namespace InventoryDataCollection
{
    partial class HrDataPrevDisparity
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxSn = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBxIDCPrvSn = new System.Windows.Forms.TextBox();
            this.txtBxDbSn = new System.Windows.Forms.TextBox();
            this.radButSnIDC = new System.Windows.Forms.RadioButton();
            this.radButSnDb = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBoxAt = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBxATagIDC = new System.Windows.Forms.TextBox();
            this.txtBxAtagDB = new System.Windows.Forms.TextBox();
            this.radButAtagIDC = new System.Windows.Forms.RadioButton();
            this.radButAtagDB = new System.Windows.Forms.RadioButton();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.groupBoxSn.SuspendLayout();
            this.groupBoxAt.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(376, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Last year\'s IDC data and the downloaded file from the national database have \r\ndi" +
    "fferent values for some of the data. Choose the correct data to use below.";
            // 
            // groupBoxSn
            // 
            this.groupBoxSn.Controls.Add(this.label3);
            this.groupBoxSn.Controls.Add(this.label2);
            this.groupBoxSn.Controls.Add(this.txtBxIDCPrvSn);
            this.groupBoxSn.Controls.Add(this.txtBxDbSn);
            this.groupBoxSn.Controls.Add(this.radButSnIDC);
            this.groupBoxSn.Controls.Add(this.radButSnDb);
            this.groupBoxSn.Location = new System.Drawing.Point(13, 56);
            this.groupBoxSn.Name = "groupBoxSn";
            this.groupBoxSn.Size = new System.Drawing.Size(446, 92);
            this.groupBoxSn.TabIndex = 0;
            this.groupBoxSn.TabStop = false;
            this.groupBoxSn.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Label Serial Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Label Serial Number";
            // 
            // txtBxIDCPrvSn
            // 
            this.txtBxIDCPrvSn.Location = new System.Drawing.Point(108, 51);
            this.txtBxIDCPrvSn.Name = "txtBxIDCPrvSn";
            this.txtBxIDCPrvSn.Size = new System.Drawing.Size(121, 20);
            this.txtBxIDCPrvSn.TabIndex = 7;
            // 
            // txtBxDbSn
            // 
            this.txtBxDbSn.Location = new System.Drawing.Point(108, 14);
            this.txtBxDbSn.Name = "txtBxDbSn";
            this.txtBxDbSn.Size = new System.Drawing.Size(121, 20);
            this.txtBxDbSn.TabIndex = 7;
            // 
            // radButSnIDC
            // 
            this.radButSnIDC.AutoSize = true;
            this.radButSnIDC.Location = new System.Drawing.Point(246, 51);
            this.radButSnIDC.Name = "radButSnIDC";
            this.radButSnIDC.Size = new System.Drawing.Size(170, 17);
            this.radButSnIDC.TabIndex = 6;
            this.radButSnIDC.Text = "Use this value from prior yr IDC";
            this.radButSnIDC.UseVisualStyleBackColor = true;
            // 
            // radButSnDb
            // 
            this.radButSnDb.AutoSize = true;
            this.radButSnDb.Checked = true;
            this.radButSnDb.Location = new System.Drawing.Point(246, 14);
            this.radButSnDb.Name = "radButSnDb";
            this.radButSnDb.Size = new System.Drawing.Size(162, 17);
            this.radButSnDb.TabIndex = 5;
            this.radButSnDb.TabStop = true;
            this.radButSnDb.Text = "Use this value from database";
            this.radButSnDb.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(248, 276);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(90, 36);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupBoxAt
            // 
            this.groupBoxAt.Controls.Add(this.label5);
            this.groupBoxAt.Controls.Add(this.label4);
            this.groupBoxAt.Controls.Add(this.txtBxATagIDC);
            this.groupBoxAt.Controls.Add(this.txtBxAtagDB);
            this.groupBoxAt.Controls.Add(this.radButAtagIDC);
            this.groupBoxAt.Controls.Add(this.radButAtagDB);
            this.groupBoxAt.Location = new System.Drawing.Point(16, 163);
            this.groupBoxAt.Name = "groupBoxAt";
            this.groupBoxAt.Size = new System.Drawing.Size(446, 92);
            this.groupBoxAt.TabIndex = 0;
            this.groupBoxAt.TabStop = false;
            this.groupBoxAt.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Asset Tag";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Asset Tag";
            // 
            // txtBxATagIDC
            // 
            this.txtBxATagIDC.Location = new System.Drawing.Point(101, 48);
            this.txtBxATagIDC.Name = "txtBxATagIDC";
            this.txtBxATagIDC.Size = new System.Drawing.Size(125, 20);
            this.txtBxATagIDC.TabIndex = 7;
            // 
            // txtBxAtagDB
            // 
            this.txtBxAtagDB.Location = new System.Drawing.Point(101, 14);
            this.txtBxAtagDB.Name = "txtBxAtagDB";
            this.txtBxAtagDB.Size = new System.Drawing.Size(125, 20);
            this.txtBxAtagDB.TabIndex = 7;
            // 
            // radButAtagIDC
            // 
            this.radButAtagIDC.AutoSize = true;
            this.radButAtagIDC.Location = new System.Drawing.Point(242, 51);
            this.radButAtagIDC.Name = "radButAtagIDC";
            this.radButAtagIDC.Size = new System.Drawing.Size(170, 17);
            this.radButAtagIDC.TabIndex = 6;
            this.radButAtagIDC.Text = "Use this value from prior yr IDC";
            this.radButAtagIDC.UseVisualStyleBackColor = true;
            // 
            // radButAtagDB
            // 
            this.radButAtagDB.AutoSize = true;
            this.radButAtagDB.Checked = true;
            this.radButAtagDB.Location = new System.Drawing.Point(242, 14);
            this.radButAtagDB.Name = "radButAtagDB";
            this.radButAtagDB.Size = new System.Drawing.Size(162, 17);
            this.radButAtagDB.TabIndex = 5;
            this.radButAtagDB.TabStop = true;
            this.radButAtagDB.Text = "Use this value from database";
            this.radButAtagDB.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(75, 276);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(90, 36);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // HrDataPrevDisparity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 324);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBoxAt);
            this.Controls.Add(this.groupBoxSn);
            this.Name = "HrDataPrevDisparity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tax-Aide Inventory Data Collection";
            this.groupBoxSn.ResumeLayout(false);
            this.groupBoxSn.PerformLayout();
            this.groupBoxAt.ResumeLayout(false);
            this.groupBoxAt.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        internal System.Windows.Forms.TextBox txtBxDbSn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtBxIDCPrvSn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txtBxATagIDC;
        internal System.Windows.Forms.TextBox txtBxAtagDB;
        internal System.Windows.Forms.RadioButton radButSnIDC;
        internal System.Windows.Forms.RadioButton radButSnDb;
        internal System.Windows.Forms.RadioButton radButAtagIDC;
        internal System.Windows.Forms.RadioButton radButAtagDB;
        internal System.Windows.Forms.GroupBox groupBoxSn;
        internal System.Windows.Forms.GroupBox groupBoxAt;
    }
}