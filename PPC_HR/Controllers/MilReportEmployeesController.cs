
using PPC_HR.Models;
using PPC_HR.Views;
using System;


namespace PPC_HR.Controllers
{
    public interface IMilReportEmployeesController
    {
        MilReportEmployeesView LoadMilReportEmployees();
    }

    public class MilReportEmployeesController : IMilReportEmployeesController
    {
        private readonly IMilReportEmployeesModel _model;

        public MilReportEmployeesController(IMilReportEmployeesModel reportModel)
        {
            if (reportModel == null) throw new ArgumentNullException("milEmplReport");
            _model = reportModel;
        }

        public MilReportEmployeesView LoadMilReportEmployees()
        {
            MilReportEmployeesView reportView = new MilReportEmployeesView(this, _model);
            return reportView;
        }

    }
}
