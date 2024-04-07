using Microsoft.EntityFrameworkCore;
using MuscleMate_Gym.Models;
using System.Diagnostics;
using System.Net;

namespace MuscleMate_Gym.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Exercise> Exercises { get; set; }
        //public DbSet<Club> Clubs { get; set; }
        public DbSet<Details> Details { get; set; }
    }
}
