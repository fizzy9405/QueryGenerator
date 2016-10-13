using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbInsert
{
    public class InsertsGenerator
    {
        public InsertsGenerator(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
            ValueFrom = defValFrom;
            ValueTo = defValTo;
            TableName = defTableName;

        }

        //too bulky
        public InsertsGenerator(DateTime startDate, DateTime endDate, double valueFrom, double valueTo, string tableName)
        {
            StartDate = startDate;
            EndDate = endDate;
            ValueFrom = valueFrom == 0 ? defValFrom : valueFrom;
            ValueTo = valueTo == 0 ? defValTo : valueTo;
            TableName = tableName == "" ? defTableName : tableName;

        }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double ValueFrom { get; set; }
        public double ValueTo { get; set; }
        public string TableName { get; set; }
        public string[] array { get; set; }
        public Random rng = new Random();

        const double defValFrom = 50;
        const double defValTo = 60;
        const string defTableName = "QUOTE";

        public string[] GenerateArray()
        {
            DateTime currentDate = StartDate;
            double diff = (EndDate - StartDate).TotalDays + 1;
            array = new string[(int)diff];
            int i = 0;

            while (currentDate <= EndDate)
            {
                array[i] = GenerateLine(currentDate);
                currentDate = currentDate.AddDays(1);
                i++;
            }
            return array;
        }
        public string GenerateLine(DateTime date)
        {
            string dateStr = date.ToString("yyyy-MM-dd");
            double num = GetRandomDouble(rng, ValueFrom, ValueTo);
            string fnum = num.ToString("f", System.Globalization.CultureInfo.InvariantCulture);
            string str = String.Format("INSERT INTO {0} VALUES ('{1}', {2},'script', getdate(), 'script', getdate());", TableName, dateStr, fnum);
            return str;
        }

        private double GetRandomDouble(Random random, double min, double max)
        {
            return min + (random.NextDouble() * (max - min));
        }
    }
}

