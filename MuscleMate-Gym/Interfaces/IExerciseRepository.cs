using MuscleMate_Gym.Models;

namespace MuscleMate_Gym.Interfaces
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> GetAll();
        Task<IEnumerable<Exercise>> SearchName(string SearchString);
        Task<Exercise> GetByIdAsync(int id);
        Task<Exercise> GetByIdAsyncNoTracking(int id);
        bool Add (Exercise exercise);
        bool Update(Exercise exercise);
        bool Delete(Exercise exercise);
        bool Save();
    }
}
