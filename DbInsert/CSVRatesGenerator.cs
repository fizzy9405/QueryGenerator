using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatesGenerator
{
    public class CSVRatesGenerator
    {
        public CSVRatesGenerator(CSVRatesModel values)
        {
            Model = values;
        }
        public void GenerateCSV() {
            List<Rate> ratesList = GenerateList(Model);
            GenerateCSV(ratesList);
        }
        public CSVRatesModel Model { get; set; }
        Random rng = new Random();

        //generate list with the values for the period of dates
        public List<Rate> GenerateList(CSVRatesModel values) {
            DateTime currentDate = Model.DateFrom;
            DateTime endDate = Model.DateTo;
            List<Rate> ratesList = new List<Rate>();
            while (currentDate<=endDate)
            {
                Rate rate = new Rate();
                rate.CodeOrIsin = Model.CodeOrIsin;
                rate.Date = currentDate;
                rate.Value = GetRandomDouble(rng,Model.ValueFrom,Model.ValueTo);
                ratesList.Add(rate);
               currentDate= currentDate.AddDays(1);
            }
            return ratesList;
        }

        //write the list on the csv file
        public void GenerateCSV(List<Rate> ratesList) {
            Directory.CreateDirectory("C:\\CSVFolder");
            TextWriter tw = new StreamWriter($"C:\\CSVFolder\\Rates{DateTime.Now.ToString("ddMMyy-hhmm")}.csv" );
            var csv = new CsvWriter(tw);
            csv.Configuration.HasHeaderRecord = true;
            csv.Configuration.Delimiter = ";";
            csv.Configuration.RegisterClassMap<RateMap>();
            csv.WriteHeader<Rate>();
            foreach (var item in ratesList)
            { 
                csv.WriteField(item.CodeOrIsin);
                csv.WriteField(item.Date.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture));
                csv.WriteField(item.Value);
                csv.NextRecord();
                
            }
           // csv.WriteRecords(ratesList);
            tw.Close();
        }


        private double GetRandomDouble(Random random, double min, double max)
        {
            return min + (random.NextDouble() * (max - min));
        }
    }
}
