using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using PPC_HR.Models;
using PPC_HR.Controllers;
using PPC_HR.DataAccess;
using PPC_HR.DocProcessing;

namespace PPC_HR.Views
{
    /// <summary>
    /// Логика взаимодействия для DisabledEmployeesReport.xaml
    /// </summary>
    public partial class MilReportEmployeesView : UserControl
    {

        private readonly IMilReportEmployeesModel _model;
        private List<MilReportEmployees> report;

        public MilReportEmployeesView(IMilReportEmployeesController reportController, IMilReportEmployeesModel reportModel)
        {
            InitializeComponent();
            _model = reportModel;

            report = _model.MilReportEmployeesList;
            GridReport.Items.Clear();
            GridReport.ItemsSource = report;
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            ReportsCreator reports = new ReportsCreator();
            reports.MilReportEmployeesCreator(report);
        }
    }
}
