using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatesGenerator
{
    public class CSVRatesModel
    {
        public string CodeOrIsin { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public double ValueFrom { get; set; }
        public double ValueTo { get; set; }
        
    }
}
