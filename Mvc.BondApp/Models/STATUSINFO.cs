namespace Mvc.BondApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.STATUSINFO")]
    public partial class STATUSINFO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STATUSINFO()
        {
            BONDAPPLICATIONs = new HashSet<BONDAPPLICATION>();
        }

        [Key]
        [StringLength(2)]
        public string STATUSCODE { get; set; }

        [StringLength(100)]
        public string STATUSDESC { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(20)]
        public string TERMINAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BONDAPPLICATION> BONDAPPLICATIONs { get; set; }
    }
}
