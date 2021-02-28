using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextEngine.Evulator;
using TextEngine.Text;

namespace TextEngine_ColoredLabel.ColoredEvulators
{
    /// <summary>
    /// [COLOR=RENK]Metin[/COLOR] içeriğini değerlendirir.
    /// </summary>
    public class ColorEvulator : BaseEvulator
    {
        //Mevcut yazı rengi
        Color latestColor;
        public override TextEvulateResult Render(TextElement tag, object vars)
        {
            ColoredInfo info = this.Evulator.CustomDataSingle as ColoredInfo;
            //Bir önceki rengi hafızaya alıyoruz.
            latestColor = info.ForeGroundColor;
            //Mevcut yezi yazı rengini atıyoruz 
            //TagAttrib [COLOR=RENK) (TagAttrib bu kısımda RENK olarak kullanılır)
            info.ForeGroundColor = Utils.StringToColor(tag.TagAttrib, info.ForeGroundColor);
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
            info.ForeGroundColor = latestColor;
            base.RenderFinish(tag, vars, latestResult);
        }
    }
}
