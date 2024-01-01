using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Zencareservice.Models
{
    public class Appts
    {

        public DataSet MyDataSet { get; set; }

        public int AptId { get; set; }

        public string? RCode { get; set; }

        [Required]
        [MaxLength(100)]
        public string? AptCategory { get; set; }

        public int  Aptbookstatus { get;set;}
        public string ? Aptbookingstatusconfirm { get; set; }

        [Required]
        [MaxLength(255)]
        public string? PatientFirstName { get; set; }

        public string? PState { get; set; }

        public string? PCity { get; set; }

        [Required, MaxLength(255)]
        public string? PatientLastName { get; set; }

        [Required,MinLength(255)]
        public string? DoctorFirstName { get; set; }

        public string? DoctorLastName { get; set; }

        public string? DContact { get; set; }

        public string? DEmail { get; set; }

        public string? PatientAge { get; set; }

        [Required,MaxLength(255)]
        public string? PatientGender { get; set; }

        public string? Patientphoneno { get; set; }

        public List<Appts> showlist {get; set;}

        public string? PatientEmail { get; set; }

        public string ?PatientAddress1 { get; set; }

        public string ?PatientAddress2 { get; set; }

        [Required]       
        public DateTime AptBookingDate { get; set; }


        [Required]
        public string ? AptBookingTime { get; set; }

        public string? ReasonType { get; set; }

        public bool? Reschedule { get; set; }

        public  int Aptbookconfirm { get; set; }

        

        public DateTime? RescheduleAppointmentDate { get; set; }

        public TimeSpan? RescheduleAppointmentTime { get; set; }

        public string? SelectedState { get; set; }
        public string? SelectedCity { get; set; }
        public List<string>? States { get; set; }
        public List<string>? Cities { get; set; }
    }
    public class states
    {
        public int selectedvalue { get; set; }
    }
}
