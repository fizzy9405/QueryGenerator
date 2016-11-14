using DbInsert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebQueryGenerator.Models;

namespace WebQueryGenerator.Controllers
{
    public class DataController : ApiController
    {
        // GET: api/Data
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Data/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Data
        public IEnumerable<string> Post([FromBody]DataModel values)
        {
            InsertsGenerator generator = new InsertsGenerator(values.DateFrom, values.DateTo, values.ValueFrom, values.ValueTo, values.Table, values.Precision);
            return generator.GenerateArray();
        }

        // PUT: api/Data/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Data/5
        public void Delete(int id)
        {
        }
    }
}
