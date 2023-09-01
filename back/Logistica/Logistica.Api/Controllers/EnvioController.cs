using Logistica.Api.AccesoDatos.Interfaces;
using Logistica.Api.Datos.Modelo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

namespace Logistica.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EnvioController : ControllerBase
    {
        private readonly IEnvioRepositorio repositorio;

        public EnvioController(IEnvioRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var response = await repositorio.Obtener( x=>x.Cliente, x=>x.TipoProducto, x => x.LugarEntrega);

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

        [HttpPost]
        public async Task Post([FromBody] Envio envio)
        {
            await repositorio.Guardar(envio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Envio envio)
        {
            try
            {
                var objeto = await repositorio.ObtenerPorId(id);
                if (objeto == null)
                {
                    return NotFound();
                }

                await repositorio.Actualizar(envio);
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
