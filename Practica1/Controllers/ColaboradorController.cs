using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Create(Colaborador Entidad)
        {
           
            if (!ModelState.IsValid)
                {   
                    ViewBag.Empresas = _daEmpresa.GetEmpresas();
                    return View(Entidad);
                }

            var id = _daColaborador.InsetarColaborador(Entidad);
            
            if (id>0)
            {
                return RedirectToAction("ListadoColaborador");
            } else
            {
                ModelState.AddModelError("", "Error al guardar colaborador");
                ViewBag.Empresas = _daEmpresa.GetEmpresas();
                return View(Entidad);
            }
        }

    }
}
