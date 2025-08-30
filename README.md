# EduTrack - Student Record Management System

EduTrack is a desktop application built using C# and WPF (Windows Presentation Foundation) for efficiently managing student records. The application provides a modern, user-friendly interface for administrators to perform CRUD (Create, Read, Update, Delete) operations on student data stored in a SQL Server database.

---

## Features

- **Splash Screen:** Displays a loading animation for 3 seconds before navigating to the main dashboard.  
- **Dashboard:** Provides an overview of student statistics, including total students, male students, and female students.  
- **Add Student:** Allows adding new student records with fields like ID (auto-generated), Name, Father Name, Date of Birth, Gender, Contact Number, Email, Degree Program, and Address.  
- **Edit Student:** Enables updating existing student records with real-time validation.  
- **View Students:** Displays all students in a DataGrid with options to edit or delete records.  
- **Search Functionality:** Supports real-time search by student ID, Name, or Contact Number.  
- **Data Validation:** Ensures accurate input with regex-based validation for Name (letters only), Contact Number (format: 1234-1234567), and Email (supports Gmail, Yahoo, Outlook, Hotmail).  
- **Responsive UI:** Modern, clean design with sidebar navigation, styled buttons, and error messages for invalid inputs.  

---

## Technologies Used

- **C#:** Core programming language for backend logic  
- **WPF:** For building the desktop application's user interface with XAML  
- **SQL Server:** Database for storing student records  
- **ADO.NET:** For database connectivity and operations  
- **.NET Framework:** Runtime environment for the application  
- **Regex:** For input validation  

---

## Project Structure

- **EduTrack.Models:** Contains the `Student` class defining the student entity.  
- **EduTrack.Views:** Includes WPF windows (`SplashScreen.xaml`, `Dashboard.xaml`, `AddStudent.xaml`, `ViewStudent.xaml`) for the UI.  
- **EduTrack:** Contains `DbHelper.cs` for database operations (CRUD and statistics).  
- **App.xaml:** Configures application startup with the splash screen.  

---

## Database Schema

Database: `EduTrackDB`  

Table: `Students`

| Column       | Type          | Notes                   |
|--------------|---------------|------------------------|
| Id           | int           | Primary Key, Auto-Increment |
| Name         | nvarchar(100) |                        |
| FatherName   | nvarchar(100) |                        |
| DateOfBirth  | date          | Nullable               |
| Gender       | nvarchar(10)  |                        |
| ContactNo    | nvarchar(12)  |                        |
| Email        | nvarchar(100) |                        |
| DegreeProgram| nvarchar(100) |                        |
| Address      | nvarchar(MAX) |                        |

SQL script to create the table:

```sql
CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    FatherName NVARCHAR(100),
    DateOfBirth DATE,
    Gender NVARCHAR(10),
    ContactNo NVARCHAR(12),
    Email NVARCHAR(100),
    DegreeProgram NVARCHAR(100),
    Address NVARCHAR(MAX)
);
