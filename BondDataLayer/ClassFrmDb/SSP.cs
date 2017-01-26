namespace BondDataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.SSP")]
    public partial class SSP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string BONDCODE { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte SLAB { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime STARTDATE { get; set; }

        public DateTime? ENDDATE { get; set; }

        public decimal? INTRATE { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        [StringLength(30)]
        public string TERMINAL { get; set; }

        public DateTime? ENTRYDATE { get; set; }
    }
}
