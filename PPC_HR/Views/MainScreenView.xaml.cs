using PPC_HR.Controllers;

using PPC_HR.Models;

using System.Windows;


namespace PPC_HR.Views
{
    /// <summary>
    /// Логика взаимодействия для MainScreenV.xaml
    /// </summary>
    public partial class MainScreenView : Window
    {
        private IPersonPreviewController _preview;
        private IDisabledEmployeeReportController _disabledEmployeeReport;
        private IMilReportEmployeesController _milReportEmployees;
        private OrdersController orders;
        public MainScreenView()
        {
            InitializeComponent();
            _preview = new PersonPreviewController(new PersonPreviewModel());
            foreach (PersonPreviewView preview in _preview.loadPreviews())
                WorkspacePanel.Children.Add(preview);
            AddPersonButton.Visibility = Visibility.Visible;
        }


        private void reportsButton_Click(object sender, RoutedEventArgs e)
        {
            AddPersonButton.Visibility = Visibility.Collapsed;
            WorkspacePanel.Children.Clear();
            if (ReportsCanvas.IsVisible) ReportsCanvas.Visibility = Visibility.Hidden;
            else ReportsCanvas.Visibility = Visibility.Visible;

        }

        private void employeesButton_Click(object sender, RoutedEventArgs e)
        {
            WorkspacePanel.Children.Clear();
            
            _preview = new PersonPreviewController(new PersonPreviewModel());
            foreach (PersonPreviewView preview in _preview.loadPreviews())
                WorkspacePanel.Children.Add(preview);
            AddPersonButton.Visibility = Visibility.Visible;
        }

        private void disabledEmplButton_Click(object sender, RoutedEventArgs e)
        {
            WorkspacePanel.Children.Clear();
            _disabledEmployeeReport = new DisabledEmployeeReportController(new DisabledEmployeesReportModel());
            WorkspacePanel.Children.Add(_disabledEmployeeReport.LoadDisabledEmployeeReport());
        }

        private void militaryLiableButton_Click(object sender, RoutedEventArgs e)
        {
            WorkspacePanel.Children.Clear();
            _milReportEmployees = new MilReportEmployeesController(new MilReportEmployeesModel());
            WorkspacePanel.Children.Add(_milReportEmployees.LoadMilReportEmployees());
        }

        private void searchButton_Click(object sender, RoutedEventArgs e)
        {
            AddPersonButton.Visibility = Visibility.Collapsed;
            WorkspacePanel.Children.Clear();
            if (searchPanel.IsVisible) searchPanel.Visibility = Visibility.Hidden;
            else searchPanel.Visibility = Visibility.Visible;
        }

        private void AddPersonButton_Click(object sender, RoutedEventArgs e)
        {
            PersonInfoView newPerson = new PersonInfoView();
            newPerson.Show();
        }

        private void OrdersButton_Click(object sender, RoutedEventArgs e)
        {
            AddPersonButton.Visibility = Visibility.Collapsed;
            WorkspacePanel.Children.Clear();
            orders = new OrdersController();
            WorkspacePanel.Children.Add( orders.LoadDisabledEmployeeReport());
        }

        private void search_click(object sender, RoutedEventArgs e)
        {
            WorkspacePanel.Children.Clear();

            SearchController _search = new SearchController(SearchTB.Text.ToString());
            foreach (PersonPreviewView preview in _search.loadPreviews())
                WorkspacePanel.Children.Add(preview);
            AddPersonButton.Visibility = Visibility.Visible;
        }
    }
}
