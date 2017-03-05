namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.EXHOUSE_INFO")]
    public partial class EXHOUSE_INFO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EXHOUSE_INFO()
        {
            BONDAPPLICATIONs = new HashSet<BONDAPPLICATION>();
        }

        [Key]
        [StringLength(3)]
        public string EXCODE { get; set; }

        [StringLength(60)]
        public string EXNAME { get; set; }

        [StringLength(100)]
        public string EXADD { get; set; }

        [StringLength(2)]
        public string EXCNTY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BONDAPPLICATION> BONDAPPLICATIONs { get; set; }
    }
}
