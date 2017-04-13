using Oracle.ManagedDataAccess.Client;
using System;
using System.Configuration;
using System.Data;

namespace Mvc.BondApp
{
    public class BondFunctions
    {



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
        public int GetTotalBondFromProcedure(string applicationNo, OracleConnection _connection, OracleCommand _oracleCommand)
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
        public string GET_NOPAYABLEBOND(string applicationNo, OracleConnection _connection, OracleCommand _oracleCommand)
        {
            string totalBond = null;
            var connection = _connection;
            var oracleCommand = _oracleCommand;
            oracleCommand.CommandType = CommandType.Text;
            oracleCommand.Parameters.Add("PBONDSCN", OracleDbType.Varchar2).Value = applicationNo;
            try
            {
                connection.Open();
                OracleDataReader reader = oracleCommand.ExecuteReader();
                while (reader.Read())
                {
                    totalBond = Convert.ToString(reader["VDESC"]);
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

        public decimal GET_PAIDUPINT(string applicationNo, OracleConnection _connection, OracleCommand _oracleCommand)
        {
            decimal paidUpInterest = 0;
            var connection = _connection;
            var oracleCommand = _oracleCommand;
            oracleCommand.CommandType = CommandType.Text;
            oracleCommand.Parameters.Add("PBONDSCN", OracleDbType.Varchar2).Value = applicationNo;
            try
            {
                connection.Open();
                OracleDataReader reader = oracleCommand.ExecuteReader();
                while (reader.Read())
                {
                    paidUpInterest = Convert.ToDecimal(reader["VNUMBER"]);
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
            return paidUpInterest;
        }

        public string GET_DRACNO(string bondCode, OracleConnection _connection, OracleCommand _oracleCommand)
        {
            string accNo = null;
            var connection = _connection;
            var oracleCommand = _oracleCommand;
            oracleCommand.CommandType = CommandType.Text;
            oracleCommand.Parameters.Add("PBONDCODE", OracleDbType.Varchar2).Value = bondCode;
            try
            {
                connection.Open();
                OracleDataReader reader = oracleCommand.ExecuteReader();
                while (reader.Read())
                {
                    accNo = Convert.ToString(reader["VDRACCNO"]);
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
            return accNo;
        }

        public string GET_APPCURR(string bondCode, char pc, OracleConnection _connection, OracleCommand _oracleCommand)
        {
            string currency = null;
            var connection = _connection;
            var oracleCommand = _oracleCommand;
            oracleCommand.CommandType = CommandType.Text;
            oracleCommand.Parameters.Add("PBONDCODE", OracleDbType.Varchar2).Value = bondCode;
            oracleCommand.Parameters.Add("PC", OracleDbType.Varchar2).Value = pc;
            try
            {
                connection.Open();
                OracleDataReader reader = oracleCommand.ExecuteReader();
                while (reader.Read())
                {
                    currency = Convert.ToString(reader["VCURRCODE"]);
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
            return currency;
        }
        //
        public DateTime GET_MAXTRANDATE(string applicationNo, OracleConnection _connection, OracleCommand _oracleCommand)
        {
            DateTime date = new DateTime();
            var connection = _connection;
            var oracleCommand = _oracleCommand;
            oracleCommand.CommandType = CommandType.Text;
            oracleCommand.Parameters.Add("PBONDSCN", OracleDbType.Varchar2).Value = applicationNo;

            try
            {
                connection.Open();
                OracleDataReader reader = oracleCommand.ExecuteReader();
                while (reader.Read())
                {
                    date = Convert.ToDateTime(reader["VDATE"]);
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
            return date;
        }
        public string GET_INTCURR(string applicationNo, char pc, OracleConnection _connection, OracleCommand _oracleCommand)
        {
            string currency = null;
            var connection = _connection;
            var oracleCommand = _oracleCommand;
            oracleCommand.CommandType = CommandType.Text;
            oracleCommand.Parameters.Add("PBONDSCN", OracleDbType.Varchar2).Value = applicationNo;
            oracleCommand.Parameters.Add("PC", OracleDbType.Varchar2).Value = pc;
            try
            {
                connection.Open();
                OracleDataReader reader = oracleCommand.ExecuteReader();
                while (reader.Read())
                {
                    currency = Convert.ToString(reader["VCURRCODE"]);
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
            return currency;
        }



        public decimal GET_TOTALAMT(string applicationNo, string cType, OracleConnection _connection, OracleCommand _oracleCommand)
        {
            decimal vNumberF = 0;
            decimal vNumberL = 0;
            //VNUMBERF NUMBER(20, 4);
            //VNUMBERL NUMBER(20, 4);
            var connection = _connection;
            var oracleCommand = _oracleCommand;
            oracleCommand.CommandType = CommandType.Text;
            oracleCommand.Parameters.Add("PBONDSCN", OracleDbType.Varchar2).Value = applicationNo;
            oracleCommand.Parameters.Add("CTYPE", OracleDbType.Varchar2).Value = cType;

            try
            {
                connection.Open();
                OracleDataReader reader = oracleCommand.ExecuteReader();
                while (reader.Read())
                {
                    vNumberF = Convert.ToDecimal(reader["VNUMBERF"]);
                    vNumberL = Convert.ToDecimal(reader["VNUMBERL"]);
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
            return vNumberF;
        }



        public decimal GET_TOTAL_BONDVALUE(string passportNo, OracleConnection _connection, OracleCommand _oracleCommand)
        {
            if (passportNo == null) throw new ArgumentNullException("passportNo");
            decimal totalValue = 0;


            var connection = _connection;
            var oracleCommand = _oracleCommand;
            oracleCommand.CommandType = CommandType.Text;
            oracleCommand.Parameters.Add("Ppasport", OracleDbType.Varchar2).Value = passportNo;


            try
            {
                connection.Open();
                OracleDataReader reader = oracleCommand.ExecuteReader();
                while (reader.Read())
                {
                    totalValue = Convert.ToDecimal(reader["vmat"]);

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
            return totalValue;
        }




        //public Tuple<string,string,string>  LookupName(long id) // tuple return type
        //{
        //    long x;
        //    // retrieve first, middle and last from data storage
        //    return new Tuple<string, string, string>(x); // tuple literal
        //}

    }

}