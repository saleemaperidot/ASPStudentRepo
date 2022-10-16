using StudentDetailsProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
//using System.Web.UI.WebControls;
//using StudentDetailsProject.Models

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
                command.Parameters.AddWithValue("@FathersName", student.FathersName);
                command.Parameters.AddWithValue("@FirstName", student.FirstName);
                command.Parameters.AddWithValue("@StudentUserName", student.StudentUserName);
                command.Parameters.AddWithValue("@StudentPassword", student.StudentPassword);
                command.Parameters.AddWithValue("@StudentAddress", student.StudentAddress);
                command.Parameters.AddWithValue("@City", student.City);
                command.Parameters.AddWithValue("@DOB", student.DateOfbirth);
                command.Parameters.AddWithValue("@ContactNumber", student.ContactNumber);
                command.Parameters.AddWithValue("@DateOfJoining", student.DateOfJoining);
                connection.Open();
                id=command.ExecuteNonQuery();  
                connection.Close();


            }
            if(id>0)

            return true;
            else
                return false;
        }

        //Get Login foriengn key

        public int getReferenceIdFromLogin(Login login)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            SqlDataReader rd;
            using (connection)
            {
                SqlCommand command=connection.CreateCommand();
                command.CommandType=CommandType.StoredProcedure;
                command.CommandText = "spLoginId";
                command.Parameters.AddWithValue("@usename", login.usrname);
                command.Parameters.AddWithValue("@password", login.password);
                connection.Open();
               //  rd = command.ExecuteReader();
               // int value =
                int a = Convert.ToInt32(command.ExecuteScalar());//Converting the returned value to Int32
                return a;
            }
            //return rd;
        }
        public List<studentModel> GetStudentDetailfilterbydate(DateTime startDate,DateTime EndDate)
        {
            List<studentModel> studentsList = new List<studentModel>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            using (connection)
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spRecordsBetweenTwoDates";
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", EndDate);
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
        //getLoggedStudentDetails
        public List<studentModel> GetLoggedInStudentDetail(int id)
        {
            List<studentModel> studentsList = new List<studentModel>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            using (connection)
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spProfileloggedin";
                command.Parameters.AddWithValue("@id",id);
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


        //get Profile

        public bool GetStudentProfileDetail(Login login)
        {
            int id = 0;
            List<studentModel> studentsList = new List<studentModel>();
            SqlConnection connection = new SqlConnection(ConnectionString);
            using (connection)
            {
                SqlCommand command = connection.CreateCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "spProfile";
                command.Parameters.AddWithValue("@usename",login.usrname);
                command.Parameters.AddWithValue("@password", login.password);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                DataTable studentDetails = new DataTable();
                connection.Open();

                adapter.Fill(studentDetails);
                connection.Close();

                if (adapter != null)
                {
                    return true;
                }
                else
                { return false; }

                /* 

                 foreach (DataRow datarow in studentDetails.Rows)
                 {
                     //studentModel student = new studentModel();
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
                 }*/

            }

            //return studentsList;
        }
    }
}