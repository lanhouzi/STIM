using System.Data;
using Newtonsoft.Json.Linq;
using STIM.WinFormUI.ExtControl;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using STIM.Utilities;
using Newtonsoft.Json;

namespace STIM.WinFormUI
{
    public class CreateStimControl
    {
        /// <summary>
        /// 根据类型自动生成的控件
        /// </summary>
        public StimControl AutoStimControl { get; set; }

        /// <summary>
        /// 根据DataRow生成控件
        /// </summary>
        /// <param name="row"></param>
        /// <param name="objValue"></param>
        /// <param name="draggable"></param>
        public CreateStimControl(DataRow row, Object objValue = null, bool draggable = false)
        {
            string dataType = row["DATA_TYPE"].ToString();
            switch (dataType)
            {
                case "DATE":
                    DateTimePicker dateTimePicker = new DateTimePicker();
                    AutoStimControl = CreateStimWfDateTimePicker(dateTimePicker, row, objValue, draggable);
                    break;
                case "NUMBER":
                    NumericUpDown numericUpDown = new NumericUpDown();
                    AutoStimControl = CreateStimWfNumericUpDown(numericUpDown, row, objValue, draggable);
                    break;
                default:
                    TextBox txt = new TextBox();
                    AutoStimControl = CreateStimWfTextBox(txt, row, objValue, draggable);
                    break;
            }
        }
        /// <summary>
        /// 根据XML生成控件
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="objValue"></param>
        /// <param name="draggable"></param>
        public CreateStimControl(XElement xElement, Object objValue = null, bool draggable = false)
        {
            ////获取控件类型 STIM.WinFormUI.ExtControl.StimWfTextBox
            //Type type = Type.GetType((string)xElement.Attribute("ControlType"));
            ////根据控件类型自动创建相应的控件
            //Control control = (Control)Activator.CreateInstance(type);

            string type = (string)xElement.Attribute("ControlType");
            switch (type)
            {
                case "TextBox":
                    TextBox textBox = new TextBox();
                    AutoStimControl = CreateStimWfTextBox(textBox, xElement, objValue, draggable);
                    break;
                case "DateTimePicker":
                    DateTimePicker dateTimePicker = new DateTimePicker();
                    AutoStimControl = CreateStimWfDateTimePicker(dateTimePicker, xElement, objValue, draggable);
                    break;
                case "NumericUpDown":
                    NumericUpDown numericUpDown = new NumericUpDown();
                    AutoStimControl = CreateStimWfNumericUpDown(numericUpDown, xElement, objValue, draggable);
                    break;
                case "CheckBox":
                    CheckBox checkBox = new CheckBox();
                    AutoStimControl = CreateStimWfCheckBox(checkBox, xElement, objValue, draggable);
                    break;
                case "RadioButton":
                    RadioButton radioButton = new RadioButton();
                    AutoStimControl = CreateStimWfRadioButton(radioButton, xElement, objValue, draggable);
                    break;
                case "ComboBox":
                    ComboBox comboBox = new ComboBox();
                    AutoStimControl = CreateStimWfComboBox(comboBox, xElement, objValue, draggable);
                    break;
                case "CheckedListBox":
                    CheckedListBox checkedListBox = new CheckedListBox();
                    AutoStimControl = CreateStimWfCheckedListBox(checkedListBox, xElement, objValue, draggable);
                    break;
                case "ListBox":
                    ListBox listBox = new ListBox();
                    AutoStimControl = CreateStimWfListBox(listBox, xElement, objValue, draggable);
                    break;
                case "DataGridView":
                    DataGridView dataGridView = new DataGridView();
                    AutoStimControl = CreateStimWfDataGridView(dataGridView, xElement, objValue, draggable);
                    break;
                default:
                    TextBox txt = new TextBox();
                    AutoStimControl = CreateStimWfTextBox(txt, xElement, objValue, draggable);
                    break;
            }
        }

        #region ===根据控件类型创建相应的控件===

