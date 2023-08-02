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
    public partial class FormCustomerNew : Form
    {
        SqlConnection conn;
        bool isSaved = false;

        public FormCustomerNew(SqlConnection conn)
        {
            this.conn = conn;

            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!SavingData()) return;

            MessageBox.Show("Customer has been saved successfully");

            txtName.Clear();
            txtCompany.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();

            isSaved = true;
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (!SavingData()) return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private bool SavingData()
        {
            if (!FormValidate()) return false;

            try
            {
                //string sql = $"INSERT INTO Customer(CustomerName, CompanyName, Phone, Email, Address) " +
                //    $"VALUES('{txtName.Text}', '{txtCompany.Text}', '{txtPhone.Text}', '{txtEmail.Text}', '{txtAddress.Text}')";

                SqlCommand command = new SqlCommand("CreateCustomer", conn);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@customerName", SqlDbType.NVarChar).Value = txtName.Text.Trim();
                command.Parameters.Add("@companyName", SqlDbType.NVarChar).Value = txtCompany.Text.Trim();
                command.Parameters.Add("@phone", SqlDbType.VarChar).Value = txtPhone.Text.Trim();
                command.Parameters.Add("@email", SqlDbType.VarChar).Value = txtEmail.Text.Trim();
                command.Parameters.Add("@address", SqlDbType.VarChar).Value = txtAddress.Text.Trim();

                command.ExecuteNonQuery();

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show($"An error occur: {e.Message}", e.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private bool FormValidate()
        {
            bool result = true;
            if(txtName.Text.Trim() == "")
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

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            epName.Clear();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            epPhone.Clear();
        }

        private void FormCustomerNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = isSaved ? DialogResult.OK : DialogResult.Cancel;
        }
    }
}
