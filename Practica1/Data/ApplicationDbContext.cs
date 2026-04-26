using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Practica1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Practica1.Models.Entidad.Colaborador> Colaboradores { get; set; }
        public DbSet<Practica1.Models.Entidad.Empresa> Empresas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=JHOEL\\SQLEXPRESS;" +
                "DataBase=Practica1;" +
                "User Id=sa;" +
                "Password=1234;" +
                "MultipleActiveResultSets=true;" +
                "Encrypt=false;"
                );
        }
    }  
}
