using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurant
{
    public partial class KasiyerEkrani : Form
    {
        public KasiyerEkrani()
        {
            InitializeComponent();
        }

        private void btnKasiyerClose_Click(object sender, EventArgs e)
        {
            GirisEkrani girisekrani = new GirisEkrani();
            girisekrani.Show();
            this.Hide();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            lbMasaNo.Visible = true;
            lbMasaNo.Text = ((Button)sender).Text;
        }

        private void KasiyerEkrani_Load(object sender, EventArgs e)
        {
            adisyon adisyon = new adisyon();
            lvAdisyon.GridLines = true;
            durumGuncelle();
           
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

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAdisyon.SelectedItems.Count > 0)
            {
                ListViewItem item = lvAdisyon.SelectedItems[0];
                lbId.Text = item.SubItems[0].Text;
            } 
        }

        private void text_changed(object sender, EventArgs e)
        {
            string masano = lbMasaNo.Text;
            lvAdisyon.Items.Clear();
            adisyon adisyon = new adisyon();
            adisyon.UrunGoster(masano, lvAdisyon);
            
           
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            adisyon adisyon = new adisyon();
            if (lbMasaNo.Text != "" && lbId.Text!="")
            {
                string masano = lbMasaNo.Text;
                adisyon.UrunSil(Convert.ToInt32(lbId.Text));
                lvAdisyon.Items.Clear();
                adisyon.UrunGoster(masano, lvAdisyon);
                if (lvAdisyon.Items.Count == 0)
                {
                    adisyon.masaDurumuDegistir(masano, "0");
                    durumGuncelle();
                }
                
            }
            
        }

        private void btnOde_Click(object sender, EventArgs e)
        {
            if (lvAdisyon.SelectedItems.Count > 0)
            {
                ListViewItem item = lvAdisyon.SelectedItems[0];
                string para = item.SubItems[2].Text;
                ParaMiktarGetir(para);
            }

            adisyon adisyon = new adisyon();
            if (lbMasaNo.Text != "" && lbId.Text != "")
            {
                string masano = lbMasaNo.Text;
                adisyon.UrunSil(Convert.ToInt32(lbId.Text));
                lvAdisyon.Items.Clear();
                adisyon.UrunGoster(masano, lvAdisyon);
                if (lvAdisyon.Items.Count == 0)
                {
                    adisyon.masaDurumuDegistir(masano, "0");
                    durumGuncelle();
                }
            }
        }
        public void ParaMiktarGetir(string para)
        {
            string tarih = DateTime.Now.ToShortDateString();
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\yldzmamak\\Documents\\Database.mdb");
            OleDbCommand komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "select top 1 para from kasa ORDER BY id desc";
            double a = Convert.ToDouble(komut.ExecuteScalar());
            a = a + (double.Parse(para));
            OleDbCommand komut2 = new OleDbCommand();
            komut2.Connection = baglanti;
            komut2.CommandText = "UPDATE (SELECT TOP 1 para FROM kasa ORDER BY id DESC) AS a SET a.para = @para";
            komut2.Parameters.AddWithValue("@a", a);
            komut2.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
