using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace KonveksiClass
{
    public class DaftarKategori
    {
        private List<kategori> listKategori;
        private string kodeTerbaru;

        public List<kategori> DaftarKategoriBarang
        {
            get { return listKategori; }
        }

        public int JumlahKategoriBarang
        {
            get { return listKategori.Count; }
        }

        public string KodeTerbaru
        {
            get { return kodeTerbaru; }
        }

        public DaftarKategori()
        {
            listKategori = new List<kategori>();
            kodeTerbaru = "01";
        }

        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT * FROM kategori";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string kode = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    kategori kt = new kategori(kode, nama);
                    listKategori.Add(kt);
                }

                c.Dispose();
                data.Dispose();

                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string CariData(string kriteria, string nilaiKriteria)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT * FROM kategori WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string kode = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    kategori kt = new kategori(kode, nama);
                    listKategori.Add(kt);
                }

                c.Dispose();
                data.Dispose();

                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string GenerateKode()
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT kodeKategori FROM kategori ORDER BY KodeKategori DESC LIMIT 1";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                MySqlDataReader data = c.ExecuteReader();
                if (data.Read() == true)
                {
                    int kdTerbaru = int.Parse(data.GetValue(0).ToString()) + 1;
                    kodeTerbaru = kdTerbaru.ToString();

                    if (kodeTerbaru.Length == 1)
                    {
                        kodeTerbaru = "0" + kodeTerbaru;
                    }
                }
                c.Dispose();
                data.Dispose();

                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string TambahData(kategori kat)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "INSERT INTO kategori(KodeKategori, Nama) VALUES ('" + kat.KodeKategori + "','" + kat.NamaKategori + "')";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                c.ExecuteNonQuery();
                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string UbahData(kategori kat)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "UPDATE kategori SET Nama = ' " + kat.NamaKategori + " 'WHERE KodeKategori = '" + kat.KodeKategori + "'";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                c.ExecuteNonQuery();
                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string HapusData(kategori kat)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "DELETE FROM kategori WHERE KodeKategori = '" + kat.KodeKategori + "'";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                c.ExecuteNonQuery();
                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}
