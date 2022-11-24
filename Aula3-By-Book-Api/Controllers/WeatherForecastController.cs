using Microsoft.AspNetCore.Mvc;

namespace Aula3_By_Book_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> Get()
        {
            return Ok("Sucesso");
        }

        [HttpPost]
        public ActionResult Post() 
        {
            return Ok();
        }
    }
}