using System.ComponentModel.DataAnnotations;

namespace MuscleMate_Gym.Models
{
    public class Detail
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string URL { get; set; }
    }
}
