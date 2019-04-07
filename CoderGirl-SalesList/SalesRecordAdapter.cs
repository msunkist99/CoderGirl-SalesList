using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace CoderGirl_SalesList
{
    class SalesRecordAdapter : ISalesRecordAdapter
    {
        /// <summary>
        /// Gets the file with a given path and converts it into a list of SalesRecord items
        /// </summary>
        /// <param name="filePath">The path to the csv file</param>
        /// <param name="header">true if the file includes a header line, else false</param>
        /// <returns>List of SalesRecord items</returns>

        public List<SalesRecord> GetSalesRecordsFromCsvFile(string filePath, bool header = false)
        {
            List<SalesRecord> salesRecords = new List<SalesRecord>();

            string[] textRecords = File.ReadAllLines(filePath);

            foreach (string textRecord in File.ReadLines(filePath))
            {
                if (header == true)
                {
                    header = false;
                }
                else
                {
                    string[] columns = textRecord.Split(',');

                    SalesRecord salesRecord = new SalesRecord();

                    salesRecord.Region = columns[0];
                    salesRecord.Country = columns[1];
                    salesRecord.ItemType = columns[2];
                    salesRecord.SalesChannel = columns[3];
                    salesRecord.OrderPriority = columns[4];
                    salesRecord.OrderDate = DateTime.Parse(columns[5]);
                    salesRecord.OrderId = (columns[6]);
                    salesRecord.ShipDate = DateTime.Parse(columns[7]);
                    salesRecord.UnitsSold = int.Parse(columns[8]);
                    salesRecord.UnitPrice = decimal.Parse(columns[9]);
                    salesRecord.UnitCost = decimal.Parse(columns[10]);
                    salesRecord.TotalRevenue = decimal.Parse(columns[11]);
                    salesRecord.TotalCost = decimal.Parse(columns[12]);
                    salesRecord.TotalProfit = decimal.Parse(columns[13]);

                    salesRecords.Add(salesRecord);
                }
            }

            return salesRecords;
        }
    }
}
