using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace restaurant
{
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }
  
        public void button1_Click(object sender, EventArgs e)
        {
            Personel nesne = new Personel();
            string a = tbKullaniciAdi.Text;
            string b = tbSifre.Text;

            string donenDeger = nesne.kisiyiGetir(a, b);
           
            if(donenDeger == "0")
            {
                lbHata.Text = "Kullanıcı adı veya şifre hatalıdır!";
                tbKullaniciAdi.Clear();
                tbSifre.Clear();
            }
            else
            {
                string[] dizi = donenDeger.Split('-');
                string AdSoyad = dizi[0] + ": " + " " +dizi[1]+ " " + dizi[2];
                    if (dizi[0] == "Patron")
                {
                    PatronEkrani patronEkrani = new PatronEkrani();
                    patronEkrani.lbPatronAdi.Text = "Sayın: " + dizi[1] + " " + dizi[2];
                    patronEkrani.Show();
                    this.Hide();
                }
                else if (dizi[0] == "Garson")
                {
                    GarsonEkrani garsonEkrani = new GarsonEkrani();
                    garsonEkrani.lbAdSoyad.Text = AdSoyad;
                    garsonEkrani.Show();
                    this.Hide();
                }
                else if (dizi[0] == "Kasiyer")
                {
                    KasiyerEkrani KasiyerEkrani = new KasiyerEkrani();
                    KasiyerEkrani.lbKasiyerAd.Text = AdSoyad;
                    KasiyerEkrani.Show();
                    this.Hide();
                }

            }
             
        }

        private void btnGirisEkrani_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
