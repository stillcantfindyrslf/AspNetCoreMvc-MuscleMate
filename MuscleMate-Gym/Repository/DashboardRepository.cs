using MuscleMate_Gym.Data;
using MuscleMate_Gym.Interfaces;
using MuscleMate_Gym.Models;

namespace MuscleMate_Gym.Repository
{
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DashboardRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<Exercise>> GetAllUserExercises()
        {
            var curUser = _httpContextAccessor.HttpContext?.User.GetUserId();
            var userExercises = _context.Exercises.Where(r => r.AppUser.Id == curUser);
            return userExercises.ToList();
        }
    }
}
