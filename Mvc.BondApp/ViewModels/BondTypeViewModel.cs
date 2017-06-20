using System.ComponentModel.DataAnnotations;

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