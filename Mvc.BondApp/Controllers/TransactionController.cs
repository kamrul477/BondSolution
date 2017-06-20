using Mvc.BondApp.ViewModels;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web.Mvc;

namespace Mvc.BondApp.Controllers
{
    public class TransactionController : Controller
    {
        BondModel _context = new BondModel();
        BondFunctions _functions = new BondFunctions();


        #region INSTALLMENT PAYMENT AREA
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ApplicationSearch(string applicationNo = "531/2017")
        {
            var memoryDb = new MemoryDb();
            var application = _context.BONDAPPLICATIONs.SingleOrDefault(a => a.BONDSCN.Equals(applicationNo));
            var connection = DatabaseConnection();
            var model = new InstallmentPaymentViewModel() { Bondapplication = application };

            SqlQueryFromOracleFunction(applicationNo, connection, application);

            CreateMemoryCollection(application);

            ViewBagDataSending();

            PaymentModeGraterThanFour();


            return View(model);
        }

        private void ViewBagDataSending()
        {
            ViewBag.Voucher = _context.VOUCHERINFOes.ToList();
        }

        private void PaymentModeGraterThanFour()
        {
            var object1 = _context.BONDPAYMODEs.Single(o => o.PAYCODE == "5");
            var object2 = _context.BONDPAYMODEs.Single(o => o.PAYCODE == "6");
            var object3 = _context.BONDPAYMODEs.Single(o => o.PAYCODE == "7");
            var object4 = _context.BONDPAYMODEs.Single(o => o.PAYCODE == "8");
            var list = new List<BONDPAYMODE> { object1, object2, object3, object4 };
            ViewBag.PaymentMode = list;
        }

        private void SqlQueryFromOracleFunction(string applicationNo, OracleConnection connection, BONDAPPLICATION application)
        {
            const string totalBondProcedureSql = "select GET_TOTALBOND(:PBONDSCN) as VCOUNT FROM DUAL";
            ViewBag.TotalBondInstallmentTransaction = GetTotalBondFromProcedure(applicationNo, connection,
                OracleCommand(totalBondProcedureSql, connection));

            const string totalAmountSql = "select GET_TOTALAMT(:PBONDSCN,:CTYPE) as VNUMBERF FROM DUAL";
            ViewBag.TotalAmountTransaction = _functions.GET_TOTALAMT(applicationNo, "L", connection,
                OracleCommand(totalAmountSql, connection));

            const string payNoOfBondSql = "select GET_NOPAYABLEBOND(:PBONDSCN) as VDESC FROM DUAL";
            ViewBag.payNoOfBondTransaction = _functions.GET_NOPAYABLEBOND(applicationNo, connection,
                OracleCommand(payNoOfBondSql, connection));

            const string getPaidUpInterestSql = "select GET_PAIDUPINT(:PBONDSCN) as VNUMBER FROM DUAL";
            ViewBag.PaidUpInterestTransaction = _functions.GET_PAIDUPINT(applicationNo, connection,
                OracleCommand(getPaidUpInterestSql, connection));

            const string accNoSql = "select GET_DRACNO(:PBONDCODE) as VDRACCNO FROM DUAL";
            ViewBag.AccNoTransaction = _functions.GET_DRACNO(application.BONDCODE, connection,
                OracleCommand(accNoSql, connection));

            const string currencySql = "select GET_APPCURR(:PBONDCODE,:PC) as VCURRCODE FROM DUAL";
            ViewBag.CurrencyName = _functions.GET_APPCURR(application.BONDCODE, 'C', connection,
                OracleCommand(currencySql, connection));

            const string lastTransactionDate = "select GET_MAXTRANDATE(:PBONDSCN) as VDATE FROM DUAL";
            ViewBag.LastTransactionDate = _functions.GET_MAXTRANDATE(applicationNo, connection,
                OracleCommand(lastTransactionDate, connection));

            const string currencyCode = "select GET_INTCURR(:PBONDCODE,:PC) as VCURRCODE FROM DUAL";
            ViewBag.CurrencyCode = _functions.GET_INTCURR(application.BONDCODE, 'C', connection,
                OracleCommand(currencyCode, connection));


            const string bondValueSql = "select GET_TOTAL_BONDVALUE(:Ppasport) as vmat FROM DUAL";
            ViewBag.TotalBondValue = _functions.GET_TOTAL_BONDVALUE(application.PASSPORTNO, connection,
                OracleCommand(bondValueSql, connection));
        }


