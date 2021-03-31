using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonveksiClass
{
    public class DaftarBahan
    {
        private List<bahan> listBahan;
        private string kodeTerbaru;

        public string KodeTerbaru { get => kodeTerbaru; set => kodeTerbaru = value; }
        public List<bahan> ListBahan { get => listBahan; set => listBahan = value; }

        public int JumlahBahan
        {
            get { return listBahan.Count; }
        }

        public DaftarBahan()
        {
            listBahan = new List<bahan>();
            kodeTerbaru = "M0001";
        }

        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();

            string sql = "SELECT bahan.id,bahan.namaBahan,bahan.Stok,bahan.hargaBeli,w.id,w.nama_warna,jb.id,jb.nama_bahan,sa.id,sa.namaSatuan,minimal FROM bahan INNER JOIN warna as w on bahan.warna = w.id INNER JOIN jenis_bahan as jb on bahan.jenis_bahan = jb.id INNER JOIN satuan as sa on bahan.satuan = sa.id";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string kodeBahan = data.GetValue(0).ToString();
                    string namaBahan = data.GetValue(1).ToString();
                    int stokBahan = int.Parse(data.GetValue(2).ToString());
                    int hargaBeliBahan = int.Parse(data.GetValue(3).ToString());

                    int idWarna = int.Parse(data.GetValue(4).ToString());
                    string namaWarna = data.GetValue(5).ToString();

                    string idjenisBahan = data.GetValue(6).ToString();
                    string namaJenisBahan = data.GetValue(7).ToString();

                    string idSatuan = data.GetValue(8).ToString();
                    string namaSatuan = data.GetValue(9).ToString();
                    int minimal = int.Parse(data.GetValue(10).ToString());

                    warna w = new warna(idWarna, namaWarna);
                    jenisBahan jb = new jenisBahan(idjenisBahan, namaJenisBahan);

                    satuan s = new satuan(idSatuan, namaSatuan);

                    bahan bhn = new bahan(kodeBahan,namaBahan,stokBahan,hargaBeliBahan,w,jb,s,minimal);

                    listBahan.Add(bhn);
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

            string sql = "SELECT bahan.id,bahan.namaBahan,bahan.Stok,bahan.hargaBeli,w.id,w.nama_warna,jb.id,jb.nama_bahan,sa.id,sa.namaSatuan,minimal FROM bahan INNER JOIN warna as w on bahan.warna = w.id INNER JOIN jenis_bahan as jb on bahan.jenis_bahan = jb.id INNER JOIN satuan as sa on bahan.satuan = sa.id WHERE bahan.Stok = 0";


            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string kodeBahan = data.GetValue(0).ToString();
                    string namaBahan = data.GetValue(1).ToString();
                    int stokBahan = int.Parse(data.GetValue(2).ToString());
                    int hargaBeliBahan = int.Parse(data.GetValue(3).ToString());

                    int idWarna = int.Parse(data.GetValue(4).ToString());
                    string namaWarna = data.GetValue(5).ToString();

                    string idjenisBahan = data.GetValue(6).ToString();
                    string namaJenisBahan = data.GetValue(7).ToString();

                    string idSatuan = data.GetValue(8).ToString();
                    string namaSatuan = data.GetValue(9).ToString();
                    int minimal = int.Parse(data.GetValue(10).ToString());

                    warna w = new warna(idWarna, namaWarna);
                    jenisBahan jb = new jenisBahan(idjenisBahan, namaJenisBahan);
                    satuan s = new satuan(idSatuan, namaSatuan);
                    

                    bahan bhn = new bahan(kodeBahan, namaBahan, stokBahan, hargaBeliBahan, w, jb,s, minimal);

                    listBahan.Add(bhn);
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

            string sql = "SELECT bahan.id,bahan.namaBahan,bahan.Stok,bahan.hargaBeli,w.id,w.nama_warna,jb.id,jb.nama_bahan,sa.id,sa.namaSatuan,minimal FROM bahan INNER JOIN warna as w on bahan.warna = w.id INNER JOIN jenis_bahan as jb on bahan.jenis_bahan = jb.id INNER JOIN satuan as sa on bahan.satuan = sa.id " +
                         "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string kodeBahan = data.GetValue(0).ToString();
                    string namaBahan = data.GetValue(1).ToString();
                    int stokBahan = int.Parse(data.GetValue(2).ToString());
                    int hargaBeliBahan = int.Parse(data.GetValue(3).ToString());

                    int idWarna = int.Parse(data.GetValue(4).ToString());
                    string namaWarna = data.GetValue(5).ToString();

                    string idjenisBahan = data.GetValue(6).ToString();
                    string namaJenisBahan = data.GetValue(7).ToString();

                    string idSatuan = data.GetValue(8).ToString();
                    string namaSatuan = data.GetValue(9).ToString();
                    int minimal = int.Parse(data.GetValue(10).ToString());

                    warna w = new warna(idWarna, namaWarna);
                    jenisBahan jb = new jenisBahan(idjenisBahan, namaJenisBahan);

                    satuan s = new satuan(idSatuan, namaSatuan);

                    bahan bhn = new bahan(kodeBahan, namaBahan, stokBahan, hargaBeliBahan, w, jb,s, minimal);

                    listBahan.Add(bhn);
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

            string sql = "SELECT bahan.id,bahan.namaBahan,bahan.Stok,bahan.hargaBeli,w.id,w.nama_warna,jb.id,jb.nama_bahan,sa.id,sa.namaSatuan,minimal FROM bahan INNER JOIN warna as w on bahan.warna = w.id INNER JOIN jenis_bahan as jb on bahan.jenis_bahan = jb.id INNER JOIN satuan as sa on bahan.satuan = sa.id " +
                         "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'" + " AND stok = 0 ";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string kodeBahan = data.GetValue(0).ToString();
                    string namaBahan = data.GetValue(1).ToString();
                    int stokBahan = int.Parse(data.GetValue(2).ToString());
                    int hargaBeliBahan = int.Parse(data.GetValue(3).ToString());

                    int idWarna = int.Parse(data.GetValue(4).ToString());
                    string namaWarna = data.GetValue(5).ToString();

                    string idjenisBahan = data.GetValue(6).ToString();
                    string namaJenisBahan = data.GetValue(7).ToString();

                    string idSatuan = data.GetValue(8).ToString();
                    string namaSatuan = data.GetValue(9).ToString();
                    int minimal = int.Parse(data.GetValue(10).ToString());

                    warna w = new warna(idWarna, namaWarna);
                    jenisBahan jb = new jenisBahan(idjenisBahan, namaJenisBahan);

                    satuan s = new satuan(idSatuan, namaSatuan);

                    bahan bhn = new bahan(kodeBahan, namaBahan, stokBahan, hargaBeliBahan, w, jb, s, minimal);

                    listBahan.Add(bhn);
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

            string sql = "SELECT SUBSTRING(id,2,4) FROM bahan ORDER BY id DESC LIMIT 1";

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
                        kodeTerbaru = "M000" + kodeTerbaru;
                    }
                    else if (kodeTerbaru.Length == 2)
                    {
                        kodeTerbaru = "M00" + kodeTerbaru;
                    }
                    else if (kodeTerbaru.Length == 3)
                    {
                        kodeTerbaru = "M0" + kodeTerbaru;
                    }
                    else
                    {
                        kodeTerbaru = "M" + kodeTerbaru;
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

        public string TambahData(bahan bhn)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "INSERT INTO bahan(id, namaBahan, Stok,hargaBeli,warna,jenis_bahan,satuan,minimal) VALUES ('" +
                bhn.Id + "','" + bhn.NamaBahan + "','" + bhn.Stok + "','" + bhn.HargaBeli + "','" + bhn.Warna.Id + "','" + bhn.Jenis_bahan.Id + "','" + bhn.Satuan.Id + "','" + bhn.Minimal + "')";

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

        public string UbahData(bahan bhn)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "UPDATE bahan SET namaBahan = '" + bhn.NamaBahan
                +  "', Stok = '" + bhn.Stok + "', hargaBeli = '" + bhn.HargaBeli + "', warna = '" + bhn.Warna.Id  + "', jenis_bahan = '" + bhn.Jenis_bahan.Id + "', satuan = '" + bhn.Satuan.Id + "', minimal = '" + bhn.Minimal + "' WHERE id = '" + bhn.Id + "'";

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

        public string HapusData(bahan bhn)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "DELETE FROM bahan WHERE id = '" + bhn.Id + "'";

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
