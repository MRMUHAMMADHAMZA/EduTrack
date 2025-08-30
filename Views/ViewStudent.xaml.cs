using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using EduTrack.Models;

namespace EduTrack.Views
{
    public partial class ViewStudent : Window
    {
        private readonly DbHelper dbHelper = new DbHelper();

        public ViewStudent()
        {
            InitializeComponent();
            LoadStudents();
        }

        // Load all students
        private void LoadStudents()
        {
            try
            {
                List<Student> students = dbHelper.GetAllStudents();
                dgStudents.ItemsSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students: " + ex.Message,
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Add Student button
        private void BtnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            AddStudent addStudentWindow = new AddStudent();
            addStudentWindow.Show();
            this.Close();
        }

        // Edit student
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Student selectedStudent = (sender as Button).DataContext as Student;
            if (selectedStudent != null)
            {
                AddStudent editWindow = new AddStudent(selectedStudent);
                editWindow.Title = "EduTrack - Edit Student";
                editWindow.Show();
                this.Close();
            }
        }

        // Delete student
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            Student selectedStudent = (sender as Button).DataContext as Student;
            if (selectedStudent != null)
            {
                MessageBoxResult result = MessageBox.Show(
                    $"Are you sure you want to delete {selectedStudent.Name}?",
                    "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    dbHelper.DeleteStudent(selectedStudent.Id);
                    LoadStudents();
                }
            }
        }

        // Instant search while typing
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            try
            {
                List<Student> students;

                if (string.IsNullOrEmpty(searchText))
                    students = dbHelper.GetAllStudents();
                else
                    students = dbHelper.SearchStudents(searchText);

                dgStudents.ItemsSource = students;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while searching: " + ex.Message,
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Optional: Search button click calls same search
        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            txtSearch_TextChanged(sender, null);
        }
    }
}
