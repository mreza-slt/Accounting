using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.Business;
using Accounting.Utility.Convertor;
using Accounting.ViewModels.Accounting;

namespace Accounting.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            Frm_Customers frm = new Frm_Customers();

            frm.ShowDialog();
        }

        private void btnNewAccounting_Click(object sender, EventArgs e)
        {
            frmNewAccounting frm_New_Accounting = new frmNewAccounting();

            frm_New_Accounting.ShowDialog();
        }

        private void btnReportPay_Click(object sender, EventArgs e)
        {
            frmReport frmReport = new frmReport();
            frmReport.TypeId = 2;
            frmReport.ShowDialog();
        }

        private void btnReportRecived_Click(object sender, EventArgs e)
        {
            frmReport frmReport = new frmReport();
            frmReport.TypeId = 1;
            frmReport.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.Hide();
            frmLogin frmLogin = new frmLogin();
            if (frmLogin.ShowDialog() == DialogResult.OK)
            {
                this.Show();
                lblDate.Text = DateConvertor.ToShamsi(DateTime.Now);
                lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
                Report();
            }
            else
            {
                Application.Exit();
            }
        }

        void Report()
        {
            ReportViewModel report = Account.ReportFormMain();
            lblPay.Text = report.Pay.ToString("#,0");
            lblRecived.Text = report.Recived.ToString("#,0");
            lblAccountBalance.Text = report.AccountBalance.ToString("#,0");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void تنظیماتورودToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.IsEdit = true;
            frmLogin.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Report();
        }
    }
}
