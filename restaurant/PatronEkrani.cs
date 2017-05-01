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
    public partial class PatronEkrani : Form
    {
        public PatronEkrani()
        {
            InitializeComponent();
        }

        private void btnPersEkle_Click(object sender, EventArgs e)
        {
            if (txtPersKulAdi.Text != "" && txtPersonelAdi.Text != "" && txtPersonelSoyadi.Text != "" && !txtPersSifre.Equals("") && cbUnvan.Text != "")
            {
                Personel personel = new Personel();
                int kontrol = personel.kisiyiekle(txtPersKulAdi.Text, txtPersSifre.Text, txtPersonelAdi.Text, txtPersonelSoyadi.Text, cbUnvan.Text);
                if (kontrol == 1)
                {
                    PersonelTemizle();
                    lvListe.Items.Clear();
                    personel.KisileriGetir(lvListe);
                    MessageBox.Show("Kaydınız Eklenmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    PersonelTemizle();
                    MessageBox.Show("Kaydınız Eklenmemiştir.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                lbUyari.Text = "Gerekli yerleri doldurunuz.";
            }
        }

        private void PersonelTemizle()
        {
            lbUyari.Text = "";
            txtPersKulAdi.Clear();
            txtPersonelAdi.Clear();
            txtPersonelSoyadi.Clear();
            txtPersSifre.Clear();
            cbUnvan.SelectedItem = null;
        }
       private void UrunTemizle()
        {
            txtFiyat.Clear();
            txtUrunAdi.Clear();
            lvListe.SelectedItems.Clear();
            lvTatlilar.SelectedItems.Clear();
            lvYiyecek.SelectedItems.Clear();
            lvIcecek.SelectedItems.Clear();
            cbUrunKategori.SelectedItem = null;
            }
        private void PatronEkrani_Load(object sender, EventArgs e)
        {
            Personel personel = new Personel();
            personel.KisileriGetir(lvListe);
            Menu menu = new Menu();
            menu.UrunGetir(lvIcecek);
            menu.UrunGetir(lvYiyecek);
            menu.UrunGetir(lvTatlilar);
            kasadakiParaGoster();
            personel.KasaFiyatlariGetir(lvKasaFiyatlari);
        }
        public void kasadakiParaGoster()
        {
            
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\yldzmamak\\Documents\\Database.mdb");
            OleDbCommand komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "select top 1 para from kasa ORDER BY id desc";
            double a = Convert.ToDouble(komut.ExecuteScalar());
            lbPara.Text = a.ToString();
            baglanti.Close();
        }
        public void kasadakiParayiBosalt()
        {
            string tarih = DateTime.Now.ToShortDateString();
            OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\yldzmamak\\Documents\\Database.mdb");
            OleDbCommand komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "UPDATE (SELECT TOP 1 tarih FROM kasa ORDER BY id DESC) AS tarih SET tarih.tarih = @tarih";
            komut.Parameters.AddWithValue("@tarih", tarih);
            komut.ExecuteNonQuery();
            OleDbCommand komut2 = new OleDbCommand();
            komut2.Connection = baglanti;
            komut2.CommandText = "Insert into kasa (para,tarih) values (@para,@tarih)";
            komut2.Parameters.AddWithValue("@para", 0);
            komut2.Parameters.AddWithValue("@tarih", tarih);
            komut2.ExecuteNonQuery();
            baglanti.Close();
        }

        private void lvListe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvListe.SelectedItems.Count > 0)
            {
                ListViewItem item = lvListe.SelectedItems[0];
                lbID.Text = item.SubItems[0].Text;
                txtPersonelAdi.Text = item.SubItems[1].Text;
                txtPersonelSoyadi.Text = item.SubItems[2].Text;
                txtPersKulAdi.Text = item.SubItems[3].Text;
                txtPersSifre.Text = item.SubItems[4].Text;
                cbUnvan.Text = item.SubItems[5].Text;
               
            }
            else
            {
                UrunTemizle();
                PersonelTemizle();
            }
        }
        
        private void btnPersSil_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel();
            int silinecekID = Convert.ToInt32(lbID.Text);
            if (personel.KisiyiSil(silinecekID) !=0)
            {
                PersonelTemizle();
                lvListe.Items.Clear();
                personel.KisileriGetir(lvListe);
                MessageBox.Show("Kayıt silinmiştir.","Bilgilendirme",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
             
        }

        private void btnPersGuncelle_Click(object sender, EventArgs e)
        {
            Personel personel = new Personel();
            int guncellenecekId = Convert.ToInt32(lbID.Text);
            int kontrol = personel.KisiyiGuncelle(guncellenecekId, txtPersKulAdi.Text, txtPersSifre.Text, txtPersonelAdi.Text, txtPersonelSoyadi.Text, cbUnvan.Text);
            if (kontrol == 1)
            {
                PersonelTemizle();
                lvListe.Items.Clear();
                personel.KisileriGetir(lvListe);
                MessageBox.Show("Kaydınız güncellenmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                PersonelTemizle();
                MessageBox.Show("Kaydınız güncellenirken hata oluşmuştur.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }


        private void btnPatronClose_Click(object sender, EventArgs e)
        {
            GirisEkrani girisekrani = new GirisEkrani();
            girisekrani.Show();
            this.Hide();
        }

        private void lvYiyecek_SelectedIndexChanged(object sender, EventArgs e)
        {
            urunsec(lvYiyecek);
            cbUrunKategori.Text = "Yiyecek";
        }

        private void lvTatlilar_SelectedIndexChanged(object sender, EventArgs e)
        {
            urunsec(lvTatlilar);
            cbUrunKategori.Text = "Tatlı";
        }

        private void lvIcecek_SelectedIndexChanged(object sender, EventArgs e)
        {
            urunsec(lvIcecek);
            cbUrunKategori.Text = "İçecek";
        }

        public void urunsec(ListView liste)
        {
            if (liste.SelectedItems.Count > 0)
            {
                ListViewItem item = liste.SelectedItems[0];
                lbUrunId.Text = item.SubItems[0].Text;
                txtUrunAdi.Text = item.SubItems[1].Text;
                txtFiyat.Text = item.SubItems[2].Text;
                PersonelTemizle();
            }
            else
            {
                UrunTemizle();
            }
        }

        private void PatronEkrani_MouseClick(object sender, MouseEventArgs e)
        {
            PersonelTemizle();
            UrunTemizle();
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            string tabloadi;
            ListView list;
            if(cbUrunKategori.Text == "İçecek" )
            {
                list = lvIcecek;
                tabloadi = "icecek";
            }
            else if(cbUrunKategori.Text == "Yiyecek")
            {
                list = lvYiyecek;
                tabloadi = "yiyecek";
            }
            else
            {
                list = lvTatlilar;
                tabloadi = "tatli";
            }

            Menu menu = new Menu();

            int deger = menu.UrunEkle(txtUrunAdi.Text, txtFiyat.Text, tabloadi);
            if (txtUrunAdi.Text != " " && txtFiyat.Text != " " && cbUrunKategori.Text != " ")
            {
                if (deger == 1)
                {

                    UrunTemizle();
                    list.Items.Clear();
                    menu.UrunGetir(list);
                    MessageBox.Show("Kaydınız Eklenmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UrunTemizle();
                    MessageBox.Show("Kaydınız Eklenmemiştir.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                }
           
            else
            {
                lbUyariUrun.Text = "Gerekli yerleri doldurunuz.";
            }
        
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            string tabloadi;
            ListView list;
            if (cbUrunKategori.Text == "İçecek")
            {
                list = lvIcecek;
                tabloadi = "icecek";
            }
            else if (cbUrunKategori.Text == "Yiyecek")
            {
                list = lvYiyecek;
                tabloadi = "yiyecek";
            }
            else
            {
                list = lvTatlilar;
                tabloadi = "tatli";
            }

            Menu menu = new Menu();
            int silinecekDeger = Convert.ToInt32(lbUrunId.Text);
            int kontrol = menu.UrunSil(silinecekDeger, tabloadi);
            if (kontrol != 0)
            {
                UrunTemizle();
                list.Items.Clear();
                menu.UrunGetir(list);
                MessageBox.Show("Kayıt silinmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            string tabloadi;
            ListView list;
            if (cbUrunKategori.Text == "İçecek")
            {
                list = lvIcecek;
                tabloadi = "icecek";
            }
            else if (cbUrunKategori.Text == "Yiyecek")
            {
                list = lvYiyecek;
                tabloadi = "yiyecek";
            }
            else
            {
                list = lvTatlilar;
                tabloadi = "tatli";
            }

            Menu menu = new Menu();
            int guncellenecekDeger = Convert.ToInt32(lbUrunId.Text);
            int kontrol = menu.UrunGuncelle(guncellenecekDeger, tabloadi, txtUrunAdi.Text ,txtFiyat.Text);
            if (kontrol != 0)
            {
                UrunTemizle();
                list.Items.Clear();
                menu.UrunGetir(list);
                MessageBox.Show("Kayıt güncellenmiştir.", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnKasaBosalt_Click(object sender, EventArgs e)
        {
            if (lbPara.Text != "0")
            {
                kasadakiParayiBosalt();
            }
            kasadakiParaGoster();
        }
    }
}
