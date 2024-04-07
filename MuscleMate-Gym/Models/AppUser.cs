using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Net;

namespace MuscleMate_Gym.Models
{
    public class AppUser
    {
        [Key]
        public string Id { get; set; }
        public int? Pace { get; set; }
        public int? Mileage { get; set; }
        [ForeignKey("Details")]
        public int DetailsId { get; set; }
        public Details? Details { get; set; }
        public ICollection<Exercise> Exercises { get; set; }
        //public ICollection<Exercise> Races { get; set; }
    }
}
