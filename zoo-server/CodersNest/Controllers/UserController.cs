using Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Repository.Repositories;
using Service.Interface;
using Service.Services;
using System.Security.Claims;
using WebApiZoo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiZoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        private readonly IService<UserDto> _service;
        private readonly ImageUploadService _imageUploadService;
        private readonly TokenService _tokenService;
        public UserController(
            IService<UserDto> service,
            ImageUploadService imageUploadService,
            TokenService tokenService)
        {
            _service = service;
            _imageUploadService = imageUploadService;
            _tokenService = tokenService;
        }
        [Authorize(Roles = "ADMIN")]
        // GET: api/<UserController>
        [HttpGet]
        public List<UserDto> Get()
        {
            return _service.GetAll();
        }
       [Authorize(Roles = "ADMIN")]

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public UserDto Get(int id)
        {
            return _service.GetById(id);
        }



        [Authorize(Roles = "USER")]
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDto value)
        {
            try
            {
                _service.Update(id, value);
                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }

        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
        [HttpGet("addpoint")]
        [Authorize(Roles = "USER , ADMIN")]
        [HttpPost("addpoint")]
        public IActionResult AddPoint()
        {
            try
            {
                var currentUser = GetCurrentUserUsername();

                // Find the user by username
                var user = _service.GetAll().FirstOrDefault(u => u.UserName == currentUser);

                if (user != null)
                {
                    user.points += 1;

                    _service.Update(user.Id, user);

                    return Ok(new { message = "User points updated successfully.", points = user.points });
                }
                else
                {
                    return NotFound(new { error = "User not found." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal server error." });
            }
        }

        [HttpGet("getpoints")]
        [Authorize(Roles = "USER , ADMIN")]
       

        public IActionResult getpoints()
        {
            try
            {
                var currentUser = GetCurrentUserUsername();

                // Find the user by username
                var user = _service.GetAll().FirstOrDefault(u => u.UserName == currentUser);

                if (user != null)
                {

                    return Ok(new { message = "User points  successfully.", points = user.points });
                }
                else
                {
                    return NotFound(new { error = "User not found." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal server error." });
            }
        }
        private string GetCurrentUserUsername()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                var userName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
                return userName;
            }
            return null;
        }



    }
}
