using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TriatlonProject.Models;

namespace TriatlonProject.Areas.Admin.Controllers
{[Area("Admin")]
    public class ReqisterRaceUserController : Controller
    {
        
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ReqisterRaceUserController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _context = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
            {
                List<RaceRegisterUser> raceregister = _context.RaceRegisterUsers.Include(d=>d.Race).ToList();

                return View(raceregister);
            }

        // GET: RegisterRaceUser/Create
        public IActionResult Create(int id)
        {
            var raceUser = _context.RaceRegisterUsers.Include(r => r.Race).FirstOrDefault(r => r.Id == id);
            if (raceUser == null)
            {
                return NotFound();
            }

            return View(raceUser);
        }

        // POST: RegisterRaceUser/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id, RaceRegisterUser model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            // RaceRegisterUser tablosundaki id'yi kullanarak ilgili kaydı bulun
            var raceUser = _context.RaceRegisterUsers.Include(r => r.Race).FirstOrDefault(r => r.Id == model.Id);
            if (raceUser == null)
            {
                return NotFound();
            }

         
                // Update the raceUser with the new data
                raceUser.Sonuc = model.Sonuc; // veya güncellemek istediğiniz diğer özellikler
                _context.Update(raceUser);
                await _context.SaveChangesAsync();
      
            return RedirectToAction(nameof(Index)); // veya yönlendirmek istediğiniz başka bir eylem
        }

    }
}
