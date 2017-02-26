namespace Mvc.BondApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.APPSCRIPT")]
    public partial class APPSCRIPT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string BONDSCN { get; set; }

        [StringLength(2)]
        public string BONDCODE { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short? BONDSL { get; set; }

        public int? BONDVALUE { get; set; }

        [StringLength(12)]
        public string BONDPREFIX { get; set; }

        [StringLength(12)]
        public string BONDNO { get; set; }

        [StringLength(100)]
        public string NOMNAME { get; set; }

        public DateTime? MATURITYDATE { get; set; }

        [StringLength(2)]
        public string BONDSTATUS { get; set; }

        public DateTime? DUPISSUEDATE { get; set; }

        public DateTime? ENCASHDATE { get; set; }

        public byte? INSTALLNO { get; set; }

        [StringLength(17)]
        public string TRANNO { get; set; }

        [StringLength(12)]
        public string PREBONDNO { get; set; }

        [StringLength(15)]
        public string BRELATION { get; set; }

        public virtual BONDAPPLICATION BONDAPPLICATION { get; set; }
    }
}
