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

namespace Bookshop
{
    public partial class FormLogin : Form
    {
        SqlConnection conn;

        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=bookshop;User Id=sa;Password=123;";
            conn.Open();

            Console.WriteLine("Database state: " + conn.State);
            txtUsername.Text = "admin";
            txtPassword.Text = "123456";
        }

        private bool FormValidation()
        {
            bool result = true;

            if(txtUsername.Text.Trim() == "")
            {
                result = false;
                epUsername.SetError(txtUsername, "Username is required");
            }

            if (txtPassword.Text.Trim() == "")
            {
                result = false;
                epPassword.SetError(txtPassword, "Password is required");
            }

            return result;
        }

        private void cbTogglePassShow_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        private void FormLogin_Shown(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            lblFormError.Text = "";
            if (!FormValidation()) return;

            string sql = $"SELECT * FROM Employee WHERE Username = '{txtUsername.Text}' AND Password = '{txtPassword.Text}'";
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows && reader.Read())
            {
                string employeeId = reader["EmployeeId"].ToString();

                new FormMain( employeeId, conn).Show();
                Hide();
            }else
            {
                lblFormError.Text = "Invalid credentials";
            }

            reader.Close();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            epUsername.Clear();
            lblFormError.Text = "";
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            epPassword.Clear();
            lblFormError.Text = "";        }
    }
}
