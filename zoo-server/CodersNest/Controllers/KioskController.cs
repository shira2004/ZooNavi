using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiZoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KioskController : ControllerBase
    {
        private readonly IService<KioskDto> _service;

        public KioskController(IService<KioskDto> service)
        {
            _service = service;
        }
        // GET: api/<KioskController>
        [HttpGet]
        public List<KioskDto> Get()
        {
            return _service.GetAll();
        }

        // GET api/<KioskController>/5
        [HttpGet("{id}")]
        public KioskDto Get(int id)
        {
            return _service.GetById(id);
        }

        // POST api/<KioskController>
        [HttpPost]
        public KioskDto Post([FromBody] KioskDto value)
        {
            return _service.Add(value);
        }

        // PUT api/<KioskController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<KioskController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
