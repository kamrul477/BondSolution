namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.SCRIPTDENOINFO")]
    public partial class SCRIPTDENOINFO
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string BONDCODE { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BONDVALUE { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(12)]
        public string BONDPREFIX { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(20)]
        public string TERMINAL { get; set; }

        public virtual BONDINFO BONDINFO { get; set; }
    }
}
