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
        IEnumerable<XElement> xElement;

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
        }

        private void FrmDetailView_Load(object sender, EventArgs e)
        {
            try
            {
                _model = _bll.GetModel(TableName);
                //_model.DETAIL_FORM_XML = XDocument.Load(Application.StartupPath + "\\DetailForm.xml").ToString();

                //按照自定义配置布局控件
                if (!string.IsNullOrEmpty(_model.DETAIL_FORM_XML))
                {
                    xDocConfig = XDocument.Parse(_model.DETAIL_FORM_XML, LoadOptions.None);
                    xElement = xDocConfig.Root.Elements().Select(el => el);
                    foreach (XElement item in xElement)
                    {
                        //字段名
                        var columnName = (string)item.Attribute("Column_Name");
                        //字段值
                        object columnValue = null;
                        if (AddOrModify == "Modify")
                        {
                            columnValue = DgvRow.Cells[columnName].Value;
                        }
                        CreateStimControl stimControl = new CreateStimControl(item, columnValue, AddOrModify);
                        //非空字段
                        //DtStruct.Select("COLUMN_NAME='" + columnName + "'")[0]["NULLABLE"].ToString() == "N"
                        //var test = xElements.Elements("DataRule").Single(el => (int)el.Attribute("Max") == 100);
                        //XElement xEl = xElement.Single(el => (string)el.Attribute("Column_Name") == columnName).Elements("DataRule").Single();

                        pnlData.Controls.Add(stimControl.AutoStimControl);
                        //非空字段
                        if (((string)item.Attribute("Required")).Equals("True"))
                        {
                            stimControl.AutoStimControl.lblFile.ForeColor = Color.Red;
                        }
                        //ComboBox
                        if (stimControl.AutoStimControl.DataFile is ComboBox && columnValue != null)
                        {
                            //ComboBox的赋值操作只能在这里处理
                            ((ComboBox)stimControl.AutoStimControl.DataFile).SelectedValue = columnValue;
                            //stimControl.AutoStimControl.DataFile.Text = "否";
                        }
                    }

                }
                else
                {
                    MessageBox.Show("尚未对表【" + TableName + "】进行自定义配置，请新增该表的自定义配置！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch( Exception ex)
            {
            
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
            if ("error" != result.ToString())
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
            //获取填写的值
            Hashtable htItem = new Hashtable();
            CreateStimControl csc = new CreateStimControl();

            foreach (StimControl item in controls)
            { 
                DataRow row=DtStruct.Select("COLUMN_NAME='" + item.Name + "'")[0];
                string value = csc.GetValueByType(item.DataFile);
                
                //值为空（此处''表示为空）
                if (string.IsNullOrEmpty(value.ToString()))
                {
                    //XElement xEl = xElement.Single(el => (string)el.Attribute("Column_Name") == item.Name).Elements("DataRule").Single();
                    //字段不能为空
                    if (row["Nullable"].ToString() == "N" || item.property.ControlRequired == 1)
                    {
                        MessageBox.Show(item.lblFile.Text + " 不能为空！", "提示消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        result = "error";
                        return;
                    }
                }
                //值不为空
                else
                {
                    sbColumns.Append("," + item.Name);
                    string type = row["DATA_TYPE"].ToString();
                    if (type.Equals("NUMBER"))
                        sbValues.Append("," + value);
                    else if (value.ToString().ToLower().Equals("sysdate"))
                        sbValues.Append("," + value);
                    else if (type.Equals("DATE") || type.ToUpper().IndexOf("TIMESTAMP") == 0)
                        sbValues.Append(",to_date('" + value + "','YYYY-MM-DD HH24:MI:SS')");
                    else
                    {
                        sbValues.Append(",'" + value + "'");
                    }
                }
                //如果是主键
                if (PkList.Contains(item.Name))
                {
                    sbExists.Append(" and " + item.Name);
                    sbExists.Append("='" + value + "'");
                }
                htItem.Add(item.property, value);
            }
            sbColumns.Remove(1, 1);//移除第一个逗号
            sbValues.Remove(9, 1);//移除第一个逗号
            sbColumns.Append(")");
            sbValues.Append(")");
            sbAddSql.Append(sbColumns);
            sbAddSql.Append(sbValues);

            //数据验证格式和正确性验证
           foreach (DictionaryEntry objDE in htItem)
            {
                string val = objDE.Value.ToString();
                StimControlProperty property = objDE.Key as StimControlProperty;
                //验证输入值
                if (!checkValudate(property, val, htItem))
                {
                    MessageBox.Show(property.Text + " 输入值错误！", "提示消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    result = "error";
                    return;
                }
                
            }
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
            //获取填写的值
            Hashtable htItem = new Hashtable();
            CreateStimControl csc = new CreateStimControl();

            foreach (StimControl item in controls)
            {
                DataRow row = DtStruct.Select("COLUMN_NAME='" + item.Name + "'")[0];
                string value = csc.GetValueByType(item.DataFile);
                //如果不是主键
                if (!PkList.Contains(item.Name))
                {
                    //值为空（此处''表示为空）
                    if (string.IsNullOrEmpty(value.ToString()))
                    {
                        //if (row["Nullable"].ToString() == "N" || item.property.ControlRequired == 1)XElement xEl = xElement.Single(el => (string)el.Attribute("Column_Name") == item.Name).Elements("DataRule").Single();
                        //字段不能为空
                        if (row["Nullable"].ToString() == "N" || item.property.ControlRequired == 1)
                        {
                            MessageBox.Show(item.lblFile.Text + " 不能为空！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            result = "error";
                            return;
                        }
                    }
                    //值不为空
                    else
                    {;
                        sbKeyValue.Append("," + item.Name);
                        string type = row["DATA_TYPE"].ToString();
                        if (type.Equals("NUMBER"))
                            sbKeyValue.Append("=" + value);
                        else if (type.Equals("DATE") || type.ToUpper().IndexOf("TIMESTAMP") == 0)
                            sbKeyValue.Append("=to_date('" + value + "','YYYY-MM-DD HH24:MI:SS')");
                        else if (value.ToString().ToLower().Equals("sysdate"))
                            sbKeyValue.Append("=" + value);
                        else
                        {
                            sbKeyValue.Append("='" + value + "'");
                        }
                    }
                }
                else
                {
                    sbWhere.Append(" and " + item.Name);
                    sbWhere.Append("='" + value + "'");
                }
                htItem.Add(item.property, value);
            }
            sbKeyValue.Remove(0, 1);//移除第一个逗号
            sbUpdateSql.Append(sbKeyValue);
            sbUpdateSql.Append(sbWhere);
            //数据验证格式和正确性验证
            foreach (DictionaryEntry objDE in htItem)
            {
                string val = objDE.Value.ToString();
                StimControlProperty property = objDE.Key as StimControlProperty;
                //验证输入值
                if (!checkValudate(property, val, htItem))
                {
                    MessageBox.Show(property.Text + " 输入值错误！", "提示消息", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    result = "error";
                    return;
                }

            }
            result = _bll.UpdateData(sbUpdateSql.ToString());
        }

        /// <summary>
        /// 验证输入的是否正确
        /// </summary>
        /// <param name="property"></param>
        /// <param name="ValueStr"></param>
        /// <returns></returns>
        private bool checkValudate(StimControlProperty property, string ValueStr, Hashtable htItem)
        {
            bool ch = true;
            if (property.CheckRegular != null)
            {
                PropertyGrid.Item.SYSMethod Method=new PropertyGrid.Item.SYSMethod();
                //0,系统方法；1,正则表达式；2,sql语句
                switch (property.CheckRegular.ValueType)
                {
                    case "0": ch = Method.CheckValue(property.CheckRegular.ValueApp, ValueStr); break;
                    case "1": ch = Method.RegexCheck(ValueStr,property.CheckRegular.ValueRegular); break;
                    case "2":
                        string sql=property.CheckRegular.ValueSql;
                        Hashtable ht = new Hashtable();
                        //ht.Add(property.Name, ValueStr);
                        //获取系统默认值
                        PropertyGrid.Item.SysValue _sysValue = new PropertyGrid.Item.SysValue();
                        foreach (PropertyGrid.TxtValObject obj in _sysValue.ValueList)
                        {
                            if (sql.IndexOf(":"+obj.Val)>0)
                            {
                                ht.Add(obj.Val, _sysValue.GetValue(obj.Val));
                            }
                        }
                        //获取界面其他控件的值
                        foreach (DictionaryEntry objDE in htItem)
                        {
                            StimControlProperty tempProperty = objDE.Key as StimControlProperty;
                            if (sql.IndexOf(":" + tempProperty.Name) > 0)
                            {
                                ht.Add(tempProperty.Name, objDE.Value);
                            }
                        }
                        ch = (new BLL.STIM_CONFIG()).SqlCheckValue(sql, ht); 
                        break;
                }
            }
            return ch;
        }

        private void FrmDetailView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }
    }
}
