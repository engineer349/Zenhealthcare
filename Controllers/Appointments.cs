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
        
        public IActionResult Aptlist()
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


        public IActionResult CreateAppointment(Appts apt)
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

           

                var dataRows = (ds.Tables.Count > 1) ? ds.Tables[2].AsEnumerable() : Enumerable.Empty<DataRow>();

                ViewBag.YourDataList = new SelectList(dataRows, "DId", "DFname");


                var genderList = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Male", Value = "Male" },
                    new SelectListItem { Text = "Female", Value = "Female" },
                    new SelectListItem { Text = "Other", Value = "Other" }
                    // Add more options as needed
                };

                var DList = new List<SelectListItem>();

                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    var Doctorname = new SelectListItem
                    {
                        Text = row["DFname"].ToString(),
                        Value = row["DId"].ToString()
                    };

                    DList.Add(Doctorname);
                    ViewBag.DFname = DList;
                    ViewBag.SelectedValue = "Doctor FirstName";
                }


                foreach (DataRow row in ds.Tables[1].Rows)

                
                ViewBag.GenderList = genderList;
                ViewBag.DataSet = ds.Tables[1];
                ViewBag.SelectedValue = "Tamil Nadu";
                
                string fname = ds.Tables[1].Rows[0]["Fname"].ToString();
                string lname = ds.Tables[1].Rows[0]["Lname"].ToString();
                string phoneno = ds.Tables[1].Rows[0]["Phoneno"].ToString();
                string email = ds.Tables[1].Rows[0]["Email"].ToString();
                string gender = ds.Tables[1].Rows[0]["Gender"].ToString();
                string address1 = ds.Tables[1].Rows[0]["Addressline1"].ToString();
                string RCode = ds.Tables[1].Rows[0]["Rcode"].ToString();
                TempData["RCode"] = RCode;
                string patage = ds.Tables[1].Rows[0]["Age"].ToString();


                apt = new Appts();
                {
                    apt.PatientFirstName = fname;
                    apt.PatientLastName = lname;
                    apt.Patientphoneno = phoneno;
                    apt.PatientEmail = email;
                    apt.PatientAddress1 = address1;
                    apt.PatientGender = gender;
                    apt.PatientAge = patage;

                }



            }
            return View(apt);
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
        public IActionResult Aptcrt(Appts Obj)
        {
              try
                {
                    string role = "patient";
                
                    string pfname = Obj.PatientFirstName;
                    string plname = Obj.PatientLastName;
                    string pemail = Obj.PatientEmail;
                    string dfname = Obj.DoctorFirstName;
                    string dlname = Obj.DoctorLastName;
                    string gender = Obj.PatientGender;

                    Obj.RCode = Convert.ToString(TempData["RCode"]);
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
