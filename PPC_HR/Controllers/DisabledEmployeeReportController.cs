using PPC_HR.DataAccess;
using PPC_HR.Models;
using PPC_HR.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace PPC_HR.Controllers
{
    public interface IDisabledEmployeeReportController
    {
        DisabledEmployeesReportView LoadDisabledEmployeeReport();
        void update(DisabledEmployeeReport disabledEmployeeReport);
    }

    public class DisabledEmployeeReportController : IDisabledEmployeeReportController
    {
        private readonly IDisabledEmployeeReportModel _model;

        public DisabledEmployeeReportController(IDisabledEmployeeReportModel reportModel)
        {
            if (reportModel == null) throw new ArgumentNullException("disabledEmplReport");
            _model = reportModel;
        }

        public DisabledEmployeesReportView LoadDisabledEmployeeReport()
        {
            DisabledEmployeesReportView reportView = new DisabledEmployeesReportView(this, _model);
            return reportView;
        }

        public void update(DisabledEmployeeReport disabledEmployeeReport)
        {
            _model.UpdateReportDisabledEmployees(disabledEmployeeReport);
        }
    }
}
