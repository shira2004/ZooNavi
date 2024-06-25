using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
    public class Zoo
    {
        [Key]
        public int ZooID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Cage> Cages { get; set; }
    }
}
