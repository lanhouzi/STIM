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
    public partial class CheckBoxGroup : UserControl
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
        public CheckBoxGroup()
        {
            InitializeComponent();
        }

        private void InitUI()
        {
            this.FLP.Controls.Clear();
            if (DataSource == null)
            {
                CheckBox cb = new CheckBox();
                this.FLP.Controls.Add(cb);
            }
            else
            {
                foreach (TxtValObject temp in DataSource)
                {
                    CheckBox cb = new CheckBox()
                    {
                        Tag = temp,
                        Text = temp.Txt,
                        Size = new Size(temp.Txt.Length*18+15, 23),
                        Margin = new System.Windows.Forms.Padding(0)
                    };
                    this.FLP.Controls.Add(cb); 
                    cb.Show();
                }
            }
        }
        private string GetValue()
        {
            string val = string.Empty;
            foreach (Control ctrl in this.FLP.Controls)
            {
                if (ctrl is CheckBox)
                {
                    CheckBox cb = ctrl as CheckBox;
                    if (cb.Checked)
                    {
                        val+=((TxtValObject)cb.Tag).Val.ToString()+",";
                    }
                }
            }
            val = val.TrimEnd(',');
            return val;
        }
        private void SetValue(string tempObj)
        {
            foreach (Control ctrl in this.FLP.Controls)
            {
                if (ctrl is CheckBox)
                {
                    CheckBox cb = ctrl as CheckBox;
                    TxtValObject temp = ctrl.Tag as TxtValObject;
                    if (temp != null )
                    {
                        tempObj = "," + tempObj + ",";
                        string val = "," + temp.Val.ToString().Trim() + ",";
                        if (tempObj.IndexOf(val) > -1)
                        {
                            cb.Checked = true;
                        }
                    }
                }
            }
        }
        
    }
}
