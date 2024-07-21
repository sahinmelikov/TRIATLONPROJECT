using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using TriatlonProject.Hubs;
using TriatlonProject.Models;
using TriatlonProject.ViewModel;
using System.Linq;

namespace TriatlonProject.Controllers
{
    public class OperatorController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<ChatHub> _hubContext;

        public OperatorController(AppDbContext context, IHubContext<ChatHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            var viewModel = new OperatorViewModel
            {
                CurrentUsername = "Operator",
                Messages = _context.ChatMessages.ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(string message, string selectedUser)
        {
            var newMessage = new ChatMessage
            {
                SenderUsername = "Operator",
                ReceiverUsername = selectedUser,
                Text = message,
                Timestamp = DateTime.Now
            };

            _context.ChatMessages.Add(newMessage);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", newMessage.SenderUsername, newMessage.Text);

            return Ok();
        }

        [HttpGet]
        public IActionResult GetMessages(string username)
        {
            var messages = _context.ChatMessages
                .Where(m => m.SenderUsername == username || m.ReceiverUsername == username)
                .OrderBy(m => m.Timestamp)
                .ToList();

            return Json(messages);
        }
    }
}
