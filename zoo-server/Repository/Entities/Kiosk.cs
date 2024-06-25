using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entities
{
   
    
        public class Kiosk
        {
        [Key]
        public int KioskID { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

            public virtual Zoo Zoo { get; set; }
        
    }
}
