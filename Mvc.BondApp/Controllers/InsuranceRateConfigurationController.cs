using System.Web.Mvc;

namespace templateMvc.Controllers
{
    public class InsuranceRateConfigurationController : Controller
    {
        // GET: InsuranceRateConfiguration
        public ActionResult Index()
        {
            return View();
        }

        // GET: InsuranceRateConfiguration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InsuranceRateConfiguration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InsuranceRateConfiguration/Create
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

        // GET: InsuranceRateConfiguration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InsuranceRateConfiguration/Edit/5
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

        // GET: InsuranceRateConfiguration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InsuranceRateConfiguration/Delete/5
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
