namespace BondDataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.RATEINFO")]
    public partial class RATEINFO
    {
        [Key]
        [Column(Order = 0)]
        public DateTime RDATE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string CURRCODE { get; set; }

        public decimal? RATEAMT { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(30)]
        public string TERMINAL { get; set; }

        public virtual CURRINFO CURRINFO { get; set; }
    }
}
