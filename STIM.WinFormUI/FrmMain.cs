using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using STIM.Utilities;
using STIM.WinFormUI.ExtControl;
using System.Xml.Linq;

namespace STIM.WinFormUI
{
    public partial class FrmMain : Form
    {
        /// <summary>
        /// 表单布局 行
        /// </summary>
        private int _layoutRow = -1;
        /// <summary>
        /// 表单布局 列
        /// </summary>
        private int _layoutColumn = -1;

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
            _layoutRow = -1;
            _layoutColumn = -1;
            tabPageDetail.Controls.Clear();
            _model = _bll.GetModel(e.Node.Name);

            //按照自定义配置布局控件
            if (!string.IsNullOrEmpty(_model.DETAIL_FORM_XML))
            {
                XDocument xDoc = XDocument.Parse(_model.DETAIL_FORM_XML, LoadOptions.None);
                ////Linq to XML
                //IEnumerable<XNode> xNodes = from nd in xDoc.Root.Nodes() select nd;
                //Linq,Lambda
                IEnumerable<XElement> xElements = xDoc.Root.Elements().Select(el => el);
                foreach (XElement item in xElements)
                {
                    CreatStimControl(item, true);
                }
            }
            //系统自动有序布局控件
            else
            {
                DataSet ds = _bll.GetTableInformation(e.Node.Name);
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    _layoutColumn++;
                    //3表示显示3列
                    if (_layoutColumn % 3 == 0)
                    {
                        _layoutColumn = 0;
                        _layoutRow++;
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
            StimTxt.lblFile.Text = row["COMMENTS"].ToString() + "：";
            StimTxt.Location = new Point(20 + _layoutColumn * 300, 10 + _layoutRow * 35);
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
                //StimTxt.dataFile.ReadOnly = true;
                StimTxt.dataFile.Enabled = false;
            }

            ////注册按钮点击事件
            //StimTxt.Click += delegate { propertyGrid1.SelectedObject = StimTxt.dataFile; };
            //拖动属性
            StimTxt.Draggable(draggable);
            StimTxt.BringToFront();
            tabPageDetail.Controls.Add(StimTxt);
        }
        public void CreatStimControl(XElement xElement, bool draggable = false)
        {
            //获取控件类型
            Type ty = Type.GetType((string)xElement.Attribute("ControlType"));
            //根据控件类型自动创建相应的控件
            Control autoControl = (Control)Activator.CreateInstance(ty);
            switch (ty.Name)
            {
                case "StimWfTextBox":
                   
                    break;
                default:
                    break;
            }
                

            StimWfTextBox stimTxt = new StimWfTextBox
            {
                Name = (string)xElement.Attribute("ColumnName"),
                Location = new Point((int)xElement.Attribute("X"), (int)xElement.Attribute("Y")),
                Width = (int)xElement.Attribute("W"),
                Height = (int)xElement.Attribute("H"),
                Visible = (bool)xElement.Attribute("Visible"),
                Enabled = (bool)xElement.Attribute("Enabled"),
                lblFile =
                {
                    Text = (string)xElement.Attribute("ColumnName")
                },
                dataFile =
                {
                    Enabled = (bool)xElement.Attribute("Enabled"),
                    Width = (int)xElement.Element("DataControl").Attribute("W"),
                    Height = (int)xElement.Element("DataControl").Attribute("H")
                }
            };
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
                        new XAttribute("ControlType", control.GetType().ToString()),
                        new XAttribute("Visible", control.Visible.ToString()),
                        new XAttribute("Enabled", control.Enabled.ToString()),
                        new XAttribute("X", control.Location.X),
                        new XAttribute("Y", control.Location.Y),
                        new XAttribute("W", control.Width),
                        new XAttribute("H", control.Height),
                            new XElement("Lable", "Value",
                                new XAttribute("Visible", control.Controls[0].Controls["lblFile"].Visible.ToString()),
                                new XAttribute("Enabled", control.Controls[0].Controls["lblFile"].Enabled.ToString()),
                                new XAttribute("W", control.Controls[0].Controls["lblFile"].Width),
                                new XAttribute("H", control.Controls[0].Controls["lblFile"].Height)
                            ),
                            new XElement("DataControl", "Value",
                                new XAttribute("Visible", control.Controls[0].Controls["dataFile"].Visible.ToString()),
                                new XAttribute("Enabled", control.Controls[0].Controls["dataFile"].Enabled.ToString()),
                                new XAttribute("W", control.Controls[0].Controls["dataFile"].Width),
                                new XAttribute("H", control.Controls[0].Controls["dataFile"].Height)
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
