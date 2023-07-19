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
    public partial class FormItemNew : Form
    {
        SqlConnection conn;
        bool isSaved = false;

        public FormItemNew(SqlConnection conn)
        {
            this.conn = conn;

            InitializeComponent();
        }

        private void txtSalePrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private bool FormValidation()
        {
            bool result = true;
            if(txtItemName.Text.Trim() == "")
            {
                result = false;
                epItemName.SetError(txtItemName, "Name is required");
            }
            if (txtSalePrice.Text.Trim() == "")
            {
                result = false;
                epSalePrice.SetError(txtSalePrice, "Price is required");
            }
            if (txtQuantity.Text.Trim() == "")
            {
                result = false;
                epQuantity.SetError(txtQuantity, "Quantity is required");
            }
            if(txtDescription.Text.Length > 250)
            {
                result = false;
                epDescription.SetError(txtDescription, "Description is too long. Max length 250");
            }

            return result;
        }

        private bool SavingData()
        {
            if (!FormValidation()) return false;

            try
            {
                string sql = $"INSERT INTO Item(ItemName, SalePrice, Quantity, Description) " +
                    $"VALUES('{txtItemName.Text}', {txtSalePrice.Text}, {txtQuantity.Text}, '{txtDescription.Text}')";

                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();

                return true;
            } catch(Exception e)
            {
                MessageBox.Show($"An error occur: {e.Message}", e.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!SavingData()) return;

            MessageBox.Show("Item has been saved successfully");

            txtItemName.Clear();
            txtSalePrice.Clear();
            txtQuantity.Clear();
            txtDescription.Clear();

            isSaved = true;
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            if (!SavingData()) return;

            DialogResult =  DialogResult.OK;
            Close();
        }


        private void txtItemName_TextChanged(object sender, EventArgs e)
        {
            epItemName.Clear();
        }

        private void txtSalePrice_TextChanged(object sender, EventArgs e)
        {
            epSalePrice.Clear();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            epQuantity.Clear();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            epDescription.Clear();
        }

        private void FormItemNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = isSaved ? DialogResult.OK : DialogResult.Cancel;
        }
    }
}
