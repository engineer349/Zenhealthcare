
using System.Data.SqlClient;
using System.Data;
using Zencareservice.Data;
using System.Xml.Linq;
using Zencareservice.Models;
using Zencareservice.Controllers;
using System;

namespace Zencareservice.Repository
{
    public class DataAccess
    {
        SqlDataAccess Obj_SqlDataAccess = new SqlDataAccess();

        public DataSet SaveRegister(Signup Obj)
        {
            
            try
            {
                DataSet ds=new DataSet();
                string StrSPName = "SaveRegister_SP";
                
                SqlParameter[] param = new SqlParameter[11];

                param[0] = new SqlParameter("@Firstname", SqlDbType.NVarChar);
                param[0].Value = Obj.Firstname;
                param[1] = new SqlParameter("@Lastname", SqlDbType.NVarChar);
                param[1].Value = Obj.Lastname;
                param[2] = new SqlParameter("@Email", SqlDbType.NVarChar);
                param[2].Value = Obj.Email;
                param[3] = new SqlParameter("@Password", SqlDbType.NVarChar);
                param[3].Value = Obj.Password;
                param[4] = new SqlParameter("@Confirmpassword", SqlDbType.NVarChar);
                param[4].Value = Obj.Confirmpassword;       
                param[5] = new SqlParameter("@Username",SqlDbType.NVarChar);
                param[5].Value = Obj.Username;
                param[6] = new SqlParameter("@Dob", SqlDbType.DateTime);
                param[6].Value = Obj.Dob;
                param[7] = new SqlParameter("@Phone", SqlDbType.VarChar);
                param[7].Value = Obj.Phonenumber;
                param[8] = new SqlParameter("@Status", SqlDbType.VarChar);
                param[8].Value = Obj.Status;
                param[9] = new SqlParameter("@Role", SqlDbType.VarChar);
                param[9].Value = Obj.RoleId;
                param[10] = new SqlParameter("@agreeterm", SqlDbType.VarChar);
                param[10].Value = Convert.ToInt32(Obj.agreeterm);


                ds = Obj_SqlDataAccess.GetDataWithParamStoredprocedure(StrSPName, param);
                
                return ds;
            }

            catch (SqlException ex)
            {                
                throw ex;
                
            }


        }

        public DataSet SaveAppointment(Appts Obj)
        {

            try
            {
                DataSet ds = new DataSet();
                string StrSPName = "AppointmentBooking_SP";

                SqlParameter[] param = new SqlParameter[15];

                param[0] = new SqlParameter("@PatientFirstname", SqlDbType.NVarChar);
                param[0].Value = Obj.PatientFirstName;
                param[1] = new SqlParameter("@PatientLastname", SqlDbType.NVarChar);
                param[1].Value = Obj.PatientLastName;
                param[2] = new SqlParameter("@PatientEmail", SqlDbType.NVarChar);
                param[2].Value = "vdgopisrinivasan@gmail.com";
                param[3] = new SqlParameter("@DoctorFirstname", SqlDbType.NVarChar);
                param[3].Value = Obj.DoctorFirstName;
                param[4] = new SqlParameter("@DoctorLastname", SqlDbType.NVarChar);
                param[4].Value = Obj.DoctorLastName;
                param[5] = new SqlParameter("@Patgender", SqlDbType.NVarChar);
                param[5].Value = Obj.PatientGender;
                param[6] = new SqlParameter("@AptBookdate", SqlDbType.Date);
                param[6].Value = Obj.AptBookingDate;
                param[7] = new SqlParameter("@AptTime", SqlDbType.Time);
                param[7].Value = Obj.AptBookingTime;
                param[8] = new SqlParameter("@PatientAddress1", SqlDbType.VarChar);
                param[8].Value = Obj.PatientAddress1;
                param[9] = new SqlParameter("@PatientAddress2", SqlDbType.VarChar);
                param[9].Value = Obj.PatientAddress2;
                param[10] = new SqlParameter("@PatientPhoneno", SqlDbType.VarChar);
                param[10].Value = Obj.Patientphoneno; 
                param[11] = new SqlParameter("@Patientage", SqlDbType.VarChar);
                param[11].Value = Obj.PatientAge;
                param[12] = new SqlParameter("@ReasonType", SqlDbType.VarChar);
                param[12].Value = Obj.ReasonType;
                param[13] = new SqlParameter("@PState", SqlDbType.VarChar);
                param[13].Value = Obj.PState;
                param[14] = new SqlParameter("@PCity", SqlDbType.VarChar);
                param[14].Value = Obj.PCity;

                ds = Obj_SqlDataAccess.GetDataWithParamStoredprocedure(StrSPName, param);

                return ds;
            }

            catch (SqlException ex)
            {
                throw ex;

            }


        }

        public DataSet CheckEmail(Signup Obj)
        {

            try
            {
                DataSet dse = new DataSet();
                string StrSPName = "GetAllEmaildetails";

                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@Email", SqlDbType.NVarChar);
                param[0].Value = Obj.Email;

                dse = Obj_SqlDataAccess.GetDataWithParamStoredprocedure(StrSPName, param);

                return dse;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public DataSet GetProfile( string UsrId)
        {

            try
            {
                DataSet ds = new DataSet();
                string StrSPName = "GetAllPersonalDetails";

                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@UsrId", SqlDbType.Int);
                param[0].Value = UsrId;

                ds = Obj_SqlDataAccess.GetDataWithParamStoredprocedure(StrSPName, param);

                return ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            }


        }
        public DataSet SaveLogin(Login Obj)
        {

            try
            {
                DataSet ds = new DataSet();
                string StrSPName = "CheckLogin_SP";

                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@Uname", SqlDbType.NVarChar);
                param[0].Value = Obj.Username;
                param[1] = new SqlParameter("@Pass", SqlDbType.NVarChar);
                param[1].Value = Obj.Password;


                ds = Obj_SqlDataAccess.GetDataWithParamStoredprocedure(StrSPName, param);

                return ds;
            }

            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataSet ResetPassword(Signup Obj, String ResetMail)
        {

            try
            {
                DataSet ds = new DataSet();
                string StrSPName = "UpdatePassword_SP";

                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@Email", SqlDbType.NVarChar);
                param[0].Value = ResetMail;
                param[1] = new SqlParameter("@RPassword", SqlDbType.NVarChar);
                param[1].Value = Obj.RPassword;
                param[2] = new SqlParameter("@CRPassword", SqlDbType.NVarChar);
                param[2].Value = Obj.CRPassword;

                ds = Obj_SqlDataAccess.GetDataWithParamStoredprocedure(StrSPName, param);

                return ds;
            }

            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
