namespace STIM.WinFormUI
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageDetail = new System.Windows.Forms.TabPage();
            this.grpRight = new System.Windows.Forms.GroupBox();
            this.propertyGrid1 = new STIM.NativePropGrid.NativePropGrid();
            this.grpLeft = new System.Windows.Forms.GroupBox();
            this.tvSingleTableList = new System.Windows.Forms.TreeView();
            this.grpBottom = new System.Windows.Forms.GroupBox();
            this.rightadjust = new System.Windows.Forms.Button();
            this.leftadjust = new System.Windows.Forms.Button();
            this.buttomadjust = new System.Windows.Forms.Button();
            this.topadjust = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.grpMain.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.grpRight.SuspendLayout();
            this.grpLeft.SuspendLayout();
            this.grpBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpMain.Controls.Add(this.tabMain);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Location = new System.Drawing.Point(140, 0);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(576, 406);
            this.grpMain.TabIndex = 9;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "设计";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPageDetail);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(3, 17);
            this.tabMain.Multiline = true;
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(570, 386);
            this.tabMain.TabIndex = 0;
            // 
            // tabPageDetail
            // 
            this.tabPageDetail.AutoScroll = true;
            this.tabPageDetail.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetail.Name = "tabPageDetail";
            this.tabPageDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetail.Size = new System.Drawing.Size(562, 360);
            this.tabPageDetail.TabIndex = 0;
            this.tabPageDetail.Text = "详细表单布局";
            this.tabPageDetail.UseVisualStyleBackColor = true;
            // 
            // grpRight
            // 
            this.grpRight.Controls.Add(this.propertyGrid1);
            this.grpRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpRight.Location = new System.Drawing.Point(716, 0);
            this.grpRight.Name = "grpRight";
            this.grpRight.Size = new System.Drawing.Size(250, 461);
            this.grpRight.TabIndex = 8;
            this.grpRight.TabStop = false;
            this.grpRight.Text = "属性";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.LineColor = System.Drawing.SystemColors.Control;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 17);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(244, 441);
            this.propertyGrid1.TabIndex = 5;
            // 
            // grpLeft
            // 
            this.grpLeft.Controls.Add(this.tvSingleTableList);
            this.grpLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpLeft.Location = new System.Drawing.Point(0, 0);
            this.grpLeft.Name = "grpLeft";
            this.grpLeft.Size = new System.Drawing.Size(140, 461);
            this.grpLeft.TabIndex = 7;
            this.grpLeft.TabStop = false;
            this.grpLeft.Text = "表信息";
            // 
            // tvSingleTableList
            // 
            this.tvSingleTableList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvSingleTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSingleTableList.Location = new System.Drawing.Point(3, 17);
            this.tvSingleTableList.Name = "tvSingleTableList";
            this.tvSingleTableList.Size = new System.Drawing.Size(134, 441);
            this.tvSingleTableList.TabIndex = 0;
            this.tvSingleTableList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSingleTableList_AfterSelect);
            // 
            // grpBottom
            // 
            this.grpBottom.Controls.Add(this.rightadjust);
            this.grpBottom.Controls.Add(this.leftadjust);
            this.grpBottom.Controls.Add(this.buttomadjust);
            this.grpBottom.Controls.Add(this.topadjust);
            this.grpBottom.Controls.Add(this.btnPreview);
            this.grpBottom.Controls.Add(this.btnSaveConfig);
            this.grpBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpBottom.Location = new System.Drawing.Point(140, 406);
            this.grpBottom.Name = "grpBottom";
            this.grpBottom.Size = new System.Drawing.Size(576, 55);
            this.grpBottom.TabIndex = 9;
            this.grpBottom.TabStop = false;
            this.grpBottom.Text = "操作区域";
            // 
            // rightadjust
            // 
            this.rightadjust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rightadjust.Location = new System.Drawing.Point(513, 19);
            this.rightadjust.Name = "rightadjust";
            this.rightadjust.Size = new System.Drawing.Size(49, 23);
            this.rightadjust.TabIndex = 6;
            this.rightadjust.Text = "右对齐";
            this.rightadjust.UseVisualStyleBackColor = true;
            this.rightadjust.Click += new System.EventHandler(this.rightadjust_Click);
            // 
            // leftadjust
            // 
            this.leftadjust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.leftadjust.Location = new System.Drawing.Point(453, 19);
            this.leftadjust.Name = "leftadjust";
            this.leftadjust.Size = new System.Drawing.Size(49, 23);
            this.leftadjust.TabIndex = 5;
            this.leftadjust.Text = "左对齐";
            this.leftadjust.UseVisualStyleBackColor = true;
            this.leftadjust.Click += new System.EventHandler(this.leftadjust_Click);
            // 
            // buttomadjust
            // 
            this.buttomadjust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttomadjust.Location = new System.Drawing.Point(396, 19);
            this.buttomadjust.Name = "buttomadjust";
            this.buttomadjust.Size = new System.Drawing.Size(49, 23);
            this.buttomadjust.TabIndex = 4;
            this.buttomadjust.Text = "下对齐";
            this.buttomadjust.UseVisualStyleBackColor = true;
            this.buttomadjust.Click += new System.EventHandler(this.buttomadjust_Click);
            // 
            // topadjust
            // 
            this.topadjust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.topadjust.Location = new System.Drawing.Point(336, 19);
            this.topadjust.Name = "topadjust";
            this.topadjust.Size = new System.Drawing.Size(49, 23);
            this.topadjust.TabIndex = 3;
            this.topadjust.Text = "上对齐";
            this.topadjust.UseVisualStyleBackColor = true;
            this.topadjust.Click += new System.EventHandler(this.topadjust_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(199, 19);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "预览";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(97, 19);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(75, 23);
            this.btnSaveConfig.TabIndex = 0;
            this.btnSaveConfig.Text = "保存配置";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 461);
            this.Controls.Add(this.grpMain);
            this.Controls.Add(this.grpBottom);
            this.Controls.Add(this.grpRight);
            this.Controls.Add(this.grpLeft);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.grpMain.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.grpRight.ResumeLayout(false);
            this.grpLeft.ResumeLayout(false);
            this.grpBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.GroupBox grpRight;
        private STIM.NativePropGrid.NativePropGrid propertyGrid1;
        private System.Windows.Forms.GroupBox grpLeft;
        private System.Windows.Forms.TreeView tvSingleTableList;
        private System.Windows.Forms.GroupBox grpBottom;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageDetail;
        private System.Windows.Forms.Button topadjust;
        private System.Windows.Forms.Button buttomadjust;
        private System.Windows.Forms.Button leftadjust;
        private System.Windows.Forms.Button rightadjust;

    }
}