<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Signup.aspx.cs" Inherits="Zenhealthcare.Signup" %>

<!DOCTYPE html>

<html>
<head runat="server">
      
      <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
      <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
      <title>Sign Up </title>
      <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous"/>
     
    
      <!-- Main css -->
      <link rel="stylesheet" href="~/css/loginstyle.css" />
      <link rel="stylesheet" href="~/css/termsofservice.css" />
      <link rel="stylesheet" href="~/css/site.css" />
      
</head>
<body>
   
    <div class="main">
      <section class="signup">
          <div class="container">
              <div class="signup-content">
                  <div class="signup-form">
                     <h3 class="form-title">Signup</h3>
                      <form  class="register-form" id="registerform" runat="server">
                          <div asp-validation-summary="ModelOnly" class="text-danger"></div>
                          <div class="form-group">        
                              <asp:TextBox ID="Firstname"  CssClass="form-control" runat="server" placeholder="Your FirstName" />
                          </div>
                          <div class="form-group">            
                              <asp:TextBox ID="Lastname" runat="server"  CssClass="form-control" placeholder="Your LastName" ></asp:TextBox>
                          </div>
                          <div class="form-group">                            
                          <asp:TextBox ID="Email" runat="server"  CssClass="form-control" placeholder="Your Email" pattern="^[a-zA-Z0-9._%+-]+[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" ></asp:TextBox>
                          </div>
                          <div class="form-group">
                              <asp:TextBox ID="Password" runat="server"  CssClass="form-control" placeholder="Password" pattern="^(?=.*[A-Za-z0-9])(?=.*[@@$!%*#?&]).{8,16}$" ></asp:TextBox>
                          </div>
                          <div class="form-group">
                              <asp:TextBox ID="CPassword" runat="server"  CssClass="form-control" placeholder="Confirm Password" pattern="^(?=.*[A-Za-z0-9])(?=.*[@@$!%*#?&]).{8,16}$" ></asp:TextBox>
                          </div>
                          <div class="form-group">
                             <asp:TextBox ID="Username" runat="server"  CssClass="form-control" placeholder="Password"  pattern="^(?=.*\d)[a-zA-Z\d]{1,6}$" ></asp:TextBox>
                          </div>
                          <div class="form-group">
                               <asp:TextBox  ID="Phonenumber" runat="server"   CSsClass="form-control" placeholder="Phone Number"  pattern="[0-9]{10}"></asp:TextBox>                                                
                          </div>
                          <div class="form-group">

                       
                              <asp:TextBox ID="DoB" CssClass="form-control" runat="server" Placeholder="DOB"></asp:TextBox>
                             
                          </div>
                        <div class="form-group">
                           <asp:DropDownList ID="Rple" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Select Role" Value="select" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="Admin" Value="Doctor"></asp:ListItem>
                            <asp:ListItem Text="Doctor" Value="Doctor"></asp:ListItem>
                            <asp:ListItem Text="Patien" Value="Patient"></asp:ListItem>
                        </asp:DropDownList>
                          </div> 
                          <div>
                             
                          </div>
                          <div class="form-group">
                              <asp:CheckBox ID="agreeterm" runat="server" />

                              <label asp-for="agreeterm" class="label-agree-term">
                                  <span><span></span></span>
                                  I agree all statements in  <a href="~/forms/termsofservice.html" data-toggle="modal" data-target="#termsModal">Terms of service</a>
                              </label>
                          </div>           

                          <div class="form-group form-button">
                           
                              <asp:Button ID="Register" runat="server" Text="Register" class="form-submit btn btn-primary" name="Register" />
                          </div>
                      </form>
                  </div>
                  <div class="signup-image">
                      <figure><img src="images/signin-zencare.png" alt="sing up image" asp-append-version="true"/></figure>
                      <a class="signup-image-link" href="Login.aspx">I am already member</a>
                  </div>
              </div>
          </div>
      </section>
  </div>
    <div class="modal" id="termsModal" tabindex="-1" role="dialog">
      <div class="modal-dialog" role="document">
          <div class="modal-content">
              <div class="modal-header" style="background-color:azure">
                  <h2 class="modal-title">Terms of Service</h2>
                  <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                      <span aria-hidden="true" class="custom-close-btn">&times;</span>
                  </button>
              </div>
              <div class="modal-body" style="background-color:azure">
                  <!-- Your Terms of Service content goes here -->
                  <h1>Zenhealthcare System Portal Privacy Policy</h1>

                  <p>Effective Date: Nov 25, 2022</p>
                  <p>Revised Date: Dec 2, 2023</p>

                  <h1>Overview</h1>

                  <p>We are committed to protecting your privacy and the security of the information you entrust with us. This privacy policy (Policy) discloses our information gathering and dissemination practices. Your use of Zenhealthcare System Portal is governed by the terms of this Policy, and by using or accessing Zenhealthcare System Portal you agree to be bound by it.</p>

                  <h1>How the Health Information in Zenhealthcare System Portal is Obtained</h1>

                  <p>Zenhealthcare System Portal provides a view into your Electronic Medical Record (EMR) which is maintained by us and also allows us to communicate securely with you. The information available for you to view through Zenhealthcare System Portal is not a comprehensive view of all the data in your EMR.</p>

                  <p>Zenhealthcare System Portal maintains limited information about you, such as your name, date of birth, and medical record number. Your personal health information is not separately maintained or managed through Zenhealthcare System Portal.</p>

                  <p>Zenhealthcare System Portal uses your Cerner Health account to confirm your identity when you sign into Zenhealthcare System Portal. Cerner Health is a personal health record service and is subject to its own Terms of Use and Privacy Policy.</p>

                  <h1>Information You Contribute to Zenhealthcare System Portal</h1>

                  <p>When you enter information in Zenhealthcare System Portal, that information is stored in your EMR where it is accessible to members of your care team and staff. Information that becomes a part of your EMR remains in your EMR even if you stop using Zenhealthcare System Portal.</p>

                  <h1>Sharing Your Personal Health Information</h1>

                  <p>If you share information available through Zenhealthcare System Portal with another individual, you acknowledge and accept responsibility for your decision to provide them access to potentially sensitive information.</p>

                  <h1>How Information is Collected and Used</h1>

                  <p>Zenhealthcare System Portal collects certain information from you in three ways: (i) from web server logs, (ii) with cookies and web analytics tools, and (iii) directly from you.</p>

                  <h1>(a) IP Addresses (Server Log Information)</h1>

                  <p>An IP address is a number automatically assigned to your computer whenever you access the Internet. All computer identification on the Internet is conducted with IP addresses, which allow computers and servers to recognize and communicate with each other. Zenhealthcare System Portal collects IP addresses in order to conduct system administration, report Aggregate Information (as defined below) to affiliates or partners, and to conduct web site analysis. Security monitoring is in place and reviewed on a constant basis in order to identify users who threaten the Zenhealthcare System Portal service, web site, users, clients or others.</p>

                  <h1>(b) Cookies and Web Analytics Tools.</h1>

                  <p>Zenhealthcare System Portal places a text file called a 'cookie' in the browser files of your computer. Cookies are pieces of information that a website transfers to an individual's hard disk for record-keeping purposes. Zenhealthcare System Portal uses cookies during your online session, secure your information, and improve performance of Zenhealthcare System Portal. These cookies do not contain any personal information. You may disable cookies in your browser but doing so will restrict your access to only public pages and you will no longer be able to access Zenhealthcare System Portal. In addition to cookies, some web analytics tools used by Zenhealthcare System Portalplace a single-pixel GIF file

              </div>
              <div class="modal-footer" style="background-color:azure">
                  <button type="button" class="btn btn-primary" data-dismiss="modal">Accept and Close</button>
              </div>
          </div>
      </div>
  </div>

