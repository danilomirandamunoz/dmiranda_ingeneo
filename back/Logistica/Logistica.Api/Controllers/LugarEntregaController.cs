using Logistica.Api.AccesoDatos.Interfaces;
using Logistica.Api.Datos.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Logistica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LugarEntregaController : ControllerBase
    {

        private readonly ILugarEntregaRepositorio repositorio;

        public LugarEntregaController(ILugarEntregaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {

            var response = await repositorio.Obtener();

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {

            var response = await repositorio.ObtenerPorId(id);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpGet("obtenerPorTipoLogistica/{idTipoLogistica}")]
        public async Task<IActionResult> ObtenerPorTipoLogistica(int idTipoLogistica)
        {
            var res = await this.repositorio.ObtenerPorIdTipoLogistica(idTipoLogistica);
            return Ok(res);
        }
        [HttpPost]
        public async Task Post([FromBody] LugarEntrega lugarEntrega)
        {
            await repositorio.Guardar(lugarEntrega);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] LugarEntrega lugarEntrega)
        {
            try
            {
                var objeto = await repositorio.ObtenerPorId(id);
                if (objeto == null)
                {
                    return NotFound();
                }

                await repositorio.Actualizar(lugarEntrega);
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
