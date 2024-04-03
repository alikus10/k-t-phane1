using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kütüphane1
{
    public partial class Kitap_ekle : Form
    {
        public Kitap_ekle()
        {
            InitializeComponent();
        }

        private void ekle2_btn_Click(object sender, EventArgs e)
        {

            // Kullanıcı arayüzünden kitap bilgilerini alın
            string ad = textBox1.Text;
            string isbn = textBox2.Text;
            string yazar = textBox3.Text;

            // Alınan bilgilerle yeni bir Kitap nesnesi oluşturun
            Kitap yeniKitap = new Kitap
            {
                ISBN = isbn,
                Ad = ad,
                Yazar = yazar,

            };

            // Mevcut kitaplar listesini alın
            List<Kitap> kitaplar = KutuphaneIslemleri.KitapOku();

            // Yeni kitabı mevcut kitaplar listesine ekleyin
            kitaplar.Add(yeniKitap);

            // Güncellenmiş kitaplar listesini JSON dosyasına kaydedin
            KutuphaneIslemleri.KitapKaydet(kitaplar);

            // Kullanıcıya ekleme işleminin başarıyla gerçekleştirildiğine dair bir mesaj gösterin
            MessageBox.Show("Kitap başarıyla eklendi.");
        }
        private void kitap_sil_btn_Click(object sender, EventArgs e)
        {
            // Silmek istediğimiz kitabın adını ve ISBN numarasını alalım
            string kitapAdi = textBox1.Text; // Kitabın adının textBox1'e girildiği varsayılarak
            string kitapISBN = textBox2.Text; // Kitabın ISBN numarasının textBox2'ye girildiği varsayılarak

            // Kayıtlı kitapları okuyalım
            List<Kitap> kitaplar = KutuphaneIslemleri.KitapOku();

            // Silmek istediğimiz kitabı bulalım (ad ve ISBN numarasına göre arama)
            Kitap silinecekKitap = kitaplar.Find(k => k.Ad == kitapAdi && k.ISBN == kitapISBN);

            // Eğer böyle bir kitap bulunamadıysa uyarı verelim
            if (silinecekKitap == null)
            {
                MessageBox.Show("Belirtilen kitap bulunamadı.");
                return;
            }

            // Kitabı listeden silelim
            kitaplar.Remove(silinecekKitap);

            // Değişiklikleri kaydedelim
            KutuphaneIslemleri.KitapKaydet(kitaplar);

            MessageBox.Show("Kitap başarıyla silindi.");
        }


    }
}