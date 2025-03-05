using System.Data.SqlClient;
using System.Data;
using Student_Registration.Models;

namespace Student_Registration.Repository
{
    public class StudentRecordRepository : IStudentRecordRepository
    {
        private readonly string connectionString;

        public StudentRecordRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("connectionString");
        }

        // Get all students along with their qualifications

        public IEnumerable<StudentViewModel> GetStudentsList()
        {
            List<StudentViewModel> studentList = new List<StudentViewModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllStudentRecords", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    StudentViewModel student = new StudentViewModel
                    {
                        StudentId = Convert.ToInt32(dr["StudentId"]),
                        FirstName = dr["FirstName"].ToString(),
                        LastName = dr["LastName"].ToString(),
                        DOB = Convert.ToDateTime(dr["DOB"]),
                        Gender = dr["Gender"].ToString(),
                        Email = dr["Email"].ToString(),
                        PhoneNumber = dr["PhoneNumber"].ToString(),
                        QualificationId = dr["QualificationId"] != DBNull.Value ? Convert.ToInt32(dr["QualificationId"]) : 0,
                        CourseName = dr["CourseName"].ToString(),
                        University = dr["University"].ToString(),
                        YearOfPassing = dr["YearOfPassing"] != DBNull.Value ? Convert.ToInt32(dr["YearOfPassing"]) : 0,
                        Percentage = dr["Percentage"] != DBNull.Value ? Convert.ToDecimal(dr["Percentage"]) : 0
                    };
                    studentList.Add(student);
                }
            }
            return studentList;
        }

        public void AddNewStudent(StudentViewModel student)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_RegisterStudent", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                cmd.Parameters.AddWithValue("@LastName", student.LastName);
                cmd.Parameters.AddWithValue("@DOB", student.DOB);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", student.PhoneNumber);
                cmd.Parameters.AddWithValue("@CourseName", student.CourseName);
                cmd.Parameters.AddWithValue("@University", student.University);
                cmd.Parameters.AddWithValue("@YearOfPassing", student.YearOfPassing);
                cmd.Parameters.AddWithValue("@Percentage", student.Percentage);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
