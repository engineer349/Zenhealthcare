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

        public IActionResult Aptcrt()
        {
            
			var jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "IndianStates.json");

            
			if (System.IO.File.Exists(jsonFilePath))
			{
				var jsonContent = System.IO.File.ReadAllText(jsonFilePath);
				var citiesData = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonContent);

				ViewBag.CitiesData = citiesData;
			}
            else
            {
                ViewBag.CitiesData = new Dictionary<string, string>();
            }
            
            string returnUrl = "/Appointments/Aptcrt";
            ViewData["ReturnUrl"] = returnUrl;
            return View();
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
