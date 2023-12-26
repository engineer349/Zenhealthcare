using System.Data;

namespace Zencareservice.Models
{
    public class Appts
    {

        public DataSet MyDataSet { get; set; }

        public int AptId { get; set; }

        public string? RCode { get; set; }

        public string? PatientFirstName { get; set; }

        public string? PState { get; set; }

        public string? PCity { get; set; }

        public string? PatientLastName { get; set; }

        public string? DoctorFirstName { get; set; }

        public string? DoctorLastName { get; set; }

        public string? PatientAge { get; set; }

        public string? PatientGender { get; set; }

        public string? Patientphoneno { get; set; }

        public List<Appts> showlist {get; set;}

        public string? PatientEmail { get; set; }

        public string ?PatientAddress1 { get; set; }

        public string ?PatientAddress2 { get; set; }

        
        public DateTime AptBookingDate { get; set; }

        public TimeSpan AptBookingTime { get; set; }

        public string? ReasonType { get; set; }

        public bool? Reschedule { get; set; }

        public bool ?Aptbookconfirm { get; set; }

        public DateOnly? RescheduleAppointmentDate { get; set; }

        public TimeOnly? RescheduleAppointmentTime { get; set; }

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
