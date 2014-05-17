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
    public partial class FrmDataView : Form
    {
        /// <summary>
        /// 表名
        /// </summary>
        string TableName = "";
        BLL.STIM_CONFIG _bll = new BLL.STIM_CONFIG();
        Model.STIM_CONFIG _model = new Model.STIM_CONFIG();

        public FrmDataView()
        {
            InitializeComponent();
        }

        private void FrmDataView_Load(object sender, EventArgs e)
        {
            _model = _bll.GetModel(TableName);
            //_model.DETAIL_FORM_XML = XDocument.Load(Application.StartupPath + "\\DetailForm.xml").ToString();
            //按照自定义配置布局控件
            if (!string.IsNullOrEmpty(_model.DATAGRIDVIEW_XML))
            {
                XDocument xDoc = XDocument.Parse(_model.DATAGRIDVIEW_XML, LoadOptions.None);
                ////Linq to XML
                //IEnumerable<XNode> xNodes = from nd in xDoc.Root.Nodes() select nd;
                //Linq,Lambda
                IEnumerable<XElement> xElements = xDoc.Root.Elements().Select(el => el);
                foreach (XElement item in xElements)
                {
                    //
                }
            }
            //系统自动有序布局控件
            else
            {
                DataSet ds = _bll.GetTableInformation(TableName);
                foreach (DataRow row in ds.Tables[0].Rows)
                {

                }
            }
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (-1 > e.RowIndex)
            {
                DataGridViewRow dgvRow = dgvData.Rows[e.RowIndex];
                FrmDetailView frm = new FrmDetailView("Add", TableName, dgvRow);
                frm.ShowDialog();
            }
        }

        private void tsMenuAdd_Click(object sender, EventArgs e)
        {
            FrmDetailView frm = new FrmDetailView("Modify", TableName);
            frm.ShowDialog();
        }

        private void tsMenuModify_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvData.CurrentRow.Index;
            if (-1 > rowIndex)
            {
                DataGridViewRow dgvRow = dgvData.Rows[rowIndex];
                FrmDetailView frm = new FrmDetailView("Modify", TableName, dgvRow);
                frm.ShowDialog();
            }
        }

        private void tsMenuDelete_Click(object sender, EventArgs e)
        {

        }

        private void tsMenuRefresh_Click(object sender, EventArgs e)
        {

        }
    }
}
