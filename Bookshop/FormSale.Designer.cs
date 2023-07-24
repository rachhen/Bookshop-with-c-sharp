
namespace Bookshop
{
    partial class FormSale
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtRefNumber = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSaleId = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.dtpTxnDate = new System.Windows.Forms.DateTimePicker();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.panel11 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel12 = new System.Windows.Forms.Panel();
            this.cboCustomer = new System.Windows.Forms.ComboBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgSaleDetail = new System.Windows.Forms.DataGridView();
            this.SaleDetailId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.epCustomer = new System.Windows.Forms.ErrorProvider(this.components);
            this.epRefNumber = new System.Windows.Forms.ErrorProvider(this.components);
            this.epSaleDetail = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSaleDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCustomer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRefNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSaleDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Location = new System.Drawing.Point(3, 69);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(222, 48);
            this.panel2.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 14);
            this.label3.TabIndex = 7;
            this.label3.Text = "Number";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.txtRefNumber);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(222, 30);
            this.panel1.TabIndex = 8;
            // 
            // txtRefNumber
            // 
            this.txtRefNumber.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtRefNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRefNumber.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRefNumber.Location = new System.Drawing.Point(4, 8);
            this.txtRefNumber.Name = "txtRefNumber";
            this.txtRefNumber.Size = new System.Drawing.Size(202, 15);
            this.txtRefNumber.TabIndex = 0;
            this.txtRefNumber.TextChanged += new System.EventHandler(this.txtRefNumber_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel14);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(12, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(760, 30);
            this.panel3.TabIndex = 14;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.label7);
            this.panel14.Controls.Add(this.txtSaleId);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel14.Location = new System.Drawing.Point(585, 0);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(175, 30);
            this.panel14.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Sale Id";
            // 
            // txtSaleId
            // 
            this.txtSaleId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaleId.Location = new System.Drawing.Point(75, 4);
            this.txtSaleId.Name = "txtSaleId";
            this.txtSaleId.ReadOnly = true;
            this.txtSaleId.Size = new System.Drawing.Size(100, 21);
            this.txtSaleId.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sale";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Location = new System.Drawing.Point(3, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(222, 48);
            this.panel5.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "Txn Date";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel6.Controls.Add(this.dtpTxnDate);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel6.Location = new System.Drawing.Point(0, 18);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(222, 30);
            this.panel6.TabIndex = 8;
            // 
            // dtpTxnDate
            // 
            this.dtpTxnDate.CalendarMonthBackground = System.Drawing.Color.WhiteSmoke;
            this.dtpTxnDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTxnDate.Location = new System.Drawing.Point(4, 5);
            this.dtpTxnDate.Name = "dtpTxnDate";
            this.dtpTxnDate.Size = new System.Drawing.Size(215, 21);
            this.dtpTxnDate.TabIndex = 38;
            this.dtpTxnDate.Value = new System.DateTime(2023, 7, 29, 20, 11, 21, 0);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnAddCustomer);
            this.panel4.Controls.Add(this.panel11);
            this.panel4.Controls.Add(this.panel9);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(12, 42);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 20);
            this.panel4.Size = new System.Drawing.Size(760, 204);
            this.panel4.TabIndex = 34;
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnAddCustomer.FlatAppearance.BorderSize = 0;
            this.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustomer.ForeColor = System.Drawing.Color.DimGray;
            this.btnAddCustomer.Location = new System.Drawing.Point(231, 153);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(43, 30);
            this.btnAddCustomer.TabIndex = 37;
            this.btnAddCustomer.Text = "Add";
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.label5);
            this.panel11.Controls.Add(this.panel12);
            this.panel11.Location = new System.Drawing.Point(3, 135);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(222, 48);
            this.panel11.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "Customer";
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel12.Controls.Add(this.cboCustomer);
            this.panel12.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel12.Location = new System.Drawing.Point(0, 18);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(222, 30);
            this.panel12.TabIndex = 8;
            // 
            // cboCustomer
            // 
            this.cboCustomer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cboCustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCustomer.FormattingEnabled = true;
            this.cboCustomer.ItemHeight = 13;
            this.cboCustomer.Items.AddRange(new object[] {
            "Male",
            "Female",
            "Other"});
            this.cboCustomer.Location = new System.Drawing.Point(3, 5);
            this.cboCustomer.Name = "cboCustomer";
            this.cboCustomer.Size = new System.Drawing.Size(202, 21);
            this.cboCustomer.TabIndex = 38;
            this.cboCustomer.SelectedIndexChanged += new System.EventHandler(this.cboCustomer_SelectedIndexChanged);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.btnCancel);
            this.panel9.Controls.Add(this.btnDelete);
            this.panel9.Controls.Add(this.btnSave);
            this.panel9.Controls.Add(this.btnNew);
            this.panel9.Controls.Add(this.panel10);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel9.Location = new System.Drawing.Point(339, 5);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(421, 179);
            this.panel9.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatAppearance.BorderSize = 2;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.Teal;
            this.btnCancel.Location = new System.Drawing.Point(3, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 40;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderSize = 2;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(109, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 30);
            this.btnDelete.TabIndex = 39;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Teal;
            this.btnSave.Location = new System.Drawing.Point(215, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 38;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.BackColor = System.Drawing.Color.Teal;
            this.btnNew.FlatAppearance.BorderSize = 0;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.ForeColor = System.Drawing.Color.White;
            this.btnNew.Location = new System.Drawing.Point(321, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 30);
            this.btnNew.TabIndex = 37;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.label6);
            this.panel10.Controls.Add(this.panel13);
            this.panel10.Location = new System.Drawing.Point(3, 60);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(417, 116);
            this.panel10.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 14);
            this.label6.TabIndex = 7;
            this.label6.Text = "Note";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel13.Controls.Add(this.txtNote);
            this.panel13.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel13.Location = new System.Drawing.Point(0, 17);
            this.panel13.Name = "panel13";
            this.panel13.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel13.Size = new System.Drawing.Size(417, 99);
            this.panel13.TabIndex = 8;
            // 
            // txtNote
            // 
            this.txtNote.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNote.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNote.Location = new System.Drawing.Point(0, 5);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(417, 94);
            this.txtNote.TabIndex = 0;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.btnFirst);
            this.panel7.Controls.Add(this.btnPrevious);
            this.panel7.Controls.Add(this.btnNext);
            this.panel7.Controls.Add(this.btnLast);
            this.panel7.Controls.Add(this.label2);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(12, 246);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(760, 41);
            this.panel7.TabIndex = 35;
            // 
            // btnFirst
            // 
            this.btnFirst.BackColor = System.Drawing.Color.Gainsboro;
            this.btnFirst.FlatAppearance.BorderSize = 0;
            this.btnFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFirst.ForeColor = System.Drawing.Color.Black;
            this.btnFirst.Location = new System.Drawing.Point(449, 12);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(70, 23);
            this.btnFirst.TabIndex = 41;
            this.btnFirst.Text = "<<";
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // btnPrevious
            // 
            this.btnPrevious.BackColor = System.Drawing.Color.Gainsboro;
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrevious.ForeColor = System.Drawing.Color.Black;
            this.btnPrevious.Location = new System.Drawing.Point(525, 12);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(70, 23);
            this.btnPrevious.TabIndex = 40;
            this.btnPrevious.Text = "<";
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Gainsboro;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNext.ForeColor = System.Drawing.Color.Black;
            this.btnNext.Location = new System.Drawing.Point(611, 12);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(70, 23);
            this.btnNext.TabIndex = 39;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            this.btnLast.BackColor = System.Drawing.Color.Gainsboro;
            this.btnLast.FlatAppearance.BorderSize = 0;
            this.btnLast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLast.ForeColor = System.Drawing.Color.Black;
            this.btnLast.Location = new System.Drawing.Point(687, 12);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(70, 23);
            this.btnLast.TabIndex = 38;
            this.btnLast.Text = ">>";
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sale Item";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dgSaleDetail);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(12, 287);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel8.Size = new System.Drawing.Size(760, 276);
            this.panel8.TabIndex = 36;
            // 
            // dgSaleDetail
            // 
            this.dgSaleDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dgSaleDetail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgSaleDetail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SaleDetailId,
            this.SaleId,
            this.ItemName,
            this.Description,
            this.Price,
            this.Quantity,
            this.Amount});
            this.dgSaleDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSaleDetail.Location = new System.Drawing.Point(0, 5);
            this.dgSaleDetail.Name = "dgSaleDetail";
            this.dgSaleDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSaleDetail.Size = new System.Drawing.Size(760, 271);
            this.dgSaleDetail.TabIndex = 0;
            this.dgSaleDetail.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSaleDetail_CellValueChanged);
            this.dgSaleDetail.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgSaleItems_EditingControlShowing);
            // 
            // SaleDetailId
            // 
            this.SaleDetailId.HeaderText = "SaleDetailId";
            this.SaleDetailId.Name = "SaleDetailId";
            this.SaleDetailId.Visible = false;
            // 
            // SaleId
            // 
            this.SaleId.HeaderText = "SaleId";
            this.SaleId.Name = "SaleId";
            this.SaleId.Visible = false;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item";
            this.ItemName.Name = "ItemName";
            this.ItemName.Width = 200;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.Name = "Quantity";
            // 
            // Amount
            // 
            this.Amount.HeaderText = "Amount";
            this.Amount.Name = "Amount";
            this.Amount.ReadOnly = true;
            // 
            // epCustomer
            // 
            this.epCustomer.ContainerControl = this;
            // 
            // epRefNumber
            // 
            this.epRefNumber.ContainerControl = this;
            // 
            // epSaleDetail
            // 
            this.epSaleDetail.ContainerControl = this;
            // 
            // FormSale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 575);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSale";
            this.Padding = new System.Windows.Forms.Padding(12);
            this.Text = "FormSale";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormSale_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel12.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSaleDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epCustomer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epRefNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epSaleDetail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRefNumber;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.DateTimePicker dtpTxnDate;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView dgSaleDetail;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.ComboBox cboCustomer;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSaleId;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.ErrorProvider epCustomer;
        private System.Windows.Forms.ErrorProvider epRefNumber;
        private System.Windows.Forms.ErrorProvider epSaleDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleDetailId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaleId;
        private System.Windows.Forms.DataGridViewComboBoxColumn ItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Amount;
    }
}