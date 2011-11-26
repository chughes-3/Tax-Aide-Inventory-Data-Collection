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
            this.partialKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ATag = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.serNumHum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.entryAssetTag = new System.Windows.Forms.TextBox();
            this.serialNumHR = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxThisSys = new System.Windows.Forms.TextBox();
            this.ProdKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(501, 39);
            this.label2.TabIndex = 0;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // listViewInvFile
            // 
            this.listViewInvFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
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
            this.OSVer,
            this.partialKey,
            this.ProdKey,
            this.ATag,
            this.serNumHum});
            this.listViewInvFile.Location = new System.Drawing.Point(16, 365);
            this.listViewInvFile.Name = "listViewInvFile";
            this.listViewInvFile.Size = new System.Drawing.Size(642, 234);
            this.listViewInvFile.TabIndex = 0;
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
            this.SerialNum.Text = "Serial_Number";
            // 
            // CPU
            // 
            this.CPU.Text = "CPU(MHz)";
            this.CPU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Memory
            // 
            this.Memory.Text = "Memory(MB)";
            this.Memory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Disk
            // 
            this.Disk.Text = "Disk(GB)";
            this.Disk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // OS
            // 
            this.OS.Text = "OS";
            // 
            // OSVer
            // 
            this.OSVer.Text = "OS_Version";
            // 
            // partialKey
            // 
            this.partialKey.Text = "Partial_Key";
            // 
            // ATag
            // 
            this.ATag.Text = "Asset_Tag";
            // 
            // serNumHum
            // 
            this.serNumHum.Text = "Human_Ser_Num";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(575, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "The current contents of the Inventory Data Text File. This window and the columns" +
                " below are resizable for better viewing";
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OK.Location = new System.Drawing.Point(493, 605);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 38);
            this.OK.TabIndex = 4;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(380, 104);
            this.label4.TabIndex = 0;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // entryAssetTag
            // 
            this.entryAssetTag.Location = new System.Drawing.Point(32, 188);
            this.entryAssetTag.Name = "entryAssetTag";
            this.entryAssetTag.Size = new System.Drawing.Size(112, 20);
            this.entryAssetTag.TabIndex = 2;
            this.entryAssetTag.Text = "Asset Tag";
            this.entryAssetTag.Enter += new System.EventHandler(this.entryAssetTag_Enter);
            this.entryAssetTag.Validating += new System.ComponentModel.CancelEventHandler(this.entryAssetTag_Validating);
            // 
            // serialNumHR
            // 
            this.serialNumHR.Location = new System.Drawing.Point(32, 224);
            this.serialNumHR.Name = "serialNumHR";
            this.serialNumHR.Size = new System.Drawing.Size(112, 20);
            this.serialNumHR.TabIndex = 3;
            this.serialNumHR.Text = "Serial Number";
            this.serialNumHR.Enter += new System.EventHandler(this.serialNumHR_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(165, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(362, 26);
            this.label5.TabIndex = 0;
            this.label5.Text = "Please enter the Asset Tag that has previously been used in past inventory \r\ndata" +
                " spreadsheets to identify this system";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(165, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(380, 26);
            this.label6.TabIndex = 0;
            this.label6.Text = "Please enter the Serial Number that has previously been used in past inventory \r\n" +
                "data spreadsheets to identify the system\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(501, 39);
            this.label7.TabIndex = 0;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(493, 605);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OK_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(564, 275);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 38);
            this.button2.TabIndex = 4;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OK_Click);
            // 
            // textBoxThisSys
            // 
            this.textBoxThisSys.Location = new System.Drawing.Point(19, 30);
            this.textBoxThisSys.Multiline = true;
            this.textBoxThisSys.Name = "textBoxThisSys";
            this.textBoxThisSys.ReadOnly = true;
            this.textBoxThisSys.Size = new System.Drawing.Size(258, 152);
            this.textBoxThisSys.TabIndex = 5;
            // 
            // ProdKey
            // 
            this.ProdKey.Text = "Product_Key";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 655);
            this.Controls.Add(this.textBoxThisSys);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.serialNumHR);
            this.Controls.Add(this.entryAssetTag);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listViewInvFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "TaxAide Inventory Data Collection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader partialKey;
        private System.Windows.Forms.TextBox entryAssetTag;
        private System.Windows.Forms.TextBox serialNumHR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader ATag;
        private System.Windows.Forms.ColumnHeader serNumHum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxThisSys;
        private System.Windows.Forms.ColumnHeader ProdKey;
    }
}

