
using Common.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Interface;
using Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiZoo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]
    public class AnimalController : ControllerBase
    {
        private readonly IService<AnimalDto> _service;
        //private readonly DistanceCalculationService _distanceCalculationService;
        private readonly ImageUploadService _imageUploadService;
        public AnimalController(ImageUploadService imageUploadService, DistanceCalculationService distanceCalculationService, IService<AnimalDto> service)
        {
            _service = service;
           // _distanceCalculationService = distanceCalculationService;
            _imageUploadService = imageUploadService;
        }


        [Authorize(Roles = "USER , ADMIN")]
        // GET: api/<AnimalController>
        [HttpGet]
        public List<AnimalDto> Get()
        {
            List<AnimalDto> animals = _service.GetAll();

            return animals;
        }

        // GET api/<AnimalController>/5
        [HttpGet("{id}")]
        public AnimalDto Get(int id)
        {
            return _service.GetById(id);
        }
        [Authorize(Roles = "ADMIN")]
        // POST api/<AnimalController>
        [HttpPost]
        public IActionResult Post([FromBody] AnimalDto value)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (!string.IsNullOrEmpty(value.Image))
                {
                    string fileExtension = "PNG";
                    string folderPath = "wwwroot/images";

                    value.Image = _imageUploadService.UploadImage(value.Image.Split(',')[1], folderPath, fileExtension);
                }

                var addedAnimal = _service.Add(value);

                return Ok(addedAnimal); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing the request");
            }
        }

        // PUT api/<AnimalController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] AnimalDto value)
        {
            _service.Update(id, value);
            return Ok(value);

        }
        [Authorize(Roles = "ADMIN")]
        // DELETE api/<AnimalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           
            _service.Delete(id);
        }
        
    }
}
