using System;
using System.Windows;
using EduTrack;

namespace EduTrack.Views
{
    public partial class Dashboard : Window
    {
        private readonly DbHelper dbHelper = new DbHelper();

        public Dashboard()
        {
            InitializeComponent();
            LoadStats();
        }

        // ✅ Load Total, Male, Female students
        private void LoadStats()
        {
            try
            {
                int total = dbHelper.GetTotalStudents();
                int male = dbHelper.GetMaleStudents();
                int female = dbHelper.GetFemaleStudents();

                txtTotalStudents.Text = $"Total Students: {total}";
                txtMaleStudents.Text = $"Male Students: {male}";
                txtFemaleStudents.Text = $"Female Students: {female}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading statistics: " + ex.Message,
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            AddStudent addStudentWindow = new AddStudent();
            addStudentWindow.Show();
            this.Close();
        }

        private void BtnViewStudents_Click(object sender, RoutedEventArgs e)
        {
            ViewStudent viewStudentWindow = new ViewStudent();
            viewStudentWindow.Show();
            this.Close();
        }
    }
}
