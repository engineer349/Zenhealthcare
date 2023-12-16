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


       
      
        public IActionResult Profile(Personaldetails pers)
        {
            
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
                DataSet dse = new DataSet();
                ds = Obj_DataAccess.GetProfile(UsrId);

                List<Personaldetails> getStates = new List<Personaldetails>();

              
                string state = ds.Tables[1].Rows[1]["State"].ToString();
                int value = ds.Tables[1].Rows[0]["SId"].GetHashCode();

                getStates.Add(new Personaldetails { Value = value, Text = state });
    
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


        [HttpPost]
        public IActionResult Profile( Personaldetails Obj)
        {
            string Altcontact = Obj.AltPhoneno;
            string Addressline1 = Obj.Address1;
            string Addressline2 = Obj.Address2;
            string Altaddress = Obj.AltAddress;
            string State = Obj.State;
            string City = Obj.City;
            string Country = Obj.Country;



            return View(Obj);


        }
       
    }
}
