namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.COMMISSIONINFO")]
    public partial class COMMISSIONINFO
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(17)]
        public string TRANNO { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime TRANDATE { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string COMMCODE { get; set; }

        public decimal? COMMRATETK { get; set; }

        [StringLength(3)]
        public string CURRCODE { get; set; }

        public decimal? CURRRATE { get; set; }

        public decimal? DRAMT { get; set; }

        public decimal? CRAMT { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(20)]
        public string TERMINAL { get; set; }

        [StringLength(6)]
        public string BRCODE { get; set; }

        public short? NOOFBOND { get; set; }

        [StringLength(2)]
        public string BONDCODE { get; set; }

        [StringLength(12)]
        public string BONDSCN { get; set; }

        public virtual CURRINFO CURRINFO { get; set; }
    }
}
