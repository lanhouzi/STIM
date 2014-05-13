namespace STIM.WinFormUI
{
    partial class FrmDetailView
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
            this.grpAction = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.grpAction.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.btnSave);
            this.grpAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpAction.Location = new System.Drawing.Point(0, 361);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(734, 100);
            this.grpAction.TabIndex = 0;
            this.grpAction.TabStop = false;
            this.grpAction.Text = "操作区域";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(35, 21);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // grpData
            // 
            this.grpData.AutoSize = true;
            this.grpData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpData.Location = new System.Drawing.Point(0, 0);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(734, 361);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            this.grpData.Text = "数据表单";
            // 
            // FrmDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpAction);
            this.Name = "FrmDetailView";
            this.Text = "FrmDetailView";
            this.Load += new System.EventHandler(this.FrmDetailView_Load);
            this.grpAction.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.Button btnSave;
    }
}