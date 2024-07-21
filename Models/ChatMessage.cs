namespace TriatlonProject.Models
{
    public class ChatMessage
    {
        public int Id { get; set; }
        public string SenderUsername { get; set; }
        public string ReceiverUsername { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
    }


}


