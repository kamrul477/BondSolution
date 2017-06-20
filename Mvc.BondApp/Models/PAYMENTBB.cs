namespace Mvc.BondApp
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BOND.PAYMENTBB")]
    public partial class PAYMENTBB
    {
        public DateTime? PAYDATE { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string PAYTYPE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(17)]
        public string CLAIMNO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(6)]
        public string BRCODE { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(2)]
        public string BONDCODE { get; set; }

        [StringLength(12)]
        public string BONDSCN { get; set; }

        [StringLength(1)]
        public string TRANMODE { get; set; }

        [StringLength(3)]
        public string CURRCODE { get; set; }

        public decimal? CLAIMAMT { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(30)]
        public string TERMINAL { get; set; }

        [StringLength(10)]
        public string TRANO { get; set; }

        public DateTime? CONTRADATE { get; set; }
    }
}
