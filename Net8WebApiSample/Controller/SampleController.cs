using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Web.Controller
{
    [Authorize]
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
