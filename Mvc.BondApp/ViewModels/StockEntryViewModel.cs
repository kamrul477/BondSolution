using System;

namespace Mvc.BondApp.ViewModels
{
    public class StockEntryViewModel
    {
        public string BondCode { get; set; }
        public string IndentNo { get; set; }
        public DateTime IndentDate { get; set; }
        public decimal TotalAmount { get; set; }
        public int TotalScript { get; set; }
        public decimal ScriptValue { get; set; }
        public string Prefix { get; set; }
        public int StartingScriptNo { get; set; }
        public int NoOfContinuousScript { get; set; }

    }
}