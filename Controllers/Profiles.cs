using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Data;
using Zencareservice.Repository;
using Zencareservice.Models;
using System.Drawing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;

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

            TempData["UserId"] = UsrId;


            //ViewBag["Message"]= UsrId;

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

                var dataRows = (ds.Tables.Count > 1) ? ds.Tables[1].AsEnumerable() : Enumerable.Empty<DataRow>();
                ViewBag.YourDataList = new SelectList(dataRows, "Id", "State");


                var genderList = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Male", Value = "Male" },
                    new SelectListItem { Text = "Female", Value = "Female" },
                    new SelectListItem { Text = "Other", Value = "Other" }
                    // Add more options as needed
                };

                var StateList = new List<SelectListItem>();


                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    var StateItem = new SelectListItem
                    {
                        Text = row["State"].ToString(),
                        Value = row["Id"].ToString()
                    };

                    StateList.Add(StateItem);
                }

                ViewBag.State = StateList;
                ViewBag.GenderList = genderList;



     

                ViewBag.DataSet = ds.Tables[1];
                ViewBag.SelectedValue = "Tamil Nadu";

            

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
        public IActionResult GetCities(int stateId)
        {
            DataAccess Obj_DataAccess = new DataAccess();
            DataSet ddd=new DataSet();
            ddd= Obj_DataAccess.SetCity(stateId);

            string cities = JsonConvert.SerializeObject(ddd.Tables[0]);
            return Json(cities);
        }

        [HttpPost]
        public IActionResult Profile(Personaldetails Obj, string UsrId)
        {
                      
            try
            {
                ViewBag["Message"] = Obj.UsrId;
                string Gender = Obj.Gender;
                string Altcontact = Obj.AltPhoneno;
                string Addressline1 = Obj.Address1;
                string Addressline2 = Obj.Address2;
                string Altaddress = Obj.AltAddress;
                string State = Obj.State;
                string City = Obj.City;
                string Country = Obj.Country;
                string Uniqueid = Obj.Uniqueid;
                string zipcode = Obj.Zipcode;
                string Email = Obj.Email;
                DataAccess Obj_DataAccess = new DataAccess();
                DataSet ds = new DataSet();
                ds = Obj_DataAccess.UpdateProfile(Obj, UsrId);
            }

            catch(Exception ex)
            {
                throw ex;
            }


            return View("Profile", "Profiles");



        }

    }
}
