using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace KonveksiClass
{
    public class DaftarJabatan
    {
        private List<jabatan> listJabatan;

        private string kodeTerbaru;
        public List<jabatan> ListJabatan
        {
            get { return listJabatan; }
        }

        public int JumlahJabatan
        {
            get { return listJabatan.Count; }
        }

        public string KodeTerbaru
        {
            get { return kodeTerbaru; }
        }

        public DaftarJabatan()
        {
            listJabatan = new List<jabatan>();
            kodeTerbaru = "J1";
        }


        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT * FROM jabatan";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string id = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    jabatan j = new jabatan(id, nama);
                    listJabatan.Add(j);
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

            string sql = "SELECT * FROM jabatan WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string id = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    jabatan j = new jabatan(id, nama);
                    listJabatan.Add(j);
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

            string sql = "SELECT SUBSTRING(IdJabatan,2) FROM jabatan ORDER BY IdJabatan DESC LIMIT 1";

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
                        kodeTerbaru = "J" + kodeTerbaru;
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

        public string TambahData(jabatan ja)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "INSERT INTO jabatan(IdJabatan, Nama) VALUES ('" + ja.IdJabatan + "','" + ja.NamaJabatan + "')";

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

        public string UbahData(jabatan ja)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "UPDATE jabatan SET Nama = ' " + ja.NamaJabatan + " 'WHERE IdJabatan = '" + ja.IdJabatan + "'";

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

        public string HapusData(jabatan ja)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "DELETE FROM jabatan WHERE IdJabatan = '" + ja.IdJabatan + "'";

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
