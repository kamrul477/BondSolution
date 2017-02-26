namespace Mvc.BondApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOND.STOCKMST")]
    public partial class STOCKMST
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LOTNO { get; set; }

        [StringLength(6)]
        public string BRCODE { get; set; }

        [StringLength(2)]
        public string BONDCODE { get; set; }

        [StringLength(30)]
        public string INDENTNO { get; set; }

        public DateTime? INDENTDATE { get; set; }

        public long? TOTALAMOUNT { get; set; }

        public int? TOTALSCRIPT { get; set; }

        [StringLength(10)]
        public string USERID { get; set; }

        public DateTime? ENTRYDATE { get; set; }

        [StringLength(20)]
        public string TERMINAL { get; set; }

        public virtual BONDINFO BONDINFO { get; set; }

        public virtual BRANCHINFO BRANCHINFO { get; set; }
    }
}
