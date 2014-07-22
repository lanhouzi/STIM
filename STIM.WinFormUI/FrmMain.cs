using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using STIM.WinFormUI.ExtControl;
using System.Web.Script.Serialization;

namespace STIM.WinFormUI
{
    public partial class FrmMain : Form
    {
        public int activecontrolcount = 0;
        public string activecontrolname = "";
        public int activeheight = 0;
        public int activeleft = 0;
        public int activetop = 0;
        public int activewidth = 0;
        public bool i_ctrl = false;
        private CRectControl CRectCtl;
        private string TableName = string.Empty;
        /// <summary>
        /// 表单布局 行
        /// </summary>
        private int _layoutRow = -1;
        /// <summary>
        /// 表单布局 列
        /// </summary>
        private int _layoutColumn = -1;
        /// <summary>
        /// 表结构
        /// </summary>
        DataTable DtStruct = new DataTable();

        BLL.STIM_CONFIG _bll = new BLL.STIM_CONFIG();
        Model.STIM_CONFIG _model = new Model.STIM_CONFIG();

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            propertyGrid1.SetStandardPropertyTabs();
            BindSingleTableList();
            this.KeyDown += new KeyEventHandler(control_KeyDown);
            this.KeyUp += new KeyEventHandler(control_KeyUp);
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
            //tvSingleTableList.Nodes.Add("GOODS_EXT", "GOODS_EXT");
        }
        /// <summary>
        /// 表切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tvSingleTableList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                _layoutRow = -1;
                _layoutColumn = -1;
                tabPageDetail.Controls.Clear();
                propertyGrid1.SelectedObject = null;
                //取得表名
                this.TableName = e.Node.Name;
                tabPageDetail.Text = "表 "+this.TableName+" 界面设计";

                DtStruct = _bll.GetTableInformation(this.TableName).Tables[0];

                _model = _bll.GetModel(e.Node.Name);
                //_model.DETAIL_FORM_XML = XDocument.Load(Application.StartupPath + "\\DetailForm.xml").ToString();

