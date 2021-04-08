using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonveksiClass
{
    public class DaftarPesan
    {
        private List<pesan> listpesan;
        private string kodeTerbaru;

        public string KodeTerbaru { get => kodeTerbaru; set => kodeTerbaru = value; }

        public List<pesan> Listpesan { get => listpesan; set => listpesan = value; }

        public int JumlahPesan
        {
            get { return listpesan.Count; }
        }

        public DaftarPesan()
        {
            Listpesan = new List<pesan>();
            kodeTerbaru = "P1";
        }

        public string CariData(string kriteria, string nilaiKriteria)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT pesan.idPesan, p1.KodePegawai, p1.Nama, p2.KodePegawai, p2.Nama, keterangan FROM pesan INNER JOIN pegawai as p1 on pesan.idTujuan = p1.KodePegawai INNER JOIN pegawai as p2 on pesan.idPenerima = p2.KodePegawai " +
                         "WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string id = data.GetValue(0).ToString();
                    string idTujuan = data.GetValue(1).ToString();
                    string namaTujuan = data.GetValue(2).ToString();
                    string idPenerima = data.GetValue(3).ToString();
                    string namaPenerima = data.GetValue(4).ToString();
                    string keterangan = data.GetValue(5).ToString();

                    pegawai p1 = new pegawai(idTujuan, namaTujuan, default, null, null, null, null, null);
                    pegawai p2 = new pegawai(idPenerima, namaPenerima, default, null, null, null, null, null);

                    pesan psn = new pesan(id, p1, p2, keterangan);

                    listpesan.Add(psn);
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

            string sql = "SELECT SUBSTRING(idPesan,2) FROM pesan ORDER BY idPesan DESC LIMIT 1";

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
                        kodeTerbaru = "P" + kodeTerbaru;
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

        public string TambahData(pesan p)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "INSERT INTO pesan(idPesan, idTujuan, idPenerima, keterangan) VALUES ('" + p.IdPesan + "','" + p.IdTujuan.KodePegawai + "','" + p.IdPenerima.KodePegawai + "','" + p.Keterangan + "')";

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

        public string HapusData(pesan p)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "DELETE FROM pesan WHERE idPesan = '" + p.IdPesan + "'";

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
