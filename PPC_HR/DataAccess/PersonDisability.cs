
namespace PPC_HR.DataAccess
{
    public class PersonDisability
    {
        public short emplId { get; set; }
        public string disabSeries { get; set; }
        public string disabNumber { get; set; }
        public string msecDateFrom { get; set; }
        public string timeIssued { get; set; }
        public string disabilityDateFrom { get; set; }
        public string disabilityDateTo { get; set; }
        public string disabilityGroup { get; set; }
        public string reason { get; set; }
        public byte[] scancopy { get; set; }
    }
}
