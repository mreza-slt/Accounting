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

namespace Accounting.App
{
    public partial class Frm_Customers : Form
    {
        public Frm_Customers()
        {
            InitializeComponent();
        }

        private void Frm_Customers_Load(object sender, EventArgs e)
        {
            BindGrid();
        }

        void BindGrid()
        {
            using (Unit_Of_Work db = new Unit_Of_Work())
            {
                dgCustomers.AutoGenerateColumns = false;
                dgCustomers.DataSource = db.CustomerRepository.GetAllCustomers();
            }
        }

        private void refreshCustomer_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            BindGrid();
        }

        private void txtFilter_TextChanged(object sender, EventArgs e)
        {
            using (Unit_Of_Work db = new Unit_Of_Work())
            {
                dgCustomers.DataSource = db.CustomerRepository.GetCustomersByFilter(txtFilter.Text);
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dgCustomers.CurrentRow != null)
            {
                using (Unit_Of_Work db = new Unit_Of_Work())
                {
                    string name = dgCustomers.CurrentRow.Cells[1].Value.ToString();

                    if(RtlMessageBox.Show($"ایا از حذف {name} مطمئن هستید؟", "توجه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {

                    int customerId = int.Parse(dgCustomers.CurrentRow.Cells[0].Value.ToString());

                    db.CustomerRepository.DeleteCustomer(customerId);
                    db.Save();

                    BindGrid();
                    }



                }

            }
            else
            {
                RtlMessageBox.Show("لطفا ستونی را انتخاب کنید.");
            }
        }

        private void btnAddNewCustomers_Click(object sender, EventArgs e)
        {
            Frm_Add_Or_Edit_Customers frmAdd = new Frm_Add_Or_Edit_Customers();
            if (frmAdd.ShowDialog() == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if(dgCustomers.CurrentRow != null)
            {
                int customerId=int.Parse(dgCustomers.CurrentRow.Cells[0].Value.ToString());

                Frm_Add_Or_Edit_Customers frmOrAndEdit = new Frm_Add_Or_Edit_Customers();

                frmOrAndEdit.customerId=customerId;

                if (frmOrAndEdit.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }
            }
        }
    }
}
