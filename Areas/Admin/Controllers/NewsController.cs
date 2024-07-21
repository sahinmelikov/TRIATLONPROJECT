using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TriatlonProject.Models;
using TriatlonProject.Utilities.Extensions;
using TriatlonProject.ViewModel;

namespace TriatlonProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NewsController(AppDbContext appDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _appDbContext = appDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<News> news = _appDbContext.Newss.ToList();

            return View(news);
        }
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NewsCreateVM newsVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (!newsVM.Photo.CheckContentType("image/"))
            {
                ModelState.AddModelError("Photo", $"{newsVM.Photo.FileName} Sekil Tipinde olmalidir ");
                return View();
            }
            if (!newsVM.Photo.CheckFileSize(1500))
            {
                ModelState.AddModelError("Photo", $"{newsVM.Photo.FileName} - 200kb dan Cox Olmaz");
                return View();
            }

            string root = Path.Combine(_webHostEnvironment.WebRootPath, "RootAllPictures", "img");
            string fileName = await newsVM.Photo.SaveAsync(root);


            News news = new News()
            {
                Title = newsVM.Title,
                Description=newsVM.Description,
                DateTime=newsVM.DateTime,

                ImagePath=fileName,


            };
            await _appDbContext.Newss.AddAsync(news);
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            News? news = _appDbContext.Newss?.Find(Id);

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
            News news = await _appDbContext.Newss.FindAsync(id);
            if (news == null)
            {
                return NotFound();
            }

           



            NewsUpdateVM updateVM = new NewsUpdateVM()
            {
                Id = news.Id,
                Title = news.Title,
                Description=news.Description,
                DateTime=news.DateTime,



            };

            return View("Update", updateVM);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(NewsUpdateVM updateVM)
        {



            News news = await _appDbContext.Newss.FindAsync(updateVM.Id);

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
            news.Description=updateVM.Description;
            news.DateTime = updateVM.DateTime;
            news.ImagePath = fileName;



            await _appDbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
