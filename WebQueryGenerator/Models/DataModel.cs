using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQueryGenerator.Models
{
    public class DataModel
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public double ValueFrom { get; set; }
        public double ValueTo { get; set; }
        public string Table { get; set; }
    }
}