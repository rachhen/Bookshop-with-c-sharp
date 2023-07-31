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
    public partial class FormAdjustment : Form
    {
        SqlConnection conn;
        DataTable dtAdjustmentDetail;
        DataTable dtAdjustment;
        BindingSource bsAdjustment;
        DataTable dtItemList;

        string employeeId;

        public FormAdjustment(string employeeId, SqlConnection conn)
        {
            this.employeeId = employeeId;
            this.conn = conn;

            InitializeComponent();
        }

        private void FormAdjustment_Load(object sender, EventArgs e)
        {
            LoadPurchaseData();
        }

        private void LoadPurchaseData()
        {
            dtAdjustment = new DataTable();
            bsAdjustment = new BindingSource();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Adjustment ORDER BY AdjustmentId DESC", conn);
            adapter.Fill(dtAdjustment);
            bsAdjustment.DataSource = dtAdjustment;

            txtAdjustmentId.DataBindings.Clear();
            txtAdjustmentId.DataBindings.Add(new Binding("Text", bsAdjustment, "AdjustmentId"));

            dtpTxnDate.DataBindings.Clear();
            dtpTxnDate.DataBindings.Add(new Binding("Text", bsAdjustment, "TxnDate", true));

            txtRefNumber.DataBindings.Clear();
            txtRefNumber.DataBindings.Add(new Binding("Text", bsAdjustment, "RefNumber"));

            txtNote.DataBindings.Clear();
            txtNote.DataBindings.Add(new Binding("Text", bsAdjustment, "Note"));

            LoadItemList();

            LoadPurchaseDetailData();
        }

        private void LoadPurchaseDetailData()
        {
            dtAdjustmentDetail = new DataTable();

            if (bsAdjustment.Count <= 0) return;

            DataRowView current = (DataRowView)bsAdjustment.Current;
            string adjustmentId = current["AdjustmentId"].ToString();
            string sql = $"SELECT AdjustmentDetailId,AdjustmentId,ItemId,Description,Quantity ​" +
                $"FROM AdjustmentDetail WHERE AdjustmentId={adjustmentId}";

            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            adapter.Fill(dtAdjustmentDetail);

            dgAdjustmentDetail.Columns[0].Visible = false;
            dgAdjustmentDetail.Columns[0].DataPropertyName = "AdjustmentDetailId";

            dgAdjustmentDetail.Columns[1].Visible = false;
            dgAdjustmentDetail.Columns[1].DataPropertyName = "AdjustmentId";

            dgAdjustmentDetail.Columns[2].Visible = true;
            dgAdjustmentDetail.Columns[2].HeaderText = "Item";
            dgAdjustmentDetail.Columns[2].Width = 200;
            dgAdjustmentDetail.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgAdjustmentDetail.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgAdjustmentDetail.Columns[2].DataPropertyName = "ItemId";

            dgAdjustmentDetail.Columns[3].Visible = true;
            dgAdjustmentDetail.Columns[3].HeaderText = "Description";
            dgAdjustmentDetail.Columns[3].Width = 300;
            dgAdjustmentDetail.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgAdjustmentDetail.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgAdjustmentDetail.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgAdjustmentDetail.Columns[3].DataPropertyName = "Description";

            dgAdjustmentDetail.Columns[4].Visible = true;
            dgAdjustmentDetail.Columns[4].HeaderText = "Quantity";
            dgAdjustmentDetail.Columns[4].Width = 100;
            dgAdjustmentDetail.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgAdjustmentDetail.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgAdjustmentDetail.Columns[4].DataPropertyName = "Quantity";

            dgAdjustmentDetail.DataSource = dtAdjustmentDetail;
        }

        private void LoadItemList()
        {
            dtItemList = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Item", conn);
            adapter.Fill(dtItemList);

            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)dgAdjustmentDetail.Columns[2];
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
                dgAdjustmentDetail.CurrentRow.Cells[4].Value = 1;
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
            bsAdjustment.AddNew();
            dtAdjustmentDetail.Rows.Clear();
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
            DataRowView datarow = (DataRowView)bsAdjustment.Current;
            if (datarow.IsNew) return;

            DialogResult confirmation;
            confirmation = MessageBox.Show("Are you sure to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmation != DialogResult.Yes) return;

            string adjustmentId = datarow["AdjustmentId"].ToString();
            string sql = $"DELETE FROM Adjustment WHERE AdjustmentId={adjustmentId}";

            SqlCommand cmdSale = new SqlCommand(sql, conn);
            cmdSale.ExecuteNonQuery();

            MessageBox.Show("Adjustment has deleted successfully");

            LoadPurchaseData();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bsAdjustment.CancelEdit();
            bsAdjustment.MoveLast();
            LoadPurchaseDetailData();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bsAdjustment.CancelEdit();
            bsAdjustment.MoveNext();
            LoadPurchaseDetailData();
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            bsAdjustment.CancelEdit();
            bsAdjustment.MovePrevious();
            LoadPurchaseDetailData();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bsAdjustment.CancelEdit();
            bsAdjustment.MoveFirst();
            LoadPurchaseDetailData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dgAdjustmentDetail.EndEdit();
            if (!DoValidation()) return;

            DataRowView datarow = (DataRowView)bsAdjustment.Current;
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

            if (txtRefNumber.Text == "")
            {
                epRefNumber.SetError(txtRefNumber, "Required");
                result = false;
            }
            if (dgAdjustmentDetail.Rows.Count <= 0)
            {
                epAdjustmentDetail.SetError(dgAdjustmentDetail, "Required");
                result = false;
            }

            return result;
        }

        private void SaveNewData()
        {
            try
            {
                string sql = "INSERT INTO Adjustment(TxnDate, RefNumber, EmployeeId, Note) " +
                        "Output Inserted.AdjustmentId " +
                        $"VALUES('{dtpTxnDate.Value:yyyy-MM-dd}','{txtRefNumber.Text}', {employeeId}, '{txtNote.Text}')";

                SqlCommand command = new SqlCommand(sql, conn);
                string adjustmentId = command.ExecuteScalar().ToString();

                foreach (DataRow row in dtAdjustmentDetail.Rows)
                {
                    sql = "INSERT INTO AdjustmentDetail(AdjustmentId,ItemId,Description,Quantity) " +
                        $"VALUES({adjustmentId},{row["ItemId"]}," +
                        $"'{row["Description"]}',{row["Quantity"]})";

                    SqlCommand cmdAdjustmentDetail = new SqlCommand(sql, conn);
                    cmdAdjustmentDetail.ExecuteNonQuery();
                }

                MessageBox.Show("Adjustment has added successfully");

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
                string adjustmentId = datarow["AdjustmentId"].ToString();
                string sql = $"UPDATE Adjustment SET " +
                    $"TxnDate='{dtpTxnDate.Value:yyyy-MM-dd}'," +
                    $"RefNumber='{txtRefNumber.Text}'," +
                    $"EmployeeId={employeeId}," +
                    $"Note='{txtNote.Text}' " +
                    $"WHERE AdjustmentId={adjustmentId} ";

                SqlCommand cmdSale = new SqlCommand(sql, conn);
                cmdSale.ExecuteNonQuery();

                foreach (DataRow row in dtAdjustmentDetail.Rows)
                {
                    string adjustmentDetailId = row["AdjustmentDetailId"].ToString();
                    if (adjustmentDetailId == "")
                    {
                        sql = "INSERT INTO AdjustmentDetail(AdjustmentId, ItemId, Description, Quantity) " +
                            $"VALUES({adjustmentId}, {row["ItemId"]}," +
                            $"'{row["Description"]}', '{row["Quantity"]}')";
                    }
                    else
                    {
                        sql = $"UPDATE AdjustmentDetail SET " +
                            $"AdjustmentId={adjustmentId}," +
                            $"ItemId={row["ItemId"]}," +
                            $"Description='{row["Description"]}'," +
                            $"Quantity={row["Quantity"]} " +
                            $"WHERE AdjustmentDetailId={adjustmentDetailId}";
                    }

                    SqlCommand cmdAdjustmentDetail = new SqlCommand(sql, conn);
                    cmdAdjustmentDetail.ExecuteNonQuery();
                }
                MessageBox.Show("Adjustment has updated successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occur: {ex.Message}", ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRefNumber_TextChanged(object sender, EventArgs e)
        {
            epRefNumber.Clear();
        }
    }
}
