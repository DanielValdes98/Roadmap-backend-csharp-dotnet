using Microsoft.AspNetCore.Mvc;
using webapi;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        IHelloworldService helloworldService;
        TareasContext tareasContext;

        public HelloWorldController(IHelloworldService _helloworldService, TareasContext dbContext)
        {
            helloworldService = _helloworldService;
            tareasContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(helloworldService.GetHelloworld());
        }

        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDatabase()
        {
            tareasContext.Database.EnsureCreated();
            return Ok();
        }
    }
}
