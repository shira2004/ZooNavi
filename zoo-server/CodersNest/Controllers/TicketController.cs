using Common.Dto;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiZoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IService<TicketDto> _service;

        public TicketController(IService<TicketDto> service)
        {
            _service = service;
        }
        // GET: api/<TicketController>
        [HttpGet]
        public List<TicketDto> Get()
        {
            return _service.GetAll();
        }

        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public TicketDto Get(int id)
        {
            return _service.GetById(id);
        }

        // POST api/<TicketController>
        [HttpPost]
        public TicketDto Post([FromBody] TicketDto value)
        {
            return _service.Add(value);
        }

        // PUT api/<TicketController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<TicketController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
