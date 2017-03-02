using System;

namespace Mvc.BondApp.ViewModels
{
    public class NewApplicationBondScriptViewModel
    {
        public int SerialNo { get; set; }
        public string Prefix { get; set; }
        public int BondNo { get; set; }
        public DateTime MaturityDate { get; set; }
        public decimal Value { get; set; }
        public string NomineeName { get; set; }
        public string Relation { get; set; }
        public decimal AmountPaid { get; set; }
    }
}