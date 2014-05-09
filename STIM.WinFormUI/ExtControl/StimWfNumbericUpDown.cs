using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace STIM.WinFormUI.ExtControl
{
    public partial class StimWfNumbericUpDown : UserControl
    {
        public StimWfNumbericUpDown()
        {
            ChildDraggableToFather();
        }
        /// <summary>
        /// 把自控件的拖动属性赋给父控件
        /// </summary>
        private void ChildDraggableToFather()
        {
            Control[] controls = { TLP, lblFile };
            foreach (Control item in controls)
            {
                item.MouseDown += item_MouseDown;
                item.MouseUp += item_MouseUp;
                item.MouseMove += item_MouseMove;
            }
        }
        void item_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }
        void item_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }
        void item_MouseMove(object sender, MouseEventArgs e)
        {
            OnMouseMove(e);
        }
    }
}
