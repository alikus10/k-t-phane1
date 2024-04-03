using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using Newtonsoft.Json;


namespace kütüphane1
{
    public static class KutuphaneIslemleri
    {
        private const string UyeDosyaAdi = "C:\\Users\\Ali Kuş\\source\\repos\\kütüphane1\\kütüphane1\\Data\\üyeler.json";
        private const string KitapDosyaAdi = "C:\\Users\\Ali Kuş\\source\\repos\\kütüphane1\\kütüphane1\\Data\\kitaplar.json";
        private const string EmanetDosyaAdi = "C:\\Users\\Ali Kuş\\source\\repos\\kütüphane1\\kütüphane1\\Data\\emanet.json";
        private static readonly string UyeDosyaYolu = Path.Combine("Data", UyeDosyaAdi);
        private static readonly string KitapDosyaYolu = Path.Combine("Data", KitapDosyaAdi);
        private static readonly string EmanetDosyaYolu = Path.Combine("Data", EmanetDosyaAdi);

        static KutuphaneIslemleri()
        {
            // data klasörünü oluştur
            if (!Directory.Exists("Data"))
            {
                Directory.CreateDirectory("Data");
            }
        }

        public static void UyeKaydet(List<Uye> uyeler)
        {
            string json = JsonConvert.SerializeObject(uyeler);
            File.WriteAllText(UyeDosyaYolu, json);
        }

        public static List<Uye> UyeOku()
        {
            if (File.Exists(UyeDosyaYolu))
            {
                string json = File.ReadAllText(UyeDosyaYolu);
                return JsonConvert.DeserializeObject<List<Uye>>(json) ?? new List<Uye>();
            }
            else
            {
                return new List<Uye>();
            }
        }


        public static void KitapKaydet(List<Kitap> kitaplar)
        {
            string json = JsonConvert.SerializeObject(kitaplar);
            File.WriteAllText(KitapDosyaYolu, json);
        }

        public static List<Kitap> KitapOku()
        {
            if (File.Exists(KitapDosyaYolu))
            {
                string json = File.ReadAllText(KitapDosyaYolu);
                return JsonConvert.DeserializeObject<List<Kitap>>(json) ?? new List<Kitap>();
            }
            else
            {
                return new List<Kitap>();
            }
        }


        public static void EmanetKaydet(List<Emanet> emanetler)
        {
           
                try
                {
                    // Yalnızca istenilen alanları içeren geçici bir liste oluştur
                    var tempEmanetler = emanetler.Select(e => new
                    {
                        Uye = new
                        {
                            e.Uye.Ad,
                            e.Uye.Soyad,
                            e.Uye.Email,
                            e.Uye.Telefon
                        },
                        Kitap = new
                        {
                            e.Kitap.ISBN,
                            e.Kitap.Ad,
                            e.Kitap.Yazar
                        },
                        e.EmanetTarihi,
                        e.TeslimTarihi
                    }).ToList();

                    // Geçici liste üzerinden JSON dosyasını oluştur
                    string json = JsonConvert.SerializeObject(tempEmanetler);
                    File.WriteAllText(EmanetDosyaYolu, json);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Dosyaya yazma hatası: " + ex.Message);
                }
            }


        


        public static List<Emanet> EmanetOku()
        {
            if (File.Exists(EmanetDosyaYolu))
            {
                string json = File.ReadAllText(EmanetDosyaYolu);
                return JsonConvert.DeserializeObject<List<Emanet>>(json) ?? new List<Emanet>();
            }
            else
            {
                return new List<Emanet>();
            }
        }
    }
}