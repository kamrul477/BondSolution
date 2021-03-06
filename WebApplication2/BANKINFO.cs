namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.BANKINFO")]
    public partial class BANKINFO
    {
        [Key]
        [StringLength(2)]
        public string BANKCODE { get; set; }

        [StringLength(40)]
        public string BANKNAME { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(20)]
        public string TERMINAL { get; set; }
    }
}
