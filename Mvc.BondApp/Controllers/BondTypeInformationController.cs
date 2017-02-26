using System.Linq;
using System.Web.Mvc;
using Mvc.BondApp;

namespace templateMvc.Controllers
{
    public class BondTypeInformationController : Controller
    {
        BondModel _context = new BondModel();
        // GET: BondTypeInformation
        public ActionResult ListOfBond()
        {
            var bonds = _context.BONDINFOes.ToList();
            return View(bonds);
        }

        // GET: BondTypeInformation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BondTypeInformation/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BondTypeInformation/Create
        [HttpPost]
        public ActionResult Create(BONDINFO bondinfo)
        {
            try
            {
                // TODO: Add insert logic here

                _context.BONDINFOes.Add(bondinfo);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BondTypeInformation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BondTypeInformation/Edit/5
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

        // GET: BondTypeInformation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BondTypeInformation/Delete/5
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
