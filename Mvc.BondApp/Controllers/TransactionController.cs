using Mvc.BondApp.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace Mvc.BondApp.Controllers
{
    public class TransactionController : Controller
    {
        BondModel _context = new BondModel();

        #region INSTALLMENT PAYMENT AREA

        #endregion
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ApplicationSearch(string applicationNo)
        {
            var application = _context.BONDAPPLICATIONs.SingleOrDefault(a => a.BONDSCN.Equals(applicationNo));
            var model = new InstallmentPaymentViewModel()
            {
                Bondapplication = application
            };
            
            return View(model);
        }
    }
}