namespace Mvc.BondApp
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("BOND.BENEFICIARY")]
    public partial class BENEFICIARY
    {
        [Key]
        [StringLength(12)]
        public string BONDSCN { get; set; }

        [StringLength(100)]
        public string BENNAME { get; set; }

        [StringLength(100)]
        public string BENFNAME { get; set; }

        [StringLength(100)]
        public string BENMNAME { get; set; }

        public DateTime? BENDOB { get; set; }

        [StringLength(200)]
        public string BENADDR { get; set; }

        public virtual BONDAPPLICATION BONDAPPLICATION { get; set; }
    }
}
