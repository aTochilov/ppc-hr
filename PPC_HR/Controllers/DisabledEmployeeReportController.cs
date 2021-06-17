
using PPC_HR.Models;
using PPC_HR.Views;
using System;


namespace PPC_HR.Controllers
{
    public interface IDisabledEmployeeReportController
    {
        DisabledEmployeesReportView LoadDisabledEmployeeReport();
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

    }
}
