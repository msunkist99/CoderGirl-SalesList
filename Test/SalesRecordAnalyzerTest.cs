using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoderGirl_SalesList;
using Xunit;

namespace Test
{
    public class SalesRecordAnalyzerTest
    {
        ISalesRecordAnalyzer salesRecordAnalyzer;

        public SalesRecordAnalyzerTest()
        {
            salesRecordAnalyzer = new Factory().SalesRecordAnalyzer;
        }

        [Theory]
        [InlineData("4/20/2014", true)]
        [InlineData("4/20/2013", false)]
        [InlineData("4/20/2020", true)]
        public void TestOrderDatesBefore(string cuttoff, bool expected)
        {
            DateTime testDate = DateTime.Parse(cuttoff);
            List<SalesRecord> salesRecords = new List<SalesRecord>
            {
                new SalesRecord{OrderDate = DateTime.Parse("4/19/2014")},
                new SalesRecord{OrderDate = DateTime.Parse("4/18/2014")},
                new SalesRecord{OrderDate = DateTime.Parse("4/20/2014")},
                new SalesRecord{OrderDate = DateTime.Parse("4/19/2019")}
            };

            bool actual = salesRecordAnalyzer.AreOrderDatesBefore(testDate, salesRecords);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestGetCountries()
        {
            List<SalesRecord> salesRecords = new List<SalesRecord>
            {
                new SalesRecord{Country = "Country1"},
                new SalesRecord{Country = "Country2"},
                new SalesRecord{Country = "Country3"},
                new SalesRecord{Country = "country3"},
                new SalesRecord{Country = "Country2"}
            };

            List<string> actual = salesRecordAnalyzer.GetCountries(salesRecords);

            Assert.Equal(4, actual.Count);
            Assert.Contains(actual, country => country == "Country1");
            Assert.Contains(actual, country => country == "Country2");
            Assert.Contains(actual, country => country == "Country3");
            Assert.Contains(actual, country => country == "country3");
        }

        [Fact]
        public void TestGetCountryCount()
        {
            List<SalesRecord> salesRecords = new List<SalesRecord>
            {
                new SalesRecord{Country = "Country1"},
                new SalesRecord{Country = "Country2"},
                new SalesRecord{Country = "Country3"},
                new SalesRecord{Country = "country3"},
                new SalesRecord{Country = "Country2"}
            };

            int actual = salesRecordAnalyzer.GetCountryCount(salesRecords);

            Assert.Equal(4, actual);
        }

        [Fact]
        public void TestGetMaxProfit()
        {
            List<SalesRecord> salesRecords = new List<SalesRecord>
            {
                new SalesRecord{TotalProfit = 17.2},
                new SalesRecord{TotalProfit = 17.0},
                new SalesRecord{TotalProfit = 0.0},
                new SalesRecord{TotalProfit = 17.1},
                new SalesRecord{TotalProfit = 10.0}
            };

            double actual = salesRecordAnalyzer.GetMaxProfit(salesRecords);

            Assert.Equal((double)17.2, actual);
        }

        [Fact]
        public void TestGetTotalRevenue()
        {
            List<SalesRecord> salesRecords = new List<SalesRecord>
            {
                new SalesRecord{TotalRevenue = 17.2},
                new SalesRecord{TotalRevenue = 17.0},
                new SalesRecord{TotalRevenue = 0.0},
                new SalesRecord{TotalRevenue = 17.1},
                new SalesRecord{TotalRevenue = 10.0}
            };

            double actual = Math.Round( salesRecordAnalyzer.GetTotalRevenue(salesRecords),2);

            Assert.Equal((double)61.30, actual);
        }

        [Fact]
        public void TestOrderByShipDate()
        {
            List<DateTime> expected = new List<DateTime>
            {
                DateTime.Parse("4/20/2013"),
                DateTime.Parse("4/18/2014"),
                DateTime.Parse("4/19/2014"),
                DateTime.Parse("4/20/2014"),
                DateTime.Parse("3/10/2019")
            };
            List<SalesRecord> salesRecords = new List<SalesRecord>
            {
                new SalesRecord{ShipDate = DateTime.Parse("4/19/2014")},
                new SalesRecord{ShipDate = DateTime.Parse("4/18/2014")},
                new SalesRecord{ShipDate = DateTime.Parse("4/20/2014")},
                new SalesRecord{ShipDate = DateTime.Parse("4/20/2013")},
                new SalesRecord{ShipDate = DateTime.Parse("3/10/2019")}
            };

            List<DateTime> actual = salesRecordAnalyzer.OrderByShipDate(salesRecords)
                .Select(record => record.ShipDate).ToList();

            Assert.True(expected.SequenceEqual(actual));
        }

        [Fact]
        public void TestOrderByUnitsSoldDescending()
        {
            List<int> expected = new List<int> { 101, 101, 29, 12, 1 };
            List<SalesRecord> salesRecords = new List<SalesRecord>
            {
                new SalesRecord{UnitsSold = 12},
                new SalesRecord{UnitsSold = 29},
                new SalesRecord{UnitsSold = 1},
                new SalesRecord{UnitsSold = 101},
                new SalesRecord{UnitsSold = 101}
            };

            List<int> actual = salesRecordAnalyzer.OrderByUnitsSoldDescending(salesRecords)
                .Select(record => record.UnitsSold).ToList();

            Assert.True(expected.SequenceEqual(actual));
        }
    }
}