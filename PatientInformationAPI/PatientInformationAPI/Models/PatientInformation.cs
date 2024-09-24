using Microsoft.VisualBasic;

namespace PatientInformationAPI.Models
{
    public class PatientInformation
    {
        public int IdNo { get; set; }
        public string MobileNo { get; set; }
        public string MRNo { get; set; }
        public string oldfileNo { get; set; }
        public string PatientName { get; set; }
        public string Gender { get; set; }
        public string PatientFlag { get; set; }
        public string DOB { get; set; }
        public string HijriDOB { get; set; }
        public string Age { get; set; }
        public string Nationality { get; set; }
        public string EmailID { get; set; }
        public string RegisteredBranch { get; set; }
        public string PatientAddress { get; set; }
        public string HowDoYouHeardAboutUs { get; set; }
    }
}
