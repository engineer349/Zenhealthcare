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
using System.Xml.Linq;
using System.Net.Sockets;
using Zencareservice.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.DataProtection;

namespace Zencareservice.Controllers
{

    public class AccountController : Controller
    {

        //private readonly TwilioService _twilioService;
        private readonly IDataProtector _dataProtector;


        private int _generatedOtp;

        private string? ResetEmail;

        private readonly DataAccess _dataaccess;

        private readonly SqlDataAccess _sqldataaccess;

        public AccountController(DataAccess dataaccess, SqlDataAccess sqldataaccess, IDataProtectionProvider dataProtectionProvider)
        {
            _dataaccess = dataaccess;
            _sqldataaccess = sqldataaccess;
            _dataProtector = dataProtectionProvider.CreateProtector("YourPurpose");
        }

        public IActionResult Index()
        {

            ViewBag.Message = "Your Details are successfully saved!";

            return View("RegistrationSuccess", "Account");
        }

        public IActionResult AdminRegister()
        {
            return View();
        }

        public IActionResult URegister()
        {
            string returnUrl = "/Account/URegister";
            ViewData["ReturnUrl"] = returnUrl;

            ViewBag.Roles = new SelectList(roles, "RoleId", "RoleName");

            return View();
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Register()
        {
            string returnUrl = "/Account/Register";
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        public IActionResult PatientRegister()
        {
            string returnUrl = "/Account/PatientRegister";
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        public IActionResult Login()
        {
            ViewBag.Message = "Your LoginPage is loaded";
            return View();
        }
        public IActionResult PatientLogin()
        {
            string returnUrl = "/Account/PatientLogin";
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        public IActionResult PatForgot()
        {
            string returnUrl = "/Account/PatForgot";
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        public IActionResult PatReset()
        {
            string returnUrl = "/Account/PatReset";
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        public IActionResult ResetPassword()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {

            return View();
        }

        public IActionResult VerifyOtp()
        {
            string gotp = Request.Cookies["OTP"];

            ViewBag.Message = gotp;

            if (string.IsNullOrEmpty(gotp))
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            HttpContext.Session.SetString("AccessDenied", DateTime.Now.AddMinutes(1).ToString());

            var myemail = TempData["MyEmail"];

            return View();
        }


        public IActionResult ValidateOtp(Signup model)
        {


            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(model.numeric1);
            stringBuilder.Append(model.numeric2);
            stringBuilder.Append(model.numeric3);
            stringBuilder.Append(model.numeric4);
            stringBuilder.Append(model.numeric5);


            string enteredOtp = stringBuilder.ToString();

            if (TempData.TryGetValue("GOTP", out var gotp))
            {

                

                string _genotp = Convert.ToString(ViewBag.Message);

                if (Convert.ToInt64(enteredOtp) == Convert.ToInt64(_genotp))
                {

                    ViewBag.Message = "SuccessfullyValidated";


                    return RedirectToAction("Dashboard", "Report");

                }
                else
                {
                    ViewBag.Message = "You entered Wrong PIN";

                    return RedirectToAction("Index", "Home");
                }

            }

            return View("Login");

        }



        private List<Signup> roles = new List<Signup>
        {
           
            new Signup { RoleId = "Doctor", RoleName = "Doctor" },
            new Signup {RoleId = "Staff", RoleName = "Staff"},
        };


        [HttpPost]
        public IActionResult ResetPassword(Signup Obj)
        {
            string ResetPassword = Obj.RPassword;
            string ConfirmResetPassword = Obj.CRPassword;

            if (TempData.TryGetValue("ResetData", out var myresetData))
            {
                ViewBag.Message = myresetData;

                string ResetEmail = Convert.ToString(ViewBag.Message);

                string AllData = Convert.ToString(ViewBag.AllData);

                if (!string.IsNullOrEmpty(ResetPassword) && !string.IsNullOrEmpty(ConfirmResetPassword))
                {
                    DataAccess Obj_DataAccess = new DataAccess();
                    DataSet ds = new DataSet();
                    ds = Obj_DataAccess.ResetPassword(Obj, ResetEmail);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(Signup obj)
        {
            string ResetEmail = obj.Email;

            if (ResetEmail != null)
            {
                TempData["ResetData"] = ResetEmail;
                string generatedCode = Codegenerator();
                _generatedOtp = Convert.ToInt32(generatedCode);

                return RedirectToAction("Login", "Account");
            }

            return View();


        }


        public IActionResult ResendEmail(Signup Obj)
        {
            string generatedCode = Codegenerator();
            _generatedOtp = Convert.ToInt32(generatedCode);

            if (TempData.TryGetValue("MyEmail", out var myEmail))
            {

                ViewBag.Message = myEmail;
                Obj.Email = Convert.ToString(ViewBag.Message);

                SendMail sendMail = new SendMail();
                SmtpClient client = new SmtpClient();

                string mail = sendMail.EmailSend("zenhealthcareservice@gmail.com", Obj.Email, "lamubclwmhfjwjjs", "Autoverification", "Your Zencareservice signup Account OTP verification of Email is " + +_generatedOtp, "smtp.gmail.com", 587);

                return RedirectToAction("VerifyOtp", "Account");
            }
            else
            {
                return RedirectToAction("Register", "Account");
            }

        }

        private bool IsDateOfBirthValid(DateTime dob)
        {


            // Ensure the user is at least 18 years old
            return dob.AddYears(18) <= DateTime.Now && dob > DateTime.Now.AddYears(-100); // Assuming a reasonable upper limit for age

        }

        private int CalculateAge(DateTime dob)
        {
            // Calculate age based on the difference between the current date and the date of birth
            int age = DateTime.Now.Year - dob.Year;

            // Adjust age if the birthday hasn't occurred yet this year
            //if (dob > DateTime.Now.AddYears(-age))
            //{
            //age--
            //}

            return age;
        }

        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        private string Codegenerator()
        {
            Random random = new Random();
            int randomCode = random.Next(10000, 100000);
            _generatedOtp = randomCode;
            TempData["GOTP"] = _generatedOtp;

            return _generatedOtp.ToString();

        }

        private static byte[] BytesFromString(string str)
        {
            return Encoding.ASCII.GetBytes(str);
        }

        private static int GetResponseCode(string ResponseString)
        {
            return int.Parse(ResponseString.Substring(0, 3));
        }

        private static bool IsEmailAccountValid(string tcpClient, string emailAddress)
        {
            TcpClient tClient = new TcpClient(tcpClient, 25);
            string CRLF = "\r\n";
            byte[] dataBuffer;
            string ResponseString;
            NetworkStream netStream = tClient.GetStream();
            StreamReader reader = new StreamReader(netStream);
            ResponseString = reader.ReadLine();

            /* Perform HELO to SMTP Server and get Response */
            dataBuffer = BytesFromString("HELO Hi" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            ResponseString = reader.ReadLine();
            dataBuffer = BytesFromString("MAIL FROM:<YourGmailIDHere@gmail.com>" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            ResponseString = reader.ReadLine();

            /* Read Response of the RCPT TO Message to know from google if it exist or not */
            dataBuffer = BytesFromString($"RCPT TO:<{emailAddress}>" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            ResponseString = reader.ReadLine();
            var responseCode = GetResponseCode(ResponseString);

            if (responseCode == 550)
            {
                return false;
            }

            /* QUITE CONNECTION */
            dataBuffer = BytesFromString("QUITE" + CRLF);
            netStream.Write(dataBuffer, 0, dataBuffer.Length);
            tClient.Close();
            return true;
        }
        [HttpPost]
        public IActionResult PatientRegister(Signup Obj, string returnUrl)
        {

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {

                // Perform additional validation
                if (IsDateOfBirthValid(Obj.Dob))
                {

                    int userAge = CalculateAge(Obj.Dob);


                    bool agreeToTerms = true;


                    if (agreeToTerms == true)
                    {

                        var gMail = IsEmailAccountValid("gmail-smtp-in.l.google.com", Obj.Email);

                        if (gMail == true)
                        {
                            DataAccess Obj_DataAccess = new DataAccess();
                            DataSet dse = new DataSet();
                            dse = Obj_DataAccess.CheckEmail(Obj);



                            if (dse.Tables[0].Rows.Count == 0 && dse.Tables[1].Rows.Count == 0)
                            {

                                try
                                {
                                    string validemail = Obj.Email;
                                    TempData["MyEmail"] = validemail;



                                    //Console.WriteLine($"Gmail account is valid - {gMail.ToString()}");

                                    // var live = IsEmailAccountValid("live-com.olc.protection.outlook.com", "aa.aa@live.com");
                                    //Console.WriteLine($"Live account is valid - {live.ToString()}");

                                   
                                    Obj.RoleId = "Patient";
                                    if (Obj.RoleId == "Patient")
                                    {
                                        Obj.RCategory = "Patient";
                                    }
                                    else if (Obj.RoleId == "Doctor")
                                    {
                                        Obj.RCategory = "Employee";
                                    }
                                    else
                                    {
                                        Obj.RCategory = "Employee";
                                    }
                                    Obj.Age = userAge;
                                    int agreeterms = Convert.ToInt32(Obj.agreeterm);
                                    string fname = Obj.Firstname;
                                    string lname = Obj.Lastname;
                                    string password = Obj.Password;
                                    string confirmpassword = Obj.Confirmpassword;
                                    string username = Obj.Username;
                                    string phoneno = Obj.Phonenumber;

                                    DateTime Dob = Obj.Dob;
                                    Obj.Status = 1;

                                    if (!String.IsNullOrEmpty(validemail))
                                    {

                                        string generatedCode = Codegenerator();

                                        _generatedOtp = Convert.ToInt32(generatedCode);
                                        CookieOptions options = new CookieOptions();
                                        options.Expires = DateTime.Now.AddMinutes(2);
                                        Response.Cookies.Append("OTP", generatedCode, options);

                                    }

                                    SendingEmail(Obj);


                                    DataAccess Obj_DataAccess2 = new DataAccess();
                                    DataSet ds = new DataSet();
                                    ds = Obj_DataAccess2.SaveRegister(Obj);

                                    return RedirectToAction("VerifyOtp", "Account");




                                }


                                catch (Exception ex)
                                {
                                    string msg = ex.Message.ToString();
                                    ViewBag.Message = msg;
                                }
                            }
                            else
                            {
                                ViewBag.Message = "UserAlready Exsits";
                            }
                        }
                        else
                        {
                            TempData["Email"] = "InvalidUser";

                            ViewBag.Message = "Invalid Emailaddress UserAccount can't create.Pls Enter a valid email address!";

                            return View();

                        }

                    }
                    else
                    {
                        ModelState.AddModelError(nameof(Signup.agreeterm), "Pls  agree to terms of service and condition.");
                    }

                }
                else
                {
                    ModelState.AddModelError(nameof(Signup.Dob), "User must be at least 18 years old.");
                }
            }

            else
            {
                ViewBag.Message = "Pls tryagain!";
                return RedirectToAction("Index", "Home");
            }



            return View();


        }
        [HttpPost]
        public IActionResult URegister(Signup Obj, string returnUrl, DateTime userDob)
        {

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
            {

                ViewBag.Roles = new SelectList(roles, "RoleId", "RoleName");

                // Perform additional validation
                if (IsDateOfBirthValid(Obj.Dob))
                {
                    int userAge = CalculateAge(Obj.Dob);
                    bool agreeToTerms = true;

                    if (agreeToTerms == true)
                    {


                        var gMail = IsEmailAccountValid("gmail-smtp-in.l.google.com", Obj.Email);

                        if (gMail == true)
                        {
                            DataAccess Obj_DataAccess = new DataAccess();
                            DataSet dse = new DataSet();
                            dse = Obj_DataAccess.CheckEmail(Obj);

                            if (dse.Tables[0].Rows.Count == 0)
                            {

                                try
                                {
                                    string validemail = Obj.Email;
                                    TempData["MyEmail"] = validemail;



                                    //Console.WriteLine($"Gmail account is valid - {gMail.ToString()}");

                                    // var live = IsEmailAccountValid("live-com.olc.protection.outlook.com", "aa.aa@live.com");
                                    //Console.WriteLine($"Live account is valid - {live.ToString()}");


                                    string SelectedRoleId = Obj.RoleId;
                                    Obj.Age = userAge;
                                    
                                    if(Obj.RoleId == "Doctor")
                                    {
                                        Obj.RCategory = "Employee";
                                        Obj.Username = "Employee";
                                    }
                                    else if (Obj.RoleId == "Staff")
                                    {
                                        Obj.RCategory = "Employee";
                                        Obj.Username = "Employee";
                                    }
                                    else
                                    {
                                        Obj.RCategory = "Employee";
                                        Obj.Username = "Employee";
                                    }
                                    int agreeterms = Convert.ToInt32(Obj.agreeterm);
                                    string fname = Obj.Firstname;
                                    string lname = Obj.Lastname;
                                    string password = Obj.Password;
                                    string confirmpassword = Obj.Confirmpassword;                                 
                                    string phoneno = Obj.Phonenumber;

                                    DateTime Dob = Obj.Dob;
                                    Obj.Status = 1;

                                    if (!String.IsNullOrEmpty(validemail))
                                    {

                                        string generatedCode = Codegenerator();

                                        _generatedOtp = Convert.ToInt32(generatedCode);
                                        CookieOptions options = new CookieOptions();
                                        options.Expires = DateTime.Now.AddMinutes(2);
                                        Response.Cookies.Append("OTP", generatedCode, options);

                                    }

                                    SendingEmail(Obj);


                                    DataAccess Obj_DataAccess2 = new DataAccess();
                                    DataSet ds = new DataSet();
                                    ds = Obj_DataAccess2.SaveRegister(Obj);

                                    return RedirectToAction("VerifyOtp", "Account");




                                }


                                catch (Exception ex)
                                {
                                    string msg = ex.Message.ToString();
                                    ViewBag.Message = msg;
                                }
                            }
                            else
                            {
                                ViewBag.Message = "UserAlready Exsits";
								TempData["SwalMessage"] = "UserAlready Exsits";
								TempData["SwalType"] = "error";


							}
						}
                        else
                        {
                            TempData["Email"] = "InvalidUser";
							

							ViewBag.Message = "Invalid Emailaddress UserAccount can't create.Pls Enter a valid email address!";

							TempData["SwalMessage"] = "InvalidUser";
							TempData["SwalType"] = "error";
							return View();

                        }

                    }
                    else
                    {
                        ModelState.AddModelError(nameof(Signup.agreeterm), "Pls  agree to terms of service and condition.");
                    }

                }
                else
                {
                    ModelState.AddModelError(nameof(Signup.Dob), "User must be at least 18 years old.");
                }
            }
            else
            {
                ViewBag.Message = "Pls tryagain!";
                return RedirectToAction("Index", "Home");

            }
     
            return View();

    }
    
        [HttpPost]
        public IActionResult AdminRegister(Signup Obj)
        {

          
                // Perform additional validation
                if (IsDateOfBirthValid(Obj.Dob))
                {

                    int userAge = CalculateAge(Obj.Dob);

                    bool agreeToTerms = true;

                    if (agreeToTerms == true)
                    {

                        var gMail = IsEmailAccountValid("gmail-smtp-in.l.google.com", Obj.Email);

                        if (gMail == true)
                        {
                            DataAccess Obj_DataAccess = new DataAccess();
                            DataSet dse = new DataSet();
                            dse = Obj_DataAccess.CheckEmail(Obj);

                            if (dse.Tables[0].Rows.Count == 0)
                            {

                                try
                                {
                                    string validemail = Obj.Email;
                                    TempData["MyEmail"] = validemail;

                                    //string SelectedRoleId = "Admin";

                                    Obj.RoleId = "Admin";

                                    if (Obj.RoleId == "Admin")
                                    {
                                        Obj.RCategory = "Admin";
                                    }
                                    else if (Obj.RoleId == "Doctor")
                                    {
                                        Obj.RCategory = "Employee";
                                    }
                                    else
                                    {
                                        Obj.RCategory = "Patient";
                                    }


                                    Obj.Age = userAge;
                                    int agreeterms = Convert.ToInt32(Obj.agreeterm);
                                    string fname = Obj.Firstname;
                                    string lname = Obj.Lastname;
                                    string password = Obj.Password;
                                    string confirmpassword = Obj.Confirmpassword;
                                    string username = Obj.Username;
                                    string phoneno = Obj.Phonenumber;

                                    DateTime Dob = Obj.Dob;
                                    Obj.Status = 1;

                                    if (!String.IsNullOrEmpty(validemail))
                                    {

                                        string generatedCode = Codegenerator();

                                        _generatedOtp = Convert.ToInt32(generatedCode);
                                        CookieOptions options = new CookieOptions();
                                        options.Expires = DateTime.Now.AddMinutes(2);
                                        Response.Cookies.Append("OTP", generatedCode, options);

                                    }

                                    SendingEmail(Obj);


                                    DataAccess Obj_DataAccess2 = new DataAccess();
                                    DataSet ds = new DataSet();
                                    ds = Obj_DataAccess2.SaveRegister(Obj);

                                    return RedirectToAction("VerifyOtp", "Account");


                                }


                                catch (Exception ex)
                                {
                                    string msg = ex.Message.ToString();
                                    ViewBag.Message = msg;
                                    TempData["SwalMessage"] = msg;
								    TempData["SwalType"] = "error";


							}
						}
                            else
                            {
                                ViewBag.Message = "UserAlready Exsits";
							    TempData["SwalMessage"] = "User Exists!";
							    TempData["SwalType"] = "warning!";


						}
					}
                        else
                        {
                            TempData["Email"] = "InvalidUser";
                            ViewBag.Message = "Invalid Emailaddress UserAccount can't create.Pls Enter a valid email address!";
                            return View();

                        }

                    }
                    else
                    {
                        ModelState.AddModelError(nameof(Signup.agreeterm), "Pls  agree to terms of service and condition.");
                    }

                }
              
 
      


            return View();


        }




        private string SendingEmail(Signup Obj)
        {
            string FName = Obj.Firstname;
            SendMail sendMail = new SendMail();
            SmtpClient client = new SmtpClient();

            string mail = sendMail.EmailSend("zenhealthcareservice@gmail.com", Obj.Email, "lamubclwmhfjwjjs", "Autoverification", $@"



                        <!DOCTYPE html>

                        <html lang=""en"">
                        <head>
                            <meta charset=""UTF-8"">
                            <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                            <title>Email Verification</title>
                            <style>
                                body {{
                                    font-family: Arial, sans-serif;
                                    margin: 0;
                                    padding: 0;
                                    display: flex;
                                    flex-direction: column;
                                    justify-content: center;
                                    align-items: center;
                                    height: 100vh;
                                    background-color: #f4f4f4;
                                }}

                                .logo {{
                                    max-width: 200px;
                                    height: auto;
                                    margin-bottom: 20px;
                                }}

                                .verification-container {{
                                    background-color: #fff;
                                    padding: 20px;
                                    border-radius: 5px;
                                    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
                                    text-align: center;
                                }}

                                .verification-code {{
                                    font-size: 24px;
                                    font-weight: bold;
                                    color: #007bff;
                                    margin-bottom: 20px;
                                }}

                                .verification-instructions {{
                                    color: #555;
                                    margin-bottom: 20px;
                                }}

                                .verification-btn {{
                                    padding: 10px;
                                    background-color: #007bff;
                                    color: #fff;
                                    border: none;
                                    border-radius: 5px;
                                    cursor: pointer;
                                }}
                            </style>
                        </head>
                        <body>
                            <img src=""~/images/zencare-logo1.png"" alt=""Your Logo"" class=""logo"">
                            <div class=""verification-container"">
        
                                <h2>Hi {FName},</p>
                                <p>Thank you for using Zenhealthcareservice! </p>
                                <p>To ensure the security of your account, we have generated a One-Time Password (OTP) for you.</p>
                                <p class=""verification-code"">Your Verification Code:{_generatedOtp}</p>
                                <p class=""verification-instructions"">Please use the above code to verify your email address.</p>
        
                            </div>
                        </body>
                        </html>", "smtp.gmail.com", 587);
            return mail;

        }
        public IActionResult RegistrationSuccess()
        {
            return View();
        }


        public IActionResult GetDecryptedCookie()
        {
            var encryptedData = Request.Cookies["YourCookieName"];
            var userDataJson = _dataProtector.Unprotect(encryptedData);

            // Deserialize UserData from the JSON string
            var userData = JsonConvert.DeserializeObject<Signup>(userDataJson);

            // Use the userData.UserId, userData.UserName, userData.Role, userData.RCode as needed

            return View();
        }



        [HttpPost]
        public IActionResult Login(Login Obj)
        {
            string username = Obj.Username;
            string password = Obj.Password;

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {


                DataAccess Obj_DataAccess = new DataAccess();
                DataSet ds = new DataSet();
                ds = Obj_DataAccess.SaveLogin(Obj);

                int Status;

                if (ds.Tables[0].Rows.Count > 0)
                {

                    Status = Convert.ToInt32(ds.Tables[0].Rows[0]["LStatus"]);
                    if (Status == 1)
                    {
                        
                        string UsrId= ds.Tables[0].Rows[0]["RId"].ToString();

                        string UserName = ds.Tables[0].Rows[0]["Username"].ToString();

                        TempData["Username"] = Obj.Username;


                        string Email = ds.Tables[0].Rows[0]["Email"].ToString();

                        TempData["Email"] = Email;

                        string Role = ds.Tables[0].Rows[0]["Role"].ToString();

                        TempData["Role"] = Role;

                        string Fname = ds.Tables[0].Rows[0]["Fname"].ToString();

                        TempData["FirstName"] =  Fname;

                        string RCode = ds.Tables[0].Rows[0]["RCode"].ToString();

                        TempData["RCode"] = RCode;



                        //var userData = new Signup
                        //{
                        //    UserId = UsrId,
                        //    Rcode = RCode, // Replace with actual user data
                        //    Email = Email,
                        //    RoleName = Role,// Replace with actual user data
                        //    Firstname = Fname
                        //};

                        //var userDataJson = JsonConvert.SerializeObject(userData);

                        //var protectedData = _dataProtector.Protect(userDataJson);


                        var cookieOptions = new CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(1), // Set the expiration date
                            HttpOnly = true, // Makes the cookie accessible only to the server-side code
                        };

                        //Response.Cookies.Append("EncryptCookie", protectedData, new CookieOptions
                        //{
                        //    HttpOnly = true,
                        //    Secure = true,
                        //    SameSite = SameSiteMode.None,
                        //    Expires = DateTimeOffset.Now.AddDays(1)

                        //});
                        Response.Cookies.Append("MyCookie", "CookieValue", cookieOptions);

                        Response.Cookies.Append("UserId", UsrId);
                        CookieOptions options = new CookieOptions();
                        options.Expires = DateTime.Now.AddMinutes(5);

                        Response.Cookies.Append("UsrName", UserName, options);
                        CookieOptions options1 = new CookieOptions();
                        options.Expires = DateTime.Now.AddMinutes(5);

                        Response.Cookies.Append("Role", Role, options);
                        CookieOptions options2 = new CookieOptions();
                        options.Expires = DateTime.Now.AddMinutes(5);

                        Response.Cookies.Append("RCode", RCode, options);
                        CookieOptions options3 = new CookieOptions();
                        options.Expires = DateTime.Now.AddMinutes(5);

                        Response.Cookies.Append("UsrId", UsrId, options1);

                        HttpContext.Session.SetString("FirstName", Fname);

                        string jsonString = JsonConvert.SerializeObject(ds.Tables[1]);


                        HttpContext.Session.SetString("MenuList", jsonString);


                        ViewBag.ShowAlert = true;
                        ViewBag.AlertMessage = "Login successful!";
                        ViewBag.AlertType = "success";


                        return RedirectToAction("Dashboard", "Report");
                        
						//if (Role == "Doctor")
						//{

						//	return RedirectToAction("DashboardDoctor", "Report");
						//}


					}
                }
            }
            else
            {
                return View();

            }

            return View(); 

        }

       


        [ValidateAntiForgeryToken]
		public IActionResult Logout()
		{
			// Implement logout logic

			// Clear authentication cookies
			HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			// Redirect to the home page or another appropriate page
			return RedirectToAction("Index", "Home");
		}
	}
}
