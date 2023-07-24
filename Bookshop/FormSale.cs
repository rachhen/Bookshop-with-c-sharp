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
        DataTable dtSaleDetail;
        DataTable dtSale;
        BindingSource bsSale;
        DataTable dtItemList;

        string employeeId;

        public FormSale(string employeeId, SqlConnection conn)
        {
            this.employeeId = employeeId;
            this.conn = conn;

            InitializeComponent();
        }

        private void FormSale_Load(object sender, EventArgs e)
        {
            LoadCustomerList();
            LoadSaleData();
        }

        private void LoadCustomerList()
        {
            DataTable dtCustomerList = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Customer", conn);
            adapter.Fill(dtCustomerList);
            cboCustomer.DataSource = dtCustomerList;
            cboCustomer.DisplayMember = "CustomerName";
            cboCustomer.ValueMember = "CustomerId";
        }

        private void LoadSaleData()
        {
            dtSale = new DataTable();
            bsSale = new BindingSource();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Sale ORDER BY SaleId DESC", conn);
            adapter.Fill(dtSale);
            bsSale.DataSource = dtSale;

            txtSaleId.DataBindings.Clear();
            txtSaleId.DataBindings.Add(new Binding("Text", bsSale, "SaleId"));

            dtpTxnDate.DataBindings.Clear();
            dtpTxnDate.DataBindings.Add(new Binding("Text", bsSale, "TxnDate", true));

            txtRefNumber.DataBindings.Clear();
            txtRefNumber.DataBindings.Add(new Binding("Text", bsSale, "RefNumber"));

            cboCustomer.DataBindings.Clear();
            cboCustomer.DataBindings.Add(new Binding("SelectedValue", bsSale, "CustomerId"));

            txtNote.DataBindings.Clear();
            txtNote.DataBindings.Add(new Binding("Text", bsSale, "Note"));

            LoadItemList();

            LoadSaleDetailData();
        }

        private void LoadSaleDetailData()
        {
            dtSaleDetail = new DataTable();

            if (bsSale.Count <= 0) return;

            DataRowView current = (DataRowView)bsSale.Current;
            string saleid = current["SaleId"].ToString();
            string sql = $"SELECT SaleDetailId,SaleId,ItemId,Description,Quantity,Price," +
                $"Quantity * Price As Amount FROM SaleDetail WHERE SaleId={saleid}";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(dtSaleDetail);

            dgSaleDetail.Columns[0].Visible = false;
            dgSaleDetail.Columns[0].DataPropertyName = "SaleDetailId";

            dgSaleDetail.Columns[1].Visible = false;
            dgSaleDetail.Columns[1].DataPropertyName = "SaleId";

            dgSaleDetail.Columns[2].Visible = true;
            dgSaleDetail.Columns[2].HeaderText = "Item";
            dgSaleDetail.Columns[2].Width = 200;
            dgSaleDetail.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgSaleDetail.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgSaleDetail.Columns[2].DataPropertyName = "ItemId";

            dgSaleDetail.Columns[3].Visible = true;
            dgSaleDetail.Columns[3].HeaderText = "Description";
            dgSaleDetail.Columns[3].Width = 300;
            dgSaleDetail.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgSaleDetail.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgSaleDetail.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgSaleDetail.Columns[3].DataPropertyName = "Description";

            dgSaleDetail.Columns[4].Visible = true;
            dgSaleDetail.Columns[4].HeaderText = "Quantity";
            dgSaleDetail.Columns[4].Width = 100;
            dgSaleDetail.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgSaleDetail.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgSaleDetail.Columns[4].DataPropertyName = "Quantity";

            dgSaleDetail.Columns[5].Visible = true;
            dgSaleDetail.Columns[5].HeaderText = "Price";
            dgSaleDetail.Columns[5].Width = 100;
            dgSaleDetail.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgSaleDetail.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgSaleDetail.Columns[5].DefaultCellStyle.Format = "$#,##0.00";
            dgSaleDetail.Columns[5].DataPropertyName = "Price";

            dgSaleDetail.Columns[6].Visible = true;
            dgSaleDetail.Columns[6].HeaderText = "Amount";
            dgSaleDetail.Columns[6].Width = 100;
            dgSaleDetail.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgSaleDetail.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgSaleDetail.Columns[6].DefaultCellStyle.Format = "$#,##0.00";
            dgSaleDetail.Columns[6].DataPropertyName = "Amount";
            dgSaleDetail.DataSource = dtSaleDetail;
        }

        private void LoadItemList()
        {
            dtItemList = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Item", conn);
            adapter.Fill(dtItemList);

            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)dgSaleDetail.Columns[2];
            column.DisplayMember = "ItemName";
            column.ValueMember = "ItemId";
            column.DataSource = dtItemList;

        }

        private void TogglePaginButton()
        {
            btnFirst.Enabled = !btnFirst.Enabled;
            btnPrevious.Enabled = !btnPrevious.Enabled;
            btnNext.Enabled = !btnNext.Enabled;
            btnLast.Enabled = !btnLast.Enabled;
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
                double.TryParse(dtItemList.Rows[cb.SelectedIndex][3].ToString(), out double price);

                dgSaleDetail.CurrentRow.Cells[3].Value = dtItemList.Rows[cb.SelectedIndex][2].ToString();
                dgSaleDetail.CurrentRow.Cells[4].Value = price;
                dgSaleDetail.CurrentRow.Cells[5].Value = 1;
                dgSaleDetail.CurrentRow.Cells[6].Value = price * 1;
            }
        }

        private void dgSaleDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgSaleDetail.IsCurrentCellDirty && (e.ColumnIndex == 4 || e.ColumnIndex == 5))
            {
                double quantity, price, amount;

                double.TryParse(dgSaleDetail.SelectedRows[0].Cells[4].Value.ToString(), out quantity);
                double.TryParse(dgSaleDetail.SelectedRows[0].Cells[5].Value.ToString(), out price);

                amount = quantity * price;

                dgSaleDetail.SelectedRows[0].Cells[6].Value = amount;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            bsSale.AddNew();
            dtSaleDetail.Rows.Clear();
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;

            TogglePaginButton();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadSaleData();
            TogglePaginButton();

            btnDelete.Enabled = true;
            btnCancel.Enabled = false;
        }

        private bool DoValidation()
        {
            bool result = true;
            if (cboCustomer.SelectedIndex < 0)
            {
                epCustomer.SetError(cboCustomer, "Required");
                result = false;
            }
            if (txtRefNumber.Text == "")
            {
                epRefNumber.SetError(txtRefNumber, "Required");
                result = false;
            }
            if (dgSaleDetail.Rows.Count <= 0)
            {
                epSaleDetail.SetError(dgSaleDetail, "Required");
                result = false;
            }

            Console.WriteLine(result);
            Console.WriteLine(dgSaleDetail.Rows.Count);
            return result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dgSaleDetail.EndEdit();
            if (!DoValidation()) return;

            DataRowView datarow = (DataRowView)bsSale.Current;
            if (datarow.IsNew)
            {
                SaveNewData();
            }
            else
            {
                UpdateData(datarow);
            }

            LoadSaleData();
        }

        private void SaveNewData()
        {
            try
            {
                string sql = "INSERT INTO Sale(TxnDate, RefNumber, CustomerId, EmployeeId, Note) " +
                        "Output Inserted.SaleId " +
                        $"VALUES('{dtpTxnDate.Value:yyyy-MM-dd}','{txtRefNumber.Text}'," +
                        $"{cboCustomer.SelectedValue},{employeeId}," +
                        $"'{txtNote.Text}')";

                SqlCommand cmdSale = new SqlCommand(sql, conn);
                string saleid = cmdSale.ExecuteScalar().ToString();

                foreach (DataRow row in dtSaleDetail.Rows)
                {
                    sql = "INSERT INTO SaleDetail(SaleId,ItemId,Description,Quantity,Price) " +
                        $"VALUES({saleid},{row["ItemId"]}," +
                        $"'{row["Description"]}',{row["Quantity"]}," +
                        $"{row["Price"]})";

                    SqlCommand cmdSaleDetail = new SqlCommand(sql, conn);
                    cmdSaleDetail.ExecuteNonQuery();
                }

                MessageBox.Show("Sale has added successfully");

                TogglePaginButton();
                btnCancel.Enabled = false;
                btnDelete.Enabled = true;
            }catch(Exception ex)
            {
                MessageBox.Show($"An error occur: {ex.Message}", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateData(DataRowView datarow)
        {
            try
            {
                string saleid = datarow["SaleId"].ToString();
                string sql = $"UPDATE Sale SET " +
                    $"TxnDate='{dtpTxnDate.Value:yyyy-MM-dd}'," +
                    $"RefNumber='{txtRefNumber.Text}'," +
                    $"CustomerId={cboCustomer.SelectedValue}," +
                    $"EmployeeId={employeeId}," +
                    $"Note='{txtNote.Text}' " +
                    $"WHERE SaleId={saleid} ";

                SqlCommand cmdSale = new SqlCommand(sql, conn);
                cmdSale.ExecuteNonQuery();

                foreach (DataRow row in dtSaleDetail.Rows)
                {
                    string saledetailid = row["SaleDetailId"].ToString();
                    if (saledetailid == "")
                    {
                        sql = "INSERT INTO  SaleDetail(SaleId, ItemId, Description, Quantity, Price) " +
                            $"VALUES({saleid}, {row["ItemId"]}," +
                            $"'{row["Description"]}', '{row["Quantity"]}'," +
                            $"'{row["Price"]}')";
                    }
                    else
                    {
                        sql = $"UPDATE SaleDetail SET " +
                            $"SaleId={saleid}," +
                            $"ItemId={row["ItemId"]}," +
                            $"Description='{row["Description"]}'," +
                            $"Quantity={row["Quantity"]}," +
                            $"Price={row["Price"]} " +
                            $"WHERE SaleDetailId={saledetailid}";
                    }

                    SqlCommand cmdSaleDetail = new SqlCommand(sql, conn);
                    cmdSaleDetail.ExecuteNonQuery();
                }
                MessageBox.Show("Sale has updated successfully");
            }catch(Exception ex)
            {
                MessageBox.Show($"An error occur: {ex.Message}", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRowView datarow = (DataRowView)bsSale.Current;
            if (datarow.IsNew) return;

            DialogResult confirmation;
            confirmation = MessageBox.Show("Are you sure to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes) return;

            string saleid = datarow["SaleId"].ToString();
            string sql = $"DELETE FROM Sale WHERE SaleId={saleid}";

            SqlCommand cmdSale = new SqlCommand(sql, conn);
            cmdSale.ExecuteNonQuery();

            MessageBox.Show("Sale has deleted successfully");

            LoadSaleData();
        }

        private void txtRefNumber_TextChanged(object sender, EventArgs e)
        {
            epRefNumber.Clear();
        }

        private void cboCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            epCustomer.Clear();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bsSale.CancelEdit();
            bsSale.MoveLast();
            LoadSaleDetailData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bsSale.CancelEdit();
            bsSale.MoveNext();
            LoadSaleDetailData();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bsSale.CancelEdit();
            bsSale.MoveFirst();
            LoadSaleDetailData();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            bsSale.CancelEdit();
            bsSale.MovePrevious();
            LoadSaleDetailData();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var form = new FormCustomerNew(conn);
            if (form.ShowDialog() == DialogResult.OK)
            {
                Console.WriteLine("Hi");
                LoadCustomerList();
            }
        }
    }
}
