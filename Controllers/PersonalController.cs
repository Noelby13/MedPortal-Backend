using MedPortal.Data;
using MedPortal.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.WebSockets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {


        private readonly DPersonal _dPersonal;

        public PersonalController(DPersonal dPersonal)
        {
            _dPersonal = dPersonal;
        }


        // POST api/<PersonalController>
        [HttpPost]
        public ActionResult<Personal> Post([FromBody] Personal personal)
        {
            var result = _dPersonal.save(personal);
            if (result)
            {
                return Ok(personal); // Devuelve el objeto Personal con un estado 200 OK
            }
            else
            {
                return BadRequest("Error al guardar el personal");
            }
        }

        // PUT api/<PersonalController>/5
        [HttpPut("{id}")]
        public ActionResult<Personal> Put(int id, [FromBody] Personal personal)
        {
            var result = _dPersonal.update(personal);
            if (result)
            {
                return Ok(personal); // Devuelve el objeto Personal con un estado 200 OK
            }
            else
            {
                return BadRequest("Error al actualizar el personal");
            }
        }

        // DELETE api/<PersonalController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _dPersonal.delete(id);
            if (result)
            {
                return Ok("Personal eliminado"); // Devuelve un mensaje con un estado 200 OK
            }
            else
            {
                return BadRequest("Error al eliminar el personal");
            }
        }

        // GET: api/<PersonalController>
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {

            var result = _dPersonal.get(id);
            if (result ==null)
            {
                var response = new
                {
                    success = false,
                    Data = "No se encontro el personal"
                };
                return Ok(JsonConvert.SerializeObject(response));
            }

            var res = new
            {
                success = true,
                Data = result
            };

            return Ok(JsonConvert.SerializeObject(res)); // Devuelve un JSON con un estado 200 OK
     
        }

        // GET api/<PersonalController>/5
        [HttpGet]
        public ActionResult GetAll()
        {
            var result = _dPersonal.GetAll();
            if (result != null)
            {
                return Ok(JsonConvert.SerializeObject(result)); // Devuelve un JSON con un estado 200 OK
            }
            else
            {
                return BadRequest("Error al obtener el personal");
            }
        }





    }
}
