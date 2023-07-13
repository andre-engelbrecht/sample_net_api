using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample_API.Data;

namespace Sample_API.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DbTestController : ControllerBase
    {
        private SampleDBContext context;

        public DbTestController(SampleDBContext context)
        {
            this.context = context;
        }

        [HttpGet(Name = "TestReadFromDB")]
        public int TestReadFromDB()
        {
            return context.Model1.Count();
        }
    }
}
