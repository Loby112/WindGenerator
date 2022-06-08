using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WindGeneratorLib;
using WindRestAPI.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WindRestAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class WindController : ControllerBase{
        private DBWindManager manager = new DBWindManager();
        
        // GET: api/<WindController>
        [HttpGet]
        public ActionResult<IEnumerable<WindData>> Get([FromQuery] int? filter){
            return Ok(manager.GetAll(filter));
        }

        // GET api/<WindController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<WindController>
        [HttpPost]
        public ActionResult<WindData> Post([FromBody] WindData newData){
            if (newData.Direction.Length > 2 || newData.Speed < 0){
                return BadRequest("Direction has to be 1-2 letters, and Speed above 0");
            }
            manager.AddWindData(newData);
            return Created("api/Wind/" + newData.Id, newData);
        }

        // PUT api/<WindController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<WindController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
