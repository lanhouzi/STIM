using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace STIM.WinFormUI
{
    public partial class FrmDataView : Form
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

        public FrmDataView()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
        }

        private void FrmDataView_Load(object sender, EventArgs e)
        {
            _model = _bll.GetModel(TableName);
            //_model.DATAGRIDVIEW_XML = XDocument.Load(Application.StartupPath + "\\DetailForm.xml").ToString();
            //按照自定义配置布局控件
            if (_model != null && !string.IsNullOrEmpty(_model.DATAGRIDVIEW_XML))
            {
                XDocument xDoc = XDocument.Parse(_model.DATAGRIDVIEW_XML, LoadOptions.None);
                //Lambda
                IEnumerable<XElement> xElements = xDoc.Root.Elements().Select(el => el);
                foreach (XElement item in xElements)
                {
                    var dgvCol = new DataGridViewTextBoxColumn
                    {
                        Name = (string)item.Attribute("Column_Name"),
                        HeaderText = (string)item.Attribute("Column_Name"),
                        DataPropertyName = (string)item.Attribute("Column_Name"),
                        ReadOnly = true
                    };
                    dgvData.Columns.Add(dgvCol);
                }
            }
            //系统自动有序布局控件
            else
            {
                //表结构
                DtStruct = _bll.GetTableInformation(TableName).Tables[0];
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

                    if (row["ISPK"].ToString().Equals("Y"))
                    {
                        PkList.Add(dgvCol.Name);
                    }
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
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddData();
        }
        private void btnModify_Click(object sender, EventArgs e)
        {
            ModifyData();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteData();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
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
            StringBuilder sbWhere = new StringBuilder("ROWNUM<=500");
            dgvData.DataSource = _bll.GetDataList(TableName, sbWhere.ToString()).Tables[0].DefaultView;
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        public void AddData()
        {
            FrmDetailView frm = new FrmDetailView("Add", TableName,DtStruct, PkList);
            frm.ShowDialog();
            LoadData();
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
                    FrmDetailView frm = new FrmDetailView("Modify", TableName,DtStruct, PkList, dgvRow);
                    frm.ShowDialog();
                    LoadData();
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
                    bool result= _bll.DeleteDataList(TableName, strDeleteWhere.Remove(0, 2), sbDeleteValues.ToString());
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

    }
}
