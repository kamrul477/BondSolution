using System.ComponentModel.DataAnnotations;

namespace Mvc.BondApp
{
    public class FcAccountInfoViewModel
    {
        [StringLength(30)]
        public string FCACCOUNTNO { get; set; }

        [StringLength(80)]
        public string FCACNAME { get; set; }

        [StringLength(100)]
        public string FCACADD { get; set; }

        [StringLength(30)]
        public string FCACPHONE { get; set; }

        public string AccountType { get; set; }
    }
}