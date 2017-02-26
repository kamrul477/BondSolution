namespace Mvc.BondApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.BONDPAYMODE")]
    public partial class BONDPAYMODE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BONDPAYMODE()
        {
            BONDAPPLICATIONs = new HashSet<BONDAPPLICATION>();
            TRANSMSTs = new HashSet<TRANSMST>();
        }

        [Key]
        [StringLength(1)]
        public string PAYCODE { get; set; }

        [StringLength(100)]
        public string PAYDESC { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(20)]
        public string TERMINAL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BONDAPPLICATION> BONDAPPLICATIONs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANSMST> TRANSMSTs { get; set; }
    }
}
