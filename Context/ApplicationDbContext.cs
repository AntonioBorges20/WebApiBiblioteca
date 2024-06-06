using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi91.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        //Modelos
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> rols { get; set; }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Gastos> Gastos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insertar en la tabla usuario
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario()
                {
                    PkUsuario = 1,
                    Nombre = "Antonio",
                    User = "Usuario1",
                    Password = "´1234",
                    FkRol = 1

                }
            );
            modelBuilder.Entity<Rol>().HasData(
                new Rol()
                {
                    PkRol = 1,
                    Nombre= "sa"
                }
            );
            //modelBuilder.Entity<Gastos>().HasData(
            //    new Gastos()
            //    {
            //        pkGasto = 1,
            //        Tipo = "Gasto",
            //        Descripcion = "Gasto 1",
            //        //Fecha = DateTime.Now,
            //        Cantidad = "100"
            //    }
            // );
            
        }

    }
}
