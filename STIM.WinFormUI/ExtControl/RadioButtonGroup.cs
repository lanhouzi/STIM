using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using STIM.WinFormUI.PropertyGrid;

namespace STIM.WinFormUI.ExtControl
{
    public partial class RadioButtonGroup : UserControl
    {
        private List<TxtValObject> _DataSource= null;
        public List<TxtValObject> DataSource
        {
            get 
            {
                return _DataSource;
            }
            set 
            {
                _DataSource = value;
                InitUI();
                
            }
        }
        public string Value
        {
            get
            {
                return GetValue();
            }
            set
            {
                SetValue(value);
            }
        }
        public RadioButtonGroup()
        {
            InitializeComponent();
        }

        private void InitUI()
        {
            this.FLP.Controls.Clear();
            if (DataSource == null)
            {
                RadioButton rb = new RadioButton();
                this.FLP.Controls.Add(rb);
            }
            else
            {
                foreach (TxtValObject temp in DataSource)
                {
                    RadioButton rb = new RadioButton()
                    {
                        Tag = temp,
                        Text = temp.Txt,
                        Size = new Size(temp.Txt.Length*18+15, 23),
                        Margin = new System.Windows.Forms.Padding(0)
                    };
                    this.FLP.Controls.Add(rb); 
                    rb.Show();
                }
            }
        }
        private string GetValue()
        {
            foreach (Control ctrl in this.FLP.Controls)
            {
                if (ctrl is RadioButton)
                {
                    RadioButton rb = ctrl as RadioButton;
                    if (rb.Checked)
                    {
                        return ((TxtValObject)rb.Tag).Val.ToString();
                    }
                }
            }
            return null;
        }
        private void SetValue(string tempObj)
        {
            foreach (Control ctrl in this.FLP.Controls)
            {
                if (ctrl is RadioButton)
                {
                    RadioButton rb = ctrl as RadioButton;
                    TxtValObject temp = ctrl.Tag as TxtValObject;
                    if (temp!=null&&temp.Val.Equals(tempObj))
                    {
                        rb.Checked = true;
                    }
                }
            }
        }
        
    }
}
