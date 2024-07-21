using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TriatlonProject.Models;
using TriatlonProject.Models.Auth;

namespace TriatlonProject
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
        public DbSet<User> Users { get;set; }
        public DbSet<News> Newss { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceRegisterUser> RaceRegisterUsers { get; set;}
        public DbSet<SonuclarAciklandi> sonuclarAciklandis { get; set; }

    }
}
