using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace KonveksiClass
{
    public class DaftarBarang
    {

        private List<barang> listBarang;
        private string kodeTerbaru;


        public List<barang> ListBarang
        {
            get { return listBarang; }
        }
        public int JumlahBarang
        {
            get { return listBarang.Count; }
        }

        public string KodeTerbaru
        {
            get { return kodeTerbaru; }
        }

        public DaftarBarang()
        {          
          listBarang = new List<barang>();
          kodeTerbaru = "B0001";   
        }
        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();

            string sql = "SELECT B.KodeBarang, B.Nama, B.HargaJual, B.Stok, K.KodeKategori, K.Nama AS Kategori, S.id, S.namaSatuan, B.minimal "
                + "FROM barang B INNER JOIN kategori K ON B.KodeKategori = K.KodeKategori INNER JOIN satuan S ON B.satuan = S.id";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string kode = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    int hrgJual = int.Parse(data.GetValue(2).ToString());
                    int stok = int.Parse(data.GetValue(3).ToString());
                    string kdKategori = data.GetValue(4).ToString();
                    string namaKategori = data.GetValue(5).ToString();
                    string id = data.GetValue(6).ToString();
                    string namaSatuan = data.GetValue(7).ToString();
                    int minimal = int.Parse(data.GetValue(8).ToString());

                    kategori kat = new kategori(kdKategori, namaKategori);
                    satuan sat = new satuan(id, namaSatuan);

                    barang brg = new barang(kode, nama, hrgJual, stok, kat, sat, minimal);

                    listBarang.Add(brg);
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

        public string BacaSemuaDataStock()
        {
            Koneksi k = new Koneksi();

            string sql = "SELECT B.KodeBarang, B.Nama, B.HargaJual, B.Stok, K.KodeKategori, K.Nama AS Kategori, S.id, S.namaSatuan, B.minimal "
                + "FROM barang B INNER JOIN kategori K ON B.KodeKategori = K.KodeKategori INNER JOIN satuan S ON B.satuan = S.id WHERE B.Stok = 0";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string kode = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    int hrgJual = int.Parse(data.GetValue(2).ToString());
                    int stok = int.Parse(data.GetValue(3).ToString());
                    string kdKategori = data.GetValue(4).ToString();
                    string namaKategori = data.GetValue(5).ToString();
                    string id = data.GetValue(6).ToString();
                    string namaSatuan = data.GetValue(7).ToString();
                    int minimal = int.Parse(data.GetValue(8).ToString());

                    kategori kat = new kategori(kdKategori, namaKategori);
                    satuan sat = new satuan(id, namaSatuan);


                    barang brg = new barang(kode, nama, hrgJual, stok, kat, sat, minimal);

                    listBarang.Add(brg);
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

            string sql = "SELECT B.KodeBarang, B.Nama, B.HargaJual, B.Stok, K.KodeKategori, K.Nama AS Kategori, S.id, S.namaSatuan, B.minimal FROM barang B " +
            "INNER JOIN kategori K ON B.KodeKategori = K.KodeKategori INNER JOIN satuan S ON B.satuan = S.id " + "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string kode = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    int hrgJual = int.Parse(data.GetValue(2).ToString());
                    int stok = int.Parse(data.GetValue(3).ToString());
                    string kdKategori = data.GetValue(4).ToString();
                    string namaKategori = data.GetValue(5).ToString();
                    string id = data.GetValue(6).ToString();
                    string namaSatuan = data.GetValue(7).ToString();
                    int minimal = int.Parse(data.GetValue(8).ToString());

                    kategori kat = new kategori(kdKategori, namaKategori);
                    satuan sat = new satuan(id, namaSatuan);


                    barang brg = new barang(kode, nama, hrgJual, stok, kat, sat, minimal);

                    listBarang.Add(brg);
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

        public string CariDataStock(string kriteria, string nilaiKriteria)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT B.KodeBarang, B.Nama, B.HargaJual, B.Stok, K.KodeKategori, K.Nama AS Kategori, S.id, S.namaSatuan, B.minimal FROM barang B " +
            "INNER JOIN kategori K ON B.KodeKategori = K.KodeKategori INNER JOIN satuan S ON B.satuan = S.id " + "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'" + " AND B.JumlahBahanBaku = 0 ";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string kode = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    int hrgJual = int.Parse(data.GetValue(2).ToString());
                    int stok = int.Parse(data.GetValue(3).ToString());
                    string kdKategori = data.GetValue(5).ToString();
                    string namaKategori = data.GetValue(6).ToString();
                    string id = data.GetValue(6).ToString();
                    string namaSatuan = data.GetValue(7).ToString();
                    int minimal = int.Parse(data.GetValue(8).ToString());

                    kategori kat = new kategori(kdKategori, namaKategori);
                    satuan sat = new satuan(id, namaSatuan);


                    barang brg = new barang(kode, nama, hrgJual, stok, kat, sat, minimal);

                    listBarang.Add(brg);
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

            string sql = "SELECT SUBSTRING(KodeBarang,2,4) FROM barang ORDER BY KodeBarang DESC LIMIT 1";

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
                        kodeTerbaru = "B000" + kodeTerbaru;
                    }
                    else if (kodeTerbaru.Length == 2)
                    {
                        kodeTerbaru = "B00" + kodeTerbaru;
                    }
                    else if (kodeTerbaru.Length == 3)
                    {
                        kodeTerbaru = "B0" + kodeTerbaru;
                    }
                    else
                    {
                        kodeTerbaru = "B" + kodeTerbaru;
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

        public string TambahData(barang brg)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "INSERT INTO barang(KodeBarang, Nama, HargaJual, Stok, KodeKategori, satuan, minimal) VALUES ('" +
                brg.KodeBarang + "','" + brg.NamaBarang + "','" + brg.HargaJual + "','" + brg.Stok + "','" + brg.KodeKategoriBarang + "','" + brg.Satuan.Id + "','" + brg.Minimal + "')";

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

        public string UbahData(barang brg)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "UPDATE barang SET Nama = '" + brg.NamaBarang
                + "', HargaJual = '" + brg.HargaJual + "', Stok = '" + brg.Stok
                + "', KodeKategori = '" + brg.KategoriBarang.KodeKategori
                + "', satuan = '" + brg.Satuan.Id
                + "', minimal = '" + brg.Minimal +
               "' WHERE KodeBarang = '" + brg.KodeBarang + "'";

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

        public string HapusData(barang brg)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "DELETE FROM barang WHERE KodeBarang = '" + brg.KodeBarang + "'";

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

        public string CetakBarcode(barang brg)
        {
            try
            {
                cetak c = new cetak("HasilBarcode-" + brg.KodeBarang + ".jpg", brg.KodeBarang, 50, 100);
                c.CetakKePrinter("barcode");

                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
