using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Zencareservice.Repository;
using Zencareservice.Models;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;

namespace Zencareservice.Controllers
{
    public class Profiles : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

      
        public IActionResult Profile()
        {
            Personaldetails pers = new Personaldetails();
            string UsrId = Request.Cookies["UsrId"];

            string UsrName = Request.Cookies["UsrName"];
            if (string.IsNullOrEmpty(UsrId) || string.IsNullOrEmpty(UsrName))
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {

                DataAccess Obj_DataAccess = new DataAccess();
                DataSet ds = new DataSet();
                ds = Obj_DataAccess.GetProfile(UsrId);
                string fname = ds.Tables[0].Rows[0]["Fname"].ToString();
                string lname = ds.Tables[0].Rows[0]["Lname"].ToString();
                //DateTime dob = ds.Tables[0].Rows[2]["Dob"].ToDateTime();
                string phoneno = ds.Tables[0].Rows[0]["Phoneno"].ToString();
                string email = ds.Tables[0].Rows[0]["Email"].ToString();

                pers = new Personaldetails();
                {
                    pers.Firstname = fname;
                    pers.Lastname = lname;
                    pers.Phoneno = phoneno;
                    pers.Email = email;
                }
            }

            return View(pers);
        }
        protected void Page_Load(object sender, EventArgs e,Personaldetails Obj)
        {
           

            try

            {


                string a = "ram";


               

            }

            catch (Exception ex)

            {

                throw ex;

            }

            
        }
    }
}
