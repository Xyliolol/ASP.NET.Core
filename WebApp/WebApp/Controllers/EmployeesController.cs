using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IMapper _mapper;
        private readonly IPersonReposinory _employeerRepository;

        public EmployeesController(ILogger<EmployeesController> logger, IPersonReposinory reposinory, IMapper mapper)
        {
            _logger = logger;
            _employeerRepository = reposinory;
            _mapper = mapper;
        }

        [HttpGet("employees/{EmployeesId}")]
        public IActionResult GetEmployeerById([FromRoute] int Id)
        {
            return Ok();
        }


        [HttpGet("employees/{EmployeesName}")]
        public IActionResult GetEmployeerByName([FromRoute] string Firstname)
        {
            return Ok();
        }


        [HttpPost("register")]
        public IActionResult AddEmployeer([FromBody] EmployeesModel entity)

        {
            return Ok();
        }


        [HttpPut("update")]
        public IActionResult UpdateEmployeer([FromBody] EmployeesModel entity)

        {
            return Ok();
        }


        [HttpDelete("delete")]
        public IActionResult DeleteEmployeer([FromBody] EmployeesModel entity)
        {
            return Ok();
        }
    }
}
