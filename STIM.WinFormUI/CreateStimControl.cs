using System.Collections.Generic;
using System.Data;
using System.Linq;
using STIM.WinFormUI.ExtControl;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Web.Script.Serialization;
using STIM.WinFormUI.PropertyGrid;

namespace STIM.WinFormUI
{
    public class CreateStimControl
    {
        /// <summary>
        /// 根据类型自动生成的控件
        /// </summary>
        public StimControl AutoStimControl { get; set; } 

        public CreateStimControl()
        {}
        /// <summary>
        /// 根据DataRow生成控件
        /// </summary>
        /// <param name="row"></param>
        /// <param name="objValue"></param>
        /// <param name="draggable"></param>
        public CreateStimControl(DataRow row, Object objValue = null)
        {
            string dataType = row["DATA_TYPE"].ToString();
            switch (dataType)
            {
                case "DATE":
                    DateTimePicker dateTimePicker = new DateTimePicker();
                    AutoStimControl = CreateStimBasic(dateTimePicker, row, objValue);
                    break;
                case "NUMBER":
                    NumericUpDown numericUpDown = new NumericUpDown();
                    AutoStimControl = CreateStimBasic(numericUpDown, row, objValue);
                    break;
                default:
                    TextBox txt = new TextBox();
                    AutoStimControl = CreateStimBasic(txt, row, objValue);
                    break;
            }
        }

       /// <summary>
        /// 根据XML生成控件,设计界面用
       /// </summary>
       /// <param name="xElement"></param>
       /// <param name="objValue"></param>
        public CreateStimControl(XElement xElement, Object objValue)
        {
            TextBox txt = new TextBox();
            AutoStimControl = CreateStimBasic(txt, xElement, objValue);
            //string type = (string)xElement.Attribute("ControlType");
            //AutoStimControl.CreateControlAndSetValue(type, objValue);
        }
        /// <summary>
        /// 根据XML生成控件,添加，编辑页面用
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="objValue"></param>
        /// <param name="Flag">add、modify</param>
        /// 
        public CreateStimControl(XElement xElement, Object objValue, string Flag)
        {
            TextBox txt = new TextBox();
            AutoStimControl = CreateStimBasic(txt, xElement, objValue, Flag);
            //string type = (string)xElement.Attribute("ControlType");
            //AutoStimControl.property_TypeChangeHandler(type);
        }

        #region ===根据控件类型创建相应的控件===

