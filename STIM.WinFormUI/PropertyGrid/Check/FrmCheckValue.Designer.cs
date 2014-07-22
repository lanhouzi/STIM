namespace STIM.WinFormUI.PropertyGrid
{
    partial class FrmCheckValue
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
            this.panelSql = new ORG.UILib.Controls.PanelEx(this.components);
            this.lblInf = new ORG.UILib.Controls.LabelEx(this.components);
            this.labelEx4 = new ORG.UILib.Controls.LabelEx(this.components);
            this.txtSql = new System.Windows.Forms.RichTextBox();
            this.labelEx3 = new ORG.UILib.Controls.LabelEx(this.components);
            this.panelRegular = new ORG.UILib.Controls.PanelEx(this.components);
            this.txtRegular = new System.Windows.Forms.RichTextBox();
            this.labelEx2 = new ORG.UILib.Controls.LabelEx(this.components);
            this.panelApp = new ORG.UILib.Controls.PanelEx(this.components);
            this.CBBApp = new ORG.UILib.Controls.ComboBoxEx(this.components);
            this.labelEx1 = new ORG.UILib.Controls.LabelEx(this.components);
            this.RadioSQL = new ORG.UILib.Controls.RadioButtonEx(this.components);
            this.RadioRegular = new ORG.UILib.Controls.RadioButtonEx(this.components);
            this.RadioApp = new ORG.UILib.Controls.RadioButtonEx(this.components);
            this.btnSubmit = new ORG.UILib.Controls.ButtonEx(this.components);
            this.panelInf = new ORG.UILib.Controls.PanelEx(this.components);
            this.labelEx5 = new ORG.UILib.Controls.LabelEx(this.components);
            this.panelSql.SuspendLayout();
            this.panelRegular.SuspendLayout();
            this.panelApp.SuspendLayout();
            this.panelInf.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSql
            // 
            this.panelSql.Controls.Add(this.txtSql);
            this.panelSql.Controls.Add(this.labelEx3);
            this.panelSql.Location = new System.Drawing.Point(29, 38);
            this.panelSql.Name = "panelSql";
            this.panelSql.Size = new System.Drawing.Size(375, 155);
            this.panelSql.TabIndex = 8;
            this.panelSql.Visible = false;
            // 
            // lblInf
            // 
            this.lblInf.AutoSize = true;
            this.lblInf.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInf.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblInf.Location = new System.Drawing.Point(15, 36);
            this.lblInf.Name = "lblInf";
            this.lblInf.Size = new System.Drawing.Size(0, 12);
            this.lblInf.TabIndex = 3;
            // 
            // labelEx4
            // 
            this.labelEx4.AutoSize = true;
            this.labelEx4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelEx4.Location = new System.Drawing.Point(9, 20);
            this.labelEx4.Name = "labelEx4";
            this.labelEx4.Size = new System.Drawing.Size(125, 12);
            this.labelEx4.TabIndex = 2;
            this.labelEx4.Text = "可用系统参数及格式：";
            // 
            // txtSql
            // 
            this.txtSql.Location = new System.Drawing.Point(11, 27);
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(356, 116);
            this.txtSql.TabIndex = 1;
            this.txtSql.Text = "";
            // 
            // labelEx3
            // 
            this.labelEx3.AutoSize = true;
            this.labelEx3.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx3.ForeColor = System.Drawing.Color.Black;
            this.labelEx3.Location = new System.Drawing.Point(13, 5);
            this.labelEx3.Name = "labelEx3";
            this.labelEx3.Size = new System.Drawing.Size(56, 14);
            this.labelEx3.TabIndex = 0;
            this.labelEx3.Text = "Sql语句";
            // 
            // panelRegular
            // 
            this.panelRegular.Controls.Add(this.txtRegular);
            this.panelRegular.Controls.Add(this.labelEx2);
            this.panelRegular.Location = new System.Drawing.Point(29, 38);
            this.panelRegular.Name = "panelRegular";
            this.panelRegular.Size = new System.Drawing.Size(375, 155);
            this.panelRegular.TabIndex = 7;
            this.panelRegular.Visible = false;
            // 
            // txtRegular
            // 
            this.txtRegular.Location = new System.Drawing.Point(11, 27);
            this.txtRegular.Name = "txtRegular";
            this.txtRegular.Size = new System.Drawing.Size(356, 116);
            this.txtRegular.TabIndex = 1;
            this.txtRegular.Text = "";
            // 
            // labelEx2
            // 
            this.labelEx2.AutoSize = true;
            this.labelEx2.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx2.ForeColor = System.Drawing.Color.Black;
            this.labelEx2.Location = new System.Drawing.Point(13, 5);
            this.labelEx2.Name = "labelEx2";
            this.labelEx2.Size = new System.Drawing.Size(77, 14);
            this.labelEx2.TabIndex = 0;
            this.labelEx2.Text = "正则表达式";
            // 
            // panelApp
            // 
            this.panelApp.Controls.Add(this.CBBApp);
            this.panelApp.Controls.Add(this.labelEx1);
            this.panelApp.Location = new System.Drawing.Point(29, 38);
            this.panelApp.Name = "panelApp";
            this.panelApp.Size = new System.Drawing.Size(375, 56);
            this.panelApp.TabIndex = 6;
            // 
            // CBBApp
            // 
            this.CBBApp.FormattingEnabled = true;
            this.CBBApp.Location = new System.Drawing.Point(84, 16);
            this.CBBApp.Name = "CBBApp";
            this.CBBApp.Size = new System.Drawing.Size(170, 20);
            this.CBBApp.TabIndex = 1;
            // 
            // labelEx1
            // 
            this.labelEx1.AutoSize = true;
            this.labelEx1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx1.ForeColor = System.Drawing.Color.Black;
            this.labelEx1.Location = new System.Drawing.Point(13, 19);
            this.labelEx1.Name = "labelEx1";
            this.labelEx1.Size = new System.Drawing.Size(63, 14);
            this.labelEx1.TabIndex = 0;
            this.labelEx1.Text = "系统方法";
            // 
            // RadioSQL
            // 
            this.RadioSQL.AutoSize = true;
            this.RadioSQL.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RadioSQL.Location = new System.Drawing.Point(285, 12);
            this.RadioSQL.Name = "RadioSQL";
            this.RadioSQL.Size = new System.Drawing.Size(102, 18);
            this.RadioSQL.TabIndex = 5;
            this.RadioSQL.Text = "SQL语句验证";
            this.RadioSQL.UseVisualStyleBackColor = true;
            // 
            // RadioRegular
            // 
            this.RadioRegular.AutoSize = true;
            this.RadioRegular.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RadioRegular.Location = new System.Drawing.Point(147, 12);
            this.RadioRegular.Name = "RadioRegular";
            this.RadioRegular.Size = new System.Drawing.Size(123, 18);
            this.RadioRegular.TabIndex = 4;
            this.RadioRegular.Text = "正则表达式验证";
            this.RadioRegular.UseVisualStyleBackColor = true;
            // 
            // RadioApp
            // 
            this.RadioApp.AutoSize = true;
            this.RadioApp.Checked = true;
            this.RadioApp.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RadioApp.Location = new System.Drawing.Point(29, 12);
            this.RadioApp.Name = "RadioApp";
            this.RadioApp.Size = new System.Drawing.Size(109, 18);
            this.RadioApp.TabIndex = 3;
            this.RadioApp.TabStop = true;
            this.RadioApp.Text = "系统方法验证";
            this.RadioApp.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(329, 203);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "确 定";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // panelInf
            // 
            this.panelInf.Controls.Add(this.labelEx5);
            this.panelInf.Controls.Add(this.lblInf);
            this.panelInf.Controls.Add(this.labelEx4);
            this.panelInf.Location = new System.Drawing.Point(29, 232);
            this.panelInf.Name = "panelInf";
            this.panelInf.Size = new System.Drawing.Size(375, 185);
            this.panelInf.TabIndex = 9;
            // 
            // labelEx5
            // 
            this.labelEx5.AutoSize = true;
            this.labelEx5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.labelEx5.Location = new System.Drawing.Point(10, 5);
            this.labelEx5.Name = "labelEx5";
            this.labelEx5.Size = new System.Drawing.Size(305, 12);
            this.labelEx5.TabIndex = 4;
            this.labelEx5.Text = "界面的字段作为参数，可用 “:CloumnName名”的形式。";
            // 
            // FrmCheckValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(429, 427);
            this.Controls.Add(this.panelInf);
            this.Controls.Add(this.panelSql);
            this.Controls.Add(this.panelRegular);
            this.Controls.Add(this.panelApp);
            this.Controls.Add(this.RadioSQL);
            this.Controls.Add(this.RadioRegular);
            this.Controls.Add(this.RadioApp);
            this.Controls.Add(this.btnSubmit);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCheckValue";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "验证规则";
            this.Load += new System.EventHandler(this.FrmCheckValue_Load);
            this.panelSql.ResumeLayout(false);
            this.panelSql.PerformLayout();
            this.panelRegular.ResumeLayout(false);
            this.panelRegular.PerformLayout();
            this.panelApp.ResumeLayout(false);
            this.panelApp.PerformLayout();
            this.panelInf.ResumeLayout(false);
            this.panelInf.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ORG.UILib.Controls.ButtonEx btnSubmit;
        private ORG.UILib.Controls.RadioButtonEx RadioSQL;
        private ORG.UILib.Controls.RadioButtonEx RadioRegular;
        private ORG.UILib.Controls.RadioButtonEx RadioApp;
        private ORG.UILib.Controls.PanelEx panelApp;
        private ORG.UILib.Controls.ComboBoxEx CBBApp;
        private ORG.UILib.Controls.LabelEx labelEx1;
        private ORG.UILib.Controls.PanelEx panelRegular;
        private ORG.UILib.Controls.PanelEx panelSql;
        private System.Windows.Forms.RichTextBox txtSql;
        private ORG.UILib.Controls.LabelEx labelEx3;
        private System.Windows.Forms.RichTextBox txtRegular;
        private ORG.UILib.Controls.LabelEx labelEx2;
        private ORG.UILib.Controls.LabelEx labelEx4;
        private ORG.UILib.Controls.LabelEx lblInf;
        private ORG.UILib.Controls.PanelEx panelInf;
        private ORG.UILib.Controls.LabelEx labelEx5;
    }
}