using Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiZoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class CageController : ControllerBase
    {
        private readonly ICage<CageDto> _service;

        public CageController(ICage<CageDto> service)
        {
            _service = service;
        }
        // GET: api/<CageDtoController>

        //[Authorize(Policy = "Admin")]
        [HttpGet]
        public List<CageDto> Get()
        {
            return _service.GetAll();
        }

        // GET api/<CageDtoController>/5
        [HttpGet("{id}")]
        public CageDto Get(int id)
        {
            return _service.GetById(id);
        }

        // POST api/<CageDtoController>

     [Authorize(Roles = "ADMIN")]
        [HttpPost]
        public CageDto Post([FromBody] CageDto value)
        {
            return _service.Add(value);
        }
       [Authorize(Roles = "ADMIN")]

        // PUT api/<CageDtoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<CageDtoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


        [HttpGet("cages")]
        public List<CageDto> GetByCages([FromQuery] int[] cagesIds)
        {
            if (cagesIds == null || cagesIds.Length == 0)
            {
                return _service.GetAll();
            }

            var cagesInList = _service.GetByCageId(cagesIds);
          
            return cagesInList;
        }

    }
}
