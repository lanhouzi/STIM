using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace STIM.Utilities
{
    
    public class MoveAndResize : Control
    {
        //private Control this=new Control ();
        //public MoveAndResize()
        //{ }
        //public MoveAndResize(Control target_control)
        //{
        //    this = target_control;
        //    this.MouseDown += this_MouseDown;
        //    this.MouseUp += this_MouseUp;
        //    this.MouseMove += this_MouseMove;
        //}

        //void this_MouseDown(object sender, MouseEventArgs e)
        //{
        //    this.OnMouseDown(e);
        //}
        //void this_MouseUp(object sender, MouseEventArgs e)
        //{
        //    this.OnMouseUp(e);
        //}
        //void this_MouseMove(object sender, MouseEventArgs e)
        //{
        //    this.OnMouseMove(e);
        //}
        public enum EnumAdjust
        {
            Nothing = 0,
            Size = 1,
            Postion = 2
        }
        private bool m_isMoving = false;
        private Point m_offset = new Point(0, 0);
        private Size m_intSize = new Size(0, 0);
        private EnumAdjust m_adjust = EnumAdjust.Nothing;
        private int m_x, m_y, m_w, m_h = 0;

        private Rectangle RecAdjustSize
        {
            get { return new Rectangle(this.Width - 15, this.Height - 15, 15, 15); }
        }
        private Rectangle RecAdjustPostion
        {
            get { return new Rectangle(0, 0, this.Width, this.Height); }
        }
        private void CursorCtrl(int x, int y)
        {
            if (!m_isMoving)
            {
                if (RecAdjustSize.Contains(x, y))
                {
                    this.Cursor = Cursors.SizeWE;
                }
                else
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }

        #region 鼠标事件
        protected override void OnMouseDown(MouseEventArgs e)
        {
            m_isMoving = true;
            m_offset = new Point(e.X, e.Y);
            m_intSize.Width = this.Width;
            m_intSize.Height = this.Height;

            if (RecAdjustSize.Contains(e.X, e.Y)) //调整大小
            {
                this.Cursor = Cursors.SizeWE;
                m_adjust = EnumAdjust.Size;
            }
            else if (RecAdjustPostion.Contains(e.X, e.Y)) //调整位置
            {
                this.Cursor = Cursors.SizeAll;
                m_adjust = EnumAdjust.Postion;
            }
            else
            {
                m_adjust = EnumAdjust.Nothing;
            }
            base.OnMouseDown(e);
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            Cursor = Cursors.Default;
            m_isMoving = false;

            base.OnMouseUp(e);
        }
        protected override void OnMouseMove(MouseEventArgs e)
        {
            CursorCtrl(e.X, e.Y);
            m_x = this.Left;
            m_y = this.Top;
            m_w = this.Width;
            m_h = this.Height;
            if (m_isMoving)
            {
                switch (m_adjust)
                {
                    case EnumAdjust.Size:
                        //改变长度
                        m_w = m_intSize.Width + (e.X - m_offset.X);
                        //改变宽度
                        //m_h = m_intSize.Height + (e.Y - m_offset.Y);
                        break;
                    case EnumAdjust.Postion:
                        m_x = Location.X + (e.X - m_offset.X);
                        m_y = Location.Y + (e.Y - m_offset.Y);
                        break;
                }
                //BackColor = Color.Red;
                this.SetBounds(m_x, m_y, m_w, m_h);
            }
            base.OnMouseMove(e);
        }
        #endregion

        #region 键盘事件
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.Alt) //调整大小
            {
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        this.Width -= 5;
                        break;
                    case Keys.Right:
                        this.Width += 5;
                        break;
                    case Keys.Down:
                        this.Height += 5;
                        break;
                    case Keys.Up:
                        this.Height -= 5;
                        break;
                }
                return;
            }
            if (e.Control)
            {
                switch (e.KeyCode) //调整位置
                {
                    case Keys.Left:
                        this.Left -= 5;
                        break;
                    case Keys.Right:
                        this.Left += 5;
                        break;
                    case Keys.Up:
                        this.Top -= 5;
                        break;
                    case Keys.Down:
                        this.Top += 5;
                        break;
                }
            }
        }
        #endregion

    }
}
