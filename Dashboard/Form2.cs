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




namespace Dashboard
{
    public partial class Form2 : Form

    {
        private PrintDocument printDoc = new PrintDocument();
        private object employeeListBox;

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
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Welcome, " + Form1.Users;
        }


        // Add Employee

        private void Addbtn_Click(object sender, EventArgs e)
        {
            // Clear previous message
            lblMessage.Text = string.Empty;

            // Validate that all fields are filled in
            if (string.IsNullOrWhiteSpace(Name.Text) ||
                string.IsNullOrWhiteSpace(Email.Text) ||
                string.IsNullOrWhiteSpace(Dob.Text) ||
                string.IsNullOrWhiteSpace(Address.Text) ||
                string.IsNullOrWhiteSpace(Password.Text))
            {
                MessageBox.Show("All fields must be filled.");
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

            // Create the connection and command
            string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    con.Open();

                    // Create the command
                    SqlCommand cmd = new SqlCommand("INSERT INTO Employee (Name, Email, Dob, Address, Password) VALUES (@Name, @Email, @Dob, @Address, @Password)", con);

                    // Add parameters
                    cmd.Parameters.AddWithValue("@Name", Name.Text);
                    cmd.Parameters.AddWithValue("@Email", Email.Text);
                    cmd.Parameters.AddWithValue("@Dob", parsedDob); // Use parsed DateTime for DOB
                    cmd.Parameters.AddWithValue("@Address", Address.Text);
                    cmd.Parameters.AddWithValue("@Password", Password.Text); // Access the Password TextBox's Text

                    // Execute the command
                    cmd.ExecuteNonQuery();

                    // Display success message
                    MessageBox.Show("Successfully inserted");

                    // Clear input fields after successful insert
                    Name.Clear();
                    Email.Clear();
                    Dob.Clear();
                    Address.Clear();
                    Password.Clear();
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




        //Exit page 

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Update Employee  from here Start first is right second in not
        /*  private void UpdateEmployee_Click(object sender, EventArgs e)
          {
              // Clear previous message
              lblMessage.Text = string.Empty;

              // Validate that all fields are filled in
              if (string.IsNullOrWhiteSpace(Name.Text) ||
                  string.IsNullOrWhiteSpace(Email.Text) ||
                  string.IsNullOrWhiteSpace(Dob.Text) ||
                  string.IsNullOrWhiteSpace(Address.Text) ||
                  string.IsNullOrWhiteSpace(Password.Text))
              {
                  MessageBox.Show("All fields must be filled.");
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

              // Create the connection and command
              string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";
              using (SqlConnection con = new SqlConnection(connectionString))
              {
                  try
                  {
                      // Open the connection
                      con.Open();

                      // Update the data for the provided ID
                      int userID;
                      if (int.TryParse(id.Text, out userID) && userID > 0)
                      {
                          // Update command
                          SqlCommand updateCmd = new SqlCommand("UPDATE Employee SET Name = @Name, Email = @Email, Dob = @Dob, Address = @Address, Password = @Password WHERE id = @id", con);
                          updateCmd.Parameters.AddWithValue("@id", userID);
                          updateCmd.Parameters.AddWithValue("@Name", Name.Text);
                          updateCmd.Parameters.AddWithValue("@Email", Email.Text);
                          updateCmd.Parameters.AddWithValue("@Dob", parsedDob);
                          updateCmd.Parameters.AddWithValue("@Address", Address.Text);
                          updateCmd.Parameters.AddWithValue("@Password", Password.Text);

                          updateCmd.ExecuteNonQuery();
                          MessageBox.Show("Successfully updated");

                          // Clear input fields after successful update
                          Name.Clear();
                          Email.Clear();
                          Dob.Clear();
                          Address.Clear();
                          Password.Clear();
                      }
                      else
                      {
                          MessageBox.Show("Invalid ID, please enter a valid ID to update.");
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
          }*/


        private void UpdateEmployee_Click_1(object sender, EventArgs e)
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
                string.IsNullOrWhiteSpace(Password.Text))
            {
                MessageBox.Show("All fields must be filled.");
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

            // Create the connection and command
            string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    con.Open();

                    // Update the data for the selected employee
                    SqlCommand updateCmd = new SqlCommand("UPDATE Employee SET Name = @Name, Email = @Email, Dob = @Dob, Address = @Address, Password = @Password WHERE id = @id", con);
                    updateCmd.Parameters.AddWithValue("@id", selectedEmployee.id); // Use selectedEmployee ID
                    updateCmd.Parameters.AddWithValue("@Name", Name.Text);
                    updateCmd.Parameters.AddWithValue("@Email", Email.Text);
                    updateCmd.Parameters.AddWithValue("@Dob", parsedDob);
                    updateCmd.Parameters.AddWithValue("@Address", Address.Text);
                    updateCmd.Parameters.AddWithValue("@Password", Password.Text);

                    updateCmd.ExecuteNonQuery();
                    MessageBox.Show("Successfully updated");

                    // Clear input fields after successful update
                    Name.Clear();
                    Email.Clear();
                    Dob.Clear();
                    Address.Clear();
                    Password.Clear();
                    id.Clear();
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

        // Helper method to get an employee by ID (this can be called when manually entering an ID)
        private Employee GetEmployeeById(int employeeId)
        {
            string connectionString = "Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True";
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT id, Name, Email, Dob, Address, Password FROM Employee WHERE id = @id", con);
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
                            Password = reader["Password"].ToString()
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

        // Update Employee  from here End 



        //Delete Employee
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
                            Dob.Clear();
                            Address.Clear();
                            Password.Clear();
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


        //serch Employee

        private void SearchAllEmployees_Click_1(object sender, EventArgs e)
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
                    SqlCommand cmd = new SqlCommand("SELECT id, Name, Email, Dob, Address FROM Employee", con);

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
                                reader["Address"].ToString()  // Address
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

        private void DataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if columns are not already added to prevent duplicates
            DataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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

            // Create the connection and command
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    con.Open();

                    // Create the SQL command to fetch all employees
                    SqlCommand cmd = new SqlCommand("SELECT id, Name, Email, Dob, Address FROM Employee", con);

                    // Execute the query and retrieve data
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Row index for Excel (starting from row 2 to leave space for the headers)
                    int rowIndex = 2;

                    // Loop through the data and add it to the Excel sheet
                    while (reader.Read())
                    {
                        worksheet.Cells[rowIndex, 1] = reader["id"].ToString(); // ID
                        worksheet.Cells[rowIndex, 2] = reader["Name"].ToString(); // Name
                        worksheet.Cells[rowIndex, 3] = reader["Email"].ToString(); // Email
                        worksheet.Cells[rowIndex, 4] = reader["Dob"].ToString(); // Date of Birth
                        worksheet.Cells[rowIndex, 5] = reader["Address"].ToString(); // Address

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

        // Print Employee detail

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

                    // SQL query to fetch all employee data
                    SqlCommand cmd = new SqlCommand("SELECT id, Name, Email, Dob, Address FROM Employee ,Password", con);

                    // Execute the query and retrieve data
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through the data and add it to the employeeData list
                    while (reader.Read())
                    {
                        string dataRow = $"{reader["id"]} | {reader["Name"]} | {reader["Email"]} | {reader["Dob"]} | {reader["Address"]}| {reader["Password"]}";
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
                // Print the header first
                float yPos = 10;
                string header = "ID | Name | Email | Date of Birth | Address | Password";
                args.Graphics.DrawString(header, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 10, yPos);
                yPos += 20;  // Move the position down for data

                // Print each row of data
                foreach (var dataRow in employeeData)
                {
                    args.Graphics.DrawString(dataRow, new Font("Arial", 10), Brushes.Black, 10, yPos);
                    yPos += 20;  // Move the position down for next row

                    // Check if we are reaching the bottom of the page and add a new page if necessary
                    if (yPos + 20 > args.PageBounds.Height)
                    {
                        args.HasMorePages = true;
                        return;
                    }
                }

                args.HasMorePages = false;  // No more pages to print
            };

            // Print the document
            printDoc.Print();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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
                    SqlCommand cmd = new SqlCommand("SELECT Name, Email, Dob, Address, Password FROM Employee WHERE id = @id", con);
                    cmd.Parameters.AddWithValue("@id", employeeId);

                    // Execute the query and retrieve data
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Populate the form fields with the employee details
                        Name.Text = reader["Name"].ToString();
                        Email.Text = reader["Email"].ToString();
                        Dob.Text = Convert.ToDateTime(reader["Dob"]).ToString("yyyy-MM-dd"); // Ensure correct format
                        Address.Text = reader["Address"].ToString();
                        Password.Text = reader["Password"].ToString();
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


        // Auto Fill data in Form When We inser id And Click CheckBox  End Here 


        internal class UpdateEmployeeButton
        {
            public static bool Enabled { get; internal set; }
        }

        private void Form2_Load_1(object sender, EventArgs e)
        {

        }

       
    }
}

