using Alice.Dialogs.Anegdots.Repository.Services;
using Microsoft.AspNetCore.Mvc;
using Yandex.Alice.Sdk.Models;

namespace Alice.Dialogs.Anegdots.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AliceController : ControllerBase
    {
        private readonly IAnegdotsSerivce serivce;

        public AliceController(IAnegdotsSerivce serivce)
        {
            this.serivce = serivce;
        }

        [HttpGet]
        public IActionResult GetTest()
        {
            return Ok("Test");
        }

        [HttpPost]
        public IActionResult WebHook([FromBody] AliceRequest req)
        {
            var str = serivce.GetRandom();

            return Ok(new AliceResponse(req, str));
        }
    }
}