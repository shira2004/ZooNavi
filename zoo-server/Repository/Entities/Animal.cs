using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class Animal
    {
        [Key]
        public int animalId { get; set; } 
        public int CageID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; } 

        public string? Image { get; set; }
        public TimeSpan? FeedingTime { get; set; }
        public virtual Cage Cage { get; set; }
       
    }
}
