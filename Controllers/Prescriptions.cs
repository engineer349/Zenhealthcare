using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using Zencareservice.Models;
using Zencareservice.Repository;

namespace Zencareservice.Controllers
{
    public class Prescriptions : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Prescrt(Prescs prc)
        {
            string UsrId = Request.Cookies["UsrId"];

            TempData["UserId"] = UsrId;

            string RCode = Request.Cookies["RCode"];

            TempData["RCode"] = RCode;

            if (string.IsNullOrEmpty(UsrId) || string.IsNullOrEmpty(RCode))
            {
                return RedirectToAction("PatientLogin", "Account");
            }
            else
            {

                DataAccess Obj_DataAccess = new DataAccess();
                DataSet ds = new DataSet();
                ds = Obj_DataAccess.GetPrescriptions(UsrId,RCode);

                var dataRows = (ds.Tables.Count > 1) ? ds.Tables[2].AsEnumerable() : Enumerable.Empty<DataRow>();

                ViewBag.YourDataList = new SelectList(dataRows, "PId", "PFname");
                

                var genderList = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Male", Value = "Male" },
                    new SelectListItem { Text = "Female", Value = "Female" },
                    new SelectListItem { Text = "Other", Value = "Other" }
                    // Add more options as needed
                };

                ViewBag.GenderList = genderList;

                var PList = new List<SelectListItem>();

                foreach (DataRow row in ds.Tables[2].Rows)
                {
                    var Patientname = new SelectListItem
                    {
                        Text = row["PFname"].ToString(),
                        Value = row["PId"].ToString()
                    };

                    PList.Add(Patientname);
                    ViewBag.PFname = PList;
                    ViewBag.SelectedValue = "patient FirstName";
                }


                foreach (DataRow row in ds.Tables[1].Rows)
         
                ViewBag.DataSet = ds.Tables[1];
                ViewBag.SelectedValue = "Ram";

                string dfname = ds.Tables[1].Rows[0]["DFname"].ToString();
                string dlname = ds.Tables[1].Rows[0]["DLname"].ToString();
                string DRCode = ds.Tables[1].Rows[0]["RCode"].ToString();
                TempData["RCode"] = DRCode;

                prc = new Prescs();
                {
                    prc.DoctorFirstName = dfname;
                    prc.DoctorLastName = dlname;

                }

            }
            return View(prc);
        }
      
        [HttpPost]
        public IActionResult CreatePrescription(Prescs Obj)
        {
            try
            {
                string pfname = Obj.PatientFirstName;
                string plname = Obj.PatientLastName;
                string dfname = Obj.DoctorFirstName;
                string dlname = Obj.DoctorLastName;
                string patage = Obj.PatientAge;
                string patgender = Obj.PatientGender;
                string patphoneno = Obj.Patientphoneno;
                

            }
            catch(Exception ex)
            {
                throw ex;
            }


           
            return View();
        }
        public IActionResult Prescedit()
        {

            return View();
        }

        public IActionResult Presclist() 
        {
            return View();
        }
    }
}
