//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.SignalR;
//using System;
//using System.Linq;
//using System.Threading.Tasks;
//using TriatlonProject.Hubs;
//using TriatlonProject.Models;
//using TriatlonProject.ViewModel;

//namespace TriatlonProject.Controllers
//{
//    public class UserController : Controller
//    {
//        private readonly AppDbContext _context;
//        private readonly IHubContext<ChatHub> _hubContext;

//        public UserController(AppDbContext context, IHubContext<ChatHub> hubContext)
//        {
//            _context = context;
//            _hubContext = hubContext;
//        }

//        public IActionResult Index()
//        {
//            var viewModel = new ChatViewModel
//            {
//                Messages = _context.ChatMessages.ToList(),
//                CurrentUsername = User.Identity.Name
//            };

//            return View(viewModel);
//        }

//        // Controller
//        [HttpPost]
//        public async Task<IActionResult> SendMessage(ChatViewModel viewModel)
//        {
//            if (!string.IsNullOrEmpty(viewModel.NewMessage))
//            {
//                var message = new ChatMessage
//                {
//                    SenderUsername = viewModel.CurrentUsername,
//                    Message = viewModel.NewMessage,
//                    TimeSent = DateTime.Now
//                };

//                _context.ChatMessages.Add(message);
//                _context.SaveChanges();

//                // Call the SendMessage method in the ChatHub
//                await _hubContext.Clients.All.SendAsync("ReceiveMessage", message.SenderUsername, message.Message);
//            }

//            return RedirectToAction("Index");
//        }
//    }
//}
