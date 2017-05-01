using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace restaurant
{
    class Menu
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\yldzmamak\\Documents\\Database.mdb");
        OleDbCommand komut = new OleDbCommand();

        public void UrunGetir(ListView lv1)
        {
           
            if(lv1.Name == "lvIcecek")
            {
                datagetir(lv1,"icecek");
            }
            else if(lv1.Name == "lvYiyecek")
            {
                datagetir(lv1, "yiyecek");
            }
            else
            {
                datagetir(lv1,"tatli");
            }

        }

        public void datagetir(ListView listview,string TabloAdi)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select * From "+TabloAdi;
            
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                string[] row = { oku["Kimlik"].ToString(), oku[TabloAdi].ToString(), oku["fiyat"].ToString() };
                var satir = new ListViewItem(row);
                listview.Items.Add(satir);
            }
            baglanti.Close();
        }

        public int UrunEkle(string urunadi,string fiyat,string urunkategori)
        {
            string [] s;
            s = urunadi.Split(' '); 
            string ürün="";//gelecek ürün adının kelime sayısı belli  olmadığı için dizinin son elemanına kadar kelimeleri yanyana yazar
            for(int i = 0; i < s.Count(); i++)
            {
                ürün += s[i];
            }

            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "insert into " + urunkategori + "(" +urunkategori+ ",fiyat) values (@"+ürün+ ",@fiyat)";
            komut.Parameters.AddWithValue("@" + ürün, urunadi);
            komut.Parameters.AddWithValue("@fiyat", fiyat);
            int etkilenenSatirSayisi = komut.ExecuteNonQuery();
            baglanti.Close();
            if (etkilenenSatirSayisi == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public int UrunSil(int Kimlik,string urunkategori)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "delete from " + urunkategori + " where Kimlik=@Kimlik";
            komut.Parameters.AddWithValue("@Kimlik", Kimlik);
            int kontrol = komut.ExecuteNonQuery();
            baglanti.Close();
            return kontrol;
        }

        public int UrunGuncelle(int Kimlik,string urunkategori,string urunadi,string fiyat)
        {
            baglanti.Open();
            komut.Connection = baglanti;//update tatli set tatli = @tatli 
            komut.CommandText = "update " + urunkategori + " set " + urunkategori+"=@" +urunkategori+ ", fiyat=@fiyat where Kimlik=@Kimlik";
            komut.Parameters.AddWithValue("@"+urunkategori ,urunadi);
            komut.Parameters.AddWithValue("@fiyat", fiyat);
            komut.Parameters.AddWithValue("@Kimlik", Kimlik);
            int etkilenenSatirSayisi = komut.ExecuteNonQuery();
            baglanti.Close();
            if (etkilenenSatirSayisi == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
            
        }

    }
}
