using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample_API.Core.Models;
using Sample_API.Core.Services;

namespace Sample_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildTypeController : ControllerBase
    {
        private IConfiguration _configuration;

        public BuildTypeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet(Name = "GetBuildType")]
        public string Get()
        {
            return _configuration["BuildType"];
        }
    }
}
