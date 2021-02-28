using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEngine.Text;
using TextEngine_ColoredLabel.ColoredEvulators;

namespace TextEngine_ColoredLabel
{

    /// <summary>
    /// Renkli metin ile ilgili işlemleri bu sınıf sağlar.
    /// </summary>
    public class ColoredTextRenderer
    {
        /// <summary>
        /// Çizimi için gerekli evulator bu fonksiyon aracılığı ile oluşturulur.
        /// </summary>
        /// <param name="text">Ayrıştırılacak metin</param>
        /// <returns>TextEvaultor sınıfında dönüş yapar.</returns>
        private static TextEvulator GetEvulator(string text)
        {
            TextEvulator evulator = new TextEvulator(text);
            //Mevcut evulator tipi ve tag ayarlamalarını temizliyoruz.
            evulator.EvulatorTypes.Clear();
            evulator.TagInfos.Clear();

            //Sağ ve Sol tagları ayarlıyoruz.
            evulator.LeftTag = '[';
            evulator.RightTag = ']';

            //Hangi tag ve işlem için hangi evulatörlerin tetikleneceğini belirtiyoruz.
            evulator.EvulatorTypes.Text = typeof(DrawingEvulator);
            evulator.EvulatorTypes["b"] = typeof(BIUSEvulator);
            evulator.EvulatorTypes["i"] = typeof(BIUSEvulator);
            evulator.EvulatorTypes["u"] = typeof(BIUSEvulator);
            evulator.EvulatorTypes["s"] = typeof(BIUSEvulator);
            evulator.EvulatorTypes["color"] = typeof(ColorEvulator);
            //Metni ayrıştırıyoruz.
            evulator.Parse();
            return evulator;
        }
        /// <summary>
        /// Ekrana renkli metin yazdırır.
        /// </summary>
        /// <param name="g">Çizim kaynağı</param>
        /// <param name="text">Metin</param>
        /// <param name="font">Varsayılan Font</param>
        /// <param name="foreGroundColor">Varsayılan Renk</param>
        /// <param name="rectangle">Çizim Alanı</param>
        /// <param name="xOfs">Satır başlarındaki girinti</param>
        /// <param name="alignment">Yazdırılacak metin konumu</param>
        public static void DrawColoredText(Graphics g, string text, Font font, Color foreGroundColor, RectangleF rectangle,
            ContentAlignment alignment = ContentAlignment.TopLeft)
        {
            var evulator = GetEvulator(text);
            //Content Aligment derğindeki Yatay alanı alıyoruz.
            System.Windows.Forms.VisualStyles.HorizontalAlign halign = Utils.ContentAligmentToHorizontalAlign(alignment);
            //Content Aligment derğindeki Dfkey alanı alıyoruz.
            System.Windows.Forms.VisualStyles.VerticalAlignment valign = Utils.ContentAligmentToVerticalAlign(alignment);

            //Dikey ve Yatay olarak sol üst konumda ise bu alana girmez.
            if (halign != System.Windows.Forms.VisualStyles.HorizontalAlign.Left || valign != System.Windows.Forms.VisualStyles.VerticalAlignment.Top)
            {
                //Metin içerisindeki konumu hesaplattıroyurz.
                var result = MeasureColoredText(g, text, font, rectangle);
                switch (halign)
                {
                    case System.Windows.Forms.VisualStyles.HorizontalAlign.Center:
                        //Metin sarma işlemi uygulandıysa bu alana girmez.
                        if (!result.IsOverlayed)
                        {
                            rectangle.X += rectangle.Width / 2 - result.Size.Width / 2;
                        }
                        break;
                    case System.Windows.Forms.VisualStyles.HorizontalAlign.Right:
                        if (!result.IsOverlayed && result.Size.Width <= rectangle.Width)
                        {
                            rectangle.X = rectangle.X + rectangle.Width - result.Size.Width - 1;
                        }
                        break;
                }
                //Metin boyutu, çizim alanından büyük ise girmez.
                if (result.Size.Height < rectangle.Height)
                {
                    switch (valign)
                    {
                        case System.Windows.Forms.VisualStyles.VerticalAlignment.Center:
                            rectangle.Y += rectangle.Height / 2 - result.Size.Height / 2;
                            break;
                        case System.Windows.Forms.VisualStyles.VerticalAlignment.Bottom:
                            rectangle.Y = rectangle.Y + rectangle.Height - result.Size.Height;
                            break;
                    }
                }
            }
            ColoredInfo info = new ColoredInfo()
            {
                Font = font,
                ForeGroundColor = foreGroundColor,
                PointX = rectangle.X,
                PointY = rectangle.Y,
                Graphics = g,
                DrawRectangle = rectangle
            };
            evulator.CustomDataSingle = info;
            evulator.Elements.EvulateValue();
        }
        /// <summary>
        /// Renkli metnin boyutunu dönderir.
        /// </summary>
        /// <param name="g">Çizim kaynağı</param>
        /// <param name="text">Metin</param>
        /// <param name="font">Varsayılan Font</param>
        /// <param name="rectangle">Çizim alanı</param>
        /// <returns></returns>
        public static ColoredTextMeasureResult MeasureColoredText(Graphics g, string text, Font font, RectangleF rectangle)
        {

            var evulator = GetEvulator(text);
            //color evulatörünün çalışmasına bu aşamada gerek yok.
            evulator.EvulatorTypes["color"] = null;
            ColoredInfo info = new ColoredInfo()
            {
                Font = font,
                Graphics = g,
                DrawRectangle = rectangle,
                //Sadece hesaplama işlemi yapacak, ekrana basma işlemini yapmayacak.
                NoDraw = true,
                PointX = rectangle.X,
                PointY = rectangle.Y
            };
            evulator.CustomDataSingle = info;
            evulator.Elements.EvulateValue();
            return new ColoredTextMeasureResult
            {
                IsOverlayed = info.IsOverlayed,
                Size = new SizeF(info.PointX, info.PointY + info.MaxH),
                TotalLines = info.TotalLines
            };
        }
    }
}
