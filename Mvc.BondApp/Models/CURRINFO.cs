namespace Mvc.BondApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BOND.CURRINFO")]
    public partial class CURRINFO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CURRINFO()
        {
            BONDINFOes = new HashSet<BONDINFO>();
            //BONDINFOes1 = new HashSet<BONDINFO>();
            COMMISSIONINFOes = new HashSet<COMMISSIONINFO>();
            RATEINFOes = new HashSet<RATEINFO>();
            TRANSMSTs = new HashSet<TRANSMST>();
        }

        [Key]
        [StringLength(3)]
        public string CURRCODE { get; set; }

        [Required]
        [StringLength(40)]
        public string CURRNAME { get; set; }

        [StringLength(2)]
        public string CURRSIGN { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(20)]
        public string TERMINAL { get; set; }

        [StringLength(10)]
        public string PAISANAME { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BONDINFO> BONDINFOes { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<BONDINFO> BONDINFOes1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<COMMISSIONINFO> COMMISSIONINFOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RATEINFO> RATEINFOes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANSMST> TRANSMSTs { get; set; }
    }
}
