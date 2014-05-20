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
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.rowChecker = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuModify = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.grpSearch.SuspendLayout();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.Location = new System.Drawing.Point(0, 0);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(734, 100);
            this.grpSearch.TabIndex = 1;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "查询条件";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(13, 71);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grpData
            // 
            this.grpData.Controls.Add(this.dgvData);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpData.Location = new System.Drawing.Point(0, 100);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(734, 361);
            this.grpData.TabIndex = 2;
            this.grpData.TabStop = false;
            this.grpData.Text = "数据列表";
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.AllowUserToOrderColumns = true;
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowChecker});
            this.dgvData.ContextMenuStrip = this.contextMenuStrip;
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 17);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 30;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(728, 341);
            this.dgvData.TabIndex = 0;
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
            // FrmDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpSearch);
            this.Name = "FrmDataView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDataView";
            this.Load += new System.EventHandler(this.FrmDataView_Load);
            this.grpSearch.ResumeLayout(false);
            this.grpData.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem tsMenuAdd;
        private System.Windows.Forms.ToolStripMenuItem tsMenuModify;
        private System.Windows.Forms.ToolStripMenuItem tsMenuDelete;
        private System.Windows.Forms.ToolStripSeparator tsSeparator;
        private System.Windows.Forms.ToolStripMenuItem tsMenuRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rowChecker;
    }
}