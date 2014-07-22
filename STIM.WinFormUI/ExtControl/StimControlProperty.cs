using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using STIM.WinFormUI.PropertyGrid;
using STIM.NativePropGrid;
namespace STIM.WinFormUI.ExtControl
{
    public delegate void ValueChange(string newValue);
    public delegate void ValueObjectChange(PropertyGrid.ValueObject newValue);

    public class StimControlProperty
    {
        public event ValueChange TextChangeHandler = null;
        public event ValueChange TypeChangeHandler = null;
        public event ValueChange ColumnWidthChangeHandler = null;
        public event ValueObjectChange ValueChangeHandler = null;
        #region 设计
        private string _text;
        private PropertyGrid.ValueObject _value;
        private PropertyGrid.CheckValueObject _checkRegular=null;
        private int _type = 0;
        private string _name;
        private List<TxtValObject> _DataSource;
        private PropertyGrid.Select.ValueObject _FrmDataObject = null;
        private bool _ControlVisible=true;
        private bool _ControlEnable = true;
        private bool _ControlRequired = false;
        private int _ControlTop;
        private int _ControlLeft;
        private int _ControlHeight=29;
        private int _ControlWidth=250;
        private int _ColumnWidth = 80;
        private int _TabIndex = 0;
        //列表页界面
        private bool _ListConditionFlag = false;
        private bool _ListShowFlag = false;

        #endregion 

        #region 设计
        [Description("对象名称"), Localizable(true), ReadOnlyAttribute(true), Category("设计")]
        [NativeNameAttibute("1 名称")]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [Description("标签值"), Localizable(true), Category("设计")]
        [NativeNameAttibute("2 标签值")]
        public string Text 
        {
            get { return _text; }
            set
            {
                _text = value;
                if (TextChangeHandler != null)
                    TextChangeHandler(_text);
            }
        }
        
        [Description("标签值宽度"), Localizable(true), Category("设计")]
        [NativeNameAttibute("3 标签宽度")]
        public int ColumnWidth 
        {
            get { return _ColumnWidth; }
            set
            {
                _ColumnWidth = value;
                if (ColumnWidthChangeHandler != null)
                    ColumnWidthChangeHandler(_ColumnWidth.ToString());
            }
        }

        //[Description("文本框默认值类型"), Localizable(true), Category("设计")]
        //[NativeNameAttibute("3 默认值类型")]
        //[TypeConverter(typeof(PropertyGrid.EnumConverter))]
        //public PropertyGrid.EnumFile.AppDataValue ValueType
        //{
        //    get;
        //    set;

