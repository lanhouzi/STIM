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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageDetail = new System.Windows.Forms.TabPage();
            this.tabPageSearch = new System.Windows.Forms.TabPage();
            this.tabPageDataGridView = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpRight = new System.Windows.Forms.GroupBox();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.grpLeft = new System.Windows.Forms.GroupBox();
            this.tvSingleTableList = new System.Windows.Forms.TreeView();
            this.grpBottom = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnCustomLayout = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.statusStrip.SuspendLayout();
            this.grpMain.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPageDataGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpRight.SuspendLayout();
            this.grpLeft.SuspendLayout();
            this.grpBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripProgressBar1});
            this.statusStrip.Location = new System.Drawing.Point(0, 439);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(734, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // grpMain
            // 
            this.grpMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpMain.Controls.Add(this.tabMain);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Location = new System.Drawing.Point(200, 0);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(334, 358);
            this.grpMain.TabIndex = 9;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "展示效果";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPageDetail);
            this.tabMain.Controls.Add(this.tabPageSearch);
            this.tabMain.Controls.Add(this.tabPageDataGridView);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(3, 17);
            this.tabMain.Multiline = true;
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(328, 338);
            this.tabMain.TabIndex = 0;
            // 
            // tabPageDetail
            // 
            this.tabPageDetail.AutoScroll = true;
            this.tabPageDetail.Location = new System.Drawing.Point(4, 22);
            this.tabPageDetail.Name = "tabPageDetail";
            this.tabPageDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDetail.Size = new System.Drawing.Size(320, 312);
            this.tabPageDetail.TabIndex = 0;
            this.tabPageDetail.Text = "详细表单布局";
            this.tabPageDetail.UseVisualStyleBackColor = true;
            // 
            // tabPageSearch
            // 
            this.tabPageSearch.Location = new System.Drawing.Point(4, 22);
            this.tabPageSearch.Name = "tabPageSearch";
            this.tabPageSearch.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSearch.Size = new System.Drawing.Size(320, 312);
            this.tabPageSearch.TabIndex = 1;
            this.tabPageSearch.Text = "查询表单布局";
            this.tabPageSearch.UseVisualStyleBackColor = true;
            // 
            // tabPageDataGridView
            // 
            this.tabPageDataGridView.Controls.Add(this.dataGridView1);
            this.tabPageDataGridView.Location = new System.Drawing.Point(4, 22);
            this.tabPageDataGridView.Name = "tabPageDataGridView";
            this.tabPageDataGridView.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDataGridView.Size = new System.Drawing.Size(320, 312);
            this.tabPageDataGridView.TabIndex = 2;
            this.tabPageDataGridView.Text = "DataGridView布局";
            this.tabPageDataGridView.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(314, 306);
            this.dataGridView1.TabIndex = 0;
            // 
            // grpRight
            // 
            this.grpRight.Controls.Add(this.propertyGrid1);
            this.grpRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.grpRight.Location = new System.Drawing.Point(534, 0);
            this.grpRight.Name = "grpRight";
            this.grpRight.Size = new System.Drawing.Size(200, 439);
            this.grpRight.TabIndex = 8;
            this.grpRight.TabStop = false;
            this.grpRight.Text = "属性";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 17);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(194, 419);
            this.propertyGrid1.TabIndex = 5;
            // 
            // grpLeft
            // 
            this.grpLeft.Controls.Add(this.tvSingleTableList);
            this.grpLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpLeft.Location = new System.Drawing.Point(0, 0);
            this.grpLeft.Name = "grpLeft";
            this.grpLeft.Size = new System.Drawing.Size(200, 439);
            this.grpLeft.TabIndex = 7;
            this.grpLeft.TabStop = false;
            this.grpLeft.Text = "信息表";
            // 
            // tvSingleTableList
            // 
            this.tvSingleTableList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvSingleTableList.Location = new System.Drawing.Point(3, 17);
            this.tvSingleTableList.Name = "tvSingleTableList";
            this.tvSingleTableList.Size = new System.Drawing.Size(194, 419);
            this.tvSingleTableList.TabIndex = 0;
            this.tvSingleTableList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSingleTableList_AfterSelect);
            // 
            // grpBottom
            // 
            this.grpBottom.Controls.Add(this.button6);
            this.grpBottom.Controls.Add(this.button5);
            this.grpBottom.Controls.Add(this.button4);
            this.grpBottom.Controls.Add(this.button3);
            this.grpBottom.Controls.Add(this.btnSaveConfig);
            this.grpBottom.Controls.Add(this.btnCustomLayout);
            this.grpBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpBottom.Location = new System.Drawing.Point(200, 358);
            this.grpBottom.Name = "grpBottom";
            this.grpBottom.Size = new System.Drawing.Size(334, 81);
            this.grpBottom.TabIndex = 9;
            this.grpBottom.TabStop = false;
            this.grpBottom.Text = "操作区";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(188, 49);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 0;
            this.button6.Text = "button1";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(107, 49);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "button1";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(26, 49);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "button1";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(188, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 0;
            this.button3.Text = "button1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(107, 20);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(75, 23);
            this.btnSaveConfig.TabIndex = 0;
            this.btnSaveConfig.Text = "保存配置";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // btnCustomLayout
            // 
            this.btnCustomLayout.Location = new System.Drawing.Point(26, 20);
            this.btnCustomLayout.Name = "btnCustomLayout";
            this.btnCustomLayout.Size = new System.Drawing.Size(75, 23);
            this.btnCustomLayout.TabIndex = 0;
            this.btnCustomLayout.Text = "自定义布局";
            this.btnCustomLayout.UseVisualStyleBackColor = true;
            this.btnCustomLayout.Click += new System.EventHandler(this.btnCustomLayout_Click);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(386, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(300, 16);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.grpMain);
            this.Controls.Add(this.grpBottom);
            this.Controls.Add(this.grpRight);
            this.Controls.Add(this.grpLeft);
            this.Controls.Add(this.statusStrip);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.grpMain.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabPageDataGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpRight.ResumeLayout(false);
            this.grpLeft.ResumeLayout(false);
            this.grpBottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.GroupBox grpRight;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.GroupBox grpLeft;
        private System.Windows.Forms.TreeView tvSingleTableList;
        private System.Windows.Forms.GroupBox grpBottom;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnCustomLayout;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageDetail;
        private System.Windows.Forms.TabPage tabPageSearch;
        private System.Windows.Forms.TabPage tabPageDataGridView;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;

    }
}