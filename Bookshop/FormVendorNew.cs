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
    public partial class FormVendorNew : Form
    {
        SqlConnection conn;
        bool isSaved = false;

        public FormVendorNew(SqlConnection conn)
        {
            this.conn = conn;
            InitializeComponent();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            epName.Clear();
        }

        private void txtCompany_TextChanged(object sender, EventArgs e)
        {
            epCompany.Clear();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            epPhone.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = isSaved ? DialogResult.OK : DialogResult.Cancel;
            Close();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (!SavingData()) return;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!SavingData()) return;

            MessageBox.Show("Vendor has been saved successfully");

            txtName.Clear();
            txtCompany.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();

            isSaved = true;
        }

        private bool SavingData()
        {
            if (!FormValidate()) return false;

            try
            {
                string sql = $"INSERT INTO Vendor(VendorName, CompanyName, Phone, Email, Address) " +
                    $"VALUES('{txtName.Text}', '{txtCompany.Text}', '{txtPhone.Text}', '{txtEmail.Text}', '{txtAddress.Text}')";

                SqlCommand command = new SqlCommand(sql, conn);
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

            if (txtCompany.Text.Trim() == "")
            {
                result = false;
                epCompany.SetError(txtCompany, "Company is required");
            }

            return result;
        }

        private void FormVendorNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = isSaved ? DialogResult.OK : DialogResult.Cancel;
        }
    }
}
