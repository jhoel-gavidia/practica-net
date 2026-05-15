using Microsoft.EntityFrameworkCore;
using Practica1.Models.Entidad;

namespace Practica1.Data.AccesoDatos
{
    public class DAEmpresa
    {

        private readonly ApplicationDbContext _context;

        public DAEmpresa(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Empresa> GetEmpresas() { 

            return _context.Empresas
                .AsNoTracking().ToList();
        }

    }
}