        /// <summary>
        /// 创建Stim控件基类，用于设计界面
        /// </summary>
        /// <param name="control"></param>
        /// <param name="objAttribute"></param>
        /// <returns></returns>
        private StimControl CreateStimBasic(Control control, Object objAttribute, Object objValue)
        {
            StimControl stimControl = null;
            //根据XML生成控件
            if (objAttribute.GetType().Name.Equals("XElement"))
            {
                XElement xElement = (XElement)objAttribute;
                //解决数据源
                List<TxtValObject> TempDataSource = null;
                string datasource = getXElementAttributeValue(xElement.Element("DataRule"), "DataSource", "");
                if (!string.IsNullOrEmpty(datasource))
                {
                    var json = new JavaScriptSerializer();
                    TempDataSource = json.Deserialize<List<TxtValObject>>(datasource) as List<TxtValObject>;
                }
                //解决窗体数据源
                PropertyGrid.Select.ValueObject TempDataObject = null;
                string TempDataObjectStr = getXElementAttributeValue(xElement.Element("FrmData"), "object", "");
                if (!string.IsNullOrEmpty(TempDataObjectStr))
                    {
                        var json = new JavaScriptSerializer();
                        TempDataObject = json.Deserialize<PropertyGrid.Select.ValueObject>(TempDataObjectStr) as PropertyGrid.Select.ValueObject;
                    }
                //解决验证规则
                PropertyGrid.CheckValueObject TempRegular = null;
                string RegularStr = getXElementAttributeValue(xElement.Element("DataRule"),"Regular","");
                if (!string.IsNullOrEmpty(RegularStr))
                {
                    var json = new JavaScriptSerializer();
                    TempRegular = json.Deserialize<PropertyGrid.CheckValueObject>(RegularStr) as PropertyGrid.CheckValueObject;
                } 
                //解决默认值
                PropertyGrid.ValueObject TempValueDialog = null;
                string valueDialogStr = getXElementAttributeValue(xElement.Element("DataControl"),"Value","");
                if (!string.IsNullOrEmpty(valueDialogStr))
                {
                    var json = new JavaScriptSerializer();
                    TempValueDialog = json.Deserialize<PropertyGrid.ValueObject>(valueDialogStr) as PropertyGrid.ValueObject;
                   
                }
                stimControl = new StimControl(control)
               {
                   objValue=objValue,
                   Name = getXElementAttributeValue(xElement,"Column_Name",""),
                   Location = new Point(int.Parse(getXElementAttributeValue(xElement,"X","0")), int.Parse(getXElementAttributeValue(xElement,"Y","0"))),
                   Width = int.Parse(getXElementAttributeValue(xElement,"W","250")),
                   Height = int.Parse(getXElementAttributeValue(xElement,"H","29")),
                   //Visible = (bool)xElement.Attribute("Visible"),
                   //Enabled = (bool)xElement.Attribute("Enabled"),
                   //TLP={CellBorderStyle=TableLayoutPanelCellBorderStyle.None},
                   property=
                   {
                       Name =getXElementAttributeValue(xElement,"Column_Name",""),
                       Text = xElement.Element("Lable").Value != "" ? xElement.Element("Lable").Value : (string)xElement.Attribute("Column_Name"),
                       ColumnWidth = int.Parse(getXElementAttributeValue(xElement,"CW","80")),
                       TabIndex = int.Parse(getXElementAttributeValue(xElement, "TabIndex", "0")),
                       ControlType=int.Parse(getXElementAttributeValue(xElement,"ControlType","0")),
                       ControlVisible=getXElementAttributeValue(xElement,"Visible","True").Equals("True")?1:0,
                       ControlEnable=getXElementAttributeValue(xElement,"Enabled","True").Equals("True")?1:0,
                       ControlRequired = getXElementAttributeValue(xElement,"Required","True").Equals("True") ? 1 : 0,
                       ListConditionFlag = getXElementAttributeValue(xElement,"ListConditionFlag","True").Equals("True") ? 1 : 0,
                       ListShowFlag =  getXElementAttributeValue(xElement,"ListShowFlag","True").Equals("True") ? 1 : 0,
                       ControlDataSource=TempDataSource,
                       FrmDataObject = TempDataObject,
                       Value = TempValueDialog,
                       CheckRegular = TempRegular
                   },
                   lblFile =
                   {
                       Text = xElement.Element("Lable").Value != "" ? xElement.Element("Lable").Value : getXElementAttributeValue(xElement,"Column_Name",""),
                       
                   },
                   DataFile =
                   {
                       Enabled = getXElementAttributeValue(xElement.Element("DataControl"),"Enabled","True").Equals("True"),
                       Visible = getXElementAttributeValue(xElement.Element("DataControl"),"Visible","True").Equals("True")
                   }
               };
            }
            //根据DataRow生成控件
            if (objAttribute.GetType().Name.Equals("DataRow"))
            {
                DataRow row = (DataRow)objAttribute;
                stimControl = new StimControl(control)
                {
                    Name = (string)row["Column_Name"],
                    property=
                   {
                    Text = (string)row["Column_Name"],
                   },
                    //TLP={CellBorderStyle=TableLayoutPanelCellBorderStyle.None},
                    lblFile = { Text = (string)row["Column_Name"] },// row["COMMENTS"] + "：";
                    DataFile =
                    {
                        Width = 150,
                        Height = 21
                    }
                };
            }
            //为空时默认返回TextBox
            return stimControl ?? new StimControl(new TextBox());
        }

