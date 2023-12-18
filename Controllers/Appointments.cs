using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing.Template;
using System.Data;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Text;
using Twilio.TwiML.Messaging;
using Zencareservice.Models;
using Zencareservice.Repository;
using System;
using System.IO;
using System.Net;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;
using System.Data.Entity.Infrastructure;
using System.Globalization;
using System.CodeDom.Compiler;
using Newtonsoft.Json;
using System.Drawing;

namespace Zencareservice.Controllers
{
    public class Appointments : Controller
    {
        public IActionResult Index()
        {

            Appts model = new Appts();

            // Example: Create a DataSet and populate it

            DataAccess Obj_DataAccess = new DataAccess();
            DataSet dataSet = new DataSet("MyDataSet");
            // ... populate the DataSet with data ...

            model.MyDataSet = dataSet;

            dataSet = Obj_DataAccess.FetchData();

            return View();
        }
        public IActionResult Aptedit()
        {
            return View();
        }

        public string GetUserId()
        {
            string UsrId = Request.Cookies["UsrId"];

            TempData["UserId"] = UsrId;

            string UsrName = Request.Cookies["UsrName"];

            return UsrId;

        }


        public IActionResult CreateAppointment()
        {

            string UsrId = Request.Cookies["UsrId"];

            TempData["UserId"] = UsrId;

            string UsrName = Request.Cookies["UsrName"];

            if (string.IsNullOrEmpty(UsrId) || string.IsNullOrEmpty(UsrName))
            {
                return RedirectToAction("PatientLogin", "Account");
            }


            else
            {
                DataAccess Obj_DataAccess = new DataAccess();
                DataSet ds = new DataSet();
                ds = Obj_DataAccess.GetAppointments(UsrId);

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


                foreach (DataRow row in ds.Tables[1].Rows)

                ViewBag.State = StateList;
                ViewBag.GenderList = genderList;
                ViewBag.DataSet = ds.Tables[1];
                ViewBag.SelectedValue = "Tamil Nadu";

                string returnUrl = "/Appointments/CreateAppointment";
                ViewData["ReturnUrl"] = returnUrl;
            }
            return View();
        }

        public IActionResult Aptcrt()
        {

           
            string UsrId = Request.Cookies["UsrId"];

            TempData["UserId"] = UsrId;

            string UsrName = Request.Cookies["UsrName"];

            if (string.IsNullOrEmpty(UsrId) || string.IsNullOrEmpty(UsrName))
            {
                return RedirectToAction("PatientLogin", "Account");
            }
            else
            {
                DataAccess Obj_DataAccess = new DataAccess();
                DataSet ds = new DataSet();
                ds = Obj_DataAccess.GetAppointments(UsrId);

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

               
                foreach (DataRow row in ds.Tables[1].Rows)

                ViewBag.State = StateList;
                ViewBag.GenderList = genderList;
                ViewBag.DataSet = ds.Tables[1];
                ViewBag.SelectedValue = "Tamil Nadu";

                //string fname = ds.Tables[0].Rows[0]["Fname"].ToString();
                //string lname = ds.Tables[0].Rows[0]["Lname"].ToString();
                //string phoneno = ds.Tables[0].Rows[0]["Phoneno"].ToString();
                //string email = ds.Tables[0].Rows[0]["Email"].ToString();
                //string gender = ds.Tables[0].Rows[0]["Gender"].ToString();
                //string address1 = ds.Tables[0].Rows[0]["Addressline1"].ToString();
                //string address2 = ds.Tables[0].Rows[0]["Addressline2"].ToString();
                //string altaddress = ds.Tables[0].Rows[0]["AltAddress"].ToString();
                //string altphoneno = ds.Tables[0].Rows[0]["Aphoneno"].ToString();
                //string uniqueid = ds.Tables[0].Rows[0]["UniqueId"].ToString();
                //string zipcode = ds.Tables[0].Rows[0]["Zipcode"].ToString();
                //string state = ds.Tables[0].Rows[0]["PState"].ToString();
                //string city = ds.Tables[0].Rows[0]["PCity"].ToString();
                //string country = ds.Tables[0].Rows[0]["Country"].ToString();



                //apts = new Appointments();
                //{
                //apts.Firstname = fname;
                //apts.Lastname = lname;
                //apts.Phoneno = phoneno;
                //apts.Email = email;
                //apts.Address1 = address1;
                //apts.Gender = gender;
                //apts.Address2 = address2;
                //apts.AltPhoneno = altphoneno;
                //apts.Uniqueid = uniqueid;
                //apts.Zipcode = zipcode;
                //apts.AltAddress = altaddress;
                //apts.Country = country;
                //apts.PState = state;
                //apts.PCity = city;

                //}

                string returnUrl = "/Appointments/Aptcrt";
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }
        }

        [HttpPost]
        public IActionResult GetCities(int stateId)
        {
            DataAccess Obj_DataAccess = new DataAccess();
            DataSet ddd = new DataSet();
            ddd = Obj_DataAccess.SetCity(stateId);

            string cities = JsonConvert.SerializeObject(ddd.Tables[0]);
            return Json(cities);
        }

        [HttpPost]
        public IActionResult Aptcrt(Appts Obj, string returnUrl)
        {
              try
                {
                    string role = "patient";
                    string pfname = Obj.PatientFirstName;
                    string plname = Obj.PatientLastName;
                    string dfname = Obj.DoctorFirstName;
                    string dlname = Obj.DoctorLastName;
                    string gender = Obj.PatientGender;
                    Obj.PatientGender = "Male";
                    string paddress1 = Obj.PatientAddress1;
                    string paddress2 = Obj.PatientAddress2;
                    string patientemail = Obj.PatientEmail;
                    Obj.PatientEmail = "vdgopisrinivasan@gmail.com";
                    string Patientage = Obj.PatientAge;
                    ViewBag.Selectedstate = Obj.PState; 
                    string State = Obj.PState;
                    string City = Obj.PCity;
                    string pcontact = Obj.Patientphoneno;
                    DateTime aptbookdate = Obj.AptBookingDate;
                    TimeSpan aptbooktime = Obj.AptBookingTime;
                    DataAccess Obj_DataAccess = new DataAccess();
                    DataSet ds = new DataSet();
                    ds = Obj_DataAccess.SaveAppointment(Obj);

              }
                catch (Exception ex)
              {
                    throw ex;
              }
                return View();
           

        }
    }
}
