using System;
using System.Collections.Generic;
using System.Text;

namespace CoderGirl_SalesList
{
    public class Factory
    {
        public ISalesRecordAdapter SalesRecordAdapter { get; private set; }
        public ISalesRecordAnalyzer SalesRecordAnalyzer { get; private set; }
        public ISalesRecordRepository SalesRecordRepository { get; private set; }

        public Factory()
        {
            //TODO: Add specific implementation classes
            //this.SalesRecordRepository = new ??
            //this.SalesRecordAnalyzer = new ??
            //this.SalesRecordAdapter = new ??

            this.SalesRecordRepository = new SalesRecordRepository();
            this.SalesRecordAnalyzer = new SalesRecordAnalyzer();
            this.SalesRecordAdapter = new SalesRecordAdapter();
        }
    }
}
