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

        }
    }

