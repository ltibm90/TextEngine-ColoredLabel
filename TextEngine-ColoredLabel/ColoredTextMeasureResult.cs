using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextEngine_ColoredLabel
{
    /// <summary>
    /// Renkli metin boyutunu hesaplama işleminin sonucu dönderir.
    /// </summary>
    public class ColoredTextMeasureResult
    {
        /// <summary>
        /// Toplam satır sayısı
        /// </summary>
        public int TotalLines { get; set; }
        /// <summary>
        /// Metnin taşmadan dolayı aşağı satıra geçip geçmediğini gösterir
        /// </summary>
        public bool IsOverlayed { get; set; }
        /// <summary>
        /// Metnin boyutunu gösterir
        /// </summary>
        public SizeF Size { get; set; }
    }
}
