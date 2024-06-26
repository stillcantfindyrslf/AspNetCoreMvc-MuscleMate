﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Net;
using MuscleMate_Gym.Data.Enum;

namespace MuscleMate_Gym.Models
{
    public class Exercise
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        [ForeignKey("Detail")]
        public int DetailsId { get; set; }
        public Detail Detail { get; set; }
        public ExerciseCategory ExerciseCategory { get; set; }
        [ForeignKey("AppUser")]
        public string? AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
    }
}
