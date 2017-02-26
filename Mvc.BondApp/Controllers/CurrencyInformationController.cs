using Mvc.BondApp;
using System.Linq;
using System.Web.Mvc;

namespace templateMvc.Controllers
{
    public class CurrencyInformationController : Controller
    {

        BondModel _context = new BondModel();
        // GET: CurrencyInformation
        public ActionResult ListOfCurrency()
        {
            var currencyList = _context.CURRINFOes.ToList();
            return View(currencyList);
        }

        // GET: CurrencyInformation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CurrencyInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CurrencyInformation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CurrencyInformation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CurrencyInformation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CurrencyInformation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CurrencyInformation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
