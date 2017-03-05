namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.USERINFO")]
    public partial class USERINFO
    {
        [Key]
        public byte USERSL { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        [StringLength(50)]
        public string NAME { get; set; }

        [StringLength(30)]
        public string DESIGNATION { get; set; }

        public byte? MGRID { get; set; }

        [StringLength(1)]
        public string STATUS { get; set; }

        public DateTime? LOCKDATE { get; set; }

        public DateTime? IDCREATIONDATE { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(20)]
        public string TERMINAL { get; set; }
    }
}
