using DbInsert;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatesGenerator
{
    public class InsertsGenerator
    {
        public InsertsGenerator(DBGeneratorModel model )
        {
            Model = model;
        }

        public InsertsGenerator(DateTime startDate, DateTime endDate)
        {
            this.Model = new DBGeneratorModel(); 
            Model.DateFrom = startDate;
            Model.DateTo = endDate;
            Model.ValueFrom = defValFrom;
            Model.ValueTo = defValTo;
            Model.Table = defTableName;
        }

        public DBGeneratorModel Model { get; set; }
        const double defValFrom = 50;
        const double defValTo = 60;
        const string defTableName = "QUOTE";
        string[] array { get; set; }
        Random rng = new Random();

        public string[] GenerateArray()
        {
            DateTime currentDate = Model.DateFrom;
            double diff = (Model.DateTo - Model.DateFrom).TotalDays + 1;
            array = new string[(int)diff];
            int i = 0;

            while (currentDate <= Model.DateTo)
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
            double num = GetRandomDouble(rng, Model.ValueFrom, Model.ValueTo);
            string format = "f" + Model.Precision;
            string fnum = num.ToString( format, System.Globalization.CultureInfo.InvariantCulture);
            string str = String.Format("INSERT INTO {0} VALUES ('{1}', {2}, 'script', getdate(), 'script', getdate());", Model.Table, dateStr, fnum);
            return str;
        }

        private double GetRandomDouble(Random random, double min, double max)
        {
            return min + (random.NextDouble() * (max - min));
        }
    }
}

