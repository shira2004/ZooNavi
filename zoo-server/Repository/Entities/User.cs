using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Repository.Entities
{
    public class User
    {
        public int Id { get; set; }
       // public string FirstName { get; set; }

        //public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

       // [Required(ErrorMessage = "user name is required")]
        public string UserName { get; set; }

        public int Points { get; set; }
        public string? Image { get; set; }
     
        public string? Role { get; set; }
    }
}
