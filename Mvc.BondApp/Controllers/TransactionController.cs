using System;
using System.Data;
using System.Data.Entity;
using Mvc.BondApp.ViewModels;
using System.Linq;
using System.Web.Mvc;
using Oracle.ManagedDataAccess.Client;

namespace Mvc.BondApp.Controllers
{
    public class TransactionController : Controller
    {
        BondModel _context = new BondModel();

        #region INSTALLMENT PAYMENT AREA

        #endregion
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ApplicationSearch(string applicationNo)
        {
            var totalBond = new OracleCommand("GET_TOTALBOND");  
            totalBond.CommandType = CommandType.StoredProcedure;
            totalBond.Connection = OracleConnection();
            totalBond.Parameters.Add("PBONDSCN",OracleDbType.NVarchar2);
            totalBond.Parameters.Add("VCOUNT",OracleDbType.Int32,ParameterDirection.ReturnValue);
            //sqlCmd.Parameters.Add("v_BDATE", Convert.ToString(dts));
            //sqlCmd.Parameters.Add("v_CLEARINGTYPE", Convert.ToString(ClearingType));

            try
            {
                OracleConnection().Open();
                totalBond.ExecuteNonQuery();
                //var kiekis = Convert.ToString(cmd.Parameters["kiekis"].Value);
                ViewBag.TotalBondInstallment = Convert.ToString(totalBond.Parameters["VCOUNT"].Value);
                               
                OracleConnection().Close();
            }
            catch (Exception e)
            {
                // throw;
            }
            finally
            {
                OracleConnection().Close();
            }

            


            var application = _context.BONDAPPLICATIONs.SingleOrDefault(a => a.BONDSCN.Equals(applicationNo));
            var model = new InstallmentPaymentViewModel()
            {
                Bondapplication = application
            };
            
            return View(model);
        }

        private OracleCommand OracleCommandConnection(string commandText)
        {
            var sqlConn = OracleConnection();
            var sqlCmd = new OracleCommand(commandText, sqlConn);
            return sqlCmd;
        }

        private OracleConnection OracleConnection()
        {
            var sqlConn = new OracleConnection(_context.Database.Connection.ConnectionString);
            return sqlConn;
        }
    }
}