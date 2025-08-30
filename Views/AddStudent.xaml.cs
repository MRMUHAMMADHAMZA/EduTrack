using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using EduTrack.Models;

namespace EduTrack.Views
{
    public partial class AddStudent : Window
    {
        private readonly DbHelper dbHelper = new DbHelper();
        private bool isUpdatingContact = false;

        private bool isEditMode = false;
        private Student editingStudent;

        public AddStudent()
        {
            InitializeComponent();
            LoadNextId();
        }

        // Overloaded constructor for Edit mode
        // Overloaded constructor for Edit mode
        public AddStudent(Student student) : this()
        {
            isEditMode = true;
            editingStudent = student;

            // ✅ Update both the window title and the top header
            this.Title = "EduTrack - Edit Student";
            txtHeader.Text = "EduTrack - Edit Student";

            // Fill data
            txtId.Text = student.Id.ToString();
            txtName.Text = student.Name;
            txtFather.Text = student.FatherName;
            dpDOB.SelectedDate = student.DateOfBirth;
            cbGender.Text = student.Gender;
            txtContact.Text = student.ContactNo;
            txtEmail.Text = student.Email;
            cbDegree.Text = student.DegreeProgram;
            txtAddress.Text = student.Address;
        }


        private void LoadNextId()
        {
            try
            {
                int nextId = dbHelper.GetNextStudentId();
                txtId.Text = nextId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading next ID: " + ex.Message,
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!ValidateForm()) return;

                if (isEditMode) // ✅ Update existing student
                {
                    editingStudent.Name = txtName.Text;
                    editingStudent.FatherName = txtFather.Text;
                    editingStudent.DateOfBirth = dpDOB.SelectedDate;
                    editingStudent.Gender = cbGender.Text;
                    editingStudent.ContactNo = txtContact.Text;
                    editingStudent.Email = txtEmail.Text.ToLower();
                    editingStudent.DegreeProgram = cbDegree.Text;
                    editingStudent.Address = txtAddress.Text;

                    dbHelper.UpdateStudent(editingStudent);

                    MessageBox.Show("Student updated successfully!",
                                    "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    // Go back to ViewStudent
                    ViewStudent view = new ViewStudent();
                    view.Show();
                    this.Close();
                }
                else // ✅ Add new student
                {
                    Student student = new Student
                    {
                        Name = txtName.Text,
                        FatherName = txtFather.Text,
                        DateOfBirth = dpDOB.SelectedDate,
                        Gender = cbGender.Text,
                        ContactNo = txtContact.Text,
                        Email = txtEmail.Text.ToLower(),
                        DegreeProgram = cbDegree.Text,
                        Address = txtAddress.Text
                    };

                    dbHelper.AddStudent(student);

                    MessageBox.Show($"Student saved successfully! Assigned ID: {student.Id}",
                                    "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                    ClearForm();
                    LoadNextId();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message,
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e) => ClearForm();
        private void BtnClose_Click(object sender, RoutedEventArgs e) => this.Close();

        private void ClearForm()
        {
            txtName.Clear();
            txtFather.Clear();
            dpDOB.SelectedDate = null;
            cbGender.SelectedIndex = -1;
            txtContact.Clear();
            txtEmail.Clear();
            cbDegree.SelectedIndex = -1;
            txtAddress.Clear();

            errName.Visibility = Visibility.Collapsed;
            errFather.Visibility = Visibility.Collapsed;
            errDOB.Visibility = Visibility.Collapsed;
            errGender.Visibility = Visibility.Collapsed;
            errContact.Visibility = Visibility.Collapsed;
            errEmail.Visibility = Visibility.Collapsed;
            errDegree.Visibility = Visibility.Collapsed;
            errAddress.Visibility = Visibility.Collapsed;
        }

        private bool ValidateForm()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(txtName.Text))
            { errName.Visibility = Visibility.Visible; isValid = false; }
            else errName.Visibility = Visibility.Collapsed;

            if (string.IsNullOrWhiteSpace(txtFather.Text))
            { errFather.Visibility = Visibility.Visible; isValid = false; }
            else errFather.Visibility = Visibility.Collapsed;

            if (dpDOB.SelectedDate == null)
            { errDOB.Visibility = Visibility.Visible; isValid = false; }
            else errDOB.Visibility = Visibility.Collapsed;

            if (cbGender.SelectedItem == null)
            { errGender.Visibility = Visibility.Visible; isValid = false; }
            else errGender.Visibility = Visibility.Collapsed;

            if (string.IsNullOrWhiteSpace(txtContact.Text))
            {
                errContact.Text = "Contact number is required";
                errContact.Visibility = Visibility.Visible;
                isValid = false;
            }
            else if (!Regex.IsMatch(txtContact.Text, @"^\d{4}-\d{7}$"))
            {
                errContact.Text = "Incorrect contact format";
                errContact.Visibility = Visibility.Visible;
                isValid = false;
            }
            else errContact.Visibility = Visibility.Collapsed;

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                errEmail.Text = "Email is required";
                errEmail.Visibility = Visibility.Visible;
                isValid = false;
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9._%+-]+@(gmail|yahoo|outlook|hotmail)\.com$"))
            {
                errEmail.Text = "Incorrect email format";
                errEmail.Visibility = Visibility.Visible;
                isValid = false;
            }
            else errEmail.Visibility = Visibility.Collapsed;

            if (cbDegree.SelectedItem == null)
            { errDegree.Visibility = Visibility.Visible; isValid = false; }
            else errDegree.Visibility = Visibility.Collapsed;

            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            { errAddress.Visibility = Visibility.Visible; isValid = false; }
            else errAddress.Visibility = Visibility.Collapsed;

            return isValid;
        }

