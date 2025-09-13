using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service;
using Web.Models;

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
            return Ok(ApiResponse.Success("test OK"));
        }

        [Authorize]
        [HttpGet("auth")]
        public IActionResult GetAuth()
        {
            return Ok(ApiResponse<string>.Success("You are authenticated", "test auth OK"));
        }

        [HttpGet("error")]
        public IActionResult GetError()
        {
            throw new Exception("test Exception");
        }
    }
}
