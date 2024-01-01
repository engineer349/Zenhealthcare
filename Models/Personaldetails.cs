using Microsoft.AspNetCore.Components;
using System;
using System.ComponentModel.DataAnnotations;

namespace Zencareservice.Models
{
    public class Personaldetails
    {

        public int PId { get; set; }
       
        public int UsrId {  get; set; }

        public int RId { get ; set; }
      
        public int DExp { get; set; }

       
        public string specialistname { get; set; }
   
        public string DQualification { get; set; }


        public string Description { get; set; }
        public IFormFile File { get; set; }

        public string? RCode { get; set; }


        public string? Firstname { get; set; }

        public string? Lastname { get; set; }

        public string? Gender { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public string? Username { get; set; }

        public DateTime Dob { get; set; }

        public string? Phoneno { get; set; }

        public string? AltPhoneno { get; set; }

        public string? Address1 { get; set; }

        public string? Address2 { get; set; }

        public string? AltAddress { get; set; }

        public string? State { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public string? Zipcode { get; set; }

        public string? Uniqueid { get; set; }

        public string? Status { get; set; }

        public string? Role { get; set; }

        public int? GenderId { get; set; }

        public string? GenderName { get; set; }
        public string? SelectedState { get; set; }
        public string? SelectedCity { get; set; }
        public List<string>? States { get; set; }
        public List<string>? Cities { get; set; }
    }
    public class state
    {
        public int selectedvalue { get; set; }
    }
}
