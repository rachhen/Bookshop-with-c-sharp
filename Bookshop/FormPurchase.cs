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
    public partial class FormPurchase : Form
    {
        SqlConnection conn;
        DataTable dtPurchaseDetail;
        DataTable dtPurchase;
        BindingSource bsPurchase;
        DataTable dtItemList;

        string employeeId;

        public FormPurchase(string employeeId, SqlConnection conn)
        {
            this.employeeId = employeeId;
            this.conn = conn;

            InitializeComponent();
        }

        private void FormPurchase_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=.\\SQLEXPRESS;Initial Catalog=bookshop;User Id=sa;Password=123;";
            conn.Open();

            LoadVendorList();
            LoadPurchaseData();
        }

        private void LoadVendorList()
        {
            DataTable dtVendorList = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Vendor", conn);
            adapter.Fill(dtVendorList);
            cboVendor.DataSource = dtVendorList;
            cboVendor.DisplayMember = "VendorName";
            cboVendor.ValueMember = "VendorId";
        }

        private void LoadPurchaseData()
        {
            dtPurchase = new DataTable();
            bsPurchase = new BindingSource();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Purchase ORDER BY PurchaseId DESC", conn);
            adapter.Fill(dtPurchase);
            bsPurchase.DataSource = dtPurchase;

            txtSaleId.DataBindings.Clear();
            txtSaleId.DataBindings.Add(new Binding("Text", bsPurchase, "PurchaseId"));

            dtpTxnDate.DataBindings.Clear();
            dtpTxnDate.DataBindings.Add(new Binding("Text", bsPurchase, "TxnDate", true));

            txtRefNumber.DataBindings.Clear();
            txtRefNumber.DataBindings.Add(new Binding("Text", bsPurchase, "RefNumber"));

            cboVendor.DataBindings.Clear();
            cboVendor.DataBindings.Add(new Binding("SelectedValue", bsPurchase, "VendorId"));

            txtNote.DataBindings.Clear();
            txtNote.DataBindings.Add(new Binding("Text", bsPurchase, "Note"));

            LoadItemList();

            LoadPurchaseDetailData();
        }

        private void LoadPurchaseDetailData()
        {
            dtPurchaseDetail = new DataTable();

            if (bsPurchase.Count <= 0) return;

            DataRowView current = (DataRowView)bsPurchase.Current;
            string purchaseId = current["PurchaseId"].ToString();
            string sql = $"SELECT PurchaseDetailId,PurchaseId,ItemId,Description,Quantity,Price," +
                $"Quantity * Price As Amount FROM PurchaseDetail WHERE PurchaseId={purchaseId}";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(dtPurchaseDetail);

            dgPurchaseDetail.Columns[0].Visible = false;
            dgPurchaseDetail.Columns[0].DataPropertyName = "PurchaseDetailId";

            dgPurchaseDetail.Columns[1].Visible = false;
            dgPurchaseDetail.Columns[1].DataPropertyName = "PurchaseId";

            dgPurchaseDetail.Columns[2].Visible = true;
            dgPurchaseDetail.Columns[2].HeaderText = "Item";
            dgPurchaseDetail.Columns[2].Width = 200;
            dgPurchaseDetail.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgPurchaseDetail.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgPurchaseDetail.Columns[2].DataPropertyName = "ItemId";

            dgPurchaseDetail.Columns[3].Visible = true;
            dgPurchaseDetail.Columns[3].HeaderText = "Description";
            dgPurchaseDetail.Columns[3].Width = 300;
            dgPurchaseDetail.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgPurchaseDetail.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgPurchaseDetail.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgPurchaseDetail.Columns[3].DataPropertyName = "Description";

            dgPurchaseDetail.Columns[4].Visible = true;
            dgPurchaseDetail.Columns[4].HeaderText = "Quantity";
            dgPurchaseDetail.Columns[4].Width = 100;
            dgPurchaseDetail.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgPurchaseDetail.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgPurchaseDetail.Columns[4].DataPropertyName = "Quantity";

            dgPurchaseDetail.Columns[5].Visible = true;
            dgPurchaseDetail.Columns[5].HeaderText = "Price";
            dgPurchaseDetail.Columns[5].Width = 100;
            dgPurchaseDetail.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgPurchaseDetail.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgPurchaseDetail.Columns[5].DefaultCellStyle.Format = "$#,##0.00";
            dgPurchaseDetail.Columns[5].DataPropertyName = "Price";

            dgPurchaseDetail.Columns[6].Visible = true;
            dgPurchaseDetail.Columns[6].HeaderText = "Amount";
            dgPurchaseDetail.Columns[6].Width = 100;
            dgPurchaseDetail.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgPurchaseDetail.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgPurchaseDetail.Columns[6].DefaultCellStyle.Format = "$#,##0.00";
            dgPurchaseDetail.Columns[6].DataPropertyName = "Amount";

            dgPurchaseDetail.DataSource = dtPurchaseDetail;
        }

        private void LoadItemList()
        {
            dtItemList = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Item", conn);
            adapter.Fill(dtItemList);

            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)dgPurchaseDetail.Columns[2];
            column.DisplayMember = "ItemName";
            column.ValueMember = "ItemId";
            column.DataSource = dtItemList;
        }

        private void dgPurchaseItems_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
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
                double amount = price * 1;

                dgPurchaseDetail.CurrentRow.Cells[3].Value = dtItemList.Rows[cb.SelectedIndex][2].ToString();
                dgPurchaseDetail.CurrentRow.Cells[4].Value = 1;
                dgPurchaseDetail.CurrentRow.Cells[5].Value = price;
                dgPurchaseDetail.CurrentRow.Cells[6].Value = amount;
            }
        }

        private void dgPurchaseDetail_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgPurchaseDetail.IsCurrentCellDirty && (e.ColumnIndex == 4 || e.ColumnIndex == 5))
            {
                double quantity, price, amount;

                double.TryParse(dgPurchaseDetail.SelectedRows[0].Cells[4].Value.ToString(), out quantity);
                double.TryParse(dgPurchaseDetail.SelectedRows[0].Cells[5].Value.ToString(), out price);

                amount = quantity * price;

                dgPurchaseDetail.SelectedRows[0].Cells[6].Value = amount;
            }
        }

        private void TogglePaginButton()
        {
            btnFirst.Enabled = !btnFirst.Enabled;
            btnPrevious.Enabled = !btnPrevious.Enabled;
            btnNext.Enabled = !btnNext.Enabled;
            btnLast.Enabled = !btnLast.Enabled;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            bsPurchase.AddNew();
            dtPurchaseDetail.Rows.Clear();
            btnDelete.Enabled = false;
            btnCancel.Enabled = true;

            TogglePaginButton();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadPurchaseData();
            TogglePaginButton();

            btnDelete.Enabled = true;
            btnCancel.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataRowView datarow = (DataRowView)bsPurchase.Current;
            if (datarow.IsNew) return;

            DialogResult confirmation;
            confirmation = MessageBox.Show("Are you sure to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes) return;

            string purchaseId = datarow["PurchaseId"].ToString();
            string sql = $"DELETE FROM Purchase WHERE PurchaseId={purchaseId}";

            SqlCommand cmdSale = new SqlCommand(sql, conn);
            cmdSale.ExecuteNonQuery();

            MessageBox.Show("Sale has deleted successfully");

            LoadPurchaseData();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bsPurchase.CancelEdit();
            bsPurchase.MoveLast();
            LoadPurchaseDetailData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bsPurchase.CancelEdit();
            bsPurchase.MoveNext();
            LoadPurchaseDetailData();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            bsPurchase.CancelEdit();
            bsPurchase.MovePrevious();
            LoadPurchaseDetailData();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bsPurchase.CancelEdit();
            bsPurchase.MoveFirst();
            LoadPurchaseDetailData();
        }

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            var form = new FormVendorNew(conn);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadVendorList();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dgPurchaseDetail.EndEdit();
            if (!DoValidation()) return;

            DataRowView datarow = (DataRowView)bsPurchase.Current;
            if (datarow.IsNew)
            {
                SaveNewData();
            }
            else
            {
                UpdateData(datarow);
            }

            LoadPurchaseData();
        }

        private bool DoValidation()
        {
            bool result = true;
            if (cboVendor.SelectedIndex < 0)
            {
                epVendor.SetError(cboVendor, "Required");
                result = false;
            }
            if (txtRefNumber.Text == "")
            {
                epRefNumber.SetError(txtRefNumber, "Required");
                result = false;
            }
            if (dgPurchaseDetail.Rows.Count <= 0)
            {
                epPurchaseDetail.SetError(dgPurchaseDetail, "Required");
                result = false;
            }

            return result;
        }

        private void SaveNewData()
        {
            try
            {
                string sql = "INSERT INTO Purchase(TxnDate, RefNumber, VendorId, EmployeeId, Note) " +
                        "Output Inserted.PurchaseId " +
                        $"VALUES('{dtpTxnDate.Value:yyyy-MM-dd}','{txtRefNumber.Text}'," +
                        $"{cboVendor.SelectedValue},{employeeId}," +
                        $"'{txtNote.Text}')";

                SqlCommand cmdSale = new SqlCommand(sql, conn);
                string saleid = cmdSale.ExecuteScalar().ToString();

                foreach (DataRow row in dtPurchaseDetail.Rows)
                {
                    sql = "INSERT INTO PurchaseDetail(PurchaseId,ItemId,Description,Quantity,Price) " +
                        $"VALUES({saleid},{row["ItemId"]}," +
                        $"'{row["Description"]}',{row["Quantity"]}," +
                        $"{row["Price"]})";

                    SqlCommand cmdSaleDetail = new SqlCommand(sql, conn);
                    cmdSaleDetail.ExecuteNonQuery();
                }

                MessageBox.Show("Purchase has added successfully");

                TogglePaginButton();
                btnCancel.Enabled = false;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occur: {ex.Message}", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateData(DataRowView datarow)
        {
            try
            {
                string purchaseId = datarow["PurchaseId"].ToString();
                string sql = $"UPDATE Purchase SET " +
                    $"TxnDate='{dtpTxnDate.Value:yyyy-MM-dd}'," +
                    $"RefNumber='{txtRefNumber.Text}'," +
                    $"VendorId={cboVendor.SelectedValue}," +
                    $"EmployeeId={employeeId}," +
                    $"Note='{txtNote.Text}' " +
                    $"WHERE PurchaseId={purchaseId} ";

                SqlCommand cmdSale = new SqlCommand(sql, conn);
                cmdSale.ExecuteNonQuery();

                foreach (DataRow row in dtPurchaseDetail.Rows)
                {
                    string purchaseDetailId = row["PurchaseDetailId"].ToString();
                    if (purchaseDetailId == "")
                    {
                        sql = "INSERT INTO  PurchaseDetail(PurchaseId, ItemId, Description, Quantity, Price) " +
                            $"VALUES({purchaseId}, {row["ItemId"]}," +
                            $"'{row["Description"]}', '{row["Quantity"]}'," +
                            $"'{row["Price"]}')";
                    }
                    else
                    {
                        sql = $"UPDATE PurchaseDetail SET " +
                            $"PurchaseId={purchaseId}," +
                            $"ItemId={row["ItemId"]}," +
                            $"Description='{row["Description"]}'," +
                            $"Quantity={row["Quantity"]}," +
                            $"Price={row["Price"]} " +
                            $"WHERE PurchaseDetailId={purchaseDetailId}";
                    }

                    SqlCommand cmdSaleDetail = new SqlCommand(sql, conn);
                    cmdSaleDetail.ExecuteNonQuery();
                }
                MessageBox.Show("Purchase has updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occur: {ex.Message}", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
