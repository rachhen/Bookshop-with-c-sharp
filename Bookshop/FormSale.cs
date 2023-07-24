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
        DataTable dtItems;

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
            dtItems = new DataTable();
            var adapter = new SqlDataAdapter(itemsSql, conn);
            adapter.Fill(dtItems);

            var combobox =  (DataGridViewComboBoxColumn)dgSaleItems.Columns["ItemId"]; 
            combobox.DisplayMember = "ItemName";
            combobox.ValueMember = "ItemId";
            combobox.DataSource = dtItems;

            dgSaleItems.Columns["Price"].DefaultCellStyle.Format = "c";

            dgSaleItems.Columns["Amount"].DefaultCellStyle.Format = "c";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void dgSaleItems_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            /*if (dgSaleItems.IsCurrentCellDirty)
            {
                dgSaleItems.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dgSaleItems.EndEdit();
            }*/
        }

        private void dgSaleItems_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            /*if (dgSaleItems.CurrentCell.ColumnIndex == 0)
            {
                DataGridViewComboBoxCell cb = (DataGridViewComboBoxCell)dgSaleItems.Rows[e.RowIndex].Cells[0];
               
                Console.WriteLine(cb.Value);
            }*/
        }

        private void dgSaleItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox cb && cb != null)
            {
                cb.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                cb.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            }
        }

        void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;

            if (cb.SelectedIndex != -1)
            {
                double price = double.Parse(dtItems.Rows[cb.SelectedIndex][3].ToString());
                dgSaleItems.CurrentRow.Cells[1].Value = price;
                dgSaleItems.CurrentRow.Cells[2].Value = 1;
                dgSaleItems.CurrentRow.Cells[3].Value = price * 1;
            }
        }
    }
}
