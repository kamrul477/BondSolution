using Kendo.Mvc.Extensions;
using Mvc.BondApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.WebPages;


namespace Mvc.BondApp.Controllers
{
    public class ApplicationController : Controller
    {

        private BondModel _context = new BondModel();
        private int scriptSerialNo;

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

        public JsonResult GetBondScriptDenoInfo(string bondTypeIndex)
        {
            var scriptDenoInfo = _context.SCRIPTDENOINFOes.Where(p => p.BONDCODE.Equals(bondTypeIndex));
            return Json(scriptDenoInfo.Select(p => new { BONDVALUE = p.BONDVALUE, BONDPREFIX = p.BONDPREFIX }), JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetBondScriptPrefixInfo(int denominationValue, string bondTypeIndex)
        {
            var scriptDenoInfo = _context.SCRIPTDENOINFOes.Where(p => p.BONDCODE.Equals(bondTypeIndex));
            var scriptPrefix = scriptDenoInfo.Where(x => x.BONDVALUE.Equals(denominationValue));
            return Json(scriptPrefix.Select(p => new { BONDPREFIX = p.BONDPREFIX }), JsonRequestBehavior.AllowGet);
        }

        //BOND SCRIPT GENERATION CALL


        public JsonResult GetBondScriptInfo(string prefix, int bondStartNo, int totalNoOfScriptForThisNominee,
            string relation, string nomineeName, int totalNoOfScript, int denomination, int rowCount)
        {
            List<NewApplicationBondScriptViewModel> model = new List<NewApplicationBondScriptViewModel>();
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
                        MaturityDate = DateTime.Now

                    });
                    bondStartNo++;

                }
            }

            return Json(model, JsonRequestBehavior.AllowGet);
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
        public ActionResult Create(FormCollection application)
        {
            try
            {
                BONDAPPLICATION _bondapplication = new BONDAPPLICATION()
                {
                    BONDCODE = application[1],
                    BONDSCN = application[2],//bond applicaiton no===SHOULD BE USED IN MULTIPLE PLACE
                    FILENO = application[3].AsInt(),
                    SCNDATE = application[4].AsDateTime(),
                    REINVDATE = application[5].AsDateTime(),
                    RESPONDDATE = application[6].AsDateTime(),
                    FBRCODE = application[7],//issueing branch
                    TOTALSCRIPT = (short?)application[8].AsInt(),//total script
                    BUYFNAME = application[9],//buyer first name
                    BUYMNAME = application[10],//buyier middle name
                    BUYLNAME = application[11],//buyer lastname
                    DOB = application[12].AsDateTime(),//buyer date of birth
                    SEX = application[13],//sex
                    DESIG = application[14],//designation
                    COMNAME = application[15],//organisation
                    COMADDR = application[16],//company address
                    ABOARDADDR = application[17],//foreign address
                    CNTYCODE = application[18],//country code
                    LOCALADDR = application[19],//local address
                    LOCALDIST = application[20],//district code
                    LOCALTHANA = application[21],//thana
                    PASSPORTNO = application[22],//passport no
                    ISSUEPLACE = application[23], //passport issue place
                    PASSISSUEDATE = application[24].AsDateTime(),//passport issue date
                    PAYMODE = application[25],//payment mode
                    FCACNO = application[26],//fc account no
                    FCBRCODE = application[27],//fc ac branch
                    CURRCODE = application[28],//currency code
                    VALUEDATE = application[29].AsDateTime(),//value date
                    EXRATE = application[30].AsDecimal(),//currency rate
                    AMOUNTFC = application[31].AsDecimal(),//amount in fc
                    AMOUNTCR = application[32].AsDecimal(),// amount for credit
                    FDDNO = application[33],//demand draft
                    EXBANKCODE = application[34],//exbankcode or bank
                    REMARKS = application[35],// remarks
                    //===================================BENEFICIARY======================================
                    //===================================OTHERS INFO======================================
                    FNAME = application[36],//others fathersname
                    MNAME = application[37],//others mothersname
                };
                //===============================BOND HOLDERS INFO========================================
                BENEFICIARY _beneficiary = new BENEFICIARY()
                {
                    BONDSCN = application[2],//bond applicaiton no
                    BENNAME = application[38],//beneficiary name
                    BENFNAME = application[39], //beneficiary fathers name
                    BENMNAME = application[40],//beneficiary mothers name
                    BENDOB = application[42].AsDateTime(),//beneficiary dateofbirth
                    BENADDR = application[41],//beneficiary address
                };
                //==========================BOND SCRIPT======================================================



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
