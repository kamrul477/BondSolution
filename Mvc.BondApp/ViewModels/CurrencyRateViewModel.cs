using System.Collections.Generic;

namespace Mvc.BondApp
{
    public class CurrencyRateViewModel
    {
        //public string CurrencyCode { get; set; }
        //public string CurrencyName { get; set; }
        //public DateTime EntryDate { get; set; }
        //public double RateAmount { get; set; }
        public List<CURRINFO> Currinfos { get; set; }
        public List<RATEINFO> Rateinfos { get; set; }
    }
}