# 🎓 EduTrack - Student Record Management System

EduTrack is a desktop application built using **C#** and **WPF** (Windows Presentation Foundation) for efficiently managing student records. It provides a modern, user-friendly interface for administrators to perform **CRUD** operations on student data stored in a **SQL Server** database.  

---

## ✨ Features

- 🖼️ **Splash Screen:** Displays a loading animation for 3 seconds before navigating to the main dashboard.  
- 📊 **Dashboard:** Overview of student statistics (total students, male/female students).  
- ➕ **Add Student:** Add new student records with fields like ID (auto-generated), Name, Father Name, Date of Birth, Gender, Contact Number, Email, Degree Program, and Address.  
- ✏️ **Edit Student:** Update existing student records with real-time validation.  
- 📋 **View Students:** Displays all students in a DataGrid with options to edit or delete records.  
- 🔍 **Search Functionality:** Real-time search by student ID, Name, or Contact Number.  
- ✅ **Data Validation:** Regex-based validation for Name (letters only), Contact Number (format: 1234-1234567), and Email (supports Gmail, Yahoo, Outlook, Hotmail).  
- 🖌️ **Responsive UI:** Modern, clean design with sidebar navigation, styled buttons, and error messages for invalid inputs.  

---

## 🛠️ Technologies Used

- **C#** – Backend logic  
- **WPF** – Desktop UI using XAML  
- **SQL Server** – Database for student records  
- **ADO.NET** – Database connectivity and operations  
- **.NET Framework** – Runtime environment  
- **Regex** – Input validation  

---

## 📂 Project Structure

- **EduTrack.Models** – Contains the `Student` class defining the student entity.  
- **EduTrack.Views** – WPF windows (`SplashScreen.xaml`, `Dashboard.xaml`, `AddStudent.xaml`, `ViewStudent.xaml`).  
- **EduTrack** – Contains `DbHelper.cs` for database operations (CRUD and statistics).  
- **App.xaml** – Configures application startup with the splash screen.  

---

## 🗄️ Database Schema

Database: `EduTrackDB`  

Table: `Students`

| Column       | Type          | Notes                   |
|--------------|---------------|------------------------|
| Id           | int           | Primary Key, Auto-Increment |
| Name         | nvarchar(100) |                        |
| FatherName   | nvarchar(100) |                        |
| DateOfBirth  | date          | Nullable               |
| Gender       | nvarchar(10)  |                        |
| ContactNo    | nvarchar(15)  |                        |
| Email        | nvarchar(100) |                        |
| DegreeProgram| nvarchar(100) |                        |
| Address      | nvarchar(250) |                        |

You can find the database creation script in [`EduTrackDB.sql`](./EduTrackDB.sql).

---

## ⚡ Installation and Setup

### Prerequisites

- Visual Studio 2019 or later with **.NET desktop development** workload  
- SQL Server & SQL Server Management Studio (SSMS)  
- .NET Framework 4.7.2 or later  

### Steps

1. **Clone the repository:**  
```bash
git clone https://github.com/your-username/EduTrack.git
