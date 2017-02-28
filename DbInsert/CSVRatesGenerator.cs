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
            // Model = values;
        }
        public CSVRatesGenerator(List<CSVRatesModel> coll, bool useComma)
        {
            this.models = coll;
            UseComma = useComma;

        }
        public void GenerateCSV()
        {
            List<List<Rate>> ratesList = GenerateList(models);
            GenerateCSV(ratesList, UseComma);
        }
        //public CSVRatesModel Model { get; set; }
        private List<CSVRatesModel> models { get; set; }
        Random rng = new Random();
        public bool UseComma { get; set; }

        //generate list with the values for the period of dates
        public List<List<Rate>> GenerateList(List<CSVRatesModel> values)
        {
            List<List<Rate>> ratesLists = new List<List<Rate>>();
            foreach (var list in models)
            {
                List<Rate> tempList = new List<Rate>();
                DateTime currentDate = list.DateFrom;
                DateTime endDate = list.DateTo;
                while (currentDate <= endDate)
                {
                    Rate rate = new Rate();
                    rate.CodeOrIsin = list.CodeOrIsin;
                    rate.Date = currentDate;
                    rate.Value = GetRandomDouble(rng, list.ValueFrom, list.ValueTo);
                    tempList.Add(rate);
                    currentDate = currentDate.AddDays(1);
                }
                ratesLists.Add(tempList);
            }
            return ratesLists;
        }

        //write the list on the csv file
        public void GenerateCSV(List<List<Rate>> ratesList, bool useComma)
        {
            Directory.CreateDirectory("C:\\CSVFolder");
            TextWriter tw = new StreamWriter(string.Format("C:\\CSVFolder\\Rates{0}.csv", DateTime.Now.ToString("ddMMyy-hhmm")));
            var csv = new CsvWriter(tw);
            csv.Configuration.HasHeaderRecord = true;
            if (!useComma)
            {
                csv.Configuration.Delimiter = ";";
            }
            csv.Configuration.RegisterClassMap<RateMap>();
            csv.WriteHeader<Rate>();
            foreach (var list in ratesList)
            {
                foreach (var item in list)
                {

                    csv.WriteField(item.CodeOrIsin);
                    csv.WriteField(item.Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));
                    csv.WriteField(item.Value);
                    csv.NextRecord();

                }
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
