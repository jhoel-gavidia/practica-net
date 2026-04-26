using Microsoft.EntityFrameworkCore;
using Practica1.Models.Entidad;

namespace Practica1.Data.AccesoDatos
{
    public class DAEmpresa
    {
        public IEnumerable<Empresa> GetEmpresas() { 
            using(var db = new ApplicationDbContext())
            {
                return db.Empresas
                    .AsNoTracking() .ToList();
            }
        }

    }
}
