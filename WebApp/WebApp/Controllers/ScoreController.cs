using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Interface;
using WebApp.Models;
using WebApp.Repositories;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        public readonly ScoreRepository repository;

        public ScoreController (ScoreRepository repository)
        {
            this.repository = repository;
        }
        [HttpPost]
        public IActionResult Create([FromBody] ScoreModel score)
        {
            repository.Add(score);
            return NoContent();
        }
        [HttpGet]
        public ActionResult<ScoreModel> Get()
        {
            var get = repository.Get();
            return Ok(get);
        }
        [HttpPut]
        public ActionResult<ScoreModel> Action([FromBody] ScoreModel score)
        {
            repository.Action(score);
            return NoContent();
        }
        [HttpDelete]
        public ActionResult<ScoreModel> Close ([FromBody]ScoreModel score)
        {
            repository.Close(score);
            return NoContent() ;
        }
    }
}
