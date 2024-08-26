using Backend_App_2.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend_App_2.Controllers
{
    
    [ApiController]
    [Route("api/")]
    public class MathController : ControllerBase
    {
        private readonly IMathService _mathService;
        private readonly ILogger<MathController> _logger;
        public MathController(IMathService mathService,ILogger<MathController> logger)
        {
            _mathService = mathService;
            _logger = logger;
        }
       
        [HttpGet]
        [Route("add")]
        public async Task<IActionResult> add([FromQuery] double x, [FromQuery] double y)
        {
            var response=await _mathService.Addition(x,y);

            return Ok(response);
        }
  
        [HttpGet]
        [Route("div")]
        public async Task<IActionResult> Div([FromQuery] double x, [FromQuery] double y)
        {
            if (y == 0)
            {
                return BadRequest("Division by zero is not allowed.");
            }
            
            var response = await _mathService.Division(x, y);

            return Ok(response);
        }

        [Route("mul")]
        [HttpGet]
        public async Task<IActionResult> Mul([FromQuery] double x, [FromQuery] double y)
        {
            var response = await _mathService.Multiplication(x, y);

            return Ok(response);
        }
        [Route("sub")]
        [HttpGet]
        public async Task<IActionResult> Sub([FromQuery] double x, [FromQuery] double y)
        {
            var response = await _mathService.Substraction(x, y);

            return Ok(response);
        }
    }
}
