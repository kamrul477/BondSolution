using Mvc.BondApp;
using System.Linq;
using System.Web.Mvc;

namespace templateMvc.Controllers
{
    public class CountryInformationController : Controller
    {
        BondModel _context = new BondModel();
        // GET: CountryInformation
        public ActionResult CountryList()
        {
            var countries = _context.COUNTRYINFOes.ToList();
            return View(countries);
        }

        // GET: CountryInformation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CountryInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CountryInformation/Create
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

        // GET: CountryInformation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CountryInformation/Edit/5
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

        // GET: CountryInformation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CountryInformation/Delete/5
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
