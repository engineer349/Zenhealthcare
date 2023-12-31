﻿using Microsoft.AspNetCore.Mvc;
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
using System.Xml.Linq;
using System.ComponentModel;
using System.Diagnostics.Eventing.Reader;

namespace Zencareservice.Controllers
{
    public class Appointments : Controller
    {

        public IActionResult Aptlist(Appts apt)
        {
            string UsrId = Request.Cookies["UsrId"];

            TempData["UserId"] = UsrId;

            string Role = Request.Cookies["Role"];

            if (string.IsNullOrEmpty(UsrId) || string.IsNullOrEmpty(Role))
            {
                return RedirectToAction("PatientLogin", "Account");
            }

            else
            {
                DataAccess Obj_DataAccess = new DataAccess();
                DataSet ds = new DataSet();
                ds = Obj_DataAccess.GetAppointmentList(UsrId, Role);

                if (Role == "Patient")
                {
                    List<Appts> AptList = new List<Appts>();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {

                        Appts apts = new Appts();
                        {
                            apts.RCode = row["RCode"].ToString();

                            apts.DoctorFirstName = row["DFname"].ToString();
                            //apts.DoctorLastName = row["DLname"].ToString();


                            apts.AptBookingDate = Convert.ToDateTime(row["AptBookingdate"]);
                            apts.ReasonType = row["Reasontype"].ToString();

                            object aptbooktime = row["AptTime"];
                            if (aptbooktime != DBNull.Value)
                            {
                                // Conversion is safe since the value is not DBNull
                                apts.AptBookingTime = (TimeSpan?)aptbooktime;
                            }

                            else
                            {
                                apts.AptBookingTime = DateTime.Now.TimeOfDay;
                            }


                            apts.DEmail = row["DEmail"].ToString();

                            apts.DContact = row["DContactno"].ToString();

                            apts.Aptbookconfirm = Convert.ToInt32(row["Aptbookingconfirm"]);
                            apts.Aptbookstatus = Convert.ToInt32(row["Aptbookingstatusconfirm"]);



                            if (apts.Aptbookconfirm == 1 && apts.Aptbookstatus == 1)
                            {
                                apts.Aptbookingstatusconfirm = "BookingConfirmed";

                            }
                            else
                            {
                                apts.Aptbookingstatusconfirm = "Pending";
                            }


                        };
                        AptList.Add(apts);
                    }
                    apt.showlist = AptList;

                }
                else
                {
                    List<Appts> AptList = new List<Appts>();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {

                        Appts apts = new Appts();
                        {
                            apts.RCode = row["RCode"].ToString();
                            apts.DoctorFirstName = row["DFname"].ToString();
                            //apts.DoctorLastName = row["DLname"].ToString();


                       
                            apts.AptBookingDate = Convert.ToDateTime(row["AptBookingdate"]);


                            apts.ReasonType = row["Reasontype"].ToString();

                            object aptbooktime = row["AptTime"];
                            if (aptbooktime != DBNull.Value)
                            {
                                // Conversion is safe since the value is not DBNull
                                apts.AptBookingTime = (TimeSpan?)aptbooktime;
                            }

                            else
                            {
                                apts.AptBookingTime = DateTime.Now.TimeOfDay;
                            }

                            apts.DEmail = row["DEmail"].ToString();
                            apts.DContact = row["DContactno"].ToString();

                            apts.Aptbookconfirm = Convert.ToInt32(row["Aptbookingconfirm"]);

                            apts.Aptbookstatus = Convert.ToInt32(row["Aptbookingstatusconfirm"]);



                            if (apts.Aptbookconfirm == 1 && apts.Aptbookstatus == 1)
                            {
                                apts.Aptbookingstatusconfirm = "BookingConfirmed";

                            }
                            else
                            {
                                apts.Aptbookingstatusconfirm = "Pending";
                            }


                        };
                        AptList.Add(apts);
                    }
                    apt.showlist = AptList;
                }
            }
            

            return View(apt);


        }

