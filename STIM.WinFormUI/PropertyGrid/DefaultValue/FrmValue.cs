using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace STIM.WinFormUI.PropertyGrid
{
    public partial class FrmValue : Form
    {
        public ValueObject valueObject=new ValueObject();
        public FrmValue()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 0,文本；1,系统变量；2,sql语句
        /// </summary>
        /// <param name="_DataSouce"></param>
        public FrmValue(object _DataSouce)
        {
            InitializeComponent();
            if (_DataSouce != null)
            {
                this.valueObject = _DataSouce as ValueObject;
            }
        }
        private void FrmValue_Load(object sender, EventArgs e)
        {
            Item.SysValue sysVal = new Item.SysValue();
            CBBApp.DataSource = sysVal.ValueList;
            CBBApp.DisplayMember = "txt";
            CBBApp.ValueMember = "val";

            RadioTxt.CheckedChanged += new EventHandler(Radio_CheckedChanged);
            RadioApp.CheckedChanged += new EventHandler(Radio_CheckedChanged);
            RadioSQL.CheckedChanged += new EventHandler(Radio_CheckedChanged);

            if (this.valueObject != null)
            {
                switch (this.valueObject.ValueType)
                {
                    case "0": RadioTxt.Checked = true; break;
                    case "1": RadioApp.Checked = true; break;
                    case "2": RadioSQL.Checked = true; break;
                }
                txtValue.Text = this.valueObject.ValueStr;
                CBBApp.SelectedValue = this.valueObject.ValueApp;
                txtSql.Text = this.valueObject.ValueSql;
            }
        }
        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton temp = sender as RadioButton;
            if(temp.Checked)
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is RadioButton&& !ctrl.Name.Equals(temp.Name))
                    {
                        ((RadioButton)ctrl).Checked = false;
                    }
                }

            panelCbb.Visible = RadioApp.Checked;
            panelSql.Visible = RadioSQL.Checked;
            panelTxt.Visible = RadioTxt.Checked;
             
            }
        } 

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (RadioTxt.Checked)
            { 
                this.valueObject.ValueType="0";
                this.valueObject.ValueStr=txtValue.Text;
                this.valueObject.ValueApp = string.Empty;
                this.valueObject.ValueSql = string.Empty;
            }
            else if(RadioApp.Checked)
            {
                this.valueObject.ValueType = "1";
                this.valueObject.ValueApp = CBBApp.SelectedValue.ToString();
                this.valueObject.ValueStr = string.Empty;
                this.valueObject.ValueSql = string.Empty;
            }
            else if (RadioSQL.Checked)
            {
                this.valueObject.ValueType = "2";
                this.valueObject.ValueSql = txtSql.Text;
                this.valueObject.ValueApp = string.Empty;
                this.valueObject.ValueStr = string.Empty;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

  

        
    }
}
