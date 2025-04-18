using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Excel = Microsoft.Office.Interop.Excel;
using ExcelInterop = Microsoft.Office.Interop.Excel;
using System.Drawing.Printing;
using System.Drawing;
using System.Data;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;




namespace Dashboard
{
    public partial class Form2 : Form

    {
        private PrintDocument printDoc = new PrintDocument();
        private object gender;
        private object city;
        private readonly object employeeListBox;

        public Form2()
        {
            if (DataGrid == null)
            {
                DataGrid = new DataGridView();
                // Initialize DataGrid properties like Size, Location, etc.
            }
            InitializeDataGridColumns();
            InitializeComponent();
            this.Load += Form2_Load;
            //Qualification.ItemCheck += Qualification_SelectedIndexChanged;
            // this.Qualification.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.Qualification_SelectedIndexChanged);

            this.Load += new System.EventHandler(this.Form2_Load);


        }

        private void Qualification_SelectedIndexChanged(object sender, ItemCheckEventArgs e)
        {
            // throw new NotImplementedException();
        }

        private void InitializeDataGridColumns()
        {

            this.DataGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            // Initialize your DataGrid's properties like Size, Location, etc.
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            // Check if columns are not already added to prevent duplicates
            if (DataGrid.Columns.Count == 0)
            {
                DataGrid.Columns.Add("id", "id");
                DataGrid.Columns.Add("Name", "Name");
                DataGrid.Columns.Add("Email", "Email");
                DataGrid.Columns.Add("Dob", "Date of Birth");
                DataGrid.Columns.Add("Address", "Address");
                DataGrid.Columns.Add("Password", "Password");
                DataGrid.Columns.Add("Gender", "Gender");
                DataGrid.Columns.Add("City", "City");

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<string> year = new List<string>
            {
                "-- Select --",
                "2008",
                "2010",
                "2011",
                "2012",
                "2013",
                "2014",
                "2015",
                "2016",
                "2017",
                "2018",
                "2019",
                "2020",
                "2021",
                "2022",
                "2023",
                "2024",

            };

            Year.DataSource = year;

            List<string> qualifications = new List<string>
            {
                "-- Select --",
                "HighSchool",
                "Intermediate",
                "B.sc",
                "Diploma",
                "BTech",
                "MTech",
                "PhD"
            };

            Qualification.DataSource = qualifications;

            //  MessageBox.Show("Form2 Loaded");
            List<string> cities = new List<string>()
            {
                    "Select City",
                     "Lucknow",
                     "Kanpur",
                     "Varanasi",
                     "Delhi"
            };

            City.DataSource = cities;
            label1.Text = "Welcome " + Form1.Users;

            // MessageBox.Show("Form2 Loaded");
            BindCityDropdown();
            // BindQualificationDropdown();
            label1.Text = "Welcome To Dashboard :" + Form1.Users;
        }

        private void BindQualificationDropdown()
        {
            throw new NotImplementedException();
        }


        // Bind city in drop down 

        private void BindCityDropdown()
        {
            string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT City FROM Employee WHERE City IS NOT NULL", con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    //City.Items.Clear();
                    //City.Items.Add("Select City");

                    while (reader.Read())
                    {
                        string cityName = reader["City"].ToString();
                        //MessageBox.Show("Loaded City: " + cityName); // 🧪 Debug
                        City.Items.Add(cityName);
                    }

                    City.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    //  MessageBox.Show("Error loading cities: " + ex.Message);
                }
            }
        }


