namespace STIM.WinFormUI.PropertyGrid
{
    partial class FrmDataSource
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.labelEx1 = new ORG.UILib.Controls.LabelEx(this.components);
            this.BtnSubmit = new ORG.UILib.Controls.ButtonEx(this.components);
            this.labelEx2 = new ORG.UILib.Controls.LabelEx(this.components);
            this.labelEx3 = new ORG.UILib.Controls.LabelEx(this.components);
            this.txtKey = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.txtValue = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.btnAdd = new ORG.UILib.Controls.ButtonEx(this.components);
            this.DataGridTxtVal = new System.Windows.Forms.DataGridView();
            this.val = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGVcontextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridTxtVal)).BeginInit();
            this.DGVcontextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelEx1
            // 
            this.labelEx1.AutoSize = true;
            this.labelEx1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx1.ForeColor = System.Drawing.Color.Black;
            this.labelEx1.Location = new System.Drawing.Point(13, 11);
            this.labelEx1.Name = "labelEx1";
            this.labelEx1.Size = new System.Drawing.Size(133, 14);
            this.labelEx1.TabIndex = 2;
            this.labelEx1.Text = "键值对形式的数据源";
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.Location = new System.Drawing.Point(315, 252);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(75, 23);
            this.BtnSubmit.TabIndex = 1;
            this.BtnSubmit.Text = "确 定";
            this.BtnSubmit.UseVisualStyleBackColor = false;
            this.BtnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // labelEx2
            // 
            this.labelEx2.AutoSize = true;
            this.labelEx2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx2.ForeColor = System.Drawing.Color.Black;
            this.labelEx2.Location = new System.Drawing.Point(16, 40);
            this.labelEx2.Name = "labelEx2";
            this.labelEx2.Size = new System.Drawing.Size(35, 14);
            this.labelEx2.TabIndex = 3;
            this.labelEx2.Text = "键：";
            // 
            // labelEx3
            // 
            this.labelEx3.AutoSize = true;
            this.labelEx3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx3.ForeColor = System.Drawing.Color.Black;
            this.labelEx3.Location = new System.Drawing.Point(184, 40);
            this.labelEx3.Name = "labelEx3";
            this.labelEx3.Size = new System.Drawing.Size(35, 14);
            this.labelEx3.TabIndex = 4;
            this.labelEx3.Text = "值：";
            // 
            // txtKey
            // 
            this.txtKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(205)))));
            this.txtKey.Location = new System.Drawing.Point(48, 37);
            this.txtKey.Name = "txtKey";
            this.txtKey.OtherText = null;
            this.txtKey.Size = new System.Drawing.Size(100, 21);
            this.txtKey.TabIndex = 5;
            // 
            // txtValue
            // 
            this.txtValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(205)))));
            this.txtValue.Location = new System.Drawing.Point(223, 37);
            this.txtValue.Name = "txtValue";
            this.txtValue.OtherText = null;
            this.txtValue.Size = new System.Drawing.Size(100, 21);
            this.txtValue.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(356, 36);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "添 加";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // DataGridTxtVal
            // 
            this.DataGridTxtVal.AllowUserToAddRows = false;
            this.DataGridTxtVal.AllowUserToResizeColumns = false;
            this.DataGridTxtVal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridTxtVal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridTxtVal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridTxtVal.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.val,
            this.txt});
            this.DataGridTxtVal.ContextMenuStrip = this.DGVcontextMenu;
            this.DataGridTxtVal.Location = new System.Drawing.Point(12, 76);
            this.DataGridTxtVal.MultiSelect = false;
            this.DataGridTxtVal.Name = "DataGridTxtVal";
            this.DataGridTxtVal.ReadOnly = true;
            this.DataGridTxtVal.RowHeadersVisible = false;
            this.DataGridTxtVal.RowTemplate.Height = 23;
            this.DataGridTxtVal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridTxtVal.Size = new System.Drawing.Size(425, 167);
            this.DataGridTxtVal.TabIndex = 9;
            // 
            // val
            // 
            this.val.DataPropertyName = "val";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.val.DefaultCellStyle = dataGridViewCellStyle2;
            this.val.HeaderText = "键";
            this.val.Name = "val";
            this.val.ReadOnly = true;
            // 
            // txt
            // 
            this.txt.DataPropertyName = "txt";
            this.txt.HeaderText = "值";
            this.txt.Name = "txt";
            this.txt.ReadOnly = true;
            // 
            // DGVcontextMenu
            // 
            this.DGVcontextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteToolStripMenuItem});
            this.DGVcontextMenu.Name = "DGVcontextMenu";
            this.DGVcontextMenu.Size = new System.Drawing.Size(105, 26);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.DeleteToolStripMenuItem.Text = "删 除";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // FrmDataSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 286);
            this.Controls.Add(this.DataGridTxtVal);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.labelEx3);
            this.Controls.Add(this.labelEx2);
            this.Controls.Add(this.labelEx1);
            this.Controls.Add(this.BtnSubmit);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDataSource";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据源";
            this.Load += new System.EventHandler(this.FrmDataSource_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridTxtVal)).EndInit();
            this.DGVcontextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ORG.UILib.Controls.ButtonEx BtnSubmit;
        private ORG.UILib.Controls.LabelEx labelEx1;
        private ORG.UILib.Controls.LabelEx labelEx2;
        private ORG.UILib.Controls.LabelEx labelEx3;
        private ORG.UILib.Controls.TextBoxEx txtKey;
        private ORG.UILib.Controls.TextBoxEx txtValue;
        private ORG.UILib.Controls.ButtonEx btnAdd;
        private System.Windows.Forms.DataGridView DataGridTxtVal;
        private System.Windows.Forms.ContextMenuStrip DGVcontextMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn val;
        private System.Windows.Forms.DataGridViewTextBoxColumn txt;
    }
}