using System.ComponentModel.DataAnnotations;

namespace MuscleMate_Gym.Models
{
    public class Favorite
    {
        [Key]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public int ExerciseId { get; set; }
        public Exercise Exercise { get; set; }
    }
}
