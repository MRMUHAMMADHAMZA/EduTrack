using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using EduTrack.Models;

namespace EduTrack
{
    public class DbHelper
    {
        private readonly string connectionString =
            "Server=DESKTOP-6RDGPRS\\SQLEXPRESS;Database=EduTrackDB;Trusted_Connection=True;";

        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // ✅ Add student to database
        public void AddStudent(Student student)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO Students
                                 (Name, FatherName, DateOfBirth, Gender, ContactNo, Email, DegreeProgram, Address)
                                 OUTPUT INSERTED.Id
                                 VALUES (@Name, @FatherName, @DateOfBirth, @Gender, @ContactNo, @Email, @DegreeProgram, @Address)";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", (object)student.Name ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FatherName", (object)student.FatherName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOfBirth", (object)student.DateOfBirth ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Gender", (object)student.Gender ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ContactNo", (object)student.ContactNo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object)student.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DegreeProgram", (object)student.DegreeProgram ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", (object)student.Address ?? DBNull.Value);

                    // ✅ Assign generated ID back to object
                    student.Id = (int)cmd.ExecuteScalar();
                }
            }
        }

        // ✅ Get next available Student ID
        public int GetNextStudentId()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT ISNULL(MAX(Id), 0) + 1 FROM Students";
                using (var cmd = new SqlCommand(query, conn))
                {
                    return Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
        }

        // ✅ Get all students
        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();

            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT Id, Name, FatherName, DateOfBirth, Gender, ContactNo, Email, DegreeProgram, Address FROM Students";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            FatherName = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            DateOfBirth = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                            Gender = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            ContactNo = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            Email = reader.IsDBNull(6) ? "" : reader.GetString(6),
                            DegreeProgram = reader.IsDBNull(7) ? "" : reader.GetString(7),
                            Address = reader.IsDBNull(8) ? "" : reader.GetString(8)
                        });
                    }
                }
            }

            return students;
        }

        // ✅ Update Student
        public void UpdateStudent(Student student)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = @"UPDATE Students 
                         SET Name=@Name, FatherName=@FatherName, DateOfBirth=@DateOfBirth, 
                             Gender=@Gender, ContactNo=@ContactNo, Email=@Email, 
                             DegreeProgram=@DegreeProgram, Address=@Address
                         WHERE Id=@Id";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", student.Id);
                    cmd.Parameters.AddWithValue("@Name", (object)student.Name ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FatherName", (object)student.FatherName ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DateOfBirth", (object)student.DateOfBirth ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Gender", (object)student.Gender ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ContactNo", (object)student.ContactNo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Email", (object)student.Email ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DegreeProgram", (object)student.DegreeProgram ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", (object)student.Address ?? DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        // ✅ Delete Student
        public void DeleteStudent(int studentId)
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Students WHERE Id=@Id";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", studentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        // ✅ Search Students by ID, Name, or Contact
        public List<Student> SearchStudents(string keyword)
        {
            var students = new List<Student>();

            using (var conn = GetConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                // Check if keyword is numeric for ID search
                if (int.TryParse(keyword, out int id))
                {
                    cmd.CommandText = @"SELECT Id, Name, FatherName, DateOfBirth, Gender, ContactNo, Email, DegreeProgram, Address
                                FROM Students
                                WHERE Id = @Id OR Name LIKE @keyword OR ContactNo LIKE @keyword";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                }
                else
                {
                    cmd.CommandText = @"SELECT Id, Name, FatherName, DateOfBirth, Gender, ContactNo, Email, DegreeProgram, Address
                                FROM Students
                                WHERE Name LIKE @keyword OR ContactNo LIKE @keyword";
                    cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
                }

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.IsDBNull(1) ? "" : reader.GetString(1),
                            FatherName = reader.IsDBNull(2) ? "" : reader.GetString(2),
                            DateOfBirth = reader.IsDBNull(3) ? (DateTime?)null : reader.GetDateTime(3),
                            Gender = reader.IsDBNull(4) ? "" : reader.GetString(4),
                            ContactNo = reader.IsDBNull(5) ? "" : reader.GetString(5),
                            Email = reader.IsDBNull(6) ? "" : reader.GetString(6),
                            DegreeProgram = reader.IsDBNull(7) ? "" : reader.GetString(7),
                            Address = reader.IsDBNull(8) ? "" : reader.GetString(8)
                        });
                    }
                }
            }

            return students;
        }

        // ✅ Get total students
        public int GetTotalStudents()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Students";
                using (var cmd = new SqlCommand(query, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        // ✅ Get male students
        public int GetMaleStudents()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Students WHERE Gender='Male'";
                using (var cmd = new SqlCommand(query, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }

        // ✅ Get female students
        public int GetFemaleStudents()
        {
            using (var conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Students WHERE Gender='Female'";
                using (var cmd = new SqlCommand(query, conn))
                {
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
    }
}
