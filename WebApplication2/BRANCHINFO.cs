namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.BRANCHINFO")]
    public partial class BRANCHINFO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BRANCHINFO()
        {
            BONDAPPLICATIONs = new HashSet<BONDAPPLICATION>();
            BONDAPPLICATIONs1 = new HashSet<BONDAPPLICATION>();
            STOCKMSTs = new HashSet<STOCKMST>();
            TRANSMSTs = new HashSet<TRANSMST>();
        }

        [Key]
        [StringLength(6)]
        public string BRCODE { get; set; }

        [Required]
        [StringLength(50)]
        public string BRNAME { get; set; }

        [StringLength(100)]
        public string BRADDRESS { get; set; }

        [StringLength(6)]
        public string ADBRCODE { get; set; }

        [StringLength(6)]
        public string BBRCODE { get; set; }

        [StringLength(1)]
        public string ACTIVESTATUS { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(20)]
        public string TERMINAL { get; set; }

        [StringLength(2)]
        public string BANKCODE { get; set; }

        [StringLength(1)]
        public string WITHCL { get; set; }

        [StringLength(1)]
        public string AVOUCHER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BONDAPPLICATION> BONDAPPLICATIONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BONDAPPLICATION> BONDAPPLICATIONs1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STOCKMST> STOCKMSTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANSMST> TRANSMSTs { get; set; }
    }
}
