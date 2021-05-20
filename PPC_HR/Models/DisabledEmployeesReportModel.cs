using PPC_HR.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPC_HR.Models
{
    public interface IDisabledEmployeeReportModel
    {
        List<DisabledEmployeeReport> DisabledEmployeeReports { get; set; }
        event EventHandler<DisabledEmployeesEventArgs> DisabledEmployeesUpdated;
        void UpdateReportDisabledEmployees(DisabledEmployeeReport employeeReport);
    }

    public class DisabledEmployeesReportModel : IDisabledEmployeeReportModel
    {
        public List<DisabledEmployeeReport> DisabledEmployeeReports { get; set; }

        public event EventHandler<DisabledEmployeesEventArgs> DisabledEmployeesUpdated = delegate { };


        public DisabledEmployeesReportModel()
        {
            DisabledEmployeeReports = new DataService().GetDisabledEmployeesReport();
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

        private void RaiseDisabledEmployeesUpdated(DisabledEmployeeReport report)
        {
            DisabledEmployeesUpdated(this, new DisabledEmployeesEventArgs(report));
        }

        public void UpdateReportDisabledEmployees(DisabledEmployeeReport disabledEmployee)
        {
            DisabledEmployeeReport selectedEmployee = DisabledEmployeeReports.Where(d => d.id == disabledEmployee.id).FirstOrDefault() as DisabledEmployeeReport;
            selectedEmployee.id = disabledEmployee.id;
            selectedEmployee.personInfo = disabledEmployee.personInfo;
            selectedEmployee.msecInfo = disabledEmployee.msecInfo;
            selectedEmployee.group = disabledEmployee.group;
            selectedEmployee.dateFrom = disabledEmployee.dateFrom;
            selectedEmployee.dateTo = disabledEmployee.dateTo;
            selectedEmployee.address = disabledEmployee.address;
            selectedEmployee.monthInWork = disabledEmployee.monthInWork;
            selectedEmployee.position = disabledEmployee.position;
            selectedEmployee.orderHired = disabledEmployee.orderHired;
            selectedEmployee.orderFired = disabledEmployee.orderFired;
            RaiseDisabledEmployeesUpdated(selectedEmployee);
        }
    }

    public class DisabledEmployeesEventArgs : EventArgs
    {
        public DisabledEmployeeReport DisabledEmployee { get; set; }

        public DisabledEmployeesEventArgs(DisabledEmployeeReport employee)
        {
        DisabledEmployee = employee;
        }
    }
}
