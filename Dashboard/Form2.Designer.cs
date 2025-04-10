using System;

namespace Dashboard
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.Exitbtn = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.TextBox();
            this.Email = new System.Windows.Forms.TextBox();
            this.Name = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Dob = new System.Windows.Forms.DateTimePicker();
            this.City1 = new System.Windows.Forms.Label();
            this.City = new System.Windows.Forms.ComboBox();
            this.Female = new System.Windows.Forms.RadioButton();
            this.Male = new System.Windows.Forms.RadioButton();
            this.Gend = new System.Windows.Forms.Label();
            this.ClearBtn = new System.Windows.Forms.Button();
            this.UpdateEmployee = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Addbtn = new System.Windows.Forms.Button();
            this.DeleteEmployee = new System.Windows.Forms.Button();
            this.SearchAllEmployees = new System.Windows.Forms.Button();
            this.ImportToExcel = new System.Windows.Forms.Button();
            this.PrintDataButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exitbtn
            // 
            this.Exitbtn.ForeColor = System.Drawing.Color.Chocolate;
            this.Exitbtn.Location = new System.Drawing.Point(20, 10);
            this.Exitbtn.Name = "Exitbtn";
            this.Exitbtn.Size = new System.Drawing.Size(75, 23);
            this.Exitbtn.TabIndex = 2;
            this.Exitbtn.Text = "EXIT";
            this.Exitbtn.UseVisualStyleBackColor = true;
            this.Exitbtn.Click += new System.EventHandler(this.Exitbtn_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(483, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(133, 25);
            this.label8.TabIndex = 23;
            this.label8.Text = "Admin Panal";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(239, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Welcome To Dashboard:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "ID";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(64, 162);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(134, 20);
            this.Password.TabIndex = 6;
            this.Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Address
            // 
            this.Address.Location = new System.Drawing.Point(63, 134);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(134, 20);
            this.Address.TabIndex = 5;
            this.Address.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Email
            // 
            this.Email.Location = new System.Drawing.Point(63, 59);
            this.Email.Name = "Email";
            this.Email.Size = new System.Drawing.Size(134, 20);
            this.Email.TabIndex = 3;
            this.Email.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Name
            // 
            this.Name.Location = new System.Drawing.Point(63, 33);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(134, 20);
            this.Name.TabIndex = 2;
            this.Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(63, 7);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(134, 20);
            this.id.TabIndex = 1;
            this.id.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Dob";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Password";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.Coral;
            this.lblMessage.Location = new System.Drawing.Point(317, 94);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(167, 20);
            this.lblMessage.TabIndex = 18;
            this.lblMessage.Text = "Plese Insert The Data ";
            this.lblMessage.Click += new System.EventHandler(this.lblMessage_Click);
            // 
            // DataGrid
            // 
            this.DataGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.GridColor = System.Drawing.SystemColors.Control;
            this.DataGrid.Location = new System.Drawing.Point(76, 418);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.RowHeadersWidth = 200;
            this.DataGrid.Size = new System.Drawing.Size(669, 107);
            this.DataGrid.TabIndex = 19;
            this.DataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellContentClick_1);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.Dob);
            this.panel2.Controls.Add(this.City1);
            this.panel2.Controls.Add(this.City);
            this.panel2.Controls.Add(this.Female);
            this.panel2.Controls.Add(this.Male);
            this.panel2.Controls.Add(this.Gend);
            this.panel2.Controls.Add(this.ClearBtn);
            this.panel2.Controls.Add(this.UpdateEmployee);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.id);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.Name);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.Email);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.Password);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.Address);
            this.panel2.Location = new System.Drawing.Point(304, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(268, 266);
            this.panel2.TabIndex = 20;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Dob
            // 
            this.Dob.CustomFormat = "dd-mm-yyyy";
            this.Dob.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.Dob.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Dob.Location = new System.Drawing.Point(64, 85);
            this.Dob.MaxDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.Dob.MinDate = new System.DateTime(1998, 1, 1, 0, 0, 0, 0);
            this.Dob.Name = "Dob";
            this.Dob.Size = new System.Drawing.Size(134, 20);
            this.Dob.TabIndex = 29;
            this.Dob.Value = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            // 
            // City1
            // 
            this.City1.AutoSize = true;
            this.City1.Location = new System.Drawing.Point(15, 199);
            this.City1.Name = "City1";
            this.City1.Size = new System.Drawing.Size(24, 13);
            this.City1.TabIndex = 28;
            this.City1.Text = "City";
            // 
            // City
            // 
            this.City.FormattingEnabled = true;
            this.City.Location = new System.Drawing.Point(64, 193);
            this.City.Name = "City";
            this.City.Size = new System.Drawing.Size(133, 21);
            this.City.TabIndex = 26;
            this.City.SelectedIndexChanged += new System.EventHandler(this.City_SelectedIndexChanged);
            // 
            // Female
            // 
            this.Female.AutoSize = true;
            this.Female.Location = new System.Drawing.Point(114, 111);
            this.Female.Name = "Female";
            this.Female.Size = new System.Drawing.Size(59, 17);
            this.Female.TabIndex = 27;
            this.Female.TabStop = true;
            this.Female.Text = "Female";
            this.Female.UseVisualStyleBackColor = true;
            this.Female.CheckedChanged += new System.EventHandler(this.Female_CheckedChanged);
            // 
            // Male
            // 
            this.Male.AutoSize = true;
            this.Male.Location = new System.Drawing.Point(64, 111);
            this.Male.Name = "Male";
            this.Male.Size = new System.Drawing.Size(48, 17);
            this.Male.TabIndex = 26;
            this.Male.TabStop = true;
            this.Male.Text = "Male";
            this.Male.UseVisualStyleBackColor = true;
            this.Male.CheckedChanged += new System.EventHandler(this.Male_CheckedChanged);
            // 
            // Gend
            // 
            this.Gend.AutoSize = true;
            this.Gend.Location = new System.Drawing.Point(16, 113);
            this.Gend.Name = "Gend";
            this.Gend.Size = new System.Drawing.Size(42, 13);
            this.Gend.TabIndex = 23;
            this.Gend.Text = "Gender";
            // 
            // ClearBtn
            // 
            this.ClearBtn.Location = new System.Drawing.Point(184, 226);
            this.ClearBtn.Name = "ClearBtn";
            this.ClearBtn.Size = new System.Drawing.Size(75, 23);
            this.ClearBtn.TabIndex = 22;
            this.ClearBtn.Text = "Clear";
            this.ClearBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ClearBtn.UseVisualStyleBackColor = true;
            this.ClearBtn.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // UpdateEmployee
            // 
            this.UpdateEmployee.Location = new System.Drawing.Point(7, 226);
            this.UpdateEmployee.Name = "UpdateEmployee";
            this.UpdateEmployee.Size = new System.Drawing.Size(75, 23);
            this.UpdateEmployee.TabIndex = 1;
            this.UpdateEmployee.Text = "UpdateEmployee";
            this.UpdateEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.UpdateEmployee.UseVisualStyleBackColor = true;
            this.UpdateEmployee.Click += new System.EventHandler(this.UpdateEmployee_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(63, 13);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 21;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Addbtn
            // 
            this.Addbtn.Location = new System.Drawing.Point(129, 9);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(75, 23);
            this.Addbtn.TabIndex = 0;
            this.Addbtn.Text = "AddEmployee";
            this.Addbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Addbtn.UseVisualStyleBackColor = true;
            this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
            // 
            // DeleteEmployee
            // 
            this.DeleteEmployee.Location = new System.Drawing.Point(243, 10);
            this.DeleteEmployee.Name = "DeleteEmployee";
            this.DeleteEmployee.Size = new System.Drawing.Size(75, 23);
            this.DeleteEmployee.TabIndex = 20;
            this.DeleteEmployee.Text = "DeleteEmployee";
            this.DeleteEmployee.UseVisualStyleBackColor = true;
            this.DeleteEmployee.Click += new System.EventHandler(this.DeleteEmployee_Click_1);
            // 
            // SearchAllEmployees
            // 
            this.SearchAllEmployees.Location = new System.Drawing.Point(396, 10);
            this.SearchAllEmployees.Name = "SearchAllEmployees";
            this.SearchAllEmployees.Size = new System.Drawing.Size(75, 23);
            this.SearchAllEmployees.TabIndex = 21;
            this.SearchAllEmployees.Text = "SearchAllEmployees";
            this.SearchAllEmployees.UseVisualStyleBackColor = true;
            this.SearchAllEmployees.Click += new System.EventHandler(this.SearchAllEmployees_Click);
            // 
            // ImportToExcel
            // 
            this.ImportToExcel.Location = new System.Drawing.Point(539, 10);
            this.ImportToExcel.Name = "ImportToExcel";
            this.ImportToExcel.Size = new System.Drawing.Size(75, 23);
            this.ImportToExcel.TabIndex = 20;
            this.ImportToExcel.Text = "Download";
            this.ImportToExcel.UseVisualStyleBackColor = true;
            this.ImportToExcel.Click += new System.EventHandler(this.ImportToExcel_Click);
            // 
            // PrintDataButton
            // 
            this.PrintDataButton.Location = new System.Drawing.Point(668, 10);
            this.PrintDataButton.Name = "PrintDataButton";
            this.PrintDataButton.Size = new System.Drawing.Size(75, 23);
            this.PrintDataButton.TabIndex = 22;
            this.PrintDataButton.Text = "PrintDataButton";
            this.PrintDataButton.UseVisualStyleBackColor = true;
            this.PrintDataButton.Click += new System.EventHandler(this.PrintDataButton_Click_1);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 35);
            this.panel1.TabIndex = 24;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.Addbtn);
            this.panel3.Controls.Add(this.PrintDataButton);
            this.panel3.Controls.Add(this.ImportToExcel);
            this.panel3.Controls.Add(this.SearchAllEmployees);
            this.panel3.Controls.Add(this.DeleteEmployee);
            this.panel3.Controls.Add(this.Exitbtn);
            this.panel3.Location = new System.Drawing.Point(0, 35);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(784, 44);
            this.panel3.TabIndex = 25;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 553);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.lblMessage);
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Load += new System.EventHandler(this.Form2_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Gender_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Button Exitbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.TextBox Email;
        private new System.Windows.Forms.TextBox Name;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.Button UpdateEmployee;
        private System.Windows.Forms.Button DeleteEmployee;
        private System.Windows.Forms.Button SearchAllEmployees;
        private System.Windows.Forms.Button ImportToExcel;
        private System.Windows.Forms.Button PrintDataButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button ClearBtn;
        private System.Windows.Forms.Label Gend;
        private System.Windows.Forms.RadioButton Male;
        private System.Windows.Forms.RadioButton Female;
        private System.Windows.Forms.Label City1;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.ComboBox City;
        private System.Windows.Forms.DateTimePicker Dob;
    }
}