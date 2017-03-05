namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.BONDAPPLICATION")]
    public partial class BONDAPPLICATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BONDAPPLICATION()
        {
            APPSCRIPTs = new HashSet<APPSCRIPT>();
            TRANSMSTs = new HashSet<TRANSMST>();
        }

        [Key]
        [StringLength(12)]
        public string BONDSCN { get; set; }

        [StringLength(12)]
        public string SALEADVNO { get; set; }

        [StringLength(10)]
        public string CLIENTAPPNO { get; set; }

        public int? FILENO { get; set; }

        [StringLength(6)]
        public string BRCODE { get; set; }

        [StringLength(2)]
        public string BONDCODE { get; set; }

        public DateTime? SCNDATE { get; set; }

        [StringLength(1)]
        public string PAYMODE { get; set; }

        [StringLength(50)]
        public string BUYFNAME { get; set; }

        [StringLength(50)]
        public string BUYMNAME { get; set; }

        [StringLength(50)]
        public string BUYLNAME { get; set; }

        [StringLength(80)]
        public string LOCALADDR { get; set; }

        [StringLength(3)]
        public string LOCALTHANA { get; set; }

        [StringLength(2)]
        public string LOCALDIST { get; set; }

        [StringLength(80)]
        public string ABOARDADDR { get; set; }

        [StringLength(2)]
        public string CNTYCODE { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(1)]
        public string SEX { get; set; }

        [StringLength(60)]
        public string DESIG { get; set; }

        [StringLength(80)]
        public string COMNAME { get; set; }

        [StringLength(100)]
        public string COMADDR { get; set; }

        [StringLength(20)]
        public string PASSPORTNO { get; set; }

        public DateTime? PASSISSUEDATE { get; set; }

        [StringLength(2)]
        public string ISSUEPLACE { get; set; }

        [StringLength(12)]
        public string FCACNO { get; set; }

        [StringLength(6)]
        public string FCBRCODE { get; set; }

        [StringLength(20)]
        public string FDDNO { get; set; }

        [StringLength(5)]
        public string EXBANKCODE { get; set; }

        public decimal? AMOUNTFC { get; set; }

        [StringLength(3)]
        public string CURRCODE { get; set; }

        public decimal? EXRATE { get; set; }

        public DateTime? VALUEDATE { get; set; }

        public short? TOTALSCRIPT { get; set; }

        [StringLength(2)]
        public string STATUSCODE { get; set; }

        [StringLength(100)]
        public string REMARKS { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(20)]
        public string TERMINAL { get; set; }

        public decimal? AMOUNTCR { get; set; }

        [StringLength(6)]
        public string PAYOFF { get; set; }

        public DateTime? ISSUEDATE { get; set; }

        [StringLength(80)]
        public string FNAME { get; set; }

        [StringLength(80)]
        public string MNAME { get; set; }

        [StringLength(1)]
        public string BACKENTRY { get; set; }

        public DateTime? REINVDATE { get; set; }

        public short? OLDFILENO { get; set; }

        [StringLength(6)]
        public string FBRCODE { get; set; }

        public DateTime? RESPONDDATE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<APPSCRIPT> APPSCRIPTs { get; set; }

        public virtual EXHOUSE_INFO EXHOUSE_INFO { get; set; }

        public virtual DISTINFO DISTINFO { get; set; }

        public virtual BRANCHINFO BRANCHINFO { get; set; }

        public virtual COUNTRYINFO COUNTRYINFO { get; set; }

        public virtual DISTINFO DISTINFO1 { get; set; }

        public virtual BONDPAYMODE BONDPAYMODE { get; set; }

        public virtual STATUSINFO STATUSINFO { get; set; }

        public virtual THANAINFO THANAINFO { get; set; }

        public virtual BENEFICIARY BENEFICIARY { get; set; }

        public virtual BRANCHINFO BRANCHINFO1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANSMST> TRANSMSTs { get; set; }
    }
}
