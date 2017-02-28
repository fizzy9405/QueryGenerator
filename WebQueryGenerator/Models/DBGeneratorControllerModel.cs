using DbInsert;
using RatesGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQueryGenerator.Models
{
    public class CSVRatesControllerModel
    {
        public List<CSVRatesModel> Values { get; set; }
        public bool UseComma { get; set; }
    }
}