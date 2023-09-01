using Logistica.Api.AccesoDatos.Interfaces;
using Logistica.Api.Datos.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Logistica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoProductoController : ControllerBase
    {
        private readonly IRepositorio<TipoProducto> repositorio;

        public TipoProductoController(IRepositorio<TipoProducto> repositorio)
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

            if(response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task Post([FromBody] TipoProducto tipoProducto)
        {
            await repositorio.Guardar(tipoProducto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TipoProducto tipoProducto)
        {
            try
            {
                var objeto = await repositorio.ObtenerPorId(id);
                if (objeto == null)
                {
                    return NotFound();
                }

                await repositorio.Actualizar(tipoProducto);
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
