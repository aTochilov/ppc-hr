using PPC_HR.Controllers;
using PPC_HR.Models;
using PPC_HR.Views;
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
using System.Windows.Shapes;

namespace PPC_HR.Views
{
    /// <summary>
    /// Логика взаимодействия для MainScreenV.xaml
    /// </summary>
    public partial class MainScreenView : Window
    {
        private IPersonPreviewController _preview;
        private IDisabledEmployeeReportController _disabledEmployeeReport;
        public MainScreenView()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PersonInfoView person = new PersonInfoView();
            
            person.Show();
        }

        private void reportsButton_Click(object sender, RoutedEventArgs e)
        {
            if (ReportsCanvas.IsVisible) ReportsCanvas.Visibility = Visibility.Hidden;
            else ReportsCanvas.Visibility = Visibility.Visible;

        }

        private void employeesButton_Click(object sender, RoutedEventArgs e)
        {
            _preview = new PersonPreviewController(new PersonPreviewModel());
            foreach (PersonPreviewView preview in _preview.loadPreviews())
                WorkspacePanel.Children.Add(preview);
        }

        private void disabledEmplButton_Click(object sender, RoutedEventArgs e)
        {
            _disabledEmployeeReport = new DisabledEmployeeReportController(new DisabledEmployeesReportModel());
            WorkspacePanel.Children.Add(_disabledEmployeeReport.LoadDisabledEmployeeReport());
        }

        private void militaryLiableButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            if (searchPanel.IsVisible) searchPanel.Visibility = Visibility.Hidden;
            else searchPanel.Visibility = Visibility.Visible;
        }
    }
}
