using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Net;

namespace MuscleMate_Gym.Models
{
    public class AppUser : IdentityUser
    {
        public string? Description { get; set; }
        public int? Favorites { get; set; }
        [ForeignKey("Detail")]
        public int? DetailsId { get; set; }
        public Detail? Detail { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
    }
}