        private void CreateMemoryCollection(BONDAPPLICATION application/*, MemoryDb memoryDb*/)
        {
            var collection = application.APPSCRIPTs.Where(o => o.BONDSTATUS.Equals("02"))
                .Select(o => new GridPayment()
            {
                BONDNO = o.BONDNO,
                BONDSL = o.BONDSL.ToString(),
                BONDPREFIX = o.BONDPREFIX,
                BONDVALUE = o.BONDVALUE.ToString()
            });

            if (!(Session["bondToGrid"] is List<GridPayment>))
            {
                //create a session to hold the data
                Session["bondToGrid"] = collection;
            }


            //To get what you have stored to a session

            //var products = Session["products"] as List<Product>;

            //to clear the session value

            //Session["products"] = null;

            //(Model.Bondapplication.APPSCRIPTs.Where(o => o.BONDSTATUS.Equals("02"))
            //memoryDb.CreateOrGetLiteDatabase();
            //memoryDb.CreateOrGetCollection<APPSCRIPT>("AppScript");
            //foreach (var item in collection)
            //{
            //    memoryDb.InsertNewItemToCollection(item, "AppScript");
            //}
            //LiteCollection<APPSCRIPT> scripts = memoryDb.CreateOrGetCollection<APPSCRIPT>("AppScript");




        }



        #endregion

        #region HELPER AJAX AREA

