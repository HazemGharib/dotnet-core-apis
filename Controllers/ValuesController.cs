using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_core_apis.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
        public int Post([FromBody]string value)
        {
           EntityEntry<Values> result = null;
           try
           {
                using (var ctx = new core2apiv1Context())
                {
                    result = ctx.Values.Add( new Values{Id = Guid.NewGuid(),Value = value});
                    ctx.SaveChanges();
                }
                return StatusCodes.Status200OK;
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
               Console.WriteLine(result);
               return StatusCodes.Status500InternalServerError;
           }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public int Put(Guid id, [FromBody]string value)
        {
           Values result = null;
           try
           {
                using (var ctx = new core2apiv1Context())
                {
                    result = ctx.Values.SingleOrDefault(x => x.Id == id);
                    result.Value = value;
                    ctx.SaveChanges();
                }
                return StatusCodes.Status200OK;
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
               Console.WriteLine(result);
               return StatusCodes.Status500InternalServerError;
           }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public int Delete(Guid id)
        {
            EntityEntry<Values> result = null;
           try
           {
                using (var ctx = new core2apiv1Context())
                {
                    result = ctx.Values.Remove(ctx.Values.SingleOrDefault(x => x.Id == id));
                    ctx.SaveChanges();
                }
                return StatusCodes.Status200OK;
           }
           catch (Exception ex)
           {
               Console.WriteLine(ex.Message);
               Console.WriteLine(result);
               return StatusCodes.Status500InternalServerError;
           }
        }
    }
}
