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
    public partial class Üye_ekle : Form
    {
        public Üye_ekle()
        {
            InitializeComponent();
        }

        private void ekle1_btn_Click(object sender, EventArgs e)
        {
            // Kullanıcı arayüzünden üye bilgilerini alın
            string ad = textBox1.Text;
            string soyad = textBox2.Text;
            string e_mail = textBox3.Text;
            string telefon = textBox4.Text;
            

            // Alınan bilgilerle yeni bir Uye nesnesi oluşturun
            Uye yeniUye = new Uye
            {
                Ad = ad,
                Soyad = soyad,
                Email = e_mail,
                Telefon = telefon
            };

            // Mevcut üyeler listesini alın
            List<Uye> uyeler = KutuphaneIslemleri.UyeOku();

            // Yeni üyeyi mevcut üyeler listesine ekleyin
            uyeler.Add(yeniUye);

            // Güncellenmiş üyeler listesini JSON dosyasına kaydedin
            KutuphaneIslemleri.UyeKaydet(uyeler);

            // Kullanıcıya ekleme işleminin başarıyla gerçekleştirildiğine dair bir mesaj gösterin
            MessageBox.Show("Üye başarıyla eklendi.");
        }
    }
}
