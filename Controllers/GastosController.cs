using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi91.Services;


namespace WebApi91.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GastosController : ControllerBase
    {
        private readonly IGastosServices _gastoServices;
        public GastosController(IGastosServices gastoServices)
        {
            _gastoServices = gastoServices;
        }

        [HttpGet]

        public async Task<IActionResult> GetGastos()
        {
            var result  = await _gastoServices.GetGastos();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearGasto([FromBody] GastoResponse request)
        {
            var result = await _gastoServices.CrearGasto (request);

            return Ok(result);
        }
    }
    
}
