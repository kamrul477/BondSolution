using Mvc.BondApp;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;


namespace templateMvc.Controllers
{

    public class BranchInformationController : Controller
    {
        BondModel _context = new BondModel();

        // GET: BankInformation
        public ActionResult BankInfo()
        {
            var bankInfo = _context.BANKINFOes.ToList();
            //var bankInfo = new BankInfoListViewModel()
            //{
            //   BankinfosCollection = _context.BANKINFOes.ToList(),
            //};

            return View(bankInfo);
        }

        // GET: BranchInformation
        [HttpGet]
        public ActionResult BranchInfo(string bankCode)
        {
            //ICollection<BRANCHINFO> branchInfo = _context.BRANCHINFOes.Where(b => b.BANKCODE.Equals(bankCode.ToString(), 
            //    StringComparison.Ordinal)).ToList();
            ICollection<BRANCHINFO> branchinfos = _context.BRANCHINFOes.ToList();
            //BANKINFO bank = _context.BANKINFOes.Find(bankCode);
            List<BRANCHINFO> branchInfo = branchinfos.Where(item => item.BANKCODE == bankCode.ToString()).ToList();

            // var _bankId = (char)bankId;
            if (!Request.IsAjaxRequest())
            {
                return View("_branchInfo", branchInfo);
            }

            return View("BankInfo");
        }

        // GET: BranchInformation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BranchInformation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BranchInformation/Create
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

        // GET: BranchInformation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BranchInformation/Edit/5
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

        // GET: BranchInformation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BranchInformation/Delete/5
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
