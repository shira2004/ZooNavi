using CodeFirst;
using Common.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using Repository.Entities;
using Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiZoo.Models;
using static System.Net.Mime.MediaTypeNames;

namespace WebApiZoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly DataContext _dataContext;
        private readonly IService<UserDto> _service;

        private readonly ImageUploadService _imageUploadService;

        public AuthController(
            IConfiguration configuration,
            IService<UserDto> service,
            DataContext dataContext,
            ImageUploadService imageUploadService)
        {
            _configuration = configuration;
            _dataContext = dataContext;
            _imageUploadService = imageUploadService;
            _service = service;
        }


        [HttpPost("/api/login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            UserDto user = _service.GetAll().FirstOrDefault(u => u.UserName == loginModel.userName && u.Password != null);
            if (user is not null)
            {
                bool passwordMatch = BCrypt.Net.BCrypt.Verify(loginModel.Password, user.Password);
                if (passwordMatch)
                {
                    var jwt = CreateJWT(user);
                    string base64Image = user.Image;
                    var response = new
                    {
                        UserName = user.UserName,
                        UserImage = base64Image,
                        Token = jwt
                    };
                    // AddSession(user);
                    return Ok(response);
                }
            }
            return Unauthorized();
        }
        [HttpPost("/api/register")]
        public IActionResult Register([FromBody] UserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_dataContext.users.Any(u => u.UserName == user.UserName))
            {
                ModelState.AddModelError("UserName", "Username already exists.");
                return BadRequest(ModelState);
            }
            if (_dataContext.users.Any(u => u.Email == user.Email))
            {
                ModelState.AddModelError("email", "email already exists.");
                return BadRequest(ModelState);
            }

            if (!string.IsNullOrEmpty(user.Image))
            {
                string fileExtension = "PNG";
                string folderPath = "wwwroot/images";

                user.Image = _imageUploadService.UploadImage(user.Image.Split(',')[1], folderPath, fileExtension);
            }
            user.Role = "USER";

            var newUser = _service.Add(user);
            if (newUser != null)
            {
                var jwt = CreateJWT(newUser);
                var response = new
                {
                    UserName = newUser.UserName,
                    UserImage = newUser.Image,
                    Token = jwt
                };
                return Ok(response);
            }
            return BadRequest(ModelState);

        }
        private object CreateJWT(UserDto user)
        {
            var claims = new List<Claim>()
                {
                  new Claim(ClaimTypes.Name, user.UserName),  // Store username
                  new Claim(ClaimTypes.Email, user.Email),    // Store email
                  new Claim(ClaimTypes.Role, user.Role)       // Store role
                };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration["JWT:issuer"],
                audience: _configuration["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return new { Token = tokenString };
        }








    }
}