using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.BondApp.ViewModels
{
    public class BondTypeViewModel
    {
        public string BONDCODE { get; set; }

        [Required]
        [StringLength(100)]
        public string BONDNAME { get; set; }
    }
}