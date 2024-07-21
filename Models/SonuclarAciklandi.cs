namespace TriatlonProject.Models
{
    public class SonuclarAciklandi
    {
        public int Id { get;set; }
        public Race Race { get; set; }
        public int? RaceId { get;set; }
        public  bool? IsActive { get; set; }
    }
}
