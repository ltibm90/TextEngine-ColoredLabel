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
    //ColorEvulator veya BIUSEvulator işleminden sonra bu kısım tetiklendir.
    class DrawingEvulator : BaseEvulator
    {
        public override TextEvulateResult Render(TextElement tag, object vars)
        {
            ColoredInfo info = this.Evulator.CustomDataSingle as ColoredInfo;
            //Karakter boyutunu hesaplayacağımız sınıfı kuruyorruz.
            StringFormat sf = new StringFormat(StringFormat.GenericTypographic);
            //Hesaplamada kırpmalar olmayacak.
            sf.Trimming = StringTrimming.None;
            //Boşluk karakteride hesaplamaya dâhil edilecek.
            sf.FormatFlags = StringFormatFlags.MeasureTrailingSpaces; 
            //1. karakteerden başlayıp 1 karakterin uzunluğunu heesaplayacak.
            sf.SetMeasurableCharacterRanges(new CharacterRange[] { new CharacterRange() { First = 1, Length = 1 } });
            PointF point = new PointF(info.PointX, info.PointY);
            RectangleF rect = info.DrawRectangle;
            //Karakte karakter hesaplatmamızın sebebi, metin sarma işleminin hesaplanması ve bazı karakterler arasında oluşan boşluk
            //sebebini düzeltmek içindir.
            for (int i = 0; i < tag.Value.Length; i++)
            {
                //mevcut karakter.
                char cur = tag.Value[i];
                bool istab = false;
                //tab karakterini boşluk karakteri gibi hesaplayıp 7 ile çarapacak.
                if(cur == '\t')
                {
                    cur = ' ';
                    istab = true;
                }
                //Karakter iki + içerisinde hesaplatmamızın sebebi, bazı karakterleri doğrudan hesapladığında belirli boşluk problemlerinin
                //ortaya çıkmasıdır.
                RectangleF size = info.Graphics.MeasureCharacterRanges("+" + cur.ToString() + "+", info.Font, rect, sf)[0].GetBounds(info.Graphics);
                if (istab)
                {
                    //Tab karakteri ise sadece width verecek, herhangi bir çizim işlemi uygulamayacak.
                    size.Width *= 7;
                    point.X += size.Width;
                    continue;
                }
                //Mevcut satır üzerinde maximum büyüklüğü belirtiyoruz.
                if (size.Height > info.MaxH) info.MaxH = size.Height;
                //Mevcut uzunluk, metin alanını genişliğini geçiyorsa, otomatik olarak bir alt satıra geçiş yapacak.
                if (!istab && (cur == '\n' || point.X + size.Width > rect.Width))
                {
                    point.Y += info.MaxH;
                    point.X = rect.X;
                    info.MaxH = (cur == '\n') ? 0 : size.Height;
                    info.TotalLines++;
                    if (!info.IsOverlayed && cur != '\n') info.IsOverlayed = true;
                    //Mevcut Y konumu çizim alanından büyük ise diğer kısımlar çizilmeyecek işlem burda sonlanacak.
                    if(!info.NoDraw && point.Y + size.Height > rect.Height)
                    {
                        info.PointX = point.X;
                        info.PointY = point.Y;
                        return new TextEvulateResult()
                        {
                            Result = TextEvulateResultEnum.EVULATE_RETURN
                        };
                    }
                }
                //satır karateri için çizim yapmaz.
                if (cur == '\n') continue;
                //Boşluklar underline gibi özellikleri çizmesi için görünmeyen bir karaktere denk getirdik.
                if (cur == ' ') cur = '\u007F';
                //Mevcut karakteri son konuma göre ekrana çizdiriyoruz.
                if(!info.NoDraw)
                {
                    info.Graphics.DrawString(cur.ToString(), info.Font, new SolidBrush(info.ForeGroundColor), point, sf);
                }

                //Son konuma mevcut karakter boyutunu dâhil ettiriyoruz.
                point.X += size.Width;
            }
            //Diğer evulatörlerin bu değişiklikleri görebilmesi için son konumların atamasını yapıyoruz.
            info.PointX = point.X;
            info.PointY = point.Y;
            //Geriye bir dönüş yapmıyor.
            return null;
        }
    }
}
