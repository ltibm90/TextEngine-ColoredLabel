using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEngine.Evulator;
using TextEngine.Text;
using System.Drawing;
namespace TextEngine_ColoredLabel.ColoredEvulators
{
   /// <summary>
   /// Bold Italic Underline Strikeout(BIUS) Evulator
   /// </summary>
    public class BIUSEvulator : BaseEvulator
    {
        //Mevcut font stili
        FontStyle lastStyle = FontStyle.Regular;
        public override TextEvulateResult Render(TextElement tag, object vars)
        {
            ColoredInfo info = this.Evulator.CustomDataSingle as ColoredInfo;
            //İşlem öncesinde, mevcut font stilini fazııya alıyoruz.
            lastStyle = info.Font.Style;
            //Büyük küçük duyarlılığı olmayacak.
            string elemName = tag.ElemName.ToLowerInvariant();
            //Girilen elemanın ismine göre işlem yapacak.
            if (elemName == "b") //[B]içerik[/B]
            {
                info.Font = new System.Drawing.Font(info.Font, info.Font.Style | System.Drawing.FontStyle.Bold);
            }
            else if(elemName == "i") //[I]içerik[/I]
            {
                info.Font = new System.Drawing.Font(info.Font, info.Font.Style | System.Drawing.FontStyle.Italic);
            }
            else if (elemName == "u") //[U]içerik[/U]
            {
                info.Font = new System.Drawing.Font(info.Font, info.Font.Style | System.Drawing.FontStyle.Underline);
            }
            else if (elemName == "s") //[S]içerik[/S]
            {
                info.Font = new System.Drawing.Font(info.Font, info.Font.Style | System.Drawing.FontStyle.Strikeout);
            }
            //DepthScan ile tag içerindeki diğer elemanların Evulate işlemi yapması sağlanır.
            return new TextEvulateResult()
            {
                Result = TextEvulateResultEnum.EVULATE_DEPTHSCAN
            };
        }
        public override void RenderFinish(TextElement tag, object vars, TextEvulateResult latestResult)
        {
            ColoredInfo info = this.Evulator.CustomDataSingle as ColoredInfo;
            //Mevcut tag içerisindeki işlem bittiğinde bir önceki ayarı geri atıyoruz.
            info.Font = new Font(info.Font, lastStyle);
            base.RenderFinish(tag, vars, latestResult);
        }

    }
}
