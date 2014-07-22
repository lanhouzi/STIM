using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace STIM.WinFormUI.ExtControl
{
    public partial class TextBoxFrm : TextBox
    {
        public PropertyGrid.Select.ValueObject valueObject = null;
        public TextBoxFrm()
        {
            InitializeComponent();
            this.ReadOnly = true;
        }

        public TextBoxFrm(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            this.ReadOnly = true;
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            PropertyGrid.Select.FrmShow frm = new PropertyGrid.Select.FrmShow(valueObject);
            frm.Owner = this.FindForm();
            frm.ShowDialog();
        }
        
    }
}
