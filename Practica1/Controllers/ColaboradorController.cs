using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using Practica1.Data.AccesoDatos;
using Practica1.Models.Entidad;

namespace Practica1.Controllers
{
    public class ColaboradorController : Controller
    {
        private readonly DAColaborador _daColaborador;

        private readonly DAEmpresa _daEmpresa;
        public ColaboradorController(DAColaborador daColaborador, DAEmpresa daEmpresa)
        {
            _daColaborador = daColaborador;
            _daEmpresa = daEmpresa;
        }
        public IActionResult ListadoColaborador()
        {
            var listado = _daColaborador.GetColaboradores();
            return View(listado);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Empresas = _daEmpresa.GetEmpresas();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Colaborador Entidad)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Empresas = _daEmpresa.GetEmpresas();
                return View(Entidad);
            }

            var id = _daColaborador.InsertarColaborador(Entidad);

            if (id>0)
            {
                return RedirectToAction("ListadoColaborador");
            } else
            {
                ViewBag.Empresas = _daEmpresa.GetEmpresas();
                return View(Entidad);
            }
        }

        //GET Edit
        public IActionResult Edit(int id)
        {
            ViewBag.Empresas = _daEmpresa.GetEmpresas();

            var model = _daColaborador.GetIdColaborador(id);

            if (model == null) return NotFound();

            return View(model);
        }

        //POST Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
       public IActionResult Edit(Colaborador entidad)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Empresas = _daEmpresa.GetEmpresas();
                return View(entidad);
            }

            entidad.FechaModificacion = DateTime.Now;

            var resultado = _daColaborador.UpdateColaborador(entidad);
            
            if(!resultado) return NotFound();

            return RedirectToAction("ListadoColaborador");
         }

        public IActionResult Delete(int id)
        {
            var model = _daColaborador.GetIdColaborador(id);

            if(model == null) return NotFound();

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var resultado = _daColaborador.DeleteColaborador(id);
            if(!resultado) return NotFound();

            return RedirectToAction("ListadoColaborador");
        }

        public IActionResult Details(int id)
        {
            var model = _daColaborador.GetIdColaborador(id);

            if(model==null) return NotFound();

            return View(model);
        }
    }
}
