using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using ORG.Utilities;
using STIM.WinFormUI.ExtControl;

namespace STIM.WinFormUI.PropertyGrid.Select
{
    public partial class FrmShow : Form
    {
        private ValueObject valueObject = null;
        //public DataGridViewRow dgvr = null;
        private int ParamCount = 0;

        public FrmShow()
        {
            InitializeComponent();
        }

        public FrmShow(ValueObject _valueObject)
        {
            InitializeComponent();
            this.valueObject = _valueObject as ValueObject;
        }

        private void FrmShow_Load(object sender, EventArgs e)
        {
            if (valueObject != null)
            {
                this.Text = valueObject.Name;
                string sql = valueObject.ListSql;
                string SearchParam = valueObject.SearchParam;
                //string ReturnColumnNames = valueObject.ReturnColumnNames;
                string[] Param = SearchParam.Split('|');
                foreach (string tempParam in Param)
                {
                    string[] temp = tempParam.Split(',');
                    ParamControlAdd(temp[0], temp[1]);
                }
            }
            else
            {
                this.Text = "无界面数据对象";
            }

        }
        private void ParamControlAdd(string arg0, string arg1)
        {
            int y = ParamCount * 30+10;
            ORG.UILib.Controls.PanelEx TempPanel = new ORG.UILib.Controls.PanelEx();
            TempPanel.Location = new System.Drawing.Point(10, y);
            TempPanel.Name = "TempPanel_" + ParamCount.ToString();
            TempPanel.Size = new System.Drawing.Size(220, 21);

            ORG.UILib.Controls.LabelEx lbl = new ORG.UILib.Controls.LabelEx();
            lbl.AutoSize = true;
            lbl.Location = new System.Drawing.Point(30, 0);
            lbl.Name = "lbl_0";
            lbl.Size = new System.Drawing.Size(53, 12);
            lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            lbl.Text = arg1;
            TempPanel.Controls.Add(lbl);

            ORG.UILib.Controls.TextBoxEx txt = new ORG.UILib.Controls.TextBoxEx();
            txt.Location = new System.Drawing.Point(100, 0);
            txt.Name = "txt_0";
            txt.Tag = arg0;
            txt.Size = new System.Drawing.Size(120, 21);
            TempPanel.Controls.Add(txt);

            ParamCount++;
            FLPannel.Controls.Add(TempPanel);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (valueObject == null)
            {
                return;
            }
            string SearchParam = valueObject.SearchParam;
            string sql = valueObject.ListSql;
            Hashtable ht = new Hashtable();
            //用户界面参数和值
            foreach (Control ctrl in FLPannel.Controls)
            {
                if (ctrl is ORG.UILib.Controls.PanelEx)
                {
                    ORG.UILib.Controls.TextBoxEx txt = ctrl.Controls["txt_0"] as ORG.UILib.Controls.TextBoxEx;
                    ht.Add(txt.Tag.ToString(), txt.Text);
                   
                }
            }
            //系统参数和值；
            PropertyGrid.Item.SysValue sv = new Item.SysValue();
            foreach (TxtValObject tv in sv.ValueList)
            {
                string key = tv.Val;
                if (sql.IndexOf(":" + key) > -1)
                {
                    ht.Add(":" + key, sv.GetValue(key));
                }
            }
            BLL.STIM_CONFIG bll=new BLL.STIM_CONFIG();
            DataSet ds = bll.getSearchResult(valueObject.ListSql,ht);
            if (ds!=null&&ds.Tables.Count>0)
            {
                DGVList.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void DGVList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                try
                {
                    int r = e.RowIndex;
                    //this.dgvr = DGVList.Rows[r];
                    Form frm=this.Owner;
                    CreateStimControl csc = new CreateStimControl();
                    string[] Column = valueObject.ReturnColumnNames.Split('|');
                    foreach (string tempColumn in Column)
                    {
                        string[] temp = tempColumn.Split(',');
                        string val=DGVList[temp[0],r].Value.ToString();//列表值
                        foreach (Control ctrl in frm.Controls)
                        {
                            Control ctrlTemp = findControl(ctrl, temp[1]);
                            if(ctrlTemp is StimControl)
                            {
                                csc.SetValueByType((ctrlTemp as StimControl).DataFile, val);
                                break;
                            }
                         
                        }
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    LogUtil.WriteLog(ex, this.Name + ".DGVList_CellContentDoubleClick");
                    MessageBox.Show(AppMessage.MSG0001, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        private System.Windows.Forms.Control findControl(System.Windows.Forms.Control control, string controlName)
        {
            Control c1;
            foreach (Control c in control.Controls)
            {
                if (c.Name == controlName)
                {
                    return c;
                }
                else if (c.Controls.Count > 0)
                {
                    c1 = findControl(c, controlName);
                    if (c1 != null)
                    {
                        return c1;
                    }
                }
            }
            return null;
        }
    }
}
