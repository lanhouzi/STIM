﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using STIM.Utilities;
using STIM.WinFormUI.ExtControl;
using System.Xml;

namespace STIM.WinFormUI
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// 表单布局 行
        /// </summary>
        public int layoutRow = -1;
        /// <summary>
        /// 表单布局 列
        /// </summary>
        public int layoutColumn = -1;
        /// <summary>
        /// 表单布局 坐标点
        /// </summary>
        public Point layoutPoint = new Point();

        BLL.STIM_CONFIG bll = new BLL.STIM_CONFIG();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject =this ;
            BindSingleTableList();
        }
        private void BindSingleTableList()
        {
            string strWhere = "";
            DataSet ds = bll.GetListForTreeView(strWhere);
            if (null != ds && ds.Tables.Count > 0 && null != ds.Tables[0] && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    tvSingleTableList.Nodes.Add(row["TABLE_NAME"].ToString(), row["REMARK"].ToString());
                }
            }
        }

        private void tvSingleTableList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            layoutRow = -1;
            layoutColumn = -1;
            tabPageDetail.Controls.Clear();
            Model.STIM_CONFIG model = new Model.STIM_CONFIG();
            model = bll.GetModel(e.Node.Name);
            //按照自定义配置布局控件
            if (!string.IsNullOrEmpty(model.DETAIL_FORM_XML))
            {
                DataSet ds = bll.GetTableInformation(e.Node.Name);
            }
            //系统自动有序布局控件
            else
            {
                DataSet ds = bll.GetTableInformation(e.Node.Name);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    layoutColumn++;
                    //3表示显示3列
                    if (layoutColumn % 3 == 0)
                    {
                        layoutColumn = 0;
                        layoutRow++;
                    }
                    CreatStimControl(row, true);
                }
            }
        }
        public void CreatStimControl(DataRow row, bool draggable = false)
        {
            //grpMain.Controls.Clear();
            StimWfTextBox StimTxt = new StimWfTextBox();
            StimTxt.Name = "txt" + row["COLUMN_NAME"].ToString();
            StimTxt.lblField.Text = row["COMMENTS"].ToString() + "：";
            //StimTxt.txtField.Text = row["COMMENTS"].ToString();
            StimTxt.Location = new Point(20 + layoutColumn * 300, 10 + layoutRow * 35);
            //只对更新操作生效
            //if (VoidNameEnum.Update == VoidName && null != DGVR)
            //{
            //    //给文本框绑定值
            //    MakeTxt.Text = DGVR.Cells[row["COLUMN_NAME"].ToString()].Value.ToString();
            //}
            //只读属性，通过是否主键判断 Y:是，N:否
            if ("Y" == row["ISPK"].ToString())
            {
                //给文本框绑定值
                StimTxt.txtField.ReadOnly = true;
                StimTxt.txtField.Enabled = false;
            }

            ////注册按钮点击事件
            //StimTxt.Click += delegate { propertyGrid1.SelectedObject = StimTxt.txtField; };
            //拖动属性
            StimTxt.Draggable(draggable);
            StimTxt.BringToFront();
            tabPageDetail.Controls.Add(StimTxt);
        }

        private void btnCustomLayout_Click(object sender, EventArgs e)
        {
            
        }

        private void BtnSaveConfig_Click(object sender, EventArgs e)
        {
            int stimX,stimY,stimWidth,stimHeight;
            int count = tabPageDetail.Controls.Count;
            foreach (Control item in tabPageDetail.Controls)
            {
                stimX = item.Location.X;
                stimY = item.Location.Y;
                stimWidth = item.Width;
                stimHeight = item.Height;
            }
        }
    }
}
