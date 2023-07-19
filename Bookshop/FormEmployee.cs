using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Bookshop
{
    public partial class FormEmployee : Form
    {
        SqlConnection conn;
        DataTable dtItems;

        public FormEmployee(SqlConnection conn)
        {
            this.conn = conn;

            InitializeComponent();
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData(string q = "")
        {
            string sql = $"SELECT [EmployeeId], [EmployeeName], [Sex], [DoB], [Addresss], " +
                $"[MaritalStatus], [HaveSpouse], [NumberOfChildren], [HiredDate], [Position], " +
                $"[Department], [Salary], [Username] " +
                $"FROM Employee WHERE EmployeeName LIKE '%{q}%'";

            dtItems = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(dtItems);

            dgEmployees.DataSource = dtItems;

            dgEmployees.Columns[0].HeaderText = "ID";
            dgEmployees.Columns[0].Width = 50;
            dgEmployees.Columns[0].ReadOnly = true;
            dgEmployees.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgEmployees.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[0].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgEmployees.Columns[1].HeaderText = "Name";
            dgEmployees.Columns[1].Width = 100;
            dgEmployees.Columns[1].ReadOnly = true;
            dgEmployees.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgEmployees.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgEmployees.Columns[1].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgEmployees.Columns[2].HeaderText = "Sex";
            dgEmployees.Columns[2].Width = 100;
            dgEmployees.Columns[2].ReadOnly = true;
            dgEmployees.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgEmployees.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgEmployees.Columns[2].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgEmployees.Columns[3].HeaderText = "DOB";
            dgEmployees.Columns[3].Width = 100;
            dgEmployees.Columns[3].ReadOnly = true;
            dgEmployees.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgEmployees.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[3].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgEmployees.Columns[4].HeaderText = "Address";
            dgEmployees.Columns[4].Width = 100;
            dgEmployees.Columns[4].ReadOnly = true;
            dgEmployees.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgEmployees.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[4].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgEmployees.Columns[5].HeaderText = "Marital Status";
            dgEmployees.Columns[5].Width = 100;
            dgEmployees.Columns[5].ReadOnly = true;
            dgEmployees.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgEmployees.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[5].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgEmployees.Columns[6].HeaderText = "Have Spouse";
            dgEmployees.Columns[6].Width = 100;
            dgEmployees.Columns[6].ReadOnly = true;
            dgEmployees.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgEmployees.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[6].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgEmployees.Columns[7].HeaderText = "Children";
            dgEmployees.Columns[7].Width = 70;
            dgEmployees.Columns[7].ReadOnly = true;
            dgEmployees.Columns[7].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgEmployees.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[7].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[7].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgEmployees.Columns[8].HeaderText = "Hired Date";
            dgEmployees.Columns[8].Width = 70;
            dgEmployees.Columns[8].ReadOnly = true;
            dgEmployees.Columns[8].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgEmployees.Columns[8].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[8].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[8].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgEmployees.Columns[9].HeaderText = "Position";
            dgEmployees.Columns[9].Width = 80;
            dgEmployees.Columns[9].ReadOnly = true;
            dgEmployees.Columns[9].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgEmployees.Columns[9].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[9].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[9].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgEmployees.Columns[10].HeaderText = "Dapartment";
            dgEmployees.Columns[10].Width = 90;
            dgEmployees.Columns[10].ReadOnly = true;
            dgEmployees.Columns[10].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgEmployees.Columns[10].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[10].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[10].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgEmployees.Columns[11].HeaderText = "Salary";
            dgEmployees.Columns[11].Width = 90;
            dgEmployees.Columns[11].ReadOnly = true;
            dgEmployees.Columns[11].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgEmployees.Columns[11].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[11].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[11].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgEmployees.Columns[12].HeaderText = "Username";
            dgEmployees.Columns[12].Width = 90;
            dgEmployees.Columns[12].ReadOnly = true;
            dgEmployees.Columns[12].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgEmployees.Columns[12].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[12].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgEmployees.Columns[12].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtKeyword.Text);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var form = new FormEmployeeNew(conn);

            if(form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            string employeeId = dgEmployees.SelectedRows[0].Cells["EmployeeId"].Value?.ToString();

            if (employeeId == null)
            {
                MessageBox.Show("Please select a employee to delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var form = new FormEmployeeEdit(employeeId, conn);

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string employeeId = dgEmployees.SelectedRows[0].Cells["EmployeeId"].Value?.ToString();

            if (employeeId == null)
            {
                MessageBox.Show("Please select a employee to delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmation = MessageBox.Show("Are you sure to delete this record?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.No) return;

            try
            {
                string sql = $"DELETE FROM Employee WHERE EmployeeId = {employeeId}";

                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();

                MessageBox.Show("Employee deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occur: {ex.Message}", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
