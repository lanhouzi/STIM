using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using STIM.WinFormUI.PropertyGrid;
using STIM.NativePropGrid;
using System.Collections;

namespace STIM.WinFormUI.ExtControl
{
    public partial class StimControl : UserControl
    {
        public Control DataFile { get; set; }
        public object objValue{ get; set; }//控件的值,主要用于内容编辑页面
        public StimControlProperty property = new StimControlProperty();

        private string _Name;
        private int _Top;
        private int _Left;
        private int _Height;
        private int _Width;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; base.Name = _Name; this.property.Name = _Name; }
        }
        public int Top 
        {
            get { return _Top; }
            set { _Top = value; base.Top = _Top; TLP.Top = _Top; this.property.ControlTop = _Top; } 
        }
        public int Left
        {
            get { return _Left; }
            set { _Left = value; base.Left = _Left; TLP.Left = _Left; this.property.ControlLeft = _Left; }
        }
        public int Height
        {
            get { return _Height; }
            set { _Height = value; base.Height = _Height; TLP.Height = _Height; this.property.ControlHeight = _Height; }
        }
        public int Width
        {
            get { return _Width; }
            set { _Width = value; base.Width = _Width; TLP.Width = _Width; this.property.ControlWidth = _Width; }
        }

        public event EventHandler Click;

        public StimControl()
        {
            InitializeComponent();

        }
        public StimControl(Control dataFile)
            : this()
        {
            AutoSize = false;
            DataFile = dataFile;
            DataFile.Name = "dataFile";
            TLP.AutoSize = false;
            TLP.Controls.Add(DataFile, 1, 0);

            ChildDraggableToFather();
            property.TextChangeHandler += new ValueChange(property_TextChangeHandler);
            property.TypeChangeHandler += new ValueChange(property_TypeChangeHandler);
            property.ColumnWidthChangeHandler += new ValueChange(property_ColumnWidthChangeHandler);
            property.ValueChangeHandler += new ValueObjectChange(property_ValueChangeHandler);
            
            this.LocationChanged+=new EventHandler(StimControl_LocationChanged);

        }
        
        /// <summary>
        /// 把自控件的拖动属性赋给父控件
        /// </summary>
        private void ChildDraggableToFather()
        {
            Control[] controls = { TLP, lblFile }; 
            foreach (Control item in controls)
            {
                item.MouseDown += item_MouseDown;
                item.MouseUp += item_MouseUp;
                //item.MouseMove += item_MouseMove;
                item.Click += item_MouseClick;
            }
        }
        void item_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }
        void item_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }
        void item_MouseMove(object sender, MouseEventArgs e)
        {
            //OnMouseMove(e);
        }
        //解决属性切换
        void item_MouseClick(object sender, EventArgs e)
        {
            OnClick(e);
            if (Click != null) Click(this, e);
        }
       
        public void property_TextChangeHandler(string text)
        {
            this.lblFile.Text=text;
        }
        public void property_TypeChangeHandler(string type)
        {
            var obj = new Control();
            switch (type)
            {
                case "0":
                    obj = new TextBox();
                    if (objValue != null)
                    {
                        obj.Text = objValue.ToString();
                    }
                    break;
                case "1":
                    obj = new DateTimePicker();
                    (obj as DateTimePicker).Width = 120;
                    (obj as DateTimePicker).Value = objValue == null ? DateTime.Now : (objValue.ToString() == "" ? DateTime.Now : (DateTime)objValue);
                    break;
                case "2":
                    obj = new NumericUpDown();
                    (obj as NumericUpDown).Maximum = decimal.MaxValue;
                    (obj as NumericUpDown).DecimalPlaces = 2;
                    (obj as NumericUpDown).Value = objValue == null ? 0 : (objValue.ToString() == "" ? 0 : decimal.Parse(objValue.ToString()));
                    break;
                case "3":
                    obj = new CheckBox(); 
                    if (objValue != null)
                    {
                        (obj as CheckBox).Checked = objValue.ToString().Equals("Y");
                    }
                    //((CheckBox)obj).DataSource = this.property.ControlDataSource;
                    break;
                case "4":
                    obj = new RadioButton();
                    //((RadioButton)obj).DataSource = this.property.ControlDataSource;
                    break;
                case "5":
                    obj = new ComboBox();
                    (obj as ComboBox).DataSource = this.property.ControlDataSource;
                    (obj as ComboBox).DisplayMember = "txt";
                    (obj as ComboBox).ValueMember = "val";
                    if (objValue != null)
                    {
                        (obj as ComboBox).SelectedValue = objValue;
                    }
                    break;
                case "6":
                    obj = new CheckBoxGroup();
                    (obj as CheckBoxGroup).DataSource = this.property.ControlDataSource;
                    if (objValue != null)
                    {
                        (obj as CheckBoxGroup).Value = objValue.ToString();
                    }
                    break;
                case "7":
                    obj = new ListBox();
                    (obj as ListBox).Height = 25;
                    (obj as ListBox).DataSource = this.property.ControlDataSource;
                    (obj as ListBox).DisplayMember = "txt";
                    (obj as ListBox).ValueMember = "val";
                    break;
                case "8":
                    obj = new RadioButtonGroup();
                    (obj as RadioButtonGroup).DataSource = this.property.ControlDataSource;
                    if (objValue != null)
                    {
                        (obj as RadioButtonGroup).Value = objValue.ToString();
                    }
                    break;
                case "9":
                    obj = new TextBoxFrm();
                    (obj as TextBoxFrm).valueObject = this.property.FrmDataObject;
                    if (objValue != null)
                    {
                        obj.Text = objValue.ToString();
                    }
                    break;
                default:
                    obj = new TextBox();
                    if (objValue != null)
                    {
                        obj.Text = objValue.ToString();
                    }
                    break;
            }
            TLP.Controls.RemoveAt(1);
            obj.Name = "dataFile";
            /*obj.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
| System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom)));*/
            obj.Enabled = this.property.ControlEnable == 1;
            obj.TabIndex = this.property.TabIndex;
            obj.Dock = System.Windows.Forms.DockStyle.Fill;
            DataFile = obj;
            TLP.Controls.Add(obj, 1, 0);
            
        }

        
        public void property_ColumnWidthChangeHandler(string val)
        {
            this.TLP.ColumnStyles[0].Width = float.Parse(val);
        }
        public void property_ValueChangeHandler(PropertyGrid.ValueObject newValue)
        {
            if (DataFile is TextBox && objValue == null && newValue != null )
            {
                this.DataFile.Text = newValue.ValueType == "0" ? newValue.ValueStr : "";
            } 
            /*else if (DataFile is RadioButtonGroup && objValue == null && newValue != null)
            {
               ((RadioButtonGroup)this.DataFile).DataSource = newValue;
            }*/
        }
        public void StimControl_LocationChanged(object sender, EventArgs e)
        {
            this.property.ControlTop = this.Location.Y;
            this.property.ControlLeft = this.Location.X;
        }

       
    }
}
