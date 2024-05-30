using Microsoft.AspNetCore.Mvc;
using MuscleMate_Gym.Interfaces;
using MuscleMate_Gym.Models;
using MuscleMate_Gym.ViewModels;

namespace MuscleMate_Gym.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardrepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DashboardController(IDashboardRepository dashboardrepository, IHttpContextAccessor httpContextAccessor)
        {
            _dashboardrepository = dashboardrepository;
            _httpContextAccessor = httpContextAccessor;
        }
        public void MapUserEdit(AppUser user, EditUserDashboardViewModel editVM)
        {
            user.Id = editVM.Id;
            user.UserName = editVM.UserName;
            user.Description = editVM.Description;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userExercises = await _dashboardrepository.GetAllUserExercises();
            var dashboardViewModel = new DashboardViewModel()
            {
                Exercises = userExercises,
            };
            return View(dashboardViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditUserProfile()
        {
            var curUserId = _httpContextAccessor.HttpContext.User.GetUserId();
            var user = await _dashboardrepository.GetUserById(curUserId);
            if (user == null) return View("Error");
            var editUserViewModel = new EditUserDashboardViewModel()
            {
                Id = curUserId,
                UserName = user.UserName,
                Description = user.Description
            };
            return View(editUserViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserProfile(EditUserDashboardViewModel editVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit profile");
                return View("EditUserProfile", editVM);
            }

            AppUser user = await _dashboardrepository.GetByIdNoTracking(editVM.Id);

            if (user != null)
            {
                MapUserEdit(user, editVM);

                _dashboardrepository.Update(user);

                return RedirectToAction("Index");
            }
            return RedirectToAction("Error");
        }
    }
}