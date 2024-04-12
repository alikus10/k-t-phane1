using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
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
            string ad = textBox1.Text;
            string isbn = textBox2.Text;
            string yazar = textBox3.Text;

            Kitap yeniKitap = new Kitap
            {
                ISBN = isbn,
                Ad = ad,
                Yazar = yazar
            };

            List<Kitap> kitaplar = KutuphaneIslemleri.KitapOku();

            kitaplar.Add(yeniKitap);

            KutuphaneIslemleri.KitapKaydet(kitaplar);

            MessageBox.Show("Kitap başarıyla eklendi.");

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=kütüphane.db;Version=3;"))
            {
                conn.Open();
                string insertQuery = "INSERT INTO kitap (ISBN, Ad, Yazar) VALUES (@ISBN, @Ad, @Yazar)";
                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@ISBN", yeniKitap.ISBN);
                    cmd.Parameters.AddWithValue("@Ad", yeniKitap.Ad);
                    cmd.Parameters.AddWithValue("@Yazar", yeniKitap.Yazar);
                    cmd.ExecuteNonQuery();
                }
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
    
        private void kitap_sil_btn_Click(object sender, EventArgs e)
        {
            string kitapAdi = textBox1.Text; 
            string kitapISBN = textBox2.Text; 

            List<Kitap> kitaplar = KutuphaneIslemleri.KitapOku();

            Kitap silinecekKitap = kitaplar.Find(k => k.Ad == kitapAdi && k.ISBN == kitapISBN);

            if (silinecekKitap == null)
            {
                MessageBox.Show("Belirtilen kitap bulunamadı.");
                return;
            }

            kitaplar.Remove(silinecekKitap);

            KutuphaneIslemleri.KitapKaydet(kitaplar);

            MessageBox.Show("Kitap başarıyla silindi.");
        }

        private void kitap_bak_btn_Click(object sender, EventArgs e)
        {
            List<Kitap> kitaplar;
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=kütüphane.db;Version=3;"))
            {
                conn.Open();
                string selectQuery = "SELECT * FROM kitap";
                using (SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        kitaplar = new List<Kitap>();
                        while (reader.Read())
                        {
                            Kitap kitap = new Kitap
                            {
                                ISBN = reader["ISBN"].ToString(),
                                Ad = reader["Ad"].ToString(),
                                Yazar = reader["Yazar"].ToString()
                            };
                            kitaplar.Add(kitap);
                        }
                    }
                }
            }

            // Çekilen kitapları ekrana göster
            StringBuilder sb = new StringBuilder();
            foreach (Kitap kitap in kitaplar)
            {
                sb.AppendLine($"ISBN: {kitap.ISBN}, Ad: {kitap.Ad}, Yazar: {kitap.Yazar}");
            }
            MessageBox.Show(sb.ToString(), "Kitaplar");
        }
    }
}