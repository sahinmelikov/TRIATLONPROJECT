using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TriatlonProject.Controllers
{
   
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Username"] = User.Identity.Name;
            return View();
        }
    }
}
