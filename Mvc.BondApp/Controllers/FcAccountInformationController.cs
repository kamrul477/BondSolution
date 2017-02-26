using Mvc.BondApp;
using System.Web.Mvc;

namespace templateMvc.Controllers
{
    public class FcAccountInformationController : Controller
    {
        BondModel _context = new BondModel();
        // GET: FcAccountInformation
        public ActionResult Index()
        {
            return View();
        }

        // GET: FcAccountInformation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FcAccountInformation/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: FcAccountInformation/Create
        [HttpPost]
        public ActionResult Create(FcAccountInfoViewModel add)
        {
            try
            {
                FCACCOUNT_INFO info = new FCACCOUNT_INFO
                {
                    FCACADD = add.FCACADD,
                    FCACNAME = add.FCACNAME,
                    FCACCOUNTNO = add.AccountType + " " + add.FCACCOUNTNO,
                    FCACPHONE = add.FCACPHONE
                };

                // TODO: Add insert logic here
                _context.FCACCOUNT_INFO.Add(info);
                _context.SaveChanges();

                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
        }

        // GET: FcAccountInformation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FcAccountInformation/Edit/5
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

        // GET: FcAccountInformation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FcAccountInformation/Delete/5
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
