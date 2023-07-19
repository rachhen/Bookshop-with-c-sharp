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
    public partial class FormEmployeeNew : Form
    {
        SqlConnection conn;
        bool isSaved = false;

        public FormEmployeeNew(SqlConnection conn)
        {
            this.conn = conn;

            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!SavingData()) return;

            MessageBox.Show("Employee has been saved successfully");

            txtName.Clear();
            txtAddress.Clear();
            txtSalary.Clear();
            txtUsername.Clear();
            txtPassword.Clear();

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
                string sql = $"INSERT INTO Employee(EmployeeName, Sex, Addresss, DoB, MaritalStatus, HaveSpouse, NumberOfChildren, HiredDate, Position, Department, Salary, Username, Password) " +
                    $"VALUES ('{txtName.Text}', '{cbbSex.Text}', '{txtAddress.Text}', '{dtpDOB.Text}', '{cbbMaritalStatus.Text}', '{chbHaveSpouse.Checked}', {txtNumerOfChild.Text}, '{dtpHiredDate.Text}', '{cbbPosition.Text}', '{cbbDepartment.Text}'," +
                    $"'{txtSalary.Text}', '{txtUsername.Text}', '{txtPassword.Text}')";

                var command = new SqlCommand(sql, conn);
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
            if (cbbSex.Text.Trim() == "")
            {
                result = false;
                epSex.SetError(cbbSex, "Sex is required");
            }
            if (cbbPosition.Text.Trim() == "")
            {
                result = false;
                epPosition.SetError(cbbPosition, "Position is required");
            }
            if (cbbMaritalStatus.Text.Trim() == "")
            {
                result = false;
                epMaritalStatus.SetError(cbbMaritalStatus, "Marital Status is required");
            }
            if (cbbDepartment.Text.Trim() == "")
            {
                result = false;
                epDepartment.SetError(cbbDepartment, "Department is required");
            }
            if (txtNumerOfChild.Text.Trim() == "")
            {
                result = false;
                epNumberOfChild.SetError(txtNumerOfChild, "Number of child is required");
            }
            if (txtSalary.Text.Trim() == "")
            {
                result = false;
                epSalary.SetError(txtSalary, "Salary is required");
            }
            if (txtUsername.Text.Trim() == "")
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

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            epName.Clear();
        }

        private void cbbSex_SelectedIndexChanged(object sender, EventArgs e)
        {
            epSex.Clear();
        }

        private void cbbPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            epPosition.Clear();
        }

        private void cbbMaritalStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            epMaritalStatus.Clear();
        }

        private void cbbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            epDepartment.Clear();
        }

        private void txtNumerOfChild_TextChanged(object sender, EventArgs e)
        {
            epNumberOfChild.Clear();
        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {
            epSalary.Clear();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            epUsername.Clear();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            epPassword.Clear();
        }

        private void txtNumerOfChild_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void FormEmployeeNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = isSaved ? DialogResult.OK : DialogResult.Cancel;
        }
    }
}
