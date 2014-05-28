using System;
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
    public partial class FrmDetailView : Form
    {
        /// <summary>
        /// 新增or修改
        /// </summary>
        string AddOrModify = "Add";
        /// <summary>
        /// 表名
        /// </summary>
        string TableName = "";
        /// <summary>
        /// 主键
        /// </summary>
        List<string> PkList = new List<string>();

        DataGridViewRow DgvRow = new DataGridViewRow();
        BLL.STIM_CONFIG _bll = new BLL.STIM_CONFIG();
        Model.STIM_CONFIG _model = new Model.STIM_CONFIG();

        public FrmDetailView()
        {
            InitializeComponent();
        }

        public FrmDetailView(string addOrModify, string tableName, List<string> pkList, DataGridViewRow dgvRow = null)
            : this()
        {
            AddOrModify = addOrModify;
            TableName = tableName;
            PkList = pkList;
            DgvRow = dgvRow;
        }

        private void FrmDetailView_Load(object sender, EventArgs e)
        {
            //_model = _bll.GetModel(TableName);
            _model.DETAIL_FORM_XML = XDocument.Load(Application.StartupPath + "\\DetailForm.xml").ToString();

            //按照自定义配置布局控件
            if (!string.IsNullOrEmpty(_model.DETAIL_FORM_XML))
            {
                XDocument xDoc = XDocument.Parse(_model.DETAIL_FORM_XML, LoadOptions.None);
                IEnumerable<XElement> xElements = xDoc.Root.Elements().Select(el => el);
                foreach (XElement item in xElements)
                {
                    //字段名
                    var columnName = (string)item.Attribute("Column_Name");
                    //字段值
                    object columnValue = null;
                    if (AddOrModify == "Modify")
                    {
                        columnValue = DgvRow.Cells[columnName].Value;
                    }
                    CreateStimControl stimControl = new CreateStimControl(item, columnValue);
                    pnlData.Controls.Add(stimControl.AutoStimControl);
                }

            }
            else
            {
                MessageBox.Show("尚未对表【" + TableName + "】进行自定义配置，请新增该表的自定义配置！", "消息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (AddOrModify)
            {
                case "Add":
                    // todo
                    break;
                case "Modify":
                    //todo
                    break;
            }

            Dictionary<string, object> dictColumns = new Dictionary<string, object>();
        }

    }
}
