using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kütüphane1
{
    public partial class Emanet : Form
    {
        public Emanet()
        {
            InitializeComponent();
        }

        private void ekle3_btn_Click(object sender, EventArgs e)
        {
            string uyeAd = textBox1.Text;
            string kitapISBN = textBox2.Text;
            DateTime emanetTarihi = dateTimePicker1.Value;
            DateTime teslimTarihi = dateTimePicker2.Value;

            List<Uye> uyeler = KutuphaneIslemleri.UyeOku();
            List<Kitap> kitaplar = KutuphaneIslemleri.KitapOku();

            Uye uye = uyeler.Find(u => u.Ad == uyeAd);
            Kitap kitap = kitaplar.Find(k => k.ISBN == kitapISBN);

            if (uye == null || kitap == null)
            {
                MessageBox.Show("Üye veya kitap bulunamadı. Lütfen geçerli bir üye adı ve kitap ISBN numarası girin.");
                return;
            }

            Emanet yeniEmanet = new Emanet
            {
                Uye = uye,
                Kitap = kitap,
                EmanetTarihi = emanetTarihi,
                TeslimTarihi = teslimTarihi
            };

            List<Emanet> emanetler = KutuphaneIslemleri.EmanetOku();
            emanetler.Add(yeniEmanet);

            KutuphaneIslemleri.EmanetKaydet(emanetler);

            MessageBox.Show("Emanet işlemi başarıyla gerçekleştirildi.");
        }

        private void emanet_al_btn_Click(object sender, EventArgs e)
        {
            // Seçilen üye adını ve kitap ISBN numarasını alalım
            string uyeAd = textBox1.Text; // Üye adının textBox1'e girildiği varsayılarak
            string kitapISBN = textBox2.Text; // Kitap ISBN numarasının textBox2'ye girildiği varsayılarak

            // Kayıtlı emanetleri okuyalım
            List<Emanet> emanetler = KutuphaneIslemleri.EmanetOku();

            // Emaneti bulalım (üye adı ve kitap ISBN numarasına göre arama)
            Emanet alinacakEmanet = emanetler.Find(em => em.Uye.Ad == uyeAd && em.Kitap.ISBN == kitapISBN);

            // Eğer böyle bir emanet bulunamadıysa uyarı verelim
            if (alinacakEmanet == null)
            {
                MessageBox.Show("Belirtilen emanet bulunamadı.");
                return;
            }

            // Emaneti listeden kaldıralım
            emanetler.Remove(alinacakEmanet);

            // Değişiklikleri kaydedelim
            KutuphaneIslemleri.EmanetKaydet(emanetler);

            MessageBox.Show("Emanet başarıyla geri alındı.");
        }

    }
}
