namespace InventoryDataCollection
{
    partial class SysDsplyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SysDsplyForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewInvFile = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.entryAssetTag = new System.Windows.Forms.TextBox();
            this.serialNumHR = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBoxThisSys = new System.Windows.Forms.TextBox();
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
            this.listViewInvFile.FullRowSelect = true;
            this.listViewInvFile.Location = new System.Drawing.Point(16, 365);
            this.listViewInvFile.MultiSelect = false;
            this.listViewInvFile.Name = "listViewInvFile";
            this.listViewInvFile.Size = new System.Drawing.Size(642, 234);
            this.listViewInvFile.TabIndex = 0;
            this.listViewInvFile.UseCompatibleStateImageBehavior = false;
            this.listViewInvFile.View = System.Windows.Forms.View.Details;
            this.listViewInvFile.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewInvFile_ColumnClick);
            this.listViewInvFile.ItemActivate += new System.EventHandler(this.listViewInvFile_ItemActivate);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 340);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(551, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "The current contents of the Inventory Data File. This window and the columns belo" +
    "w are resizable for better viewing";
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
            this.entryAssetTag.Leave += new System.EventHandler(this.entryAssetTag_Leave);
            // 
            // serialNumHR
            // 
            this.serialNumHR.Location = new System.Drawing.Point(32, 224);
            this.serialNumHR.Name = "serialNumHR";
            this.serialNumHR.Size = new System.Drawing.Size(112, 20);
            this.serialNumHR.TabIndex = 3;
            this.serialNumHR.Text = "Serial Number";
            this.serialNumHR.Enter += new System.EventHandler(this.serialNumHR_Enter);
            this.serialNumHR.Leave += new System.EventHandler(this.serialNumHR_Leave);
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
            this.label7.Size = new System.Drawing.Size(509, 39);
            this.label7.TabIndex = 0;
            this.label7.Text = resources.GetString("label7.Text");
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(493, 605);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 38);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.OK_Click);
            // 
            // button2
            // 
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
            // SysDsplyForm
            // 
            this.AcceptButton = this.buttonOK;
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
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listViewInvFile);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SysDsplyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TaxAide Inventory Data Collection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewInvFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox entryAssetTag;
        private System.Windows.Forms.TextBox serialNumHR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBoxThisSys;
    }
}

