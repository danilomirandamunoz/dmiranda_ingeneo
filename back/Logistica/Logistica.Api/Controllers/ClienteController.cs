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
    public class ClienteController : ControllerBase
    {
        private readonly IRepositorio<Cliente> repositorio;

        public ClienteController(IRepositorio<Cliente> repositorio)
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
        public async Task Post([FromBody] Cliente cliente)
        {
            await repositorio.Guardar(cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Cliente cliente)
        {
            try
            {
                var objeto = await repositorio.ObtenerPorId(id);
                if (objeto == null)
                {
                    return NotFound();
                }

                await repositorio.Actualizar(cliente);
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
