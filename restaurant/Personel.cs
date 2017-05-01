using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurant
{
    class Personel
    {

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\yldzmamak\\Documents\\Database.mdb");
        OleDbCommand komut = new OleDbCommand();
       

        string cevap;
        public string kisiyiGetir(string kullaniciadi, string parola)
        {

            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select * From kullanicilar";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                string kisiadi;
                kisiadi = oku["kullaniciAdi"].ToString();
                string kisininsifresi;
                kisininsifresi = oku["sifre"].ToString();

                if (kisiadi == kullaniciadi && kisininsifresi == parola)
                {
                    cevap = oku["unvan"].ToString() + "-" + oku["adi"].ToString() + "-" + oku["soyadi"].ToString() + "-";
                    break;
                }
                else
                {
                    cevap = "0";
                }

            }

            baglanti.Close();
            return cevap;

        }
        
        public int kisiyiekle(string kullaniciadi, string sifre, string adi, string soyadi, string unvan)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Insert into kullanicilar (kullaniciAdi,sifre,adi,soyadi,unvan) values (@kullaniciadi,@sifre,@adi,@soyadi,@unvan)";
            komut.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);
            komut.Parameters.AddWithValue("@sifre", sifre);
            komut.Parameters.AddWithValue("@adi", adi);
            komut.Parameters.AddWithValue("@soyadi", soyadi);
            komut.Parameters.AddWithValue("@unvan", unvan);
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
        public int KisiyiGuncelle(int id,string kullaniciadi, string sifre, string adi, string soyadi, string unvan)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update kullanicilar set kullaniciadi=@kullaniciadi, sifre=@sifre, adi=@adi, soyadi=@soyadi, unvan=@unvan where id=@id";
            komut.Parameters.AddWithValue("@kullaniciadi", kullaniciadi);
            komut.Parameters.AddWithValue("@sifre", sifre);
            komut.Parameters.AddWithValue("@adi", adi);
            komut.Parameters.AddWithValue("@soyadi", soyadi);
            komut.Parameters.AddWithValue("@unvan", unvan);
            komut.Parameters.AddWithValue("@id", id);
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
        public int KisiyiSil(int id)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "delete from kullanicilar where id=@id";
            komut.Parameters.AddWithValue("@id", id);
            int kontrol = komut.ExecuteNonQuery();
            baglanti.Close();
            return kontrol;
        }


        public void KisileriGetir(ListView lv)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select * From kullanicilar";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                string[] row = { oku["id"].ToString(),oku["adi"].ToString(),oku["soyadi"].ToString(),oku["kullaniciadi"].ToString(),oku["sifre"].ToString(),oku["unvan"].ToString() };
                var satir = new ListViewItem(row);
                lv.Items.Add(satir);
            }

            baglanti.Close();

        }
        public void KasaFiyatlariGetir(ListView lv)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select * From kasa";
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                string[] row = { oku["id"].ToString(), oku["para"].ToString(), oku["tarih"].ToString()};
                var satir = new ListViewItem(row);
                lv.Items.Add(satir);
            }

            baglanti.Close();
        }


    }
}
//Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\yldzmamak\Documents\Database.mdb
