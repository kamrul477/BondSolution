namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.TRANSCHD")]
    public partial class TRANSCHD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(17)]
        public string TRANNO { get; set; }

        [Key]
        [Column(Order = 1)]
        public byte TRANSL { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime TRANDATE { get; set; }

        [StringLength(2)]
        public string BONDCODE { get; set; }

        public int? BONDVALUE { get; set; }

        [StringLength(12)]
        public string BONDPREFIX { get; set; }

        [StringLength(12)]
        public string BONDNO { get; set; }

        public byte? INSTALLNO { get; set; }

        public DateTime? BASEDATE { get; set; }

        public decimal? INTRATE { get; set; }

        public decimal? CALINT { get; set; }

        public decimal? PAIDUPINT { get; set; }

        public decimal? NETPAY { get; set; }

        [StringLength(30)]
        public string TERMINAL { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        public decimal? LEVEYAMT { get; set; }

        [StringLength(1)]
        public string PAYTYPE { get; set; }

        public decimal? LEAVYPAID { get; set; }

        public decimal? SSPAMT { get; set; }

        public decimal? SSPPAID { get; set; }

        public virtual TRANSMST TRANSMST { get; set; }
    }
}
