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
    public partial class FormItem : Form
    {
        SqlConnection conn;
        DataTable dtItems;

        public FormItem()
        {
            InitializeComponent();
        }

        private void FormItem_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=bookshop;User Id=sa;Password=123;";
            conn.Open();

            LoadData();
        }

        private void LoadData(string q = "")
        {
            string sql = $"SELECT * FROM Item " +
                $"WHERE ItemName LIKE '%{q}%' " +
                $"OR Description LIKE '%{q}%' " +
                $"OR SalePrice LIKE '%{q}%' " +
                $"OR Quantity LIKE '%{q}%' ";

            dtItems = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(dtItems);

            dgItems.DataSource = dtItems;

            dgItems.Columns[0].HeaderText = "ID";
            dgItems.Columns[0].Width = 50;
            dgItems.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgItems.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgItems.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgItems.Columns[0].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgItems.Columns[1].HeaderText = "Name";
            dgItems.Columns[1].Width = 100;
            dgItems.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgItems.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgItems.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgItems.Columns[1].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgItems.Columns[2].HeaderText = "Description";
            dgItems.Columns[2].Width = 100;
            dgItems.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgItems.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgItems.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgItems.Columns[2].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgItems.Columns[3].HeaderText = "Price";
            dgItems.Columns[3].Width = 100;
            dgItems.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgItems.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgItems.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgItems.Columns[3].DefaultCellStyle.Format = "c";
            dgItems.Columns[3].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgItems.Columns[4].HeaderText = "Quantity";
            dgItems.Columns[4].Width = 100;
            dgItems.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgItems.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgItems.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgItems.Columns[4].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FormItemNew form = new FormItemNew(conn);
            if(form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData(txtKeyword.Text);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgItems.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select a item to edit", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string itemId = dgItems.SelectedRows[0].Cells["ItemId"].Value.ToString();
            FormItemEdit form = new FormItemEdit(itemId, conn);

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string itemId = dgItems.SelectedRows[0].Cells["ItemId"].Value?.ToString();

            if (itemId == null)
            {
                MessageBox.Show("Please select a item to delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirmation = MessageBox.Show("Are you sure to delete this record?", "Confimation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation == DialogResult.No) return;

            try
            {
                string sql = $"DELETE FROM Item WHERE ItemId = {itemId}";

                SqlCommand command = new SqlCommand(sql, conn);
                command.ExecuteNonQuery();

                MessageBox.Show("Item deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
            catch(Exception ex)
            {
                MessageBox.Show($"An error occur: {ex.Message}", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
