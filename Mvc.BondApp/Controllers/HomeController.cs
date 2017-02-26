using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Mvc.BondApp.Controllers
{
    public class HomeController : Controller
    {
        private BondModel _context = new BondModel();
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetBondInfo()
        {
            var bondType = _context.BONDINFOes.ToList();
            return Json(bondType, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public JsonResult GetCategories()
        {
            List<object> items = new List<object>()
               {
                  new SelectListItem { Value="1", Text="Beverages" },
                  new SelectListItem { Value="2", Text="Condiments" },
                  new SelectListItem { Value="3", Text="Confectionries" },
                  new SelectListItem { Value="4", Text="Dairy" }
               };
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}