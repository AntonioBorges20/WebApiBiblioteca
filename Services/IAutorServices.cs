using Domain.DTO;
using Domain.Entities;

namespace WebApi91.Services
{
    public interface IAutorServices
    {
        public Task<Response<List<Autor>>> GetAutores();

        public Task<Response<Autor>> CrearAutor(AutorResponse i);

        public Task<Response<Autor>> ActualizarAutor(int id, Autor autor);

        public Task<Response<Autor>> DeleteAutor(int PkAutor);

    };
}
