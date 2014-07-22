namespace STIM.WinFormUI.PropertyGrid
{
    partial class FrmValue
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
            this.RadioTxt = new ORG.UILib.Controls.RadioButtonEx(this.components);
            this.RadioApp = new ORG.UILib.Controls.RadioButtonEx(this.components);
            this.RadioSQL = new ORG.UILib.Controls.RadioButtonEx(this.components);
            this.txtValue = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.panelTxt = new ORG.UILib.Controls.PanelEx(this.components);
            this.labelEx1 = new ORG.UILib.Controls.LabelEx(this.components);
            this.panelCbb = new ORG.UILib.Controls.PanelEx(this.components);
            this.CBBApp = new ORG.UILib.Controls.ComboBoxEx(this.components);
            this.labelEx2 = new ORG.UILib.Controls.LabelEx(this.components);
            this.panelSql = new ORG.UILib.Controls.PanelEx(this.components);
            this.txtSql = new System.Windows.Forms.RichTextBox();
            this.labelEx3 = new ORG.UILib.Controls.LabelEx(this.components);
            this.btnSubmit = new ORG.UILib.Controls.ButtonEx(this.components);
            this.panelTxt.SuspendLayout();
            this.panelCbb.SuspendLayout();
            this.panelSql.SuspendLayout();
            this.SuspendLayout();
            // 
            // RadioTxt
            // 
            this.RadioTxt.AutoSize = true;
            this.RadioTxt.Checked = true;
            this.RadioTxt.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RadioTxt.Location = new System.Drawing.Point(23, 13);
            this.RadioTxt.Name = "RadioTxt";
            this.RadioTxt.Size = new System.Drawing.Size(81, 18);
            this.RadioTxt.TabIndex = 0;
            this.RadioTxt.TabStop = true;
            this.RadioTxt.Text = "默认文本";
            this.RadioTxt.UseVisualStyleBackColor = true;
            // 
            // RadioApp
            // 
            this.RadioApp.AutoSize = true;
            this.RadioApp.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RadioApp.Location = new System.Drawing.Point(123, 13);
            this.RadioApp.Name = "RadioApp";
            this.RadioApp.Size = new System.Drawing.Size(109, 18);
            this.RadioApp.TabIndex = 1;
            this.RadioApp.Text = "系统变量的值";
            this.RadioApp.UseVisualStyleBackColor = true;
            // 
            // RadioSQL
            // 
            this.RadioSQL.AutoSize = true;
            this.RadioSQL.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RadioSQL.Location = new System.Drawing.Point(257, 13);
            this.RadioSQL.Name = "RadioSQL";
            this.RadioSQL.Size = new System.Drawing.Size(116, 18);
            this.RadioSQL.TabIndex = 2;
            this.RadioSQL.Text = "SQL语句获取值";
            this.RadioSQL.UseVisualStyleBackColor = true;
            // 
            // txtValue
            // 
            this.txtValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(205)))));
            this.txtValue.Location = new System.Drawing.Point(98, 14);
            this.txtValue.Name = "txtValue";
            this.txtValue.OtherText = null;
            this.txtValue.Size = new System.Drawing.Size(177, 21);
            this.txtValue.TabIndex = 3;
            // 
            // panelTxt
            // 
            this.panelTxt.Controls.Add(this.labelEx1);
            this.panelTxt.Controls.Add(this.txtValue);
            this.panelTxt.Location = new System.Drawing.Point(23, 51);
            this.panelTxt.Name = "panelTxt";
            this.panelTxt.Size = new System.Drawing.Size(366, 49);
            this.panelTxt.TabIndex = 4;
            // 
            // labelEx1
            // 
            this.labelEx1.AutoSize = true;
            this.labelEx1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx1.ForeColor = System.Drawing.Color.Black;
            this.labelEx1.Location = new System.Drawing.Point(18, 17);
            this.labelEx1.Name = "labelEx1";
            this.labelEx1.Size = new System.Drawing.Size(70, 14);
            this.labelEx1.TabIndex = 4;
            this.labelEx1.Text = "文本内容:";
            // 
            // panelCbb
            // 
            this.panelCbb.Controls.Add(this.CBBApp);
            this.panelCbb.Controls.Add(this.labelEx2);
            this.panelCbb.Location = new System.Drawing.Point(23, 51);
            this.panelCbb.Name = "panelCbb";
            this.panelCbb.Size = new System.Drawing.Size(366, 49);
            this.panelCbb.TabIndex = 5;
            this.panelCbb.Visible = false;
            // 
            // CBBApp
            // 
            this.CBBApp.FormattingEnabled = true;
            this.CBBApp.Location = new System.Drawing.Point(98, 10);
            this.CBBApp.Name = "CBBApp";
            this.CBBApp.Size = new System.Drawing.Size(177, 20);
            this.CBBApp.TabIndex = 5;
            // 
            // labelEx2
            // 
            this.labelEx2.AutoSize = true;
            this.labelEx2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx2.ForeColor = System.Drawing.Color.Black;
            this.labelEx2.Location = new System.Drawing.Point(18, 13);
            this.labelEx2.Name = "labelEx2";
            this.labelEx2.Size = new System.Drawing.Size(70, 14);
            this.labelEx2.TabIndex = 4;
            this.labelEx2.Text = "系统变量:";
            // 
            // panelSql
            // 
            this.panelSql.Controls.Add(this.txtSql);
            this.panelSql.Controls.Add(this.labelEx3);
            this.panelSql.Location = new System.Drawing.Point(23, 52);
            this.panelSql.Name = "panelSql";
            this.panelSql.Size = new System.Drawing.Size(366, 176);
            this.panelSql.TabIndex = 6;
            this.panelSql.Visible = false;
            // 
            // txtSql
            // 
            this.txtSql.Location = new System.Drawing.Point(21, 31);
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(329, 133);
            this.txtSql.TabIndex = 5;
            this.txtSql.Text = "";
            // 
            // labelEx3
            // 
            this.labelEx3.AutoSize = true;
            this.labelEx3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx3.ForeColor = System.Drawing.Color.Black;
            this.labelEx3.Location = new System.Drawing.Point(18, 8);
            this.labelEx3.Name = "labelEx3";
            this.labelEx3.Size = new System.Drawing.Size(63, 14);
            this.labelEx3.TabIndex = 4;
            this.labelEx3.Text = "SQL文本:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(300, 243);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "确 定";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // FrmValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 288);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.panelSql);
            this.Controls.Add(this.panelCbb);
            this.Controls.Add(this.panelTxt);
            this.Controls.Add(this.RadioSQL);
            this.Controls.Add(this.RadioApp);
            this.Controls.Add(this.RadioTxt);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmValue";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "默认值编辑";
            this.Load += new System.EventHandler(this.FrmValue_Load);
            this.panelTxt.ResumeLayout(false);
            this.panelTxt.PerformLayout();
            this.panelCbb.ResumeLayout(false);
            this.panelCbb.PerformLayout();
            this.panelSql.ResumeLayout(false);
            this.panelSql.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ORG.UILib.Controls.RadioButtonEx RadioTxt;
        private ORG.UILib.Controls.RadioButtonEx RadioApp;
        private ORG.UILib.Controls.RadioButtonEx RadioSQL;
        private ORG.UILib.Controls.TextBoxEx txtValue;
        private ORG.UILib.Controls.PanelEx panelTxt;
        private ORG.UILib.Controls.LabelEx labelEx1;
        private ORG.UILib.Controls.PanelEx panelCbb;
        private ORG.UILib.Controls.LabelEx labelEx2;
        private ORG.UILib.Controls.PanelEx panelSql;
        private ORG.UILib.Controls.LabelEx labelEx3;
        private ORG.UILib.Controls.ComboBoxEx CBBApp;
        private System.Windows.Forms.RichTextBox txtSql;
        private ORG.UILib.Controls.ButtonEx btnSubmit;
    }
}