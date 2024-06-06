using Domain.Entities;
using WebApi91.Context;
using Microsoft.EntityFrameworkCore;
using Domain.DTO;

namespace WebApi91.Services
{
    public class UsuarioServices : IUsuarioServices
    { 
        private readonly ApplicationDbContext _context; //Significa que es privado (_context)
        public UsuarioServices(ApplicationDbContext context)
        {
            _context = context;
        }

        //Lista de usuarios
        public async Task<Response<List<Usuario>>> ObtenerUsuarios() 
        {
            try
            {
                List<Usuario> response = await _context.Usuarios.Include(x=> x.Roles).ToListAsync();

                return new Response<List<Usuario>>(response);
            }
            catch (Exception ex)
            {

                throw new Exception("Sucedio un error" + ex.Message);
            }
        }


        public async Task<Response<Usuario>> ObtenerUsuario(int id)
        {
            try
            {
                Usuario res = await _context.Usuarios.FirstOrDefaultAsync(x=>x.PkUsuario == id);

                return new Response<Usuario>(res);
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        
        }

        public async Task<Response<Usuario>> CrearUsuario(UsuarioResponse request)
        {
            try
            {
                Usuario usuario = new Usuario() 
                { 
                    Nombre = request.Nombre,
                    User = request.User,
                    Password = request.Password,
                    FkRol = request.FkRol
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario);

            }
            catch (Exception ex)
            { 
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
        // 1ro. Se crea la funcion de ActualizarUsuario
        public async Task<Response<Usuario>> ActualizarUsuario(int id, UsuarioResponse request) 
        { 
            try
            {
                if (id == null)
                {
                    throw new ArgumentNullException("id");
                }
                
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x=> x.PkUsuario == id);
                
                usuario.Nombre = request.Nombre;
                usuario.Password = request.Password;
                usuario.User = request.User;
                usuario.FkRol = request.FkRol;

                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario);

            }
            catch (Exception ex)
            { 
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<Usuario>> EliminarUsuario(int id)
        {
            try     
            { 
                Usuario usuario = await _context.Usuarios.FirstOrDefaultAsync(x=>x.PkUsuario == id);
                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                return new Response<Usuario>(usuario);
            } 
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
    }
}
