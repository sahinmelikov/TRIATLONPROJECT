namespace TriatlonProject.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
       ///////
       ///burada neticeler hissesinde Email yazilacaq ve bu emailde bizim seyfeye login olan kisilere otomatik olarak bildirim gitsin diye
      public string UserEmail {  get; set; }
        public string ImagePath { get;set; }
        public string Locetion { get;set; }
       

    }
}
