using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace STIM.WinFormUI
{
    public partial class FrmDataView : Form
    {
        string TableName = "";
        public FrmDataView()
        {
            InitializeComponent();
        }

        private void dgvData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (-1 > e.RowIndex)
            {
                DataGridViewRow dgvRow = dgvData.Rows[e.RowIndex];
                FrmDetailView frm = new FrmDetailView(TableName, dgvRow);
                frm.ShowDialog();
            }
        }
    }
}
