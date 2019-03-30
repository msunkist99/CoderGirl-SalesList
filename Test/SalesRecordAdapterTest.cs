using System;
using System.Collections.Generic;
using System.Linq;
using CoderGirl_SalesList;
using Xunit;

namespace Test
{
    public class SalesRecordAdapterTest
    {
        ISalesRecordAdapter salesRecordAdapter;

        public SalesRecordAdapterTest()
        {
            salesRecordAdapter = new Factory().SalesRecordAdapter;
        }
        
        [Fact]
        public void Test_Adapter_GivenFilePath_ReturnsList_WithCorrectNumberOfItems()
        {
            string path = @"TestData.csv";

            List<SalesRecord> result = salesRecordAdapter.GetSalesRecordsFromCsvFile(path, true);

            Assert.Equal(100, result.Count);
        }

        [Theory]
        [InlineData("Sub-Saharan Africa,Burkina Faso,Vegetables,Online,H,7/17/2012,871543967,7/27/2012,8082,154.06,90.93,1245112.92,734896.26,510216.66")]
        [InlineData("Australia and Oceania,Fiji,Clothes,Offline,C,6/30/2010,647876489,8/1/2010,9905,109.28,35.84,1082418.40,354995.20,727423.20")]
        [InlineData("Australia and Oceania,Samoa ,Cosmetics,Online,H,7/20/2013,670854651,8/7/2013,9654,437.20,263.33,4220728.80,2542187.82,1678540.98")]
        public void Test_AdapterGivenFilePath_ReturnsSalesRecords_WithProperData(string testLine)
        {
            string path = @"TestData.csv";

            List<SalesRecord> result = salesRecordAdapter.GetSalesRecordsFromCsvFile(path, true);

            bool everythingMatches = false;

            while (everythingMatches == false)
            {
                foreach (SalesRecord salesRecord in result)
                {
                    everythingMatches = ContainsMatchingData(testLine, salesRecord);
                    if (everythingMatches == true)
                    {
                        break;
                    }
                }
            }

            //Assert.Contains(result, item => ContainsMatchingData(testLine, item));

            Assert.True(everythingMatches);
        }

        private bool ContainsMatchingData(string testLine, SalesRecord item)
        {
            string[] expectedData = testLine.Split(",");
            //IEnumerable<string> itemProperties = item.GetPropertiesAsStrings();

            string[] itemArray = {item.Region,
                item.Country,
                item.ItemType,
                item.SalesChannel,
                item.OrderPriority,
                item.OrderDate.ToString("M/d/yyyy"),
                item.OrderId,
                item.ShipDate.ToString("M/d/yyyy"),
                item.UnitsSold.ToString(),
                item.UnitPrice.ToString(),
                item.UnitCost.ToString(),
                item.TotalRevenue.ToString(),
                item.TotalCost.ToString(),
                item.TotalProfit.ToString() };
            IEnumerable<string> missingData = expectedData.Except(itemArray);
            return !missingData.Any();
        }
    }

    static class TestExtensions {
        public static IEnumerable<string> GetPropertiesAsStrings(this SalesRecord item)
        {
            return item.GetType().GetProperties().Select(prop => prop.ToString());
        }
    }
}
