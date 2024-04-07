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
    public partial class kütüphane_ana_sayfa : Form
    {
        private Üye_ekle Üye_ekle;
        private Kitap_ekle Kitap_ekle;
        private Emanet Emanet;
        public kütüphane_ana_sayfa()
        {
            InitializeComponent();

            Üye_ekle = new Üye_ekle();
            Kitap_ekle = new Kitap_ekle();
            Emanet = new Emanet();
        }

        private void üye_ekle_btn_Click(object sender, EventArgs e)
        {

            Üye_ekle.Show();
           
        }

        private void kitap_ekle_btn_Click(object sender, EventArgs e)
        {
            Kitap_ekle.Show();
        }

        private void emanet_btn_Click(object sender, EventArgs e)
        {
            Emanet.Show();
        }
    }
}
