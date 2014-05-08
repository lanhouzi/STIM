namespace STIM.WinFormUI.ExtControl
{
    partial class StimWfDateTimePicker
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFile = new System.Windows.Forms.Label();
            this.TLP = new System.Windows.Forms.TableLayoutPanel();
            this.dataFile = new System.Windows.Forms.DateTimePicker();
            this.TLP.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFile
            // 
            this.lblFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFile.AutoEllipsis = true;
            this.lblFile.Location = new System.Drawing.Point(4, 4);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(85, 21);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "FileName：";
            this.lblFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TLP
            // 
            this.TLP.AutoSize = true;
            this.TLP.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.TLP.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.TLP.ColumnCount = 2;
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLP.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TLP.Controls.Add(this.lblFile, 0, 0);
            this.TLP.Controls.Add(this.dataFile, 1, 0);
            this.TLP.Location = new System.Drawing.Point(0, 0);
            this.TLP.Margin = new System.Windows.Forms.Padding(0);
            this.TLP.Name = "TLP";
            this.TLP.RowCount = 1;
            this.TLP.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TLP.Size = new System.Drawing.Size(250, 29);
            this.TLP.TabIndex = 2;
            // 
            // dataFile
            // 
            this.dataFile.Location = new System.Drawing.Point(96, 4);
            this.dataFile.Name = "dataFile";
            this.dataFile.Size = new System.Drawing.Size(150, 21);
            this.dataFile.TabIndex = 0;
            // 
            // StimWfDateTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.TLP);
            this.Name = "StimWfDateTimePicker";
            this.Size = new System.Drawing.Size(250, 29);
            this.TLP.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TableLayoutPanel TLP;
        public System.Windows.Forms.Label lblFile;
        public System.Windows.Forms.DateTimePicker dataFile;



    }
}
