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
CREATE TABLE Students (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100) NOT NULL,
    FatherName NVARCHAR(100) NOT NULL,
    DateOfBirth DATE NULL,
    Gender NVARCHAR(10) NOT NULL,
    ContactNo NVARCHAR(12) NOT NULL,
    Email NVARCHAR(100),
    DegreeProgram NVARCHAR(100) NOT NULL,
    Address NVARCHAR(MAX)
);
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
   git clone https://github.com/your-username/EduTrack.git
   ```

2. **Setup Database**  
   - Open **SQL Server Management Studio (SSMS)**  
   - Run the SQL script above to create the database and table.  

3. **Configure Connection String**  
   Update `DbHelper.cs` with your SQL Server instance:  

   ```csharp
   private readonly string connectionString = 
       "Server=YOUR_SERVER_NAME;Database=EduTrackDB;Trusted_Connection=True;";
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

## 🔮 Future Enhancements  
- 🔑 Add authentication & role-based access (Admin vs. Viewer).  
- 📤 Export data to **CSV/Excel**.  
- 📥 Support **bulk imports**.  
- 🎨 More UI themes.  
- 📅 Advanced search filters (e.g., Degree Program, Date of Birth).  

---

## 🤝 Contributing  
1. Fork the repository  
2. Create a feature branch → `git checkout -b feature/your-feature`  
3. Commit changes → `git commit -m "Add your feature"`  
4. Push to branch → `git push origin feature/your-feature`  
5. Create a **Pull Request**  

---

## 📜 License  
This project is licensed under the **MIT License**. See the LICENSE file for details.  

---

## 📧 Contact  
For any questions or suggestions, feel free to **open an issue** or contact the repository owner.  
