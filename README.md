# 📘 EduTrack - Student Record Management System

## 📌 Project Overview  
EduTrack is a desktop application built using **C#** and **WPF (Windows Presentation Foundation)** for managing student records efficiently. It provides a user-friendly interface for administrators to perform **CRUD (Create, Read, Update, Delete)** operations on student data, stored in a **SQL Server** database. The application is designed with a **modern UI**, robust data validation, and seamless navigation to enhance user experience.

---

## ✨ Features  
- 🚀 **Splash Screen**: Displays a loading animation for 3 seconds before navigating to the main dashboard.  
- 📊 **Dashboard**: Provides an overview of student statistics, including total students, male students, and female students.  
- ➕ **Add Student**: Add new student records with fields like ID (auto-generated), Name, Father Name, Date of Birth, Gender, Contact Number, Email, Degree Program, and Address.  
- ✏️ **Edit Student**: Update existing student records with real-time validation.  
- 📋 **View Students**: Displays a list of all students in a DataGrid with options to edit or delete records.  
- 🔍 **Search Functionality**: Real-time search by student **ID, Name, or Contact Number**.  
- ✅ **Data Validation**: Regex-based validation for Name (letters only), Contact Number (e.g., `1234-1234567`), and Email (gmail, yahoo, outlook, hotmail).  
- 🎨 **Responsive UI**: Sidebar navigation, styled buttons, modern clean design, and error messaging for invalid inputs.  

---

## 🛠 Technologies Used  
- **C#** → Core programming language for backend logic.  
- **WPF (XAML)** → For building the UI.  
- **SQL Server** → Database for storing student records.  
- **ADO.NET** → Database connectivity & operations.  
- **.NET Framework 4.7.2+** → Runtime environment.  
- **Regex** → Input validation.  

---

## 📂 Project Structure  
- **EduTrack.Models** → Contains `Student` class with properties (Id, Name, FatherName, etc.)  
- **EduTrack.Views** → WPF windows (`SplashScreen.xaml`, `Dashboard.xaml`, `AddStudent.xaml`, `ViewStudent.xaml`).  
- **EduTrack** → Contains `DbHelper.cs` for database operations (CRUD & stats).  
- **App.xaml** → Configures app startup with splash screen.  

---

## 🗄 Database Schema  
The app uses a **SQL Server database (EduTrackDB)** with a single table **Students**:  

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

---

## ⚡ Installation and Setup  

### ✅ Prerequisites  
- Visual Studio 2019+ with **.NET desktop development** workload  
- SQL Server & **SQL Server Management Studio (SSMS)**  
- .NET Framework 4.7.2+  

### 🛠 Steps  

1. **Clone the Repository**  
   ```bash
   github.com/MRMUHAMMADHAMZA/EduTrack
   ```

2. **Setup Database**  
   - Open **SQL Server Management Studio (SSMS)**  
   - Run the SQL script above to create the database and table.  

3. **Configure Connection String**  
   Update `DbHelper.cs` with your SQL Server instance:  

   ```csharp
   private readonly string connectionString = "Server=YOUR_SERVER_NAME;Database=EduTrackDB;Trusted_Connection=True;";
   ```

4. **Build and Run the Project**  
   - Open `EduTrack.sln` in Visual Studio  
   - Build and run the solution  

---

## 🚀 Usage  
- Launch the app → see **Splash Screen**.  
- Navigate to **Dashboard** → view student statistics.  
- Use **Add Student** → input new records with validation.  
- Open **View Students** → search, edit, or delete records.  
- Search students in real-time by **ID, Name, or Contact Number**.  

--- 

---

## 📧 Contact  
For any questions or suggestions, feel free to **open an issue** or contact the repository owner.  
