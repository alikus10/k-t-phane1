namespace kütüphane1
{
    partial class kütüphane_ana_sayfa
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
            this.üye_ekle_btn = new System.Windows.Forms.Button();
            this.kitap_ekle_btn = new System.Windows.Forms.Button();
            this.emanet_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // üye_ekle_btn
            // 
            this.üye_ekle_btn.Location = new System.Drawing.Point(95, 62);
            this.üye_ekle_btn.Name = "üye_ekle_btn";
            this.üye_ekle_btn.Size = new System.Drawing.Size(131, 77);
            this.üye_ekle_btn.TabIndex = 0;
            this.üye_ekle_btn.Text = "Üye Ekle";
            this.üye_ekle_btn.UseVisualStyleBackColor = true;
            this.üye_ekle_btn.Click += new System.EventHandler(this.üye_ekle_btn_Click);
            // 
            // kitap_ekle_btn
            // 
            this.kitap_ekle_btn.Location = new System.Drawing.Point(95, 163);
            this.kitap_ekle_btn.Name = "kitap_ekle_btn";
            this.kitap_ekle_btn.Size = new System.Drawing.Size(131, 77);
            this.kitap_ekle_btn.TabIndex = 0;
            this.kitap_ekle_btn.Text = "Kitap Ekle";
            this.kitap_ekle_btn.UseVisualStyleBackColor = true;
            this.kitap_ekle_btn.Click += new System.EventHandler(this.kitap_ekle_btn_Click);
            // 
            // emanet_btn
            // 
            this.emanet_btn.Location = new System.Drawing.Point(95, 266);
            this.emanet_btn.Name = "emanet_btn";
            this.emanet_btn.Size = new System.Drawing.Size(131, 77);
            this.emanet_btn.TabIndex = 0;
            this.emanet_btn.Text = "Emanet İşlemleri";
            this.emanet_btn.UseVisualStyleBackColor = true;
            this.emanet_btn.Click += new System.EventHandler(this.emanet_btn_Click);
            // 
            // kütüphane_ana_sayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 403);
            this.Controls.Add(this.emanet_btn);
            this.Controls.Add(this.kitap_ekle_btn);
            this.Controls.Add(this.üye_ekle_btn);
            this.Name = "kütüphane_ana_sayfa";
            this.Text = "Ana Sayfa";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button üye_ekle_btn;
        private System.Windows.Forms.Button kitap_ekle_btn;
        private System.Windows.Forms.Button emanet_btn;
    }
}

