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

            Uye uye = KutuphaneIslemleri.UyeOku().FirstOrDefault(u => u.Ad == uyeAd);
            Kitap kitap = KutuphaneIslemleri.KitapOku().FirstOrDefault(k => k.ISBN == kitapISBN);

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

            // SQLite veritabanına ekleme
            using (SQLiteConnection conn = new SQLiteConnection("Data Source=kütüphane.db;Version=3;"))
            {
                conn.Open();
                string insertQuery = "INSERT INTO emanet (UyeAd, KitapISBN, EmanetTarihi, TeslimTarihi) VALUES (@UyeAd, @KitapISBN, @EmanetTarihi, @TeslimTarihi)";
                using (SQLiteCommand cmd = new SQLiteCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UyeAd", yeniEmanet.Uye.Ad);
                    cmd.Parameters.AddWithValue("@KitapISBN", yeniEmanet.Kitap.ISBN);
                    cmd.Parameters.AddWithValue("@EmanetTarihi", yeniEmanet.EmanetTarihi);
                    cmd.Parameters.AddWithValue("@TeslimTarihi", yeniEmanet.TeslimTarihi);
                    cmd.ExecuteNonQuery();
                }
            }

            // JSON dosyasına ekleme
            List<Emanet> emanetler = KutuphaneIslemleri.EmanetOku();
            emanetler.Add(yeniEmanet);
            KutuphaneIslemleri.EmanetKaydet(emanetler);

            MessageBox.Show("Emanet işlemi başarıyla gerçekleştirildi.");
            textBox1.Clear();
            textBox2.Clear();
        }

        private void emanet_al_btn_Click(object sender, EventArgs e)
        {
            string uyeAd = textBox1.Text;
            string kitapISBN = textBox2.Text;

            if (string.IsNullOrWhiteSpace(uyeAd) || string.IsNullOrWhiteSpace(kitapISBN))
            {
                MessageBox.Show("Lütfen üye adı ve kitap ISBN alanlarını doldurun.");
                return;
            }

            List<Emanet> emanetler = KutuphaneIslemleri.EmanetOku();

            Emanet alinacakEmanet = emanetler.Find(em => em.Uye.Ad == uyeAd && em.Kitap.ISBN == kitapISBN);

            if (alinacakEmanet == null)
            {
                MessageBox.Show("Belirtilen emanet bulunamadı.");
                return;
            }

            using (SQLiteConnection conn = new SQLiteConnection("Data Source=kütüphane.db;Version=3;"))
            {
                conn.Open();
                string deleteQuery = "DELETE FROM emanet WHERE UyeAd = @UyeAd AND KitapISBN = @KitapISBN";
                using (SQLiteCommand cmd = new SQLiteCommand(deleteQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@UyeAd", uyeAd);
                    cmd.Parameters.AddWithValue("@KitapISBN", kitapISBN);
                    cmd.ExecuteNonQuery();
                }
            }

            emanetler.Remove(alinacakEmanet);

            KutuphaneIslemleri.EmanetKaydet(emanetler);

            MessageBox.Show("Emanet başarıyla geri alındı.");

            textBox1.Clear();
            textBox2.Clear();
        }



        private void emanet_bak_btn_Click(object sender, EventArgs e)
        {
          
                List<Emanet> emanetler;
                using (SQLiteConnection conn = new SQLiteConnection("Data Source=kütüphane.db;Version=3;"))
                {
                    conn.Open();
                    string selectQuery = "SELECT * FROM emanet";
                    using (SQLiteCommand cmd = new SQLiteCommand(selectQuery, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            emanetler = new List<Emanet>();
                            while (reader.Read())
                            {
                                Emanet emanet = new Emanet
                                {
                                    Uye = new Uye
                                    {
                                        Ad = reader["UyeAd"].ToString(),
                                       
                                    },
                                    Kitap = new Kitap
                                    {
                                        ISBN = reader["KitapISBN"].ToString(),
                                     
                                    },
                                    EmanetTarihi = Convert.ToDateTime(reader["EmanetTarihi"]),
                                    TeslimTarihi = Convert.ToDateTime(reader["TeslimTarihi"])
                                };
                                emanetler.Add(emanet);
                            }
                        }
                    }
                }

                StringBuilder sb = new StringBuilder();
                foreach (Emanet emanet in emanetler)
                {
                    sb.AppendLine($"Üye: {emanet.Uye.Ad}, Kitap ISBN: {emanet.Kitap.ISBN}, Emanet Tarihi: {emanet.EmanetTarihi}, Teslim Tarihi: {emanet.TeslimTarihi}");
                }
                MessageBox.Show(sb.ToString(), "Emanetler");
            }

        }
    }

