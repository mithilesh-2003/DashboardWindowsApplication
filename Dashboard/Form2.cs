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

        }

        private void InitializeDataGridColumns()
        {
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
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
                label1.Text = "Welcome To Dashboard :" + Form1.Users;
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
                    cmd.Parameters.AddWithValue("@Dob", parsedDob); // Use parsed DateTime for DOB
                    cmd.Parameters.AddWithValue("@Address", Address.Text);
                    cmd.Parameters.AddWithValue("@Password", Password.Text);
                    cmd.Parameters.AddWithValue("@Gender", gender); // Gender from radio buttons
                    cmd.Parameters.AddWithValue("@City", city); // City from combo box

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

        // data Grid For sowing in list data
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

        // Employee Details load 
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

        // Refresh Fage Not working
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Refresh the form (reload the page)
            this.Refresh();

        }

        private void YourForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Optional: Perform any necessary cleanup or actions when the form is closed
            var newForm = new YourForm();
            newForm.Show();
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

        // Clear Items 
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
        // Drop Down City
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string city = City.SelectedItem.ToString();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

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

        //private void UpdateEmployee_Click(object sender, EventArgs e)
        //{
        //    lblMessage.Text = string.Empty;

        //    // Validate that all fields are filled in
        //    if (string.IsNullOrWhiteSpace(Name.Text) ||
        //        string.IsNullOrWhiteSpace(Email.Text) ||
        //        string.IsNullOrWhiteSpace(Dob.Text) ||
        //        string.IsNullOrWhiteSpace(Address.Text) ||
        //        string.IsNullOrWhiteSpace(Password.Text) ||
        //        (!Male.Checked && !Female.Checked) || // Ensure gender is selected
        //        City.SelectedIndex == 0) // Ensure city is selected (no default value)
        //    {
        //        MessageBox.Show("Please fill all required fields, including selecting a gender and city.");
        //        return;
        //    }

        //    // Validate Name (should not be empty)
        //    if (string.IsNullOrWhiteSpace(Name.Text))
        //    {
        //        MessageBox.Show("Name cannot be empty.");
        //        return;
        //    }

        //    // Validate Email format using regular expression
        //    if (!IsValidEmail(Email.Text))
        //    {
        //        MessageBox.Show("Invalid email format.");
        //        return;
        //    }

        //    // Validate Date of Birth (DOB should be in a valid date format)
        //    if (!DateTime.TryParse(Dob.Text, out DateTime parsedDob))
        //    {
        //        MessageBox.Show("Invalid Date of Birth.");
        //        return;
        //    }

        //    // Validate Password length (at least 6 characters)
        //    if (Password.Text.Length < 6)
        //    {
        //        MessageBox.Show("Password must be at least 6 characters long.");
        //        return;
        //    }

        //    // Determine gender based on selected radio button
        //    string gender = Male.Checked ? "Male" : "Female"; // Assuming only Male or Female is selected

        //    // Get the selected city from the combo box
        //    // Validate that a valid city is selected
        //    if (City.SelectedIndex == -1 || City.SelectedItem.ToString() == "Select City")
        //    {
        //        MessageBox.Show("Please select a valid city.");
        //        return;
        //    }

        //    // Now safely access the selected city
        //    string city = City.SelectedItem.ToString();

        //    // Assuming you have an employee ID or a way to identify which employee to update
        //    int employeeId = GetEmployeeId(); // This should be defined somewhere, perhaps from a selected employee in the UI.

        //    if (employeeId == 0)
        //    {
        //        MessageBox.Show("No employee selected to update.");
        //        return;
        //    }

        //    // Create the connection and command for updating the database
        //    string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        try
        //        {
        //            // Open the connection
        //            con.Open();

        //            // Create the command
        //            SqlCommand cmd = new SqlCommand("UPDATE Employee " +
        //                                            "SET Name = @Name, Email = @Email, Dob = @Dob, Address = @Address, Password = @Password, Gender = @Gender, City = @City " +
        //                                            "WHERE EmployeeId = @EmployeeId", con);

        //            // Add parameters
        //            cmd.Parameters.AddWithValue("@Name", Name.Text);
        //            cmd.Parameters.AddWithValue("@Email", Email.Text);
        //            cmd.Parameters.AddWithValue("@Dob", parsedDob); // Use parsed DateTime for DOB
        //            cmd.Parameters.AddWithValue("@Address", Address.Text);
        //            cmd.Parameters.AddWithValue("@Password", Password.Text);
        //            cmd.Parameters.AddWithValue("@Gender", gender); // Gender from radio buttons
        //            cmd.Parameters.AddWithValue("@City", city); // City from combo box
        //            cmd.Parameters.AddWithValue("@EmployeeId", employeeId); // Employee ID to identify which record to update

        //            // Execute the command
        //            cmd.ExecuteNonQuery();

        //            // Display success message
        //            MessageBox.Show("Employee details successfully updated");

        //            // Optionally, clear input fields or reset UI after the update
        //            Name.Clear();
        //            Email.Clear();
        //            Address.Clear();
        //            Password.Clear();
        //            Male.Checked = false; // Uncheck the radio buttons
        //            Female.Checked = false;
        //            City.SelectedIndex = 0; // Reset the dropdown to default value
        //        }
        //        catch (Exception ex)
        //        {
        //            // Handle any errors that might occur
        //            MessageBox.Show("Error: " + ex.Message);
        //        }
        //        finally
        //        {
        //            // Ensure the connection is closed
        //            con.Close();
        //        }

        //    }

        //}

        //private int GetEmployeeId()
        //{
        //    throw new NotImplementedException();
        //}

        //private int GetEmployeeId()
        //{
        //    throw new NotImplementedException();
        //}

        private void label8_Click(object sender, EventArgs e)
        {


        }
      

        // get Employee by Id 
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

       
    }
}