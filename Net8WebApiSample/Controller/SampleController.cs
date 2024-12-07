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
    }
}
