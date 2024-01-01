using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace Zencareservice.Models
{
    public class Signup
    {

        public string ?RoleId { get; set; }
        public string ?RoleName { get; set; }

        public List<Signup> showlist { get; set; }

        public string UserId { get; set; }
        public int Age { get; set; }
        public string ?numeric1 { get; set; }

        public string ?numeric2 { get; set; }

        public string? numeric3 { get; set; }

        public string ?numeric4 { get; set; }

        public string ? numeric5 { get; set; }

        public int RId { get;set; }
        public string ?Rcode { get; set; }

        public string ? RCategory { get; set; }

        [Required(ErrorMessage = "Firstname required!")]
        [DataType(DataType.Text)]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "Firstname must be between 4 and 16 characters.")]
        public string ?Firstname { get; set; }

        [Required(ErrorMessage = "Lastname required!")]
        [DataType(DataType.Text)]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "Firstname must be between 4 and 16 characters.")]
        public string ?Lastname { get; set; }

        [Required(ErrorMessage = "Please enter Emailaddress")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Please enter a valid email address.")]
        public string? Email { get; set; }

        private const string PasswordRegexPattern =@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,16}$";

        [Required(ErrorMessage = "Password required")]
        [DataType(DataType.Password)]
        [RegularExpression(PasswordRegexPattern, ErrorMessage = "Password must be alphanumeric with at least one special character and be 8 to 16 characters long.")]
        public string ?Password { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm Password required")]
        [CompareAttribute("Password", ErrorMessage = "Password doesn't match.")]
        [RegularExpression(PasswordRegexPattern, ErrorMessage = "Password must be alphanumeric with at least one special character and be 8 to 16 characters long.")]

        public string ?Confirmpassword { get; set; }

        [Required(ErrorMessage = "ResetPassword required")]
        [DataType(DataType.Password)]
        [RegularExpression(PasswordRegexPattern, ErrorMessage = "Password must be alphanumeric with at least one special character and be 8 to 16 characters long.")]
        public string ?RPassword { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm ResetPassword required")]
        [CompareAttribute("Password", ErrorMessage = "Password doesn't match.")]
        [RegularExpression(PasswordRegexPattern, ErrorMessage = "Password must be alphanumeric with at least one special character and be 8 to 16 characters long.")]

        public string ?CRPassword { get; set; }

        [Required(ErrorMessage = "Enter Username")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Username must be between 6 and  10 characters.")]

        public string ?Username { get; set; }

        [Required(ErrorMessage = "Phonenumber required")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Please enter a valid 10-digit phone number using only numeric digits.")]
        public string ?Phonenumber { get; set; }

        [Required(ErrorMessage = "DOB required")]
        [DataType(DataType.Date)]

        public DateTime Dob { get; set; }

        public string ?Randomcode { get; set; }
        public int Status { get; set; }

        [Required(ErrorMessage = "Please select the agreeterms")]

        public bool agreeterm {get; set;}

  

    }
}
