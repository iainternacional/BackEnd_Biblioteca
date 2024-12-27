using Biblioteca.BackEnd.Application.Services.Biblioteca;
using Biblioteca.BackEnd.Domain.Entities.Biblioteca;
using Biblioteca.BackEnd.Domain.Entities.Request.Biblioteca;
using Biblioteca.BackEnd.Domain.Entities.Response.Biblioteca;
using Biblioteca.BackEnd.Infrastructure.Framework.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Biblioteca_BackEnd.Controllers.Biblioteca
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        readonly ILibrosService _librosService;

        public LibrosController(ILibrosService librosService)
        {
            this._librosService = librosService;
        }
        //[Authorize]
        [HttpGet("obtenertodoslibros")]
        public async Task<IActionResult> ObtenerListaLibrosAsync()
        {
            IEnumerable<Libro> librosConsultados;

            librosConsultados = await _librosService.ObtenerListadoLibrosAsync();

            return Ok(librosConsultados);
        }

        //[Authorize]
        [HttpGet("obtenerlibro/{id}")]
        public async Task<IActionResult> ObtenerLibroPorId(int id)
        {
            var libroConsultado = await _librosService.ObtenerLibroPorId(id);

            return Ok(libroConsultado);
        }

        //[Authorize]
        [HttpPost("crearlibro")]
        public IActionResult InsertarNuevoLibro([FromForm] LibroRequest libroRequest)
        {
            try
            {
                var idLibro = _librosService.InsertarNuevoLibro(libroRequest, "admin");

                if (idLibro != 0)
                {
                    LibroResponse libroResponse = new LibroResponse()
                    {
                        Exito = true,
                        IdLibro = idLibro,
                        MensajeError = "Libro creado con éxito"
                    };
                    return CreatedAtAction(nameof(ObtenerLibroPorId), new { id = idLibro }, libroResponse);
                }
                else
                {
                    return BadRequest(new LibroResponse
                    {
                        Exito= false,
                        MensajeError = "No se pudo crear el libro"
                    });
                }

            }
            catch (Excepcion ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Ocurrió un error inesperado.", detalle = ex.Message });
            }
        }
        //[Authorize]
        [HttpPut("actualizarlibro")]
        public void ActualizarLibro([FromForm] LibroRequest libroRequest)
        {
            try
            {
                _librosService.ActualizarLibro(libroRequest, "admin");
            }
            catch (Excepcion ex)
            {
                StatusCode((int)ex.StatusCode, ex.Message);
            }
            catch (Exception ex)
            {
                StatusCode(500, new { mensaje = "Ocurrió un error inesperado.", detalle = ex.Message });
            }
        }
    }
}
