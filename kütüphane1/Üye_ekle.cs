using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

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
            string ad = textBox1.Text;
            string soyad = textBox2.Text;
            string e_mail = textBox3.Text;
            string telefon = textBox4.Text;

            Uye yeniUye = new Uye
            {
                Ad = ad,
                Soyad = soyad,
                Email = e_mail,
                Telefon = telefon
            };

            // Mevcut üyeleri al
            List<Uye> uyeler = KutuphaneIslemleri.UyeOku();

            // Yeni üyeyi listeye ekle
            uyeler.Add(yeniUye);

            // Güncellenmiş üye listesini veritabanına kaydet
            KutuphaneIslemleri.UyeKaydet(uyeler);

            // SQLite veritabanına sadece yeni üyeyi ekle
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=kütüphane.db;Version=3;"))
            {
                conn.Open();
                string insertQuery = "INSERT INTO üye (Ad, Soyad, Email, Telefon) VALUES (@Ad, @Soyad, @Email, @Telefon)";
                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@Ad", yeniUye.Ad);
                    cmd.Parameters.AddWithValue("@Soyad", yeniUye.Soyad);
                    cmd.Parameters.AddWithValue("@Email", yeniUye.Email);
                    cmd.Parameters.AddWithValue("@Telefon", yeniUye.Telefon);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Üye başarıyla eklendi.");

            // TextBox'ları temizle
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }


        private void üye_sil_btn_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string soyad = textBox2.Text;

            List<Uye> uyeler = KutuphaneIslemleri.UyeOku();

            Uye silinecekUye = uyeler.Find(u => u.Ad == ad && u.Soyad == soyad);

            if (silinecekUye == null)
            {
                MessageBox.Show("Belirtilen üye bulunamadı.");
                return;
            }

            uyeler.Remove(silinecekUye);
            KutuphaneIslemleri.UyeKaydet(uyeler);

            MessageBox.Show("Üye başarıyla silindi.");

            textBox1.Clear();
            textBox2.Clear();
        }

        private void üye_güncelle_btn_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string soyad = textBox2.Text;

            List<Uye> uyeler = KutuphaneIslemleri.UyeOku();

            Uye güncellenecekUye = uyeler.Find(u => u.Ad == ad && u.Soyad == soyad);

            if (güncellenecekUye == null)
            {
                MessageBox.Show("Belirtilen üye bulunamadı.");
                return;
            }

            string yeniAd = textBox5.Text;
            string yeniSoyad = textBox6.Text;
            string yeniEmail = textBox7.Text;
            string yeniTelefon = textBox8.Text;

            if (string.IsNullOrWhiteSpace(yeniAd) || string.IsNullOrWhiteSpace(yeniSoyad) || string.IsNullOrWhiteSpace(yeniEmail) || string.IsNullOrWhiteSpace(yeniTelefon))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            güncellenecekUye.Ad = yeniAd;
            güncellenecekUye.Soyad = yeniSoyad;
            güncellenecekUye.Email = yeniEmail;
            güncellenecekUye.Telefon = yeniTelefon;

            KutuphaneIslemleri.UyeKaydet(uyeler);

            MessageBox.Show("Üye bilgileri başarıyla güncellendi.");

            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
        }

        private void üyelere_bak_btn_Click(object sender, EventArgs e)
        {
            // SQLite veritabanından tüm üyeleri çek
            List<Uye> uyeler;
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=kütüphane.db;Version=3;"))
            {
                conn.Open();
                string selectQuery = "SELECT * FROM üye";
                using (SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        uyeler = new List<Uye>();
                        while (reader.Read())
                        {
                            Uye uye = new Uye
                            {
                                Ad = reader["Ad"].ToString(),
                                Soyad = reader["Soyad"].ToString(),
                                Email = reader["Email"].ToString(),
                                Telefon = reader["Telefon"].ToString()
                            };
                            uyeler.Add(uye);
                        }
                    }
                }
            }

            // Çekilen üyeleri ekrana göster
            StringBuilder sb = new StringBuilder();
            foreach (Uye uye in uyeler)
            {
                sb.AppendLine($"Ad: {uye.Ad}, Soyad: {uye.Soyad}, Email: {uye.Email}, Telefon: {uye.Telefon}");
            }
            MessageBox.Show(sb.ToString(), "Üyeler");
        }

    }

}
