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
using WebQueryGenerator.Models;

namespace WebQueryGenerator.Controllers
{
    public class CSVRatesController : ApiController
    {
        public void Post([FromBody]CSVRatesControllerModel values )
        {
            CSVRatesGenerator generator = new CSVRatesGenerator(values.Values,values.UseComma);

            generator.GenerateCSV();

        }
    }
}
