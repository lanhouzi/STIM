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

namespace STIM.WinFormUI
{
    public partial class FrmDetailView : Form
    {
        /// <summary>
        /// 新增or修改
        /// </summary>
        string AddOrModify = "Add";
        /// <summary>
        /// 表名
        /// </summary>
        string TableName = "";
        /// <summary>
        /// 表结构
        /// </summary>
        DataTable DtStruct = new DataTable();
        /// <summary>
        /// 主键
        /// </summary>
        List<string> PkList = new List<string>();
        /// <summary>
        /// 表单配置信息
        /// </summary>
        XDocument xDocConfig = new XDocument();
        /// <summary>
        /// 表单配置元素集合
        /// </summary>
        IEnumerable<XElement> xElements;

        DataGridViewRow DgvRow = new DataGridViewRow();
        BLL.STIM_CONFIG _bll = new BLL.STIM_CONFIG();
        Model.STIM_CONFIG _model = new Model.STIM_CONFIG();

        public FrmDetailView()
        {
            InitializeComponent();
        }

        public FrmDetailView(string addOrModify, string tableName, DataTable dtStruct, List<string> pkList, DataGridViewRow dgvRow = null)
            : this()
        {
            AddOrModify = addOrModify;
            TableName = tableName;
            DtStruct = dtStruct;
            PkList = pkList;
            DgvRow = dgvRow;
            if ("Modify" == AddOrModify)
            {
                ckbContinue.Enabled = false;
            }
        }

