using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PioneerTech.Consultancy.DAL
{
    public class EmployeeDataAccessLayer
    {
        //public EmployeeDataAccessLayer()
        //{
        //    SqlConnection mssqlconnection = new SqlConnection("Data Source=DESKTOP-I3T5H70;" +
        //        "Initial Catalog=PioneerTech;" +
        //        "Integrated Security=true");
        //    mssqlconnection.Open();
        //}
        public int SaveEmployeeData(string firstName,string lastName,string emailId,long phoneNumber,long alternatePhoneNumber,string address1,string address2,string homeCountry,string currentCountry,  int zipCode)
        {
            //SqlConnection mssqlconnection;
            SqlConnection mssqlconnection = new SqlConnection("Data Source=DESKTOP-I3T5H70;" +
                  "Initial Catalog=PioneerTech;" +
                 "Integrated Security=true");
            mssqlconnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO EmployeeDetail VALUES(" +
                       "'" + firstName + "','" + lastName + "','" + emailId + "'," +
                       phoneNumber + "," + alternatePhoneNumber + ",'" + address1 + "','" + address2 +
                       "','" + homeCountry + "','" + currentCountry + "'," + zipCode + ")", mssqlconnection);
            int row =command.ExecuteNonQuery();
            mssqlconnection.Close();
            return row;
        }
        public int SaveEmployeeProjectData(string projectName , string clientName, string roles, string location, int employeeId)
        {
            SqlConnection mssqlconnection = new SqlConnection("Data Source=DESKTOP-I3T5H70;" +
                  "Initial Catalog=PioneerTech;" +
                 "Integrated Security=true");
            mssqlconnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO ProjectDetail VALUES(" +
                           "'" + projectName + "','" + clientName + "','" + location + "','" +
                          roles + "'," + employeeId + ")", mssqlconnection);
            int row = command.ExecuteNonQuery();
            mssqlconnection.Close();
            return row;
        }
        public int SaveEmployeeCompanyData(string employerName, long contactNumber, string location, string website, int employeeId)
        {
            SqlConnection mssqlconnection = new SqlConnection("Data Source=DESKTOP-I3T5H70;" +
                  "Initial Catalog=PioneerTech;" +
                 "Integrated Security=true");
            mssqlconnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO CompanyDetail VALUES(" +
                           "'" + employerName + "'," + contactNumber + ",'" + location + "','" +
                          website + "'," + employeeId + ")", mssqlconnection);
            int row = command.ExecuteNonQuery();
            mssqlconnection.Close();
            return row;
        }
    }
}
