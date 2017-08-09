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
using PioneerTech.Consultancy.DAL;

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
            long contactNumber = Convert.ToInt64(contactNumberTextBox.Text);
            string location = companyLocationTextBox.Text;
            string website = companyWebsiteTextBox.Text;
            int employeeID = Convert.ToInt32(companyEmployeeIDTextBox.Text);
            EmployeeDataAccessLayer companyDAL = new EmployeeDataAccessLayer();
            int numberOfRowEffected = companyDAL.SaveEmployeeCompanyData(employerName, contactNumber, location, website, employeeID);
            if (numberOfRowEffected > 0)
            {
                MessageBox.Show("Employee Company Data Successfully Added");
            }
            else
            {
                MessageBox.Show("Employee Company Data not Added. Please try again.");
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
            EmployeeDataAccessLayer employeeDAL = new EmployeeDataAccessLayer();
            int numberOfRowEffected = employeeDAL.SaveEmployeeData(firstName, lastName, emailId, phoneNumber, alternatePhoneNumber, address1, address2, homeCountry, currentCountry, zipCode);
            if(numberOfRowEffected>0)
            {
                MessageBox.Show("Employee Data Successfully Added");
            }
            else
            {
                MessageBox.Show("Employee Data not Added");
            }

        }

        private void projectDetailsSaveButton_Click(object sender, EventArgs e)
        {
            string projectName = projectNameTextBox.Text;
            string clientName = clientNameTextBox.Text;
            string roles = rolesTextBox.Text;
            string location = projectLocationTextBox.Text;
            int employeeID = Convert.ToInt32(employeeIdTextBox.Text);
            EmployeeDataAccessLayer projectDAL = new EmployeeDataAccessLayer();
            int numberOfRowEffected = projectDAL.SaveEmployeeProjectData(projectName, clientName, roles, location,employeeID);
            if (numberOfRowEffected > 0)
            {
                MessageBox.Show("Employee Project Data Successfully Added");
            }
            else
            {
                MessageBox.Show("Employee Project Data Added. Please try again.");
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
                DashboardDataGridView.BackgroundColor = Color.LightSteelBlue;
                projectDetailDataGridView.DataSource = source1;
                projectDetailDataGridView.BackgroundColor = Color.LightSteelBlue;
                companyDetailDataGridView.DataSource = source2;
                companyDetailDataGridView.BackgroundColor = Color.LightSteelBlue;

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

        private void companyDetailsTabPage_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
