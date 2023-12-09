using System.CodeDom;
using System.Data;
using System.Data.SqlClient;

namespace Zencareservice.Data
{
    public class SqlDataAccess
    {
        string connectionString = @"Data Source=GOPI\SQLEXPRESS;Initial Catalog = zencareservice; User Id = sa; Password=Devops@22;";
        SqlConnection sqlcon;
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        public SqlDataAccess()
        {


        }
        public DataSet GetDataWithStoredprocedure(string StrSpName)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {


                SqlConnection con = new SqlConnection(connectionString);
                SqlDataAdapter da = new SqlDataAdapter(StrSpName, con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.Fill(ds);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();

            }
            return ds;
        }
        public DataSet GetDataWithParamStoredprocedure(string StrSpName, SqlParameter[] Param)
        {
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {

                SqlConnection con = new SqlConnection(connectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                //da.SelectCommand.CommandType = CommandType.StoredProcedure;
                cmd = new SqlCommand(StrSpName, con);
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                for (int i = 0; i < Param.Length; i++)
                {
                    da.SelectCommand.Parameters.Add(Param[i]);
                }
                // string ExecStmt=CommandAsSql_Text(cmd);
                da.Fill(ds);


            }
            catch (Exception ex)
            {

                throw ex;
            }


            return ds;
        }

    }
}
