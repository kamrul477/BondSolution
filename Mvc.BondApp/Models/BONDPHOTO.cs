namespace Mvc.BondApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.BONDPHOTO")]
    public partial class BONDPHOTO
    {
        [Key]
        [StringLength(12)]
        public string BONDSCN { get; set; }

        [Column(TypeName = "long raw")]
        [MaxLength(2147483647)]
        public byte[] PIC { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(20)]
        public string TERMINAL { get; set; }
    }
}
