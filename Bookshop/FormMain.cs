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
    public partial class FormMain : Form
    {

        string employeeId;
        SqlConnection conn;

        FormItem formItem;
        FormCustomer formCustomer;
        FormVendor formVendor;
        FormEmployee formEmployee;
        FormSale formSale;

        Rectangle orignalPnMainSize;

        public FormMain(string employeeId, SqlConnection conn)
        {
            this.employeeId = employeeId;
            this.conn = conn;


            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            conn.Close();
            Application.Exit();
        }

        private void mbtnItem_Click(object sender, EventArgs e)
        {
            if (formItem == null)
            {
                formItem = new FormItem();
                formItem.TopLevel = false;
                pnMain.Controls.Add(formItem);
                formItem.Show();
                formItem.BringToFront();
            }
            else
            {
                formItem.BringToFront();
            }
        }

        private void pnMain_Resize(object sender, EventArgs e)
        {
            Console.WriteLine(pnMain.Size);
            if (formItem != null)
            {

            }
        }

      /*  https://www.youtube.com/watch?v=TTsyUclt-XU */
        private void resizeControl(Rectangle r, Control c)
        {

        }

        private void mbtnCustomer_Click(object sender, EventArgs e)
        {
            if (formCustomer == null)
            {
                formCustomer = new FormCustomer();
                formCustomer.TopLevel = false;
                pnMain.Controls.Add(formCustomer);
                formCustomer.Show();
                formCustomer.BringToFront();
            }
            else
            {
                formCustomer.BringToFront();
            }
        }

        private void mbtnVendor_Click(object sender, EventArgs e)
        {
            if (formVendor == null)
            {
                formVendor = new FormVendor(conn);
                formVendor.TopLevel = false;
                pnMain.Controls.Add(formVendor);
                formVendor.Show();
                formVendor.BringToFront();
            }
            else
            {
                formVendor.BringToFront();
            }
        }

        private void mbtnEmployee_Click(object sender, EventArgs e)
        {
            if (formEmployee == null)
            {
                formEmployee = new FormEmployee(conn);
                formEmployee.TopLevel = false;
                pnMain.Controls.Add(formEmployee);
                formEmployee.Show();
                formEmployee.BringToFront();
            }
            else
            {
                formEmployee.BringToFront();
            }
        }

        private void mbtnSale_Click(object sender, EventArgs e)
        {
            LoadFormSale();
        }

        private void LoadFormSale()
        {
            if (formSale == null)
            {
                formSale = new FormSale(employeeId, conn);
                formSale.TopLevel = false;
                pnMain.Controls.Add(formSale);
                formSale.Show();
                formSale.BringToFront();
            }
            else
            {
                formSale.BringToFront();
            }
        }
    }
}
