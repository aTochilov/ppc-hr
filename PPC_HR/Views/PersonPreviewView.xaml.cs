using PPC_HR.Controllers;
using PPC_HR.DataAccess;
using PPC_HR.Models;
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
    /// Логика взаимодействия для PersonPreviewView.xaml
    /// </summary>
    public partial class PersonPreviewView : UserControl
    {
        private readonly IPersonPreviewController _controller;
        private readonly IPersonPreviewModel _model;

        private PersonPreview person;

        public PersonPreviewView(IPersonPreviewController previewController, IPersonPreviewModel previewModel)
        {
            InitializeComponent();
            _controller = previewController;
            _model = previewModel;
            person = _model.GetNextPreview();

            _model.PreviewUpdated += model_PreviewUpdated;
            FullName.Text = person.fullname;
            Position.Text = person.position;
            Phone.Text = person.phone;
        }

        void model_PreviewUpdated(object sender, PersonPreviewEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MoreButton_Click(object sender, RoutedEventArgs e)
        {
            PersonInfoView personInfo = new PersonInfoView(new PersonInfoModel(person.id), false);
            personInfo.Show();
        }

        private void EditablePersonInfo_Click(object sender, RoutedEventArgs e)
        {
            PersonInfoView personInfo = new PersonInfoView(new PersonInfoModel(person.id), true);
            personInfo.Show();
        }
    }
}
