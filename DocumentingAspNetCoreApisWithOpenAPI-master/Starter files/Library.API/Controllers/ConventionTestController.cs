using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiConventionType(typeof(DefaultApiConventions))]
    public class ConventionTestController : ControllerBase
    {
        // GET: api/ConventionTest
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ConventionTest/5
        [HttpGet("{id}", Name = "Get")]
        //[ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ConventionTest
        [HttpPost]
        [ApiConventionMethod(typeof(CustomConvention), nameof(CustomConvention.Insert))]
        public void Insert([FromBody] string value)
        {
        }

        // PUT: api/ConventionTest/5
        [HttpPut("{id}")]        
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
