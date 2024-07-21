using Microsoft.AspNetCore.Identity;

namespace TriatlonProject.Models.Auth
{
    public class AppUser : IdentityUser
    {
        public string Fullname { get; set; }
        public bool IsActivated { get; set; }
     
 
    }
}
