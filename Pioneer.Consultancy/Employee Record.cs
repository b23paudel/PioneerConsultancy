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
using Pioneertech.Consultancy.model;

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
            CompanyDetail companyDetail = new CompanyDetail
            {
                EmployerName = employeeIdTextBox.Text,
                ContactNumber = Convert.ToInt64(contactNumberTextBox.Text),
                Location = companyLocationTextBox.Text,
                Website = companyWebsiteTextBox.Text,
                EmployeeId =Convert.ToInt32(companyEmployeeIDTextBox.Text)
        };
            
            EmployeeDataAccessLayer companyDAL = new EmployeeDataAccessLayer();
            int numberOfRowEffected = companyDAL.SaveEmployeeCompanyData(companyDetail);
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
            EmployeeDetail employeeDetail = new EmployeeDetail();
            employeeDetail.FirstName = firstNameTextBox.Text;
            employeeDetail.LastName = lastNameTextBox.Text;
            employeeDetail.EmailId = emailIDTextBox.Text;
            employeeDetail.PhoneNumber = Convert.ToInt64(phoneNumberTextBox.Text);
            employeeDetail.AlternatePhoneNumber = Convert.ToInt64(alternatePhoneTextBox.Text);
            employeeDetail.Address1 = address1TextBox.Text;
            employeeDetail.Address2 = address2TextBox.Text;
            employeeDetail.HomeCountry = homeCountryTextBox.Text;
            employeeDetail.CurrentCountry = currentCountryTextBox.Text;
            employeeDetail.ZipCode = Convert.ToInt32(zipcodeTextBox.Text);

            
            EmployeeDataAccessLayer employeeDAL = new EmployeeDataAccessLayer();
            int numberOfRowEffected = employeeDAL.SaveEmployeeData(employeeDetail);
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
            ProjectDetail projectdetails = new ProjectDetail
            {
                ProjectName = projectNameTextBox.Text,
                ClientName = clientNameTextBox.Text,
                Roles = rolesTextBox.Text,
                Location = projectLocationTextBox.Text,
                EmployeeId = Convert.ToInt32(employeeIdTextBox.Text)
            };
            
            EmployeeDataAccessLayer projectDAL = new EmployeeDataAccessLayer();
            int numberOfRowEffected = projectDAL.SaveEmployeeProjectData(projectdetails);
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

       
    }
}
