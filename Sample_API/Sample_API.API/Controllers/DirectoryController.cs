using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample_API.Core.Services;

namespace Sample_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        private DirectoryService directoryService;

        public DirectoryController(DirectoryService directoryService)
        {
            this.directoryService = directoryService;
        }

        [HttpGet("WriteNewFile")]
        public string WriteNewFile()
        {
            return directoryService.WriteNewFile();
        }

        [HttpGet("ReadFiles")]
        public string[] ReadFiles() 
        { 
            return directoryService.ReadFiles();
        }
    }
}
