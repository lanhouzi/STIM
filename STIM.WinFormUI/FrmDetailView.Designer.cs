﻿namespace STIM.WinFormUI
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.pnlData = new System.Windows.Forms.Panel();
            this.grpAction.SuspendLayout();
            this.grpData.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAction
            // 
            this.grpAction.Controls.Add(this.btnClose);
            this.grpAction.Controls.Add(this.btnSave);
            this.grpAction.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpAction.Location = new System.Drawing.Point(0, 512);
            this.grpAction.Name = "grpAction";
            this.grpAction.Size = new System.Drawing.Size(884, 50);
            this.grpAction.TabIndex = 0;
            this.grpAction.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(770, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 101;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(670, 17);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 100;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpData
            // 
            this.grpData.AutoSize = true;
            this.grpData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpData.Controls.Add(this.pnlData);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpData.Location = new System.Drawing.Point(0, 0);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(884, 512);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            this.grpData.Text = "数据表单";
            // 
            // pnlData
            // 
            this.pnlData.AutoScroll = true;
            this.pnlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlData.Location = new System.Drawing.Point(3, 17);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(878, 492);
            this.pnlData.TabIndex = 0;
            // 
            // FrmDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 562);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpAction);
            this.KeyPreview = true;
            this.Name = "FrmDetailView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "详细界面预览";
            this.Load += new System.EventHandler(this.FrmDetailView_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmDetailView_KeyPress);
            this.grpAction.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpAction;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel pnlData;
    }
}