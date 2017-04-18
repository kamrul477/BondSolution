//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Helpers;
//using System.Web.Mvc;
//using Glimpse.AspNet.Tab;
//using Mvc.BondApp.ViewModels;
//using System.Data.Entity;
//using System.Net;

//namespace Mvc.BondApp.Supporting_Class
//{
//    public class UtilityMethods
//    {

//        BondModel db = new BondModel();

//        #region HELPER AJAX CODE




//        public List<DISTINFO> GetDistrict()
//        {
//            List<DISTINFO> district = db.DISTINFOes;
//            return district;


//        }

//        public List<THANAINFO> GetThana(string district)
//        {
//            var thanas = db.THANAINFOes.AsQueryable();

//            if (district != null)
//            {
//                thanas = thanas.Where(p => p.DISTCODE == district);
//            }
//            List<THANAINFO> thanasProjected = thanas.Select(p => new {ThanaCode = p.THANACODE, ThanaName = p.THANADESC});
//            return thanasProjected;
//        }

//        public JsonResult GetPaymentMode()
//        {
//            var paymentMode = db.BONDPAYMODEs.AsQueryable();
//            return Json(paymentMode.Select(p => new { PAYCODE = p.PAYCODE, PAYDESC = p.PAYDESC }), JsonRequestBehavior.AllowGet);
//        }

//        public JsonResult GetIssuingBranch()
//        {
//            var foreignBranch = db.BRANCHINFOes.ToList().Where(p => p.BRCODE.Contains("15F"));
//            return Json(foreignBranch.Select(p => new { BRCODE = p.BRCODE, BRNAME = p.BRNAME }), JsonRequestBehavior.AllowGet);
//            //SUBSTR(BRCODE, 1, 3) = '15F'
//        }

//        public JsonResult GetFcBranch()
//        {
//            var branches = db.BRANCHINFOes.ToList();
//            return Json(branches.Select(p => new { BRCODE = p.BRCODE, BRNAME = p.BRNAME }), JsonRequestBehavior.AllowGet);
//        }

//        public JsonResult GetCurrencyCode()
//        {
//            var currencyCode = db.CURRINFOes.ToList();
//            return Json(currencyCode.Select(p => new { CURRCODE = p.CURRCODE, CURRNAME = p.CURRNAME }), JsonRequestBehavior.AllowGet);
//        }

//        public JsonResult GetCurrencyRateOnSpecificDate(DateTime date, string currencyCode)
//        {
//            try
//            {
//                var rate = db.RATEINFOes.Find(date, currencyCode);
//                return Json(rate.RATEAMT, JsonRequestBehavior.AllowGet);
//            }
//            catch (Exception)
//            {

//                return Json(0.00, JsonRequestBehavior.AllowGet); ;
//            }

//        }


//        public JsonResult GetExchangeHouseInfo(string searchText)
//        {
//            var exchangeHouses = from m in db.EXHOUSE_INFO
//                                 where m.EXNAME.Contains(searchText.ToUpper())
//                                 select m;
//            return Json(exchangeHouses.Select(p => new { EXCODE = p.EXCODE, EXNAME = p.EXNAME }), JsonRequestBehavior.AllowGet);
//        }

//        public JsonResult GetBondScriptDenoInfo(string bondTypeIndex)
//        {
//            var scriptDenoInfo = db.SCRIPTDENOINFOes.Where(p => p.BONDCODE.Equals(bondTypeIndex));
//            return Json(scriptDenoInfo.Select(p => new { BONDVALUE = p.BONDVALUE, BONDPREFIX = p.BONDPREFIX }), JsonRequestBehavior.AllowGet);
//        }

//        public JsonResult ClearBlock()
//        {
//            const string message = "successfully cleared";
//            Session["appScript"] = null;
//            return Json(message, JsonRequestBehavior.AllowGet);

//        }


//        public JsonResult GetBondScriptPrefixInfo(int denominationValue, string bondTypeIndex)
//        {
//            var scriptDenoInfo = db.SCRIPTDENOINFOes.Where(p => p.BONDCODE.Equals(bondTypeIndex));
//            var scriptPrefix = scriptDenoInfo.Where(x => x.BONDVALUE.Equals(denominationValue));
//            return Json(scriptPrefix.Select(p => new { BONDPREFIX = p.BONDPREFIX }), JsonRequestBehavior.AllowGet);
//        }

   

//        #endregion
//    }
//}