        // Event Handlers
        private void txtName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[a-zA-Z\s]+$");
        }

        private void txtContact_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Regex.IsMatch(e.Text, @"[0-9]"))
                e.Handled = true;
        }

        private void txtContact_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isUpdatingContact) return;
            isUpdatingContact = true;

            TextBox tb = sender as TextBox;
            string digits = tb.Text.Replace("-", "");

            if (digits.Length > 11)
                digits = digits.Substring(0, 11);

            if (digits.Length > 4)
                tb.Text = digits.Substring(0, 4) + "-" + digits.Substring(4);
            else
                tb.Text = digits;

            tb.CaretIndex = tb.Text.Length;

            if (!string.IsNullOrWhiteSpace(tb.Text))
                errContact.Visibility = Visibility.Collapsed;
            else
            {
                errContact.Text = "Contact number is required";
                errContact.Visibility = Visibility.Visible;
            }

            isUpdatingContact = false;
        }

        private void dpDOB_Loaded(object sender, RoutedEventArgs e)
        {
            dpDOB.DisplayDateEnd = DateTime.Today;
        }

        private void Field_DateChanged(object sender, SelectionChangedEventArgs e)
        {
            errDOB.Visibility = dpDOB.SelectedDate == null ? Visibility.Visible : Visibility.Collapsed;
        }

        private void Field_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender == cbGender)
                errGender.Visibility = cbGender.SelectedItem == null ? Visibility.Visible : Visibility.Collapsed;
            else if (sender == cbDegree)
                errDegree.Visibility = cbDegree.SelectedItem == null ? Visibility.Visible : Visibility.Collapsed;
        }

        private void Field_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender == txtName)
                errName.Visibility = string.IsNullOrWhiteSpace(txtName.Text) ? Visibility.Visible : Visibility.Collapsed;
            else if (sender == txtFather)
                errFather.Visibility = string.IsNullOrWhiteSpace(txtFather.Text) ? Visibility.Visible : Visibility.Collapsed;
            else if (sender == txtAddress)
                errAddress.Visibility = string.IsNullOrWhiteSpace(txtAddress.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void TxtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
                errEmail.Visibility = Visibility.Collapsed;
            else
            {
                errEmail.Text = "Email is required";
                errEmail.Visibility = Visibility.Visible;
            }
        }

        private void BtnViewStudents_Click(object sender, RoutedEventArgs e)
        {
            ViewStudent viewStudentWindow = new ViewStudent();
            viewStudentWindow.Show();
            this.Close();
        }
    }
}
