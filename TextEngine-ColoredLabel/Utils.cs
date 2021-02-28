using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.Windows.Forms.VisualStyles;

namespace TextEngine_ColoredLabel
{
    public static class Utils
    {
        //Mevcut renk dizisi
        private static PropertyInfo[] colors = null;
        /// <summary>
        /// Metinden Color tipine dönüştürme işlemini sağlar.
        /// </summary>
        /// <param name="colorName">Renk ismi</param>
        /// <param name="defaultColor">Varsayılan dönüş rengi(Renk bulunamazsa dönüş yapılacak renk)</param>
        /// <returns>Girilen rengin Color tipinde karşılığını dönderir</returns>
        public static System.Drawing.Color StringToColor(string colorName, System.Drawing.Color defaultColor = default(System.Drawing.Color))
        {

            //Mevcut renk dizisi boş ise içeriğini dolduruyoruz, bu işlem sadece ilk seferinde çalışır.
            if(colors == null)
            {
                //Öncellikle Color tipinin Type sini alıyoruz.
                Type colorType = typeof(System.Drawing.Color);
                //colors dizisin içeriğini propertylerdkei renkler ile dolduruyoruz.
                //GetProperty ise Get özelliği/Public ve Static olan propertyleri dönderiyoruz.
                colors = colorType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.GetProperty | System.Reflection.BindingFlags.Static);
            }
            //colors dizisi içerisindeki renklerin isimleri ile verilen ismi Büyük küçük duyarsız şekilde karşılaştırıyoruz.
            var findedColor = colors.Where(e => e.Name.ToLowerInvariant() == colorName.ToLowerInvariant()).FirstOrDefault();
            //Renk mevcut değilse null dönüş yapacak.
            if (findedColor == null) return defaultColor;
            //Renk mevcut ise Property değerini Color tipine Cast ederek dönüş yapıyoruz.
            return (System.Drawing.Color)findedColor.GetValue(null);
        }

        /// <summary>
        /// ContentAlignment tipini HorizontalAlign tipine çevirir
        /// </summary>
        /// <param name="alignment">Çevirilecek tip</param>
        /// <returns>HorizontalAlign tipinde dönüş yapar</returns>
        public static HorizontalAlign ContentAligmentToHorizontalAlign(System.Drawing.ContentAlignment alignment)
        {
            if ((alignment & (System.Drawing.ContentAlignment.TopCenter | System.Drawing.ContentAlignment.MiddleCenter 
                | System.Drawing.ContentAlignment.BottomCenter)) != 0)
            {
                return HorizontalAlign.Center;
            }
            else if ((alignment & (System.Drawing.ContentAlignment.TopRight | System.Drawing.ContentAlignment.MiddleRight 
                | System.Drawing.ContentAlignment.BottomRight)) != 0)
            {
                return HorizontalAlign.Right;
            }
            return HorizontalAlign.Left;
        }
        /// <summary>
        /// ContentAlignment tipini VerticalAlignment tipine çevirir
        /// </summary>
        /// <param name="alignment">Çevirilecek tip</param>
        /// <returns>VerticalAlignment tipinde dönüş yapar</returns>
        public static VerticalAlignment ContentAligmentToVerticalAlign(System.Drawing.ContentAlignment alignment)
        {
            if ((alignment & (System.Drawing.ContentAlignment.MiddleLeft | System.Drawing.ContentAlignment.MiddleCenter | 
                System.Drawing.ContentAlignment.MiddleRight)) != 0)
            {
                return VerticalAlignment.Center;
            }
            else if ((alignment & (System.Drawing.ContentAlignment.BottomLeft | System.Drawing.ContentAlignment.BottomCenter
                | System.Drawing.ContentAlignment.BottomRight)) != 0)
            {
                return VerticalAlignment.Bottom;
            }
            return VerticalAlignment.Top;
        }
    }
}
