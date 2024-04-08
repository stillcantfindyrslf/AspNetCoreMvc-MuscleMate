using Microsoft.EntityFrameworkCore;
using MuscleMate_Gym.Data;
using MuscleMate_Gym.Interfaces;
using MuscleMate_Gym.Models;

namespace MuscleMate_Gym.Repository
{
    public class ExerciseRepository : IExerciseRepository
    {
        private ApplicationDbContext _context;

        public ExerciseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Exercise exercise)
        {
            _context.Add(exercise);
            return Save();
        }

        public bool Delete(Exercise exercise)
        {
            _context.Remove(exercise);
            return Save();
        }

        public async Task<IEnumerable<Exercise>> GetAll()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise> GetByIdAsync(int id)
        {
            return await _context.Exercises.Include(i => i.Detail).FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<Exercise> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Exercises.Include(i => i.Detail).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Exercise>> GetExirciseByTitle(string title)
        {
            return await _context.Exercises.Where(c => c.Detail.Title.Contains(title)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Exercise exercise)
        {
            _context.Update(exercise);
            return Save();
        }
    }
}