                //按照自定义配置布局控件
                if (!string.IsNullOrEmpty(_model.DETAIL_FORM_XML))
                {
                    XDocument xDoc = XDocument.Parse(_model.DETAIL_FORM_XML, LoadOptions.None);
                    ////Linq to XML
                    //IEnumerable<XNode> xNodes = from nd in xDoc.Root.Nodes() select nd;
                    //Lambda
                    IEnumerable<XElement> xElements = xDoc.Root.Elements().Select(el => el);
                    foreach (XElement item in xElements)
                    {
                        CreatStimControl(item); 
                    }
                }
                //系统自动有序布局控件
                else
                {
                    foreach (DataRow row in DtStruct.Rows)
                    {
                        _layoutColumn++;
                        //3表示显示3列
                        if (_layoutColumn % 3 == 0)
                        {
                            _layoutColumn = 0;
                            _layoutRow++;
                        }
                        CreatStimControl(row);
                    }
                }
            }
            catch(Exception ex)
            {
            
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string tablename = string.IsNullOrEmpty(this.TableName) ? "GOODS_EXT" : this.TableName;
            FrmDataView frm = new FrmDataView(tablename);
            frm.ShowDialog();
        }
        /// <summary>
        /// 数据库加载
        /// </summary>
        /// <param name="row"></param>
        /// <param name="draggable"></param>
        public void CreatStimControl(DataRow row)
        {
            CreateStimControl stimControl = new CreateStimControl(row, null);
            stimControl.AutoStimControl.Location = new Point(20 + _layoutColumn * 300, 10 + _layoutRow * 35);
            //只读属性，通过是否主键判断 Y:是，N:否
            if ("Y" == row["ISPK"].ToString())
            {
                //stimControl.AutoStimControl.Enabled = false;
                //StimTxt.dataFile.ReadOnly = true;
                stimControl.AutoStimControl.property.ControlEnable = 0;
            }
            //添加属性选择对象
            stimControl.AutoStimControl.Click += new System.EventHandler(stimControl_Click);
            //添加拖住标识
            stimControl.AutoStimControl.MouseDown += new MouseEventHandler(control_MouseDown);
            stimControl.AutoStimControl.MouseUp += new MouseEventHandler(control_MouseUp);
            tabPageDetail.Controls.Add(stimControl.AutoStimControl);

        }
        /// <summary>
        /// XML文件加载
        /// </summary>
        /// <param name="xElement"></param>
        /// <param name="draggable"></param>
        public void CreatStimControl(XElement xElement)
        {
            CreateStimControl stimControl = new CreateStimControl(xElement, null);
            //添加属性选择对象
            stimControl.AutoStimControl.Click += new System.EventHandler(stimControl_Click);
            //添加拖住标识
            stimControl.AutoStimControl.MouseDown += new MouseEventHandler(control_MouseDown);
            stimControl.AutoStimControl.MouseUp += new MouseEventHandler(control_MouseUp);
            
            //pb.WireControl(stimControl.AutoStimControl);
            tabPageDetail.Controls.Add(stimControl.AutoStimControl);
            //if (stimControl.AutoStimControl.DataFile is RadioButtonGroup)
            //{
            //    ((RadioButtonGroup)stimControl.AutoStimControl.DataFile).InitUI();
            //}
        }
        /// <summary>
        /// propertyGrid控件属性切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stimControl_Click(object sender, EventArgs e)
        {
            StimControl stimControl = (StimControl)sender;

            propertyGrid1.SelectedObject = stimControl.property;
            
        }
         
        /// <summary>
        /// 存储配置模版的xml到数据库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            string tableName = tvSingleTableList.SelectedNode.Name;
            var controls = tabPageDetail.Controls;
            _model.TABLE_NAME = tableName;
            _model.DETAIL_FORM_XML = MakeXmlLinq(tableName, controls);

            bool result =  _bll.Update(_model);
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

            int VerticalScroll=this.tabPageDetail.VerticalScroll.Value;
            int HorizontalScroll=this.tabPageDetail.HorizontalScroll.Value;
            foreach (Control control in controls)
            {
                if (control is StimControl)
                {
                    StimControl temp = control as StimControl;
                    //解决shujuy
                    string datasource = string.Empty;
                    if (temp.property.ControlDataSource!=null)
                    {
                        var json = new JavaScriptSerializer();
                        datasource = json.Serialize(temp.property.ControlDataSource);
                    }
                    //解决弹窗选择数据
                    string frmDataObject = string.Empty;
                    if (temp.property.FrmDataObject != null)
                    {
                        var json = new JavaScriptSerializer();
                        frmDataObject = json.Serialize(temp.property.FrmDataObject);
                    }
                    //解决规则
                    string Regular = string.Empty;
                    if (temp.property.CheckRegular!=null)
                    {
                        var json = new JavaScriptSerializer();
                        Regular = json.Serialize(temp.property.CheckRegular);
                    }
                    //解决默认值
                    string valueObjectStr = string.Empty;
                     if (temp.property.Value!=null)
                    {
                        var json = new JavaScriptSerializer();
                        valueObjectStr = json.Serialize(temp.property.Value);
                    }
                    XElement xEle = new XElement("Column",
                            new XAttribute("Column_Name", temp.Name),
                            new XAttribute("ControlType", temp.property.ControlType),
                            new XAttribute("ControlName", control.Controls["TLP"].Controls["dataFile"].GetType().Name),
                            new XAttribute("Visible", temp.property.ControlVisible == 1 ? "True" : "False"),
                            new XAttribute("Enabled", temp.property.ControlEnable == 1 ? "True" : "False"),
                            new XAttribute("Required", temp.property.ControlRequired == 1 ? "True" : "False"),
                            new XAttribute("ListConditionFlag", temp.property.ListConditionFlag == 1 ? "True" : "False"),
                            new XAttribute("ListShowFlag", temp.property.ListShowFlag == 1 ? "True" : "False"),
                            new XAttribute("X", (temp.property.ControlLeft + HorizontalScroll).ToString()),
                            new XAttribute("Y", (temp.property.ControlTop + VerticalScroll).ToString()),
                            new XAttribute("W", temp.property.ControlWidth.ToString()),
                            new XAttribute("H", temp.property.ControlHeight.ToString()),
                            new XAttribute("CW", temp.property.ColumnWidth.ToString()),
                            new XAttribute("TabIndex", temp.property.TabIndex.ToString()),
                                new XElement("Lable",temp.property.Text,
                                    new XAttribute("W", 100),
                                    new XAttribute("H", 25)
                                ),
                                new XElement("DataControl",
                                    new XAttribute("Visible", temp.property.ControlVisible == 1 ? "True" : "False"),
                                    new XAttribute("Enabled", temp.property.ControlEnable == 1 ? "True" : "False"),
                                    new XAttribute("Value", valueObjectStr)
                                ),
                                new XElement("DataRule",
                                    //new XAttribute("Nullable", DtStruct.Select("COLUMN_NAME='" + control.Name + "'")[0]["NULLABLE"].ToString()),
                                    new XAttribute("DataSource", datasource),
                                    new XAttribute("Regular", Regular)
                                ),
                                new XElement("FrmData",
                                    new XAttribute("object", frmDataObject)
                                )
                        );
                    xDoc.Root.Add(xEle);
                }
            }

            //xDoc.Save(Application.StartupPath + "\\DetailForm.xml");

            return xDoc.Declaration + xDoc.ToString(SaveOptions.DisableFormatting);
        }

        
        /// <summary>
        /// 获取当前要拖动的控件 xi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void control_MouseDown(object sender, MouseEventArgs e)
        {
            int num;
            bool flag = false;
            Control control = sender as Control;
            control.BringToFront();
            control.Capture = false;
            string str = "CRectCtl" + (sender as Control).Name;
            if (!this.i_ctrl)
            {
                if (!control.Parent.Controls.Contains(control.Parent.Controls[str]))
                {
                    for (num = 0; num < base.Controls.Count; num++)
                    {
                        if (base.Controls[num] is CRectControl)
                        {
                            base.Controls[num].Dispose();
                        }
                        else if (base.Controls[num].HasChildren)
                        {
                            this.SetTheRectnull(base.Controls[num], str);
                        }
                    }
                    this.CRectCtl = new CRectControl(sender as Control);
                    this.CRectCtl.Name = "CRectCtl" + (sender as Control).Name;
                    control.Parent.Controls.Add(this.CRectCtl);
                    this.CRectCtl.BringToFront();
                    this.CRectCtl.Draw();
                    //解决拖动后属性变化，但是propertyGrid1不同步显示的问题
                    this.CRectCtl.CallBackHandler += new EventHandler(delegate { propertyGrid1.Refresh(); });
                }
            }
            else if (control.Parent != null)
            {
                for (num = 0; num < control.Parent.Controls.Count; num++)
                {
                    if (control.Parent.Controls[num].Name == str)
                    {
                        flag = true;
                        control.Parent.Controls[num].Visible = true;
                        control.Parent.Controls[num].BringToFront();
                        return;
                    }
                }
                if (!flag)
                {
                    this.CRectCtl = new CRectControl(sender as Control);
                    this.CRectCtl.Name = "CRectCtl" + (sender as Control).Name;
                    control.Parent.Controls.Add(this.CRectCtl);
                    this.CRectCtl.BringToFront();
                    this.CRectCtl.Draw();
                }
            }
        }

        private void control_MouseUp(object sender, MouseEventArgs e)
        {
            int num = 0;
            if ((sender as Control).Parent != null)
            {
                for (int i = 0; i < (sender as Control).Parent.Controls.Count; i++)
                {
                    if ((sender as Control).Parent.Controls[i] is CRectControl)
                    {
                        num++;
                    }
                }
            }
            if (num == 1)
            {
                this.activeleft = (sender as Control).Left;
                this.activetop = (sender as Control).Top;
                this.activewidth = (sender as Control).Width;
                this.activeheight = (sender as Control).Height;
                this.activecontrolname = (sender as Control).Name;
            }
            else if (num > 1)
            {
            }
        }
        private void SetTheRectnull(Control ctrl, string s_name)
        {
            string name = "";
            for (int i = ctrl.Controls.Count - 1; i >= 0; i--)
            {
                name = ctrl.Controls[i].Name;
                if (ctrl.Controls[i] is CRectControl)
                {
                    ctrl.Controls[i].Dispose();
                }
                else if (ctrl.Controls[i].HasChildren)
                {
                    this.SetTheRectnull(ctrl.Controls[i], s_name);
                }
            }
        }
        private void GetTheRectCount(Control ctrl, string sposition)
        {
            string str = "";
            for (int i = ctrl.Controls.Count - 1; i >= 0; i--)
            {
                if (ctrl.Controls[i] is CRectControl)
                {
                    this.activecontrolcount++;
                    str = ctrl.Controls[i].Name.Substring(8, ctrl.Controls[i].Name.Length - 8);
                    if (ctrl.Controls[i].Parent.Controls.Contains(ctrl.Controls[i].Parent.Controls[str]))
                    {
                        if (sposition == "Left")
                        {
                            ctrl.Controls[i].Parent.Controls[str].Left = this.activeleft;
                            (ctrl.Controls[i] as CRectControl).Create();
                        }
                        else if (sposition == "Top")
                        {
                            ctrl.Controls[i].Parent.Controls[str].Top = this.activetop;
                            (ctrl.Controls[i] as CRectControl).Create();
                        }
                        else if (sposition == "Bottom")
                        {
                            ctrl.Controls[i].Parent.Controls[str].Top = (this.activetop + this.activeheight) - ctrl.Controls[i].Parent.Controls[str].Height;
                            (ctrl.Controls[i] as CRectControl).Create();
                        }
                        else if (sposition == "Right")
                        {
                            ctrl.Controls[i].Parent.Controls[str].Left = (this.activeleft + this.activewidth) - ctrl.Controls[i].Parent.Controls[str].Width;
                            (ctrl.Controls[i] as CRectControl).Create();
                        }
                    }
                }
                else if (ctrl.Controls[i].HasChildren)
                {
                    this.GetTheRectCount(ctrl.Controls[i], sposition);
                }
            }
        }
        private void control_KeyDown(object sender, KeyEventArgs e)
        {
            int num;
            string str = "";
            Control ctrlNow = tabPageDetail;
            if (e.KeyCode.ToString() == "Down")
            {
                if (ctrlNow != null )
                {
                        for (num = 0; num < tabPageDetail.Controls.Count; num++)
                        {
                            str = "CRectCtl" + ctrlNow.Controls[num].Name;
                            if (ctrlNow.Controls.Contains(ctrlNow.Controls[str]))
                            {
                                if (e.Control)
                                {
                                    (ctrlNow.Controls[num] as StimControl).Height++;
                                    //(ctrlNow.Controls[str] as CRectControl).Height++;
                                    (ctrlNow.Controls[str] as CRectControl).Create();
                                }
                                else
                                {
                                    ctrlNow.Controls[num].Top++;
                                    ctrlNow.Controls[str].Top++;
                                }
                            }
                    } 
                }
               
            }
            else if (e.KeyCode.ToString() == "Up")
            {
                if (ctrlNow != null)
                {
                    for (num = 0; num < ctrlNow.Controls.Count; num++)
                    {
                        str = "CRectCtl" + ctrlNow.Controls[num].Name;
                        if (ctrlNow.Controls.Contains(ctrlNow.Controls[str]))
                        {
                            if (e.Control)
                            {
                                (ctrlNow.Controls[num] as StimControl).Height--;
                                //(ctrlNow.Controls[str] as CRectControl).Height--;
                                (ctrlNow.Controls[str] as CRectControl).Create();
                            }
                            else
                            {
                                ctrlNow.Controls[num].Top--;
                                ctrlNow.Controls[str].Top--;
                            }
                        }
                    }
                }
            }
            else if (e.KeyCode.ToString() == "Right")
            {
                if (ctrlNow != null)
                {
                    for (num = 0; num < ctrlNow.Controls.Count; num++)
                    {
                        str = "CRectCtl" + ctrlNow.Controls[num].Name;
                        if (ctrlNow.Controls.Contains(ctrlNow.Controls[str]))
                        {
                            if (e.Control)
                            {
                                (ctrlNow.Controls[num] as StimControl).Width++;
                                //(ctrlNow.Controls[str] as CRectControl).Width++;
                                (ctrlNow.Controls[str] as CRectControl).Create();
                            }
                            else
                            {
                                ctrlNow.Controls[num].Left++;
                                ctrlNow.Controls[str].Left++;
                            }
                        }
                    }
                }
            }
            else if (e.KeyCode.ToString() == "Left")
            {
                if (ctrlNow != null)
                {
                    for (num = 0; num < ctrlNow.Controls.Count; num++)
                    {
                        str = "CRectCtl" + ctrlNow.Controls[num].Name;
                        if (ctrlNow.Controls.Contains(ctrlNow.Controls[str]))
                        {
                            if (e.Control)
                            {
                                (ctrlNow.Controls[num] as StimControl).Width--;
                                //(ctrlNow.Controls[str] as CRectControl).Width--;
                                (ctrlNow.Controls[str] as CRectControl).Create();
                            }
                            else
                            {
                                ctrlNow.Controls[num].Left--;
                                ctrlNow.Controls[str].Left--;
                            }
                        }
                    }
                }
            }
            else if (e.KeyCode.ToString() == "ControlKey")
            {
                this.i_ctrl = true;
                //this.Text = "i_ctrl = true";
            }
        }

        private void control_KeyUp(object sender, KeyEventArgs e)
        {
            this.i_ctrl = false;
            //this.Text = "i_ctrl = false";
        }
        #region 上下左右对齐
        private void leftadjust_Click(object sender, EventArgs e)
        {
            this.activecontrolcount = 0;
            for (int i = 0; i < base.Controls.Count; i++)
            {
                if (base.Controls[i] is CRectControl)
                {
                    this.activecontrolcount++;
                }
                else if (base.Controls[i].HasChildren)
                {
                    this.GetTheRectCount(base.Controls[i], "Left");
                }
            }
        }

        private void rightadjust_Click(object sender, EventArgs e)
        {
            this.activecontrolcount = 0;
            for (int i = 0; i < base.Controls.Count; i++)
            {
                if (base.Controls[i] is CRectControl)
                {
                    this.activecontrolcount++;
                }
                else if (base.Controls[i].HasChildren)
                {
                    this.GetTheRectCount(base.Controls[i], "Right");
                }
            }
        }

        private void buttomadjust_Click(object sender, EventArgs e)
        {
            this.activecontrolcount = 0;
            for (int i = 0; i < base.Controls.Count; i++)
            {
                if (base.Controls[i] is CRectControl)
                {
                    this.activecontrolcount++;
                }
                else if (base.Controls[i].HasChildren)
                {
                    this.GetTheRectCount(base.Controls[i], "Bottom");
                }
            }
        }
        private void topadjust_Click(object sender, EventArgs e)
        {
            this.activecontrolcount = 0;
            for (int i = 0; i < base.Controls.Count; i++)
            {
                if (base.Controls[i] is CRectControl)
                {
                    this.activecontrolcount++;
                }
                else if (base.Controls[i].HasChildren)
                {
                    this.GetTheRectCount(base.Controls[i], "Top");
                }
            }
        }
        #endregion 

         
    }
}
