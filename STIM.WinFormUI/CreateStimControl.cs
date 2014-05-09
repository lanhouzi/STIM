using STIM.WinFormUI.ExtControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using STIM.Utilities;

namespace STIM.WinFormUI
{
    public partial class CreateStimControl
    {
        /// <summary>
        /// 根据类型自动生成的控件
        /// </summary>
        public StimControl AutoStimControl { get; set; }
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
                default:
                    TextBox txt = new TextBox();
                    AutoStimControl = CreateStimWfTextBox(txt, xElement, draggable);
                    break;
            }
        }
        /// <summary>
        /// 创建Stim控件基类
        /// </summary>
        /// <param name="control"></param>
        /// <param name="xElement"></param>
        /// <returns></returns>
        private StimControl CreateStimBasic(Control control, XElement xElement)
        {
            StimControl stimControl = new StimControl(control)
            {
                Name = (string)xElement.Attribute("ColumnName"),
                Location = new Point((int)xElement.Attribute("X"), (int)xElement.Attribute("Y")),
                Width = (int)xElement.Attribute("W"),
                Height = (int)xElement.Attribute("H"),
                Visible = (bool)xElement.Attribute("Visible"),
                Enabled = (bool)xElement.Attribute("Enabled"),
                lblFile = { Text = (string)xElement.Attribute("ColumnName") },
                DataFile =
                {
                    Enabled = (bool)xElement.Attribute("Enabled"),
                    Width = (int)xElement.Element("DataControl").Attribute("W"),
                    Height = (int)xElement.Element("DataControl").Attribute("H")
                }
            };
            return stimControl;
        }
        /// <summary>
        /// 创建Stim TextBox
        /// </summary>
        /// <param name="control"></param>
        /// <param name="xElement"></param>
        /// <param name="draggable"></param>
        /// <returns></returns>
        private StimControl CreateStimWfTextBox(TextBox control, XElement xElement, bool draggable)
        {
            //
            //TODO 数据空间的处理操作 control.Text = "test";
            //
            StimControl stimControl = CreateStimBasic(control, xElement);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }
        /// <summary>
        /// 创建Stim DateTimePicker
        /// </summary>
        /// <param name="control"></param>
        /// <param name="xElement"></param>
        /// <param name="draggable"></param>
        /// <returns></returns>
        private StimControl CreateStimWfDateTimePicker(DateTimePicker control, XElement xElement, bool draggable)
        {
            //
            //TODO 数据空间的处理操作 control.Value = DateTime.Now.AddDays();
            //
            StimControl stimControl = CreateStimBasic(control, xElement);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }
        private StimControl CreateStimWfNumericUpDown(NumericUpDown control, XElement xElement, bool draggable)
        {
            //
            //TODO 数据空间的处理操作 control.Value = 1;
            //
            StimControl stimControl = CreateStimBasic(control, xElement);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }
        private StimControl CreateStimWfCheckBox(CheckBox control, XElement xElement, bool draggable)
        {
            //
            //TODO 数据空间的处理操作 control.Checked = true;
            //
            StimControl stimControl = CreateStimBasic(control, xElement);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }
        private StimControl CreateStimWfRadioButton(RadioButton control, XElement xElement, bool draggable)
        {
            //
            //TODO 数据空间的处理操作 control.Checked = true;
            //
            StimControl stimControl = CreateStimBasic(control, xElement);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }
        private StimControl CreateStimWfComboBox(ComboBox control, XElement xElement, bool draggable)
        {
            //
            //TODO 数据空间的处理操作 control.DropDownStyle = ComboBoxStyle.DropDownList;
            //
            StimControl stimControl = CreateStimBasic(control, xElement);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }
        private StimControl CreateStimWfListBox(ListBox control, XElement xElement, bool draggable)
        {
            //
            //TODO 数据空间的处理操作 control.SelectionMode = SelectionMode.One;
            //
            StimControl stimControl = CreateStimBasic(control, xElement);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }
        private StimControl CreateStimWfDataGridView(DataGridView control, XElement xElement, bool draggable)
        {
            //
            //TODO 数据空间的处理操作 control.AutoSize = true;
            //
            StimControl stimControl = CreateStimBasic(control, xElement);
            //拖动属性
            stimControl.Draggable(draggable);
            stimControl.BringToFront();
            return stimControl;
        }
    }
}
