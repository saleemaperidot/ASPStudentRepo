using StudentDetailsProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
//using StudentDetailsProject.Models;

namespace StudentDetailsProject.DAL
{
    public class StudentDataAccess
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["Dbconnection"].ToString();
        
        // Get Student Details
        public List<studentModel> GetStudentDetail()
        {
            List<studentModel> studentsList = new List<studentModel>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            using (connection)
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SelectAllStudentDetails";
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable studentDetails = new DataTable();
                connection.Open();

                adapter.Fill(studentDetails);
                connection.Close();
                foreach (DataRow datarow in studentDetails.Rows)
                {
                    studentsList.Add(new studentModel
                    {

                        StudentId = (int)datarow["StudentID"],
                        FirstName = (string)datarow["FirstName"],
                        LastName = (string)datarow["LastName"],
                        StudentAddress = (string)datarow["StudentAddress"],
                        StudentPassword = (string)datarow["StudentPassword"],
                        StudentUserName = (string)datarow["StudentUserName"],
                        City = (string)datarow["City"],
                        ContactNumber = (string)datarow["ContactNumber"],
                        FathersName = (string)datarow["FathersName"],
                        DateOfbirth = (DateTime)datarow["DOB"],
                        DateOfJoining = (DateTime)datarow["DateOfJoining"]
                    });
                }

            }

            return studentsList;
        }

        //insert Student details during registration
        public bool insertStudentRegistrationDetails(studentModel student)
        {
            int id = 0;
            SqlConnection connection = new SqlConnection(ConnectionString);
            using(connection)
            {
                SqlCommand command = new SqlCommand("StudentRegistrationProcedure",connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@LastName",student.LastName);
                command.Parameters.AddWithValue("@FirstName", student.LastName);
                command.Parameters.AddWithValue("@StudentUserName", student.LastName);
                command.Parameters.AddWithValue("@StudentPassword", student.LastName);
                command.Parameters.AddWithValue("@StudentAddress", student.LastName);
                command.Parameters.AddWithValue("@City", student.LastName);
                command.Parameters.AddWithValue("@DOB", student.LastName);
                command.Parameters.AddWithValue("@DateOfJoining", student.LastName);
                connection.Open();
                id=command.ExecuteNonQuery();  
                connection.Close();


            }
            if(id>0)

            return true;
            else
                return false;
        }
    }
}