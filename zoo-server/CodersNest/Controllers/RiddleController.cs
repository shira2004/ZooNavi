using Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Interface;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiZoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiddleController : ControllerBase
    {
        private readonly IService<RiddleDto> _service;

        public RiddleController(IService<RiddleDto> service)
        {
            _service = service;
        }
       [Authorize(Roles = "ADMIN")]

        // GET: api/<RiddleController>
        [HttpGet]
        public List<RiddleDto> Get()
        {
            return _service.GetAll();
        }

        // GET api/<RiddleController>/5
        [HttpGet("{id}")]
        public RiddleDto Get(int id)
        {
            return _service.GetById(id);
        }
       [Authorize(Roles = "ADMIN")]

        // POST api/<RiddleController>
        [HttpPost]
        public RiddleDto Post([FromBody] RiddleDto value)
        {
            return _service.Add(value);
        }
      [Authorize(Roles = "ADMIN")]

        // PUT api/<RiddleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }
       [Authorize(Roles = "ADMIN")]

        // DELETE api/<RiddleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
      // [Authorize(Roles = "USER , ADMIN")]
        // GET api/<RiddleController>/animal/5
        [HttpGet("riddle/{animalId}")]
        public IActionResult GetRiddleByAnimalId(int animalId)
        {
            var riddle = _service.GetAll().FirstOrDefault(r => r.animalId == animalId);
            if (riddle != null)
                return Ok(riddle);
            else
                return NotFound();
        }
    }
}
