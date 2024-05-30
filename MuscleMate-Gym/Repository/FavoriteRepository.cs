using Microsoft.EntityFrameworkCore;
using MuscleMate_Gym.Data;
using MuscleMate_Gym.Interfaces;
using MuscleMate_Gym.Models;

namespace MuscleMate_Gym.Repository
{
    public class FavoriteRepository : IFavoriteRepository
    {
        private readonly ApplicationDbContext _context;

        public FavoriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckIfExistsAsync(string userId, int exerciseId)
        {
            return await _context.Favorites.AnyAsync(f => f.AppUserId == userId && f.ExerciseId == exerciseId);
        }

        public async Task AddFavoriteAsync(string userId, int exerciseId)
        {
            if (!await CheckIfExistsAsync(userId, exerciseId))
            {
                var favorite = new Favorite
                {
                    AppUserId = userId,
                    ExerciseId = exerciseId
                };
                _context.Favorites.Add(favorite);
            }
        }

        public async Task RemoveFavoriteAsync(string userId, int exerciseId)
        {
            var favorite = await _context.Favorites
                .FirstOrDefaultAsync(f => f.AppUserId == userId && f.ExerciseId == exerciseId);

            if (favorite != null)
            {
                _context.Favorites.Remove(favorite);
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Exercise>> GetFavoritesByUserIdAsync(string userId)
        {
            return await _context.Favorites
                .Where(f => f.AppUserId == userId)
                .Include(f => f.Exercise)
                .Select(f => f.Exercise)
                .ToListAsync();
        }
    }
}
