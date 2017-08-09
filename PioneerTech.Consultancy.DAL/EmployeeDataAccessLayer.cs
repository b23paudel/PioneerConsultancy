using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pioneertech.Consultancy.model;

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
        public int SaveEmployeeData(EmployeeDetail employeeDetail)
        {
            //SqlConnection mssqlconnection;
            SqlConnection mssqlconnection = new SqlConnection("Data Source=DESKTOP-I3T5H70;" +
                  "Initial Catalog=PioneerTech;" +
                 "Integrated Security=true");
            mssqlconnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO EmployeeDetail VALUES(" +
                       "'" + employeeDetail.FirstName+ "','" + employeeDetail.LastName + "','" + employeeDetail.EmailId + "'," +
                       employeeDetail.PhoneNumber + "," + employeeDetail.AlternatePhoneNumber + ",'" + employeeDetail.Address1 + "','" + employeeDetail.Address2 +
                       "','" + employeeDetail.HomeCountry + "','" + employeeDetail.CurrentCountry + "'," + employeeDetail.ZipCode + ")", mssqlconnection);
            int row =command.ExecuteNonQuery();
            mssqlconnection.Close();
            return row;
        }
        public int SaveEmployeeProjectData(ProjectDetail projectDetail)
        {
            SqlConnection mssqlconnection = new SqlConnection("Data Source=DESKTOP-I3T5H70;" +
                  "Initial Catalog=PioneerTech;" +
                 "Integrated Security=true");
            mssqlconnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO ProjectDetail VALUES(" +
                           "'" + projectDetail.ProjectName + "','" + projectDetail.ClientName + "','" + projectDetail.Location + "','" +
                          projectDetail.Roles + "'," + projectDetail.EmployeeId + ")", mssqlconnection);
            int row = command.ExecuteNonQuery();
            mssqlconnection.Close();
            return row;
        }
        public int SaveEmployeeCompanyData(CompanyDetail companyDetail)
        {
            SqlConnection mssqlconnection = new SqlConnection("Data Source=DESKTOP-I3T5H70;" +
                  "Initial Catalog=PioneerTech;" +
                 "Integrated Security=true");
            mssqlconnection.Open();
            SqlCommand command = new SqlCommand("INSERT INTO CompanyDetail VALUES(" +
                           "'" + companyDetail.EmployerName + "'," + companyDetail.ContactNumber + ",'" + companyDetail.Location + "','" +
                          companyDetail.Website + "'," + companyDetail.EmployeeId + ")", mssqlconnection);
            int row = command.ExecuteNonQuery();
            mssqlconnection.Close();
            return row;
        }
    }
}
