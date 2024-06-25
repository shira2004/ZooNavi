using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{

   
        public class Ticket
        {
        [Key]
        public int TicketID { get; set; }

            public int price { get; set; }

            public virtual Zoo Zoo { get; set; }
        }
    
    
}
