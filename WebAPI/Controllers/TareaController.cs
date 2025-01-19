using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using WebAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        ITareaService tareaService;

        public TareaController(ITareaService tareaService)
        {
            this.tareaService = tareaService;
        }

        // GET: api/<TareaController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(tareaService.Get());
        }

        // POST api/<TareaController>
        [HttpPost]
        public IActionResult Save([FromBody] Tarea tarea)
        {
            tareaService.Save(tarea);
            return Ok();
        }

        // PUT api/<TareaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Tarea tarea)
        {
            tareaService.Update(id, tarea);
            return Ok();
        }

        // DELETE api/<TareaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            tareaService.Delete(id);
            return Ok();
        }

    }
}
