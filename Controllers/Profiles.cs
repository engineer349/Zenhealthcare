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

            string RCode = Request.Cookies["RCode"];

            if (string.IsNullOrEmpty(UsrId) || string.IsNullOrEmpty(RCode))
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
                ViewBag.YourDataList = new SelectList(dataRows, "specialistid", "specialistname");
				


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

                var doctorspecialist = new List<SelectListItem>();


                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    var specialistitem = new SelectListItem
                    {
                        Text = row["specialistname"].ToString(),
                        Value = row["specialistid"].ToString()
                    };

                    doctorspecialist.Add(specialistitem);
                }



                foreach (DataRow row in ds.Tables[1].Rows)
               
                ViewBag.specialistname = doctorspecialist;
                ViewBag.State = StateList;
                ViewBag.GenderList = genderList;              
                ViewBag.DataSet = ds.Tables[1];
                ViewBag.SelectedValue = "Tamil Nadu";

                string fname = ds.Tables[0].Rows[0]["Fname"].ToString();
                string lname = ds.Tables[0].Rows[0]["Lname"].ToString();              
                string phoneno = ds.Tables[0].Rows[0]["Phoneno"].ToString();
                string email = ds.Tables[0].Rows[0]["Email"].ToString();
                string gender = ds.Tables[0].Rows[0]["Gender"].ToString();
                string address1 = ds.Tables[0].Rows[0]["Addressline1"].ToString();
                string address2 = ds.Tables[0].Rows[0]["Addressline2"].ToString();
                string altaddress = ds.Tables[0].Rows[0]["AltAddress"].ToString();
                string altphoneno = ds.Tables[0].Rows[0]["Aphoneno"].ToString();
                string uniqueid = ds.Tables[0].Rows[0]["UniqueId"].ToString();
                string zipcode = ds.Tables[0].Rows[0]["Zipcode"].ToString();
                string state = ds.Tables[0].Rows[0]["State"].ToString();
                int sid = Convert.ToInt32( ds.Tables[0].Rows[0]["SId"]);
                string city = ds.Tables[0].Rows[0]["City"].ToString();
                string country = ds.Tables[0].Rows[0]["Country"].ToString();
                string Role = ds.Tables[0].Rows[0]["Role"].ToString();
                TempData["Role"] = Role;

				if(!String.IsNullOrEmpty(city))
                {
                    ViewBag.Citymsg = city;
					DataAccess Obj_DataAccess2 = new DataAccess();
					DataSet ddd = new DataSet();
					ddd = Obj_DataAccess2.SetCity(sid);

					ViewBag.YourDataList = new SelectList(dataRows, "CId", "City");
					var CityList = new List<SelectListItem>();


					foreach (DataRow row in ddd.Tables[0].Rows)
					{
						var CityItem = new SelectListItem
						{
							Text = row["City"].ToString(),
							Value = row["CId"].ToString()
						};

						CityList.Add(CityItem);
					}
					ViewBag.City = CityList;
				}


				pers = new Personaldetails();
                {
                    pers.Firstname = fname;
                    pers.Lastname = lname;
                    pers.Phoneno = phoneno;
                    pers.Email = email;
                    pers.Address1 = address1;
                    pers.Gender = gender;
                    pers.Address2 = address2;
                    pers.AltPhoneno = altphoneno;
                    pers.Uniqueid = uniqueid;
                    pers.Zipcode = zipcode;
                    pers.AltAddress = altaddress;
                    pers.Country = country;
                    pers.State = state;
                    pers.City = city;

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
            ViewBag.Citymsg = null;
            string cities = JsonConvert.SerializeObject(ddd.Tables[0]);
            return Json(cities);
        }

        [HttpPost]
        public IActionResult UpdateProfile(Personaldetails Obj)
        {
                      
            try
            {
                if (Obj.File != null && Obj.File.Length > 0)
                {
                    // Read the file content into a byte array
                    byte[] fileContent;
                    using (var stream = Obj.File.OpenReadStream())
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);
                            fileContent = memoryStream.ToArray();
                        }
                    }
                }
                    Obj.UsrId = Convert.ToInt32(TempData["UserId"]);
                    Obj.Role = Convert.ToString( TempData["Role"]);
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
                    ds = Obj_DataAccess.UpdateProfile(Obj);
                
            }

            catch(Exception ex)
            {
                throw ex;
            }

            return RedirectToAction("Userlist","Profiles");



        }


        public IActionResult Userlist(Signup user)
        {
            string UsrId = Request.Cookies["UsrId"];

            TempData["UserId"] = UsrId;

            string Role = Request.Cookies["Role"];

            if (string.IsNullOrEmpty(UsrId) || string.IsNullOrEmpty(Role))
            {
                return RedirectToAction("Login", "Account");
            }

            else
            {
                DataAccess Obj_DataAccess = new DataAccess();
                DataSet ds = new DataSet();
                ds = Obj_DataAccess.GetUserList(Role);



                List<Signup> UserList = new List<Signup>();

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string Employeecode  = ds.Tables[0].Rows[0]["RCode"].ToString();
                    string RegFirstname = ds.Tables[0].Rows[0]["Fname"].ToString();
                    string RegLastname = ds.Tables[0].Rows[0]["Lname"].ToString();                    
                    string RegEmail = ds.Tables[0].Rows[0]["Email"].ToString();
                    string RegPhoneno = ds.Tables[0].Rows[0]["Phoneno"].ToString();                   



                    Signup reg = new Signup();
                    {
                        reg.Rcode = Employeecode ;
                        reg.Firstname = RegFirstname;
                        reg.Lastname = RegLastname;
                        reg.Email = RegEmail;
                        reg.Phonenumber = RegPhoneno;
                        

                    };
                    UserList.Add(reg);
                }
                user.showlist = UserList;

            }


            return View(user);

        }

    }
}
