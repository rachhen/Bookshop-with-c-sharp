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
    public partial class FormCustomer : Form
    {
        SqlConnection conn;
        DataTable dtCustomers;

        public FormCustomer()
        {
            InitializeComponent();
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=bookshop;User Id=sa;Password=123;";
            conn.Open();

            LoadData();
        }

        private void LoadData(string q = "")
        {
            string sql = $"SELECT * FROM Customer WHERE CustomerName LIKE '%{q}%'";

            dtCustomers = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(dtCustomers);

            dgCustomers.DataSource = dtCustomers;

            dgCustomers.Columns[0].HeaderText = "ID";
            dgCustomers.Columns[0].Width = 50;
            dgCustomers.Columns[0].ReadOnly = true;
            dgCustomers.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgCustomers.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgCustomers.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgCustomers.Columns[0].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgCustomers.Columns[1].HeaderText = "Name";
            dgCustomers.Columns[1].Width = 120;
            dgCustomers.Columns[1].ReadOnly = true;
            dgCustomers.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgCustomers.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgCustomers.Columns[1].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgCustomers.Columns[2].HeaderText = "Company";
            dgCustomers.Columns[2].Width = 100;
            dgCustomers.Columns[2].ReadOnly = true;
            dgCustomers.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgCustomers.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgCustomers.Columns[2].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgCustomers.Columns[3].HeaderText = "Phone";
            dgCustomers.Columns[3].Width = 100;
            dgCustomers.Columns[3].ReadOnly = true;
            dgCustomers.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgCustomers.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgCustomers.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgCustomers.Columns[3].DefaultCellStyle.Format = "c";
            dgCustomers.Columns[3].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgCustomers.Columns[4].HeaderText = "Email";
            dgCustomers.Columns[4].Width = 150;
            dgCustomers.Columns[4].ReadOnly = true;
            dgCustomers.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgCustomers.Columns[4].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);


            dgCustomers.Columns[5].HeaderText = "Address";
            dgCustomers.Columns[5].Width = 100;
            dgCustomers.Columns[5].ReadOnly = true;
            dgCustomers.Columns[5].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);
            dgCustomers.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtKeyword.Text); 
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string customerId = dgCustomers.SelectedRows[0].Cells["CustomerId"].Value?.ToString();

            if (customerId == null)
            {
                MessageBox.Show("Please select a customer to delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmation = MessageBox.Show("Are you sure to delete this record?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.No) return;

            try
            {
                string sql = $"DELETE FROM Customer WHERE CustomerId = {customerId}";

                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();

                MessageBox.Show("Customer deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occur: {ex.Message}", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var form = new FormCustomerNew(conn);
            if(form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgCustomers.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a customer to edit", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string customerId = dgCustomers.SelectedRows[0].Cells["CustomerId"].Value.ToString();
            var form = new FormCustomerEdit(customerId, conn);

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
