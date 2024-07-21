using System.Collections.Generic;
using TriatlonProject.Models;

namespace TriatlonProject.ViewModel
{
    public class ChatViewModel
    {
        public string CurrentUsername { get; set; }
        public List<ChatMessage> Messages { get; set; }
        public List<News> NEws { get; set; }    
        public List<Race> Races { get; set; }
        public List<SonuclarAciklandi> Sonnuclar { get; set; }
    }
}
