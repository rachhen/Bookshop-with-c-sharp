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
    public partial class FormSale : Form
    {
        SqlConnection conn;
        DataTable dtSaleItems;

        public FormSale()
        {
            InitializeComponent();
        }

        private void FormSale_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=bookshop;User Id=sa;Password=123;";
            conn.Open();

            /*dtSaleItems = new DataTable();

            dgSaleItems.DataSource = dtSaleItems;*/

            string itemsSql = $"SELECT * FROM Item";
            var dtItems = new DataTable();
            var adapter = new SqlDataAdapter(itemsSql, conn);
            adapter.Fill(dtItems);

            var combobox =  (DataGridViewComboBoxColumn)dgSaleItems.Columns["ItemId"]; 
            combobox.DisplayMember = "ItemName";
            combobox.ValueMember = "ItemId";
            combobox.DataSource = dtItems;
            combobox.HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgSaleItems.Columns["Price"].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

            dgSaleItems.Columns["Quantity"].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);
            dgSaleItems.Columns["Amount"].HeaderCell.Style.Font = new Font("Roboto", 8, FontStyle.Bold);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void dgSaleItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgSaleItems.IsCurrentCellDirty)
            {
                dgSaleItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dgSaleItems.EndEdit();
            }
        }

        private void dgSaleItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dgSaleItems.CurrentCell.ColumnIndex == 0)
            {
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgSaleItems.Rows[e.RowIndex].Cells[0];
                Console.WriteLine(cb.Value);
            }
        }

    }
}
