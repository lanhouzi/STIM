using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace STIM.WinFormUI.PropertyGrid.Select
{
    public partial class FrmSet : Form
    {
        private int ParamCount = 0;
        private int ColumnCount = 0;
        public ValueObject valueObject = null;

        public FrmSet()
        {
            InitializeComponent();
        }
        public FrmSet(Object _valueObject)
        {
            InitializeComponent();
            this.valueObject = _valueObject as ValueObject;
        }
        private void FrmSet_Load(object sender, EventArgs e)
        {
            if (valueObject!=null)
            {
                txtName.Text = valueObject.Name;
                txtSql.Text = valueObject.ListSql;
                string SearchParam = valueObject.SearchParam;
                string ReturnColumnNames = valueObject.ReturnColumnNames;
                string[] Param=SearchParam.Split('|');
                foreach (string tempParam in Param)
                {
                    string[] temp = tempParam.Split(',');
                    ParamControlAdd(temp[0], temp[1]);
                }

                string[] Column = ReturnColumnNames.Split('|');
                foreach (string tempColumn in Column)
                {
                    string[] temp = tempColumn.Split(',');
                    ColumnControlAdd(temp[0], temp[1]);
                }
            }
        }

        private void llblParamAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ParamControlAdd("","");
        }
        private void ParamControlAdd(string arg0,string arg1)
        {
            int y = ParamCount * 30;
            ORG.UILib.Controls.PanelEx TempPanel = new ORG.UILib.Controls.PanelEx();
            TempPanel.Location = new System.Drawing.Point(10, y);
            TempPanel.Name = "TempPanel_" + ParamCount.ToString();
            TempPanel.Size = new System.Drawing.Size(560, 21);

            ORG.UILib.Controls.LabelEx lbl = new ORG.UILib.Controls.LabelEx();
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(30, 0);
            lbl.Name = "lbl_0";
            lbl.Size = new System.Drawing.Size(53, 12);
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl.Text ="参数名：";
            TempPanel.Controls.Add(lbl);

            ORG.UILib.Controls.TextBoxEx txt = new ORG.UILib.Controls.TextBoxEx();
            txt.Location = new System.Drawing.Point(100, 0);
            txt.Name = "txt_0";
            txt.Text = arg0;
            txt.Size = new System.Drawing.Size(120, 21);
            TempPanel.Controls.Add(txt);

            ORG.UILib.Controls.LabelEx lbl2 = new ORG.UILib.Controls.LabelEx();
            lbl2.AutoSize = true;
            lbl2.Location = new System.Drawing.Point(220, 0);
            lbl2.Name = "lbl_1";
            lbl2.Size = new System.Drawing.Size(53, 12);
            lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl2.Text = "参数标签值：";
            TempPanel.Controls.Add(lbl2);

            ORG.UILib.Controls.TextBoxEx txt2 = new ORG.UILib.Controls.TextBoxEx();
            txt2.Location = new System.Drawing.Point(320, 0);
            txt2.Name = "txt_1";
            txt2.Text = arg1;
            txt2.Size = new System.Drawing.Size(120, 21);
            TempPanel.Controls.Add(txt2);


            ORG.UILib.Controls.LinkLabelEx llblParamDelete = new ORG.UILib.Controls.LinkLabelEx();
            llblParamDelete.Location = new System.Drawing.Point(450, 0);
            llblParamDelete.Name = "lblDelete";
            llblParamDelete.Size = new System.Drawing.Size(60, 21);
            llblParamDelete.Text = "删除";
            llblParamDelete.LinkClicked+=new LinkLabelLinkClickedEventHandler(llblParamDelete_LinkClicked);
            TempPanel.Controls.Add(llblParamDelete);

            ParamCount++;
            lblParamNum.Text = ParamCount.ToString();
            panelParam.Controls.Add(TempPanel);
            
        }

        private void llblColumnAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ColumnControlAdd("", "");
        }
        private void ColumnControlAdd(string arg0, string arg1)
        {
            int y = ColumnCount * 30;
            ORG.UILib.Controls.PanelEx TempPanel = new ORG.UILib.Controls.PanelEx();
            TempPanel.Location = new System.Drawing.Point(10, y);
            TempPanel.Name = "TempPanel_" + ParamCount.ToString();
            TempPanel.Size = new System.Drawing.Size(560, 21);

            ORG.UILib.Controls.LabelEx lbl = new ORG.UILib.Controls.LabelEx();
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(30, 0);
            lbl.Name = "lbl_0";
            lbl.Size = new System.Drawing.Size(53, 12);
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl.Text = "列名：";
            TempPanel.Controls.Add(lbl);

            ORG.UILib.Controls.TextBoxEx txt = new ORG.UILib.Controls.TextBoxEx();
            txt.Location = new System.Drawing.Point(100, 0);
            txt.Name = "txt_0" ;
            txt.Text = arg0;
            txt.Size = new System.Drawing.Size(120, 21);
            TempPanel.Controls.Add(txt);

            ORG.UILib.Controls.LabelEx lbl2 = new ORG.UILib.Controls.LabelEx();
            lbl2.AutoSize = true;
            lbl2.Location = new System.Drawing.Point(240, 0);
            lbl2.Name = "lbl_1";
            lbl2.Size = new System.Drawing.Size(53, 12);
            lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl2.Text = "控件名称：";
            TempPanel.Controls.Add(lbl2);

            ORG.UILib.Controls.TextBoxEx txt2 = new ORG.UILib.Controls.TextBoxEx();
            txt2.Location = new System.Drawing.Point(320, 0);
            txt2.Name = "txt_1";
            txt2.Text = arg1;
            txt2.Size = new System.Drawing.Size(120, 21);
            TempPanel.Controls.Add(txt2);

            ORG.UILib.Controls.LinkLabelEx llblColumnDelete = new ORG.UILib.Controls.LinkLabelEx();
            llblColumnDelete.Location = new System.Drawing.Point(450, 0);
            llblColumnDelete.Name = "lblDelete_" + ColumnCount.ToString();
            llblColumnDelete.Size = new System.Drawing.Size(60, 21);
            llblColumnDelete.Text = "删除";
            llblColumnDelete.LinkClicked += new LinkLabelLinkClickedEventHandler(llblColumnDelete_LinkClicked);
            TempPanel.Controls.Add(llblColumnDelete);

            ColumnCount++;
            lblColumnNum.Text = ColumnCount.ToString();
            panelColumn.Controls.Add(TempPanel);
        }
        /// <summary>
        /// 参数删除功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llblParamDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Control ctrl = sender as Control;
            ctrl.Parent.Parent.Controls.Remove(ctrl.Parent);
            ParamCount--;
            lblParamNum.Text = ParamCount.ToString();
        }
        /// <summary>
        /// 列删除功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llblColumnDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Control ctrl = sender as Control;
            ctrl.Parent.Parent.Controls.Remove(ctrl.Parent);
            ColumnCount--;
            lblColumnNum.Text = ColumnCount.ToString();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            valueObject = new ValueObject();
            string name = txtName.Text;
            string SqlInf = txtSql.Text;
            string SearchParam = string.Empty;
            foreach (Control ctrl in panelParam.Controls)
            {
                if (ctrl is ORG.UILib.Controls.PanelEx)
                {
                    string ParamName = ctrl.Controls["txt_0"].Text;
                    string ParamTxt = ctrl.Controls["txt_1"].Text;
                    if (SqlInf.IndexOf(ParamName) == -1)
                    {
                        MessageBox.Show("参数[" + ParamName + "] 与SQL语句中的参数不对应！");
                        return;
                    }
                    SearchParam += ParamName + "," + ParamTxt + "|";
                }
            }
            string ReturnColumnNames = string.Empty;
            foreach (Control ctrl in panelColumn.Controls)
            {
                if (ctrl is ORG.UILib.Controls.PanelEx)
                {
                    string ColumnName = ctrl.Controls["txt_0"].Text;
                    string ColumnObj = ctrl.Controls["txt_1"].Text;
                    if (SqlInf.IndexOf(ColumnName) == -1)
                    {
                        MessageBox.Show("列名[" + ColumnName + "] 与SQL语句中的列名不对应！");
                        return;
                    }
                    ReturnColumnNames += ColumnName + "," + ColumnObj + "|";
                }
            }
            valueObject.Name = name;
            valueObject.ListSql = txtSql.Text;
            valueObject.SearchParam = SearchParam.TrimEnd('|');
            valueObject.ReturnColumnNames = ReturnColumnNames.TrimEnd('|');

            this.DialogResult = DialogResult.OK;
            this.Close(); 
        }

    }
}
