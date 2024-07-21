using Microsoft.AspNetCore.Identity;

namespace TriatlonProject.Models.Auth
{
    public class AppRole : IdentityRole
    {
        public bool IsActivated { get; set; }
    }
}
