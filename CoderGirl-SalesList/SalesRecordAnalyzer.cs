using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoderGirl_SalesList
{
    class SalesRecordAnalyzer : ISalesRecordAnalyzer
    {
        /// <summary>
        /// Returns true if there are any OrderDates before the cuttoff date, else returns false
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="salesRecords"></param>
        /// <returns></returns>
        public bool AreOrderDatesBefore(DateTime cutoffDate, List<SalesRecord> salesRecords)
        {
            bool areOrderDatesBefore = false;
            /*
            DateTime minOrderDate = salesRecords.Select(p => p.OrderDate).Min();
            DateTime maxOrderDate = salesRecords.Select(p => p.OrderDate).Max();

            List<SalesRecord> resultSalesRecords = salesRecords.Where(p => p.OrderDate < cutoffDate).ToList();
            */

            areOrderDatesBefore = salesRecords.Where(p=> p.OrderDate < cutoffDate).Count() > 0 ? true : false;

            return areOrderDatesBefore;
        }

                /// <summary>
        /// Returns unique list of countries for which there are a Sales Record
        /// </summary>
        /// <param name="salesRecords"></param>
        /// <returns></returns>
        public List<string> GetCountries(List<SalesRecord> salesRecords)
        {
            List<string> countries = new List<string>();

            countries = salesRecords.OrderBy(p=> p.Country).Select(p => p.Country).Distinct().ToList();

            return countries;
        }

        /// <summary>
        /// Returns number of unique countries for which there are a Sales Record 
        /// </summary>
        /// <param name="salesRecords"></param>
        /// <returns></returns>
        public int GetCountryCount(List<SalesRecord> salesRecords)
        {
            int countryCount = 0;

            countryCount = salesRecords.Select(p => p.Country).Distinct().Count();
            return countryCount;
    }

        /// <summary>
        /// Returns the value of the largest profit in the Sales Records
        /// </summary>
        /// <param name="salesRecords"></param>
        /// <returns></returns>
        public double GetMaxProfit(List<SalesRecord> salesRecords)
        {
            double maxProfit = salesRecords.Select(p => p.TotalProfit).Max();

            return maxProfit;
        }

        /// <summary>
        /// Returns the Sum of the TotalRevenue of all Sales Records
        /// </summary>
        /// <param name="salesRecords"></param>
        /// <returns></returns>
        public double GetTotalRevenue(List<SalesRecord> salesRecords)
        {
            double totalRevenue = salesRecords.Select(p => p.TotalRevenue).Sum();
            return totalRevenue;
        }

        /// <summary>
        /// Returns list of SalesRecords ordered by ShipDate in ascending order
        /// </summary>
        /// <param name="salesRecords"></param>
        /// <returns></returns>
        public List<SalesRecord> OrderByShipDate(List<SalesRecord> salesRecords)
        {
            List<SalesRecord> salesRecordsOrderedByShipDate= salesRecords.OrderBy(p => p.ShipDate).ToList();

            return salesRecordsOrderedByShipDate;
    }

        /// <summary>
        /// Returns list of SalesRecords ordered by UnitsSold in descending order
        /// </summary>
        /// <param name="salesRecords"></param>
        /// <returns></returns>
        public List<SalesRecord> OrderByUnitsSoldDescending(List<SalesRecord> salesRecords)
        {
            List<SalesRecord> salesRecordsOrderedByUnitsSoldDescending = salesRecords.OrderByDescending(p => p.UnitsSold).ToList();
            return salesRecordsOrderedByUnitsSoldDescending;
        }
    }
}
