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

        #region INSTALLMENT PAYMENT AREA
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ApplicationSearch(string applicationNo = "531/2017")
        {

            BondFunctions functions = new BondFunctions();
            var application = _context.BONDAPPLICATIONs.SingleOrDefault(a => a.BONDSCN.Equals(applicationNo));


            var model = new InstallmentPaymentViewModel()
            {
                Bondapplication = application
            };

            var connection = DatabaseConnection();

            const string totalBondProcedureSql = "select GET_TOTALBOND(:PBONDSCN) as VCOUNT FROM DUAL";
            ViewBag.TotalBondInstallmentTransaction = GetTotalBondFromProcedure(applicationNo, connection,
                OracleCommand(totalBondProcedureSql, connection));

            const string totalAmountSql = "select GET_TOTALAMT(:PBONDSCN,:CTYPE) as VNUMBERF FROM DUAL";
            ViewBag.TotalAmountTransaction = functions.GET_TOTALAMT(applicationNo, "L", connection,
                OracleCommand(totalAmountSql, connection));

            const string payNoOfBondSql = "select GET_NOPAYABLEBOND(:PBONDSCN) as VDESC FROM DUAL";
            ViewBag.payNoOfBondTransaction = functions.GET_NOPAYABLEBOND(applicationNo, connection,
                OracleCommand(payNoOfBondSql, connection));

            const string getPaidUpInterestSql = "select GET_PAIDUPINT(:PBONDSCN) as VNUMBER FROM DUAL";
            ViewBag.PaidUpInterestTransaction = functions.GET_PAIDUPINT(applicationNo, connection,
                OracleCommand(getPaidUpInterestSql, connection));

            const string accNoSql = "select GET_DRACNO(:PBONDCODE) as VDRACCNO FROM DUAL";
            ViewBag.AccNoTransaction = functions.GET_DRACNO(application.BONDCODE, connection,
                OracleCommand(accNoSql, connection));

            const string currencySql = "select GET_APPCURR(:PBONDCODE,:PC) as VCURRCODE FROM DUAL";
            ViewBag.CurrencyName = functions.GET_APPCURR(application.BONDCODE, 'C', connection,
                OracleCommand(currencySql, connection));

            const string lastTransactionDate = "select GET_MAXTRANDATE(:PBONDSCN) as VDATE FROM DUAL";
            ViewBag.LastTransactionDate = functions.GET_MAXTRANDATE(applicationNo, connection,
                OracleCommand(lastTransactionDate, connection));

            const string currencyCode = "select GET_INTCURR(:PBONDSCN,:PC) as VCURRCODE FROM DUAL";
            ViewBag.CurrencyCode = functions.GET_INTCURR(applicationNo, 'C', connection,
                OracleCommand(currencyCode, connection));


            const string bondValueSql = "select GET_TOTAL_BONDVALUE(:Ppasport) as vmat FROM DUAL";
            ViewBag.TotalBondValue = functions.GET_TOTAL_BONDVALUE(application.PASSPORTNO, connection,
                OracleCommand(bondValueSql, connection));

            var object1 = _context.BONDPAYMODEs.Single(o => o.PAYCODE == "5");
            var object2 = _context.BONDPAYMODEs.Single(o => o.PAYCODE == "6");
            var object3 = _context.BONDPAYMODEs.Single(o => o.PAYCODE == "7");
            var object4 = _context.BONDPAYMODEs.Single(o => o.PAYCODE == "8");
            var list = new List<BONDPAYMODE> { object1, object2, object3, object4 };
            ViewBag.PaymentMode = list;






            return View(model);
        }


        #endregion

        #region HELPER AJAX AREA

        public JsonResult GetBankList(string q)
        {
            var search = q.ToUpper();
            var _bankList = _context.BANKINFOes.ToList();
            var bankList = _bankList.Where(o => o.BANKNAME.Contains(search)).OrderBy(o => o.BANKNAME);
            return Json(bankList.Select(p => new { bankCode = p.BANKCODE, bankName = p.BANKNAME }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBankName(string q)
        {
            var bankName = _context.BANKINFOes.Where(o => o.BANKCODE == "15");
            return Json(bankName.Select(p => new { bankCode = p.BANKCODE, bankName = p.BANKNAME }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetBranchList(string bankCode)
        {
            var branchList = _context.BRANCHINFOes.Where(o => o.BANKCODE == bankCode);
            return Json(branchList.Select(p => new { branchCode = p.BRCODE, branchName = p.BRNAME }), JsonRequestBehavior.AllowGet);
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