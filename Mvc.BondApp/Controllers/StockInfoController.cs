using System.Linq;
using Mvc.BondApp.ViewModels;
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
            return View(model);
        }


        #endregion






    }
}