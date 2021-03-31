using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace KonveksiClass
{
    public class DaftarPelanggan
    {
        private List<pelanggan> listPelanggan;
        private string kodeTerbaru;

        public List<pelanggan> ListPelanggan
        {
            get { return listPelanggan; }
        }

        public int JumlahPelanggan
        {
            get { return listPelanggan.Count; }
        }

        public string KodeTerbaru
        {
            get { return kodeTerbaru; }
        }
        public DaftarPelanggan()
        {
            listPelanggan = new List<pelanggan>();
            kodeTerbaru = "01";
        }

        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT * FROM pelanggan";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string kode = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    string alamat = data.GetValue(2).ToString();
                    string telepon = data.GetValue(3).ToString();

                    pelanggan plgn = new pelanggan(kode, nama, alamat, telepon);
                    listPelanggan.Add(plgn);
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

            string sql = "SELECT * FROM pelanggan WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string kode = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    string alamat = data.GetValue(2).ToString();
                    string telepon = data.GetValue(3).ToString();

                    pelanggan plgn = new pelanggan(kode, nama, alamat, telepon);
                    listPelanggan.Add(plgn);
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

            string sql = "SELECT kodePelanggan FROM pelanggan ORDER BY KodePelanggan DESC LIMIT 1";

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

        public string TambahData(pelanggan pl)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "INSERT INTO pelanggan(KodePelanggan, Nama, Alamat, Telepon) VALUES ('" + pl.KodePelanggan + "','" + pl.NamaPelanggan + "','" + pl.Alamat + "','" + pl.Telepon + "')";

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

        public string UbahData(pelanggan pl)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "UPDATE pelanggan SET Nama = '" + pl.NamaPelanggan + "', Alamat = '" + pl.Alamat + "', Telepon = '" + pl.Telepon + "' WHERE KodePelanggan = '" + pl.KodePelanggan + "'";

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

        public string HapusData(pelanggan pl)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "DELETE FROM pelanggan WHERE KodePelanggan = '" + pl.KodePelanggan + "'";

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
