using Microsoft.Win32;
using PPC_HR.DataAccess;
using PPC_HR.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PPC_HR.Views
{
    /// <summary>
    /// Логика взаимодействия для PersonInfoView.xaml
    /// </summary>
    public partial class PersonInfoView : Window
    {
        string FilePath;

        //private readonly IPersonInfoController _controller;
        private readonly PersonInfoModel _model;

        private PersonInfo _info;
        private List<PersonPosition> _positions;
        private PersonExperience _experience;
        private List<PersonDiploma> _diplomas;
        private PersonMilitary _militaryInfo;
        private PersonDisability _disabilityInfo;
        private PersonMentalCheck _mentalCheck;
        private byte[] scanDisability;
        private byte[] scanMentalCheck;
        private bool isNewEmpl = false;

        public PersonInfoView()
        {
            _model = new PersonInfoModel(0);
            InitializeComponent();
            PanelPersonInfo.IsEnabled = true;
            PanelPositions.IsEnabled = true;
            PanelEducation.IsEnabled = true;
            PanelMilitary.IsEnabled = true;
            PanelDisability.IsEnabled = true;
            PanelMentalCheck.IsEnabled = true;
            isNewEmpl = true;
            PersonPositions.Items.Clear();
            GridEducation.Items.Clear();
            DeleteEmployee.Visibility = Visibility.Collapsed;
        }

        public PersonInfoView(PersonInfoModel infoModel, bool editable)
        {
            InitializeComponent();
            if (editable == true)
            {
                PanelPersonInfo.IsEnabled = true;
                PanelPositions.IsEnabled = true;
                PanelEducation.IsEnabled = true;
                PanelMilitary.IsEnabled = true;
                PanelDisability.IsEnabled = true;
                PanelMentalCheck.IsEnabled = true;
            }
            infoModel.RunTasksPersonInfo();
            _model = infoModel;

            _info = _model.Info;
            _positions = _model.Positions.Item1;
            _experience = _model.Positions.Item2;
            _diplomas = _model.Diplomas;
            _militaryInfo = _model.Military;
            _disabilityInfo = _model.Disability;
            _mentalCheck = _model.MentalCheck;

            PersonPositions.Items.Clear();
            GridEducation.Items.Clear();

            LastName.Text = _info.surname;
            FirstName.Text = _info.firstname;
            MidName.Text = _info.patronymic;
            iid.Text = _info.iid.ToString();
            Phone.Text = _info.phone.ToString();
            Address.Text = _info.emplAddress;
            BirthDate.SelectedDate = Convert.ToDateTime(_info.birthdate);
            CyclKomis.Text = _info.cyclKomis;
            Position.Text = _info.position;
            pedWork.IsChecked = _info.pedWorkload;
            milLiable.IsChecked = _info.isMilitaryBound;
            isRetired.IsChecked = _info.isRetired;
            sex.Text = _info.sex.ToString();

        }

        private void mainInfo_Click(object sender, RoutedEventArgs e)
        {

            foreach (StackPanel panel in Container.Children)
                panel.Visibility = Visibility.Hidden;
            PanelPersonInfo.Visibility = Visibility.Visible;
            if (!isNewEmpl)
            {
                LastName.Text = _info.surname;
                FirstName.Text = _info.firstname;
                MidName.Text = _info.patronymic;
                iid.Text = _info.iid.ToString();
                Phone.Text = _info.phone.ToString();
                Address.Text = _info.emplAddress;
                BirthDate.SelectedDate = Convert.ToDateTime(_info.birthdate);
                CyclKomis.Text = _info.cyclKomis;
                Position.Text = _info.position;
                pedWork.IsChecked = _info.pedWorkload;
                milLiable.IsChecked = _info.isMilitaryBound;
                isRetired.IsChecked = _info.isRetired;
                sex.Text = _info.sex.ToString();
            }
        }

        private void position_Click(object sender, RoutedEventArgs e)
        {

            foreach (StackPanel panel in Container.Children)
                panel.Visibility = Visibility.Hidden;
            PanelPositions.Visibility = Visibility.Visible;


            code.SelectedValuePath = "positionId";
            code.DisplayMemberPath = "positionCode";
            if (!isNewEmpl)
            {
                PersonPositions.ItemsSource = _positions;
                code.SetBinding(ComboBox.ItemsSourceProperty, new Binding() { Source = _positions });
                code.SetCurrentValue(ComboBox.SelectedValueProperty, _positions.Find(p => p.isMainPosition = true).positionId);
                volume.Text = _positions.First(p => p.positionId == (short)code.SelectedValue).positionVolume.ToString();
                position.Text = _positions.First(p => p.positionId == (short)code.SelectedValue).positionName.ToString();

                totalExp.Text = _experience.totalExp.ToString();
                specExp.Text = _experience.specializationExp.ToString();
                positionExp.Text = _experience.positionExp.ToString();
                lastChanges.SelectedDate = Convert.ToDateTime(_experience.lastChangesDate);
            }
            else
            {
                _positions = new List<PersonPosition>();
                code.ItemsSource = _positions;
            }
        }

        private void education_Click(object sender, RoutedEventArgs e)
        {

            foreach (StackPanel panel in Container.Children)
                panel.Visibility = Visibility.Hidden;
            PanelEducation.Visibility = Visibility.Visible;
            if (!isNewEmpl)
            {
                GridEducation.ItemsSource = _diplomas;
            }
            else
            {
                _diplomas = new List<PersonDiploma>();
                GridEducation.ItemsSource = _diplomas;
            }
        }

        private void milButton_Click(object sender, RoutedEventArgs e)
        {

            foreach (StackPanel panel in Container.Children)
                panel.Visibility = Visibility.Hidden;
            PanelMilitary.Visibility = Visibility.Visible;
            if (!isNewEmpl)
            {
                milSeries.Text = _militaryInfo.series;
                milNumber.Text = _militaryInfo.serialNumber;
                milRank.Text = _militaryInfo.militaryRank;
                milDept.Text = _militaryInfo.militaryDept;
            }
        }

        private void disabButton_Click(object sender, RoutedEventArgs e)
        {

            foreach (StackPanel panel in Container.Children)
                panel.Visibility = Visibility.Hidden;
            PanelDisability.Visibility = Visibility.Visible;
            List<string> listTimeIssued = new List<string>() { "Первинний", "Повторно", "З дитинства" };
            List<string> listGroups = new List<string>() { "I", "II", "III" };
            timeIssued.ItemsSource = listTimeIssued;
            disabilityGroup.ItemsSource = listGroups;
            if (!isNewEmpl)
            {
                disabSeries.Text = _disabilityInfo.disabSeries;
                disabNumber.Text = _disabilityInfo.disabNumber;
                msecDateFrom.SelectedDate = Convert.ToDateTime(_disabilityInfo.msecDateFrom);
                timeIssued.SetCurrentValue(ComboBox.SelectedValueProperty, _disabilityInfo.timeIssued);
                DisabilityDateFrom.SelectedDate = Convert.ToDateTime(_disabilityInfo.disabilityDateFrom);
                DisabilityDateTo.SelectedDate = Convert.ToDateTime(_disabilityInfo.disabilityDateTo);
                disabilityGroup.SetCurrentValue(ComboBox.SelectedValueProperty, _disabilityInfo.disabilityGroup);
                reason.Text = _disabilityInfo.reason;
                scanDisability = _disabilityInfo.scancopy;
            }
        }

        private void MentalCheck_click(object sender, RoutedEventArgs e)
        {

            foreach (StackPanel panel in Container.Children)
                panel.Visibility = Visibility.Hidden;
            PanelMentalCheck.Visibility = Visibility.Visible;
            if (!isNewEmpl)
            {
                mentalCheckSeries.Text = _mentalCheck.series;
                mentalCheckNumber.Text = _mentalCheck.serialNumber;
                mentalCheckDateTo.SelectedDate = Convert.ToDateTime(_mentalCheck.dateTo);
                scanMentalCheck = _mentalCheck.scancopy;
            }
        }

        private void LoadPhotoClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            //openFileDialog.Filter = "all files (*.*)|*.*|All files (*.*)|*.*";
            //openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                PhotoViewer.Source = new BitmapImage(new Uri(FilePath));
            }
        }

        private void code_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!isNewEmpl)
            {
                position.Text = _positions.First(p => p.positionId == (short)code.SelectedValue).positionName.ToString();
                volume.Text = _positions.First(p => p.positionId == (short)code.SelectedValue).positionVolume.ToString();
            }
        }


        private void uploadFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "pictures (*.*)|*.*|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                FileMentalCheck.Content = new BitmapImage(new Uri(FilePath));
            }

        }


        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            if (imageC != null)
            {
                encoder.Frames.Add(BitmapFrame.Create(imageC));
                encoder.Save(memStream);
                return memStream.ToArray();
            }
            else return new byte[] { 0 };
        }

        private void SaveMainInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PersonInfo employee = new PersonInfo
                {
                    iid = Convert.ToDecimal(iid.Text),
                    surname = Convert.ToString(LastName.Text),
                    firstname = Convert.ToString(FirstName.Text),
                    patronymic = Convert.ToString(MidName.Text),
                    sex = Convert.ToChar(sex.Text),
                    emplAddress = Convert.ToString(Address.Text),
                    birthdate = BirthDate.SelectedDate.ToString(),
                    phone = Convert.ToDecimal(Phone.Text),
                    cyclKomis = Convert.ToString(CyclKomis.Text),
                    isMilitaryBound = Convert.ToBoolean(milLiable.IsChecked),
                    isRetired = Convert.ToBoolean(isRetired.IsChecked),
                    pedWorkload = Convert.ToBoolean(pedWork.IsChecked),
                    photo = getJPGFromImageControl(PhotoViewer.Source as BitmapImage)
                };
                if (_info is null) employee.emplid = 0;
                else employee.emplid = _info.emplid;
                _model.UpdatePersonInfo(employee);
        }
            catch (Exception ex) { MessageBox.Show("Невірно введені дані"); }
}

        private void SavePositions_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<PersonPosition> positions = new List<PersonPosition>();
                positions = PersonPositions.Items.OfType<PersonPosition>().ToList();
                foreach (PersonPosition pos in positions)
                {
                    pos.isMainPosition = false;
                    if (_info is null) pos.emplid = 0;
                    else pos.emplid = _info.emplid;
                }
                positions.Find(p => p.positionId == (short)code.SelectedValue).isMainPosition = true;
                _model.UpdatePersonPosition(positions);

                PersonExperience experience = new PersonExperience
                {
                    positionExp = Convert.ToInt16(positionExp.Text),
                    totalExp = Convert.ToInt16(totalExp.Text.ToString()),
                    specializationExp = Convert.ToInt16(specExp.Text),
                    lastChangesDate = lastChanges.SelectedDate.ToString()
                };
                if (_info is null) experience.emplid = 0;
                else experience.emplid = _info.emplid;

                _model.UpdatePedExp(experience);
            }
            catch (Exception ex) { MessageBox.Show("Невірно введені дані"); }
        }

        private void MilSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PersonMilitary military = new PersonMilitary
                {
                    series = milSeries.Text.ToString(),
                    serialNumber = milNumber.Text.ToString(),
                    militaryRank = milRank.Text.ToString(),
                    militaryDept = milDept.Text.ToString(),
                };
                if (_info is null) military.emplId = 0;
                else military.emplId = _info.emplid;

                _model.UpdateMilitary(military);
            }
            catch (Exception ex) { MessageBox.Show("Невірно введені дані"); }
        }

        private void SaveDisability_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PersonDisability disability = new PersonDisability
                {
                    disabSeries = disabSeries.Text.ToString(),
                    disabNumber = disabNumber.Text.ToString(),
                    msecDateFrom = msecDateFrom.SelectedDate.ToString(),
                    timeIssued = timeIssued.SelectedItem.ToString(),
                    disabilityDateFrom = DisabilityDateFrom.SelectedDate.ToString(),
                    disabilityDateTo = DisabilityDateTo.SelectedDate.ToString(),
                    disabilityGroup = disabilityGroup.SelectedItem.ToString(),
                    reason = reason.Text.ToString(),
                    scancopy = getJPGFromImageControl(DisabilityFile.Content as BitmapImage)
                };
                if (_info is null) disability.emplId = 0;
                else disability.emplId = _info.emplid;
                switch (disability.disabilityGroup)
                {
                    case "I": disability.disabilityGroup = "1"; break;
                    case "II": disability.disabilityGroup = "2"; break;
                    case "III": disability.disabilityGroup = "3"; break;
                }
                _model.UpdateDisability(disability);
            }
            catch (Exception ex) { MessageBox.Show("Невірно введені дані"); }
        }

        private void MentalCheckSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                PersonMentalCheck mentalCheck = new PersonMentalCheck();
                if (_info is null) mentalCheck.emplId = 0;
                else mentalCheck.emplId = _info.emplid;
                mentalCheck.series = mentalCheckSeries.Text.ToString();
                mentalCheck.serialNumber = mentalCheckNumber.Text.ToString();
                mentalCheck.dateTo = mentalCheckDateTo.SelectedDate.ToString();
                mentalCheck.scancopy = getJPGFromImageControl(DisabilityFile.Content as BitmapImage);

                _model.UpdateMentalCheck(mentalCheck);
            }
            catch (Exception ex) { MessageBox.Show("Невірно введені дані"); }
        }

        private void uploadFileDisability_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "pictures (*.*)|*.*|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                DisabilityFile.Content = new BitmapImage(new Uri(FilePath));
            }
        }

        private void DeleteEmployee_Click(object sender, RoutedEventArgs e)
        {
            _model.DeleteEmployee(_info.emplid);
        }

        private void EducationSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<PersonDiploma> diplomas = GridEducation.Items.OfType<PersonDiploma>().ToList();
                _model.UpdateDiplomasInfo(diplomas);
            }
            catch (Exception ex) { MessageBox.Show("Невірно введені дані"); }
        }
    }
}
