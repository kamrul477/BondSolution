using Mvc.BondApp.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Mvc.BondApp.Controllers
{
    public class StockInfoController : Controller
    {

        #region COMMON AREA

        private BondModel _context = new BondModel();


        #endregion

        #region STOCK ENTRY AREA

        public ActionResult StockEntry()
        {
            ViewBag.BondCodeForStockEntry = _context.BONDINFOes.ToList();
            var model = new StockEntryViewModel();
            return View();
        }

        public JsonResult GetBondScriptDenoInfo(string bondTypeIndex)
        {
            var scriptDenoInfo = _context.SCRIPTDENOINFOes.Where(p => p.BONDCODE.Equals(bondTypeIndex));
            return Json(scriptDenoInfo.Select(p => new { BONDVALUE = p.BONDVALUE, BONDPREFIX = p.BONDPREFIX }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBondScriptPrefixInfo(int denominationValue, string bondTypeIndex)
        {
            var scriptDenoInfo = _context.SCRIPTDENOINFOes.Where(p => p.BONDCODE.Equals(bondTypeIndex));
            var scriptPrefix = scriptDenoInfo.Where(x => x.BONDVALUE.Equals(denominationValue));
            return Json(scriptPrefix.Select(p => new { BONDPREFIX = p.BONDPREFIX }), JsonRequestBehavior.AllowGet);
        }


        #endregion






    }
}