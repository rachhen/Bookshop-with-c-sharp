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
    public partial class FormVendorEdit : Form
    {
        string vendorId;
        SqlConnection conn;

        public FormVendorEdit(string vendorId, SqlConnection conn)
        {
            this.vendorId = vendorId;
            this.conn = conn;

            InitializeComponent();
        }

        private void FormVendorEdit_Load(object sender, EventArgs e)
        {
            string sql = $"SELECT * FROM Vendor WHERE VendorId = {vendorId}";

            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                txtName.Text = reader["VendorName"].ToString();
                txtCompany.Text = reader["CompanyName"].ToString();
                txtPhone.Text = reader["Phone"].ToString();
                txtEmail.Text = reader["Email"].ToString();
                txtAddress.Text = reader["Address"].ToString();
            }

            reader.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!FormValidate()) return;

            try
            {
                string sql = $"UPDATE Vendor SET " +
                    $"VendorName = '{txtName.Text}', " +
                    $"CompanyName = '{txtCompany.Text}', " +
                    $"Phone = '{txtPhone.Text}', " +
                    $"Email = '{txtEmail.Text}', " +
                    $"Address = '{txtAddress.Text}' " +
                    $"WHERE VendorId = {vendorId}";

                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception err)
            {
                MessageBox.Show($"An error occur: {err.Message}", err.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
