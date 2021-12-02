using AirRestService.Data;
using AirRestService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirLibrary;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AirRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirController : ControllerBase
    {
        private IAir AirService;
        public AirController(IAir _air)
        {
            AirService = _air;
        }
        //public AirManager airmanager = new AirManager(AirService);

        // GET: api/<AirController>
        [HttpGet]
        public ActionResult<IEnumerable<Air>> GetAll()
        {
            return Ok(AirService.GetAll());
        }
        [HttpGet("/api/[controller]/Latest")]
        public ActionResult<Air> GetLatest()
        {
            if (AirService.GetLatest() != null)
                return Ok(AirService.GetLatest());
            else return BadRequest();
        }

        // GET api/<AirController>/5
        [HttpGet("{id}")]
        public ActionResult<Air> Get(int id)
        {
            if (AirService.Get(id) != null)
                return Ok(AirService.Get(id));
            else return BadRequest();
        }

        // POST api/<AirController>
        [HttpPost]
        public ActionResult Post([FromBody] Air value)
        {
            value.TimeStamp = DateTime.Now;
            AirService.Create(value);
            return NoContent();
        }

        // PUT api/<AirController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Air value)
        {
            if (AirService.Get(id) != null)
            {
                AirService.Update(id, value);
                return NoContent();
            }
            else return BadRequest();
        }

        // DELETE api/<AirController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (AirService.Get(id) != null)
            {
                AirService.Remove(id);
                return NoContent();
            }
            else return BadRequest();
        }
    }
}
