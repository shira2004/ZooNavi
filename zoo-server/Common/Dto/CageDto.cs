using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class CageDto
    {
        public int CageID { get; set; }
        [Range(-90, 90, ErrorMessage = "Latitude must be between -90 and 90 degrees.")]
        public double Latitude { get; set; }

        [Range(-180, 180, ErrorMessage = "Longitude must be between -180 and 180 degrees.")]
        public double Longitude { get; set; }
        public double Size { get; set; }
        public string Notes { get; set; }
         
        public int ZooId { get; set; }

       // public virtual Zoo Zoo { get; set; }

    }
}
