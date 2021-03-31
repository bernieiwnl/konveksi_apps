using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonveksiClass
{
    public class DaftarSatuan
    {
        private List<satuan> satuans;
        private string kodeTerbaru;
        public List<satuan> Satuans { get => satuans;}

        public int JumlahSatuan
        {
            get { return satuans.Count; }
        }

        public string KodeTerbaru
        {
            get { return kodeTerbaru; }
        }

        public DaftarSatuan()
        {
            satuans = new List<satuan>();
            kodeTerbaru = "S1";
        }


        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT * FROM satuan";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string id = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    satuan s = new satuan(id, nama);
                    satuans.Add(s);
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

            string sql = "SELECT * FROM satuan WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string id = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    satuan s = new satuan(id, nama);
                    satuans.Add(s);
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

            string sql = "SELECT SUBSTRING(id,2) FROM satuan ORDER BY id DESC LIMIT 1";

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
                        kodeTerbaru = "S" + kodeTerbaru;
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

        public string TambahData(satuan s)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "INSERT INTO satuan(id, namaSatuan) VALUES ('" + s.Id + "','" + s.NamaSatuan + "')";

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

        public string UbahData(satuan s)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "UPDATE satuan SET namaSatuan = ' " + s.NamaSatuan + " 'WHERE id = '" + s.Id + "'";

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

        public string HapusData(satuan s)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "DELETE FROM satuan WHERE id = '" + s.Id + "'";

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
