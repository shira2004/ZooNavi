using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{

        public class Cage
        {
        [Key]
            public int CageID { get; set; }
           public double Latitude { get; set; }
             public double Longitude { get; set; }
            public double Size { get; set; }
            public string Notes { get; set; }

             public int ZooId { get; set; }

           
        }
    }

