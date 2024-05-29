using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MuscleMate_Gym.Data;
using MuscleMate_Gym.Interfaces;
using MuscleMate_Gym.Models;
using MuscleMate_Gym.ViewModels;
using System.Net;

namespace MuscleMate_Gym.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        private readonly IFavoriteRepository _favoriteRepository;

        public ExerciseController(IExerciseRepository exerciseRepository, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, IFavoriteRepository favoriteRepository)
        {
            _exerciseRepository = exerciseRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
            _favoriteRepository = favoriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;

            IEnumerable<Exercise> exercises = await _exerciseRepository.GetAll();
            if (!string.IsNullOrEmpty(searchString))
            {
                exercises = await _exerciseRepository.SearchName(searchString);
            }
            return View(exercises);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            Exercise exercise = await _exerciseRepository.GetByIdAsync(id);
            return View(exercise);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var curUser = _httpContextAccessor.HttpContext.User.GetUserId();
            var createExerciseViewModel = new CreateExerciseViewModel { AppUserId = curUser };
            return View(createExerciseViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExerciseViewModel exerciseVM)
        {
            if (ModelState.IsValid)
            {
                var exercise = new Exercise
                {
                    Title = exerciseVM.Title,
                    Description = exerciseVM.Description,
                    Image = exerciseVM.Image.ToString(),
                    AppUserId = exerciseVM.AppUserId,
                    Detail = new Detail
                    {
                        Title = exerciseVM.Details.Title,
                        Description = exerciseVM.Details.Description,
                        URL = exerciseVM.Details.URL
                    }
                };
                _exerciseRepository.Add(exercise);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Error");
            }
            return View(exerciseVM);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(id);
            if (exercise == null) return View("Error");
            var exerciseVM = new EditExerciseViewModel
            {
                Title = exercise.Title,
                Description = exercise.Description,
                DetailsId = exercise.DetailsId,
                Detail = exercise.Detail,
                Image = exercise.Image,
                ExerciseCategory = exercise.ExerciseCategory
            };
            return View(exerciseVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, EditExerciseViewModel exerciseVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Error to edit exercise");
                return View("Edit", exerciseVM);
            }
            var userExercise = await _exerciseRepository.GetByIdAsyncNoTracking(id);
            if (userExercise != null)
            {
                var exercise = new Exercise
                {
                    Id = id,
                    Title = exerciseVM.Title,
                    Description = exerciseVM.Description,
                    Image = exerciseVM.Image,
                    DetailsId = exerciseVM.DetailsId,
                    Detail = exerciseVM.Detail
                };
                _exerciseRepository.Update(exercise);
                return RedirectToAction("Index");
            }
            else
            {
                return View(exerciseVM);
            }
        }
    
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var exerciseDetails = await _exerciseRepository.GetByIdAsync(id);
            if (exerciseDetails == null) return View("Error");
            return View(exerciseDetails);
        }

        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteExercise(int id)
        {
            var exerciseDetails = await _exerciseRepository.GetByIdAsync(id);
            if (exerciseDetails == null) return View("Error");

            _exerciseRepository.Delete(exerciseDetails);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorites(IEnumerable<int> exerciseIds)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            foreach (var exerciseId in exerciseIds)
            {
                await _favoriteRepository.AddFavoriteAsync(user.Id, exerciseId);
            }

            await _favoriteRepository.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromFavorites(int exerciseId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            await _favoriteRepository.RemoveFavoriteAsync(user.Id, exerciseId);
            await _favoriteRepository.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Favorites()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var favoriteExercises = await _favoriteRepository.GetFavoritesByUserIdAsync(user.Id);
            return View(favoriteExercises);
        }


    }
}
