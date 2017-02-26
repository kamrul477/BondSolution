using Mvc.BondApp;
using System;
using System.Linq;
using System.Web.Mvc;

namespace templateMvc.Controllers
{
    public class RateConfigurationController : Controller
    {
        private BondModel _context = new BondModel();
        // GET: RateConfiguration
        public ActionResult CurrencyRateList()
        {
            var rateList = _context.RATEINFOes.ToList();
            var currencyList = _context.CURRINFOes.ToList();
            CurrencyRateViewModel model = new CurrencyRateViewModel() { Currinfos = currencyList, Rateinfos = rateList };
            return View(model);
        }

        // GET: RateConfiguration/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RateConfiguration/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: RateConfiguration/Create
        [HttpPost]
        public ActionResult Create(RATEINFO rateinfo)
        {
            try
            {
                // TODO: Add insert logic here
                if (rateinfo != null)
                {
                    RATEINFO _rateinfo = new RATEINFO { RDATE = (DateTime)rateinfo.ENTRYDATE };
                    _rateinfo.CURRCODE = rateinfo.CURRCODE;
                    _rateinfo.ENTRYDATE = rateinfo.ENTRYDATE;
                    _rateinfo.RATEAMT = rateinfo.RATEAMT;

                    _context.RATEINFOes.Add(_rateinfo);
                    _context.SaveChanges();

                }

                return RedirectToAction("CurrencyRateList");
            }
            catch
            {
                return View();
            }
        }

        // GET: RateConfiguration/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RateConfiguration/Edit/5
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

        // GET: RateConfiguration/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RateConfiguration/Delete/5
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
