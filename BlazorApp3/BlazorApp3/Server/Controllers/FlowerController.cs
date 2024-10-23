using BlazorApp3.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp3.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerController : ControllerBase
    {
        private readonly FlowerContext _flowerContext;

        public FlowerController(FlowerContext flowerContext)
        {
            _flowerContext = flowerContext;
        }
        [HttpGet]
        public IActionResult GetAllFlower()
        {
            var AllFlower = _flowerContext.Select().Execute();

            return Ok(AllFlower);
        }

        [HttpGet("{id}")]
        public IActionResult GetFlowerById(int id)
        {
            var movie = _flowerContext.Select().Where(s => s.Eq(r => r.FlowerId,id)).Execute().FirstOrDefault();
            if(movie == null)
            {
                return NotFound("Not Found");
            }
            return Ok(movie);
        }
        [HttpPost]
        public IActionResult AddFlower([FromBody] Flower flower)
        {
            var newFlower = _flowerContext.Insert().WithFields(m => m.Exclude(s=>s.FlowerId)).Execute(flower, returnNewRecord:true);

            return CreatedAtAction(nameof(GetAllFlower),new {Id = newFlower.FlowerId},newFlower);
        }
    }
}
