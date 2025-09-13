using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Web.Controller
{
    [Route("api/sample")]
    public class SampleController : ControllerBase
    {
        public ISampleService SampleService { get; set; }


        [HttpGet("")]
        public IActionResult Get()
        {
            SampleService.Test();
            return Ok();
        }

        [Authorize]
        [HttpGet("auth")]
        public IActionResult GetAuth()
        {
            return Ok("You are authenticated");
        }

        [HttpGet("error")]
        public IActionResult GetError()
        {
            throw new Exception("這是一個測試例外");
        }
    }
}
