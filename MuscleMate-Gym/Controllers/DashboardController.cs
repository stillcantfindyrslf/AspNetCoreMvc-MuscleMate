using Microsoft.AspNetCore.Mvc;
using MuscleMate_Gym.Interfaces;
using MuscleMate_Gym.ViewModels;

namespace MuscleMate_Gym.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardrepository;
        public DashboardController(IDashboardRepository dashboardrepository)
        {
            _dashboardrepository = dashboardrepository;
        }
        public async Task<IActionResult> Index()
        {
            var userExercises = await _dashboardrepository.GetAllUserExercises();
            var dashboardViewModel = new DashboardViewModel()
            {
                Exercises = userExercises,
            };
            return View(dashboardViewModel);
        }
    }
}