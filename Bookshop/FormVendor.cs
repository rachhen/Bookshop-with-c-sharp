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
    public partial class FormVendor : Form
    {
        SqlConnection conn;
        DataTable dtVendors;

        public FormVendor(SqlConnection conn)
        {
            this.conn = conn;

            InitializeComponent();
        }

        private void FormVendor_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData(string q = "")
        {
            string sql = $"SELECT * FROM Vendor WHERE VendorName LIKE '%{q}%'";

            dtVendors = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(dtVendors);

            dgVendors.DataSource = dtVendors;

            dgVendors.Columns[0].HeaderText = "ID";
            dgVendors.Columns[0].Width = 50;
            dgVendors.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgVendors.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgVendors.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgVendors.Columns[0].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgVendors.Columns[1].HeaderText = "Name";
            dgVendors.Columns[1].Width = 120;
            dgVendors.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgVendors.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgVendors.Columns[1].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgVendors.Columns[2].HeaderText = "Company";
            dgVendors.Columns[2].Width = 100;
            dgVendors.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgVendors.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgVendors.Columns[2].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgVendors.Columns[3].HeaderText = "Phone";
            dgVendors.Columns[3].Width = 100;
            dgVendors.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgVendors.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgVendors.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgVendors.Columns[3].DefaultCellStyle.Format = "c";
            dgVendors.Columns[3].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgVendors.Columns[4].HeaderText = "Email";
            dgVendors.Columns[4].Width = 150;
            dgVendors.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgVendors.Columns[4].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);


            dgVendors.Columns[5].HeaderText = "Address";
            dgVendors.Columns[5].Width = 100;

            dgVendors.Columns[5].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);
            dgVendors.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtKeyword.Text);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string vendorId = dgVendors.SelectedRows[0].Cells["VendorId"].Value?.ToString();

            if (vendorId == null)
            {
                MessageBox.Show("Please select a vendor to delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmation = MessageBox.Show("Are you sure to delete this record?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.No) return;

            try
            {
                string sql = $"DELETE FROM Vendor WHERE VendorId = {vendorId}";

                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();

                MessageBox.Show("Vendor deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occur: {ex.Message}", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var form = new FormVendorNew(conn);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgVendors.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a vendor to edit", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string customerId = dgVendors.SelectedRows[0].Cells["VendorId"].Value.ToString();
            var form = new FormVendorEdit(customerId, conn);

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
