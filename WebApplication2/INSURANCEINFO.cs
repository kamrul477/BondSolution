namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.INSURANCEINFO")]
    public partial class INSURANCEINFO
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string BONDCODE { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte? SLAB { get; set; }

        public decimal? AMTFROM { get; set; }

        public decimal? AMTTO { get; set; }

        public DateTime? STARTDATE { get; set; }

        public DateTime? ENDDATE { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal? INSPER { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        [StringLength(30)]
        public string TERMINAL { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        public decimal? MINAMT { get; set; }

        public virtual BONDINFO BONDINFO { get; set; }
    }
}
