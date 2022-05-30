
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Repositories;
using WebApp.Services;
using WebApp.Validation;

namespace WebApp.Controllers
{
    [Authorize]
    [Route("employeer/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public readonly IEmployeerRepository _employeerRepository;
        public readonly EmployeerRepository employeerRepository;
        private IEmployeerValidator employeerValidator;
        private IEmpDelValidator employeerDelValidator;

        public EmployeesController(IEmployeerRepository empRepo,
           IEmployeerValidator employeerValidator,
            IEmpDelValidator employeerDelValidator)
        {
            this._employeerRepository = empRepo;
            this.employeerValidator = employeerValidator;
            this.employeerDelValidator = employeerDelValidator;
        }
        public EmployeesController(EmployeerRepository employeerRepository,
            IEmployeerValidator employeerValidator,
            IEmpDelValidator employeerDelValidator)

        {
         this. employeerRepository = employeerRepository;
            this.employeerValidator = employeerValidator;
            this.employeerDelValidator = employeerDelValidator;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = employeerRepository.Get();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] EmployeerModel newEmployeer)

        {          
            var validation = new OperationResult<EmployeerModel>(employeerValidator.ValidateEntity(newEmployeer));
            if (!validation.Succeed)
            {
                return BadRequest(validation);
            }
             employeerRepository.Add(newEmployeer);
            return NoContent();
        }

        [HttpPut]
        public IActionResult Update([FromBody] EmployeerModel newEmployeer)

        {
            employeerRepository.Update(newEmployeer);
            return Ok(newEmployeer);
        }

        [HttpDelete]
        public IActionResult Delete( int Id)
        {
            var request = new EmployeerDeleteModel { Id = Id };
            var validation = new OperationResult<EmployeerDeleteModel>(employeerDelValidator.ValidateEntity(request));
            if (!validation.Succeed)
            {
                return BadRequest(validation);
            }
            employeerRepository.Delete(Id);
            return NoContent();
        }
       
    }
}
