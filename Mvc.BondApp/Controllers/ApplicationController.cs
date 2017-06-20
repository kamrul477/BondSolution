//using Kendo.Mvc.Extensions;
using Mvc.BondApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Mvc.BondApp.Controllers
{
    public class ApplicationController : Controller
    {
        private BondModel db = new BondModel();
        private int scriptSerialNo;

        // GET: Application
        public ActionResult Index()
        {
            var bONDAPPLICATIONs = db.BONDAPPLICATIONs
                .Include(b => b.BENEFICIARY).Include(b => b.BONDPAYMODE)
                .Include(b => b.BRANCHINFO).Include(b => b.COUNTRYINFO)
                .Include(b => b.DISTINFO).Include(b => b.EXHOUSE_INFO)
                .Include(b => b.STATUSINFO).Include(b => b.THANAINFO);
            return View(bONDAPPLICATIONs.ToList());
        }
        // GET: Application
        public ActionResult Succesfull()
        {

            return View();
        }

        // GET: Application/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BONDAPPLICATION bONDAPPLICATION = db.BONDAPPLICATIONs.Find(id);
            if (bONDAPPLICATION == null)
            {
                return HttpNotFound();
            }
            return View(bONDAPPLICATION);
        }

        #region HELPER AJAX CODE


        //public JsonResult GetBondInfo()
        //{
        //    var bondType = from bond in db.BONDINFOes.ToList()
        //                   select new BondTypeViewModel()
        //                   {
        //                       BONDCODE = bond.BONDCODE,
        //                       BONDNAME = bond.BONDNAME

        //                   };
        //    return Json(bondType.ToList(), JsonRequestBehavior.AllowGet);
        //    //DataSourceRequest request = new DataSourceRequest();
        //    //return Json(bondType.ToDataSourceResult(request));
        //}


        public JsonResult GetCascadeDistrict()
        {
            var district = db.DISTINFOes;

            return Json(district.Select(c => new { CategoryId = c.DISTCODE, CategoryName = c.DISTDESC }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCascadeThana(string district)
        {
            var thanas = db.THANAINFOes.AsQueryable();


            if (district != null)
            {
                thanas = thanas.Where(p => p.DISTCODE == district);
            }

            return Json(thanas.Select(p => new { ThanaCode = p.THANACODE, ThanaName = p.THANADESC }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPaymentMode()
        {
            var paymentMode = db.BONDPAYMODEs.AsQueryable();
            return Json(paymentMode.Select(p => new { PAYCODE = p.PAYCODE, PAYDESC = p.PAYDESC }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetIssuingBranch()
        {
            var foreignBranch = db.BRANCHINFOes.ToList().Where(p => p.BRCODE.Contains("15F"));
            return Json(foreignBranch.Select(p => new { BRCODE = p.BRCODE, BRNAME = p.BRNAME }), JsonRequestBehavior.AllowGet);
            //SUBSTR(BRCODE, 1, 3) = '15F'
        }

        public JsonResult GetFcBranch()
        {
            var branches = db.BRANCHINFOes.ToList();
            return Json(branches.Select(p => new { BRCODE = p.BRCODE, BRNAME = p.BRNAME }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCurrencyCode()
        {
            var currencyCode = db.CURRINFOes.ToList();
            return Json(currencyCode.Select(p => new { CURRCODE = p.CURRCODE, CURRNAME = p.CURRNAME }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCurrencyRateOnSpecificDate(DateTime date, string currencyCode)
        {
            try
            {
                var rate = db.RATEINFOes.Find(date, currencyCode);
                return Json(rate.RATEAMT, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(0.00, JsonRequestBehavior.AllowGet); ;
            }

        }


        public JsonResult GetExchangeHouseInfo(string searchText)
        {
            var exchangeHouses = from m in db.EXHOUSE_INFO
                                 where m.EXNAME.Contains(searchText.ToUpper())
                                 select m;
            return Json(exchangeHouses.Select(p => new { EXCODE = p.EXCODE, EXNAME = p.EXNAME }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBondScriptDenoInfo(string bondTypeIndex)
        {
            var scriptDenoInfo = db.SCRIPTDENOINFOes.Where(p => p.BONDCODE.Equals(bondTypeIndex));
            return Json(scriptDenoInfo.Select(p => new { BONDVALUE = p.BONDVALUE, BONDPREFIX = p.BONDPREFIX }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ClearBlock()
        {
            const string message = "successfully cleared";
            Session["appScript"] = null;
            return Json(message, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GetBondScriptPrefixInfo(int denominationValue, string bondTypeIndex)
        {
            var scriptDenoInfo = db.SCRIPTDENOINFOes.Where(p => p.BONDCODE.Equals(bondTypeIndex));
            var scriptPrefix = scriptDenoInfo.Where(x => x.BONDVALUE.Equals(denominationValue));
            return Json(scriptPrefix.Select(p => new { BONDPREFIX = p.BONDPREFIX }), JsonRequestBehavior.AllowGet);
        }

        //BOND SCRIPT GENERATION CALL
        public JsonResult GetBondScriptInfo(string prefix, int bondStartNo, int totalNoOfScriptForThisNominee,
            string relation, string nomineeName, int totalNoOfScript, int denomination, int rowCount, string bondCode, string bondScn)
        {
            List<NewApplicationBondScriptViewModel> model = new List<NewApplicationBondScriptViewModel>();
            List<APPSCRIPT> _appscripts = new List<APPSCRIPT>();
            var _bondinfo = db.BONDINFOes.Find(bondCode);
            if (rowCount <= totalNoOfScript)
            {
                scriptSerialNo = rowCount;

                for (var i = 0; i < totalNoOfScriptForThisNominee; i++)
                {
                    ++scriptSerialNo;
                    model.Add(new NewApplicationBondScriptViewModel()
                    {
                        SerialNo = scriptSerialNo,
                        BondNo = bondStartNo,
                        NomineeName = nomineeName,
                        Prefix = prefix,
                        Relation = relation,
                        Value = denomination,
                        AmountPaid = 0,
                        MaturityDate = DateTime.Now.AddYears((int)_bondinfo.DURATION)

                    });
                    _appscripts.Add(new APPSCRIPT()
                    {
                        BONDSL = (short)scriptSerialNo,
                        BONDCODE = bondCode.ToString(),
                        BONDSCN = bondScn.ToString(),
                        BONDNO = bondStartNo.ToString(),
                        BONDPREFIX = prefix,
                        BONDVALUE = denomination,
                        NOMNAME = nomineeName,
                        MATURITYDATE = DateTime.Now.AddYears((int)_bondinfo.DURATION)
                        //BONDSTATUS = bondStatus
                    });
                    bondStartNo++;
                }
            }
            Session["appScript"] = _appscripts;
            return Json(model, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region CREATE OPERATION AREA
        // GET: Application/Create
        public ActionResult Create()
        {
            //BOND APP NO
            ViewBag.BONDSCN = new SelectList(db.BENEFICIARies, "BONDSCN", "BENNAME");
            //PAYMENT MODE
            ViewBag.PAYMODE = db.BONDPAYMODEs.ToList(); //new SelectList(db.BONDPAYMODEs, "PAYCODE", "PAYDESC");
            ViewBag.BRCODE = db.BRANCHINFOes.ToList().OrderBy(o => o.BRNAME);//new SelectList(db.BRANCHINFOes, "BRCODE", "BRNAME");
            ViewBag.CNTYCODE = db.COUNTRYINFOes.ToList().OrderBy(o => o.CNTYNAME); ; //new SelectList(db.COUNTRYINFOes, "CNTYCODE", "CNTYNAME");
            ViewBag.DISTRICT = db.DISTINFOes.ToList().OrderBy(o => o.DISTDESC); //new SelectList(db.DISTINFOes, "DISTCODE", "DISTDESC");
            ViewBag.EXBANKCODE = db.EXHOUSE_INFO.ToList().OrderBy(o => o.EXNAME);//new SelectList(db.EXHOUSE_INFO, "EXCODE", "EXNAME");
            ViewBag.STATUSCODE = db.STATUSINFOes.ToList(); //new SelectList(db.STATUSINFOes, "STATUSCODE", "STATUSDESC");
            ViewBag.LOCALTHANA = db.THANAINFOes.ToList().OrderBy(o => o.THANADESC);//new SelectList(db.THANAINFOes, "THANACODE", "THANADESC");
            //=========ADDEDBYME========
            ViewBag.CURRCODE = db.CURRINFOes.ToList();//new SelectList(db.CURRINFOes, "CURRCODE", "CURRNAME");
            ViewBag.Denomination = db.SCRIPTDENOINFOes.ToList();//new SelectList(db.SCRIPTDENOINFOes, "BONDCODE", "BONDVALUE");
            ViewBag.BONDCODE = db.BONDINFOes.ToList();//new SelectList(db.BONDINFOes, "BONDCODE", "BONDNAME");
            ViewBag.FBRCODE = db.BRANCHINFOes.ToList().Where(p => p.BRCODE.Contains("15F")).OrderBy(o => o.BRNAME);
            ViewBag.FCBRCODE = db.BRANCHINFOes.Where(p => p.BANKCODE.Equals("15")).OrderBy(o => o.BRNAME);
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BONDAPPLICATION bONDAPPLICATION)

        {
            var appScripts = Session["appScript"] as List<APPSCRIPT>;
            db.APPSCRIPTs.AddRange(appScripts);
            db.BONDAPPLICATIONs.Add(bONDAPPLICATION);

            db.SaveChanges();
            Session["appScript"] = null;
            return RedirectToAction("Succesfull");



        }
        #endregion

        #region EDIT OPERATION AREA
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var bondapplication = db.BONDAPPLICATIONs.Find(id);
            var appscripts = db.APPSCRIPTs.Where(b => b.BONDSCN.Equals(id)).OrderBy(b => b.BONDSL).ToList();
            bondapplication.APPSCRIPTs = appscripts;


            ViewBag.BONDSCN = new SelectList(db.BENEFICIARies, "BONDSCN", "BENNAME");
            ViewBag.PAYMODE = db.BONDPAYMODEs.ToList();
            ViewBag.BRCODE = db.BRANCHINFOes.ToList().OrderBy(o => o.BRNAME);
            ViewBag.CNTYCODE = db.COUNTRYINFOes.ToList().OrderBy(o => o.CNTYNAME);
            ViewBag.DISTRICT = db.DISTINFOes.ToList().OrderBy(o => o.DISTDESC);
            ViewBag.EXBANKCODE = db.EXHOUSE_INFO.ToList().OrderBy(o => o.EXNAME);
            ViewBag.STATUSCODE = db.STATUSINFOes.ToList();
            ViewBag.LOCALTHANA = db.THANAINFOes.ToList().OrderBy(o => o.THANADESC);
            //=========ADDED BY ME===============================================================
            ViewBag.CURRCODE = db.CURRINFOes.ToList();
            ViewBag.Denomination = db.SCRIPTDENOINFOes.ToList();
            ViewBag.BONDCODE = db.BONDINFOes.ToList();
            ViewBag.FBRCODE = db.BRANCHINFOes.ToList().Where(p => p.BRCODE.Contains("15F")).OrderBy(o => o.BRNAME);
            ViewBag.FCBRCODE = db.BRANCHINFOes.Where(p => p.BANKCODE.Equals("15")).OrderBy(o => o.BRNAME);
            return View(bondapplication);
        }

        // POST: Application/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSave(BONDAPPLICATION bONDAPPLICATION)
        {
            if (ModelState.IsValid)
            {
                /*var appScripts;*/ /*= Session["appScript"] != null ? Session["appScript"] as List<APPSCRIPT> : db.APPSCRIPTs.Where(b => b.BONDSCN.Equals(bONDAPPLICATION.BONDSCN)) as List<APPSCRIPT>;*/
                List<APPSCRIPT> appscripts = new List<APPSCRIPT>();

                if (Session["appScript"] != null)
                {
                    appscripts = Session["appScript"] as List<APPSCRIPT>;
                }
                else
                {
                    // appscripts = db.APPSCRIPTs.Where(b => b.BONDSCN == bONDAPPLICATION.BONDSCN).ToList();
                }
                //db.APPSCRIPTs.AddRange(appscripts);
                db.BONDAPPLICATIONs.Add(bONDAPPLICATION);
                db.Entry(bONDAPPLICATION.BENEFICIARY).State = EntityState.Modified;
                db.Entry(bONDAPPLICATION).State = EntityState.Modified;
                db.SaveChanges();
                Session["appScript"] = null;
            }

            return View();
        }

        public ActionResult EditSearch()
        {

            return View();
        }
        #endregion

        #region STATUS CHANGE AREA
        //EXECUTION TREE StatusChangePromped => ApplicationNoWiseSearchBox => ApplicationNoWise =>
        //EXECUTION TREE StatusChangePromped => BondNoWiseSearchBox => BondNoWise =>
        public ActionResult StatusChangePromped()
        {
            return View();
        }
        public PartialViewResult ApplicationNoWiseSearchBox()
        {
            return PartialView("_applicationNoWiseSearchBox");
        }
        public PartialViewResult ApplicationNoWise(string applicationNo)
        {
            var app = db.BONDAPPLICATIONs.Find(applicationNo);
            string[] index = { "02", "03", "06", "07", "09" };
            var list = index.Select(item => db.STATUSINFOes.Single(s => s.STATUSCODE.Equals(item))).ToList();

            ViewBag.Status = list;
            if (app == null)
            {
                return PartialView("_notFound");
            }
            return PartialView("_applicationNoWise", app);
        }

        [HttpPost]
        public ActionResult ApplicationNoWiseSave(BONDAPPLICATION model)
        {
            var application = db.BONDAPPLICATIONs.SingleOrDefault(o => o.BONDSCN == model.BONDSCN);
            if (application != null)
            {
                var singleOrDefault = db.STATUSINFOes.SingleOrDefault(o => o.STATUSCODE.Equals(model.STATUSCODE));
                if (singleOrDefault != null)
                    application.STATUSCODE = singleOrDefault.STATUSCODE;
            }
            db.Entry(application).State = EntityState.Modified;
            db.SaveChanges();
            return View("Successfull");
        }
        public PartialViewResult BondNoWise(string BondCode, string prefix, string bondNo)
        {
            var script = db.APPSCRIPTs.SingleOrDefault(o => o.BONDNO == bondNo);
            var application = db.BONDAPPLICATIONs.Find(script.BONDSCN);
            var model = new BondNoWiseViewModel()
            {
                BondType = db.BONDINFOes.Find(BondCode).BONDNAME,
                BondNo = bondNo,
                Prefix = prefix,
                BondHolder = application.BUYFNAME + " " + application.BUYMNAME + " " + application.BUYLNAME,
                ApplicationDate = application.SCNDATE,
                CurrentStatus = db.STATUSINFOes.Single(o => o.STATUSCODE == script.BONDSTATUS).STATUSDESC,
                AppNo = application.BONDSCN,
                LocalAddress = application.LOCALADDR,
                ForeignAddress = application.ABOARDADDR,
                DateOfBirth = application.DOB,
                PassportNo = application.PASSPORTNO,
                IssueDate = application.PASSISSUEDATE
            };
            ViewBag.BondNoWiseStatus = db.STATUSINFOes.Where(o => o.STATUSCODE != application.STATUSCODE).ToList();
            return PartialView("_bondNoWise", model);
        }
        public PartialViewResult BondNoWiseSearchBox()
        {
            ViewBag.BONDCODE = db.BONDINFOes.ToList();
            return PartialView("_bondNoWiseSearchBox");
        }

        public ActionResult BondNoWiseSave(BondNoWiseViewModel model)
        {
            var script = db.APPSCRIPTs.SingleOrDefault(s => s.BONDNO == model.BondNo);
            if (script != null) script.BONDSTATUS = model.ChangeStatus;
            db.Entry(script).State = EntityState.Modified;
            db.SaveChanges();
            return View("Successfull");
        }
        public JsonResult GetStatus(string appNo)
        {
            var application = db.BONDAPPLICATIONs.SingleOrDefault(o => o.BONDSCN.Equals(appNo)).STATUSCODE;
            var statusDes = db.STATUSINFOes.Single(o => o.STATUSCODE == application).STATUSDESC;
            return Json(statusDes, JsonRequestBehavior.AllowGet);

        }
        public JsonResult GetPlace(int issuePlace)
        {
            var place = db.DISTINFOes.SingleOrDefault(o=>o.DISTCODE == issuePlace.ToString()).DISTDESC;
            return Json(place, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPrefix(string bondCode)
        {
            var prefixes = db.SCRIPTDENOINFOes.Where(p => p.BONDCODE == bondCode);
            return Json(prefixes.Select(p => new { PrefixCode = p.BONDPREFIX, PrefixName = p.BONDPREFIX }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBondNo(string searchText, string bondCode, string prefix)
        {
            //var bonds = from item in db.APPSCRIPTs
            //    where item.BONDCODE == bondCode && item.BONDPREFIX == prefix && item.BONDNO == searchText
            //    select item;
            var firstSearch = db.APPSCRIPTs.Where(p => p.BONDCODE == bondCode).ToList()
                                           .Where(p => p.BONDPREFIX == prefix).ToList()
                                           .Where(p => p.BONDNO.StartsWith(searchText))
                                           .OrderBy(o => o.BONDNO);
            //var secondSort = firstSearch.Where(p => p.BONDPREFIX == prefix).ToList();
            //var thirdSort = secondSort.Where(p => p.BONDNO.StartsWith(searchText)).OrderBy(o=>o.BONDNO);

            return Json(firstSearch.Select(p => new { bond = p.BONDNO }), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region REPORTING AREA
        public ActionResult ReportPromped()
        {
            return View();
        }





        #endregion










        // GET: Application/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BONDAPPLICATION bONDAPPLICATION = db.BONDAPPLICATIONs.Find(id);
            if (bONDAPPLICATION == null)
            {
                return HttpNotFound();
            }
            return View(bONDAPPLICATION);
        }

        // POST: Application/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BONDAPPLICATION bONDAPPLICATION = db.BONDAPPLICATIONs.Find(id);
            db.BONDAPPLICATIONs.Remove(bONDAPPLICATION);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
