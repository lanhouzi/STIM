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
            this.grpData = new System.Windows.Forms.GroupBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuModify = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsMenuRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.rowCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.grpData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSearch
            // 
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.Location = new System.Drawing.Point(0, 0);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(734, 100);
            this.grpSearch.TabIndex = 1;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "查询条件";
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
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowCheck});
            this.dgvData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData.Location = new System.Drawing.Point(3, 17);
            this.dgvData.Name = "dgvData";
            this.dgvData.RowHeadersWidth = 30;
            this.dgvData.RowTemplate.Height = 23;
            this.dgvData.Size = new System.Drawing.Size(728, 341);
            this.dgvData.TabIndex = 0;
            this.dgvData.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvData_CellDoubleClick);
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
            // 
            // tsMenuModify
            // 
            this.tsMenuModify.Name = "tsMenuModify";
            this.tsMenuModify.Size = new System.Drawing.Size(100, 22);
            this.tsMenuModify.Text = "修改";
            // 
            // tsMenuDelete
            // 
            this.tsMenuDelete.Name = "tsMenuDelete";
            this.tsMenuDelete.Size = new System.Drawing.Size(100, 22);
            this.tsMenuDelete.Text = "删除";
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
            // 
            // rowCheck
            // 
            this.rowCheck.Frozen = true;
            this.rowCheck.HeaderText = "";
            this.rowCheck.MinimumWidth = 30;
            this.rowCheck.Name = "rowCheck";
            this.rowCheck.Width = 30;
            // 
            // FrmDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grpSearch);
            this.Name = "FrmDataView";
            this.Text = "FrmDataView";
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
        private System.Windows.Forms.DataGridViewCheckBoxColumn rowCheck;
    }
}