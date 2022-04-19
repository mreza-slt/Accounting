using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValidationComponents;
using Accounting.DataLayer.Context;
using Accounting.DataLayer;
using System.IO;

namespace Accounting.App
{
    public partial class Frm_Add_Or_Edit_Customers : Form
    {
        public int customerId = 0;

        Unit_Of_Work db = new Unit_Of_Work();
        public Frm_Add_Or_Edit_Customers()
        {
            InitializeComponent();
        }

        private void btnSelectPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.ShowDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pcCustomer.ImageLocation = dialog.FileName;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (BaseValidator.IsFormValid(this.components))
            {
                string imageName = Guid.NewGuid().ToString() + Path.GetExtension(pcCustomer.ImageLocation);
                string path = Application.StartupPath + "/Images/";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                pcCustomer.Image.Save(path + imageName);

                Customers customer = new Customers()
                {
                    Address = txtAddress.Text,
                    FullName = txtName.Text,
                    Email = txtEmail.Text,
                    Mobile = txtMobile.Text,
                    CustomerImage = imageName
                };

                if (customerId == 0)
                {
                    db.CustomerRepository.InsertCustomer(customer);
                }
                else
                {
                    customer.CustomerId = customerId;
                    db.CustomerRepository.UpdateCustomer(customer);
                }
                db.Save();
                DialogResult = DialogResult.OK;
            }
        }

        private void Frm_Add_Or_Edit_Customers_Load(object sender, EventArgs e)
        {
            if (customerId != 0)
            {
                this.Text = "ویرایش شخص";
                btnSave.Text = "ویرایش";
                var customer = db.CustomerRepository.GetCustomerById(customerId);

                txtEmail.Text = customer.Email;
                txtName.Text = customer.FullName;
                txtAddress.Text = customer.Address;
                txtMobile.Text = customer.Mobile;
                pcCustomer.ImageLocation = Application.StartupPath + "/Images/" + customer.CustomerImage;

            }

        }
    }
}
