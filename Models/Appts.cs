using System.Data;

namespace Zencareservice.Models
{
    public class Appts
    {

        public DataSet MyDataSet { get; set; }
        public string PatientFirstName { get; set; }

        public string PatientLastName { get; set; }

        public string DoctorFirstName { get; set; }

        public string DoctorLastName { get; set; }

        public string PatientAge { get; set; }

        public string PatientGender { get; set; }

        public string Patientphoneno { get; set; }

        public string PState { get; set; }

        public string PCity { get; set; }

        public string PatientEmail { get; set; }

        public string PatientAddress1 { get; set; }

        public string PatientAddress2 { get; set; }


        public DateTime AptBookingDate { get; set; }

        public TimeSpan AptBookingTime { get; set; }

        public string? ReasonType { get; set; }

        public DateOnly? ReschduleAppointmentDate { get; set; }

        public TimeOnly? ReschdeuleAppointmentTime { get; set; }
    }
}
