using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Data;

namespace Zencareservice.Models
{
    public class Appts
    {

        public DataSet MyDataSet { get; set; }

        public int AptId { get; set; }

        public string? RCode { get; set; }

        [Required(ErrorMessage ="Pls Select Appointment Category!")]
        [MaxLength(100)]
        public string? AptCategory { get; set; }

        public int Aptbookstatus { get; set; }

        public string? Aptbookingstatusconfirm { get; set; }

        [Required(ErrorMessage ="Pls Enter the firstname!")]
        [MaxLength(255)]
        public string? PatientFirstName { get; set; }

        [Required, MaxLength(255)]
        public string? PatientLastName { get; set; }

        [Required(ErrorMessage ="SelectDoctor"), MinLength(255)]
        public string? DoctorFirstName { get; set; }

        [Required(ErrorMessage ="Pls Enter Age!")]
        public string? PatientAge { get; set; }
        
        [Required(ErrorMessage ="Pls select Gender!*"), MaxLength(255)]
        public string? PatientGender { get; set; }

        [Required(ErrorMessage ="Pls Enter MobileNo!"),MaxLength(10)]
        public string? Patientphoneno { get; set; }

        [Required(ErrorMessage ="Pls Enter Emailaddress!")]
        public string? PatientEmail { get; set; }

        [Required(ErrorMessage ="Choose AppointmentBookingDate!")]
        public DateTime AptBookingDate { get; set; }


        [Required(ErrorMessage ="Select AppointmentTime!")]
        public TimeSpan? AptBookingTime { get; set; }


        public DateTime? RescheduleAppointmentDate { get; set; }

        public TimeSpan? RescheduleAppointmentTime { get; set; }


        public string? ReasonType { get; set; }

        public string? PState { get; set; }


        public string? PCity { get; set; }

        public string? DoctorLastName { get; set; }

        public string? DContact { get; set; }

        public int UsrId { get; set; }

        public string? DEmail { get; set; }


        public List<Appts> showlist { get; set; }

        public string? PatientAddress1 { get; set; }

        public string? PatientAddress2 { get; set; }


        public bool? Reschedule { get; set; }

        public int Aptbookconfirm { get; set; }




    }

}
