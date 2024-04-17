using MuscleMate_Gym.Data.Enum;
using MuscleMate_Gym.Models;
using System.Net;

namespace MuscleMate_Gym.ViewModels
{
    public class CreateExerciseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Detail Details { get; set; }
        public string Image { get; set; }
        public ExerciseCategory ExerciseCategory { get; set; }
        public string AppUserId { get; set; }
    }
}
