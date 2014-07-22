namespace STIM.WinFormUI.PropertyGrid.Select
{
    partial class FrmShow
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
            this.FLPannel = new System.Windows.Forms.FlowLayoutPanel();
            this.DGVList = new ORG.UILib.Controls.DataGridViewEx(this.components);
            this.panelEx1 = new ORG.UILib.Controls.PanelEx(this.components);
            this.btnSearch = new ORG.UILib.Controls.ButtonEx(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DGVList)).BeginInit();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // FLPannel
            // 
            this.FLPannel.AutoSize = true;
            this.FLPannel.Dock = System.Windows.Forms.DockStyle.Top;
            this.FLPannel.Location = new System.Drawing.Point(0, 0);
            this.FLPannel.Name = "FLPannel";
            this.FLPannel.Padding = new System.Windows.Forms.Padding(10);
            this.FLPannel.Size = new System.Drawing.Size(708, 20);
            this.FLPannel.TabIndex = 0;
            // 
            // DGVList
            // 
            this.DGVList.ColumnDisplayIndexSave = false;
            this.DGVList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DGVList.ColumnVisibleEnableSave = true;
            this.DGVList.ColumnWidthSave = true;
            this.DGVList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGVList.Location = new System.Drawing.Point(0, 49);
            this.DGVList.MultiSelect = false;
            this.DGVList.MyForm = this;
            this.DGVList.Name = "DGVList";
            this.DGVList.RowTemplate.Height = 23;
            this.DGVList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGVList.ShowdgvTotalRow = false;
            this.DGVList.ShowTotal = 0;
            this.DGVList.Size = new System.Drawing.Size(708, 324);
            this.DGVList.SumColumnList = new string[] {
        ""};
            this.DGVList.SumField = "";
            this.DGVList.TabIndex = 2;
            this.DGVList.UserName = "SystemUserName";
            this.DGVList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGVList_CellContentDoubleClick);
            // 
            // panelEx1
            // 
            this.panelEx1.Controls.Add(this.btnSearch);
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 20);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(708, 29);
            this.panelEx1.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(551, 1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查 询";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // FrmShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 373);
            this.Controls.Add(this.DGVList);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.FLPannel);
            this.Name = "FrmShow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmShow";
            this.Load += new System.EventHandler(this.FrmShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGVList)).EndInit();
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel FLPannel;
        private ORG.UILib.Controls.DataGridViewEx DGVList;
        private ORG.UILib.Controls.PanelEx panelEx1;
        private ORG.UILib.Controls.ButtonEx btnSearch;
    }
}