</body>


<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.6.0/jquery.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validate/1.19.3/jquery.validate.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery-validation-unobtrusive/3.2.12/jquery.validate.unobtrusive.js"></script>

<script type="text/javascript">

    $(document).ready(function () {
        $('#email').on('blur', function () {
            var emailAddress = $(this).val();

            if (isValidEmailAddress(emailAddress)) {
                $('#email-validation-mark').addClass('active');
            } else {
                $('#email-validation-mark').removeClass('active');
            }
        });

        function isValidEmailAddress(emailAddress) {
            // Implement email validation logic here
            return true; // Replace with actual validation
        }
    });

</script>

<script type="text/javascript">
    function validateForm() {

        // var checkbox = document.getElementById("agree-term");

        // if (!checkbox.checked)
        // {
        //         swal("!Please agree to the Terms of Service.");
        //         return false; // Prevent form submission
        // }
        // Validate Firstname
        var firstname = document.getElementById("firstname").value.trim();
        if (firstname === "") {
            swal("First name cannot be empty.");
            return false;
        }
        if (!/^[a-zA-Z]{4,16}$/.test(firstname)) {
            swal("First name must contain only letters and be between 4 and 16 characters.");
            return false;
        }

        var lastname = document.getElementById("lastname").value.trim();
        if (lastname === "") {
            swal("Last name cannot be empty.");
                return false;
        }
        if (!/^[a-zA-Z]{4,16}$/.test(lastname)) {
            swal("Last name must contain only letters and be between 4 and 16 characters.");
            return false;
        }
        // Validate Password
        var password = document.getElementById("pass").value.trim();
        if (password === "") {
            swal("Password cannot be empty.");
            return false;
        }
        if (!/^(?=.*[A-Za-z\d])(?=.*[$!%*#?&]).{8,16}$/.test(password)) {
            swa("Password must be at least 8 characters long, alphanumeric, and contain at least one special character.");
            return false;
        }

        // Validate Email
        var email = document.getElementById("email").value.trim();
        if (email === "") {
            swal("Email cannot be empty.");
            return false;
        }
        if (!/^[a-zA-Z0-9._%+-]+(gmail\.com|yahoo\.com|redhat\.com|[a-zA-Z0-9.-]+\.(com|edu|org))$/.test(email)) {
            swal("Please enter a valid email address with the specified domains.");
            return false;
        }

        // Validate Username
        var username = document.getElementById("username").value.trim();
        if (username === "") {
            swal("Username cannot be empty.");
            return false;
        }
        if (!/^[a-zA-Z0-9]{6,10}$/.test(username)) {
            swal("Username must be alphanumeric and between 6 and 10 characters.");
            return false;
        }

        // If all validations pass, return true to allow form submission
        return true;
    }
</script>

</html>
