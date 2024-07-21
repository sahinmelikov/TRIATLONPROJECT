using Microsoft.AspNetCore.Mvc;
using TriatlonProject.Models;
using TriatlonProject.Utilities.Extensions;
using TriatlonProject.ViewModel;

namespace TriatlonProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RaceController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public RaceController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Race> race = _appDbContext.Races.ToList();

            return View(race);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RaceCreateVM racesVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!racesVM.Photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photo", $"{racesVM.Photo.FileName} Sekil Tipinde olmalidir ");
                return View();
            }
            if (!racesVM.Photo.CheckFileSize(1500))
            {
                ModelState.AddModelError("Photo", $"{racesVM.Photo.FileName} - 200kb dan Cox Olmaz");
                return View();
            }

            string root = Path.Combine(_webHostEnvironment.WebRootPath, "RootAllPictures", "img");
            string fileName = await racesVM.Photo.SaveAsync(root);


            Race race = new Race()
            {
                Title = racesVM.Title,
                Description = racesVM.Description,
                DateTime = racesVM.DateTime,
             Country=racesVM.Country,
             UzgucuYolu=racesVM.UzgucuYolu,
             YarishYolu=racesVM.YarishYolu,
             VeloYolu=racesVM.VeloYolu,
                Name=racesVM.Name,
                ImagePath = fileName,


            };
            await _appDbContext.Races.AddAsync(race);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Race? news = _appDbContext.Races?.Find(Id);

            if (news == null)
            {
                return NotFound();
            }



            _appDbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }



        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Race news = await _appDbContext.Races.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }





            RaceUpdateVM updateVM = new RaceUpdateVM()
            {
                Id = news.Id,
                Title = news.Title,
                Description = news.Description,
                DateTime = news.DateTime,
                Country=news.Country,
                VeloYolu=news.VeloYolu,
                YarishYolu=news.YarishYolu,
                UzgucuYolu=news.UzgucuYolu,
                    Name = news.Name


            };

            return View("Update", updateVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(RaceUpdateVM updateVM)
        {



            Race news = await _appDbContext.Races.FindAsync(updateVM.Id);

            if (news == null)
            {
                return NotFound();
            }


            if (!updateVM.Photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photo", $"{updateVM.Photo.FileName} Sekil Tipinde olmalidir ");
                return View();
            }
            if (!updateVM.Photo.CheckFileSize(1500))
            {
                ModelState.AddModelError("Photo", $"{updateVM.Photo.FileName} - 200kb dan Cox Olmaz");
                return View();
            }

            string root = Path.Combine(_webHostEnvironment.WebRootPath, "RootAllPictures", "img");
            string fileName = await updateVM.Photo.SaveAsync(root);



            news.Title = updateVM.Title;
            news.Description = updateVM.Description;
            news.DateTime = updateVM.DateTime;
            news.ImagePath = fileName;

            news.Country = updateVM.Country;
            news.VeloYolu = updateVM.VeloYolu;
            news.YarishYolu = updateVM.YarishYolu;
            news.UzgucuYolu = updateVM.UzgucuYolu;
            news.Name = updateVM.Name;
            await _appDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
