using Kendo.Mvc.Extensions;
using Mvc.BondApp.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;
using templateMvc;


namespace Mvc.BondApp.Controllers
{
    public class ApplicationController : Controller
    {
        //private IInventoryService inventoryService;

        //public ApplicationController(IInventoryService _inventoryService)
        //{
        //    inventoryService = _inventoryService;
        //}

        private BondModel _context = new BondModel();

        // GET: Application
        public ActionResult NewApplication()
        {
            //add new properties to this class if required to initialize the empty form.
            NewApplicationInitialViewModel bondInfoList = new NewApplicationInitialViewModel()
            {
                BondinfoListForView = _context.BONDINFOes.ToList(),
                CountryinfoListForView = _context.COUNTRYINFOes.ToList(),
                DistinfoListForView = _context.DISTINFOes.ToList(),
                BondpaymodeListForView = _context.BONDPAYMODEs.ToList()
            };


            return View(bondInfoList);
        }

        //send the bond info to the view
        public JsonResult GetBondInfo()
        {
            var bondType = from bond in _context.BONDINFOes.ToList()
                           select new BondTypeViewModel()
                           {
                               BONDCODE = bond.BONDCODE,
                               BONDNAME = bond.BONDNAME

                           };
            return Json(bondType.ToList(), JsonRequestBehavior.AllowGet);
            //DataSourceRequest request = new DataSourceRequest();
            //return Json(bondType.ToDataSourceResult(request));
        }


        public JsonResult GetCascadeDistrict()
        {
            var district = _context.DISTINFOes;

            return Json(district.Select(c => new { CategoryId = c.DISTCODE, CategoryName = c.DISTDESC }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCascadeThana(string district)
        {
            var thanas = _context.THANAINFOes.AsQueryable();


            if (district != null)
            {
                thanas = thanas.Where(p => p.DISTCODE == district);
            }

            return Json(thanas.Select(p => new { ThanaCode = p.DISTCODE, ThanaName = p.THANADESC }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPaymentMode()
        {
            var paymentMode = _context.BONDPAYMODEs.AsQueryable();
            return Json(paymentMode.Select(p => new { PAYCODE = p.PAYCODE, PAYDESC = p.PAYDESC }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetFcBranch()
        {
            var branches = _context.BRANCHINFOes.ToList();
            return Json(branches.Select(p => new { BRCODE = p.BRCODE, BRNAME = p.BRNAME }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCurrencyCode()
        {
            var currencyCode = _context.CURRINFOes.ToList();
            return Json(currencyCode.Select(p => new { CURRCODE = p.CURRCODE, CURRNAME = p.CURRNAME }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCurrencyRateOnSpecificDate(DateTime date, string currencyCode)
        {
            try
            {
                var rate = _context.RATEINFOes.Find(date, currencyCode);
                return Json(rate.RATEAMT, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(0.00, JsonRequestBehavior.AllowGet); ;
            }

        }


        public JsonResult GetExchangeHouseInfo(string searchText)
        {
            var exchangeHouses = from m in _context.EXHOUSE_INFO
                                 where m.EXNAME.Contains(searchText.ToUpper())
                                 select m;
            return Json(exchangeHouses.Select(p => new { EXCODE = p.EXCODE, EXNAME = p.EXNAME }), JsonRequestBehavior.AllowGet);
        }




        // GET: Application/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Application/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Application/Create
        [HttpPost]
        public ActionResult Create(NewApplication application)
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

        // GET: Application/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Application/Edit/5
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

        // GET: Application/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Application/Delete/5
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
