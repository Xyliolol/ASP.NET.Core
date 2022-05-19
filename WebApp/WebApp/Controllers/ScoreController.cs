using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult<ScoreModel>> Create()
        {

            await repository.Add();
            return NoContent();
        }
        [HttpGet]
        public ActionResult<ScoreModel> Get()
        {
            var get = repository.Get();
            return Ok(get);
        }
        [HttpPut]
        public async Task<ActionResult<ScoreModel>> Action([FromBody] ScoreModel score)
        {
            await repository.Action(score);
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult<ScoreModel>> Close ([FromBody]ScoreModel score)
        {
            await repository.Close(score);
            return NoContent() ;
        }
    }
}
