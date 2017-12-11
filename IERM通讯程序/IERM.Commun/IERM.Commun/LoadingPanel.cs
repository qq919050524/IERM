using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IERM.WCFService
{
    /// <summary>
    /// 透明的加载等待层
    /// </summary>
    [ToolboxBitmap(typeof(LoadingPanel))]
    public class LoadingPanel : System.Windows.Forms.Control
    {
        /// <summary>
        /// 是否背景透明
        /// </summary>
        private bool _transparentBG = true;
        /// <summary>
        /// 透明度
        /// </summary>
        private int _alpha = 125;

        /// <summary>
        /// 容器组件
        /// </summary>
        private System.ComponentModel.Container components = new System.ComponentModel.Container();

        /// <summary>
        /// 构造函数
        /// </summary>
        public LoadingPanel() : this(true) { }
        /// <summary>
        /// 标准构造函数
        /// </summary>
        /// <param name="Alpha"></param>
        /// <param name="showLoadingImage"></param>
        public LoadingPanel(bool showLoadingImage)
        {
            // | ControlStyles.OptimizedDoubleBuffer AllPaintingInWmPaint
            SetStyle(ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            base.CreateControl();
            // 显示等待的图像
            if (showLoadingImage)
            {
                PictureBox pictureBox_Loading = new PictureBox();
                pictureBox_Loading.BackColor = System.Drawing.Color.White;
                pictureBox_Loading.Image = Properties.Resources.loading;
                pictureBox_Loading.Name = "pictureBox_Loading";
                pictureBox_Loading.Size = new System.Drawing.Size(48, 48);
                pictureBox_Loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
                Point Location = new Point(this.Location.X + (this.Width - pictureBox_Loading.Width) / 2, this.Location.Y + (this.Height - pictureBox_Loading.Height) / 2);
                pictureBox_Loading.Location = Location;
                pictureBox_Loading.Anchor = AnchorStyles.None;
                this.Controls.Add(pictureBox_Loading);
            }


        }
        /// <summary>
        /// 析构处理
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!((components == null)))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// 自定义绘制窗体
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            float vlblControlWidth;
            float vlblControlHeight;

            Pen labelBorderPen;
            SolidBrush labelBackColorBrush;

            if (_transparentBG)
            {
                Color drawColor = Color.FromArgb(this._alpha, this.BackColor);
                labelBorderPen = new Pen(drawColor, 0);
                labelBackColorBrush = new SolidBrush(drawColor);
            }
            else
            {
                labelBorderPen = new Pen(this.BackColor, 0);
                labelBackColorBrush = new SolidBrush(this.BackColor);
            }
            vlblControlWidth = this.Size.Width;
            vlblControlHeight = this.Size.Height;
            e.Graphics.DrawRectangle(labelBorderPen, 0, 0, vlblControlWidth, vlblControlHeight);
            e.Graphics.FillRectangle(labelBackColorBrush, 0, 0, vlblControlWidth, vlblControlHeight);

            base.OnPaint(e);
        }
        /// <summary>
        /// 控件透明特性
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                // 开启 WS_EX_TRANSPARENT,使控件支持透明
                cp.ExStyle |= 0x20;
                return cp;
            }
        }
        /// <summary>
        /// 是否使用透明
        /// </summary>
        [Category("AlphaOpaque"), Description("是否使用透明,默认为True")]
        public bool TransparentBG
        {
            get { return _transparentBG; }
            set
            {
                _transparentBG = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// 设置透明度
        /// </summary>
        [Category("AlphaOpaque"), Description("设置透明度")]
        public int Alpha
        {
            get { return _alpha; }
            set
            {
                _alpha = value;
                this.Invalidate();
            }
        }
        /// <summary>
        /// 隐藏处理
        /// </summary>
        internal void CloseWaitingPanel()
        {
            this.BeginInvoke(new Action(() =>
            {
                SendToBack();
                Hide();

            }));
        }
        /// <summary>
        /// 显示处理
        /// </summary>
        internal void ShowWaitingPanel()
        {
            this.BeginInvoke(new Action(() =>
            {
                BringToFront();
                Show();
            }));
        }
    }
}
