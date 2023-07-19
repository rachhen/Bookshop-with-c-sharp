using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bookshop
{
    public partial class FormEmployeeEdit : Form
    {
        SqlConnection conn;
        string employeeId;

        public FormEmployeeEdit(string employeeId, SqlConnection conn)
        {
            this.employeeId = employeeId;
            this.conn = conn;

            InitializeComponent();
        }

        private void FormEmployeeEdit_Load(object sender, EventArgs e)
        {
            string sql = $"SELECT * FROM Employee WHERE EmployeeId = {employeeId}";

            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                txtName.Text = reader["EmployeeName"].ToString();
                dtpDOB.Value = DateTime.Parse(reader["DoB"].ToString());
                txtAddress.Text = reader["Addresss"].ToString();
                cbbMaritalStatus.SelectedIndex = cbbMaritalStatus.Items.IndexOf(reader["MaritalStatus"].ToString().Trim());
                cbbSex.SelectedIndex = cbbSex.Items.IndexOf(reader["Sex"].ToString().Trim());
                chbHaveSpouse.Checked = reader["HaveSpouse"].ToString().Contains("True");
                txtNumerOfChild.Text = reader["NumberOfChildren"].ToString();
                dtpHiredDate.Value = DateTime.Parse(reader["HiredDate"].ToString());
                cbbPosition.SelectedIndex = cbbPosition.Items.IndexOf(reader["Position"].ToString().Trim());
                cbbDepartment.SelectedIndex = cbbDepartment.Items.IndexOf(reader["Department"].ToString().Trim());
                txtSalary.Text = reader["Salary"].ToString();
                txtUsername.Text = reader["Username"].ToString();
                txtPassword.Text = reader["Password"].ToString();
                
            }

            reader.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!FormValidate()) return;
            try
            {
                string sql = $"UPDATE Employee SET " +
                    $"EmployeeName = '{txtName.Text}', " +
                    $"Sex = '{cbbSex.Text}', " +
                    $"DoB = '{dtpDOB.Value}', " +
                    $"Addresss = '{txtAddress.Text}', " +
                    $"MaritalStatus = '{cbbMaritalStatus.Text}', " +
                    $"HaveSpouse = '{chbHaveSpouse.Checked}', " +
                    $"NumberOfChildren = {txtNumerOfChild.Text}, " +
                    $"HiredDate = '{dtpHiredDate.Value}', " +
                    $"Position = '{cbbPosition.Text}', " +
                    $"Department = '{cbbDepartment.Text}', " +
                    $"Salary = {txtSalary.Text}, " +
                    $"Username = '{txtUsername.Text}', " +
                    $"Password = '{txtPassword.Text}' " +
                    $"WHERE EmployeeId = {employeeId}";

                var command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occur: {ex.Message}", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtNumerOfChild_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSalary_TextChanged(object sender, EventArgs e)
        {
            epSalary.Clear();
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

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            epUsername.Clear();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            epPassword.Clear();
        }
    }
}
