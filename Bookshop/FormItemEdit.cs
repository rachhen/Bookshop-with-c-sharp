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
    public partial class FormItemEdit : Form
    {
        string itemId;
        SqlConnection conn;

        public FormItemEdit(string itemId, SqlConnection conn)
        {
            this.itemId = itemId;
            this.conn = conn;

            InitializeComponent();
        }

        private void FormItemEdit_Load(object sender, EventArgs e)
        {
            string sql = $"SELECT * FROM Item WHERE ItemId = {itemId}";

            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                txtItemName.Text = reader["ItemName"].ToString();
                txtSalePrice.Text = reader["SalePrice"].ToString();
                txtQuantity.Text = reader["Quantity"].ToString();
                txtDescription.Text = reader["Description"].ToString();
            }

            reader.Close();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!FormValidation()) return;

            try
            {
                string sql = $"UPDATE Item SET " +
                    $"ItemName = '{txtItemName.Text}', " +
                    $"SalePrice = {txtSalePrice.Text}, " +
                    $"Quantity = {txtQuantity.Text}, " +
                    $"Description = '{txtDescription.Text}' " +
                    $"WHERE ItemId = {itemId}";

                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();

                MessageBox.Show("Item updated successfully");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occur: {ex.Message}", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool FormValidation()
        {
            bool result = true;
            if (txtItemName.Text.Trim() == "")
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
            if (txtDescription.Text.Length > 250)
            {
                result = false;
                epDescription.SetError(txtDescription, "Description is too long. Max length 250");
            }

            return result;
        }
    }
}
