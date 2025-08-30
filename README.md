EduTrack - Student Record Management System

Project Overview

EduTrack is a desktop application built using C# and WPF (Windows Presentation Foundation) for managing student records efficiently. It provides a user-friendly interface for administrators to perform CRUD (Create, Read, Update, Delete) operations on student data, stored in a SQL Server database. The application is designed with a modern UI, robust data validation, and seamless navigation to enhance user experience.

Features





Splash Screen: Displays a loading animation for 3 seconds before navigating to the main dashboard.



Dashboard: Provides an overview of student statistics, including total students, male students, and female students.



Add Student: Allows administrators to add new student records with fields like ID (auto-generated), Name, Father Name, Date of Birth, Gender, Contact Number, Email, Degree Program, and Address.



Edit Student: Enables updating existing student records with real-time validation.



View Students: Displays a list of all students in a DataGrid with options to edit or delete records.



Search Functionality: Supports real-time search by student ID, Name, or Contact Number.



Data Validation: Ensures accurate input with regex-based validation for fields like Name (letters only), Contact Number (format: 1234-1234567), and Email (supports gmail, yahoo, outlook, hotmail domains).



Responsive UI: Features a modern, clean design with a sidebar navigation, styled buttons, and error messaging for invalid inputs.

Technologies Used





C#: Core programming language for backend logic.



WPF: For building the desktop application's user interface with XAML.



SQL Server: Database for storing student records.



ADO.NET: For database connectivity and operations.



.NET Framework: Provides the runtime environment for the application.



Regex: For input validation (e.g., email and contact number formats).

Project Structure





EduTrack.Models: Contains the Student class defining the student entity with properties like Id, Name, FatherName, etc.



EduTrack.Views: Includes WPF windows (SplashScreen.xaml, Dashboard.xaml, AddStudent.xaml, ViewStudent.xaml) for the UI.



EduTrack: Contains the DbHelper class for database operations (CRUD and statistics).



App.xaml: Configures the application startup with the splash screen.

Database Schema

The application uses a SQL Server database named EduTrackDB with a single table Students having the following schema:





Id (int, Primary Key, Auto-increment)



Name (nvarchar)



FatherName (nvarchar)



DateOfBirth (date, nullable)



Gender (nvarchar)



ContactNo (nvarchar)



Email (nvarchar)



DegreeProgram (nvarchar)



Address (nvarchar)

Installation and Setup





Prerequisites:





Install Visual Studio (2019 or later) with .NET desktop development workload.



Install SQL Server and SQL Server Management Studio (SSMS).



Ensure .NET Framework 4.7.2 or later is installed.



Database Setup:





Create a database named EduTrackDB in SQL Server.



Execute the following SQL script to create the Students table:
