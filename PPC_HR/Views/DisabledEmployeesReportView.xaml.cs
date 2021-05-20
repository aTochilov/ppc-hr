using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using PPC_HR.Models;
using PPC_HR.Controllers;
using PPC_HR.DataAccess;
using PPC_HR.DocProcessing;

namespace PPC_HR.Views
{
    /// <summary>
    /// Логика взаимодействия для DisabledEmployeesReport.xaml
    /// </summary>
    public partial class DisabledEmployeesReportView : UserControl
    {

        private readonly IDisabledEmployeeReportModel _model;
        private readonly IDisabledEmployeeReportController _controller;
        private List<DisabledEmployeeReport> report;

        public DisabledEmployeesReportView(IDisabledEmployeeReportController reportController, IDisabledEmployeeReportModel reportModel)
        {
            InitializeComponent();
            _controller = reportController;
            _model = reportModel;

            _model.DisabledEmployeesUpdated += model_ReportUpdated;
            report = _model.DisabledEmployeeReports;
            GridReport.Items.Clear();
            GridReport.ItemsSource = report;

            ReportsCreator reports = new ReportsCreator();
            reports.DisabledEmployeesReportCreator(report);
        }

        void model_ReportUpdated(object sender, DisabledEmployeesEventArgs e)
        {

        }
    }
}
