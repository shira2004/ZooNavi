using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public enum AnswerId
    {
        c = 1,
        Two = 2,
        Three = 3
    }

    public class Riddle
    {
        [Key]
        public int QuestionId { get; set; }

        public string Question { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public AnswerId CorrectAnswerId { get; set; }
        public int animalId { get; set; }
       // [ForeignKey("animalId")]
       // public virtual Animal? animal { get; set; }
    }

}
