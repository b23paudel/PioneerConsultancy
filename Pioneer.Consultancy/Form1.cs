using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pioneer.Consultancy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void companyDetailsSaveButton_Click(object sender, EventArgs e)
        {
            string employerName = employerNameTextBox.Text;
            string contactNumber = contactNumberTextBox.Text;
            string location = companyLocationTextBox.Text;
            string website = companyWebsiteTextBox.Text;
            int employeeID = Convert.ToInt32(companyEmployeeIDTextBox.Text);
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-I3T5H70;" +
               "Initial Catalog=PioneerTech;" +
               "Integrated Security=true");
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO CompanyDetail VALUES(" +
                           "'" + employerName + "'," + contactNumber + ",'" + location + "','" +
                          website + "'," + employeeID + ")", conn);
                SqlDataReader rr = command.ExecuteReader();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string emailId = emailIDTextBox.Text;
            long phoneNumber = Convert.ToInt64(phoneNumberTextBox.Text);
            long alternatePhoneNumber = Convert.ToInt64(alternatePhoneTextBox.Text);
            string address1 = address1TextBox.Text;
            string address2 = address2TextBox.Text;
            string homeCountry = homeCountryTextBox.Text;
            string currentCountry = currentCountryTextBox.Text;
            int zipCode = Convert.ToInt32(zipcodeTextBox.Text);
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-I3T5H70;" +
                "Initial Catalog=PioneerTech;" +
                "Integrated Security=true");
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO EmployeeDetail VALUES(" +
                           "'" + firstName + "','" + lastName + "','" + emailId + "'," +
                           phoneNumber + "," + alternatePhoneNumber + ",'" + address1 + "','" + address2 +
                           "','" + homeCountry + "','" + currentCountry + "'," + zipCode + ")", conn);
                SqlDataReader rr = command.ExecuteReader();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void projectDetailsSaveButton_Click(object sender, EventArgs e)
        {
            string projectName = projectNameTextBox.Text;
            string clientName = clientNameTextBox.Text;
            string roles = rolesTextBox.Text;
            string location = projectLocationTextBox.Text;
            int employeeID = Convert.ToInt32(employeeIdTextBox.Text);
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-I3T5H70;" +
               "Initial Catalog=PioneerTech;" +
               "Integrated Security=true");
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("INSERT INTO ProjectDetail VALUES(" +
                           "'" + projectName + "','" + clientName + "','" + location + "','" +
                          roles +  "'," + employeeID + ")", conn);
                SqlDataReader rr = command.ExecuteReader();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int searchEmployeeID = Convert.ToInt32(searchTextBox.Text);
            SqlConnection conn = new SqlConnection("Data Source=DESKTOP-I3T5H70;" +
               "Initial Catalog=PioneerTech;" +
               "Integrated Security=true");
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM EmployeeDetail WHERE EmployeeID = "+searchEmployeeID, conn);
                SqlCommand command1 = new SqlCommand("SELECT * FROM ProjectDetail WHERE EmployeeID = "+searchEmployeeID, conn);
                SqlCommand command2 = new SqlCommand("SELECT * FROM CompanyDetail WHERE EmployeeID = "+searchEmployeeID , conn);

                SqlDataReader drE = command.ExecuteReader();
                BindingSource source = new BindingSource();
                source.DataSource = drE;
                drE.Close();
                
                SqlDataReader drP = command1.ExecuteReader();
                BindingSource source1 = new BindingSource();
                source1.DataSource = drP;
                drP.Close();

                SqlDataReader drC = command1.ExecuteReader();
                BindingSource source2 = new BindingSource();
                source2.DataSource = drC;
                drC.Close();

                DashboardDataGridView.DataSource = source;
                projectDetailDataGridView.DataSource = source1;
                companyDetailDataGridView.DataSource = source2;

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
        }
    }
}
