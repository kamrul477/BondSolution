namespace Mvc.BondApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BOND.TRANSMST")]
    public partial class TRANSMST
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRANSMST()
        {
            TRANSCHDs = new HashSet<TRANSCHD>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(17)]
        public string TRANNO { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime TRANDATE { get; set; }

        [StringLength(6)]
        public string BRCODE { get; set; }

        [StringLength(2)]
        public string BONDCODE { get; set; }

        [StringLength(12)]
        public string BONDSCN { get; set; }

        [StringLength(1)]
        public string TRANMODE { get; set; }

        [StringLength(30)]
        public string ACCNO { get; set; }

        [StringLength(1)]
        public string PAYMODE { get; set; }

        [StringLength(3)]
        public string CURRCODE { get; set; }

        public int? VOUCHERNO { get; set; }

        public decimal? DRAMT { get; set; }

        public decimal? CRAMT { get; set; }

        [StringLength(10)]
        public string ENTRYUSER { get; set; }

        [StringLength(10)]
        public string AUTHUSER { get; set; }

        public DateTime? AUTHDATE { get; set; }

        [StringLength(20)]
        public string TERMINAL { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        public decimal? EXRATE { get; set; }

        public decimal? CLAIMAMTP { get; set; }

        public decimal? CLAIMAMTI { get; set; }

        public decimal? ACTUALAMT { get; set; }

        public DateTime? DEATHDATE { get; set; }

        public decimal? CLAIMAMTS { get; set; }

        [StringLength(1)]
        public string VOUCHERTYPE { get; set; }

        [StringLength(1)]
        public string PAYTONOM { get; set; }

        [StringLength(1)]
        public string REPART { get; set; }

        [StringLength(3)]
        public string FCURR { get; set; }

        public decimal? CLAIMAMTSIM { get; set; }

        public decimal? LEAVYAMT { get; set; }

        public decimal? LEAVYAMTS { get; set; }

        public decimal? SSPAMT { get; set; }

        public virtual BONDAPPLICATION BONDAPPLICATION { get; set; }

        public virtual BONDINFO BONDINFO { get; set; }

        public virtual BONDPAYMODE BONDPAYMODE { get; set; }

        public virtual BRANCHINFO BRANCHINFO { get; set; }

        public virtual CURRINFO CURRINFO { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANSCHD> TRANSCHDs { get; set; }
    }
}
