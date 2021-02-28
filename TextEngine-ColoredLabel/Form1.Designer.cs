
namespace TextEngine_ColoredLabel
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.coloredLabel2 = new TextEngine_ColoredLabel.ColoredLabel();
            this.coloredLabel1 = new TextEngine_ColoredLabel.ColoredLabel();
            this.coloredLabel3 = new TextEngine_ColoredLabel.ColoredLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // coloredLabel2
            // 
            this.coloredLabel2.BorderColor = System.Drawing.Color.Coral;
            this.coloredLabel2.BorderWidth = 1;
            this.coloredLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.coloredLabel2.ForeColor = System.Drawing.Color.Black;
            this.coloredLabel2.Location = new System.Drawing.Point(32, 217);
            this.coloredLabel2.Name = "coloredLabel2";
            this.coloredLabel2.Size = new System.Drawing.Size(287, 52);
            this.coloredLabel2.TabIndex = 1;
            this.coloredLabel2.Text = "[COLOR=RED]Kırmızı[/COLOR] [COLOR=GREEN]Yeşil[/COLOR] [COLOR=BLUE][B][U]Bold Mavi" +
    " Underline[/U][/B][/COLOR]";
            this.coloredLabel2.Click += new System.EventHandler(this.coloredLabel2_Click);
            // 
            // coloredLabel1
            // 
            this.coloredLabel1.BorderColor = System.Drawing.SystemColors.ControlText;
            this.coloredLabel1.ForeColor = System.Drawing.Color.Black;
            this.coloredLabel1.Location = new System.Drawing.Point(32, 85);
            this.coloredLabel1.Name = "coloredLabel1";
            this.coloredLabel1.Size = new System.Drawing.Size(165, 37);
            this.coloredLabel1.TabIndex = 0;
            this.coloredLabel1.Text = "[B]bold[/B] [I]italic[/I] [u]underline[/u] [s]strikeout[/s]";
            // 
            // coloredLabel3
            // 
            this.coloredLabel3.BorderColor = System.Drawing.Color.Red;
            this.coloredLabel3.BorderWidth = 1;
            this.coloredLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.coloredLabel3.ForeColor = System.Drawing.Color.Black;
            this.coloredLabel3.Location = new System.Drawing.Point(32, 371);
            this.coloredLabel3.Name = "coloredLabel3";
            this.coloredLabel3.Size = new System.Drawing.Size(287, 52);
            this.coloredLabel3.TabIndex = 2;
            this.coloredLabel3.Text = "[COLOR=GREEN]Cyber[/COLOR] [COLOR=RED]Warrior[/COLOR] [COLOR=LIME][B][U]AR-GE Gru" +
    "p[/U][/B][/COLOR]";
            this.coloredLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(29, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(354, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "[B]bold[/B] [I]italic[/I] [u]underline[/u] [s]strikeout[/s]";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(29, 149);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(759, 65);
            this.label2.TabIndex = 4;
            this.label2.Text = "[COLOR=RED]Kırmızı[/COLOR] [COLOR=GREEN]Yeşil[/COLOR] [COLOR=BLUE][B][U]Bold Mavi" +
    " Underline[/U][/B][/COLOR]\r\nBorder kullanıldı";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(29, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(759, 65);
            this.label3.TabIndex = 5;
            this.label3.Text = "[COLOR=GREEN]Cyber[/COLOR] [COLOR=RED]Warrior[/COLOR] [COLOR=LIME][B][U]AR-GE Gru" +
    "p[/U][/B][/COLOR]\r\nBorder kulalnıldı, metin her iki taraftanda ortalı olarak aya" +
    "rlandı";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.coloredLabel3);
            this.Controls.Add(this.coloredLabel2);
            this.Controls.Add(this.coloredLabel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ColoredLabel coloredLabel1;
        private ColoredLabel coloredLabel2;
        private ColoredLabel coloredLabel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

