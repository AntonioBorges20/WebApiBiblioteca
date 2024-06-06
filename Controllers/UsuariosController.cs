using Domain.DTO;
using Microsoft.AspNetCore.Mvc;
using WebApi91.Services;

namespace WebApi91.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        public readonly IUsuarioServices _usuarioServices;
        public UsuariosController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerLista()
        {
            var result = await _usuarioServices.ObtenerUsuarios();
            return Ok(result);
        }
        [HttpGet("{id:int}")]
            
        public async Task<IActionResult> ObtenerUsuario(int id) 
        { 
            var result = await _usuarioServices.ObtenerUsuario(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody]UsuarioResponse request)
        { 
            var result = await _usuarioServices.CrearUsuario(request);
            return Ok(result);
        }

        //3er. Crear el método ActualizarUsuario en el controlador UsuariosController
        [HttpPut]
        public async Task<IActionResult> ActualizarUsuario(int id, UsuarioResponse request)
        {
            var result = await _usuarioServices.ActualizarUsuario(id, request);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> EliminarUsuario(int id)    
        {
            var result = await _usuarioServices.EliminarUsuario(id);
            return Ok(result);
        }
        
    }
}