        public JsonResult GetBankList(string q)
        {
            var search = q.ToUpper();
            var _bankList = _context.BANKINFOes.ToList();
            var bankList = _bankList.Where(o => o.BANKNAME.Contains(search)).OrderBy(o => o.BANKNAME);
            return Json(bankList.Select(p => new { id = p.BANKCODE, text = p.BANKNAME }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBankName(string q)
        {
            var bankName = _context.BANKINFOes.ToList().Where(o => o.BANKCODE == "15");
            return Json(bankName.Select(p => new { bankCode = p.BANKCODE, bankName = p.BANKNAME }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetExchangeRate(DateTime tranDate, string currCode)
        {
            var connection = DatabaseConnection();
            const string rateSql = "select GET_EXRATE(:PRDATE, :PCURRCODE) as output FROM DUAL";
            var exRate = _functions.GET_EXRATE(tranDate, currCode, connection,
                OracleCommand(rateSql, connection));

            return Json(exRate, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBondSpecific(string serialNo, string applicationNo)
        {
            var application = _context.BONDAPPLICATIONs.SingleOrDefault(o => o.BONDSCN.Equals(applicationNo));

            var bond = application.APPSCRIPTs.SingleOrDefault(o => (o.BONDSL.ToString() == serialNo) && (o.BONDSTATUS == "02"));


            return Json(new { prefix = bond.BONDPREFIX, bondNo = bond.BONDNO,
                   bondValue = bond.BONDVALUE, bondCode = bond.BONDCODE, lastInstallmentNo= bond.INSTALLNO }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBranchList(string q, string bankCode)
        {
            var search = q.ToUpper();
            var _branchList = _context.BRANCHINFOes.ToList().Where(o => o.BANKCODE == bankCode);
            var branchList = _branchList.Where(o => o.BRNAME.Contains(search)).OrderBy(o => o.BRNAME);
            return Json(branchList.Select(p => new { id = p.BRCODE, text = p.BRNAME }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetInstallmentNoList(string q, DateTime trnDate, DateTime scanDate, string bondScn)
        {
            var connection = DatabaseConnection();
            List<int> vminus = new List<int>();
            decimal vtrDuration;
            //===============SELECT MINIMUM INSTALL NO===============

            var appScripts =
                _context.APPSCRIPTs.Where(o => (o.BONDSCN == bondScn) && (o.BONDSTATUS == "02"));
            if (appScripts != null)
            {
                foreach (var item in appScripts)
                {
                    if (item.INSTALLNO != null)
                        vminus.Add((int)item.INSTALLNO);
                    else
                        vminus.Add(0);
                }
                // vminus = (int)singleOrDefault.INSTALLNO;
            }
            //==================SELECT TOTAL BOND AND DURATION IN MONTH=================
            var application = _context.BONDAPPLICATIONs.SingleOrDefault(a => a.BONDSCN.Equals(bondScn));
            var vbDuration = _context.BONDINFOes.SingleOrDefault(o => o.BONDCODE.Equals(application.BONDCODE)).DURATION * 12;
            var vIntDuration = _context.BONDINFOes.SingleOrDefault(o => o.BONDCODE.Equals(application.BONDCODE)).INSTDURATION;

            const string dateDifference = "select SBDateDiff(:GDate1, :GDate2, :Qry) as pdate FROM DUAL";
            var _dateDifference = _functions.SBDateDiff(trnDate, scanDate, "MONTH", connection, OracleCommand(dateDifference, connection));


            if (_dateDifference > vbDuration)
            {
                vtrDuration = (decimal)vbDuration;
            }
            else
            {
                vtrDuration = _dateDifference;
            }

            List<object> installNo = new List<object>();
            for (int i = (vminus.Min() + 1); i <= Math.Floor((decimal)(vtrDuration / vIntDuration)); i++)
            {
                installNo.Add(i);
            }

            //const string isDayEndSql = "select IS_DAYEND(:PDATE) as X FROM DUAL";
            //var _isDayEndSql = functions.IS_DAYEND(connection, OracleCommand(isDayEndSql, connection));

            return Json(installNo.Select(p => new { id = p, text = p }), JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region STORED PROCEDURE AREA

        public OracleConnection DatabaseConnection()
        {
            //var connection = new OracleConnection(_context.Database.Connection.ConnectionString);
            var connection = new OracleConnection(ConfigurationManager.ConnectionStrings["BondModelDb"].ConnectionString);
            return connection;
        }

        public OracleCommand OracleCommand(string commandText, OracleConnection connection)
        {
            var oracleCommand = new OracleCommand(commandText, connection);
            return oracleCommand;
        }
        private int GetTotalBondFromProcedure(string applicationNo, OracleConnection _connection, OracleCommand _oracleCommand)
        {
            int totalBond = 0;
            var connection = _connection;
            var oracleCommand = _oracleCommand;
            oracleCommand.CommandType = CommandType.Text;
            oracleCommand.Parameters.Add("PBONDSCN", OracleDbType.Varchar2).Value = applicationNo;
            //oracleCommand.Parameters.Add("VCOUNT", OracleDbType.Int32).Direction = ParameterDirection.ReturnValue;
            try
            {
                connection.Open();
                OracleDataReader reader = oracleCommand.ExecuteReader();
                while (reader.Read())
                {
                    totalBond = Convert.ToInt32(reader["VCOUNT"]);
                }
            }
            catch (Exception es)
            {
                // ignored
            }
            finally
            {
                connection.Close();
            }
            return totalBond;
        }



        // ViewBag.TotalBondInstallment = oracleCommand.Parameters["VCOUNT"].Value;
        //Convert.ToString(oracleCommand.Parameters["VCOUNT"].Value);


        //var totalBond = OracleCommand("bond.GET_TOTALBOND");
        //totalBond.CommandType = CommandType.StoredProcedure;
        //totalBond.Parameters.Add("PBONDSCN", OracleDbType.NVarchar2).Value = applicationNo;
        //totalBond.Parameters.Add("VCOUNT", OracleDbType.Int32).Direction = ParameterDirection.ReturnValue;
        ////totalBond.Parameters["VCOUNT"].Direction = ParameterDirection.ReturnValue;

        //totalBond.Connection.Open();
        //totalBond.ExecuteNonQuery();
        //ViewBag.TotalBondInstallment = Convert.ToString(totalBond.Parameters["VCOUNT"].Value);
        //totalBond.Connection.Close();

        #endregion

    }
}