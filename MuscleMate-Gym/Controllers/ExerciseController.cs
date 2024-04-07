﻿using Microsoft.AspNetCore.Mvc;
using MuscleMate_Gym.Data;
using MuscleMate_Gym.Interfaces;
using MuscleMate_Gym.Models;
using MuscleMate_Gym.ViewModel;

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

        [HttpGet]
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(id);
            if (exercise == null) return View("Error");
            var exerciseVM = new EditExerciseViewModel
            {
                Title = exercise.Title,
                Description = exercise.Description,
                ВetailsId = exercise.ВetailsId,
                Details = exercise.Details,
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
            if(userExercise != null)
            {
                var exercise = new Exercise
                {
                    Id = id,
                    Title = exerciseVM.Title,
                    Description = exerciseVM.Description,
                    Image = exerciseVM.Image,
                    ВetailsId = exerciseVM.ВetailsId,
                    Details = exerciseVM.Details
                };
                _exerciseRepository.Update(exercise);
                return RedirectToAction("Index");
            }
            else
            {
                return View(exerciseVM);
            }
        }
    }
}
