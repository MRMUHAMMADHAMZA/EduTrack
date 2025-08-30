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

## 🗄️ Database Setup

### SQL Server Database Creation Script

```sql
-- 1️⃣ Create the database if it doesn't exist
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'EduTrackDB')
BEGIN
    CREATE DATABASE EduTrackDB;
END
GO

-- 2️⃣ Use the newly created database
USE EduTrackDB;
GO

-- 3️⃣ Create the Students table (drop first if it exists)
IF OBJECT_ID('Students', 'U') IS NOT NULL
    DROP TABLE Students;
GO

CREATE TABLE Students
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    FatherName NVARCHAR(100) NOT NULL,
    DateOfBirth DATE NULL,
    Gender NVARCHAR(10) NOT NULL,
    ContactNo NVARCHAR(15) NOT NULL,
    Email NVARCHAR(100) NULL,
    DegreeProgram NVARCHAR(100) NOT NULL,
    Address NVARCHAR(250) NULL
);
GO

-- 4️⃣ Select all students (initially empty)
SELECT *
FROM Students;
GO
```

### Steps to Setup Database

1. Open SQL Server Management Studio (SSMS).
2. Copy and paste the above SQL code into a new query window.
3. Execute the script to create the EduTrackDB database and Students table.
4. The database is now ready to use with the application.


## ⚡ Installation and Setup

### Prerequisites

- Visual Studio 2019 or later with .NET desktop development workload
- SQL Server & SQL Server Management Studio (SSMS)
- .NET Framework 4.7.2 or later


### Steps

bash
# 1. Clone the repository
git clone https://github.com/your-username/EduTrack.git
```

```csharp
```
2. Configure Connection String in DbHelper.cs
```
private readonly string connectionString = "Server=YOUR_SERVER_NAME;Database=EduTrackDB;Trusted_Connection=True;";
```
# 3. Build & Run
- Open EduTrack.sln in Visual Studio
- Build the solution and run the application

## 🏃 Usage

1. Launch the app to see the splash screen.
2. Navigate to the Dashboard to view student statistics.
3. Use Add Student to input new records.
4. Use View Students to see all students, search, edit, or delete records.
5. Search students by ID, Name, or Contact Number in real-time.



---

## 📬 Contact

```
For questions or suggestions, open an issue or contact the repository owner.
```
