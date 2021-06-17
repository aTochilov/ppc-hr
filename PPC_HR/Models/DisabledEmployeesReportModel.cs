using PPC_HR.DataAccess;
using System.Collections.Generic;


namespace PPC_HR.Models
{
    public interface IDisabledEmployeeReportModel
    {
        List<DisabledEmployeeReport> DisabledEmployeeReports { get; set; }
    }

    public class DisabledEmployeesReportModel : IDisabledEmployeeReportModel
    {
        public List<DisabledEmployeeReport> DisabledEmployeeReports { get; set; }

        public DisabledEmployeesReportModel()
        {
            DisabledEmployeeReports = new DataReceiveService().GetDisabledEmployeesReport();
            for (short pers = 0; pers < DisabledEmployeeReports.Count ; pers++)
            {
                DisabledEmployeeReports[pers].idx = (short)(pers + 1);
                switch (DisabledEmployeeReports[pers].group)
                {
                    case "1": 
                        DisabledEmployeeReports[pers].group = "I";
                        break;
                    case "2":
                        DisabledEmployeeReports[pers].group = "II";
                        break;
                    case "3":
                        DisabledEmployeeReports[pers].group = "III";
                        break;
                }
            }
        }



    }
}
