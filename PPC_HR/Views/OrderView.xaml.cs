using PPC_HR.DataAccess;
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

namespace PPC_HR.Views
{
    /// <summary>
    /// Логика взаимодействия для OrderView.xaml
    /// </summary>
    public partial class OrderView : UserControl
    {
        public OrderView(List<Order> list)
        {
            InitializeComponent();
            GridOrders.Items.Clear();
            GridOrders.ItemsSource = list;
        }

        private void SaveOrderButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
