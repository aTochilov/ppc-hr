
namespace PPC_HR.DataAccess
{
    public class PersonDiploma
    {
        public short diplomaId { get; set; }
        public short emplId { get; set; }
        public string diplomaSeries { get; set; }
        public string diplomaSerialNumber { get; set; }
        public string educationalLevel { get; set; }
        public string branch { get; set; }
        public string issueDate { get; set; }
        public string institution { get; set; }
        public bool pedEducation { get; set; }
    }
}
