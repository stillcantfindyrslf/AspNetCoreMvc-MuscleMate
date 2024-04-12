using MuscleMate_Gym.Data.Enum;
using MuscleMate_Gym.Models;

namespace MuscleMate_Gym.ViewModels
{
    public class EditExerciseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Image { get; set; }
        public int DetailsId { get; set; }
        public Detail Detail { get; set; }
        public ExerciseCategory ExerciseCategory { get; set; }
    }
}
