using System;
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
using System.IO;
using STIM.Model;
using System.Xml.Linq;

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
        /// <summary>
        /// 实例化XmlHelper
        /// </summary>
        XmlHelper xml = new XmlHelper();
        BLL.STIM_CONFIG bll = new BLL.STIM_CONFIG();
        Model.STIM_CONFIG model = new Model.STIM_CONFIG();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = this;
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
            model = bll.GetModel(e.Node.Name);

            //按照自定义配置布局控件
            if (!string.IsNullOrEmpty(model.DETAIL_FORM_XML))
            {
                xml.XmlString = model.DETAIL_FORM_XML;

                DataSet ds = new DataSet();
                XmlNodeList xnList = xml.SelectNodes("/Table/Column");
                foreach (XmlNode item in xnList)
                {
                    CreatStimControl(item);
                }
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
            StimTxt.Name = row["COLUMN_NAME"].ToString();
            StimTxt.lblField.Text = row["COMMENTS"].ToString() + "：";
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
        public void CreatStimControl(XmlNode xmlNode, bool draggable = false)
        {
            XmlAttributeCollection attrCollection = xmlNode.Attributes;
            //grpMain.Controls.Clear();
            StimWfTextBox stimTxt = new StimWfTextBox
            {
                Name = attrCollection["ColumnName"].Value,
                Location = new Point(int.Parse(attrCollection["X"].Value), int.Parse(attrCollection["Y"].Value)),
                Width = int.Parse(attrCollection["W"].Value),
                Height = int.Parse(attrCollection["H"].Value),
                Visible = bool.Parse(attrCollection["Visible"].Value),
                Enabled = bool.Parse(attrCollection["Enabled"].Value),
                lblField =
                {
                    Text = attrCollection["ColumnName"].Value
                },
                txtField =
                {
                    Text = attrCollection["ColumnName"].Value//,
                    // Width =int.Parse(xmlNode.SelectSingleNode( "DataControl").Attributes["W"].Value)
                }
            };


            //只对更新操作生效
            //if (VoidNameEnum.Update == VoidName && null != DGVR)
            //{
            //    //给文本框绑定值
            //    MakeTxt.Text = DGVR.Cells[row["COLUMN_NAME"].ToString()].Value.ToString();
            //}
            //只读属性，通过是否主键判断 Y:是，N:否
            if ("Y" == attrCollection["X"].Value)
            {
                //给文本框绑定值
                //StimTxt.txtField.ReadOnly = true;
                stimTxt.txtField.Enabled = false;
            }

            ////注册按钮点击事件
            //StimTxt.Click += delegate { propertyGrid1.SelectedObject = StimTxt.txtField; };
            //拖动属性
            stimTxt.Draggable(draggable);
            stimTxt.BringToFront();
            tabPageDetail.Controls.Add(stimTxt);
        }

        private void btnCustomLayout_Click(object sender, EventArgs e)
        {

        }

        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            string tableName = tvSingleTableList.SelectedNode.Name;
            //控件字典
            Dictionary<string, Dictionary<string, string>> dictControls = new Dictionary<string, Dictionary<string, string>>();

            foreach (Control item in tabPageDetail.Controls)
            {
                //属性字典
                Dictionary<string, string> dictAttributes = new Dictionary<string, string>
                {
                    {"Visible", item.Visible.ToString()},
                    {"Enabled", item.Enabled.ToString()},
                    {"X", item.Location.X.ToString()},
                    {"Y", item.Location.Y.ToString()},
                    {"W", item.Width.ToString()},
                    {"H", item.Height.ToString()}
                };

                //把属性字典添加到空间字典
                dictControls.Add(item.Name, dictAttributes);
            }
            model.DETAIL_FORM_XML = MakeXml(tableName, dictControls);

            bool result = bll.Update(model);
            if (result)
            {
                MessageBox.Show("保存成功！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("保存失败！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public string MakeXml(string tableName, Dictionary<string, Dictionary<string, string>> dictControls)
        {
            xml.XmlString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><Table TableName=\"" + tableName + "\"></Table>";

            foreach (var control in dictControls)
            {
                //<Table TableName="GOODS_EXT" X="1">
                xml.Insert(XmlSourceTypeEnum.FromString, "/Table", "Column", "ColumnName", control.Key);
                foreach (var attribute in control.Value)
                {

                    //<Column ColumnName="GOODS_EXT" X="1">
                    xml.Insert(XmlSourceTypeEnum.FromString, "/Table/Column[@ColumnName='" + control.Key + "']", "", attribute.Key, attribute.Value);
                }
                //<Lable>1</Lable>
                xml.Insert(XmlSourceTypeEnum.FromString, "/Table/Column[@ColumnName='" + control.Key + "']", "Lable", "", "1");
                //<DataControl X="1" />
                xml.Insert(XmlSourceTypeEnum.FromString, "/Table/Column[@ColumnName='" + control.Key + "']", "DataControl", "", "150");

            }
            return xml.XmlString;
        }

    }
}
