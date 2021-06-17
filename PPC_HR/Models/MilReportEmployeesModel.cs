using PPC_HR.DataAccess;
using System.Collections.Generic;


namespace PPC_HR.Models
{
    public interface IMilReportEmployeesModel
    {
        List<MilReportEmployees> MilReportEmployeesList { get; set; }
    }

    public class MilReportEmployeesModel : IMilReportEmployeesModel
    {
        public List<MilReportEmployees> MilReportEmployeesList { get; set; }

        public MilReportEmployeesModel()
        {
            MilReportEmployeesList = new DataReceiveService().GetMilReportEmployees();
            for (short pers = 0; pers < MilReportEmployeesList.Count; pers++)
            {
                MilReportEmployeesList[pers].idx = (short)(pers + 1);
            }
        }
    
    }
}
