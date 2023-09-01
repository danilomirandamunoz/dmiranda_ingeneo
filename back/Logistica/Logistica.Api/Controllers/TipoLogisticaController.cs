using Logistica.Api.AccesoDatos.Interfaces;
using Logistica.Api.AccesoDatos.Repositorios;
using Logistica.Api.Datos.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Logistica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoLogisticaController : ControllerBase
    {

        private readonly IRepositorio<TipoLogistica> repositorio;

        public TipoLogisticaController(IRepositorio<TipoLogistica> repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {

            var response = await repositorio.Obtener();

            return Ok(response);
        }

        [HttpGet("id")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {

            var response = await repositorio.ObtenerPorId(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task Post([FromBody] TipoLogistica tipoLogistica)
        {
            await repositorio.Guardar(tipoLogistica);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TipoLogistica tipoLogistica)
        {
            try
            {
                var objeto = await repositorio.ObtenerPorId(id);
                if (objeto == null)
                {
                    return NotFound();
                }

                await repositorio.Actualizar(tipoLogistica);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var objeto = await repositorio.ObtenerPorId(id);
            if (objeto == null)
            {
                return NotFound();
            }
            await repositorio.Eliminar(objeto);
            return Ok();
        }
    }
}