        //}
        [Description("默认值，支持三种方式:常量文本、系统变量、SQL语句"), Category("设计"), EditorAttribute(typeof(PropertyGrid.ValueDialog), typeof(System.Drawing.Design.UITypeEditor))]
        [NativeNameAttibute("4 默认值")]
        public PropertyGrid.ValueObject Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (ValueChangeHandler != null)
                    ValueChangeHandler(_value);
            }
        }

        [Description("填值控件的类型"), Category("设计"), TypeConverter(typeof(PropertyGrid.ComboBoxItem))]
        [NativeNameAttibute("5 输入框类型")]
        public int ControlType
        {
            get { return _type; }
            set
            {
                _type = value;
                if (TypeChangeHandler != null)
                    TypeChangeHandler(_type.ToString());
            }
        }

        [Description("是否页面可见"), DefaultValueAttribute(1),Category("设计"), TypeConverter(typeof(PropertyGrid.BoolItem))]
        [NativeNameAttibute("6 可见性")]
        public int ControlVisible { get { return _ControlVisible == true ? 1 : 0; } set { _ControlVisible = (value == 1 ? true : false); } }
        
        [Description("是否页面可用"), DefaultValueAttribute("是"), Category("设计"), TypeConverter(typeof(PropertyGrid.BoolItem))]
        [NativeNameAttibute("7 可用性")]
        public int ControlEnable { get { return _ControlEnable == true ? 1 : 0; } set { _ControlEnable = (value == 1 ? true : false); } }
        
        [Description("是否必填项"), Category("设计"), TypeConverter(typeof(PropertyGrid.BoolItem))]
        [NativeNameAttibute("8 必填项")]
        public int ControlRequired { get { return _ControlRequired == true ? 1 : 0; } set { _ControlRequired = (value == 1 ? true : false); } }
        
        [Description("Tab键顺序"), Category("设计")]
        [NativeNameAttibute("9 Tab键顺序")]
        public int TabIndex { get { return _TabIndex; } set { _TabIndex = value; } }
        
        #endregion

        #region 布局
        [Description("居顶"), Localizable(true), ReadOnlyAttribute(true), Category("布局")]
        [NativeNameAttibute("1 居顶")]
        public int ControlTop { get { return _ControlTop; } set { _ControlTop = value; } }
        [Description("居左"), Localizable(true), ReadOnlyAttribute(true), Category("布局")]
        [NativeNameAttibute("2 居左")]
        public int ControlLeft { get { return _ControlLeft; } set { _ControlLeft = value; } }
        [Description("控件的高度"), Localizable(true), ReadOnlyAttribute(true), Category("布局")]
        [NativeNameAttibute("3 高度")]
        public int ControlHeight { get { return _ControlHeight; } set { _ControlHeight = value; } }
        [Description("控件的宽度"), Localizable(true), ReadOnlyAttribute(true), Category("布局")]
        [NativeNameAttibute("4 宽度")]
        public int ControlWidth { get { return _ControlWidth; } set { _ControlWidth = value; } }
        #endregion

        #region 数据源
        /*[Description("数据源"), Localizable(true), Category("数据"), EditorAttribute(typeof(PropertyGrid.ListItemDialog), typeof(System.Drawing.Design.UITypeEditor))]
        [NativeNameAttibute("数据源")]
        public string ControlDataSource { get; set; }*/
        [Description("数据源"), Localizable(true), Category("数据"), EditorAttribute(typeof(PropertyGrid.ListItemDialog), typeof(System.Drawing.Design.UITypeEditor))]
        [NativeNameAttibute("数据源")]
        public List<TxtValObject> ControlDataSource 
        {
            get
            {
                return _DataSource;
            }
            set
            {
                _DataSource = value;
                if (TypeChangeHandler != null)
                    TypeChangeHandler(_type.ToString());
            }
        }

        [Description("通过窗口查询数据，选择行记录来获取值"), Localizable(true), Category("数据"), EditorAttribute(typeof(PropertyGrid.Select.FrmDialog), typeof(System.Drawing.Design.UITypeEditor))]
        [NativeNameAttibute("窗体数据")]
        public PropertyGrid.Select.ValueObject FrmDataObject
        {
            get
            {
                return _FrmDataObject;
            }
            set
            {
                _FrmDataObject = value;
            }
        }
        #endregion

        #region 验证规则
        [Description("验证"), Localizable(true), Category("验证"), EditorAttribute(typeof(PropertyGrid.CheckValueDialog), typeof(System.Drawing.Design.UITypeEditor))]
        [NativeNameAttibute("验证规则")]
        public PropertyGrid.CheckValueObject CheckRegular
        {
            get
            {
                return _checkRegular;
            }
            set
            {
                _checkRegular = value;
            }
        }

        #endregion

        #region 列表页相关设计
        [Description("是否列表界面查询项"), Category("列表界面属性"), TypeConverter(typeof(PropertyGrid.BoolItem))]
        [NativeNameAttibute("1 查询项")]
        public int ListConditionFlag { get { return _ListConditionFlag == true ? 1 : 0; } set { _ListConditionFlag = (value == 1 ? true : false); } }

        [Description("是否为列表界面显示项"), Category("列表界面属性"), TypeConverter(typeof(PropertyGrid.BoolItem))]
        [NativeNameAttibute("2 显示项")]
        public int ListShowFlag { get { return _ListShowFlag == true ? 1 : 0; } set { _ListShowFlag = (value == 1 ? true : false); } }
        
        #endregion
        /*[Description("文件打开对话框"), Localizable(true), ReadOnlyAttribute(true), Category("属性"), EditorAttribute(typeof(PropertyGrid.ListItemDialog), typeof(System.Drawing.Design.UITypeEditor))]
        [NativeNameAttibute("文本")]
        public string fileName { get; set; }
        [Description("布尔"), Category("属性"), TypeConverter(typeof(PropertyGrid.BoolItem))]
        public int flag { get; set; }
        [Description("类型"), Category("属性"), TypeConverter(typeof(PropertyGrid.ComboBoxItem))]
        public int str { get; set; }
        */
    }
}
