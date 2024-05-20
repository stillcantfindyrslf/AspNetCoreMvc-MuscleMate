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
            return await _context.Exercises.Include(e => e.Detail).FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Exercise> GetByIdAsyncNoTracking(int id)
        {
            return await _context.Exercises.Include(e => e.Detail).AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public async Task<IEnumerable<Exercise>> SearchName(string SearchString)
        {
            return await _context.Exercises.Where(e => e.Title.Contains(SearchString)).ToListAsync();
        }

        public bool Update(Exercise exercise)
        {
            _context.Update(exercise);
            return Save();
        }
    }
}
