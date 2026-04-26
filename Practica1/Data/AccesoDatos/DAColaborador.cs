using Microsoft.EntityFrameworkCore;
using Practica1.Models.Entidad;

namespace Practica1.Data.AccesoDatos
{
    public class DAColaborador
    {
        public IEnumerable<Colaborador> GetColaboradores() {

            using (var db = new ApplicationDbContext())
            {
                return db.Colaboradores
                    .Include(c => c.Empresa)
                    .AsNoTracking()
                    .ToList();
            }
        }

        public int InsetarColaborador(Colaborador Entidad)
        {   
                if (Entidad == null) return 0;

                using (var db = new ApplicationDbContext()) { 
                    db.Colaboradores.Add(Entidad);
                    db.SaveChanges();
                    return Entidad.IdColaborador;
                }
            }
        }
    }

