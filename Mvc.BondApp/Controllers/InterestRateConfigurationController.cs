using Mvc.BondApp;
using System.Linq;
using System.Web.Mvc;

namespace templateMvc.Controllers
{
    public class InterestRateConfigurationController : Controller
    {
        BondModel _context = new BondModel();
        // GET: InterestRateConfiguration
        public ActionResult PresentConfiguration()
        {
            var interestRateConfiguration = _context.INTRATEINFOes.ToList();
            return View(interestRateConfiguration);
        }

        // GET: InterestRateConfiguration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InterestRateConfiguration/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();

        }

        // POST: InterestRateConfiguration/Create
        [HttpPost]
        public ActionResult Create(INTRATEINFO intrateinfo)
        {
            try
            {
                //there is problem with slab that has be resolved.....................
                var intRateInfo = _context.INTRATEINFOes.Find(intrateinfo.BONDCODE, intrateinfo.DURATION);
                // TODO: Add insert logic here
                var _intrateinfo = new INTRATEINFO();
                _intrateinfo.BONDCODE = intrateinfo.BONDCODE;
                _intrateinfo.ENTRYDATE = intrateinfo.ENTRYDATE;
                _intrateinfo.DURATION = intrateinfo.DURATION;
                _intrateinfo.SLAB = (byte)(intRateInfo.SLAB + 1);
                _intrateinfo.ENDDATE = intrateinfo.ENDDATE;
                _intrateinfo.INTRATE = intrateinfo.INTRATE;
                _context.INTRATEINFOes.Add(_intrateinfo);
                return RedirectToAction("PresentConfiguration");
            }
            catch
            {
                return View();
            }
        }

        // GET: InterestRateConfiguration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InterestRateConfiguration/Edit/5
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

        // GET: InterestRateConfiguration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InterestRateConfiguration/Delete/5
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
