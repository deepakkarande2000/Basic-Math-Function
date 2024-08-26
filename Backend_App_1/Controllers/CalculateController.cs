using Backend_App_1.Interface;
using Backend_App_1.Modals;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Backend_App_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateController : ControllerBase
    {
        private readonly ICalculateService calculateService;
        private readonly ILogger<CalculateController> _logger;
        string[] validOpcodes = new[] { "add", "mul", "div", "sub" };
        public CalculateController(ICalculateService _calculateservice, ILogger<CalculateController> logger)
        {
            calculateService = _calculateservice;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> calculate([FromQuery] double i,double j,string opcode)
        {
            if (opcode == null || !validOpcodes.Contains(opcode.Trim().ToLower()))
            {
                return BadRequest(new GenericReponseModal { StatusCode = HttpStatusCode.BadRequest,
                    Message = "Bad Request", Payload = "" });
            }
            try
            {
                var response = await calculateService.Calculate(i, j, opcode);
                return Ok(new GenericReponseModal { StatusCode = HttpStatusCode.OK, Message = "Data received", Payload = response });

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return BadRequest(new GenericReponseModal { StatusCode = HttpStatusCode.InternalServerError, Message = "Exception ocure" + ex.ToString(), Payload = "" });                
            }            
        }
    }
}
