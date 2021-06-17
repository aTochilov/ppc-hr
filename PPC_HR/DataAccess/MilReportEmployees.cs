
namespace PPC_HR.DataAccess
{

    public interface IMilReportEmployees
    {
        short idx { get; set; }
        short id { get; set; }
        string personInfo { get; set; }
        string birthDate { get; set; }
        string milRank { get; set; }
        string emplAddress { get; set; }
        string position { get; set; }

    }

    public class MilReportEmployees : IMilReportEmployees
    {
        public short idx { get; set; }
        public short id { get; set; }
        public string personInfo { get; set; }
        public string birthDate { get; set; }
        public string milRank { get; set; }
        public string emplAddress { get; set; }
        public string position { get; set; }

    }
}
