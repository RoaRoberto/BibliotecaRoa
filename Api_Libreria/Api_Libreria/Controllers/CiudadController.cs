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
    public class CiudadController : ControllerBase
    {

        private ILogger _logger;
        private ICiudadService _service;

        public CiudadController(ICiudadService service, ILogger<CiudadController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet]
        public ObjectResult Get()
        {
            try
            {
                var Ciudads = _service.GetCiudades();
                return Ok(Ciudads);
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
                var Ciudad = _service.GetCiudadByiD(id);
                return Ok(Ciudad);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

    }
}
