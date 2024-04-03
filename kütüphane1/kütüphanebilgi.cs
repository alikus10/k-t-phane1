using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace kütüphane1
{
    // Üye sınıfı
    public class Uye
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }


    }

    // Kitap sınıfı
    public class Kitap
    {
        public string ISBN { get; set; }
        public string Ad { get; set; }
        public string Yazar { get; set; }

    }

    // Emanet sınıfı
    public partial class Emanet
    {
        public Uye Uye { get; set; } // Emanetin bağlı olduğu üye
        public Kitap Kitap { get; set; } // Emanet edilen kitap
        public DateTime EmanetTarihi { get; set; } // Emanet tarihi
        public DateTime TeslimTarihi { get; set; } // Teslim tarihi
    }
}