        public IActionResult PAptlist(Appts apt)
        {
            string UsrId = Request.Cookies["UsrId"];

            TempData["UserId"] = UsrId;

            string Role = Request.Cookies["Role"];

            if (string.IsNullOrEmpty(UsrId) || string.IsNullOrEmpty(Role))
            {
                return RedirectToAction("PatientLogin", "Account");
            }

            else
            {
                DataAccess Obj_DataAccess = new DataAccess();
                DataSet ds = new DataSet();
                ds = Obj_DataAccess.GetAppointmentList(UsrId ,Role);



                List<Appts> AptList = new List<Appts>();

                foreach (DataRow row in ds.Tables[0].Rows)
                {

                    Appts apts = new Appts();
                    {
                        apts.RCode = row["RCode"].ToString();

                        
                        StringBuilder builder1 = new StringBuilder();

                        apts.PatientFirstName = row["PFname"].ToString();
                        apts.PatientLastName = row["PLname"].ToString();

                        string pfname = apts.PatientFirstName;
                        string plname = apts.PatientLastName;

                        builder1.Append(pfname);
                        builder1.Append(plname);

                        string patientname = builder1.ToString();
                        apts.PatientFirstName = patientname;
                        apts.Patientphoneno = row["Patphone"].ToString();
                        apts.PatientEmail = row["PatientEmail"].ToString();

                        apts.AptBookingDate = Convert.ToDateTime(row["AptBookingdate"]);


                        object aptRescheduleTime = row["Aptrescheduletime"];

                        if (aptRescheduleTime != DBNull.Value)
                        {
                            // Conversion is safe since the value is not DBNull
                            apts.RescheduleAppointmentTime = (TimeSpan?)aptRescheduleTime;
                        }
                        else
                        {
                            // Handle the case when the value is DBNull (e.g., set a default value)
                            apts.RescheduleAppointmentTime = DateTime.Now.TimeOfDay;
                            // Or set to a default Nullable<TimeSpan> value
                        }
                        apts.Aptbookconfirm = Convert.ToInt32(row["Aptbookingconfirm"]);
                        apts.Aptbookstatus = Convert.ToInt32(row["Aptbookingstatusconfirm"]);



                        if (apts.Aptbookconfirm == 1 && apts.Aptbookstatus == 1)
                        {
                            apts.Aptbookingstatusconfirm = "BookingConfirmed";

                        }
                        else
                        {
                            apts.Aptbookingstatusconfirm = "Pending";
                        }

                        object aptRescheduleDate = row["Aptrescheduledate"];

                        if (aptRescheduleDate != DBNull.Value)
                        {
                            apts.RescheduleAppointmentDate = Convert.ToDateTime(aptRescheduleDate);
                        }
                        else
                        {
                            apts.RescheduleAppointmentDate = DateTime.Now; 
                        }
                        apts.ReasonType = row["Reasontype"].ToString();
                        apts.AptBookingTime = ((TimeSpan?)row["AptTime"]);



                       

                    };
                    AptList.Add(apts);
                }
                apt.showlist = AptList;

            }


            return View(apt);

        }


        public string GetUserId()
        {
            string UsrId = Request.Cookies["UsrId"];

            TempData["UserId"] = UsrId;

            string UsrName = Request.Cookies["UsreName"];

            return UsrId;

        }

        public IActionResult CreateAppointment()
        {
            string returnUrl = "/Appointment/CreateAppointment";
            ViewData["ReturnUrl"] = returnUrl;

            string UsrId = Request.Cookies["UsrId"];

            TempData["UserId"] = UsrId;

            string RCode = Request.Cookies["RCode"];

            if (string.IsNullOrEmpty(UsrId) || string.IsNullOrEmpty(RCode))
            {
                return RedirectToAction("PatientLogin", "Account");
            }

            else
            {
                DataAccess Obj_DataAccess = new DataAccess();
                DataSet ds = new DataSet();
                ds = Obj_DataAccess.GetAppointments(UsrId);
                if (ds.Tables[2].Rows.Count < 1)
                {
                    ViewBag.Message = "There are no doctors available to book your Appointment";

                    return RedirectToAction("PAptlist", "Appointments");
                }

                else
                {
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
                }

                }
                return View();
        }

        [HttpGet]
        public IActionResult GetAppointment(string type )
        {
            string UsrId = Request.Cookies["UsrId"];
            DataSet ds = new DataSet();

            if (type == "self")
            {
               
                DataAccess Obj_DataAccess = new DataAccess();
               
                ds = Obj_DataAccess.SetSelfAppointment(UsrId);

            }

            ViewBag.Citymsg = null;
            string cities = JsonConvert.SerializeObject(ds.Tables[0]);
            return Json(cities);
        }

