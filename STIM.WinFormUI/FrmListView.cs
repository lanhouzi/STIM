using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using STIM.WinFormUI.ExtControl;
using System.Collections;

namespace STIM.WinFormUI
{
    public partial class FrmListView : ORG.UILib.Forms.BaseForm
    {
        /// <summary>
        /// 表名
        /// </summary>
        string TableName = "GOODS_EXT";
        /// <summary>
        /// 表结构
        /// </summary>
        DataTable DtStruct = new DataTable();
        /// <summary>
        /// 主键
        /// </summary>
        List<string> PkList = new List<string>();
        BLL.STIM_CONFIG _bll = new BLL.STIM_CONFIG();
        Model.STIM_CONFIG _model = new Model.STIM_CONFIG();

        public FrmListView()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
        }
        public FrmListView(string tablename)
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            this.TableName = tablename;

            this.tsBaseVisible = true;
            this.tsbSearchEnable = true;
            this.tsbAddEnable = true;
            this.tsbDelEnable = false;
            this.tsbUpdateEnable = false;
        }

        private void FrmDataView_Load(object sender, EventArgs e)
        {
            //表结构
            DtStruct = _bll.GetTableInformation(TableName).Tables[0];
            _model = _bll.GetModel(TableName);
            foreach (DataRow row in DtStruct.Rows)
            {
                if (row["ISPK"].ToString().Equals("Y"))
                {
                    PkList.Add((string)row["Column_Name".ToUpper()]);
                }
            }
            //_model.DATAGRIDVIEW_XML = XDocument.Load(Application.StartupPath + "\\DetailForm.xml").ToString();
            //按照自定义配置布局控件
            if (_model != null && !string.IsNullOrEmpty(_model.DETAIL_FORM_XML))
            {
                XDocument xDoc = XDocument.Parse(_model.DETAIL_FORM_XML, LoadOptions.None);
                //Lambda
                IEnumerable<XElement> xElements = xDoc.Root.Elements().Select(el => el);
                
                int _layoutRow = -1; // 表单布局 行
                int _layoutColumn = -1;// 表单布局 列

                foreach (XElement item in xElements)
                {
                   string ListConditionFlag = item.Attribute("ListConditionFlag").Value;
                   string ListShowFlag= item.Attribute("ListShowFlag").Value;
                   
                    var dgvCol = new DataGridViewTextBoxColumn
                    {
                        Name = (string)item.Attribute("Column_Name"),
                        HeaderText = (string)item.Element("Lable").Value.TrimEnd(':').TrimEnd('：'),
                        DataPropertyName = (string)item.Attribute("Column_Name"),
                        Visible = ListShowFlag.Equals("True"),
                    };
                    dgvData.Columns.Add(dgvCol);

                    if (ListConditionFlag.Equals("True"))
                    {
                        CreateStimControl stimControl = new CreateStimControl(item, null, "add");
                        _layoutColumn++;
                        //3表示显示3列
                        if (_layoutColumn % 3 == 0)
                        {
                            _layoutColumn = 0;
                            _layoutRow++;
                        }
                        stimControl.AutoStimControl.Location = new Point(20 + _layoutColumn * 300, 20 + _layoutRow * 35);
                        GrpflPanelSearch.Controls.Add(stimControl.AutoStimControl);
                        stimControl.AutoStimControl.Visible = true;
                        stimControl.AutoStimControl.DataFile.Enabled= true;
                    }   
                }
                //grpSearch.Height = (_layoutRow +1)* 35 + 20;
            }
            //系统自动有序布局控件
            else
            {
                foreach (DataRow row in DtStruct.Rows)
                {
                    var dgvCol = new DataGridViewTextBoxColumn
                    {
                        Name = (string)row["Column_Name".ToUpper()],
                        HeaderText = (string)row["Column_Name".ToUpper()],
                        DataPropertyName = (string)row["Column_Name".ToUpper()],
                        ReadOnly = true,
                        //主键
                        //Tag = row["ISPK"].ToString().Equals("Y") ? "ISPK" : ""
                    };
                    dgvData.Columns.Add(dgvCol);

                    //if (row["ISPK"].ToString().Equals("Y"))
                    //{
                    //    PkList.Add(dgvCol.Name);
                    //}
                }
            }
            //LoadData();
        }

        #region ===事件===
        private void tsMenuAdd_Click(object sender, EventArgs e)
        {
            AddData();
        }
        private void tsMenuModify_Click(object sender, EventArgs e)
        {
            ModifyData();
        }
        private void tsMenuDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
        private void tsMenuRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void FrmListView_tSMIAdd_click(object sender, EventArgs e)
        {
            AddData();
        }

        private void FrmListView_tSMIDel_click(object sender, EventArgs e)
        {
            DeleteData();
        }

        private void FrmListView_tSMISearch_click(object sender, EventArgs e)
        {
                LoadData();
        }

        private void FrmListView_tSMIUpdate_click(object sender, EventArgs e)
        {
            ModifyData();
        }
        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ModifyData();
        }
        #endregion

        # region ===方法===
        /// <summary>
        /// 加载数据
        /// </summary>
        public void LoadData()
        {
            ArrayList al = new ArrayList();
            CreateStimControl csc = new CreateStimControl();
            foreach (Control item in GrpflPanelSearch.Controls)
            {
                if (item is StimControl)
                {
                    string name=(item as StimControl).Name;
                    string value = csc.GetValueByType((item as StimControl).DataFile);
                    if (!string.IsNullOrEmpty(value))
                    {
                        ArrayList altemp = new ArrayList();
                        altemp.Insert(0, name);
                        altemp.Insert(1, value);
                        altemp.Insert(2, (item as StimControl).DataFile.GetType().Name.Equals("DateTimePicker") ? "3" : "0");
                        al.Add(altemp);
                    }
                }
            }
            DataSet ds= _bll.GetDataList(TableName, al);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                dgvData.DataSource = ds.Tables[0].DefaultView;
                this.tsbDelEnable = true;
                this.tsbUpdateEnable = true;
                tsMenuModify.Enabled = true;
                tsMenuDelete.Enabled = true;
            }
            else
            {
                this.tsbDelEnable = false;
                this.tsbUpdateEnable = false;
                tsMenuModify.Enabled = false;
                tsMenuDelete.Enabled = false;
            }
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        public void AddData()
        {
            FrmDetailView frm = new FrmDetailView("Add", TableName, DtStruct, PkList);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        public void ModifyData()
        {
            if (dgvData.CurrentRow != null)
            {
                int rowIndex = dgvData.CurrentRow.Index;
                if (-1 < rowIndex)
                {
                    DataGridViewRow dgvRow = dgvData.Rows[rowIndex];
                    FrmDetailView frm = new FrmDetailView("Modify", TableName, DtStruct, PkList, dgvRow);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        public void DeleteData()
        {
            DialogResult resault = MessageBox.Show("确定要删除选中的记录吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resault == DialogResult.OK)
            {
                //把主键拼接为一个查询条件
                string strDeleteWhere = PkList.Aggregate("", (current, item) => current + ("||" + item));
                StringBuilder sbDeleteValues = new StringBuilder();

                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    //选中的行
                    if ((bool)row.Cells["rowChecker"].EditedFormattedValue)
                    {
                        //string strValue = "";
                        //foreach (string item in IsPkList)
                        //{
                        //    strValue += row.Cells[item].Value.ToString();
                        //}
                        string strValue = PkList.Aggregate("", (current, item) => current + row.Cells[item].Value.ToString());
                        sbDeleteValues.Append(",'" + strValue + "'");
                    }
                }

                if (sbDeleteValues.Length > 0)
                {
                    //移出头部的,
                    sbDeleteValues.Remove(0, 1);
                    bool result = _bll.DeleteDataList(TableName, strDeleteWhere.Remove(0, 2), sbDeleteValues.ToString());
                    if (result)
                    {
                        MessageBox.Show("删除成功！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("删除失败！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                    //richTextBox1.AppendText("delete " + TableName);
                    //richTextBox1.AppendText(" where " + strDeleteWhere.Remove(0, 2));//移出头部的||
                    //richTextBox1.AppendText(" in (" + sbDeleteValues + ")");
                }
                else
                {
                    MessageBox.Show("请选择需要删除的行记录！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        #endregion

        private void FrmDataView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

       

    }
}
