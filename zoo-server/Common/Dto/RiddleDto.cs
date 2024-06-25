using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public enum AnswerId
    {
        One = 1,
        Two = 2,
        Three = 3
    }
    public class RiddleDto
    {
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Question is required")]
        [MinLength(10, ErrorMessage = "Question must be at least 10 characters long")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Answer 1 is required")]
        [MinLength(2, ErrorMessage = "Answer 1 must be at least 2 characters long")]
        public string Answer1 { get; set; }

        [Required(ErrorMessage = "Answer 2 is required")]
        [MinLength(2, ErrorMessage = "Answer 2 must be at least 2 characters long")]
        public string Answer2 { get; set; }

        [Required(ErrorMessage = "Answer 3 is required")]
        [MinLength(2, ErrorMessage = "Answer 3 must be at least 2 characters long")]
        public string Answer3 { get; set; }
        public AnswerId CorrectAnswerId { get; set; }
        public int animalId { get; set; }
        // public int animalId { get; set; }
        //public AnimalDto? animal { get; set; }
    }

}
