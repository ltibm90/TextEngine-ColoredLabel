using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEngine.Evulator;
using TextEngine.Text;
using TextEngine_ColoredLabel.ColoredEvulators;
namespace TextEngine_ColoredLabel
{
    public class ColoredLabel : Control
    {
        private Color borderColor = SystemColors.ControlText;
        [DefaultValue(typeof(Color), "Black")]
        [Description("Border rengi")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value; 
                this.Invalidate(); //Border rengi değiştiğinde çizim yenilenir
            }
        }
        private int borderWidth = 0;
        [DefaultValue(0)]
        [Description("Border bouyutu(0 kapatır)")]
        public int BorderWidth
        {
            get
            {
                return borderWidth;
            }
            set
            {
                borderWidth = value;
                this.Invalidate(); // Border boyutu değiştiğinde çizim yenilenir
            }
        }

        private ContentAlignment textAlignment = ContentAlignment.TopLeft;
        [DefaultValue(ContentAlignment.TopLeft)]
        [Description("Metnin konumu belirler")]
        public ContentAlignment TextAlign
        {
            get
            {
                return textAlignment;
            }
            set
            {
                textAlignment = value;
                this.Invalidate(); //Metin konumu değeiştiğinde çizim yenilenir.
            }
        }
        protected override void OnPaddingChanged(EventArgs e)
        {
            this.Invalidate(); //Padding değişiminde çizim yenilenir.
            base.OnPaddingChanged(e);
        }
        /// <summary>
        /// Metin çizim alanını dönderir.
        /// </summary>
        /// <returns>RectangleF tipinde dönüş yapar</returns>
        protected RectangleF GetTextArea()
        {
            float borderWidthSingle = Convert.ToSingle(this.BorderWidth);
            RectangleF textRectangle = this.ClientRectangle;
            //Border boyutuna göre metin alanı yeniden konumlanır.
            if (this.BorderWidth > 0)
            {
                //Metin ile border içi içe girmemesi için, metnin konumunu bordere göre ayarlıyoruz.
                //Metni borderin boyutuna ek 2 birim daha öteledik.
                textRectangle.X = borderWidthSingle + 2;
                textRectangle.Y = borderWidthSingle + 2;

                //Metnin çizim alanını metnin başlangıç alanına göre konumlandırdık.
                textRectangle.Width -= textRectangle.X;
                textRectangle.Height -= textRectangle.Y;
            }
            //Padding değerlerine göre yeinden konumlandırıyoruz.
            textRectangle.Width -= this.Padding.Right - this.Padding.Left;
            textRectangle.Height -= this.Padding.Bottom - this.Padding.Top;
            textRectangle.X += this.Padding.Left;
            textRectangle.Y += this.Padding.Top;
            return textRerctangle;
        }
        /// <summary>
        /// Border çizimin alanını dönderir
        /// </summary>
        /// <returns>RectangleF tipinde dönüş yapar</returns>
        protected RectangleF GetBorderArea()
        {
            float borderWidthSingle = Convert.ToSingle(this.BorderWidth);
            RectangleF borderRect = this.ClientRectangle;
            //Borderi çerçeveye tam oturacak şekilde ayarlıyoruz.
            borderRect.Inflate(-borderWidthSingle / 2f, -borderWidthSingle / 2f);
            borderRect.Inflate(-0.5f, -0.5f);
            return borderRect;
        }
        /// <summary>
        /// Metin yazdırma işlemini yapar
        /// </summary>
        /// <param name="g">Çizim kaynağı</param>
        protected void DrawText(Graphics g)
        {
            RectangleF textRectangle = this.GetTextArea();

            //Çizilecek birşey yoksa devam etmez.
            if (textRectangle.Height <= 1 || textRectangle.Width <= 1) return;
            //Yukarıdaki ayarlamaları yaptıktan sonra metin çizdirme işlemini buradan yaptırıyoruz.
            ColoredTextRenderer.DrawColoredText(g, this.Text, this.Font, this.ForeColor, textRectangle, this.TextAlign);
        }
        /// <summary>
        /// Border çizimini yapar
        /// </summary>
        /// <param name="g">Çizim kaynağı</param>
        protected void DrawBorder(Graphics g)
        {
            if (this.BorderWidth > 0)
            {
                RectangleF borderRect = this.GetBorderArea();
                g.DrawRectangle(new Pen(new SolidBrush(this.BorderColor), this.BorderWidth), borderRect.X, borderRect.Y, borderRect.Width, borderRect.Height);
            }
        }
        //Boyama işlemi
        protected override void OnPaint(PaintEventArgs e)
        {
            //Çıktıyı kaliteli olarak belirttik.
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            //Borderi çizdir.
            this.DrawBorder(e.Graphics);

            //Metni yazdır.
            this.DrawText(e.Graphics);

            base.OnPaint(e);
        }
    }

}
