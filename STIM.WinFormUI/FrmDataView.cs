﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace STIM.WinFormUI
{
    public partial class FrmDataView : Form
    {
        /// <summary>
        /// 表名
        /// </summary>
        string TableName = "GOODS_EXT";
        List<string> IsPkList = new List<string>();
        BLL.STIM_CONFIG _bll = new BLL.STIM_CONFIG();
        Model.STIM_CONFIG _model = new Model.STIM_CONFIG();

        public FrmDataView()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
        }

        private void FrmDataView_Load(object sender, EventArgs e)
        {
            //_model = _bll.GetModel(TableName);
            _model.DATAGRIDVIEW_XML = XDocument.Load(Application.StartupPath + "\\DetailForm.xml").ToString();
            //按照自定义配置布局控件
            if (_model != null && !string.IsNullOrEmpty(_model.DATAGRIDVIEW_XML))
            {
                XDocument xDoc = XDocument.Parse(_model.DATAGRIDVIEW_XML, LoadOptions.None);
                //Lambda
                IEnumerable<XElement> xElements = xDoc.Root.Elements().Select(el => el);
                foreach (XElement item in xElements)
                {
                    var dgvCol = new DataGridViewTextBoxColumn
                    {
                        Name = (string)item.Attribute("Column_Name"),
                        HeaderText = (string)item.Attribute("Column_Name"),
                        DataPropertyName = (string)item.Attribute("Column_Name"),
                        ReadOnly = true
                    };
                    dgvData.Columns.Add(dgvCol);
                }
            }
            //系统自动有序布局控件
            else
            {
                //表结构
                DataSet dsStruct = _bll.GetTableInformation(TableName);
                foreach (DataRow row in dsStruct.Tables[0].Rows)
                {
                    var dgvCol = new DataGridViewTextBoxColumn
                    {
                        Name = (string)row["Column_Name".ToUpper()],
                        HeaderText = (string)row["Column_Name".ToUpper()],
                        DataPropertyName = (string)row["Column_Name".ToUpper()],
                        ReadOnly = true,
                        //主键
                        //Tag = row["ISPK"].ToString().Equals("Y") ? "ISPK" : ""
                    };
                    dgvData.Columns.Add(dgvCol);

                    if (row["ISPK"].ToString().Equals("Y"))
                    {
                        IsPkList.Add(dgvCol.Name);
                    }
                }
            }
            LoadData();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (-1 < e.RowIndex)
            {
                DataGridViewRow dgvRow = dgvData.Rows[e.RowIndex];
                FrmDetailView frm = new FrmDetailView("Modify", TableName, dgvRow);
                frm.ShowDialog();
                LoadData();
            }
        }

        private void tsMenuAdd_Click(object sender, EventArgs e)
        {
            FrmDetailView frm = new FrmDetailView("Add", TableName);
            frm.ShowDialog();
            LoadData();
        }

        private void tsMenuModify_Click(object sender, EventArgs e)
        {
            if (dgvData.CurrentRow != null)
            {
                int rowIndex = dgvData.CurrentRow.Index;
                if (-1 < rowIndex)
                {
                    DataGridViewRow dgvRow = dgvData.Rows[rowIndex];
                    FrmDetailView frm = new FrmDetailView("Modify", TableName, dgvRow);
                    frm.ShowDialog();
                    LoadData();
                }
            }
        }

        private void tsMenuDelete_Click(object sender, EventArgs e)
        {
            DialogResult resault = MessageBox.Show("确定要删除选中的记录吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (resault == DialogResult.OK)
            {
                StringBuilder sbDeleteWhere = new StringBuilder();
                StringBuilder sbDeleteValue = new StringBuilder();
                foreach ( DataGridViewRow row in dgvData.Rows)
                {
                    //选中的行
                    if(((DataGridViewCheckBoxCell)row.Cells["rowChecker"]).Selected)
                    {
                        
                    }
                }
                //foreach (DataGridViewColumn item in dgvData.Columns)
                //{

                //    if (Equals(item.Tag, "ISPK"))
                //    {
                //        sbDeleteWhere.AppendFormat (item.Name='{0}')
                //    }
                //    sbDeleteWhere.Append("||" + item);
                //}
                //sbDeleteWhere.Remove(0, 2);//移出头部的||

                //foreach (DataGridViewRow dgvr in dgvData.Rows)
                //{
                //    DataGridViewCheckBoxCell dgvckbex = (DataGridViewCheckBoxCell)dgvr.Cells["rowChecker"];
                //    if (dgvckbex.Selected)
                //    {
                //        sbDeleteValue.Append(",'");
                //        foreach (string item in ISPKColumnList)
                //        {
                //            sbDeleteValue.Append(dgvr.Cells[item].Value.ToString());
                //        }
                //        sbDeleteValue.Append("'");
                //    }
                //}
                LoadData();
            }
        }

        private void tsMenuRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void LoadData()
        {
            StringBuilder sbWhere = new StringBuilder("ROWNUM<=500");
            dgvData.DataSource = _bll.GetDataList(TableName, sbWhere.ToString()).Tables[0].DefaultView;
        }
    }
}
