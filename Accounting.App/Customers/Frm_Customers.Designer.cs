namespace Accounting.App
{
    partial class Frm_Customers
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddNewCustomers = new System.Windows.Forms.ToolStripButton();
            this.btnEditCustomer = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteCustomer = new System.Windows.Forms.ToolStripButton();
            this.refreshCustomer = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtFilter = new System.Windows.Forms.ToolStripTextBox();
            this.dgCustomers = new System.Windows.Forms.DataGridView();
            this.CustomerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mobile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddNewCustomers,
            this.btnEditCustomer,
            this.btnDeleteCustomer,
            this.refreshCustomer,
            this.toolStripLabel1,
            this.txtFilter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(582, 67);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddNewCustomers
            // 
            this.btnAddNewCustomers.Image = global::Accounting.App.Properties.Resources._1371475930_filenew;
            this.btnAddNewCustomers.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAddNewCustomers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddNewCustomers.Name = "btnAddNewCustomers";
            this.btnAddNewCustomers.Size = new System.Drawing.Size(89, 64);
            this.btnAddNewCustomers.Text = "شخص جدید";
            this.btnAddNewCustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAddNewCustomers.Click += new System.EventHandler(this.btnAddNewCustomers_Click);
            // 
            // btnEditCustomer
            // 
            this.btnEditCustomer.Image = global::Accounting.App.Properties.Resources._1371475973_document_edit;
            this.btnEditCustomer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditCustomer.Name = "btnEditCustomer";
            this.btnEditCustomer.Size = new System.Drawing.Size(105, 64);
            this.btnEditCustomer.Text = "ویرایش شخص";
            this.btnEditCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnEditCustomer.Click += new System.EventHandler(this.btnEditCustomer_Click);
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.Image = global::Accounting.App.Properties.Resources._1371476007_Close_Box_Red;
            this.btnDeleteCustomer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDeleteCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(91, 64);
            this.btnDeleteCustomer.Text = "حذف شخص";
            this.btnDeleteCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // refreshCustomer
            // 
            this.refreshCustomer.Image = global::Accounting.App.Properties.Resources._1371476368_Synchronize;
            this.refreshCustomer.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.refreshCustomer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshCustomer.Name = "refreshCustomer";
            this.refreshCustomer.Size = new System.Drawing.Size(88, 64);
            this.refreshCustomer.Text = "به روزرسانی";
            this.refreshCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.refreshCustomer.Click += new System.EventHandler(this.refreshCustomer_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(56, 64);
            this.toolStripLabel1.Text = "جستجو:";
            // 
            // txtFilter
            // 
            this.txtFilter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(100, 67);
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // dgCustomers
            // 
            this.dgCustomers.AllowUserToAddRows = false;
            this.dgCustomers.AllowUserToDeleteRows = false;
            this.dgCustomers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomerId,
            this.FullName,
            this.Mobile,
            this.Email});
            this.dgCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCustomers.Location = new System.Drawing.Point(0, 67);
            this.dgCustomers.Name = "dgCustomers";
            this.dgCustomers.ReadOnly = true;
            this.dgCustomers.RowHeadersWidth = 51;
            this.dgCustomers.RowTemplate.Height = 24;
            this.dgCustomers.Size = new System.Drawing.Size(582, 286);
            this.dgCustomers.TabIndex = 1;
            // 
            // CustomerId
            // 
            this.CustomerId.DataPropertyName = "CustomerId";
            this.CustomerId.HeaderText = "Column1";
            this.CustomerId.MinimumWidth = 6;
            this.CustomerId.Name = "CustomerId";
            this.CustomerId.ReadOnly = true;
            this.CustomerId.Visible = false;
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.HeaderText = "نام";
            this.FullName.MinimumWidth = 6;
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            // 
            // Mobile
            // 
            this.Mobile.DataPropertyName = "Mobile";
            this.Mobile.HeaderText = "موبایل";
            this.Mobile.MinimumWidth = 6;
            this.Mobile.Name = "Mobile";
            this.Mobile.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "ایمیل";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Frm_Customers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 353);
            this.Controls.Add(this.dgCustomers);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_Customers";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "لیست اشخاص";
            this.Load += new System.EventHandler(this.Frm_Customers_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCustomers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddNewCustomers;
        private System.Windows.Forms.ToolStripButton btnEditCustomer;
        private System.Windows.Forms.ToolStripButton btnDeleteCustomer;
        private System.Windows.Forms.ToolStripButton refreshCustomer;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtFilter;
        private System.Windows.Forms.DataGridView dgCustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mobile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    }
}