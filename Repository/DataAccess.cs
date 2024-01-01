
using System.Data.SqlClient;
using System.Data;
using Zencareservice.Data;
using System.Xml.Linq;
using Zencareservice.Models;
using Zencareservice.Controllers;
using System;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.CodeDom;

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

                if (Obj.RCategory == "Employee")
                {
                    SqlParameter[] param = new SqlParameter[12];
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
                    param[5] = new SqlParameter("@Dob", SqlDbType.DateTime);
                    param[5].Value = Obj.Dob;
                    param[6] = new SqlParameter("@Phone", SqlDbType.VarChar);
                    param[6].Value = Obj.Phonenumber;
                    param[7] = new SqlParameter("@Status", SqlDbType.VarChar);
                    param[7].Value = Obj.Status;
                    param[8] = new SqlParameter("@Role", SqlDbType.VarChar);
                    param[8].Value = Obj.RoleId;
                    param[9] = new SqlParameter("@agreeterm", SqlDbType.VarChar);
                    param[9].Value = Convert.ToInt32(Obj.agreeterm);
                    param[10] = new SqlParameter("@Age", SqlDbType.Int);
                    param[10].Value = Convert.ToInt32(Obj.Age);
                    param[11] = new SqlParameter("@RCategory", SqlDbType.VarChar);
                    param[11].Value = Obj.RCategory;
                    ds = Obj_SqlDataAccess.GetDataWithParamStoredprocedure(StrSPName, param);

                }
                else
                {
                    SqlParameter[] param = new SqlParameter[12];
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
                    param[5] = new SqlParameter("@Dob", SqlDbType.DateTime);
                    param[5].Value = Obj.Dob;
                    param[6] = new SqlParameter("@Phone", SqlDbType.VarChar);
                    param[6].Value = Obj.Phonenumber;
                    param[7] = new SqlParameter("@Status", SqlDbType.VarChar);
                    param[7].Value = Obj.Status;
                    param[8] = new SqlParameter("@Role", SqlDbType.VarChar);
                    param[8].Value = Obj.RoleId;
                    param[9] = new SqlParameter("@agreeterm", SqlDbType.VarChar);
                    param[9].Value = Convert.ToInt32(Obj.agreeterm);
                    param[10] = new SqlParameter("@Age", SqlDbType.Int);
                    param[10].Value = Convert.ToInt32(Obj.Age);
                    param[11] = new SqlParameter("@RCategory", SqlDbType.VarChar);
                    param[11].Value = Obj.RCategory;
                    param[12] = new SqlParameter("@Username",SqlDbType.NVarChar);
                    param[12].Value = Obj.Username;
                    ds = Obj_SqlDataAccess.GetDataWithParamStoredprocedure(StrSPName, param);
                }


   
                return ds;
            }

            catch (SqlException ex)
            {                
                throw ex;
                
            }


        }


        public DataSet FetchData()
        {
            try
            {
                DataSet ds = new DataSet();
                
                 
                
                string StrSPName = "GetAllPatientDetails";

                //string StrSPName = "GetAllDoctorDetails";

              


                return ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            
            }

        }

        public DataSet GetDashboardvalues(Dashboard Obj)
        {
            try
            {
                DataSet ds = new DataSet();
                string StrSPName = "DashboardValues_SP";

                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@UsrId", SqlDbType.Int);
                param[0].Value = Obj.UsrId;
                param[1] = new SqlParameter("@Role", SqlDbType.NVarChar);
                param[1].Value = Obj.Role;

                ds = Obj_SqlDataAccess.GetDataWithParamStoredprocedure(StrSPName,param);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CheckAppointmentList(Appts Obj)
        {
            try
            {
                DataSet ds = new DataSet();
                string StrSPName = "GetAllAppointmentdetails";

                SqlParameter[] param = new SqlParameter[4];

                param[0] = new SqlParameter("@AptBookingdate", SqlDbType.NVarChar);
                param[0].Value = Obj.AptBookingDate;
                param[1] = new SqlParameter("@AptBokingtime", SqlDbType.NVarChar);
                param[1].Value = Obj.AptBookingTime; ;
                param[2] = new SqlParameter("@PFname", SqlDbType.NVarChar);
                param[2].Value = Obj.PatientFirstName;
                param[3] = new SqlParameter("@DFname", SqlDbType.NVarChar);
                param[3].Value = Obj.DoctorFirstName;
                



                ds = Obj_SqlDataAccess.GetDataWithParamStoredprocedure(StrSPName, param);

                return ds ;
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

                SqlParameter[] param = new SqlParameter[10];

                param[0] = new SqlParameter("@PatientFirstname", SqlDbType.NVarChar);
                param[0].Value = Obj.PatientFirstName;
                param[1] = new SqlParameter("@PatientLastname", SqlDbType.NVarChar);
                param[1].Value = Obj.PatientLastName;
                param[2] = new SqlParameter("@PatientEmail", SqlDbType.NVarChar);
                param[2].Value = Obj.PatientEmail;
                param[3] = new SqlParameter("@DoctorFirstname", SqlDbType.NVarChar);
                param[3].Value = Obj.DoctorFirstName;
                param[4] = new SqlParameter("@AptCategory", SqlDbType.NVarChar);
                param[4].Value = Obj.AptCategory;
                param[5] = new SqlParameter("@Patgender", SqlDbType.NVarChar);
                param[5].Value = Obj.PatientGender;
                param[6] = new SqlParameter("@AptBookdate", SqlDbType.Date);
                param[6].Value = Obj.AptBookingDate;
                param[7] = new SqlParameter("@AptTime", SqlDbType.Time);
                param[7].Value = Obj.AptBookingTime;
                param[8] = new SqlParameter("@RCode", SqlDbType.VarChar);
                param[8].Value = Obj.RCode;
                param[9] = new SqlParameter("@ReasonType", SqlDbType.VarChar);
                param[9].Value = Obj.ReasonType;
                param[10] = new SqlParameter("@PatientContact", SqlDbType.VarChar);
                param[10].Value = Obj.Patientphoneno;



                ds = Obj_SqlDataAccess.GetDataWithParamStoredprocedure(StrSPName, param);

                return ds;
            }

            catch (SqlException ex)
            {
                throw ex;

            }


        }

        public DataSet UpdateAppointment(Appts Obj)
        {

            try
            {
                DataSet ds = new DataSet();
                string StrSPName = "UpdateAppointment_SP";

                SqlParameter[] param = new SqlParameter[10];


                param[1] = new SqlParameter("@AptBookdate", SqlDbType.Date);
                param[1].Value = Obj.AptBookingDate;
                param[2] = new SqlParameter("@AptTime", SqlDbType.Time);
                param[2].Value = Obj.AptBookingTime;
                param[3] = new SqlParameter("@RCode", SqlDbType.VarChar);
                param[3].Value = Obj.RCode;
                param[4] = new SqlParameter("@ReschduleAppointmentDate", SqlDbType.Date);
                param[4].Value = Obj.ReasonType;
                param[5] = new SqlParameter("@RescheduleAppointmentTime", SqlDbType.Time);
                param[5].Value = Obj.ReasonType;
                param[6] = new SqlParameter("@ReasonType", SqlDbType.VarChar);
                param[6].Value = Obj.ReasonType;
                

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

        public DataSet GetProfile( int Id)
        {

            try
            {
                DataSet ds = new DataSet();
                string StrSPName = "GetAllPersonalDetails";

                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@Id", SqlDbType.Int);
                param[0].Value = Id;

                ds = Obj_SqlDataAccess.GetDataWithParamStoredprocedure(StrSPName, param);

                return ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            }


        }



        public DataSet GetAppointments(string UsrId)
        {

            try
            {
                DataSet ds = new DataSet();
                string StrSPName = "GetAllAppoinments";

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
        public DataSet GetAppointmentList(string UsrId)
        {

            try
            {
                DataSet ds = new DataSet();
                string StrSPName = "GetAppointmentList";

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

        public DataSet SetSelfAppointment(string UsrId)
        {
            try
            {
                DataSet ds = new DataSet();
                string StrSPName = "GetSelfAppointment";

                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@UsrId", SqlDbType.VarChar);
                param[0].Value = UsrId;

                ds = Obj_SqlDataAccess.GetDataWithParamStoredprocedure(StrSPName, param);

                return ds;

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public DataSet GetUserList(string Role)
        {

            try
            {
                DataSet ds = new DataSet();
                string StrSPName = "GetAllUserList";

                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@Role", SqlDbType.VarChar);
                param[0].Value = Role;


                ds = Obj_SqlDataAccess.GetDataWithParamStoredprocedure(StrSPName, param);

                return ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            }


        }
        public DataSet GetPrescriptions(string UsrId,string RCode)
        {

            try
            {
                DataSet ds = new DataSet();
                string StrSPName = "GetAllPrescriptions";

                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("@UsrId", SqlDbType.Int);
                param[0].Value = UsrId;
                param[1] = new SqlParameter("@RCode", SqlDbType.VarChar);
                param[1].Value = RCode;

                ds = Obj_SqlDataAccess.GetDataWithParamStoredprocedure(StrSPName, param);

                return ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            }


        }

        public DataSet SetCity ( int stateId)
        {
            try
            {
                DataSet ds = new DataSet();
                string StrSPName = "GetAllCitites";

                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@StateId", SqlDbType.Int);
                param[0].Value = stateId;

                ds = Obj_SqlDataAccess.GetDataWithParamStoredprocedure(StrSPName, param);

                return ds;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public DataSet GetStates()
        {

            try
            {
                DataSet ds = new DataSet();
                string StrSPName = "GetAllStates";

                ds = Obj_SqlDataAccess.GetDataWithStoredprocedure(StrSPName);

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
        public DataSet UpdateProfile(Personaldetails Obj)
        {

            try
            {
                DataSet ds = new DataSet();
                string StrSPName = "UpdatePersonaldetails_SP";

                SqlParameter[] param = new SqlParameter[16];
                param[0] = new SqlParameter("@Gender", SqlDbType.NVarChar);
                param[0].Value = Obj.Gender;
                param[1] = new SqlParameter("@APhoneno", SqlDbType.NVarChar);
                param[1].Value = Obj.AltPhoneno;
                param[2] = new SqlParameter("@Addressline1", SqlDbType.NVarChar);
                param[2].Value = Obj.Address1;
                param[3] = new SqlParameter("@Addressline2", SqlDbType.NVarChar);
                param[3].Value = Obj.Address2;
                param[4] = new SqlParameter("@AltAddress", SqlDbType.NVarChar);
                param[4].Value = Obj.AltAddress;
                param[5] = new SqlParameter("@State", SqlDbType.NVarChar);
                param[5].Value = Obj.State;
                param[6] = new SqlParameter("@City", SqlDbType.NVarChar);
                param[6].Value = Obj.City;
                param[7] = new SqlParameter("@Country", SqlDbType.NVarChar);
                param[7].Value = Obj.Country;
                param[8] = new SqlParameter("@UniqueId", SqlDbType.NVarChar);
                param[8].Value = Obj.Uniqueid;
                param[9] = new SqlParameter("@UsrId", SqlDbType. Int);
                param[9].Value = Obj.UsrId;
                param[10] = new SqlParameter("@Zipcode", SqlDbType.NVarChar);
                param[10].Value = Obj.Zipcode;
                param[11] = new SqlParameter("@Email", SqlDbType.NVarChar);
                param[11].Value = Obj.Email;
                param[12] = new SqlParameter("@Role",SqlDbType.NVarChar);
                param[12].Value = Obj.Role;
                param[13] = new SqlParameter("@Dqualify", SqlDbType.NVarChar);
                param[13].Value = Obj.DQualification;
                param[14] = new SqlParameter("@specialistname", SqlDbType.NVarChar);
                param[14].Value = Obj.specialistname;
                param[15] = new SqlParameter("@Dexp", SqlDbType.NVarChar);
                param[15].Value = Obj.DExp;
                

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
