using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatesGenerator
{
    public class Rate
    {
        public string CodeOrIsin { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }

    }
}
