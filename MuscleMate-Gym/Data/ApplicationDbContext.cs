using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuscleMate_Gym.Migrations;
using MuscleMate_Gym.Models;
using System.Diagnostics;
using System.Net;

namespace MuscleMate_Gym.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
    }
}
