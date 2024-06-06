using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApi91.Services;

namespace WebApi91.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutoresController : ControllerBase
    {
        private readonly IAutorServices _autorServices;
        public AutoresController(IAutorServices autorServices)
        {
            _autorServices = autorServices;
        }

        [HttpGet]

        public async Task<IActionResult> GetAutores()
        {
            var result  = await _autorServices.GetAutores();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearAutor([FromBody] AutorResponse request)
        {
            var result = await _autorServices.CrearAutor(request);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarAutor(int id, Autor autor)
        {
            var result = await _autorServices.ActualizarAutor(id, autor);

            return Ok(result);
        }

        [HttpDelete("{PkAutor}")]
        public async Task<IActionResult> DeleteAutor(int PkAutor)
        {
            var result = await _autorServices.DeleteAutor(PkAutor);

            return Ok(result);
        }

    }
}
