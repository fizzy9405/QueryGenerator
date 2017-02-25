using RatesGenerator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web.Mvc;

namespace WebQueryGenerator.Controllers
{
    public class CSVRatesController : ApiController
    {
        public void Post([FromBody]CSVRatesModel values)
        {
            CSVRatesGenerator generator = new CSVRatesGenerator(values);

            generator.GenerateCSV();

        }
    }
}
