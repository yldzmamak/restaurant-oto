using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurant
{
    class adisyon
    {
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\yldzmamak\\Documents\\Database.mdb");
        OleDbCommand komut = new OleDbCommand();

        public void UrunEkle(string urunadi,string fiyat,string urunturu,string masano,string garsonadi)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Insert into adisyon (urunadi,fiyat,urunturu,masano,garsonadi) values (@urunadi,@fiyat,@urunturu,@masano,@garsonadi)";
            komut.Parameters.AddWithValue("@urunadi", urunadi);
            komut.Parameters.AddWithValue("@fiyat", fiyat);
            komut.Parameters.AddWithValue("@urunturu", urunturu);
            komut.Parameters.AddWithValue("@masano", masano);
            komut.Parameters.AddWithValue("@garsonadi", garsonadi);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public void UrunGoster(string masano, ListView lv)
        {
            OleDbCommand komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "Select * From adisyon where masano=@masano";
            komut.Parameters.AddWithValue("@masano", masano);
            komut.ExecuteNonQuery();
            OleDbDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                string[] row = { oku["id"].ToString(), oku["urunadi"].ToString(), oku["fiyat"].ToString()};
                var satir = new ListViewItem(row);
                lv.Items.Add(satir);
            }
            baglanti.Close();
        }
        
        public int masaDurumuDegistir(string masanumarasi,string durum)
        {
            OleDbCommand komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update masakontrol set masadurumu=@masadurumu where masanumarasi=@masanumarasi";
            komut.Parameters.AddWithValue("@masadurumu", durum);
            komut.Parameters.AddWithValue("@masanumarasi", masanumarasi);
            int deger = komut.ExecuteNonQuery();
            baglanti.Close();
            if (deger == 0)
                return 0;
            else
                return 1;
        }
        public void UrunSil(int id)
        {
            OleDbCommand komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "delete from adisyon where id=@id";
            komut.Parameters.AddWithValue("@id", id);
            int kontrol = komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public void masaDurumuDoldur(string[] masaDizisi, string[] durumDizisi)
        {
            int a = 0;
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "select * from masakontrol";
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                masaDizisi[a] = oku["masanumarasi"].ToString();
                durumDizisi[a] = oku["masadurumu"].ToString();
                a++;
            }
            baglanti.Close();
        }
        public int rezervemasamı(string masanumarasi)
        {
            OleDbCommand komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "select masadurumu from masakontrol where masanumarasi=@masanumarasi";
            komut.Parameters.AddWithValue("@masanumarasi", masanumarasi);
            int a = Convert.ToInt32(komut.ExecuteScalar());
            baglanti.Close();
            return a;
        }
    }
}
