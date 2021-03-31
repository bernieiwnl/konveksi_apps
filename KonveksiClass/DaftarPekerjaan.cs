using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KonveksiClass
{
    public class DaftarPekerjaan
    {
        private List<pekerjaan> listPekerjaan;
        private string kodeTerbaru;

        public List<pekerjaan> ListPekerjaan { get => listPekerjaan; set => listPekerjaan = value; }
        public string KodeTerbaru { get => kodeTerbaru; }

        public int JumlahPekerjaan
        {
            get { return listPekerjaan.Count; }
        }


        public DaftarPekerjaan()
        {
            listPekerjaan = new List<pekerjaan>();
            kodeTerbaru = "P1";
        }

        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();

            string sql = "SELECT p.idPengerjaan, k.idKegiatan, k.namaKegiatan, peg.KodePegawai, " +
                "peg.Nama, p.tanggalKegiatan, p.keterangan, p.status, b.KodeBarang, b.Nama, p.harga, p.satuan FROM pengerjaan p INNER JOIN kegiatan k on k.idKegiatan = p.idKegiatan INNER JOIN pegawai peg on peg.KodePegawai = p.idPegawai INNER JOIN barang b ON B.KodeBarang = P.kodeBarang";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string idPengerjaan = data.GetValue(0).ToString();
                    string idKegiatan = data.GetValue(1).ToString();
                    string namaKegiatan = data.GetValue(2).ToString();
                    string idPegawai = data.GetValue(3).ToString();
                    string namaPegawai = data.GetValue(4).ToString();
                    string tgl = data.GetValue(5).ToString();
                    string keterangan = data.GetValue(6).ToString();
                    string status = data.GetValue(7).ToString();
                    string kodeBarang = data.GetValue(8).ToString();
                    string namaBarang = data.GetValue(9).ToString();
                    int harga = int.Parse(data.GetValue(10).ToString());
                    int satuan = int.Parse(data.GetValue(11).ToString());

                    kegiatan kat = new kegiatan(idKegiatan, namaKegiatan);

                    pegawai peg = new pegawai(idPegawai, namaPegawai, default, "", "", "" , "" , null);

                    barang bar = new barang(kodeBarang, namaBarang, 0, 0, null, null, 0);

                    pekerjaan pek = new pekerjaan(idPengerjaan, kat, peg, DateTime.Parse(tgl), keterangan, status, harga, satuan, bar);

                    ListPekerjaan.Add(pek);
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

            string sql = "SELECT p.idPengerjaan, k.idKegiatan, k.namaKegiatan, peg.KodePegawai, peg.Nama, p.tanggalKegiatan, p.keterangan, p.status, b.KodeBarang, b.Nama, p.harga, p.satuan FROM pengerjaan p INNER JOIN kegiatan k on k.idKegiatan = p.idKegiatan INNER JOIN pegawai peg on peg.KodePegawai = p.idPegawai INNER JOIN barang b ON B.KodeBarang = P.kodeBarang WHERE " + kriteria + " LIKE '%" + nilaiKriteria + "%'";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string idPengerjaan = data.GetValue(0).ToString();
                    string idKegiatan = data.GetValue(1).ToString();
                    string namaKegiatan = data.GetValue(2).ToString();
                    string idPegawai = data.GetValue(3).ToString();
                    string namaPegawai = data.GetValue(4).ToString();
                    string tgl = data.GetValue(5).ToString();
                    string keterangan = data.GetValue(6).ToString();
                    string status = data.GetValue(7).ToString();
                    string kodeBarang = data.GetValue(8).ToString();
                    string namaBarang = data.GetValue(9).ToString();
                    int harga = int.Parse(data.GetValue(10).ToString());
                    int satuan = int.Parse(data.GetValue(11).ToString());

                    kegiatan kat = new kegiatan(idKegiatan, namaKegiatan);

                    pegawai peg = new pegawai(idPegawai, namaPegawai, default, "", "", "", "", null);

                    barang bar = new barang(kodeBarang, namaBarang, 0, 0, null, null, 0);

                    pekerjaan pek = new pekerjaan(idPengerjaan, kat, peg, DateTime.Parse(tgl), keterangan, status, harga, satuan, bar);

                    ListPekerjaan.Add(pek);
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

            string sql = "SELECT SUBSTRING(idPengerjaan,2) FROM pengerjaan ORDER BY idPengerjaan DESC LIMIT 1";

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

        public string TambahData(pekerjaan pek)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "INSERT INTO pengerjaan(idPengerjaan, idKegiatan, idPegawai, tanggalKegiatan, keterangan, status, kodeBarang, harga, satuan) VALUES ('" +
                pek.IdPengerjaan + "','" + pek.Kegiatan.IdKegiatan + "','" + pek.Pegawai.KodePegawai + "','" + pek.TanggalKegiatan.ToString("yyyy-MM-dd hh:mm:ss") + "','" + pek.Keterangan + "','" + pek.Status + "','" + pek.Barang.KodeBarang + "','"+ pek.Harga + "','" + pek.Satuan + "')";

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


        public string UbahData(pekerjaan pek)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "UPDATE pengerjaan SET idPegawai = '" + pek.Pegawai.KodePegawai
                + "', idKegiatan = '" + pek.Kegiatan.IdKegiatan + "', status = '" + pek.Status + "', keterangan = '" + "', kodeBarang = '" + pek.Barang.KodeBarang + "', harga = '" + pek.Harga + "', satuan = '" + pek.Satuan +  "', keterangan = '" + pek.Keterangan + "' WHERE idPengerjaan = '" + pek.IdPengerjaan + "'";

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


        public string HapusData(pekerjaan pek)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "DELETE FROM pengerjaan WHERE idPengerjaan = '" + pek.IdPengerjaan + "'";

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

        public void CetakNota(string kriteria, string nilaiKriteria, string namaFile)
        {
            CariData(kriteria, nilaiKriteria);
            StreamWriter file = new StreamWriter(namaFile);

            for (int i = 0; i < listPekerjaan.Count; i++)
            {
                //info perusahaan
                file.WriteLine("        Nota Gaji        ");
                file.WriteLine("    UD. KONVEKSI DAN SABLON INDRA");
                file.WriteLine("    Kota Mataram, Lombok, NTB");
                file.WriteLine("    Telp. (031) - 89900800");
                file.WriteLine("==========================================");

                //header nota
                file.WriteLine("No.Pekerjaan    : " + listPekerjaan[i].IdPengerjaan);
                file.WriteLine("Tanggal         : " + listPekerjaan[i].TanggalKegiatan.ToString("dddd, dd MMMM yyyy"));
                file.WriteLine("");
                file.WriteLine("Pegawai         : " + listPekerjaan[i].Pegawai.Nama);
                file.WriteLine("Kegiatan        : " + listPekerjaan[i].Kegiatan.NamaKegiatan);
                file.WriteLine("");
                file.WriteLine("==========================================");

                //barang yg terjual
                int subTotal = 0;

                string nama = listPekerjaan[i].Barang.NamaBarang;
                string kode = listPekerjaan[i].Barang.KodeBarang;

                    if (nama.Length > 30)
                    {
                        nama = nama.Substring(0, 30);
                    }

                int satuan = ListPekerjaan[i].Satuan;
                int harga = ListPekerjaan[i].Harga;
                subTotal = satuan * harga;

                file.Write("Kode");
                file.Write(SpasiTambahan("Kode".Length, 10));
                file.Write("Barang");
                file.Write(SpasiTambahan("Barang".Length, 15));
                file.Write("Satuan");
                file.Write(SpasiTambahan("Satuan".ToString().Length, 10));
                file.Write("Harga");
                file.WriteLine("\n");


                file.Write(kode);
                file.Write(SpasiTambahan(kode.Length, 10));
                file.Write(nama);
                file.Write(SpasiTambahan(nama.Length, 15));
                file.Write(satuan);
                file.Write(SpasiTambahan(satuan.ToString().Length, 10));
                file.Write(harga.ToString("0,###"));
                file.WriteLine("");

                file.WriteLine("==========================================");
                file.WriteLine("Total : " + subTotal.ToString("0,####"));
                file.WriteLine("");
            }

            file.Close();
            cetak c = new cetak(namaFile, "Courier New", 13, 20, 20, 20, 20);
            c.CetakKePrinter("tulisan");
        }

        private string SpasiTambahan(int jmlKarakterSaatIni, int jmlKarakterMax)
        {
            string spasi = "";
            for (int i = jmlKarakterSaatIni; i < jmlKarakterMax; i++)
            {
                spasi = spasi + " ";
            }
            return spasi;
        }

    }
}
