using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Runtime.CompilerServices;
using Zencareservice.Models;
using Zencareservice.Repository;

namespace Zencareservice.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();

        }
        public IActionResult Dashboard( Dashboard Obj)
        {
            string UserId = Request.Cookies["UsrId"];

          

            string UsrName = Request.Cookies["UsrName"];

            string RoleName = Request.Cookies["Role"];


            if (string.IsNullOrEmpty(UserId) || string.IsNullOrEmpty(UsrName) || string.IsNullOrEmpty(RoleName))
            {
                return RedirectToAction("Login","Account");
            }
            else
            {
                Obj.UsrId = Convert.ToInt32(UserId);
                Obj.Role = RoleName;

                DataAccess Obj_DataAccess = new DataAccess();
                DataSet ds = new DataSet();
                ds = Obj_DataAccess.GetDashboardvalues(Obj);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string aptcount = Convert.ToString(ds.Tables[0].Rows[0]["AptCount"]);

                    ViewBag.Appointments = aptcount;

                    string regcount = Convert.ToString(ds.Tables[0].Rows[0]["RegisterCount"]);

                    ViewBag.Users = regcount;

                    string aptstatuscount = Convert.ToString(ds.Tables[0].Rows[0]["AptstatusCount"]);

                    ViewBag.AppointmentStatus = aptstatuscount;

                    string prescriptioncount = Convert.ToString(ds.Tables[0].Rows[0]["PrescriptionCount"]);

                    ViewBag.Prescriptions = prescriptioncount;
                }

                

            }
            return View();



        }
    }
}
