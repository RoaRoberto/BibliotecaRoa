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
    public class AutorController : ControllerBase
    {

        private ILogger _logger;
        private IAutorService _service;

        public AutorController(IAutorService service, ILogger<AutorController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet]
        public ObjectResult Get()
        {
            try
            {
                var Autors = _service.GetAutores();
                return Ok(Autors);
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
                var Autor = _service.GetAutorByiD(id);
                return Ok(Autor);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ObjectResult Post([FromBody] AutorEntity entity)
        {
            try
            {
                entity.Ciudad = null;
                var newEntity = _service.AddAutor(entity);
                return Ok(newEntity);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public ObjectResult Put(int id, [FromBody] AutorEntity entity)
        {
            try
            {
                entity.Ciudad = null;
                var Autors = _service.UpdateAutor(id,entity);
                return Ok(Autors);
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
                var respuesta = _service.DeleteAutor(id);
                return Ok(respuesta);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