        /// <summary>
        /// 用于添加、编辑页面生成控件
        /// </summary>
        /// <param name="control"></param>
        /// <param name="objAttribute"></param>
        /// <param name="objValue"></param>
        /// <param name="Flag">是添加、还是修改</param>
        /// <returns></returns>
        private StimControl CreateStimBasic(TextBox control, Object objAttribute, Object objValue, string Flag)
        {
            StimControl stimControl = null;
            //根据XML生成控件
            if (objAttribute.GetType().Name.Equals("XElement"))
            {
                XElement xElement = (XElement)objAttribute;
                //解决数据源
                List<TxtValObject> TempDataSource = null;
                string datasource = getXElementAttributeValue(xElement.Element("DataRule"),"DataSource","");
                if (!string.IsNullOrEmpty(datasource))
                {
                    var json = new JavaScriptSerializer();
                    TempDataSource = json.Deserialize<List<TxtValObject>>(datasource) as List<TxtValObject>;
                }
                //解决窗体数据源
                PropertyGrid.Select.ValueObject TempDataObject = null;
                string TempDataObjectStr = getXElementAttributeValue(xElement.Element("FrmData"), "object", "");
                if (!string.IsNullOrEmpty(TempDataObjectStr))
                {
                    var json = new JavaScriptSerializer();
                    TempDataObject = json.Deserialize<PropertyGrid.Select.ValueObject>(TempDataObjectStr) as PropertyGrid.Select.ValueObject;
                }
                //解决验证规则
                PropertyGrid.CheckValueObject TempRegular = null;
                string RegularStr = getXElementAttributeValue(xElement.Element("DataRule"),"Regular","");
                if (!string.IsNullOrEmpty(RegularStr))
                {
                    var json = new JavaScriptSerializer();
                    TempRegular = json.Deserialize<PropertyGrid.CheckValueObject>(RegularStr) as PropertyGrid.CheckValueObject;
                }
                //解决默认值
                PropertyGrid.ValueObject TempValueDialog = null;
                string valueDialogStr = getXElementAttributeValue(xElement.Element("DataControl"),"Value","");
                if (!string.IsNullOrEmpty(valueDialogStr))
                {
                    var json = new JavaScriptSerializer();
                    TempValueDialog = json.Deserialize<PropertyGrid.ValueObject>(valueDialogStr) as PropertyGrid.ValueObject;
                    if (Flag.ToLower().Equals("add"))
                    {
                        //0,文本；1,系统变量；2,sql语句
                        switch (TempValueDialog.ValueType)
                        {
                            case "0": objValue = TempValueDialog.ValueStr; break;
                            case "1": objValue = (new PropertyGrid.Item.SysValue()).GetValue(TempValueDialog.ValueApp); break;
                            case "2": objValue = (new BLL.STIM_CONFIG()).getSqlDefaultValue(TempValueDialog.ValueSql); break;
                        }
                    }
                }
                stimControl = new StimControl(control)
                {
                    objValue = objValue,
                    Name = getXElementAttributeValue(xElement,"Column_Name",""),
                    Location = new Point(int.Parse(getXElementAttributeValue(xElement,"X","0")), int.Parse(getXElementAttributeValue(xElement,"Y","0"))),
                    Width = int.Parse(getXElementAttributeValue(xElement, "W", "250")),
                    Height = int.Parse(getXElementAttributeValue(xElement,"H","29")),
                    Visible = (getXElementAttributeValue(xElement, "Visible", "True")).Equals("True"),
                    //Enabled = (bool)xElement.Attribute("Enabled"),
                    TLP={CellBorderStyle=TableLayoutPanelCellBorderStyle.None},
                    property =
                    {
                        Name = getXElementAttributeValue(xElement, "Column_Name", ""),
                        Text = xElement.Element("Lable").Value != "" ? xElement.Element("Lable").Value : (string)xElement.Attribute("Column_Name"),
                        ColumnWidth = int.Parse(getXElementAttributeValue(xElement, "CW", "80")),
                        TabIndex = int.Parse(getXElementAttributeValue(xElement, "TabIndex", "0")),
                        ControlType = int.Parse(getXElementAttributeValue(xElement,"ControlType","0")),
                        ControlVisible = getXElementAttributeValue(xElement,"Visible","True").Equals("True") ? 1 : 0,
                        ControlEnable = getXElementAttributeValue(xElement,"Enabled","True").Equals("True") ? 1 : 0,
                        ControlRequired = getXElementAttributeValue(xElement,"Required","True").Equals("True") ? 1 : 0,
                        ListConditionFlag = getXElementAttributeValue(xElement,"ListConditionFlag","True").Equals("True") ? 1 : 0,
                        ListShowFlag = getXElementAttributeValue(xElement,"ListShowFlag","True").Equals("True") ? 1 : 0,
                        FrmDataObject = TempDataObject,
                        ControlDataSource = TempDataSource,
                        Value = TempValueDialog,
                        CheckRegular = TempRegular
                    },
                    lblFile =
                    {
                        Text = xElement.Element("Lable").Value != "" ? xElement.Element("Lable").Value : (string)xElement.Attribute("Column_Name"),

                    },
                    DataFile =
                    {
                        Enabled = getXElementAttributeValue(xElement.Element("DataControl"),"Enabled","True").Equals("True"),
                        Visible = getXElementAttributeValue(xElement.Element("DataControl"),"Visible","True").Equals("True")
                    }
                };
            }

            //为空时默认返回TextBox
            return stimControl ?? new StimControl(new TextBox());
        }

