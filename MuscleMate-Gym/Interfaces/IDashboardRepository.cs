using Microsoft.AspNetCore.Mvc;
using MuscleMate_Gym.Models;

namespace MuscleMate_Gym.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Exercise>> GetAllUserExercises();
    }
}
