using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonveksiClass
{
    public class DaftarKegiatan
    {
        private List<kegiatan> listKegiatan;
        private string kodeTerbaru;
        public List<kegiatan> ListKegiatan
        {
            get { return listKegiatan; }
        }

        public int JumlahJabatan
        {
            get { return ListKegiatan.Count; }
        }

        public string KodeTerbaru
        {
            get { return kodeTerbaru; }
        }

        public DaftarKegiatan()
        {
            listKegiatan = new List<kegiatan>();
            kodeTerbaru = "K1";
        }

        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT * FROM kegiatan";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string id = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    kegiatan j = new kegiatan(id, nama);
                    listKegiatan.Add(j);
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

            string sql = "SELECT * FROM kegiatan WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string id = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    kegiatan j = new kegiatan(id, nama);
                    listKegiatan.Add(j);
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

            string sql = "SELECT SUBSTRING(idKegiatan,2) FROM kegiatan ORDER BY idKegiatan DESC LIMIT 1";

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
                        kodeTerbaru = "K" + kodeTerbaru;
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

        public string TambahData(kegiatan ja)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "INSERT INTO kegiatan(idKegiatan, namaKegiatan) VALUES ('" + ja.IdKegiatan + "','" + ja.NamaKegiatan + "')";

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

        public string UbahData(kegiatan ja)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "UPDATE kegiatan SET namaKegiatan = ' " + ja.NamaKegiatan + " 'WHERE idKegiatan = '" + ja.IdKegiatan + "'";

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

        public string HapusData(kegiatan ja)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "DELETE FROM kegiatan WHERE idKegiatan = '" + ja.IdKegiatan + "'";

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
