using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonveksiClass
{
    public class DaftarJenisBahan
    {
        private List<jenisBahan> listJenisBahan;

        private string kodeTerbaru;

        public List<jenisBahan> ListJenisBahan { get => listJenisBahan; set => listJenisBahan = value; }
        public string KodeTerbaru { get => kodeTerbaru; }

        public int JumlahJenisBahan
        {
            get { return listJenisBahan.Count; }
        }


        public DaftarJenisBahan()
        {
            listJenisBahan = new List<jenisBahan>();
            kodeTerbaru = "JB1";
        }

        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT * FROM jenis_bahan";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string id = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    jenisBahan JB = new jenisBahan(id, nama);
                    listJenisBahan.Add(JB);
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

            string sql = "SELECT * FROM jenis_bahan WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string id = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    jenisBahan JB = new jenisBahan(id, nama);
                    listJenisBahan.Add(JB);
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

            string sql = "SELECT SUBSTRING(id,3) FROM jenis_bahan ORDER BY id DESC LIMIT 1";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                MySqlDataReader data = c.ExecuteReader();
                if (data.Read() == true)
                {
                    int kdTerbaru = int.Parse(data.GetValue(0).ToString()) + 1;
                    kodeTerbaru = "JB" + kdTerbaru.ToString();
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

        public string TambahData(jenisBahan JB)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "INSERT INTO jenis_bahan(id, nama_bahan) VALUES ('" + JB.Id + "','" + JB.Nama_bahan + "')";

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

        public string UbahData(jenisBahan JB)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "UPDATE jenis_bahan SET nama_bahan = '" + JB.Nama_bahan + "'WHERE id = '" + JB.Id + "'";

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

        public string HapusData(jenisBahan JB)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "DELETE FROM jenis_bahan WHERE id = '" + JB.Id + "'";

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
