using System.Collections.Generic;
using TriatlonProject.Models;

namespace TriatlonProject.ViewModel
{
    public class OperatorViewModel
    {
        public string CurrentUsername { get; set; }
        public List<ChatMessage> Messages { get; set; }
    }
}
