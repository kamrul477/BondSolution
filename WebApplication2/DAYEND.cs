namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.DAYEND")]
    public partial class DAYEND
    {
        [Key]
        public DateTime EDATE { get; set; }

        public decimal? TCLAIM { get; set; }

        public decimal? TRECONCILE { get; set; }

        [StringLength(30)]
        public string USERID { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(2)]
        public string BONDCODE { get; set; }
    }
}
