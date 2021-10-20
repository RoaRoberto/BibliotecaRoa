using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_Libreria.Model;
using Api_Libreria.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Api_Libreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {

        private ILogger _logger;
        private ILibroService _service;

        public LibroController(ILibroService service, ILogger<LibroController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet]
        public ObjectResult Get()
        {
            try
            {
                var libros = _service.GetLibros();
                return Ok(libros);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{id}")]
        public ObjectResult Get(int id)
        {
            try
            {
                var libro = _service.GetLibroByiD(id);
                return Ok(libro);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ObjectResult Post([FromBody] LibroEntity entity)
        {
            try
            {
                entity.Autor = null;
                var newEntity = _service.AddLibro(entity);
                return Ok(newEntity);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromBody] LibroEntity entity)
        {
            try
            {
                entity.Autor = null;
                var libros = _service.UpdateLibro(id,entity);
                return Ok(libros);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ObjectResult Delete(int id)
        {
            try
            {
                var respuesta = _service.DeleteLibro(id);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
