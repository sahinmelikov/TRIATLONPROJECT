using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TriatlonProject.Hubs;
using TriatlonProject.Models;
using TriatlonProject.Models.Auth;
using TriatlonProject.Services;
using TriatlonProject.ViewModel;

namespace TriatlonProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly TranslationService _translationService;
        private readonly IHubContext<ChatHub> _hubContext;
    private readonly UserManager<AppUser> _userManager;

        public HomeController(AppDbContext context, TranslationService translationService, IHubContext<ChatHub> hubContext = null, UserManager<AppUser> userManager = null)
        {
            _context = context;
            _translationService = translationService;
            _hubContext = hubContext;
            _userManager = userManager;
        }
        public async Task<IActionResult> RegisterYarishma(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var raceitem = _context.Races.FirstOrDefault(n => n.Id == id);
            if (raceitem == null)
            {
                return NotFound();
            }

            var model = new RegistrationViewModel
            {
                Name = user.UserName,
                EmailAddres = user.Email,
                RaceId = raceitem.Id
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult RegisterYarishma(RegistrationViewModel model)
        {
            var raceitem = _context.Races.FirstOrDefault(n => n.Id == model.RaceId);
            if (raceitem == null)
            {
                return NotFound();
            }

            var existingRegistration = _context.RaceRegisterUsers
                .FirstOrDefault(r => r.EmailAddres == model.EmailAddres && r.RaceId == model.RaceId);

            if (existingRegistration != null)
            {
                TempData["ErrorMessage"] = "Siz artıq qeydiyyatdan keçmisiniz. Hesabınızdan izləyə bilərsiniz.";
                return RedirectToAction("RegisterYarishma", new { id = model.RaceId });
            }

            if (!ModelState.IsValid)
            {
                var registration = new RaceRegisterUser
                {
                    Name = model.Name,
                    SurName = model.SurName,
                    EmailAddres = model.EmailAddres,
                    Country = model.Country,
                    NewYear = model.NewYear,
                    T_ShirtSie = model.T_ShirtSie,
                    RaceId = model.RaceId,
                    Cinsi = model.Cinsi
                };

                _context.RaceRegisterUsers.Add(registration);
                _context.SaveChanges();

                return RedirectToAction("RegisterYarishma");
            }

            return View(model);
        }

        public IActionResult Payment()
        {
            return View();
        }

        public async Task<IActionResult> RaceAll(int id)
        {
            var raceResults = await _context.RaceRegisterUsers
                .Include(r => r.Race)
                .Where(r => r.RaceId == id)
                .ToListAsync();

            if (raceResults == null || raceResults.Count == 0)
            {
                return NotFound();
            }

            return View(raceResults);
        }

        public IActionResult Index()
        {
            var currentUsername = User.Identity.Name;
            var messages = _context.ChatMessages
                                    .Where(m => m.SenderUsername == currentUsername || m.ReceiverUsername == currentUsername)
                                    .OrderBy(m => m.Timestamp)
                                    .ToList();

            var viewModel = new ChatViewModel
            {
                NEws=_context.Newss.ToList(),
                CurrentUsername = currentUsername,
                Messages = messages,
                Races=_context.Races.ToList(),
                Sonnuclar=_context.sonuclarAciklandis.Include(d=>d.Race).ToList()
            };

            return View(viewModel);
        }
        public IActionResult NavbarRace()
        {
            var viewModel = new ChatViewModel
            {
                NEws = _context.Newss.ToList(),
              
           
                Races = _context.Races.ToList(),
                Sonnuclar = _context.sonuclarAciklandis.Include(d => d.Race).ToList()
            };
            return View(viewModel);
        }
        public IActionResult ViewDetailsRace(int id)
        {
			var raceitem = _context.Races.FirstOrDefault(n => n.Id == id);
			if (raceitem == null)
			{
				return NotFound();
			}

			// Benzer haberleri almak için örnek bir mantık
			var similarRace = _context.Races
									  .Where(n => n.Id != id)
									  .OrderByDescending(n => n.DateTime)
									  .Take(3)
									  .ToList();

			var viewModel = new RaceDetailsViewModel
			{
				RaceItem = raceitem,
				SimilarRAce = similarRace
			};

			return View(viewModel);
		}
        // NewsDescript eylemi
        public IActionResult NewsDescript(int id)
        {
            var newsItem = _context.Newss.FirstOrDefault(n => n.Id == id);
            if (newsItem == null)
            {
                return NotFound();
            }

            // Benzer haberleri almak için örnek bir mantık
            var similarNews = _context.Newss
                                      .Where(n => n.Id != id)
                                      .OrderByDescending(n => n.DateTime)
                                      .Take(3)
                                      .ToList();

            var viewModel = new NewsDescriptViewModel
            {
                NewsItem = newsItem,
                SimilarNews = similarNews
            };

            return View(viewModel);
        }
    
        [HttpPost]
        public async Task<IActionResult> SendMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                var currentUsername = User.Identity.Name;
                var chatMessage = new ChatMessage
                {
                    SenderUsername = currentUsername,
                    ReceiverUsername = "Operator",
                    Text = message,
                    Timestamp = DateTime.Now
                };

                _context.ChatMessages.Add(chatMessage);
                await _context.SaveChangesAsync();

                await _hubContext.Clients.All.SendAsync("ReceiveMessage", chatMessage.SenderUsername, chatMessage.Text);
            }

            return Ok();
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Operator()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        public async Task<IActionResult> ChangeLanguage(string culture)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) }
            );

            var persons = await _context.Persons.ToListAsync();
            foreach (var person in persons)
            {
                person.Name = await _translationService.TranslateTextAsync(person.Name, culture);
                person.Description = await _translationService.TranslateTextAsync(person.Description, culture);
            }

            return View("Index", persons);
        }

        public override bool Equals(object? obj)
        {
            return obj is HomeController controller &&
                   EqualityComparer<IHubContext<ChatHub>>.Default.Equals(_hubContext, controller._hubContext);
        }
    }
}
