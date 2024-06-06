using Dapper;
using Domain.DTO;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi91.Context;


namespace WebApi91.Services
{
    public class GastosServices : IGastosServices
    {
        private readonly ApplicationDbContext _context; //Significa que es privado (_context)
        public GastosServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Response<List<Gastos>>> GetGastos()
        {
            try
            {
                List<Gastos> response = new List<Gastos>();

                var result = await _context.Gastos.ToListAsync();

                response = result.ToList();

                return new Response<List<Gastos>>(response);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error :(" + ex.Message);
            }
        }


        public async Task<Response<Gastos>> CrearGasto(GastoResponse request)
        {
            try
            {
                Gastos gasto = new Gastos()
                {
                    Descripcion = request.Descripcion,
                    Fecha = request.Fecha,
                    Cantidad = request.Cantidad,
                    Tipo = request.Tipo
                };

                _context.Gastos.Add(gasto);
                await _context.SaveChangesAsync();

                return new Response<Gastos>(gasto);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
    }
}