using Domain.DTO;
using Domain.Entities;

namespace WebApi91.Services
{
    public interface IGastosServices
    {
        public Task<Response<List<Gastos>>> GetGastos();
        public Task<Response<Gastos>> CrearGasto(GastoResponse request);

        
    }
}