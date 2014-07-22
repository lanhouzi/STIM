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
    public partial class FrmCheckValue : Form
    {
        public CheckValueObject checkValueObject = new CheckValueObject();
        public FrmCheckValue()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 0,系统方法；1,正则表达式；2,sql语句
        /// </summary>
        /// 
        public FrmCheckValue(object _DataSouce)
        {
            InitializeComponent();
            if (_DataSouce != null)
            {
                this.checkValueObject = _DataSouce as CheckValueObject;
            }
        } 
        private void FrmCheckValue_Load(object sender, EventArgs e)
        {
            Item.SYSMethod sysMethod = new Item.SYSMethod();
            CBBApp.DataSource = sysMethod.MethodList;
            CBBApp.DisplayMember = "txt";
            CBBApp.ValueMember = "val";
            //可用系统参数提示
            string temp = string.Empty;
            Item.SysValue sysVal = new Item.SysValue();
            foreach (PropertyGrid.TxtValObject obj in sysVal.ValueList)
            {
                temp += obj.Txt+"  :"+obj.Val+"\n";
            }
            lblInf.Text = temp;

            RadioApp.CheckedChanged += new EventHandler(Radio_CheckedChanged);
            RadioRegular.CheckedChanged += new EventHandler(Radio_CheckedChanged);
            RadioSQL.CheckedChanged += new EventHandler(Radio_CheckedChanged);

            if (this.checkValueObject != null)
            {
                switch (this.checkValueObject.ValueType)
                {
                    case "0": RadioApp.Checked = true; break;
                    case "1": RadioRegular.Checked = true; break;
                    case "2": RadioSQL.Checked = true; break;
                }
                CBBApp.SelectedValue = this.checkValueObject.ValueApp;
                txtRegular.Text = this.checkValueObject.ValueRegular;
                txtSql.Text = this.checkValueObject.ValueSql;
            }
        }
        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton temp = sender as RadioButton;
            if (temp.Checked)
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is RadioButton && !ctrl.Name.Equals(temp.Name))
                    {
                        ((RadioButton)ctrl).Checked = false;
                    }
                }

                panelApp.Visible = RadioApp.Checked;
                panelSql.Visible = RadioSQL.Checked;
                panelRegular.Visible = RadioRegular.Checked;
                if (RadioSQL.Checked)
                {
                    panelInf.Visible = true;
                    this.Height = 465;
                }
                else
                {

                    panelInf.Visible = false;
                    this.Height = 280;
                }
            }
        } 
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (RadioRegular.Checked)
            {
                this.checkValueObject.ValueType = "1";
                this.checkValueObject.ValueRegular = txtRegular.Text;
                this.checkValueObject.ValueApp = string.Empty;
                this.checkValueObject.ValueSql = string.Empty;
            }
            else if (RadioApp.Checked)
            {
                this.checkValueObject.ValueType = "0";
                this.checkValueObject.ValueApp = CBBApp.SelectedValue.ToString();
                this.checkValueObject.ValueRegular = string.Empty;
                this.checkValueObject.ValueSql = string.Empty;
            }
            else if (RadioSQL.Checked)
            {
                this.checkValueObject.ValueType = "2";
                this.checkValueObject.ValueSql = txtSql.Text;
                this.checkValueObject.ValueApp = string.Empty;
                this.checkValueObject.ValueRegular = string.Empty;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
