using Dapper;
using Domain.DTO;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApi91.Context;


namespace WebApi91.Services
{
    public class AutoresServices : IAutorServices
    {
        private readonly ApplicationDbContext _context; //Significa que es privado (_context)
        public AutoresServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Response<List<Autor>>> GetAutores()
        {
            try 
            {
                List<Autor> response = new List<Autor>();

                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new {}, commandType:CommandType.StoredProcedure);

                response = result.ToList();

                return new Response<List<Autor>>(response);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error :(" + ex.Message);
            }
        }

        public async Task<Response<Autor>> CrearAutor(AutorResponse i)
        {
            try
            { 
                Autor result = new Autor();

                result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spCrearAutor", new {i.Nombre, i.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();

                 return new Response<Autor>(result);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error :(" + ex.Message);
            }
        }

        public async Task<Response<Autor>> ActualizarAutor(int id, Autor i)
        {
            try
            {
                Autor result = new Autor();

                result = (await _context.Database.GetDbConnection()
                    .QueryAsync<Autor>(
                    "SpUpdateAutor", 
                    new { i.PkAutor ,i.Nombre, i.Nacionalidad }, 
                    commandType: CommandType.StoredProcedure
                    )).FirstOrDefault(x=> x.PkAutor == id);

                return new Response<Autor>(result);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error :(" + ex.Message);
            }
        }

        public async Task<Response<Autor>> DeleteAutor(int PkAutor)
        {
            try
            {
                Autor result = new Autor();

                result = (await _context.Database.GetDbConnection()
                    .QueryAsync<Autor>(
                    "spDeleteAutor",
                    new { PkAutor},
                    commandType: CommandType.StoredProcedure
                    )).FirstOrDefault(x => x.PkAutor == PkAutor);

                return new Response<Autor>(result);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error :(" + ex.Message);
            }
        }

    }
}
