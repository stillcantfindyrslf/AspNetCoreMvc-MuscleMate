using Microsoft.AspNetCore.Mvc;
using MuscleMate_Gym.Data;
using MuscleMate_Gym.Interfaces;
using MuscleMate_Gym.Models;

namespace MuscleMate_Gym.Controllers
{
    public class ExerciseController : Controller
    {
        private readonly IExerciseRepository _exerciseRepository;

        public ExerciseController(IExerciseRepository exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }
        
        public async Task<IActionResult> Index()
        {
            IEnumerable<Exercise> exercises = await _exerciseRepository.GetAll();
            return View(exercises);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Exercise exercise = await _exerciseRepository.GetByIdAsync(id);
            return View(exercise);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Exercise exercise)
        {
            if (!ModelState.IsValid)
            {
                return View(exercise);
            }
            _exerciseRepository.Add(exercise);
            return RedirectToAction("Index");
        }
    }
}
