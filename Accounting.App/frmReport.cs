﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accounting.DataLayer;
using Accounting.DataLayer.Context;
using Accounting.Utility.Convertor;
using Accounting.ViewModels.Customers;

namespace Accounting.App
{
    public partial class frmReport : Form
    {

        public int TypeId = 0;
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            using(Unit_Of_Work db=new Unit_Of_Work())
            {
                List<ListCustomerViewModel> list = new List<ListCustomerViewModel>();
                list.Add(new ListCustomerViewModel()
                {
                    CustomerId=0,
                    FullName="انتخاب کنید"
                });
                list.AddRange(db.CustomerRepository.GetNameCustomers());

                cbCustomer.DataSource = list;
                cbCustomer.DisplayMember = "FullName";
                cbCustomer.ValueMember = "CustomerId";
            }

            if (TypeId == 1)
            {
                this.Text = "گزارش دریافتی ها";
            }
            else
            {
                this.Text = "گزارش پرداختی ها";
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            Filter();
        }

        void Filter()
        {
            using (Unit_Of_Work db = new Unit_Of_Work())
            {
                List<DataLayer.Accounting> result = new List<DataLayer.Accounting>();


                DateTime? startDate;
                DateTime? endDate;

                if ((int)cbCustomer.SelectedValue != 0)
                {
                    int customerId = int.Parse(cbCustomer.SelectedValue.ToString());
                    result.AddRange(db.AccountingRepository.Get(a => a.TypeId == TypeId && a.CusomerId == customerId));
                }
                else
                {
                    result.AddRange(db.AccountingRepository.Get(a => a.TypeId == TypeId));
                }

                if (txtFromDate.Text != "    /  /")
                {
                    startDate=Convert.ToDateTime(txtFromDate.Text);
                    startDate = DateConvertor.ToMiladi(startDate.Value);
                    result=result.Where(r=>r.DateTime>=startDate.Value).ToList();
                }

                if (txtToDate.Text != "    /  /")
                {
                    endDate = Convert.ToDateTime(txtToDate.Text);
                    endDate=DateConvertor.ToMiladi(endDate.Value);
                    result = result.Where(r => r.DateTime <= endDate.Value).ToList();

                }

                //dgReport.AutoGenerateColumns = false;
                //dgReport.DataSource = result;

                dgReport.Rows.Clear();

                foreach (var accounting in result)
                {
                    string customerName = db.CustomerRepository.GetCustomerNameById(accounting.CusomerId);
                    dgReport.Rows.Add(accounting.Id, customerName, accounting.Amount, accounting.DateTime.ToShamsi(), accounting.Description);
                }
            }

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Filter();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgReport.CurrentRow != null)
            {
                int id = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());

                if (RtlMessageBox.Show("ایا از حذف مطمئن هستید؟", "هشدار", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (Unit_Of_Work db = new Unit_Of_Work())
                    {
                        db.AccountingRepository.Delete(id);
                        db.Save();
                        Filter();
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgReport.CurrentRow != null)
            {
                int id = int.Parse(dgReport.CurrentRow.Cells[0].Value.ToString());
                frmNewAccounting frmNew = new frmNewAccounting();
                frmNew.AccountID = id;
                if (frmNew.ShowDialog() == DialogResult.OK)
                {
                    Filter();
                }
            }
        }
    }
}
