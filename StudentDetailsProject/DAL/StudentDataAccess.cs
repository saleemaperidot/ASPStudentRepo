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
    }
}