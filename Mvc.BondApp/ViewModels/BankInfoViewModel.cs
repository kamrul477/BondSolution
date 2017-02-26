using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc.BondApp
{
    public class BankInfoListViewModel
    {
        public ICollection<BANKINFO> BankinfosCollection { get; set; }

        [Display(Name = "Bank Name")]
        public int SelectedBankCode { get; set; }

        public IEnumerable<SelectListItem> BanksList
        {
            get { return new SelectList(BankinfosCollection,"BANKCODE", "BANKNAME","USERID"); }
        }
    }
}