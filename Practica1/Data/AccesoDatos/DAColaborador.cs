using Microsoft.AspNetCore.Razor.Language.Intermediate;
using Microsoft.EntityFrameworkCore;
using Practica1.Models.Entidad;

namespace Practica1.Data.AccesoDatos
{
    public class DAColaborador
    {
        private readonly ApplicationDbContext _context;

        public DAColaborador(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Colaborador> GetColaboradores() {
                return _context.Colaboradores
                    .Include(c => c.Empresa)
                    .AsNoTracking()
                    .ToList(); 
        }

        public int InsertarColaborador(Colaborador Entidad)
        {
            if (Entidad == null) return 0;

                _context.Colaboradores.Add(Entidad);
                _context.SaveChanges();
                return Entidad.IdColaborador;
            
        }
        

    public Colaborador GetIdColaborador(int id)
        {
            return _context.Colaboradores
                    .Include(c => c.Empresa)
                    .FirstOrDefault(c => c.IdColaborador == id);  
        }

        public bool UpdateColaborador(Colaborador entidad)
        {
            var existente = _context.Colaboradores
                .FirstOrDefault(c => c.IdColaborador == entidad.IdColaborador);

            if(existente == null) return false;

            existente.NombColaborador = entidad.NombColaborador;
            existente.ApeColaborador = entidad.ApeColaborador;
            existente.DNI = entidad.DNI;
            existente.Sexo = entidad.Sexo;
            existente.Direccion = entidad.Direccion;
            existente.IdEmpresa = entidad.IdEmpresa;
            existente.FechaModificacion = entidad.FechaModificacion;

            return _context.SaveChanges() > 0;
        }

        public bool DeleteColaborador(int id)
        {
            var existente = _context.Colaboradores
                .FirstOrDefault(c => c.IdColaborador == id);    

            if(existente == null ) return false;

            _context.Colaboradores.Remove(existente);
            _context.SaveChanges();

            return true;
        }

    }
}

