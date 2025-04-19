using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class Form1 : Form
    {

        private readonly SqlConnection con = new SqlConnection("Data Source=DESKTOP-4HDIA6Q;Initial Catalog=Dashboard;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
       // private object bunifuMaterialtxtname;

        public static string Users { get; internal set; }

        public Form1()
        {
            InitializeComponent();
        }

        // This method will toggle the password visibility
  

        private async void Loginbtn_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("SELECT * FROM Users WHERE username = @username AND userpass = @userpass", con);
                cmd.Parameters.AddWithValue("@username", txtname.Text);
                cmd.Parameters.AddWithValue("@userpass", txtpass.Text);

                // Open the connection
                await con.OpenAsync();


                // Execute the command and check for rows
                dr = await cmd.ExecuteReaderAsync();
                if (dr.HasRows)
                {
                     Hide(); // Hide this form
                    string username = txtname.Text;

                    // ✅ Save username in application settings
                    Properties.Settings.Default.username = username;
                    Properties.Settings.Default.Save(); // Save the changes

                    username = txtname.Text;


                    Form2 form2 = new Form2();
                    this.Hide();
                    form2.Show();
                }
                else
                {
                    MessageBox.Show("Login Failed, Try Again!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPassword.Checked)
            {
                txtpass.PasswordChar = '\0'; 
            }
            else
            {
                txtpass.PasswordChar = '*';
            }

        }

        private void Clearbtns_Click(object sender, EventArgs e)
        {
            txtname.Clear(); // Clears the username text box
            txtpass.Clear(); // Clears the password text box
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
