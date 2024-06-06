using Domain.DTO;
using Domain.Entities;

namespace WebApi91.Services
{
    public interface IUsuarioServices
    {
        public Task<Response<List<Usuario>>> ObtenerUsuarios();

        public Task<Response<Usuario>> ObtenerUsuario(int id);

        public Task<Response<Usuario>> CrearUsuario(UsuarioResponse request);
        //2do. Crear el método ActualizarUsuario en la interfaz IUsuarioServices
        public Task<Response<Usuario>> ActualizarUsuario(int id, UsuarioResponse request);

        public Task<Response<Usuario>> EliminarUsuario(int id);
    }
}
