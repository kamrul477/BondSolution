namespace Mvc.BondApp
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BOND.FCACCOUNT_INFO")]
    public partial class FCACCOUNT_INFO
    {
        [Key]
        [StringLength(30)]
        public string FCACCOUNTNO { get; set; }

        [StringLength(80)]
        public string FCACNAME { get; set; }

        [StringLength(100)]
        public string FCACADD { get; set; }

        [StringLength(30)]
        public string FCACPHONE { get; set; }
    }
}
