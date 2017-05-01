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
    public partial class GarsonEkrani : Form
    {
        public GarsonEkrani()
        {
            InitializeComponent();
        }
        
        private void btn_Click(object sender, EventArgs e)
        {
            adisyon adisyon = new adisyon();
            lblMasaNo.Visible = true;
            lblMasaNo.Text = ((Button)sender).Text;
            int gelenDeger = adisyon.rezervemasamı(lblMasaNo.Text);
            if (gelenDeger == 1)
            {
                cbRezerve.Enabled = true;
                cbRezerve.Checked = true;
            }
            else if (gelenDeger == 2)
            {
                cbRezerve.Enabled = false;
            }
            else
            {
                cbRezerve.Checked = false;
                cbRezerve.Enabled = true;
            }
        }

        private void GarsonEkrani_Load(object sender, EventArgs e)
        {
            durumGuncelle();
            GirisEkrani frm = new GirisEkrani();
            lvIcecek.GridLines = true;
            lvYiyecek.GridLines = true;
            lvTatlilar.GridLines = true;
            lvUrunler.GridLines = true;
            Menu menu = new Menu();
            menu.UrunGetir(lvIcecek);
            lbUrunTuru.Text = "icecek";
            
        }
        private void durumGuncelle()
        {
            adisyon adisyon = new adisyon();
            string[] masaDizisi = new string[24];
            string[] durumDizisi = new string[24];
            adisyon.masaDurumuDoldur(masaDizisi, durumDizisi);
            for (int i = 0; i < masaDizisi.Length; i++)
            {
                Button btn = (Button)this.Controls.Find("btn" + masaDizisi[i], true)[0];
                if (durumDizisi[i] == "0")
                    btn.BackColor = Color.Green;
                else if (durumDizisi[i] == "1")
                    btn.BackColor = Color.Yellow;
                else
                    btn.BackColor = Color.Red;
            }
        }

        private void btnicecekler_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.UrunGetir(lvIcecek);
            lvTatlilar.Visible = false;
            lvYiyecek.Visible = false;
            lvIcecek.Visible = true;
            lbUrunTuru.Text = "icecek";

        }

        private void btnYiyecekler_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.UrunGetir(lvYiyecek);
            lvIcecek.Visible = false;
            lvTatlilar.Visible = false;
            lvYiyecek.Visible = true;
            lbUrunTuru.Text = "yiyecek";

        }

        private void btnTatlilar_Click(object sender, EventArgs e)
        {
            Menu menu = new Menu();
            menu.UrunGetir(lvTatlilar);
            lvYiyecek.Visible = false;
            lvIcecek.Visible = false;
            lvTatlilar.Visible = true;
            lbUrunTuru.Text = "tatli";
        }

        private void btnGarsonClose_Click_1(object sender, EventArgs e)
        {
            GirisEkrani girisekrani = new GirisEkrani();
            girisekrani.Show();
            this.Hide();
        }
        
        private void btnEkle_Click(object sender, EventArgs e)
        {
            adisyon adisyon = new adisyon();
            ListView liste;
            if (lbUrunTuru.Text == "icecek") { liste = lvIcecek; }
            else if (lbUrunTuru.Text == "yiyecek") { liste = lvYiyecek; }
            else { liste = lvTatlilar; }
            
                ListViewItem item = liste.SelectedItems[0];
                adisyon.UrunEkle(item.SubItems[1].Text, item.SubItems[2].Text,lbUrunTuru.Text,lblMasaNo.Text,lbAdSoyad.Text);
                lvUrunler.Items.Clear();
                adisyon.UrunGoster(lblMasaNo.Text, lvUrunler);

                int gelendeger=adisyon.masaDurumuDegistir(lblMasaNo.Text,"2");
               
                durumGuncelle();

        }

        private void text_changed(object sender, EventArgs e)
        {
            string masano = lblMasaNo.Text;
            lvUrunler.Items.Clear();
            adisyon adisyon = new adisyon();
            adisyon.UrunGoster(masano, lvUrunler);
            int gelenDeger = adisyon.rezervemasamı(lblMasaNo.Text);
            if (gelenDeger == 1)
            {
                cbRezerve.Checked = true;
            }
            else if (gelenDeger == 2)
            {
                cbRezerve.Enabled = false;
            }
            else cbRezerve.Checked = false;
        }

       /* private void btnUrunSil_Click(object sender, EventArgs e)
        {
            adisyon adisyon = new adisyon();
            if (lblMasaNo.Text != "")
            {
                string masano = lblMasaNo.Text;
                ListViewItem item = lvUrunler.SelectedItems[0];
               lbId.Text= item.SubItems[0].Text;
                adisyon.UrunSil(Convert.ToInt32(lbId.Text));
                lvUrunler.Items.Clear();
                adisyon.UrunGoster(masano, lvUrunler);
                if (lvUrunler.Items.Count == 0)
                {
                    adisyon.masaDurumuDegistir(masano, "0");
                    durumGuncelle();
                }
            }
        }*/

            //oda doluysa rezerve enable = false olsun. !!!!!!

        private void cbRezerve_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRezerve.Checked == true)
            {
                adisyon adisyon = new adisyon();
                string masano = lblMasaNo.Text;
                adisyon.masaDurumuDegistir(masano, "1");
                durumGuncelle();
            }
            else
            {
                adisyon adisyon = new adisyon();
                string masano = lblMasaNo.Text;
                adisyon.masaDurumuDegistir(masano, "0");
                durumGuncelle();
            }
        }
    }
}
