namespace InventoryDataCollection
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxThisSys = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewInvFile = new System.Windows.Forms.ListView();
            this.nameComp1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Manufacturer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SerialNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CPU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Memory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Disk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OSVer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inventory Data for this System";
            // 
            // listBoxThisSys
            // 
            this.listBoxThisSys.FormattingEnabled = true;
            this.listBoxThisSys.Location = new System.Drawing.Point(16, 35);
            this.listBoxThisSys.Name = "listBoxThisSys";
            this.listBoxThisSys.Size = new System.Drawing.Size(290, 121);
            this.listBoxThisSys.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 183);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(462, 52);
            this.label2.TabIndex = 2;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // listViewInvFile
            // 
            this.listViewInvFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewInvFile.AutoArrange = false;
            this.listViewInvFile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameComp1,
            this.Manufacturer,
            this.Model,
            this.SerialNum,
            this.CPU,
            this.Memory,
            this.Disk,
            this.OS,
            this.OSVer});
            this.listViewInvFile.Location = new System.Drawing.Point(16, 268);
            this.listViewInvFile.Name = "listViewInvFile";
            this.listViewInvFile.Size = new System.Drawing.Size(619, 250);
            this.listViewInvFile.TabIndex = 3;
            this.listViewInvFile.UseCompatibleStateImageBehavior = false;
            this.listViewInvFile.View = System.Windows.Forms.View.Details;
            // 
            // nameComp1
            // 
            this.nameComp1.Text = "Name";
            this.nameComp1.Width = 120;
            // 
            // Manufacturer
            // 
            this.Manufacturer.Text = "Manufacturer";
            this.Manufacturer.Width = 74;
            // 
            // Model
            // 
            this.Model.Text = "Model";
            // 
            // SerialNum
            // 
            this.SerialNum.Text = "Serial Number";
            // 
            // CPU
            // 
            this.CPU.Text = "CPU";
            // 
            // Memory
            // 
            this.Memory.Text = "Memory";
            // 
            // Disk
            // 
            this.Disk.Text = "Disk";
            // 
            // OS
            // 
            this.OS.Text = "OS";
            // 
            // OSVer
            // 
            this.OSVer.Text = "OS Version";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(575, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "The current contents of the Inventory Data Text File. This window and the columns" +
                " below are resizable for better viewing";
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.Location = new System.Drawing.Point(470, 524);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 38);
            this.OK.TabIndex = 5;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 574);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listViewInvFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxThisSys);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "TaxAide Inventory Data Collection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxThisSys;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewInvFile;
        private System.Windows.Forms.ColumnHeader Manufacturer;
        private System.Windows.Forms.ColumnHeader Model;
        private System.Windows.Forms.ColumnHeader SerialNum;
        private System.Windows.Forms.ColumnHeader CPU;
        private System.Windows.Forms.ColumnHeader Memory;
        private System.Windows.Forms.ColumnHeader Disk;
        private System.Windows.Forms.ColumnHeader OS;
        private System.Windows.Forms.ColumnHeader OSVer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.ColumnHeader nameComp1;
    }
}

