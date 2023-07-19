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
    public partial class FormCustomerEdit : Form
    {
        string customerId;
        SqlConnection conn;
        bool isSaved = false;

        public FormCustomerEdit(string customerId, SqlConnection conn)
        {
            this.customerId = customerId;
            this.conn = conn;

            InitializeComponent();
        }

        private void FormCustomerEdit_Load(object sender, EventArgs e)
        {
            string sql = $"SELECT * FROM Customer WHERE CustomerId = {customerId}";

            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                txtName.Text = reader["CustomerName"].ToString();
                txtCompany.Text = reader["CompanyName"].ToString();
                txtPhone.Text = reader["Phone"].ToString();
                txtEmail.Text = reader["Email"].ToString();
                txtAddress.Text = reader["Address"].ToString();
            }

            reader.Close();
        }

        private bool FormValidate()
        {
            bool result = true;
            if (txtName.Text.Trim() == "")
            {
                result = false;
                epName.SetError(txtName, "Name is required");
            }

            if (txtPhone.Text.Trim() == "")
            {
                result = false;
                epPhone.SetError(txtPhone, "Phone is required");
            }

            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!FormValidate()) return;

            try
            {
                string sql = $"UPDATE Customer SET " +
                    $"CustomerName = '{txtName.Text}', " +
                    $"CompanyName = '{txtCompany.Text}', " +
                    $"Phone = '{txtPhone.Text}', " +
                    $"Email = '{txtEmail.Text}', " +
                    $"Address = '{txtAddress.Text}' " +
                    $"WHERE CustomerId = {customerId}";

                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();

                DialogResult = DialogResult.OK;

                MessageBox.Show("Customer updated successfully");

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occur: {ex.Message}", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }
    }
}
