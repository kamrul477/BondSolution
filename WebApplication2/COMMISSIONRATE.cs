namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.COMMISSIONRATE")]
    public partial class COMMISSIONRATE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string COMMCODE { get; set; }

        [StringLength(80)]
        public string COMMDESC { get; set; }

        [StringLength(1)]
        public string COMMTYPE { get; set; }

        public decimal? RATETK { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string BONDCODE { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        [StringLength(20)]
        public string TERMINAL { get; set; }

        public DateTime? ENTRYDATE { get; set; }
    }
}
