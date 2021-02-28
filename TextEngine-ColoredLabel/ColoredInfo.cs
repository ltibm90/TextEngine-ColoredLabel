using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEngine_ColoredLabel
{
    /// <summary>
    /// ColoredLabel içerisindeki Evulator sınıfları bu sınıf aracılığı ile işlem yapacaklar.
    /// </summary>
    public class ColoredInfo
    {
        /// <summary>
        /// Yazı rengi
        /// </summary>
        public Color ForeGroundColor { get; set; }
        /// <summary>
        /// Font
        /// </summary>
        public Font Font { get; set; }
        public Graphics Graphics { get; set; }
        /// <summary>
        /// Son X konumu
        /// </summary>
        public float PointX { get; set; }
        /// <summary>
        /// Son Y konumu
        /// </summary>
        public float PointY { get; set; }
        /// <summary>
        /// Satır içerisinde en büyük karakterin boyutu
        /// </summary>
        public float MaxH { get; set; }
        /// <summary>
        /// Sadece hesaplama işlemi yapar
        /// </summary>
        public bool NoDraw { get; set; }
        /// <summary>
        /// Çizim alanı
        /// </summary>
        public RectangleF DrawRectangle { get; set; }
        /// <summary>
        /// Toplam satır sayısı
        /// </summary>
        public int TotalLines { get; set; }
        /// <summary>
        /// Metin taşmadan dolayı satır atlayıp atlamadığını dönderir.
        /// </summary>
        public bool IsOverlayed { get; set; }
    }
}
