using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Documents;
using System.Windows.Forms;
using STIM.Utilities;
using STIM.WinFormUI.ExtControl;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace STIM.WinFormUI
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// 表单布局 行
        /// </summary>
        public int LayoutRow = -1;
        /// <summary>
        /// 表单布局 列
        /// </summary>
        public int LayoutColumn = -1;
        /// <summary>
        /// 表单布局 坐标点
        /// </summary>
        public Point LayoutPoint = new Point();
        /// <summary>
        /// 实例化XmlHelper
        /// </summary>
        BLL.STIM_CONFIG _bll = new BLL.STIM_CONFIG();
        Model.STIM_CONFIG _model = new Model.STIM_CONFIG();

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
            DataSet ds = _bll.GetListForTreeView(strWhere);
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
            LayoutRow = -1;
            LayoutColumn = -1;
            tabPageDetail.Controls.Clear();
            _model = _bll.GetModel(e.Node.Name);

            //按照自定义配置布局控件
            if (!string.IsNullOrEmpty(_model.DETAIL_FORM_XML))
            {
                //XmlDocument xmlDoc = new XmlDocument();
                //xmlDoc.LoadXml(_model.DETAIL_FORM_XML);
                //XmlNodeList xnList = xmlDoc.SelectNodes("/Table/Column");

                XDocument xDoc = XDocument.Parse(_model.DETAIL_FORM_XML, LoadOptions.None);
                IEnumerable<XNode> nodes =
                    from nd in xDoc.Root.Nodes()
                    select nd;
                foreach (XNode item in nodes)
                {
                    //CreatStimControl(item, true);
                }
            }
            //系统自动有序布局控件
            else
            {
                DataSet ds = _bll.GetTableInformation(e.Node.Name);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    LayoutColumn++;
                    //3表示显示3列
                    if (LayoutColumn % 3 == 0)
                    {
                        LayoutColumn = 0;
                        LayoutRow++;
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
            StimTxt.Location = new Point(20 + LayoutColumn * 300, 10 + LayoutRow * 35);
            //只对更新操作生效
            //if (VoidNameEnum.Update == VoidName && null != DGVR)
            //{
            //    //给文本框绑定值
            //    MakeTxt.Text = DGVR.Cells[row["COLUMN_NAME"].ToString()].Value.ToString();
            //}
            //只读属性，通过是否主键判断 Y:是，N:否
            if ("Y" == row["ISPK"].ToString())
            {
                StimTxt.Enabled = false;
                //StimTxt.txtField.ReadOnly = true;
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
                    Text = attrCollection["ColumnName"].Value,
                    Enabled = bool.Parse(attrCollection["Enabled"].Value),
                    Width = int.Parse(xmlNode.SelectSingleNode("DataControl").Attributes["W"].Value),
                    Height = int.Parse(xmlNode.SelectSingleNode("DataControl").Attributes["H"].Value)
                }
            };
            //主键判断 
            if ("False" == attrCollection["Enabled"].Value)
            {
                //给文本框绑定值
                //StimTxt.txtField.ReadOnly = true;
                stimTxt.txtField.Enabled = false;
            }
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
            var controls = tabPageDetail.Controls;
            _model.DETAIL_FORM_XML = MakeXmlLinq(tableName, controls);

            bool result = _bll.Update(_model);
            if (result)
            {
                MessageBox.Show("保存成功！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("保存失败！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// 使用 LINQ to XML 的方式创建XML
        /// </summary>
        /// <param name="tableName">数据库表名</param>
        /// <param name="controls">控件集合</param>
        /// <returns></returns>
        public string MakeXmlLinq(string tableName, Control.ControlCollection controls)
        {
            XDocument xDoc = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Table",
                    new XAttribute("TableName", tableName)
                )
            );
            foreach (Control control in controls)
            {
                XElement xEle =
                    new XElement("Column",
                        new XAttribute("ColumnName", control.Name),
                        new XAttribute("Visible", control.Visible.ToString()),
                        new XAttribute("Enabled", control.Enabled.ToString()),
                        new XAttribute("X", control.Location.X),
                        new XAttribute("Y", control.Location.Y),
                        new XAttribute("W", control.Width),
                        new XAttribute("H", control.Height),
                            new XElement("Lable", "Value",
                                new XAttribute("Visible", control.Controls[0].Controls["lblField"].Visible.ToString()),
                                new XAttribute("Enabled", control.Controls[0].Controls["lblField"].Enabled.ToString()),
                                new XAttribute("W", control.Controls[0].Controls["lblField"].Width),
                                new XAttribute("H", control.Controls[0].Controls["lblField"].Height)
                            ),
                            new XElement("DataControl", "Value",
                                new XAttribute("Visible", control.Controls[0].Controls["txtField"].Visible.ToString()),
                                new XAttribute("Enabled", control.Controls[0].Controls["txtField"].Enabled.ToString()),
                                new XAttribute("W", control.Controls[0].Controls["txtField"].Width),
                                new XAttribute("H", control.Controls[0].Controls["txtField"].Height)
                            )
                    );
                xDoc.Root.Add(xEle);
            }
            return xDoc.Declaration.ToString() + "\r\n" + xDoc.ToString(SaveOptions.None);
        }

        public string MakeXml(string tableName, Dictionary<Control, Dictionary<string, string>> dictControls)
        {
            XmlHelper xml = new XmlHelper();
            xml.XmlString = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><Table TableName=\"" + tableName + "\"></Table>";

            foreach (var control in dictControls)
            {
                Control c = new Control();

                //<Table TableName="GOODS_EXT" X="1">
                xml.Insert(XmlSourceTypeEnum.FromString, "/Table", "Column", "ColumnName", control.Key.Name);
                foreach (var attribute in control.Value)
                {

                    //<Column ColumnName="GOODS_EXT" X="1">
                    xml.Insert(XmlSourceTypeEnum.FromString, "/Table/Column[@ColumnName='" + control.Key + "']", "", attribute.Key, attribute.Value);
                }
                //<Lable>1</Lable>
                xml.Insert(XmlSourceTypeEnum.FromString, "/Table/Column[@ColumnName='" + control.Key + "']", "Lable", "", "1");
                //<DataControl X="150" />
                xml.Insert(XmlSourceTypeEnum.FromString, "/Table/Column[@ColumnName='" + control.Key + "']", "DataControl", "W", "180");

            }
            return xml.XmlString;
        }

    }
}