        private void BindQualificationDropdowns()
        {
            string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT DISTINCT Qualification FROM Employee WHERE Qualification IS NOT NULL", con);
                    SqlDataReader reader = cmd.ExecuteReader();



                    while (reader.Read())
                    {
                        string QualificationName = reader["Qualification"].ToString();
                        MessageBox.Show("Loaded Qualification: " + Qualification); // 🧪 Debug
                        Qualification.Items.Add(QualificationName);
                    }

                    City.SelectedIndex = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading Qualification: " + ex.Message);
                }
            }
        }



        private void City_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (City.SelectedIndex > 0)
            {
                string city = City.SelectedItem.ToString();
                MessageBox.Show("You selected: " + city);
            }
        }

        // Add Employee  here 
        private void Addbtn_Click(object sender, EventArgs e)
        {
            // Clear previous messages
            lblMessage.Text = string.Empty;

            // Validate that all fields are filled in
            if (string.IsNullOrWhiteSpace(Name.Text) ||
                string.IsNullOrWhiteSpace(Email.Text) ||
                string.IsNullOrWhiteSpace(Dob.Text) ||
                string.IsNullOrWhiteSpace(Address.Text) ||
                string.IsNullOrWhiteSpace(Password.Text) ||

                (!Male.Checked && !Female.Checked) || // Ensure gender is selected
                City.SelectedIndex == 0) // Ensure city is selected (no default value)
            {
                MessageBox.Show("Please fill all required fields, including selecting a gender and city.");
                return;
            }

            // Validate Name (should not be empty)
            if (string.IsNullOrWhiteSpace(Name.Text))
            {
                MessageBox.Show("Name cannot be empty.");
                return;
            }


            // Validate Email format using regular expression
            if (!IsValidEmail(Email.Text))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            // Validate Date of Birth (DOB should be in a valid date format)
            if (!DateTime.TryParse(Dob.Text, out DateTime parsedDob))
            {
                MessageBox.Show("Invalid Date of Birth.");
                return;
            }

            // Validate Password length (at least 6 characters)
            if (Password.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
                return;
            }

            // Determine gender based on selected radio button
            string gender = Male.Checked ? "Male" : "Female"; // Assuming only Male or Female is selected

            // Get the selected city from the combo box
            // Validate that a valid city is selected
            if (City.SelectedIndex == -1 || City.SelectedItem.ToString() == "Select City")
            {
                MessageBox.Show("Please select a valid city.");
                return;
            }

            // Now safely access the selected city
            string city = City.SelectedItem.ToString();

            // Create the connection and command for inserting into the database
            string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    con.Open();

                    // Create the command
                    SqlCommand cmd = new SqlCommand("INSERT INTO Employee (Name, Email, Dob, Address, Password, Gender, City) " +
                                                    "VALUES (@Name, @Email, @Dob, @Address, @Password, @Gender, @City)", con);

                    // Add parameters
                    cmd.Parameters.AddWithValue("@Name", Name.Text);
                    cmd.Parameters.AddWithValue("@Email", Email.Text);
                    cmd.Parameters.AddWithValue("@Dob", parsedDob);
                    cmd.Parameters.AddWithValue("@Address", Address.Text);
                    cmd.Parameters.AddWithValue("@Password", Password.Text);
                    cmd.Parameters.AddWithValue("@Gender", gender);
                    cmd.Parameters.AddWithValue("@City", city);


                    // Execute the command
                    cmd.ExecuteNonQuery();

                    // Display success message
                    MessageBox.Show("Successfully inserted");

                    // Clear input fields after successful insert
                    Name.Clear();
                    Email.Clear();
                    //Dob.Value = DateTime.MinValue;
                    Address.Clear();
                    Password.Clear();

                    // Uncheck gender radio buttons (assuming Male and Female are RadioButtons)
                    Male.Checked = false;
                    Female.Checked = false;

                    // Clear city ComboBox (reset to the default or the first item if needed)
                    City.SelectedIndex = -1;  // -1 will reset the ComboBox to no selection, or you can use a default index if you prefer

                    // Dob.Value = DateTime.Now; ;  // Reset to default item
                }
                catch (Exception ex)
                {
                    // Handle any errors that might occur
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    // Ensure the connection is closed
                    con.Close();
                }
            }
        }

        // Email validation using regular expression
        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Update Employee here
        private void UpdateEmployee_Click(object sender, EventArgs e)
        {
            // Clear previous message
            lblMessage.Text = string.Empty;

            // Check if an employee is selected from the list or ID is entered
            if (EmployeeListBox.SelectedItem == null && string.IsNullOrWhiteSpace(id.Text))
            {
                MessageBox.Show("Please select an employee from the list or enter an employee ID to update.");
                return;
            }

            // If an employee is selected from the ListBox
            Employee selectedEmployee = null;
            if (EmployeeListBox.SelectedItem != null)
            {
                selectedEmployee = (Employee)EmployeeListBox.SelectedItem;
            }

            // If no employee is selected, but ID is provided, validate the ID
            int employeeId = 0;
            if (selectedEmployee == null && !string.IsNullOrWhiteSpace(id.Text) && int.TryParse(id.Text, out employeeId))
            {
                // Manually entered ID is valid, fetch employee from DB
                selectedEmployee = GetEmployeeById(employeeId);
            }

            // If no valid employee is selected or ID is not valid, show an error
            if (selectedEmployee == null)
            {
                MessageBox.Show("Invalid employee or ID. Please select a valid employee.");
                return;
            }

            // Now that we have a valid selected employee, perform the update

            // Validate that all fields are filled in
            if (string.IsNullOrWhiteSpace(Name.Text) ||
                string.IsNullOrWhiteSpace(Email.Text) ||
                string.IsNullOrWhiteSpace(Dob.Text) ||
                string.IsNullOrWhiteSpace(Address.Text) ||
                string.IsNullOrWhiteSpace(Password.Text) ||
               (!Male.Checked && !Female.Checked) || // Ensure gender is selected
                City.SelectedIndex == 0)
            {
                MessageBox.Show("Please fill all required fields, including selecting a gender and city.");
                return;
            }

            // Validate Name (should not be empty)
            if (string.IsNullOrWhiteSpace(Name.Text))
            {
                MessageBox.Show("Name cannot be empty.");
                return;
            }

            // Validate Email format using regular expression
            if (!IsValidEmail(Email.Text))
            {
                MessageBox.Show("Invalid email format.");
                return;
            }

            // Validate Date of Birth (DOB should be in a valid date format)
            if (!DateTime.TryParse(Dob.Text, out DateTime parsedDob))
            {
                MessageBox.Show("Invalid Date of Birth.");
                return;
            }

            // Validate Password length (at least 6 characters)
            if (Password.Text.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.");
                return;
            }

            // Determine gender based on selected radio button
            string gender = Male.Checked ? "Male" : "Female"; // Assuming only Male or Female is selected

            // Get the selected city from the combo box
            // Validate that a valid city is selected
            if (City.SelectedIndex == -1 || City.SelectedItem.ToString() == "Select City")
            {
                MessageBox.Show("Please select a valid city.");
                return;
            }

            // Now safely access the selected city
            string city = City.SelectedItem.ToString();

            // Create the connection and command
            string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    con.Open();

                    // Update the data for the selected employee
                    SqlCommand updateCmd = new SqlCommand("UPDATE Employee SET Name = @Name, Email = @Email, Dob = @Dob, Address = @Address, Password = @Password, Gender = @Gender, City = @City WHERE id = @id", con);
                    updateCmd.Parameters.AddWithValue("@id", selectedEmployee.id); // Use selectedEmployee ID
                    updateCmd.Parameters.AddWithValue("@Name", Name.Text);
                    updateCmd.Parameters.AddWithValue("@Email", Email.Text);
                    updateCmd.Parameters.AddWithValue("@Dob", parsedDob);
                    updateCmd.Parameters.AddWithValue("@Address", Address.Text);
                    updateCmd.Parameters.AddWithValue("@Password", Password.Text);
                    updateCmd.Parameters.AddWithValue("@Gender", gender); // Gender from radio buttons
                    updateCmd.Parameters.AddWithValue("@City", city);

                    updateCmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully updated");

                    // Clear input fields after successful update
                    Name.Clear();
                    Email.Clear();
                    // Dob.Clear();
                    Address.Clear();
                    Password.Clear();
                    id.Clear();

                    // Uncheck gender radio buttons (assuming Male and Female are RadioButtons)
                    Male.Checked = false;
                    Female.Checked = false;

                    // Clear city ComboBox (reset to the default or the first item if needed)
                    City.SelectedIndex = -1;  // -1 will reset the ComboBox to no selection, or you can use a default index if you prefer

                    // Dob.Value = DateTime.Now;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    // Ensure the connection is closed
                    con.Close();
                }
            }
        }

        // Delete Employee From Here 
        private void DeleteEmployee_Click_1(object sender, EventArgs e)
        {
            // Clear previous message
            lblMessage.Text = string.Empty;

            // Validate if ID is entered
            if (string.IsNullOrWhiteSpace(id.Text))
            {
                MessageBox.Show("Please enter the ID of the employee you want to delete.");
                return;
            }

            // Check if ID is a valid integer
            if (!int.TryParse(id.Text, out int userID) || userID <= 0)
            {
                MessageBox.Show("Invalid ID entered. Please enter a valid ID.");
                return;
            }

            // Confirm with the user before deletion
            DialogResult result = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Create the connection and command for deletion
                string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    try
                    {
                        // Open the connection
                        con.Open();

                        // Create the delete command
                        SqlCommand deleteCmd = new SqlCommand("DELETE FROM Employee WHERE id = @id", con);
                        deleteCmd.Parameters.AddWithValue("@id", userID);

                        // Execute the command
                        int rowsAffected = deleteCmd.ExecuteNonQuery();

                        // Check if any rows were deleted
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Employee successfully deleted.");
                            // Clear input fields after deletion
                            id.Clear();
                            Name.Clear();
                            Email.Clear();
                            //Dob.Clear();
                            Address.Clear();
                            Password.Clear();

                            // Uncheck gender radio buttons (assuming Male and Female are RadioButtons)
                            Male.Checked = false;
                            Female.Checked = false;

                            // Clear city ComboBox (reset to the default or the first item if needed)
                            City.SelectedIndex = -1;  // -1 will reset the ComboBox to no selection, or you can use a default index if you prefer

                            // Dob.Value = DateTime.Now;
                        }
                        else
                        {
                            MessageBox.Show("No employee found with the provided ID.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally
                    {
                        // Ensure the connection is closed
                        con.Close();
                    }
                }
            }
            else
            {
                // If the user selects 'No', cancel the deletion
                MessageBox.Show("Deletion canceled.");
            }
        }


        //serch Employee And Also Click to go update 

        private void SearchAllEmployees_Click(object sender, EventArgs e)
        {
            // Clear any previous data from the DataGridView
            DataGrid.Rows.Clear();

            // Check if the DataGridView has columns defined (you can define them in the designer or programmatically)
            if (DataGrid.Columns.Count == 0)
            {
                // Define columns if they are not defined (this can be done programmatically)
                DataGrid.Columns.Add("ID", "ID");
                DataGrid.Columns.Add("Name", "Name");
                DataGrid.Columns.Add("Email", "Email");
                DataGrid.Columns.Add("Dob", "Date of Birth");
                DataGrid.Columns.Add("Address", "Address");
                DataGrid.Columns.Add("Gender", "Gender");
                DataGrid.Columns.Add("City", "City");

            }

            // Create the connection string
            string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    con.Open();

                    // Create the query to fetch all employees
                    SqlCommand cmd = new SqlCommand("SELECT id, Name, Email, Dob, Address,Gender,City FROM Employee", con);

                    // Execute the query and retrieve data
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Check if there are rows in the result set
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Add rows to the DataGridView with employee data
                            DataGrid.Rows.Add(
                                reader["id"].ToString(),  // ID
                                reader["Name"].ToString(),  // Name
                                reader["Email"].ToString(),  // Email
                                reader["Dob"].ToString(),  // Date of Birth
                                reader["Address"].ToString(),  // Address
                                reader["Gender"].ToString(),  // Address
                                reader["City"].ToString() // Address

                            );
                        }
                    }
                    else
                    {
                        MessageBox.Show("No employees found.");
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that might occur
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    // Ensure the connection is closed
                    con.Close();
                }
            }
        }


        private void DataGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (e.RowIndex >= 0)
            {
                // Debug: Check the clicked row's ID value
                Console.WriteLine("Row clicked with ID: " + DataGrid.Rows[e.RowIndex].Cells["id"].Value);

                // Get the ID of the selected employee from the DataGridView
                int employeeId = Convert.ToInt32(DataGrid.Rows[e.RowIndex].Cells["id"].Value);

                // Now, you can load the employee details using the employee ID for updating
                LoadEmployeeDetail(employeeId);
            }


        }


        private void LoadEmployeeDetail(int employeeId)
        {
            string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    con.Open();

                    // SQL query to fetch employee details by ID
                    SqlCommand cmd = new SqlCommand("SELECT id, Name, Email, Dob, Address, Password, Gender, City FROM Employee WHERE id = @id", con);
                    cmd.Parameters.AddWithValue("@id", employeeId);

                    // Execute the query and retrieve data
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Debugging: Check the employee details retrieved
                        Console.WriteLine("Loaded employee with ID: " + reader["id"]);

                        // Populate the form fields with the employee details
                        id.Text = reader["id"].ToString(); // Populate ID field as well
                        Name.Text = reader["Name"].ToString();
                        Email.Text = reader["Email"].ToString();
                        Dob.Text = Convert.ToDateTime(reader["Dob"]).ToString("yyyy-MM-dd"); // Ensure correct format
                        Address.Text = reader["Address"].ToString();
                        Password.Text = reader["Password"].ToString();

                        // Handling Gender - assuming you have Male and Female radio buttons
                        string gender = reader["Gender"].ToString();
                        if (gender == "Male")
                        {
                            Male.Checked = true;  // Check the Male radio button
                            Female.Checked = false;
                        }
                        else if (gender == "Female")
                        {
                            Female.Checked = true;  // Check the Female radio button
                            Male.Checked = false;
                        }

                        // Handling City - assuming you have a ComboBox for City
                        string city = reader["City"].ToString();
                        if (!string.IsNullOrEmpty(city))
                        {
                            City.SelectedItem = city;  // Set the selected city in the ComboBox
                        }
                    }
                    else
                    {
                        MessageBox.Show("No employee found with this ID.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    con.Close(); // Ensure the connection is closed
                }
            }
        }


        // Download Employee Details
        private void ImportToExcel_Click(object sender, EventArgs e)
        {
            // Create the connection string
            string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";

            // Create a new Excel application
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Visible = true;

            // Create a new workbook
            var workbook = excelApp.Workbooks.Add();
            var worksheet = workbook.Sheets[1];

            // Set the column headers
            worksheet.Cells[1, 1] = "ID";
            worksheet.Cells[1, 2] = "Name";
            worksheet.Cells[1, 3] = "Email";
            worksheet.Cells[1, 4] = "Date of Birth";
            worksheet.Cells[1, 5] = "Address";
            worksheet.Cells[1, 6] = "Gender";
            worksheet.Cells[1, 7] = "City";

            // Create the connection and command
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    con.Open();

                    // Create the SQL command to fetch all employees
                    SqlCommand cmd = new SqlCommand("SELECT id, Name, Email, Dob, Address, Gender, City FROM Employee", con);

                    // Execute the query and retrieve data
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Row index for Excel (starting from row 2 to leave space for the headers)
                    int rowIndex = 2;

                    // Loop through the data and add it to the Excel sheet
                    while (reader.Read())
                    {
                        // Add data to distinct columns
                        worksheet.Cells[rowIndex, 1] = reader["id"].ToString(); // ID
                        worksheet.Cells[rowIndex, 2] = reader["Name"].ToString(); // Name
                        worksheet.Cells[rowIndex, 3] = reader["Email"].ToString(); // Email
                        worksheet.Cells[rowIndex, 4] = reader["Dob"].ToString(); // Date of Birth
                        worksheet.Cells[rowIndex, 5] = reader["Address"].ToString(); // Address
                        worksheet.Cells[rowIndex, 6] = reader["Gender"].ToString(); // Gender
                        worksheet.Cells[rowIndex, 7] = reader["City"].ToString(); // City

                        rowIndex++;
                    }

                    MessageBox.Show("Data exported to Excel successfully!");
                }
                catch (Exception ex)
                {
                    // Handle any errors that might occur
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    // Ensure the connection is closed
                    con.Close();
                }
            }
        }

        // Print Employee details
        private void PrintDataButton_Click_1(object sender, EventArgs e)
        {
            // Create the connection string
            string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";

            // Create a list to hold the employee data
            List<string> employeeData = new List<string>();

            // Create the connection and command to fetch data from the database
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    con.Open();

                    // SQL query to fetch all employee data (fixed issue with Password field)
                    SqlCommand cmd = new SqlCommand("SELECT id, Name, Email, Dob, Address, Gender, City FROM Employee", con);

                    // Execute the query and retrieve data
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through the data and add it to the employeeData list
                    while (reader.Read())
                    {
                        string dataRow = $"{reader["id"]} | {reader["Name"]} | {reader["Email"]} | {reader["Dob"]} | {reader["Address"]} | {reader["Gender"]} | {reader["City"]}";
                        employeeData.Add(dataRow);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that might occur during the process
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            // Set up the printing
            printDoc.PrintPage += (s, args) =>
            {
                // Set up fonts for headers and data
                Font headerFont = new Font("Arial", 12, FontStyle.Bold);
                Font dataFont = new Font("Arial", 10);

                float yPos = 10;
                float leftMargin = 10;
                float topMargin = 10;
                float lineHeight = 20;

                // Print the header first
                string header = "ID | Name | Email | Date of Birth | Address | Gender | City";
                args.Graphics.DrawString(header, headerFont, Brushes.Black, leftMargin, yPos);
                yPos += lineHeight;  // Move the position down for data

                // Print each row of data
                foreach (var dataRow in employeeData)
                {
                    args.Graphics.DrawString(dataRow, dataFont, Brushes.Black, leftMargin, yPos);
                    yPos += lineHeight;  // Move the position down for next row

                    // Check if we are reaching the bottom of the page and add a new page if necessary
                    if (yPos + lineHeight > args.PageBounds.Height)
                    {
                        args.HasMorePages = true;  // Indicate that there's more content to print
                        return;  // Exit the method to print more pages
                    }
                }

                args.HasMorePages = false;  // No more pages to print
            };

            // Print the document
            printDoc.Print();
        }


        //Exit Button Here 
        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // Auto Fill data in Form When We inser id And Click CheckBox
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Check if an item is selected in the ListBox or ID is entered manually
            if (EmployeeListBox.SelectedItem == null && string.IsNullOrWhiteSpace(id.Text))
            {
                // If no item is selected and no ID is entered, show a message to the user
                MessageBox.Show("Please select an employee from the list or enter an employee ID to update.");
                return;
            }

            // If an employee is selected from the list, get the employee ID from the ListBox item
            int employeeId = 0;

            if (EmployeeListBox.SelectedItem != null)
            {
                Employee selectedEmployee = (Employee)EmployeeListBox.SelectedItem;
                employeeId = selectedEmployee.id;
            }
            else if (!string.IsNullOrWhiteSpace(id.Text) && int.TryParse(id.Text, out employeeId))
            {
                // If the ID is manually entered, use it
                // Do additional validation if needed
            }
            else
            {
                MessageBox.Show("Please enter a valid employee ID.");
                return;
            }

            // Call the method to load employee details by ID
            LoadEmployeeDetails(employeeId);
        }
        private void LoadEmployeeDetails(int employeeId)
        {
            string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    con.Open();

                    // SQL query to fetch employee details by ID
                    SqlCommand cmd = new SqlCommand("SELECT Name, Email, Dob, Address, Password, Gender, City FROM Employee WHERE id = @id", con);
                    cmd.Parameters.AddWithValue("@id", employeeId);

                    // Execute the query and retrieve data
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Populate the form fields with the employee details
                        Name.Text = reader["Name"].ToString();
                        Email.Text = reader["Email"].ToString();

                        // Ensure correct Date of Birth format
                        if (reader["Dob"] != DBNull.Value)
                        {
                            Dob.Value = Convert.ToDateTime(reader["Dob"]);  // Using DateTimePicker control directly
                        }

                        Address.Text = reader["Address"].ToString();
                        Password.Text = reader["Password"].ToString();

                        // Handling Gender (RadioButton)
                        string Gender = reader["Gender"].ToString().Trim();
                        if (Gender == "Male")
                        {
                            Male.Checked = true;  // Check the Male radio button
                        }
                        else if (Gender == "Female")
                        {
                            Female.Checked = true;  // Check the Female radio button
                        }

                        // Handling City (ComboBox/DropDown)
                        string city = reader["City"].ToString();
                        if (!string.IsNullOrEmpty(city))
                        {
                            int index = City.Items.IndexOf(city);
                            if (index >= 0)
                            {
                                City.SelectedIndex = index;  // Set the index of the ComboBox to the city's position
                            }
                            else
                            {
                                MessageBox.Show("City not found in the list. Please ensure the city is available in the dropdown.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No employee found with this ID.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();  // Ensure the connection is closed
                }
            }
        }


        // Helper method to get an employee by ID (this can be called when manually entering an ID)
        private Employee GetEmployeeById(int employeeId)
        {
            string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id, Name, Email, Dob, Address, Password,Gender,City FROM Employee WHERE id = @id", con);
                    cmd.Parameters.AddWithValue("@id", employeeId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Employee
                        {
                            id = (int)reader["id"],
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Dob = Convert.ToDateTime(reader["Dob"]),
                            Address = reader["Address"].ToString(),
                            Password = reader["Password"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            City = reader["City"].ToString()

                        };
                    }
                }
                catch (Exception)
                {
                    // Handle exceptions as necessary
                }
            }
            return null; // Return null if no employee is found with the provided ID
        }


        // Inside Form1.cs
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Reload this form (Form1)
            Form1 newForm = new Form1();  // Replace 'Form1' with your form's actual class name
            newForm.Show();
            this.Close();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Open Form2 when Form1 is closed
            Form2 newForm2 = new Form2(); // Make sure Form2 is a valid form
            newForm2.Show();
        }




        // Auto Fill data in Form When We inser id And Click CheckBox  End Here 


        internal class UpdateEmployeeButton
        {
            public static bool Enabled { get; internal set; }
        }


        private void Form2_Load_1(object sender, EventArgs e)
        {
            label8.Text = Properties.Settings.Default.username;
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string city = City.SelectedItem.ToString();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }



        private void Female_CheckedChanged(object sender, EventArgs e, Gender gender)
        {

        }

        private class Gender
        {
            internal static object Text;

            internal static void Clear()
            {
                throw new NotImplementedException();
            }

            public static implicit operator Gender(string v)
            {
                throw new NotImplementedException();
            }
        }


        private void label8_Click(object sender, EventArgs e)
        {


        }



        private Employee GetEmployeeByid(int employeeId)
        {
            string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id, Name, Email, Dob, Address, Password, Gender, City FROM Employee WHERE id = @id", con);
                    cmd.Parameters.AddWithValue("@id", employeeId);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        return new Employee
                        {
                            id = (int)reader["id"],
                            Name = reader["Name"].ToString(),
                            Email = reader["Email"].ToString(),
                            Dob = Convert.ToDateTime(reader["Dob"]),
                            Address = reader["Address"].ToString(),
                            Password = reader["Password"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            City = reader["City"].ToString()
                        };
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            return null; // Return null if no employee is found with the provided ID
        }





        // Drop Down City




        // condiation for check male or female
        private void Male_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Male";
            Gender.Text = gender;
        }

        private void Female_CheckedChanged(object sender, EventArgs e)
        {
            gender = "Female";
            Gender.Text = gender;


        }




        private void NotePad_Click_1(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                Title = "Save Notepad File",
                FileName = "EmployeeData.txt"
            };

            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            string txtFilePath = saveFileDialog.FileName;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id, Name, Email, Dob, Address, Gender, City FROM Employee", con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<string> employeeData = new List<string>();

                    // Format header line
                    string headers = string.Format("{0,-5} {1,-15} {2,-25} {3,-15} {4,-20} {5,-10} {6,-15}",
                        "ID", "Name", "Email", "DOB", "Address", "Gender", "City");
                    string underline = new string('=', headers.Length);

                    // Read data from the database
                    while (reader.Read())
                    {
                        string line = string.Format("{0,-5} {1,-15} {2,-25} {3,-15} {4,-20} {5,-10} {6,-15}",
                            reader["id"],
                            reader["Name"],
                            reader["Email"],
                            Convert.ToDateTime(reader["Dob"]).ToString("yyyy-MM-dd"),
                            reader["Address"],
                            reader["Gender"],
                            reader["City"]);
                        employeeData.Add(line);
                    }

                    reader.Close();

                    // Paginate the data - 72 records per page
                    int recordsPerPage = 72;
                    int totalPages = (int)Math.Ceiling((double)employeeData.Count / recordsPerPage);

                    using (StreamWriter writer = new StreamWriter(txtFilePath))
                    {
                        for (int page = 0; page < totalPages; page++)
                        {
                            writer.WriteLine($"--- Page {page + 1} ---\n");

                            // Underline above and below the header
                            writer.WriteLine(underline);
                            writer.WriteLine(headers);
                            writer.WriteLine(underline);

                            var pageData = employeeData.Skip(page * recordsPerPage).Take(recordsPerPage);

                            foreach (var line in pageData)
                            {
                                writer.WriteLine(line);
                            }

                            writer.WriteLine(); // Empty line after each page
                        }
                    }

                    MessageBox.Show("Data exported to Notepad successfully.");
                }

                System.Diagnostics.Process.Start("notepad.exe", txtFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void ClearBtn_Click(object sender, EventArgs e)
        {
            // Clear textboxes
            id.Clear();
            Name.Clear();
            Email.Clear();
            Address.Clear();
            Password.Clear();

            // Uncheck gender radio buttons (assuming Male and Female are RadioButtons)
            Male.Checked = false;
            Female.Checked = false;

            // Clear city ComboBox (reset to the default or the first item if needed)
            City.SelectedIndex = -1;  // -1 will reset the ComboBox to no selection, or you can use a default index if you prefer

            //Dob.Value = DateTime.Now;  // Reset the DatePicker to the current date (or to a specific default date)
        }


        //private void Form_Load(object sender, EventArgs e)
        //{
        //    this.Text = "Form2";

        //    List<string> educationLevels = new List<string>
        //    {
        //        "High School",
        //        "Intermediate",
        //        "Graduation",
        //        "Post Graduation",
        //        "Diploma",
        //        "PhD"
        //    };

        //    Qualification.Items.AddRange(educationLevels.ToArray());
        //}

        //private void Qualification_ItemCheck(object sender, ItemCheckEventArgs e)
        //{
        //    this.BeginInvoke((MethodInvoker)delegate
        //    {
        //        List<string> selectedQualifications = new List<string>();

        //        // Go through all items
        //        for (int i = 0; i < Qualification.Items.Count; i++)
        //        {
        //            bool isChecked = Qualification.GetItemChecked(i);

        //            // This one is being changed, so we use e.NewValue
        //            if (i == e.Index)
        //            {
        //                isChecked = (e.NewValue == CheckState.Checked);
        //            }

        //            if (isChecked)
        //            {
        //                selectedQualifications.Add(Qualification.Items[i].ToString());
        //            }
        //        }

        //        // Join into comma-separated string or do whatever you want
        //        string result = string.Join(", ", selectedQualifications);
        //        // For example, show or assign to a label
        //        MessageBox.Show("Selected Qualifications: " + result);
        //        // Or: someTextBox.Text = result;
        //    });
        //}


        private void EmpId_Click(object sender, EventArgs e)
        {

        }


        //private void AddDegree_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Input validation
        //        if (string.IsNullOrWhiteSpace(Employeeid.Text) ||
        //            Qualification.SelectedItem == null ||
        //            string.IsNullOrWhiteSpace(Year.Text) ||
        //            string.IsNullOrWhiteSpace(Percentage.Text) ||
        //            string.IsNullOrWhiteSpace(Emp_Name.Text) ||
        //            string.IsNullOrWhiteSpace(College.Text) ||
        //            string.IsNullOrWhiteSpace(Marks.Text))
        //        {
        //            MessageBox.Show("Please fill all fields before submitting.");
        //            return;
        //        }

        //        int empId = int.Parse(Employeeid.Text);
        //        int year = int.Parse(Year.Text);
        //        float percentage = float.Parse(Percentage.Text);
        //        string qualification = Qualification.SelectedItem.ToString();

        //        string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True;";

        //        using (SqlConnection conn = new SqlConnection(connectionString))
        //        {
        //            conn.Open();

        //            // ✅ Step 1: Check if employee exists
        //            string checkEmployeeQuery = "SELECT COUNT(*) FROM Employee WHERE id = @Employeeid";

        //            using (SqlCommand checkCmd = new SqlCommand(checkEmployeeQuery, conn))
        //            {
        //                checkCmd.Parameters.AddWithValue("@Employeeid", empId);
        //                int count = (int)checkCmd.ExecuteScalar();

        //                if (count == 0)
        //                {
        //                    MessageBox.Show("Employee ID not found. Please enter a valid employee.");
        //                    return;
        //                }
        //            }

        //            // ✅ Step 2: Insert qualification if employee exists
        //            string insertQuery = @"INSERT INTO Qualification 
        //  (id, Qualification, Year, Percentage, Emp_Name, College, Marks)
        //  VALUES (@Employeeid, @Qualification, @Year, @Percentage, @Emp_Name, @College, @Marks)";

        //            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
        //            {
        //                cmd.Parameters.AddWithValue("@Employeeid", empId);
        //                cmd.Parameters.AddWithValue("@Qualification", qualification);
        //                cmd.Parameters.AddWithValue("@Year", year);
        //                cmd.Parameters.AddWithValue("@Percentage", percentage);
        //                cmd.Parameters.AddWithValue("@Emp_Name", Emp_Name.Text);
        //                cmd.Parameters.AddWithValue("@College", College.Text);
        //                cmd.Parameters.AddWithValue("@Marks", Marks.Text);

        //                cmd.ExecuteNonQuery();
        //                MessageBox.Show("Qualification inserted successfully!");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error:\n" + ex.ToString());
        //    }
        //}


        // Event for updating Percentage when Marks or TotalMarks changes

        private void Marks_TextChanged(object sender, EventArgs e)
        {
            CalculatePercentage();
        }

        private void TotalMarks_TextChanged(object sender, EventArgs e)
        {
            CalculatePercentage();
        }

        private void CalculatePercentage()
        {
            // Check if both Marks and TotalMarks have valid values
            if (float.TryParse(Marks.Text, out float marks) && float.TryParse(TotalMarks.Text, out float totalMarks))
            {
                if (totalMarks > 0)
                {
                    // Calculate the percentage
                    float percentage = (marks / totalMarks) * 100;
                    Percentage.Text = percentage.ToString("F2");  // Display percentage with two decimal places
                }
                else
                {
                    Percentage.Text = "0";  // Set percentage to 0 if TotalMarks is 0
                }
            }
            else
            {
                Percentage.Clear();  // Clear the percentage field if invalid input
            }
        }

        private void AddDegree_Click(object sender, EventArgs e)
        {
            try
            {
                // Input presence validation
                if (string.IsNullOrWhiteSpace(Employeeid.Text) ||
                    Qualification.SelectedItem == null ||
                    Year.SelectedItem == null ||
                    string.IsNullOrWhiteSpace(Marks.Text) ||
                    string.IsNullOrWhiteSpace(TotalMarks.Text) ||
                    string.IsNullOrWhiteSpace(Emp_Name.Text) ||
                    string.IsNullOrWhiteSpace(College.Text))
                {
                    MessageBox.Show("Please fill all fields before submitting.");
                    return;
                }

                // Type validation for Employee ID
                if (!int.TryParse(Employeeid.Text, out int empId))
                {
                    MessageBox.Show("Employee ID must be a valid integer.");
                    return;
                }

                // Type validation for Year
                if (!int.TryParse(Year.SelectedItem.ToString(), out int year))
                {
                    MessageBox.Show("Selected year is not valid.");
                    return;
                }

                // Parse Marks and TotalMarks to ensure they are valid
                if (!float.TryParse(Marks.Text, out float marks))
                {
                    MessageBox.Show("Marks must be a valid number.");
                    return;
                }

                if (!float.TryParse(TotalMarks.Text, out float totalMarks))
                {
                    MessageBox.Show("Total Marks must be a valid number.");
                    return;
                }

                if (totalMarks == 0)
                {
                    MessageBox.Show("Total Marks cannot be zero.");
                    return;
                }

                // Calculate the percentage
                float percentage = (marks / totalMarks) * 100;
                Percentage.Text = percentage.ToString("F2"); // Show percentage with two decimal places

                string qualification = Qualification.SelectedItem.ToString();
                string empName = Emp_Name.Text.Trim();
                string college = College.Text.Trim();

                string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Step 1: Check if employee exists
                    string checkEmployeeQuery = "SELECT COUNT(*) FROM Employee WHERE id = @Employeeid";
                    using (SqlCommand checkCmd = new SqlCommand(checkEmployeeQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Employeeid", empId);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count == 0)
                        {
                            MessageBox.Show("Employee ID not found. Please enter a valid employee.");
                            return;
                        }
                    }

                    // Step 2: Check for duplicate qualification for this employee
                    string duplicateQuery = "SELECT COUNT(*) FROM Qualification WHERE id = @Employeeid AND Qualification = @Qualification";
                    using (SqlCommand duplicateCmd = new SqlCommand(duplicateQuery, conn))
                    {
                        duplicateCmd.Parameters.AddWithValue("@Employeeid", empId);
                        duplicateCmd.Parameters.AddWithValue("@Qualification", qualification);
                        int duplicateCount = (int)duplicateCmd.ExecuteScalar();

                        if (duplicateCount > 0)
                        {
                            MessageBox.Show("This qualification already exists for the selected employee.");
                            return;
                        }
                    }

                    // Step 3: Insert qualification
                    string insertQuery = @"INSERT INTO Qualification 
                                   (id, Qualification, Year, Percentage, Emp_Name, College, Marks, TotalMarks) 
                                   VALUES 
                                   (@Employeeid, @Qualification, @Year, @Percentage, @Emp_Name, @College, @Marks, @TotalMarks)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Employeeid", empId);
                        cmd.Parameters.AddWithValue("@Qualification", qualification);
                        cmd.Parameters.AddWithValue("@Year", year);
                        cmd.Parameters.AddWithValue("@Percentage", percentage);
                        cmd.Parameters.AddWithValue("@Emp_Name", empName);
                        cmd.Parameters.AddWithValue("@College", college);
                        cmd.Parameters.AddWithValue("@Marks", marks);
                        cmd.Parameters.AddWithValue("@TotalMarks", totalMarks);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Qualification inserted successfully!");

                        // Clear form after successful insert
                        ClearFields();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:\n" + ex.Message);
            }
        }




        private void ClearFields()
        {
            Employeeid.Clear();
            Qualification.SelectedIndex = -1; // Deselect dropdown
            Year.SelectedIndex = -1;
            Percentage.Clear();
            Emp_Name.Clear();
            College.Clear();
            Marks.Clear();
            TotalMarks.Clear();

        }




        private void button1_Click(object sender, EventArgs e)
        {
            id.Clear();
            Emp_Name.Clear();
            College.Clear();
            Qualification.SelectedIndex = -1; // Deselect dropdown
            Year.SelectedIndex = -1;
            Percentage.Clear();
            Marks.Clear();
            TotalMarks.Clear();

        }

        private void Qualification_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Qualification.SelectedIndex > 0)
            {
                string qualification = Qualification.SelectedItem.ToString();
                MessageBox.Show("You selected: " + qualification);
            }
        }

        private void Emp_id_TextChanged(object sender, EventArgs e)
        {

        }

        private void Year_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Year.SelectedIndex > 0)
            {
                string year = Year.SelectedItem.ToString();
                MessageBox.Show("You selected: " + Year);



            }
        }

        // it's find button not delete 
        private void Delete_Click (object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Employeeid.Text))
            {
                return; // Employee ID is needed to search
            }

            if (!int.TryParse(Employeeid.Text, out int empId))
            {
                MessageBox.Show("Employee ID must be a valid integer.");
                return;
            }

            if (Qualification.SelectedItem == null)
            {
                return;
            }

            string qualification = Qualification.SelectedItem.ToString();
            string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"SELECT Year, Percentage, Emp_Name, College, Marks,TotalMarks FROM Qualification WHERE id = @Employeeid AND Qualification = @Qualification";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Employeeid", empId);
                    cmd.Parameters.AddWithValue("@Qualification", qualification);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Populate the form fields
                            Year.SelectedItem = reader["Year"].ToString();
                            Percentage.Text = reader["Percentage"].ToString();
                            Emp_Name.Text = reader["Emp_Name"].ToString();
                            College.Text = reader["College"].ToString();
                            Marks.Text = reader["Marks"].ToString();
                            TotalMarks.Text = reader["TotalMarks"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("No matching qualification data found.");
                        }
                    }
                }
            }
        }
        // it's a delete Button 
        private void Delete_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Employeeid.Text))
            {
                MessageBox.Show("Please enter the Employee ID.");
                return;
            }

            if (!int.TryParse(Employeeid.Text, out int empId))
            {
                MessageBox.Show("Employee ID must be a valid integer.");
                return;
            }

            if (Qualification.SelectedItem == null)
            {
                MessageBox.Show("Please select a qualification.");
                return;
            }

            string qualification = Qualification.SelectedItem.ToString();
            string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // ✅ Step 1: Optional — show existing data before deletion
                string selectQuery = @"SELECT Year, Percentage, Emp_Name, College, Marks 
                               FROM Qualification 
                               WHERE id = @Employeeid AND Qualification = @Qualification";

                using (SqlCommand selectCmd = new SqlCommand(selectQuery, conn))
                {
                    selectCmd.Parameters.AddWithValue("@Employeeid", empId);
                    selectCmd.Parameters.AddWithValue("@Qualification", qualification);

                    using (SqlDataReader reader = selectCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Year.SelectedItem = reader["Year"].ToString();
                            Percentage.Text = reader["Percentage"].ToString();
                            Emp_Name.Text = reader["Emp_Name"].ToString();
                            College.Text = reader["College"].ToString();
                            Marks.Text = reader["Marks"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("No matching qualification data found.");
                            return;
                        }
                    }
                }

                // ✅ Step 2: Delete the record
                string deleteQuery = @"DELETE FROM Qualification WHERE id = @Employeeid AND Qualification = @Qualification";

                using (SqlCommand deleteCmd = new SqlCommand(deleteQuery, conn))
                {
                    deleteCmd.Parameters.AddWithValue("@Employeeid", empId);
                    deleteCmd.Parameters.AddWithValue("@Qualification", qualification);

                    int rowsAffected = deleteCmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Qualification deleted successfully.");
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("No matching qualification found to delete.");
                    }
                }
            }
        }

    }
}