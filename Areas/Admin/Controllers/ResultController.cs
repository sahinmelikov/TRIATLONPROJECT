using Google;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TriatlonProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ResultController : Controller
    {
        private readonly AppDbContext _context;

        public ResultController(AppDbContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var sonuclar=_context.sonuclarAciklandis.Include(d=>d.Race).ToList();
            return View(sonuclar);
        }
        [HttpPost]
        public async Task<IActionResult> ToggleIsActive([FromBody] dynamic request)
        {
            int id = request.id;
            bool isActive = request.isActive;

            var race = await _context.sonuclarAciklandis.FindAsync(id);
            if (race != null)
            {
                race.IsActive = isActive;
                await _context.SaveChangesAsync();
                return Ok(new { success = true });
            }
            return NotFound(new { success = false });
        }


    }
}