        private void FrmDetailView_Load(object sender, EventArgs e)
        {
            _model = _bll.GetModel(TableName);
            //_model.DETAIL_FORM_XML = XDocument.Load(Application.StartupPath + "\\DetailForm.xml").ToString();

            //按照自定义配置布局控件
            if (!string.IsNullOrEmpty(_model.DETAIL_FORM_XML))
            {
                xDocConfig = XDocument.Parse(_model.DETAIL_FORM_XML, LoadOptions.None);
                xElements = xDocConfig.Root.Elements();//.Select(el => el);
                foreach (XElement item in xElements)
                {
                    //字段名
                    var columnName = (string)item.Attribute("Column_Name");
                    //字段值
                    object columnValue = null;
                    if (AddOrModify == "Modify")
                    {
                        columnValue = DgvRow.Cells[columnName].Value;
                    }
                    CreateStimControl stimControl = new CreateStimControl(item, columnValue);
                    //非空字段
                    //DtStruct.Select("COLUMN_NAME='" + columnName + "'")[0]["NULLABLE"].ToString() == "N"
                    //var test = xElements.Elements("DataRule").Single(el => (int)el.Attribute("Max") == 100);
                    XElement xEl = xElements.Single(el => (string)el.Attribute("Column_Name") == columnName).Elements("DataRule").Single();
                    //(string)xEl.Attribute("Nullable") == "N"
                    if ((string)xEl.Attribute("Nullable") == "N")
                    {
                        stimControl.AutoStimControl.lblFile.ForeColor = Color.Red;
                    }
                    pnlData.Controls.Add(stimControl.AutoStimControl);
                }

            }
            else
            {
                MessageBox.Show("尚未对表【" + TableName + "】进行自定义配置，请新增该表的自定义配置！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            object result = false;
            var controls = pnlData.Controls;
            switch (AddOrModify)
            {
                case "Add":
                    AddData(controls, ref result);
                    break;
                case "Modify":
                    ModifyData(controls, ref result);
                    break;
            }
            if ("error" != result.ToString ())
            {
                if ((bool)result)
                {
                    MessageBox.Show("保存成功！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("保存失败！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ckbContinue.Checked)
                {
                    //todo:
                }
                else ;
                {
                    this.Close();
                }
            }
        }

        /// <summary>
        /// 根据控件类型返回值
        /// </summary>
        /// <param name="control">目标控件</param>
        /// <param name="row"></param>
        /// <return></return>
        public object GetValueByType(Control control, DataRow row)
        {
            object result = null;
            Type type = control.GetType();
            switch (type.Name)
            {
                case "TextBox":
                    result = ((TextBox)control).Text;
                    break;
                case "DateTimePicker":
                    result = ((DateTimePicker)control).Value;
                    break;
                case "NumericUpDown":
                    result = ((NumericUpDown)control).Value;
                    break;
                case "CheckBox":
                    result = ((CheckBox)control).Checked;
                    break;
                case "RadioButton":
                    result = ((RadioButton)control).Checked;
                    break;
                case "ComboBox":
                    result = ((ComboBox)control).SelectedText;
                    break;
                case "CheckedListBox":
                    result = ((CheckedListBox)control).SelectedItems;
                    break;
                case "ListBox":
                    result = ((ListBox)control).SelectedItems;
                    break;
                case "DataGridView":
                    result = ((DataGridView)control).SelectedRows;
                    break;
                default:
                    result = control.Text;
                    break;
            }
            switch (row["DATA_TYPE"].ToString())
            {
                case "NUMBER":
                    return result;
                    break;
                case "DATE":
                    return "to_date('" + result + "','YYYY-MM-DD HH24:MI:SS')";
                    break;
                default:
                    return "'" + result + "'";
                    break;
            }
        }
        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="controls">控件集合</param>
        /// <param name="result">返回值</param>
        public void AddData(Control.ControlCollection controls, ref object result)
        {
            StringBuilder sbExists = new StringBuilder("select count(1) from " + TableName + " where 1=1 ");
            StringBuilder sbAddSql = new StringBuilder("insert into " + TableName);
            StringBuilder sbColumns = new StringBuilder("(");
            StringBuilder sbValues = new StringBuilder(" values (");
            foreach (StimControl item in controls)
            {
                var value = GetValueByType(item.DataFile, DtStruct.Select("COLUMN_NAME='" + item.Name + "'")[0]);
                //值为空（此处''表示为空）
                if ("''" == value.ToString())
                {
                    XElement xEl = xElements.Single(el => (string)el.Attribute("Column_Name") == item.Name).Elements("DataRule").Single();
                    //字段不能为空
                    if ((string)xEl.Attribute("Nullable") == "N")
                    {
                        MessageBox.Show(item.lblFile.Text + " 不能为空！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                //值不为空
                else
                {
                    sbColumns.Append("," + item.Name);
                    sbValues.Append("," + value);
                }
                //如果是主键
                if (PkList.Contains(item.Name))
                {
                    sbExists.Append(" and " + item.Name);
                    sbExists.Append("=" + value);
                }
            }
            sbColumns.Remove(1, 1);//移除第一个逗号
            sbValues.Remove(9, 1);//移除第一个逗号
            sbColumns.Append(")");
            sbValues.Append(")");
            sbAddSql.Append(sbColumns);
            sbAddSql.Append(sbValues);
            //是否存在数据记录
            if (_bll.ExistsData(sbExists.ToString()))
            {
                MessageBox.Show("已存在该条记录！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                result = "error";
            }
            else
            {
                result = _bll.AddData(sbAddSql.ToString());
            }
        }
        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="controls">控件集合</param>
        /// <param name="result">返回值</param>
        public void ModifyData(Control.ControlCollection controls, ref object result)
        {
            StringBuilder sbUpdateSql = new StringBuilder("update " + TableName + " set ");
            StringBuilder sbKeyValue = new StringBuilder();
            StringBuilder sbWhere = new StringBuilder(" where 1=1 ");
            foreach (StimControl item in controls)
            {
                //如果不是主键
                if (!PkList.Contains(item.Name))
                {
                    var value = GetValueByType(item.DataFile, DtStruct.Select("COLUMN_NAME='" + item.Name + "'")[0]);
                    //值为空（此处''表示为空）
                    if ("''" == value.ToString())
                    {
                        XElement xEl = xElements.Single(el => (string)el.Attribute("Column_Name") == item.Name).Elements("DataRule").Single();
                        //字段不能为空
                        if ((string)xEl.Attribute("Nullable") == "N")
                        {
                            MessageBox.Show(item.lblFile.Text + " 不能为空！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            result = "error";
                            return;
                        }
                    }
                    //值不为空
                    else
                    {
                        sbKeyValue.Append("," + item.Name);
                        sbKeyValue.Append("=" + value);
                    }
                }
                else
                {
                    sbWhere.Append(" and " + item.Name);
                    sbWhere.Append("=" +
                                   GetValueByType(item.DataFile,
                                       DtStruct.Select("COLUMN_NAME='" + item.Name + "'")[0]));
                }
            }
            sbKeyValue.Remove(0, 1);//移除第一个逗号
            sbUpdateSql.Append(sbKeyValue);
            sbUpdateSql.Append(sbWhere);

            result = _bll.UpdateData(sbUpdateSql.ToString());
        }
    }
}
