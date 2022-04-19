using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.DataLayer.Context;
using ValidationComponents;

namespace Accounting.App
{
    public partial class frmNewAccounting : Form
    {

        Unit_Of_Work db;

        public int AccountID = 0;

        public frmNewAccounting()
        {
            InitializeComponent();
        }

        private void frmNewAccounting_Load(object sender, EventArgs e)
        {
            db = new Unit_Of_Work();
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.DataSource = db.CustomerRepository.GetNameCustomers();

            

            if (AccountID != 0)
            {
                var account = db.AccountingRepository.GetById(AccountID);
                txtAmount.Text = account.Amount.ToString();
                txtDescription.Text = account.Description.ToString();
                txtName.Text = db.CustomerRepository.GetCustomerNameById(account.CusomerId);
                if (account.TypeId == 1)
                {
                    rbtnRecived.Checked = true;
                }
                else
                {
                    rBtnPay.Checked = true;
                }

                this.Text = "ویرایش";
                btnSave.Text = "ویرایش";

                db.Dispose();
            }
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            db = new Unit_Of_Work();
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.DataSource = db.CustomerRepository.GetNameCustomers(txtFilter.Text);
            db.Dispose();
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = dgvCustomers.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                if (rBtnPay.Checked || rbtnRecived.Checked)
                {
                    db = new Unit_Of_Work();
                    DataLayer.Accounting accounting = new DataLayer.Accounting()
                    {
                        Amount = int.Parse(txtAmount.Value.ToString()),
                        CusomerId = db.CustomerRepository.GetCustomerByIdName(txtName.Text),
                        TypeId = (rbtnRecived.Checked) ? 1 : 2,
                        DateTime = DateTime.Now,
                        Description = txtDescription.Text
                    };
                    if (AccountID == 0)
                    {
                        db.AccountingRepository.Insert(accounting);
                        db.Save();
                    }
                    else
                    {
                        accounting.Id = AccountID;
                        db.AccountingRepository.Update(accounting);


                        /*method1 
                        create Unit_Of_Work db;

                        use : 
                        db = new Unit_Of_Work();

                        finish using => db.Dispose();

                        method 2:
                        using (Unit_Of_Work db2 = new Unit_Of_Work())
                        {
                            accounting.Id = AccountID;
                            db2.AccountingRepository.Update(accounting);
                            db2.Save();
                        }

                        -------------i used from method 1;---------
                        */

                    }

                    db.Save();
                    DialogResult = DialogResult.OK;
                    db.Dispose();
                }
                else
                {
                    RtlMessageBox.Show("لطفا نوع تراکنش را انتخاب کنید");
                }
            }
        }
    }
}
