using System.Linq;
using System.Web.Mvc;

namespace Mvc.BondApp.Controllers
{
    public class BBPaymentController : Controller
    {
        private BondModel _context = new BondModel();

        #region BBPAYMENT + DATA ENTRY

        public ActionResult DataEntryInitialDisplay()
        {
            ViewBag.BONDCODE = _context.BONDINFOes.ToList();
            return View();
        }


        #endregion



        #region BBPAYMENT + PAYMENT REPORT

        public ActionResult PaymentReportInitialDisplay()
        {
            return View();
        }

        #endregion



        #region BBPAYMENT + UNRECONCILE CLAIM WISE

        public ActionResult UnreconcileClaimWiseInitialDisplay()
        {
            return View();
        }


        #endregion


        #region BBPAYMENT + UNRECONCILE TRA WISE

        public ActionResult UnreconcileTraWiseInitialDisplay()
        {
            return View();
        }


        #endregion
    }
}
