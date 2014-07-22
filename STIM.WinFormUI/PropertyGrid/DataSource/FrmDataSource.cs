// ***********************************************************************
// Assembly         : STIM.WinFormUI
// Author           : 席
// Created          : 2014-07-09
//
// Last Modified By : 席
// Last Modified On : 2014-07-09
// ***********************************************************************
// <copyright file="FrmDataSource.cs" company="华润医药商业">
//     Copyright (c) 华润医药商业. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using STIM.NativePropGrid;
using System.Web.Script.Serialization;
using System.Text;
using System.Windows.Forms;

namespace STIM.WinFormUI.PropertyGrid
{
    public partial class FrmDataSource : Form
    {
        public object DataSouce;
        private List<TxtValObject> list=new List<TxtValObject>();
        public FrmDataSource()
        {
            InitializeComponent();
        }
        public FrmDataSource(object _DataSouce)
        {
            InitializeComponent();
            this.DataSouce = _DataSouce;
            if (_DataSouce != null)
            {
                this.list = _DataSouce as List<TxtValObject>;
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            DataSouce = list;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FrmDataSource_Load(object sender, EventArgs e)
        {
            if(list.Count>0)
            {
                DataGridTxtVal.DataSource = list;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TxtValObject entity=new TxtValObject(txtKey.Text,txtValue.Text);
            if (!list.Exists(x => x.Val.ToLower() == txtKey.Text.ToLower()))
            {
                list.Add(entity);
                //遇到奇怪的问题，必须这么做先绑定付空，再重新绑定数据源
                DataGridTxtVal.DataSource = new List<TxtValObject>();
                DataGridTxtVal.DataSource = list;
                
                txtKey.Text=string.Empty;
                txtValue.Text = string.Empty;

            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DataGridTxtVal.SelectedRows.Count > 0)
            {
                DataGridViewRow temp = DataGridTxtVal.SelectedRows[0];
                list.RemoveAll(x => x.Val.ToLower() == temp.Cells["val"].Value.ToString().ToLower());
                //遇到奇怪的问题，必须这么做先绑定付空，再重新绑定数据源
                DataGridTxtVal.DataSource = new List<TxtValObject>();
                DataGridTxtVal.DataSource = list;

                /*var json = new JavaScriptSerializer();
                string data = json.Serialize(list);
                richTxt.Text = data.ToString();*/
            }
        }
    }
}
