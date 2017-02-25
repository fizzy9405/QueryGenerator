using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatesGenerator
{
    
   public sealed class RateMap : CsvClassMap<Rate>
    {
        public RateMap()
        {
            Map(m => m.CodeOrIsin).Name("ISIN/BBCode");
            Map(m => m.Date).Name("Date");
            Map(m => m.Value).Name("Rate");
        }
    }
}
