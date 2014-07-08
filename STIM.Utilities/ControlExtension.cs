using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace STIM.Utilities
{
    public static class ControlExtension
    {
        // TKey is control to drag, TValue is a flag used while dragging
        private static Dictionary<Control, bool> draggables = new Dictionary<Control, bool>();
        private static System.Drawing.Size mouseOffset;

        /// <summary>
        /// Enabling/disabling dragging for control
        /// </summary>
        public static void Draggable(this Control control, bool Enable)
        //public static void Draggable(this UILib.Controls.Sensor control, bool Enable)
        {
            if (Enable)
            {
                // enabling drag feature
                if (draggables.ContainsKey(control))
                {   // return if control is already draggable
                    return;
                }
                draggables.Add(control, false); // 'false' - initial state is 'not dragging'
                // assign required event handlers
                control.MouseDown += new MouseEventHandler(control_MouseDown);
                control.MouseUp += new MouseEventHandler(control_MouseUp);
                control.MouseMove += new MouseEventHandler(control_MouseMove);
            }
            else
            {
                // disabling drag feature
                if (!draggables.ContainsKey(control))
                {  // return if control is not draggable
                    return;
                }
                // remove event handlers
                control.MouseDown -= control_MouseDown;
                control.MouseUp -= control_MouseUp;
                control.MouseMove -= control_MouseMove;
                draggables.Remove(control);
            }
        }

        static void control_MouseDown(object sender, MouseEventArgs e)
        {
            ((Control)sender).Cursor = System.Windows.Forms.Cursors.SizeAll;
            mouseOffset = new System.Drawing.Size(e.Location);
            // turning on dragging
            draggables[(Control)sender] = true;
        }

        static void control_MouseUp(object sender, MouseEventArgs e)
        {
            ((Control)sender).Cursor = System.Windows.Forms.Cursors.Hand;
            // turning off dragging
            draggables[(Control)sender] = false;

            #region ---控件超出父容器之后的处理---
            if (((Control)sender).Left < 0)
            {
                ((Control)sender).Left = 0;
            }
            if (((Control)sender).Top < 0)
            {
                ((Control)sender).Top = 0;
            }
            if (null != ((Control)sender).Parent.BackgroundImage && ((Control)sender).Left > ((Control)sender).Parent.BackgroundImage.Size.Width - ((Control)sender).Size.Width)
            {
                ((Control)sender).Left = ((Control)sender).Parent.BackgroundImage.Size.Width - ((Control)sender).Size.Width;
            }
            if (null != ((Control)sender).Parent.BackgroundImage && ((Control)sender).Top > ((Control)sender).Parent.BackgroundImage.Size.Height - ((Control)sender).Height)
            {
                ((Control)sender).Top = ((Control)sender).Parent.BackgroundImage.Size.Height - ((Control)sender).Height;
            }
            #endregion
        }

        static void control_MouseMove(object sender, MouseEventArgs e)
        {
            // only if dragging is turned on
            if (draggables[(Control)sender] == true)
            {
                // calculations of control's new position
                System.Drawing.Point newLocationOffset = e.Location - mouseOffset;
                if (true)
                {
                    System.Drawing.Size patentSize = ((Control)sender).Parent.Size;
                }
                ((Control)sender).Left += newLocationOffset.X;
                ((Control)sender).Top += newLocationOffset.Y;

            }
        }
    }

}