        /// <summary>
        /// 获取XElement的属性值，如果不存属性则返回 defaultValue的值
        /// </summary>
        /// <param name="xEle"></param>
        /// <param name="AttributeName"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        private string getXElementAttributeValue(XElement xEle,string AttributeName, string defaultValue)
        {
            try
            {
                return xEle.Attribute(AttributeName).Value;
            }
            catch
            { 
                return defaultValue;
            }
        }
        #endregion

        /// <summary>
        /// 根据控件类型返回值
        /// </summary>
        /// <param name="control">目标控件</param>
        /// <param name="row"></param>
        /// <return></return>
        public string GetValueByType(Control control)
        {
            try
            {
                string result = string.Empty;
                Type type = control.GetType();
                switch (type.Name)
                {
                    case "TextBox":
                        result = ((TextBox)control).Text;
                        break;
                    case "TextBoxFrm":
                        result = ((TextBoxFrm)control).Text;
                        break;
                    case "DateTimePicker":
                        result = ((DateTimePicker)control).Value.ToString("yyyy-MM-dd");
                        break;
                    case "NumericUpDown":
                        result = ((NumericUpDown)control).Value.ToString();
                        break;
                    case "CheckBox":
                        result = ((CheckBox)control).Checked ? "Y" : "N";
                        break;
                    case "RadioButton":
                        result = ((RadioButton)control).Checked ? "Y" : "N"; ;
                        break;
                    case "RadioButtonGroup":
                        result = ((RadioButtonGroup)control).Value;
                        break;
                    case "ComboBox":
                        result = ((ComboBox)control).SelectedValue.ToString();
                        break;
                    case "CheckBoxGroup":
                        result = ((CheckBoxGroup)control).Value;
                        break;
                    case "ListBox":
                        foreach (object obj in ((ListBox)control).SelectedItems)
                        {
                            result += (obj as DataRowView)[((ListBox)control).ValueMember].ToString() + ",";
                        }
                        result = result.TrimEnd(',');
                        break;
                    default:
                        result = control.Text;
                        break;
                }
                return result ?? string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool SetValueByType(Control control,string value)
        {
            try
            {
                Type type = control.GetType();
                switch (type.Name)
                {
                    case "TextBox":
                        ((TextBox)control).Text=value;
                        break;
                    case "TextBoxFrm":
                        ((TextBoxFrm)control).Text=value;
                        break;
                    case "DateTimePicker": 
                        DateTime dt=new DateTime();
                        DateTime.TryParse(value,out dt);
                        ((DateTimePicker)control).Value = dt;
                        break;
                    case "NumericUpDown":
                        Decimal temp = 0;
                        Decimal.TryParse(value, out temp);
                        ((NumericUpDown)control).Value = temp;
                        break;
                    case "CheckBox":
                        ((CheckBox)control).Checked = "Y".Equals(value);
                        break;
                    case "RadioButton":
                        ((RadioButton)control).Checked = "Y".Equals(value);;
                        break;
                    case "RadioButtonGroup":
                        ((RadioButtonGroup)control).Value = value;
                        break;
                    case "ComboBox":
                        ((ComboBox)control).SelectedValue = value;
                        break;
                    case "CheckBoxGroup":
                        ((CheckBoxGroup)control).Value = value;
                        break;
                    case "ListBox":
                        for (int i = 0; i < (control as ListBox).Items.Count;i++ )
                        {
                            Object obj=(control as ListBox).Items[i];
                            string temp1 = "," + (obj as DataRowView)[((ListBox)control).ValueMember].ToString()+",";
                            if ((","+value+",").IndexOf(temp1)>-1)
                            (control as ListBox).SetSelected(i, true);
                        }
                        break;
                    default:
                        control.Text = value;
                        break;
                }
                return true;
            }
            catch 
            {
                return false;
            }

        }
    }
}
