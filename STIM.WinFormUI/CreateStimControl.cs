using System.Data;
using STIM.WinFormUI.ExtControl;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using STIM.Utilities;

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
        /// <param name="draggable"></param>
        public CreateStimControl(DataRow row, bool draggable)
        {
            string dataType = row["DATA_TYPE"].ToString();
            switch (dataType)
            {
                case "DATE":
                    DateTimePicker dateTimePicker = new DateTimePicker();
                    AutoStimControl = CreateStimWfDateTimePicker(dateTimePicker, row, draggable);
                    break;
                case "NUMBER":
                    NumericUpDown numericUpDown = new NumericUpDown();
                    AutoStimControl = CreateStimWfNumericUpDown(numericUpDown, row, draggable);
                    break;
                default:
                    TextBox txt = new TextBox();
                    AutoStimControl = CreateStimWfTextBox(txt, row, draggable);
                    break;
            }
        }
        /// <summary>
        /// 根据XML生成控件
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="draggable"></param>
        public CreateStimControl(XElement xElement, bool draggable)
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
                    AutoStimControl = CreateStimWfTextBox(textBox, xElement, draggable);
                    break;
                case "DateTimePicker":
                    DateTimePicker dateTimePicker = new DateTimePicker();
                    AutoStimControl = CreateStimWfDateTimePicker(dateTimePicker, xElement, draggable);
                    break;
                case "NumericUpDown":
                    NumericUpDown numericUpDown = new NumericUpDown();
                    AutoStimControl = CreateStimWfNumericUpDown(numericUpDown, xElement, draggable);
                    break;
                case "CheckBox":
                    CheckBox checkBox = new CheckBox();
                    AutoStimControl = CreateStimWfCheckBox(checkBox, xElement, draggable);
                    break;
                case "RadioButton":
                    RadioButton radioButton = new RadioButton();
                    AutoStimControl = CreateStimWfRadioButton(radioButton, xElement, draggable);
                    break;
                case "ComboBox":
                    ComboBox comboBox = new ComboBox();
                    AutoStimControl = CreateStimWfComboBox(comboBox, xElement, draggable);
                    break;
                case "CheckedListBox":
                    CheckedListBox checkedListBox = new CheckedListBox();
                    AutoStimControl = CreateStimWfCheckedListBox(checkedListBox, xElement, draggable);
                    break;
                case "ListBox":
                    ListBox listBox = new ListBox();
                    AutoStimControl = CreateStimWfListBox(listBox, xElement, draggable);
                    break;
                case "DataGridView":
                    DataGridView dataGridView = new DataGridView();
                    AutoStimControl = CreateStimWfDataGridView(dataGridView, xElement, draggable);
                    break;
                default:
                    TextBox txt = new TextBox();
                    AutoStimControl = CreateStimWfTextBox(txt, xElement, draggable);
                    break;
            }
        }

        #region ===根据控件类型创建相应的控件===

        /// <summary>
        /// 创建Stim控件基类
        /// </summary>
        /// <param name="control"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        private StimControl CreateStimBasic(Control control, Object obj)
        {
            StimControl stimControl = null;
            //根据XML生成控件
            if (obj.GetType().Name.Equals("XElement"))
            {
                XElement xElement = (XElement)obj;
                stimControl = new StimControl(control)
               {
                   Name = (string)xElement.Attribute("Column_Name"),
                   Location = new Point((int)xElement.Attribute("X"), (int)xElement.Attribute("Y")),
                   Width = (int)xElement.Attribute("W"),
                   Height = (int)xElement.Attribute("H"),
                   Visible = (bool)xElement.Attribute("Visible"),
                   //Enabled = (bool)xElement.Attribute("Enabled"),
                   //TLP={CellBorderStyle=TableLayoutPanelCellBorderStyle.None},
                   lblFile = { Text = (string)xElement.Attribute("Column_Name") },
                   DataFile =
                   {
                       Enabled = (bool)xElement.Attribute("Enabled"),
                       Width = (int)xElement.Element("DataControl").Attribute("W"),
                       Height = (int)xElement.Element("DataControl").Attribute("H")
                   }
               };
            }
            //根据DataRow生成控件
            if (obj.GetType().Name.Equals("DataRow"))
            {
                DataRow row = (DataRow)obj;
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
        /// <param name="obj"></param>
        /// <param name="draggable"></param>
        /// <returns></returns>
        private StimControl CreateStimWfTextBox(TextBox control, Object obj, bool draggable)
        {
            //
            //TODO 数据空间的处理操作 control.Text = "test";
            //
            StimControl stimControl = CreateStimBasic(control, obj);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        /// <summary>
        /// 创建Stim DateTimePicker
        /// </summary>
        /// <param name="control"></param>
        /// <param name="obj"></param>
        /// <param name="draggable"></param>
        /// <returns></returns>
        private StimControl CreateStimWfDateTimePicker(DateTimePicker control, Object obj, bool draggable)
        {
            //
            //TODO 数据空间的处理操作 control.Value = DateTime.Now.AddDays();
            //
            StimControl stimControl = CreateStimBasic(control, obj);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        private StimControl CreateStimWfNumericUpDown(NumericUpDown control, Object obj, bool draggable)
        {
            //
            //TODO 数据空间的处理操作 control.Value = 1;
            //
            StimControl stimControl = CreateStimBasic(control, obj);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        private StimControl CreateStimWfCheckBox(CheckBox control, Object obj, bool draggable)
        {
            //
            //TODO 数据空间的处理操作 control.Checked = true;
            //
            StimControl stimControl = CreateStimBasic(control, obj);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        private StimControl CreateStimWfRadioButton(RadioButton control, Object obj, bool draggable)
        {
            //
            //TODO 数据空间的处理操作 control.Checked = true;
            //
            StimControl stimControl = CreateStimBasic(control, obj);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        private StimControl CreateStimWfComboBox(ComboBox control, Object obj, bool draggable)
        {
            //
            //TODO 数据空间的处理操作 control.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            StimControl stimControl = CreateStimBasic(control, obj);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        private StimControl CreateStimWfCheckedListBox(CheckedListBox control, Object obj, bool draggable)
        {
            //
            //TODO 数据空间的处理操作 control.SelectionMode = SelectionMode.MultiExtended;
            //
            StimControl stimControl = CreateStimBasic(control, obj);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        private StimControl CreateStimWfListBox(ListBox control, Object obj, bool draggable)
        {
            //
            //TODO 数据空间的处理操作 control.SelectionMode = SelectionMode.One;
            //
            StimControl stimControl = CreateStimBasic(control, obj);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        private StimControl CreateStimWfDataGridView(DataGridView control, Object obj, bool draggable)
        {
            //
            //TODO 数据空间的处理操作 control.AutoSize = true;
            //
            StimControl stimControl = CreateStimBasic(control, obj);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }

        #endregion
    }
}
