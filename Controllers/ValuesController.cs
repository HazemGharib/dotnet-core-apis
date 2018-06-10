using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_core_apis.Model;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_apis.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<Values> Get()
        {
            IEnumerable<Values> values;
            using (var ctx = new core2apiv1Context())
            {
                values = ctx.Values.ToList();
            }
            return values;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(Guid id)
        {
            string value;
            using (var ctx = new core2apiv1Context())
            {
                value = ctx.Values.FirstOrDefault(x => x.Id == id).Value;
            }
            return value;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
