namespace STIM.WinFormUI
{
    partial class FrmDataView
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuModify = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.flpAction = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnModify = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.dgvData = new ORG.UILib.Controls.DataGridViewEx(this.components);
            this.rowChecker = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grpSearch.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.flpAction.SuspendLayout();
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
            this.grpSearch.Size = new System.Drawing.Size(984, 35);
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
            this.GrpflPanelSearch.Size = new System.Drawing.Size(959, 14);
            this.GrpflPanelSearch.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(337, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
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
            // flpAction
            // 
            this.flpAction.Controls.Add(this.btnAdd);
            this.flpAction.Controls.Add(this.btnModify);
            this.flpAction.Controls.Add(this.btnDelete);
            this.flpAction.Controls.Add(this.btnRefresh);
            this.flpAction.Controls.Add(this.btnSearch);
            this.flpAction.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpAction.Location = new System.Drawing.Point(0, 35);
            this.flpAction.Name = "flpAction";
            this.flpAction.Padding = new System.Windows.Forms.Padding(10, 5, 0, 0);
            this.flpAction.Size = new System.Drawing.Size(984, 40);
            this.flpAction.TabIndex = 3;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "新增";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnModify
            // 
            this.btnModify.Location = new System.Drawing.Point(94, 8);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(75, 23);
            this.btnModify.TabIndex = 1;
            this.btnModify.Text = "修改";
            this.btnModify.UseVisualStyleBackColor = true;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(175, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(256, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.dgvData);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpData.Location = new System.Drawing.Point(0, 75);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(984, 487);
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
            this.dgvData.Size = new System.Drawing.Size(978, 467);
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
            // FrmDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.flpAction);
            this.Controls.Add(this.grpSearch);
            this.KeyPreview = true;
            this.Name = "FrmDataView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "列表界面";
            this.Load += new System.EventHandler(this.FrmDataView_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmDataView_KeyPress);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.flpAction.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.FlowLayoutPanel flpAction;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnModify;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.GroupBox grpData;
        private ORG.UILib.Controls.DataGridViewEx dgvData;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rowChecker;
        private System.Windows.Forms.FlowLayoutPanel GrpflPanelSearch;
    }
}