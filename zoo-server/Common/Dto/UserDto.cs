using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
       // public string? FirstName { get; set; }
       // public string? LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression("^(?=.*[a-zA-Z])(?=.*\\d).{6,}$", ErrorMessage = "Password must be at least 6 characters long and contain at least one letter and one digit")]
        public string Password { get; set; }
        [Required(ErrorMessage = "userName is required")]
        public string UserName { get; set; }

        public string? Image { get; set; }
        public int? points { get; set; }
        public string? Role { get; set; }

    }
}
