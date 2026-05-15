using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Practica1.Data.AccesoDatos;
using Practica1.DTOs;

namespace Practica1.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    [AllowAnonymous]
    public class ColaboradorAPIController : ControllerBase
    {

        private readonly DAColaborador _daColaborador;
        private readonly DAEmpresa _daEmpresa;

        public ColaboradorAPIController(DAColaborador daColaborador, DAEmpresa daEmpresa)
        {
            _daColaborador = daColaborador;
            _daEmpresa = daEmpresa;
        }


        [HttpGet("Listar")]
        public IActionResult Listar()
        {
            var listado = _daColaborador.GetColaboradores();

            var resultado = listado.Select(c => new ColaboradorDTO
            {
                IdColaborador = c.IdColaborador,
                Name = c.NombColaborador,
                LastName = c.ApeColaborador
            });

            return Ok(resultado);
        }



    }
}
