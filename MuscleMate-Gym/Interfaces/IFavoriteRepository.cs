using MuscleMate_Gym.Models;

namespace MuscleMate_Gym.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<bool> CheckIfExistsAsync(string userId, int exerciseId);
        Task AddFavoriteAsync(string userId, int exerciseId);
        Task RemoveFavoriteAsync(string userId, int exerciseId);
        Task Save();
        Task<IEnumerable<Exercise>> GetFavoritesByUserIdAsync(string userId);
    }
}
