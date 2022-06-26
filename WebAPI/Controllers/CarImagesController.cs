using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService=carImageService;
        }

        [HttpPost("add")]
        public IActionResult Add( IFormFile file,  int carId)
        {
            
            var result = _carImageService.Add(carId,file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Success);
        }
      

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetByCarId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Success);
        }

  
        [HttpPut("update")]
        public IActionResult Update(IFormFile file,int id)
        {
            var result = _carImageService.Update(id,file);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Success);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var result = _carImageService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Success);
        }
    }
}
