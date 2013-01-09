namespace InventoryDataCollection
{
    partial class ItemActions
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
            this.labelInitialStatement = new System.Windows.Forms.Label();
            this.deleteRow = new System.Windows.Forms.Button();
            this.labelEditData = new System.Windows.Forms.Label();
            this.textboxAssetTag = new System.Windows.Forms.TextBox();
            this.labelAssetTag = new System.Windows.Forms.Label();
            this.textBoxSerialNo = new System.Windows.Forms.TextBox();
            this.labelSerialNo = new System.Windows.Forms.Label();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelAfterRow = new System.Windows.Forms.Label();
            this.labelBeforeRow = new System.Windows.Forms.Label();
            this.textBoxBeforeRow = new System.Windows.Forms.TextBox();
            this.textBoxAfter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelInitialStatement
            // 
            this.labelInitialStatement.AutoSize = true;
            this.labelInitialStatement.Location = new System.Drawing.Point(13, 13);
            this.labelInitialStatement.Name = "labelInitialStatement";
            this.labelInitialStatement.Size = new System.Drawing.Size(226, 13);
            this.labelInitialStatement.TabIndex = 0;
            this.labelInitialStatement.Text = "You have selected the System Data on Row   ";
            // 
            // deleteRow
            // 
            this.deleteRow.Location = new System.Drawing.Point(52, 43);
            this.deleteRow.Name = "deleteRow";
            this.deleteRow.Size = new System.Drawing.Size(153, 23);
            this.deleteRow.TabIndex = 3;
            this.deleteRow.Text = "Delete the Data on this Row";
            this.deleteRow.UseVisualStyleBackColor = true;
            this.deleteRow.Click += new System.EventHandler(this.deleteRow_Click);
            // 
            // labelEditData
            // 
            this.labelEditData.AutoSize = true;
            this.labelEditData.Location = new System.Drawing.Point(16, 163);
            this.labelEditData.Name = "labelEditData";
            this.labelEditData.Size = new System.Drawing.Size(234, 13);
            this.labelEditData.TabIndex = 0;
            this.labelEditData.Text = "Edit the Asset Tag or Serial Number for this Row";
            // 
            // textboxAssetTag
            // 
            this.textboxAssetTag.Location = new System.Drawing.Point(124, 195);
            this.textboxAssetTag.Name = "textboxAssetTag";
            this.textboxAssetTag.Size = new System.Drawing.Size(100, 20);
            this.textboxAssetTag.TabIndex = 6;
            this.textboxAssetTag.Text = "Asset Tag";
            this.textboxAssetTag.Enter += new System.EventHandler(this.textboxAssetTag_Enter);
            this.textboxAssetTag.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textboxAssetTag.Leave += new System.EventHandler(this.textboxAssetTag_Leave);
            // 
            // labelAssetTag
            // 
            this.labelAssetTag.AutoSize = true;
            this.labelAssetTag.Location = new System.Drawing.Point(16, 195);
            this.labelAssetTag.Name = "labelAssetTag";
            this.labelAssetTag.Size = new System.Drawing.Size(55, 13);
            this.labelAssetTag.TabIndex = 0;
            this.labelAssetTag.Text = "Asset Tag";
            // 
            // textBoxSerialNo
            // 
            this.textBoxSerialNo.Location = new System.Drawing.Point(124, 232);
            this.textBoxSerialNo.Name = "textBoxSerialNo";
            this.textBoxSerialNo.Size = new System.Drawing.Size(100, 20);
            this.textBoxSerialNo.TabIndex = 7;
            this.textBoxSerialNo.Text = "Serial Number";
            this.textBoxSerialNo.Enter += new System.EventHandler(this.textBoxSerialNo_Enter);
            this.textBoxSerialNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxSerialNo.Leave += new System.EventHandler(this.textBoxSerialNo_Leave);
            // 
            // labelSerialNo
            // 
            this.labelSerialNo.AutoSize = true;
            this.labelSerialNo.Location = new System.Drawing.Point(16, 232);
            this.labelSerialNo.Name = "labelSerialNo";
            this.labelSerialNo.Size = new System.Drawing.Size(73, 13);
            this.labelSerialNo.TabIndex = 0;
            this.labelSerialNo.Text = "Serial Number";
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(52, 265);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 1;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(174, 265);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // labelAfterRow
            // 
            this.labelAfterRow.AutoSize = true;
            this.labelAfterRow.Location = new System.Drawing.Point(38, 92);
            this.labelAfterRow.Name = "labelAfterRow";
            this.labelAfterRow.Size = new System.Drawing.Size(150, 13);
            this.labelAfterRow.TabIndex = 0;
            this.labelAfterRow.Text = "Move this row to before row    ";
            // 
            // labelBeforeRow
            // 
            this.labelBeforeRow.AutoSize = true;
            this.labelBeforeRow.Location = new System.Drawing.Point(38, 129);
            this.labelBeforeRow.Name = "labelBeforeRow";
            this.labelBeforeRow.Size = new System.Drawing.Size(141, 13);
            this.labelBeforeRow.TabIndex = 0;
            this.labelBeforeRow.Text = "Move this row to after row    ";
            // 
            // textBoxBeforeRow
            // 
            this.textBoxBeforeRow.Location = new System.Drawing.Point(197, 89);
            this.textBoxBeforeRow.MaxLength = 3;
            this.textBoxBeforeRow.Name = "textBoxBeforeRow";
            this.textBoxBeforeRow.Size = new System.Drawing.Size(42, 20);
            this.textBoxBeforeRow.TabIndex = 4;
            this.textBoxBeforeRow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxBeforeRow.Enter += new System.EventHandler(this.textBoxBeforeRow_Enter);
            this.textBoxBeforeRow.Leave += new System.EventHandler(this.textBoxBeforeRow_Leave);
            // 
            // textBoxAfter
            // 
            this.textBoxAfter.Location = new System.Drawing.Point(194, 122);
            this.textBoxAfter.MaxLength = 3;
            this.textBoxAfter.Name = "textBoxAfter";
            this.textBoxAfter.Size = new System.Drawing.Size(42, 20);
            this.textBoxAfter.TabIndex = 5;
            this.textBoxAfter.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxAfter.Enter += new System.EventHandler(this.textBoxAfter_Enter);
            this.textBoxAfter.Leave += new System.EventHandler(this.textBoxAfter_Leave);
            // 
            // ItemActions
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(295, 300);
            this.Controls.Add(this.textBoxAfter);
            this.Controls.Add(this.textBoxBeforeRow);
            this.Controls.Add(this.labelBeforeRow);
            this.Controls.Add(this.labelAfterRow);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.labelSerialNo);
            this.Controls.Add(this.textBoxSerialNo);
            this.Controls.Add(this.labelAssetTag);
            this.Controls.Add(this.textboxAssetTag);
            this.Controls.Add(this.labelEditData);
            this.Controls.Add(this.deleteRow);
            this.Controls.Add(this.labelInitialStatement);
            this.Name = "ItemActions";
            this.Text = "Inventory Data Collection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelInitialStatement;
        private System.Windows.Forms.Button deleteRow;
        private System.Windows.Forms.Label labelEditData;
        private System.Windows.Forms.TextBox textboxAssetTag;
        private System.Windows.Forms.Label labelAssetTag;
        private System.Windows.Forms.TextBox textBoxSerialNo;
        private System.Windows.Forms.Label labelSerialNo;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelAfterRow;
        private System.Windows.Forms.Label labelBeforeRow;
        private System.Windows.Forms.TextBox textBoxBeforeRow;
        private System.Windows.Forms.TextBox textBoxAfter;
    }
}