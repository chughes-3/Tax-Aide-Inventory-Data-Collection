namespace InventoryDataCollection
{
    partial class ChooseSplitState
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
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select your Split State from the list below, then the \r\ninformation for the syste" +
    "ms in your Split State and \r\nthe newly shipped systems will be downloaded.";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Alaska   \tAK1",
            "Alabama\tAL1",
            "Arkansas\tAR1",
            "Arizona  \tAZ1",
            "California\tCA1",
            "California\tCA2",
            "California\tCA3",
            "California\tCA4",
            "California\tCA5",
            "Colorado\tCO1",
            "Connecticut      CT1",
            "Dist of Columbia   DC1",
            "Dist of Columbia   DC2",
            "Delaware\tDE1",
            "Florida\tFL1",
            "Florida\tFL2",
            "Florida\tFL3",
            "Florida\tFL4",
            "Florida\tFL5",
            "Florida\tFL6",
            "Georgia\tGA1",
            "Gulf Region     GRD",
            "Hawaii\tHI1",
            "Iowa    \tIA1",
            "Idaho  \tID1",
            "Illinois  \tIL1",
            "Illinois  \tIL2",
            "Indiana\tIN1",
            "Kansas\tKS1",
            "Kentucky\tKY1",
            "Louisiana\tLA1",
            "Massachusetts\tMA1",
            "Maryland\tMD1",
            "Maine  \tME1",
            "Michigan\tMI1",
            "Minnesota\tMN1",
            "Minnesota\tMN2",
            "Missouri\tMO1",
            "Mississippi\tMS1",
            "Montana\tMT1",
            "North Carolina\tNC1",
            "North Dakota\tND1",
            "Nebraska\tNE1",
            "New Hampshire NH1",
            "New Jersey\tNJ1",
            "New Mexico\tNM1",
            "Nevada\tNV1",
            "New York\tNY1",
            "New York\tNY2",
            "New York\tNY3",
            "New York\tNY4",
            "Ohio    \tOH1",
            "Ohio    \tOH2",
            "Ohio    \tOH3",
            "Oklahoma\tOK1",
            "Oregon\tOR1",
            "Pennsylvania\tPA1",
            "Pennsylvania\tPA2",
            "Rhode Island\tRI1",
            "South Carolina\tSC1",
            "South Dakota\tSD1",
            "Tennessee\tTN1",
            "Texas   \tTX1",
            "Texas   \tTX2",
            "Texas   \tTX3",
            "Texas   \tTX4",
            "Utah    \tUT1",
            "Virginia\tVA1",
            "Vermont\tVT1",
            "Washington\tWA1",
            "Wisconsin\tWI1",
            "West Virginia\tWV1",
            "Wyoming\tWY1"});
            this.checkedListBox1.Location = new System.Drawing.Point(16, 60);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(195, 199);
            this.checkedListBox1.TabIndex = 1;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(154, 276);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(44, 276);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // ChooseSplitState
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 309);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.label1);
            this.Name = "ChooseSplitState";
            this.Text = "ChooseSplitState";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}