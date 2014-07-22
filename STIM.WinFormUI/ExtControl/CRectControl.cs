namespace STIM.WinFormUI.ExtControl
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Windows.Forms;

    public class CRectControl : UserControl
    {
        private Rectangle baseRect;
        private Rectangle[] BoundRect = new Rectangle[4];
        private Rectangle ControlRect;
        private Control currentControl;
        private HitDownSquare CurrHitPlace;
        private Graphics g;
        private bool isFirst = true;
        private Point prevLeftClick;
        private Rectangle[] SmallRect = new Rectangle[8];
        private Size Square = new Size(6, 6);
        //回调事件，拖动或调整后，再执行的事件
        public event EventHandler CallBackHandler;

        public CRectControl(Control theControl)
        {
            this.InitializeComponent();
            this.currentControl = theControl;
            this.Create();
        }

        private GraphicsPath BuildFrame()
        {
            GraphicsPath path = new GraphicsPath();
            this.BoundRect[0] = new Rectangle(0, 0, (this.currentControl.Width + (this.Square.Width * 2)) + 1, this.Square.Height + 1);
            this.BoundRect[1] = new Rectangle(0, this.Square.Height + 1, this.Square.Width + 1, (this.currentControl.Bounds.Height + this.Square.Height) + 1);
            this.BoundRect[2] = new Rectangle(this.Square.Width + 1, (this.currentControl.Bounds.Height + this.Square.Height) - 1, (this.currentControl.Width + this.Square.Width) + 2, this.Square.Height + 2);
            this.BoundRect[3] = new Rectangle((this.currentControl.Width + this.Square.Width) - 1, this.Square.Height + 1, this.Square.Width + 2, this.currentControl.Height - 1);
            path.AddRectangle(this.BoundRect[0]);
            path.AddRectangle(this.BoundRect[1]);
            path.AddRectangle(this.BoundRect[2]);
            path.AddRectangle(this.BoundRect[3]);
            return path;
        }

        public void Create()
        {
            int x = this.currentControl.Bounds.X - this.Square.Width;
            int y = this.currentControl.Bounds.Y - this.Square.Height;
            int num3 = this.currentControl.Bounds.Height + (this.Square.Height * 2);
            int num4 = this.currentControl.Bounds.Width + (this.Square.Width * 2);
            base.Bounds = new Rectangle(x, y, num4 + 1, num3 + 1);
            base.BringToFront();
            this.Rect = this.currentControl.Bounds;
            base.Region = new Region(this.BuildFrame());
            this.g = base.CreateGraphics();
        }

        private void CRectControl_Load(object sender, EventArgs e)
        {
        }

        public void Draw()
        {
            try
            {
                this.g.FillRectangles(Brushes.LightGray, this.BoundRect);
                this.g.FillRectangles(Brushes.White, this.SmallRect);
                this.g.DrawRectangles(Pens.Black, this.SmallRect);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public bool Hit_Test(int x, int y)
        {
            Point pt = new Point(x, y);
            if (!this.ControlRect.Contains(pt))
            {
                Cursor.Current = Cursors.Arrow;
                return false;
            }
            if (this.SmallRect[0].Contains(pt))
            {
                Cursor.Current = Cursors.SizeNWSE;
                this.CurrHitPlace = HitDownSquare.HDS_TOPLEFT;
            }
            else if (this.SmallRect[3].Contains(pt))
            {
                Cursor.Current = Cursors.SizeNWSE;
                this.CurrHitPlace = HitDownSquare.HDS_BOTTOMRIGHT;
            }
            else if (this.SmallRect[1].Contains(pt))
            {
                Cursor.Current = Cursors.SizeNESW;
                this.CurrHitPlace = HitDownSquare.HDS_TOPRIGHT;
            }
            else if (this.SmallRect[2].Contains(pt))
            {
                Cursor.Current = Cursors.SizeNESW;
                this.CurrHitPlace = HitDownSquare.HDS_BOTTOMLEFT;
            }
            else if (this.SmallRect[4].Contains(pt))
            {
                Cursor.Current = Cursors.SizeNS;
                this.CurrHitPlace = HitDownSquare.HDS_TOP;
            }
            else if (this.SmallRect[5].Contains(pt))
            {
                Cursor.Current = Cursors.SizeNS;
                this.CurrHitPlace = HitDownSquare.HDS_BOTTOM;
            }
            else if (this.SmallRect[6].Contains(pt))
            {
                Cursor.Current = Cursors.SizeWE;
                this.CurrHitPlace = HitDownSquare.HDS_LEFT;
            }
            else if (this.SmallRect[7].Contains(pt))
            {
                Cursor.Current = Cursors.SizeWE;
                this.CurrHitPlace = HitDownSquare.HDS_RIGHT;
            }
            else if (this.ControlRect.Contains(pt))
            {
                Cursor.Current = Cursors.SizeAll;
                this.CurrHitPlace = HitDownSquare.HDS_NONE;
            }
            return true;
        }

        private void InitializeComponent()
        {
            base.SuspendLayout();
            this.BackColor = Color.Wheat;
            base.Name = "CRectControl";
            base.Load += new EventHandler(this.CRectControl_Load);
            base.Paint += new PaintEventHandler(this.RectTracker_Paint);
            base.MouseMove += new MouseEventHandler(this.RectTracker_MouseMove);
            base.MouseUp += new MouseEventHandler(this.RectTracker_MouseUp);
            base.ResumeLayout(false);
        }

        public void Mouse_Move(object sender, MouseEventArgs e)
        {
            if (this.currentControl.Height < 8)
            {
                this.currentControl.Height = 8;
                if (this.currentControl is StimControl)
                {
                    ((StimControl)this.currentControl).Height = 8;
                }
            }
            else if (this.currentControl.Width < 8)
            {
                this.currentControl.Width = 8;
                if (this.currentControl is StimControl)
                {
                    ((StimControl)this.currentControl).Width = 8;
                }
            }
            else
            {
                switch (this.CurrHitPlace)
                {
                    case HitDownSquare.HDS_NONE:
                        if (this.currentControl.Parent != null)
                        {
                            for (int i = 0; i < this.currentControl.Parent.Controls.Count; i++)
                            {
                                string name = this.currentControl.Parent.Controls[i].Name;
                                if (this.currentControl.Parent.Controls[i].Name.IndexOf("CRectCtl") >= 0)
                                {
                                    this.currentControl.Parent.Controls[i].Visible = false;
                                }
                                else if (this.currentControl.Parent.Contains(this.currentControl.Parent.Controls["CRectCtl" + this.currentControl.Parent.Controls[i].Name]))
                                {
                                    this.currentControl.Parent.Controls[i].Left = (this.currentControl.Parent.Controls[i].Left + e.X) - this.prevLeftClick.X;
                                    this.currentControl.Parent.Controls[i].Top = (this.currentControl.Parent.Controls[i].Top + e.Y) - this.prevLeftClick.Y;
                                }
                            }
                            
                        }
                        break;

                    case HitDownSquare.HDS_TOP:
                        this.currentControl.Height = (this.currentControl.Height - e.Y) + this.prevLeftClick.Y;
                        if (this.currentControl.Height > 8)
                        {
                            this.currentControl.Top = (this.currentControl.Top + e.Y) - this.prevLeftClick.Y;
                        }
                        if (this.currentControl is StimControl)
                        {
                            ((StimControl)this.currentControl).Height = (this.currentControl.Height - e.Y) + this.prevLeftClick.Y;
                             
                        }
                        break;

                    case HitDownSquare.HDS_RIGHT:
                        this.currentControl.Width = (this.currentControl.Width + e.X) - this.prevLeftClick.X;
                        if (this.currentControl is StimControl)
                        {
                            ((StimControl)this.currentControl).Width = (this.currentControl.Width + e.X) - this.prevLeftClick.X;
                        }
                        break;

                    case HitDownSquare.HDS_BOTTOM:
                        this.currentControl.Height = (this.currentControl.Height + e.Y) - this.prevLeftClick.Y;
                        if (this.currentControl is StimControl)
                        {
                            ((StimControl)this.currentControl).Height = (this.currentControl.Height + e.Y) - this.prevLeftClick.Y;
                        }
                        break;

                    case HitDownSquare.HDS_LEFT:
                        this.currentControl.Width = (this.currentControl.Width - e.X) + this.prevLeftClick.X;
                        if (this.currentControl.Width > 8)
                        {
                            this.currentControl.Left = (this.currentControl.Left + e.X) - this.prevLeftClick.X;
                        } 
                        if (this.currentControl is StimControl)
                        {
                            ((StimControl)this.currentControl).Width = (this.currentControl.Width - e.X) + this.prevLeftClick.X;
                        }
                        break;

                    case HitDownSquare.HDS_TOPLEFT:
                        this.currentControl.Height = (this.currentControl.Height - e.Y) + this.prevLeftClick.Y;
                        if (this.currentControl.Height > 8)
                        {
                            this.currentControl.Top = (this.currentControl.Top + e.Y) - this.prevLeftClick.Y;
                        }
                        this.currentControl.Width = (this.currentControl.Width - e.X) + this.prevLeftClick.X;
                        if (this.currentControl.Width > 8)
                        {
                            this.currentControl.Left = (this.currentControl.Left + e.X) - this.prevLeftClick.X;
                        }
                        if (this.currentControl is StimControl)
                        {
                            ((StimControl)this.currentControl).Height = (this.currentControl.Height - e.Y) + this.prevLeftClick.Y;
                            ((StimControl)this.currentControl).Width = (this.currentControl.Width - e.X) + this.prevLeftClick.X;
                        }
                        break;

                    case HitDownSquare.HDS_TOPRIGHT:
                        this.currentControl.Height = (this.currentControl.Height - e.Y) + this.prevLeftClick.Y;
                        this.currentControl.Width = (this.currentControl.Width + e.X) - this.prevLeftClick.X;
                        if (this.currentControl is StimControl)
                        {
                            ((StimControl)this.currentControl).Height = (this.currentControl.Height - e.Y) + this.prevLeftClick.Y;
                            ((StimControl)this.currentControl).Width = (this.currentControl.Width + e.X) - this.prevLeftClick.X;
                        }
                        if (this.currentControl.Height > 8)
                        {
                            this.currentControl.Top = (this.currentControl.Top + e.Y) - this.prevLeftClick.Y;
                        }
                        break;

                    case HitDownSquare.HDS_BOTTOMLEFT:
                        this.currentControl.Height = (this.currentControl.Height + e.Y) - this.prevLeftClick.Y;
                        this.currentControl.Width = (this.currentControl.Width - e.X) + this.prevLeftClick.X;
                        if (this.currentControl is StimControl)
                        {
                            ((StimControl)this.currentControl).Height = (this.currentControl.Height + e.Y) - this.prevLeftClick.Y;
                            ((StimControl)this.currentControl).Width = (this.currentControl.Width - e.X) + this.prevLeftClick.X;
                        }
                        if (this.currentControl.Width > 8)
                        {
                            this.currentControl.Left = (this.currentControl.Left + e.X) - this.prevLeftClick.X;
                        }
                        break;

                    case HitDownSquare.HDS_BOTTOMRIGHT:
                        this.currentControl.Height = (this.currentControl.Height + e.Y) - this.prevLeftClick.Y;
                        this.currentControl.Width = (this.currentControl.Width + e.X) - this.prevLeftClick.X;
                        if (this.currentControl is StimControl)
                        {
                            ((StimControl)this.currentControl).Height = (this.currentControl.Height + e.Y) - this.prevLeftClick.Y;
                            ((StimControl)this.currentControl).Width = (this.currentControl.Width + e.X) - this.prevLeftClick.X;
                        }
                        break;
                }
            }
        }

        private void RectTracker_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.isFirst)
                {
                    this.prevLeftClick = new Point(e.X, e.Y);
                    this.isFirst = false;
                }
                else
                {
                    base.Visible = false;
                    this.Mouse_Move(this, e);
                    this.prevLeftClick = new Point(e.X, e.Y);
                }
            }
            else
            {
                this.isFirst = true;
                base.Visible = true;
                this.Hit_Test(e.X, e.Y);
            }
        }

        private void RectTracker_MouseUp(object sender, MouseEventArgs e)
        {
            this.Create();
            if ((sender as CRectControl).Parent != null)
            {
                for (int i = (sender as CRectControl).Parent.Controls.Count - 1; i >= 0; i--)
                {
                    if (((sender as CRectControl).Parent.Controls[i].Name.IndexOf("CRectCtl") >= 0) && ((sender as CRectControl).Parent.Controls[i].Name != (sender as CRectControl).Name))
                    {
                        string str = (sender as CRectControl).Parent.Controls[i].Name.Substring(8, (sender as CRectControl).Parent.Controls[i].Name.Length - 8);
                        (sender as CRectControl).Parent.Controls[i].Left = (sender as CRectControl).Parent.Controls[str].Left - 6;
                        (sender as CRectControl).Parent.Controls[i].Top = (sender as CRectControl).Parent.Controls[str].Top - 6;
                        (sender as CRectControl).Parent.Controls[i].Visible = true;
                    }
                }
            }
            base.Visible = true;
            if (CallBackHandler != null) CallBackHandler(null, null);
        }

        private void RectTracker_Paint(object sender, PaintEventArgs e)
        {
            if (base.Visible)
            {
                this.Draw();
            }
        }

        private void SetRectangles()
        {
            this.SmallRect[0] = new Rectangle(new Point(this.baseRect.X - this.Square.Width, this.baseRect.Y - this.Square.Height), this.Square);
            this.SmallRect[4] = new Rectangle(new Point((this.baseRect.X + (this.baseRect.Width / 2)) - (this.Square.Width / 2), this.baseRect.Y - this.Square.Height), this.Square);
            this.SmallRect[1] = new Rectangle(new Point(this.baseRect.X + this.baseRect.Width, this.baseRect.Y - this.Square.Height), this.Square);
            this.SmallRect[2] = new Rectangle(new Point(this.baseRect.X - this.Square.Width, this.baseRect.Y + this.baseRect.Height), this.Square);
            this.SmallRect[5] = new Rectangle(new Point((this.baseRect.X + (this.baseRect.Width / 2)) - (this.Square.Width / 2), this.baseRect.Y + this.baseRect.Height), this.Square);
            this.SmallRect[3] = new Rectangle(new Point(this.baseRect.X + this.baseRect.Width, this.baseRect.Y + this.baseRect.Height), this.Square);
            this.SmallRect[6] = new Rectangle(new Point(this.baseRect.X - this.Square.Width, (this.baseRect.Y + (this.baseRect.Height / 2)) - (this.Square.Height / 2)), this.Square);
            this.SmallRect[7] = new Rectangle(new Point(this.baseRect.X + this.baseRect.Width, (this.baseRect.Y + (this.baseRect.Height / 2)) - (this.Square.Height / 2)), this.Square);
            this.ControlRect = new Rectangle(new Point(0, 0), base.Bounds.Size);
        }

        public Rectangle Rect
        {
            get
            {
                return this.baseRect;
            }
            set
            {
                int width = this.Square.Width;
                int height = this.Square.Height;
                int num3 = value.Height;
                int num4 = value.Width;
                this.baseRect = new Rectangle(width, height, num4, num3);
                this.SetRectangles();
            }
        }

        private enum HitDownSquare
        {
            HDS_NONE,
            HDS_TOP,
            HDS_RIGHT,
            HDS_BOTTOM,
            HDS_LEFT,
            HDS_TOPLEFT,
            HDS_TOPRIGHT,
            HDS_BOTTOMLEFT,
            HDS_BOTTOMRIGHT
        }
    }
}

