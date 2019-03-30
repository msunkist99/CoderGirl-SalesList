using System;
using System.Collections.Generic;
using System.Text;

namespace CoderGirl_SalesList
{
    public interface ISalesRecordAdapter
    {
        /// <summary>
        /// Gets the file with a given path and converts it into a list of SalesRecord items
        /// </summary>
        /// <param name="filePath">The path to the csv file</param>
        /// <param name="header">true if the file includes a header line, else false</param>
        /// <returns>List of SalesRecord items</returns>
        List<SalesRecord> GetSalesRecordsFromCsvFile(string filePath, bool header = false);
    }
}
