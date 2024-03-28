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
            // Kullanıcı arayüzünden emanet bilgilerini alın
            string uyeAd = textBox1.Text;
            string kitapISBN = textBox2.Text;
            DateTime emanetTarihi = dateTimePicker1.Value;
            DateTime teslimTarihi = dateTimePicker2.Value;

            // Mevcut üyeler ve kitaplar listelerini alın
            List<Uye> uyeler = KutuphaneIslemleri.UyeOku();
            List<Kitap> kitaplar = KutuphaneIslemleri.KitapOku();

            // Uygun üye ve kitabı bulun
            Uye uye = uyeler.Find(u => u.Ad == uyeAd);
            Kitap kitap = kitaplar.Find(k => k.ISBN == kitapISBN);

            // Eğer uygun üye veya kitap bulunamazsa, kullanıcıya bilgi verin
            if (uye == null || kitap == null)
            {
                MessageBox.Show("Üye veya kitap bulunamadı. Lütfen geçerli bir üye adı ve kitap ISBN numarası girin.");
                return;
            }

            // Alınan bilgilerle yeni bir Emanet nesnesi oluşturun
            Emanet yeniEmanet = new Emanet
            {
                Uye = uye,
                Kitap = kitap,
                EmanetTarihi = emanetTarihi,
                TeslimTarihi = teslimTarihi
            };

            // Mevcut emanetler listesini alın
            List<Emanet> emanetler = KutuphaneIslemleri.EmanetOku();

            // Yeni emaneti mevcut emanetler listesine ekleyin
            emanetler.Add(yeniEmanet);

            // Güncellenmiş emanetler listesini JSON dosyasına kaydedin
            KutuphaneIslemleri.EmanetKaydet(emanetler);

            // Kullanıcıya emanet işleminin başarıyla gerçekleştirildiğine dair bir mesaj gösterin
            MessageBox.Show("Emanet işlemi başarıyla gerçekleştirildi.");
        }
    }
}
