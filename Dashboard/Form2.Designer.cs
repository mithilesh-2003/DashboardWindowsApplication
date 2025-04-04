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
            this.pa = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Addbtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PrintDataButton = new System.Windows.Forms.Button();
            this.ImportToExcel = new System.Windows.Forms.Button();
            this.SearchAllEmployees = new System.Windows.Forms.Button();
            this.DeleteEmployee = new System.Windows.Forms.Button();
            this.UpdateEmployee = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.Address = new System.Windows.Forms.TextBox();
            this.Dob = new System.Windows.Forms.TextBox();
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.pa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Exitbtn
            // 
            this.Exitbtn.ForeColor = System.Drawing.Color.Chocolate;
            this.Exitbtn.Location = new System.Drawing.Point(694, 520);
            this.Exitbtn.Name = "Exitbtn";
            this.Exitbtn.Size = new System.Drawing.Size(75, 23);
            this.Exitbtn.TabIndex = 2;
            this.Exitbtn.Text = "EXIT";
            this.Exitbtn.UseVisualStyleBackColor = true;
            this.Exitbtn.Click += new System.EventHandler(this.Exitbtn_Click);
            // 
            // pa
            // 
            this.pa.Controls.Add(this.pictureBox1);
            this.pa.Controls.Add(this.label1);
            this.pa.Dock = System.Windows.Forms.DockStyle.Top;
            this.pa.Location = new System.Drawing.Point(0, 0);
            this.pa.Name = "pa";
            this.pa.Size = new System.Drawing.Size(784, 36);
            this.pa.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 5);
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
            this.label1.Location = new System.Drawing.Point(375, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Welcome:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Addbtn
            // 
            this.Addbtn.Location = new System.Drawing.Point(19, 11);
            this.Addbtn.Name = "Addbtn";
            this.Addbtn.Size = new System.Drawing.Size(75, 23);
            this.Addbtn.TabIndex = 0;
            this.Addbtn.Text = "AddEmployee";
            this.Addbtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.Addbtn.UseVisualStyleBackColor = true;
            this.Addbtn.Click += new System.EventHandler(this.Addbtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PrintDataButton);
            this.panel1.Controls.Add(this.ImportToExcel);
            this.panel1.Controls.Add(this.SearchAllEmployees);
            this.panel1.Controls.Add(this.DeleteEmployee);
            this.panel1.Controls.Add(this.UpdateEmployee);
            this.panel1.Controls.Add(this.Addbtn);
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 46);
            this.panel1.TabIndex = 4;
            // 
            // PrintDataButton
            // 
            this.PrintDataButton.Location = new System.Drawing.Point(640, 11);
            this.PrintDataButton.Name = "PrintDataButton";
            this.PrintDataButton.Size = new System.Drawing.Size(75, 23);
            this.PrintDataButton.TabIndex = 22;
            this.PrintDataButton.Text = "PrintDataButton";
            this.PrintDataButton.UseVisualStyleBackColor = true;
            this.PrintDataButton.Click += new System.EventHandler(this.PrintDataButton_Click_1);
            // 
            // ImportToExcel
            // 
            this.ImportToExcel.Location = new System.Drawing.Point(499, 11);
            this.ImportToExcel.Name = "ImportToExcel";
            this.ImportToExcel.Size = new System.Drawing.Size(75, 23);
            this.ImportToExcel.TabIndex = 20;
            this.ImportToExcel.Text = "Download";
            this.ImportToExcel.UseVisualStyleBackColor = true;
            this.ImportToExcel.Click += new System.EventHandler(this.ImportToExcel_Click);
            // 
            // SearchAllEmployees
            // 
            this.SearchAllEmployees.Location = new System.Drawing.Point(393, 11);
            this.SearchAllEmployees.Name = "SearchAllEmployees";
            this.SearchAllEmployees.Size = new System.Drawing.Size(75, 23);
            this.SearchAllEmployees.TabIndex = 21;
            this.SearchAllEmployees.Text = "SearchAllEmployees";
            this.SearchAllEmployees.UseVisualStyleBackColor = true;
            this.SearchAllEmployees.Click += new System.EventHandler(this.SearchAllEmployees_Click_1);
            // 
            // DeleteEmployee
            // 
            this.DeleteEmployee.Location = new System.Drawing.Point(238, 11);
            this.DeleteEmployee.Name = "DeleteEmployee";
            this.DeleteEmployee.Size = new System.Drawing.Size(75, 23);
            this.DeleteEmployee.TabIndex = 20;
            this.DeleteEmployee.Text = "DeleteEmployee";
            this.DeleteEmployee.UseVisualStyleBackColor = true;
            this.DeleteEmployee.Click += new System.EventHandler(this.DeleteEmployee_Click_1);
            // 
            // UpdateEmployee
            // 
            this.UpdateEmployee.Location = new System.Drawing.Point(127, 11);
            this.UpdateEmployee.Name = "UpdateEmployee";
            this.UpdateEmployee.Size = new System.Drawing.Size(75, 23);
            this.UpdateEmployee.TabIndex = 1;
            this.UpdateEmployee.Text = "UpdateEmployee";
            this.UpdateEmployee.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.UpdateEmployee.UseVisualStyleBackColor = true;
            this.UpdateEmployee.Click += new System.EventHandler(this.UpdateEmployee_Click_1);
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
            this.Password.Location = new System.Drawing.Point(63, 137);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(134, 20);
            this.Password.TabIndex = 6;
            this.Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Address
            // 
            this.Address.Location = new System.Drawing.Point(63, 111);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(134, 20);
            this.Address.TabIndex = 5;
            this.Address.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Dob
            // 
            this.Dob.Location = new System.Drawing.Point(63, 85);
            this.Dob.Name = "Dob";
            this.Dob.Size = new System.Drawing.Size(134, 20);
            this.Dob.TabIndex = 4;
            this.Dob.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.label6.Location = new System.Drawing.Point(12, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Address";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 144);
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
            this.lblMessage.Location = new System.Drawing.Point(40, 223);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(167, 20);
            this.lblMessage.TabIndex = 18;
            this.lblMessage.Text = "Plese Insert The Data ";
            this.lblMessage.Click += new System.EventHandler(this.lblMessage_Click);
            // 
            // DataGrid
            // 
            this.DataGrid.BackgroundColor = System.Drawing.Color.SeaShell;
            this.DataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.GridColor = System.Drawing.SystemColors.Control;
            this.DataGrid.Location = new System.Drawing.Point(72, 103);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.RowHeadersWidth = 200;
            this.DataGrid.Size = new System.Drawing.Size(643, 107);
            this.DataGrid.TabIndex = 19;
            this.DataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGrid_CellContentClick);
            // 
            // panel2
            // 
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
            this.panel2.Controls.Add(this.Dob);
            this.panel2.Controls.Add(this.Address);
            this.panel2.Location = new System.Drawing.Point(19, 246);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 165);
            this.panel2.TabIndex = 20;
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
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 553);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pa);
            this.Controls.Add(this.Exitbtn);
            this.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Load += new System.EventHandler(this.Form2_Load_1);
            this.pa.ResumeLayout(false);
            this.pa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Panel pa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Addbtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.TextBox Address;
        private System.Windows.Forms.TextBox Dob;
        private System.Windows.Forms.TextBox Email;
        private new System.Windows.Forms.TextBox Name;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button UpdateEmployee;
        private System.Windows.Forms.Button DeleteEmployee;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Button SearchAllEmployees;
        private System.Windows.Forms.Button ImportToExcel;
        private System.Windows.Forms.Button PrintDataButton;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}