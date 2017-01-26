namespace BondDataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.CLAIMINFO")]
    public partial class CLAIMINFO
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(17)]
        public string CLAIMNO { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime CLAIMDATE { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string CLAIMTYPE { get; set; }

        [StringLength(12)]
        public string BONDSCN { get; set; }

        [StringLength(100)]
        public string BONDNAME { get; set; }

        [StringLength(6)]
        public string BRCODE { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(2)]
        public string BONDCODE { get; set; }

        [StringLength(1)]
        public string TRANMODE { get; set; }

        [StringLength(3)]
        public string CURRCODE { get; set; }

        public decimal? CLAIMAMT { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(20)]
        public string TERMINAL { get; set; }

        [StringLength(1)]
        public string RECONSTATUS { get; set; }

        public DateTime? RECONDATE { get; set; }

        [StringLength(17)]
        public string TRANNO { get; set; }

        [StringLength(1)]
        public string REPART { get; set; }

        public decimal? LEAVYAMT { get; set; }

        public decimal? SSPAMT { get; set; }
    }
}
