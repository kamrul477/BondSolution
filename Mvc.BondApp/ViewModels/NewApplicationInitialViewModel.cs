using System.Collections.Generic;
using templateMvc;

namespace Mvc.BondApp
{
    public class NewApplicationInitialViewModel
    {
        public List<BONDINFO> BondinfoListForView { get; set; }
        public NewApplication NewApplication { get; set; }
        public List<COUNTRYINFO> CountryinfoListForView { get; set; }
        public IEnumerable<DISTINFO> DistinfoListForView { get; set; }
        public List<BONDPAYMODE> BondpaymodeListForView { get; set; }

    }
}