        [HttpGet]
        public IActionResult Apptcrt(Appts apt)
        {

            string UsrId = Request.Cookies["UsrId"];

            TempData["UserId"] = UsrId;

            string RCode = Request.Cookies["RCode"];

            if (string.IsNullOrEmpty(UsrId) || string.IsNullOrEmpty(RCode))
            {
                return RedirectToAction("PatientLogin", "Account");
            }


            else
            {


                DataAccess Obj_DataAccess = new DataAccess();
                DataSet ds = new DataSet();
                ds = Obj_DataAccess.GetAppointments(UsrId);

                if (ds.Tables[2].Rows.Count < 1)
                {
                    ViewBag.Message = "There are no doctors available to book your Appointment";

                    return RedirectToAction("PAptlist", "Appointments");
                }

                else
                {
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
            }
            return View(apt);
        }

        [HttpPost]
        public IActionResult Aptedit(string a)
        {
            string ap = "apple";

            return View();
        }

        public IActionResult Aptedit(Appts apt)
        {
            string UsrId = Request.Cookies["UsrId"];

            TempData["UserId"] = UsrId;

            string RCode = Request.Cookies["RCode"];

            if (string.IsNullOrEmpty(UsrId) || string.IsNullOrEmpty(RCode))
            {
                return RedirectToAction("PatientLogin", "Account");
            }


            else
            {
                DataAccess Obj_DataAccess = new DataAccess();
                DataSet ds = new DataSet();
                ds = Obj_DataAccess.GetAppointments(UsrId);

                if (ds != null)
                {
                    foreach (DataRow row in ds.Tables[4].Rows)
                    {
                        string pfname = ds.Tables[1].Rows[0]["PFname"].ToString();
                        string plname = ds.Tables[1].Rows[0]["PLname"].ToString();
                        string dfname = ds.Tables[1].Rows[0]["DFname"].ToString();                       
                        string reasontype = ds.Tables[1].Rows[0]["Reasontype"].ToString();
                        string aptbookingdate = ds.Tables[1].Rows[0]["AptBookingdate"].ToString();
                        string aptbookingtime = ds.Tables[1].Rows[0]["AptTime"].ToString();


                        apt = new Appts();
                        {
                            apt.PatientFirstName = pfname;
                            apt.PatientLastName = plname;
                            apt.DoctorFirstName = dfname;                          
                            apt.ReasonType = reasontype;


                        }


                    }


                }
                return View(apt);
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
        public IActionResult CreateAppointment(Appts Obj,string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {
                string UsrId = Request.Cookies["UsrId"];

                string RCode = Request.Cookies["RCode"];

                if (string.IsNullOrEmpty(UsrId) || string.IsNullOrEmpty(RCode))
                {
                    return RedirectToAction("PatientLogin", "Account");
                }


                else
                {
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            // If the model is not valid, return the view with the model
                           
                 

                            Obj.UsrId = Convert.ToInt32(UsrId);
                            string pfname = Obj.PatientFirstName;
                            string plname = Obj.PatientLastName;
                            string pemail = Obj.PatientEmail;
                            string dfname = Obj.DoctorFirstName;
                            //string dlname = Obj.DoctorLastName;
                            string gender = Obj.PatientGender;

                            Obj.RCode = Convert.ToString(TempData["RCode"]);
                            DateTime aptbookdate = Obj.AptBookingDate;
                            TimeSpan aptbooktime = (TimeSpan)Obj.AptBookingTime;


                            DataAccess Obj_DataAccess = new DataAccess();
                            DataSet ds = new DataSet();
                            ds = Obj_DataAccess.CheckAppointmentList(Obj);

                            if (ds.Tables[0].Rows.Count == 0)
                            {


                                ds = Obj_DataAccess.SaveAppointment(Obj);
                                TempData["SwalMessage"] = "Your Appointment is saved.";
                                TempData["SwalType"] = "success";

                                return RedirectToAction("Aptlist", "Appointments");
                            }
                            else
                            {
                                TempData["SwalMessage"] = "Your Appointment is already booked.";
                                TempData["SwalType"] = "error";

                                return RedirectToAction("CreateAppointment", "Appointments");

                            }
                        }
                        else
                        {
                            return RedirectToAction("CreateAppointment", "Appointments");
                        }

                    }
                    catch (Exception ex)
                    {
						TempData["SwalMessage"] = "An error occurred while processing your request.";
						TempData["SwalType"] = "error";

						return RedirectToAction("Error", "Home");

					}

                  


				}

            }
            else
            {
                ViewBag.Message = "Pls tryagain!";
                return RedirectToAction("CreateAppointment", "Appointments");
            }
            
        }

    }
}
