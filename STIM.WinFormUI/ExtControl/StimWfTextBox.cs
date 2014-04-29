using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using STIM.Utilities;
using System.Collections;

namespace STIM.WinFormUI.ExtControl
{

    public partial class StimWfTextBox : UserControl
    {
        public StimWfTextBox()
        {
            InitializeComponent();
            ChildDraggableToFather();
        }
        /// <summary>
        /// 把自控件的拖动属性赋给父控件
        /// </summary>
        private void ChildDraggableToFather()
        {
            Control[] Ctrls = { TLP, lblField };
            foreach (Control item in Ctrls)
            {
                item.MouseDown += item_MouseDown;
                item.MouseUp += item_MouseUp;
                item.MouseMove += item_MouseMove;
            }
        }
        void item_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }
        void item_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }
        void item_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }
    }
}
