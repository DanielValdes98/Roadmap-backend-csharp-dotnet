using Microsoft.AspNetCore.Mvc;
using webapi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET: api/<CategoriaController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_categoriaService.Get());
        }

        // POST api/<CategoriaController>
        [HttpPost]
        public IActionResult Save([FromBody] Categoria categoria)
        {
            _categoriaService.Save(categoria);
            return Ok();
        }

        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Categoria categoria)
        {
            _categoriaService.Update(id, categoria);
            return Ok();
        }

        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _categoriaService.Delete(id);
            return Ok();
        }
    }
}
