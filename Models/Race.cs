namespace TriatlonProject.Models
{
    public class Race
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Title { get; set; }    
        public string Description { get; set; }
        public string Country { get; set; } 
        public string ImagePath {  get; set; }  
        public double UzgucuYolu { get; set; }   
        public double VeloYolu { get; set; }
        public double YarishYolu { get; set; }
        public DateTime DateTime { get; set; }
        public double BiletQiymeti { get; set; }
        public List<Race> Races { get; set; }  
       
    }
}
