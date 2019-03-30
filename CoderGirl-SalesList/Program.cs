using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace CoderGirl_SalesList
{
    public class Program
    {
        Factory factory = new Factory();

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
            Console.ReadLine();
        }

        private void Run()
        {
            //List<SalesRecord> salesRecords = GetSalesRecordsFromFileData();
            List<SalesRecord> salesRecords = factory.SalesRecordAdapter.GetSalesRecordsFromCsvFile(@"Data\1000 Sales Records.csv", true);

            List<string> countries = factory.SalesRecordAnalyzer.GetCountries(salesRecords);

            Console.WriteLine("Distinct countries sorted in ascending order");
            foreach (string country in countries)
            {
                Console.WriteLine(country);
            }

            //GetCountForNorthAmerica(salesRecords);

            int countNorthAmerica = factory.SalesRecordAnalyzer.GetCountryCount(salesRecords);

            Console.WriteLine($"Distinct country count - {countNorthAmerica}");

            bool x = factory.SalesRecordAnalyzer.AreOrderDatesBefore(new DateTime( 2009,01,01), salesRecords);
            Console.WriteLine($"Orders before 01/01/2009 {x}");
            x = factory.SalesRecordAnalyzer.AreOrderDatesBefore(new DateTime(2017, 07, 27), salesRecords);
            Console.WriteLine($"Orders before 07/27/2017 {x}");

            decimal maxProfit = factory.SalesRecordAnalyzer.GetMaxProfit(salesRecords);
            Console.WriteLine($"Max profit {maxProfit:C}");

            decimal sumTotalRevenue = factory.SalesRecordAnalyzer.GetTotalRevenue(salesRecords);
            Console.WriteLine($"Total revenue {sumTotalRevenue:C}");

            List<SalesRecord> salesRecordsByOrderDate = factory.SalesRecordAnalyzer.OrderByShipDate(salesRecords);
            foreach (SalesRecord salesRecord in salesRecordsByOrderDate)
            {
                Console.WriteLine($"{ salesRecord.OrderId} - { salesRecord.ShipDate}");
            }

            List<SalesRecord> salesRecordsUnitsSoldDescending = factory.SalesRecordAnalyzer.OrderByUnitsSoldDescending(salesRecords);
            foreach (SalesRecord salesRecord in salesRecordsUnitsSoldDescending)
            {
                Console.WriteLine($"{ salesRecord.OrderId} - { salesRecord.UnitsSold}");
            }
        }

        private int GetCountForNorthAmerica(List<SalesRecord> salesRecords)
        {
            int count = 0;
            foreach(SalesRecord record in salesRecords)
            {
                if(record.Region == "North America")
                {
                    count++;
                }
            }

            return count;
        }

        /*
        private List<SalesRecord> GetSalesRecordsFromFileData()
        {
            List<SalesRecord> salesRecords = new List<SalesRecord>();
            bool isFirstRow = true;
            foreach (string line in File.ReadLines(@"Data\1000 Sales Records.csv"))
            {
                if (isFirstRow)
                {
                    isFirstRow = false;
                    continue;
                }

                SalesRecord salesRecord = CreateSalesRecord(line);
                salesRecords.Add(salesRecord);
            }
            return salesRecords;
        }

        private SalesRecord CreateSalesRecord(string line)
        {
            SalesRecord salesRecord = new SalesRecord();
            string[] properties = line.Split(",");
            salesRecord.Region = properties[0];
            salesRecord.Country = properties[1];
            salesRecord.ItemType = properties[2];
            salesRecord.SalesChannel = properties[3];
            salesRecord.OrderPriority = properties[4];
            salesRecord.OrderDate = DateTime.Parse(properties[5]);

            return salesRecord;
        }
        */
    }
}