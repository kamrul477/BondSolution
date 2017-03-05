namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.DISTINFO")]
    public partial class DISTINFO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DISTINFO()
        {
            BONDAPPLICATIONs = new HashSet<BONDAPPLICATION>();
            BONDAPPLICATIONs1 = new HashSet<BONDAPPLICATION>();
        }

        [Key]
        [StringLength(2)]
        public string DISTCODE { get; set; }

        [StringLength(40)]
        public string DISTDESC { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(20)]
        public string TERMINAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BONDAPPLICATION> BONDAPPLICATIONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BONDAPPLICATION> BONDAPPLICATIONs1 { get; set; }
    }
}
