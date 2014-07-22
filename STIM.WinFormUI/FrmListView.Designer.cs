namespace STIM.WinFormUI
{
    partial class FrmListView
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
            this.components = new System.ComponentModel.Container();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.GrpflPanelSearch = new System.Windows.Forms.FlowLayoutPanel();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuModify = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.dgvData = new ORG.UILib.Controls.DataGridViewEx(this.components);
            this.rowChecker = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grpSearch.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // grpSearch
            // 
            this.grpSearch.AutoSize = true;
            this.grpSearch.Controls.Add(this.GrpflPanelSearch);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.Location = new System.Drawing.Point(0, 0);
            this.grpSearch.Margin = new System.Windows.Forms.Padding(10);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(984, 20);
            this.grpSearch.TabIndex = 1;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "查询条件";
            // 
            // GrpflPanelSearch
            // 
            this.GrpflPanelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrpflPanelSearch.AutoSize = true;
            this.GrpflPanelSearch.Location = new System.Drawing.Point(13, 15);
            this.GrpflPanelSearch.Name = "GrpflPanelSearch";
            this.GrpflPanelSearch.Size = new System.Drawing.Size(959, 2);
            this.GrpflPanelSearch.TabIndex = 0;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuAdd,
            this.tsMenuModify,
            this.tsMenuDelete,
            this.tsSeparator,
            this.tsMenuRefresh});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(101, 98);
            // 
            // tsMenuAdd
            // 
            this.tsMenuAdd.Name = "tsMenuAdd";
            this.tsMenuAdd.Size = new System.Drawing.Size(100, 22);
            this.tsMenuAdd.Text = "新增";
            this.tsMenuAdd.Click += new System.EventHandler(this.tsMenuAdd_Click);
            // 
            // tsMenuModify
            // 
            this.tsMenuModify.Name = "tsMenuModify";
            this.tsMenuModify.Size = new System.Drawing.Size(100, 22);
            this.tsMenuModify.Text = "修改";
            this.tsMenuModify.Click += new System.EventHandler(this.tsMenuModify_Click);
            // 
            // tsMenuDelete
            // 
            this.tsMenuDelete.Name = "tsMenuDelete";
            this.tsMenuDelete.Size = new System.Drawing.Size(100, 22);
            this.tsMenuDelete.Text = "删除";
            this.tsMenuDelete.Click += new System.EventHandler(this.tsMenuDelete_Click);
            // 
            // tsSeparator
            // 
            this.tsSeparator.Name = "tsSeparator";
            this.tsSeparator.Size = new System.Drawing.Size(97, 6);
            // 
            // tsMenuRefresh
            // 
            this.tsMenuRefresh.Name = "tsMenuRefresh";
            this.tsMenuRefresh.Size = new System.Drawing.Size(100, 22);
            this.tsMenuRefresh.Text = "刷新";
            this.tsMenuRefresh.Click += new System.EventHandler(this.tsMenuRefresh_Click);
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.dgvData);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpData.Location = new System.Drawing.Point(0, 20);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(984, 542);
            this.grpData.TabIndex = 4;
            this.grpData.TabStop = false;
            this.grpData.Text = "数据列表";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.ColumnDisplayIndexSave = false;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowChecker});
            this.dgvData.ColumnVisibleEnableSave = true;
            this.dgvData.ColumnWidthSave = true;
            this.dgvData.ContextMenuStrip = this.contextMenuStrip;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 17);
            this.dgvData.MultiSelect = false;
            this.dgvData.MyForm = this;
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 30;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.ShowdgvTotalRow = false;
            this.dgvData.ShowTotal = 0;
            this.dgvData.Size = new System.Drawing.Size(978, 522);
            this.dgvData.SumColumnList = new string[] {
        ""};
            this.dgvData.SumField = "";
            this.dgvData.TabIndex = 0;
            this.dgvData.UserName = "SystemUserName";
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
            // 
            // rowChecker
            // 
            this.rowChecker.Frozen = true;
            this.rowChecker.HeaderText = "";
            this.rowChecker.MinimumWidth = 30;
            this.rowChecker.Name = "rowChecker";
            this.rowChecker.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.rowChecker.Width = 30;
            // 
            // FrmListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpSearch);
            this.KeyPreview = true;
            this.Name = "FrmListView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "列表界面";
            this.tSMISearch_click += new ORG.UILib.Forms.BaseForm.tSMISearchEventHandler(this.FrmListView_tSMISearch_click);
            this.tSMIAdd_click += new ORG.UILib.Forms.BaseForm.tSMIAddEventHandler(this.FrmListView_tSMIAdd_click);
            this.tSMIUpdate_click += new ORG.UILib.Forms.BaseForm.tSMIUpdateEventHandler(this.FrmListView_tSMIUpdate_click);
            this.tSMIDel_click += new ORG.UILib.Forms.BaseForm.tSMIDelEventHandler(this.FrmListView_tSMIDel_click);
            this.Load += new System.EventHandler(this.FrmDataView_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmDataView_KeyPress);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsMenuAdd;
        private System.Windows.Forms.ToolStripMenuItem tsMenuModify;
        private System.Windows.Forms.ToolStripMenuItem tsMenuDelete;
        private System.Windows.Forms.ToolStripSeparator tsSeparator;
        private System.Windows.Forms.ToolStripMenuItem tsMenuRefresh;
        private System.Windows.Forms.GroupBox grpData;
        private ORG.UILib.Controls.DataGridViewEx dgvData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rowChecker;
        private System.Windows.Forms.FlowLayoutPanel GrpflPanelSearch;
    }
}