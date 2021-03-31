using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace KonveksiClass
{
    public class DaftarSupplier
    {
        private List<supplier> listSupplier;
        private string kodeTerbaru;

        public List<supplier> ListSupplier
        {
            get { return listSupplier; }
        }

        public int JumlahSupplier
        {
            get { return listSupplier.Count; }
        }

        public string KodeTerbaru
        {
            get { return kodeTerbaru; }
        }

        public DaftarSupplier()
        {
            listSupplier = new List<supplier>();
            kodeTerbaru = "1";
        }
        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT * FROM supplier";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string kode = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    string alamat = data.GetValue(2).ToString();
                    string jenis = data.GetValue(3).ToString();

                    supplier sup = new supplier(kode, nama, alamat, jenis);
                    listSupplier.Add(sup);
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

            string sql = "SELECT * FROM supplier WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string kode = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    string alamat = data.GetValue(2).ToString();
                    string jenis = data.GetValue(3).ToString();

                    supplier sup = new supplier(kode, nama, alamat, jenis);
                    listSupplier.Add(sup);
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

            string sql = "SELECT KodeSupplier FROM supplier ORDER BY KodeSupplier DESC LIMIT 1";

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

        public string TambahData(supplier sp)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "INSERT INTO supplier(KodeSupplier, Nama, Alamat, jenisSuplier) VALUES ('" + sp.KodeSupplier + "','" + sp.NamaSupplier + "','" + sp.AlamatSupplier + "','" + sp.JenisSuplier + "')";

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

        public string UbahData(supplier sp)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "UPDATE supplier SET Nama = '" + sp.NamaSupplier + "', Alamat = '" + sp.AlamatSupplier + "', jenisSuplier = '" + sp.JenisSuplier + "' WHERE KodeSupplier = '" + sp.KodeSupplier + "'";

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

        public string HapusData(supplier sp)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "DELETE FROM supplier WHERE KodeSupplier = '" + sp.KodeSupplier + "'";

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
