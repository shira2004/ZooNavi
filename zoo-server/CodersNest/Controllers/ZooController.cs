using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiZoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZooController : ControllerBase
    {
        private readonly IService<ZooDto> _service;

        public ZooController(IService<ZooDto> service)
        {
            _service = service;
        }
        // GET: api/<ZooController>
        [HttpGet]
        public List<ZooDto> Get()
        {
            return _service.GetAll();
        }

        // GET api/<ZooController>/5
        [HttpGet("{id}")]
        public ZooDto Get(int id)
        {
            return _service.GetById(id);
        }

        // POST api/<ZooController>
        [HttpPost]
        public ZooDto Post([FromBody] ZooDto value)
        {
            return _service.Add(value);
        }

        // PUT api/<ZooController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<ZooController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
