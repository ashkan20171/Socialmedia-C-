using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialMediaLikeTelegram
{
    class SemiTransparentPanel : Panel
    {
        public SemiTransparentPanel()
        {

        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams CP = base.CreateParams;
                CP.ExStyle |= 0x00000020;
                return CP;
            }
        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            //base.OnPaintBackground(pevent);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(Alpha, BaseColor)), this.ClientRectangle);
        }
        private int _alpha = 180;
        public int Alpha { get { return _alpha; } set { _alpha = value; OnPaint(new PaintEventArgs(CreateGraphics(), this.ClientRectangle)); } }
        private Color _baseColor;
        public Color BaseColor { get { return _baseColor; } set { _baseColor = value; OnPaint(new PaintEventArgs(CreateGraphics(), this.ClientRectangle)); } }
    }
}
