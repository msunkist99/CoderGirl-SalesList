using System;
using System.Collections.Generic;
using System.Text;

namespace CoderGirl_SalesList
{
    public interface ISalesRecordAnalyzer
    {
        /// <summary>
        /// Returns number of unique countries for which there are a Sales Record 
        /// </summary>
        /// <param name="salesRecords"></param>
        /// <returns></returns>
        int GetCountryCount(List<SalesRecord> salesRecords);

        /// <summary>
        /// Returns unique list of countries for which there are a Sales Record
        /// </summary>
        /// <param name="salesRecords"></param>
        /// <returns></returns>
        List<string> GetCountries(List<SalesRecord> salesRecords);

        /// <summary>
        /// Returns the value of the largest profit in the Sales Records
        /// </summary>
        /// <param name="salesRecords"></param>
        /// <returns></returns>
        decimal GetMaxProfit(List<SalesRecord> salesRecords);

        /// <summary>
        /// Returns the Sum of the TotalRevenue of all Sales Records
        /// </summary>
        /// <param name="salesRecords"></param>
        /// <returns></returns>
        decimal GetTotalRevenue(List<SalesRecord> salesRecords);

        /// <summary>
        /// Returns list of SalesRecords ordered by ShipDate in ascending order
        /// </summary>
        /// <param name="salesRecords"></param>
        /// <returns></returns>
        List<SalesRecord> OrderByShipDate(List<SalesRecord> salesRecords);

        /// <summary>
        /// Returns list of SalesRecords ordered by UnitsSold in descending order
        /// </summary>
        /// <param name="salesRecords"></param>
        /// <returns></returns>
        List<SalesRecord> OrderByUnitsSoldDescending(List<SalesRecord> salesRecords);

        /// <summary>
        /// Returns true if there are any OrderDates before the cuttoff date, else returns false
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="salesRecords"></param>
        /// <returns></returns>
        bool AreOrderDatesBefore(DateTime cutoffDate, List<SalesRecord> salesRecords);
    }
}
