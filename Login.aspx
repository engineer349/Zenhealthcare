<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Zenhealthcare.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
     <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
     <meta http-equiv="X-UA-Compatible" content="ie=edge"/>
     <meta name="google-signin-client_id" content="YOUR_CLIENT_ID.apps.googleusercontent.com"/>
     
     <title>Login</title>

     <!-- Font Icon -->
     <link rel="stylesheet" href="~/fonts/material-icon/css/material-design-iconic-font.min.css"/>

     <!-- Main css -->
     <link rel="stylesheet" href="~/css/loginstyle.css"/>
  
</head>
<body>
    <div class="main">
        <section class="sign-in">
            <div class="container">
                <div class="signin-content">
                    <div class="signin-image">
                        <figure>
                            <img src="images/signin-zencare.png" alt="login image" /></figure>
                             <a href="Signup.aspx" class="signup-image-link">Create an account</a>
                             <a href="ForgotPassword" class="signup-image-link">Forgot Password/Reset Password</a>"
                    </div>

                    <div class="signin-form">
                        <h2 class="form-title">Login</h2>
                        <form class="register-form" id="loginform" runat="server">

                            <div class="form-group">

                                <asp:TextBox ID="username" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>
                            <div class="form-group">

                                <asp:TextBox ID="password" runat="server" CssClass="form-control"></asp:TextBox>

                            </div>

                            <div class="form-group form-button">

                                <asp:Button ID="signin" runat="server" Text="Signin" CssClass="form-submit" />

                            </div>
                            <div class="social-login">
                                <span class="social-label">Or login with</span>
                                <div class="g-signin2" data-onsuccess="onSignIn"></div>
                            </div>
                        </form>

                    </div>
                </div>
            </div>
        </section>
    </div>
    <script src="https://apis.google.com/js/platform.js" async defer></script>
    <script>
        function onSignIn(googleUser) {
            var profile = googleUser.getBasicProfile();
            console.log('ID: ' + profile.getId()); // Do not send to your backend! Use an ID token instead.
            console.log('Name: ' + profile.getName());
            console.log('Image URL: ' + profile.getImageUrl());
            console.log('Email: ' + profile.getEmail()); // This is null if the 'email' scope is not present.
        }
    </script>

    <script>
        function signOut() {
            var auth2 = gapi.auth2.getAuthInstance();
            auth2.signOut().then(function () {
                console.log('User signed out.');
            });
        }
    </script>
    <script>
        function alert() {
            Swal.fire({
                title: "Good job!",
                text: "You clicked the button!",
                icon: "success"
            });
        }

    </script>
</body>
</html>
