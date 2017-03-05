namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.BONDINFO")]
    public partial class BONDINFO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BONDINFO()
        {
            INSURANCEINFOes = new HashSet<INSURANCEINFO>();
            INTRATEINFOes = new HashSet<INTRATEINFO>();
            SCRIPTDENOINFOes = new HashSet<SCRIPTDENOINFO>();
            STOCKMSTs = new HashSet<STOCKMST>();
            TRANSMSTs = new HashSet<TRANSMST>();
        }

        [Key]
        [StringLength(2)]
        public string BONDCODE { get; set; }

        [Required]
        [StringLength(100)]
        public string BONDNAME { get; set; }

        [StringLength(20)]
        public string BONDSNAME { get; set; }

        [StringLength(3)]
        public string CURRCODE { get; set; }

        [StringLength(3)]
        public string INTCURRCODE { get; set; }

        public byte? DURATION { get; set; }

        [StringLength(30)]
        public string CRACCT { get; set; }

        [StringLength(30)]
        public string DRACCT { get; set; }

        public byte? SCRIPLENGTH { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(20)]
        public string TERMINAL { get; set; }

        public byte? INSURANCE { get; set; }

        public byte? INSTDURATION { get; set; }

        [StringLength(4)]
        public string COMPOUNDINT { get; set; }

        [StringLength(100)]
        public string CERTIHEAD { get; set; }

        public virtual CURRINFO CURRINFO { get; set; }

        public virtual CURRINFO CURRINFO1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INSURANCEINFO> INSURANCEINFOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<INTRATEINFO> INTRATEINFOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCRIPTDENOINFO> SCRIPTDENOINFOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCKMST> STOCKMSTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANSMST> TRANSMSTs { get; set; }
    }
}