        /// <summary>
        /// 创建Stim控件基类
        /// </summary>
        /// <param name="control"></param>
        /// <param name="objAttribute"></param>
        /// <returns></returns>
        private StimControl CreateStimBasic(Control control, Object objAttribute)
        {
            StimControl stimControl = null;
            //根据XML生成控件
            if (objAttribute.GetType().Name.Equals("XElement"))
            {
                XElement xElement = (XElement)objAttribute;
                stimControl = new StimControl(control)
               {
                   Name = (string)xElement.Attribute("Column_Name"),
                   Location = new Point((int)xElement.Attribute("X"), (int)xElement.Attribute("Y")),
                   Width = (int)xElement.Attribute("W"),
                   Height = (int)xElement.Attribute("H"),
                   Visible = (bool)xElement.Attribute("Visible"),
                   //Enabled = (bool)xElement.Attribute("Enabled"),
                   //TLP={CellBorderStyle=TableLayoutPanelCellBorderStyle.None},
                   lblFile =
                   {
                       Text = xElement.Element("Lable").Value != "" ? xElement.Element("Lable").Value : (string)xElement.Attribute("Column_Name")
                   },
                   DataFile =
                   {
                       Enabled = (bool)xElement.Attribute("Enabled"),
                       Width = (int)xElement.Element("DataControl").Attribute("W"),
                       Height = (int)xElement.Element("DataControl").Attribute("H")
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
        /// 创建Stim TextBox
        /// </summary>
        /// <param name="control"></param>
        /// <param name="objAttribute"></param>
        /// <param name="objValue"></param>
        /// <param name="draggable"></param>
        /// <returns></returns>
        private StimControl CreateStimWfTextBox(TextBox control, Object objAttribute, Object objValue, bool draggable)
        {
            //TODO 数据控件的处理操作 control.Text = "test";
            control.Text = objValue == null ? "" : (objValue.ToString() == "" ? "" : objValue.ToString());
            StimControl stimControl = CreateStimBasic(control, objAttribute);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        /// <summary>
        /// 创建Stim DateTimePicker
        /// </summary>
        /// <param name="control"></param>
        /// <param name="objAttribute"></param>
        /// <param name="objValue"></param>
        /// <param name="draggable"></param>
        /// <returns></returns>
        private StimControl CreateStimWfDateTimePicker(DateTimePicker control, Object objAttribute, Object objValue, bool draggable)
        {
            //TODO 数据控件的处理操作 control.Value = DateTime.Now.AddDays();
            control.Value = objValue == null ? DateTime.Now : (objValue.ToString() == "" ? DateTime.Now : (DateTime)objValue);
            StimControl stimControl = CreateStimBasic(control, objAttribute);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        private StimControl CreateStimWfNumericUpDown(NumericUpDown control, Object objAttribute, Object objValue, bool draggable)
        {
            //TODO 数据控件的处理操作 control.Value = 1;
            control.Maximum = decimal.MaxValue;
            control.DecimalPlaces = 2;
            control.Value = objValue == null ? 0 : (objValue.ToString() == "" ? 0 : decimal.Parse(objValue.ToString()));
            StimControl stimControl = CreateStimBasic(control, objAttribute);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        private StimControl CreateStimWfCheckBox(CheckBox control, Object objAttribute, Object objValue, bool draggable)
        {
            //TODO 数据控件的处理操作 control.Checked = true;
            //control.Checked = !objValue==null&& (bool)objValue;
            StimControl stimControl = CreateStimBasic(control, objAttribute);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        private StimControl CreateStimWfRadioButton(RadioButton control, Object objAttribute, Object objValue, bool draggable)
        {
            //TODO 数据控件的处理操作 control.Checked = true;
            //control.Checked = !objValue==null&& (bool)objValue;
            StimControl stimControl = CreateStimBasic(control, objAttribute);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        private StimControl CreateStimWfComboBox(ComboBox control, Object objAttribute, Object objValue, bool draggable)
        {
            //TODO 数据控件的处理操作 control.DropDownStyle = ComboBoxStyle.DropDownList;
            if (objAttribute.GetType().Name.Equals("XElement"))
            {
                XElement xElement = (XElement)objAttribute;
                control.DropDownStyle = ComboBoxStyle.DropDownList;
                var dataSource = xElement.Element("DataRule").Attribute("DataSource").Value;
                JObject jObject = JObject.Parse(dataSource);//{'Y':'True','N':'False'}
                DataTable dt = new DataTable();
                dt.Columns.Add("Value", typeof(string));
                dt.Columns.Add("Display", typeof(string));
                foreach (var item in jObject)
                {
                    dt.Rows.Add(item.Key, item.Value);
                }
                control.ValueMember = "Value";
                control.DisplayMember = "Display";
                control.DataSource = dt;
            }
            StimControl stimControl = CreateStimBasic(control, objAttribute);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        private StimControl CreateStimWfCheckedListBox(CheckedListBox control, Object objAttribute, Object objValue, bool draggable)
        {
            //TODO 数据控件的处理操作 control.SelectionMode = SelectionMode.MultiExtended;
            //control.Text = (string)objValue;
            StimControl stimControl = CreateStimBasic(control, objAttribute);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        private StimControl CreateStimWfListBox(ListBox control, Object objAttribute, Object objValue, bool draggable)
        {
            //TODO 数据控件的处理操作 control.SelectionMode = SelectionMode.One;
            //control.Text = (string)objValue;
            StimControl stimControl = CreateStimBasic(control, objAttribute);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        private StimControl CreateStimWfDataGridView(DataGridView control, Object objAttribute, Object objValue, bool draggable)
        {
            //TODO 数据控件的处理操作 control.AutoSize = true;
            //control.DataSource = objValue;
            StimControl stimControl = CreateStimBasic(control, objAttribute);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        #endregion
    }
}
