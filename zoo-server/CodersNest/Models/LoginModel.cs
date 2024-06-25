using System.ComponentModel.DataAnnotations;

namespace WebApiZoo.Models
{
    public class LoginModel
    {
        //[Required(ErrorMessage = "Email is required")]
        //[EmailAddress(ErrorMessage = "Invalid Email Address")]
        //public string Email { get; set; }
        [Required(ErrorMessage ="userName is requierd")]
        public string userName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression("^(?=.*[a-zA-Z])(?=.*\\d).{6,}$", ErrorMessage = "Password must be at least 6 characters long and contain at least one letter and one digit")]
        public string? Password { get; set; }
    }
}
