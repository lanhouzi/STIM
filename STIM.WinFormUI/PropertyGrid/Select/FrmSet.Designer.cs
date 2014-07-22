namespace STIM.WinFormUI.PropertyGrid.Select
{
    partial class FrmSet
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
            this.groupBoxEx3 = new ORG.UILib.Controls.GroupBoxEx(this.components);
            this.lblColumnNum = new ORG.UILib.Controls.LabelEx(this.components);
            this.llblColumnAdd = new ORG.UILib.Controls.LinkLabelEx(this.components);
            this.panelColumn = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxEx2 = new ORG.UILib.Controls.GroupBoxEx(this.components);
            this.lblParamNum = new ORG.UILib.Controls.LabelEx(this.components);
            this.panelParam = new System.Windows.Forms.FlowLayoutPanel();
            this.llblParamAdd = new ORG.UILib.Controls.LinkLabelEx(this.components);
            this.groupBoxEx1 = new ORG.UILib.Controls.GroupBoxEx(this.components);
            this.txtSql = new System.Windows.Forms.RichTextBox();
            this.btnSubmit = new ORG.UILib.Controls.ButtonEx(this.components);
            this.labelEx1 = new ORG.UILib.Controls.LabelEx(this.components);
            this.txtName = new ORG.UILib.Controls.TextBoxEx(this.components);
            this.groupBoxEx3.SuspendLayout();
            this.groupBoxEx2.SuspendLayout();
            this.groupBoxEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxEx3
            // 
            this.groupBoxEx3.Controls.Add(this.lblColumnNum);
            this.groupBoxEx3.Controls.Add(this.llblColumnAdd);
            this.groupBoxEx3.Controls.Add(this.panelColumn);
            this.groupBoxEx3.Location = new System.Drawing.Point(13, 320);
            this.groupBoxEx3.Name = "groupBoxEx3";
            this.groupBoxEx3.Size = new System.Drawing.Size(606, 140);
            this.groupBoxEx3.TabIndex = 10;
            this.groupBoxEx3.TabStop = false;
            this.groupBoxEx3.Text = "返回的列值对应的控件名";
            // 
            // lblColumnNum
            // 
            this.lblColumnNum.AutoSize = true;
            this.lblColumnNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblColumnNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblColumnNum.Location = new System.Drawing.Point(524, 0);
            this.lblColumnNum.Name = "lblColumnNum";
            this.lblColumnNum.Size = new System.Drawing.Size(17, 16);
            this.lblColumnNum.TabIndex = 8;
            this.lblColumnNum.Text = "0";
            // 
            // llblColumnAdd
            // 
            this.llblColumnAdd.AutoSize = true;
            this.llblColumnAdd.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.llblColumnAdd.Location = new System.Drawing.Point(169, 0);
            this.llblColumnAdd.Name = "llblColumnAdd";
            this.llblColumnAdd.Size = new System.Drawing.Size(42, 14);
            this.llblColumnAdd.TabIndex = 7;
            this.llblColumnAdd.TabStop = true;
            this.llblColumnAdd.Text = "添 加";
            this.llblColumnAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblColumnAdd_LinkClicked);
            // 
            // panelColumn
            // 
            this.panelColumn.AutoScroll = true;
            this.panelColumn.Location = new System.Drawing.Point(12, 18);
            this.panelColumn.Name = "panelColumn";
            this.panelColumn.Size = new System.Drawing.Size(581, 118);
            this.panelColumn.TabIndex = 4;
            // 
            // groupBoxEx2
            // 
            this.groupBoxEx2.Controls.Add(this.lblParamNum);
            this.groupBoxEx2.Controls.Add(this.panelParam);
            this.groupBoxEx2.Controls.Add(this.llblParamAdd);
            this.groupBoxEx2.Location = new System.Drawing.Point(12, 173);
            this.groupBoxEx2.Name = "groupBoxEx2";
            this.groupBoxEx2.Size = new System.Drawing.Size(606, 140);
            this.groupBoxEx2.TabIndex = 9;
            this.groupBoxEx2.TabStop = false;
            this.groupBoxEx2.Text = "SQL语句参数";
            // 
            // lblParamNum
            // 
            this.lblParamNum.AutoSize = true;
            this.lblParamNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblParamNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblParamNum.Location = new System.Drawing.Point(525, -2);
            this.lblParamNum.Name = "lblParamNum";
            this.lblParamNum.Size = new System.Drawing.Size(17, 16);
            this.lblParamNum.TabIndex = 7;
            this.lblParamNum.Text = "0";
            // 
            // panelParam
            // 
            this.panelParam.AutoScroll = true;
            this.panelParam.Location = new System.Drawing.Point(13, 17);
            this.panelParam.Name = "panelParam";
            this.panelParam.Size = new System.Drawing.Size(581, 118);
            this.panelParam.TabIndex = 3;
            // 
            // llblParamAdd
            // 
            this.llblParamAdd.AutoSize = true;
            this.llblParamAdd.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.llblParamAdd.Location = new System.Drawing.Point(96, 0);
            this.llblParamAdd.Name = "llblParamAdd";
            this.llblParamAdd.Size = new System.Drawing.Size(42, 14);
            this.llblParamAdd.TabIndex = 6;
            this.llblParamAdd.TabStop = true;
            this.llblParamAdd.Text = "添 加";
            this.llblParamAdd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblParamAdd_LinkClicked);
            // 
            // groupBoxEx1
            // 
            this.groupBoxEx1.Controls.Add(this.txtSql);
            this.groupBoxEx1.Location = new System.Drawing.Point(12, 40);
            this.groupBoxEx1.Name = "groupBoxEx1";
            this.groupBoxEx1.Size = new System.Drawing.Size(606, 127);
            this.groupBoxEx1.TabIndex = 8;
            this.groupBoxEx1.TabStop = false;
            this.groupBoxEx1.Text = "SQL语句";
            // 
            // txtSql
            // 
            this.txtSql.Location = new System.Drawing.Point(13, 20);
            this.txtSql.Name = "txtSql";
            this.txtSql.Size = new System.Drawing.Size(581, 96);
            this.txtSql.TabIndex = 1;
            this.txtSql.Text = "";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(509, 479);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "确 定";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // labelEx1
            // 
            this.labelEx1.AutoSize = true;
            this.labelEx1.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelEx1.ForeColor = System.Drawing.Color.Black;
            this.labelEx1.Location = new System.Drawing.Point(18, 13);
            this.labelEx1.Name = "labelEx1";
            this.labelEx1.Size = new System.Drawing.Size(49, 14);
            this.labelEx1.TabIndex = 11;
            this.labelEx1.Text = "名称：";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(235)))), ((int)(((byte)(205)))));
            this.txtName.Location = new System.Drawing.Point(71, 10);
            this.txtName.Name = "txtName";
            this.txtName.OtherText = null;
            this.txtName.Size = new System.Drawing.Size(227, 21);
            this.txtName.TabIndex = 12;
            // 
            // FrmSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 509);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.labelEx1);
            this.Controls.Add(this.groupBoxEx3);
            this.Controls.Add(this.groupBoxEx2);
            this.Controls.Add(this.groupBoxEx1);
            this.Controls.Add(this.btnSubmit);
            this.Name = "FrmSet";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "控件弹出窗口选值设置";
            this.Load += new System.EventHandler(this.FrmSet_Load);
            this.groupBoxEx3.ResumeLayout(false);
            this.groupBoxEx3.PerformLayout();
            this.groupBoxEx2.ResumeLayout(false);
            this.groupBoxEx2.PerformLayout();
            this.groupBoxEx1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtSql;
        private System.Windows.Forms.FlowLayoutPanel panelParam;
        private ORG.UILib.Controls.ButtonEx btnSubmit;
        private ORG.UILib.Controls.LinkLabelEx llblParamAdd;
        private ORG.UILib.Controls.LinkLabelEx llblColumnAdd;
        private ORG.UILib.Controls.GroupBoxEx groupBoxEx1;
        private ORG.UILib.Controls.GroupBoxEx groupBoxEx2;
        private ORG.UILib.Controls.GroupBoxEx groupBoxEx3;
        private ORG.UILib.Controls.LabelEx lblParamNum;
        private ORG.UILib.Controls.LabelEx lblColumnNum;
        private System.Windows.Forms.FlowLayoutPanel panelColumn;
        private ORG.UILib.Controls.LabelEx labelEx1;
        private ORG.UILib.Controls.TextBoxEx txtName;
    }
}