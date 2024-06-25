using System;
using System.ComponentModel.DataAnnotations;

namespace Common.Dto
{
    public class AnimalDto
    {
        public int AnimalId { get; set; }
        public int CageId { get; set; }

        [Required(ErrorMessage = "Animal name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Animal name must be at least 2 characters long.")]
        public string Name { get; set; }


        [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be at least 10 characters long.")]
        public string Description { get; set; }

        public string? Image { get; set; }
        public TimeSpan? FeedingTime { get; set; }

       
    }
}
