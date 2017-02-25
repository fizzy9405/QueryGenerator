using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbInsert
{
    public class DBGeneratorModel
    {
         public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public double ValueFrom { get; set; }
        public double ValueTo { get; set; }
        public string Table { get; set; }
        public int Precision { get; set; }

     
    }
}
