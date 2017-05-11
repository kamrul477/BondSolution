using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc.BondApp.Models
{
    [Table("BOND.VOUCHERINFO")]
    public class VOUCHERINFO
    {
        [Key]
        [StringLength(2)]
        public string VCODE { get; set; }
        

        [StringLength(60)]
        public string VDESC { get; set; }
    }
}