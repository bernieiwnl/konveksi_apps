using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.IO;
using System.Drawing;
using System.Drawing.Printing;

namespace KonveksiClass
{
    public class DaftarNotaJual
    {
        private List<notaJual> listNotaJual;
        private string noNotaBaru;
        public List<notaJual> ListNotaJual
        {
            get { return listNotaJual; }
        }

        public int JumlahNotaJual
        {
            get { return listNotaJual.Count; }
        }

        public string NoNotaBaru
        {
            get { return noNotaBaru; }
        }

        public DaftarNotaJual()
        {
            listNotaJual = new List<notaJual>();
            noNotaBaru = "20200101001";
        }

        public string GenerateNoNota()
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT SUBSTRING(NoNota,9,3) AS noUrutTransaksi " +
                         "FROM notajual WHERE Date(Tanggal) = Date(CURRENT_DATE) " +
                         "ORDER BY NoNota DESC LIMIT 1";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                MySqlDataReader data = c.ExecuteReader();

                string noUrutTransTerbaru = "";

                if (data.Read() == true)
                {
                    int noUrutTrans = int.Parse(data.GetValue(0).ToString()) + 1;
                    noUrutTransTerbaru = noUrutTrans.ToString();
                    if (noUrutTransTerbaru.Length == 1)
                    {
                        noUrutTransTerbaru = "00" + noUrutTransTerbaru;
                    }
                    else if (noUrutTransTerbaru.Length == 2)
                    {
                        noUrutTransTerbaru = "0" + noUrutTransTerbaru;
                    }
                }
                else
                {
                    noUrutTransTerbaru = "001";
                }

                string tahun = DateTime.Now.Year.ToString();
                string bulan = DateTime.Now.Month.ToString();
                if (bulan.Length == 1)
                {
                    bulan = "0" + bulan;
                }

                string tanggal = DateTime.Now.Day.ToString();
                if (tanggal.Length == 1)
                {
                    tanggal = "0" + tanggal;
                }

                noNotaBaru = tahun + bulan + tanggal + noUrutTransTerbaru.ToString();

                c.Dispose();
                data.Dispose();
                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string TambahData(notaJual nota)
        {
            Koneksi k1 = new Koneksi();
            k1.Connect();

            string sql1 = "INSERT INTO notajual(NoNota, Tanggal, tanggalSelesai, KodePelanggan, KodePegawai, Status) VALUES ('" +
                           nota.NoNota + "','" + nota.Tanggal.ToString("yyyy-MM-dd hh:mm:ss") + "','" + nota.TanggalSelesai.ToString("yyyy-MM-dd hh:mm:ss") + "','" +
                           nota.Pelanggan.KodePelanggan + "','" + nota.Pegawai.KodePegawai + "','" + nota.Status +"')";

            MySqlCommand c1 = new MySqlCommand(sql1, k1.KoneksiDB);

            try
            {
                c1.ExecuteNonQuery();

                for (int i = 0; i < nota.JumlahBarangNota; i++)
                {
                    Koneksi k2 = new Koneksi();
                    k2.Connect();

                    string sql2 = "INSERT INTO notajualdetil(NoNota, KodeBarang, Harga, Jumlah) VALUES ('" +
                                   nota.NoNota + "','" + nota.ListNotaDetil[i].BarangNota.KodeBarang + "','" +
                                   nota.ListNotaDetil[i].HargaJual + "','" + nota.ListNotaDetil[i].JumlahJual + "')";

                    MySqlCommand c2 = new MySqlCommand(sql2, k2.KoneksiDB);
                    c2.ExecuteNonQuery();

                    string hasilUpdateBrg = UpdateStokBarang(nota.ListNotaDetil[i]);
                }
                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public string UpdateStokBarang(notaJualDetail detilNota)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "";
            sql = "UPDATE barang SET Stok = Stok - " + detilNota.JumlahJual +
                " WHERE KodeBarang = '" + detilNota.BarangNota.KodeBarang + "'";

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

        public string UbahStatusPesanan(notaJual nota)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "UPDATE notajual SET Status = '" + nota.Status + "' WHERE NoNota = '" + nota.NoNota + "'";

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


        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT N.NoNota, N.Tanggal, N.tanggalSelesai, N.Status, N.KodePelanggan, Plg.Nama AS NamaPelanggan, Plg.Alamat AS AlamatPelanggan, N.KodePegawai, Peg.Nama AS NamaPegawai " +
                "FROM notaJual N INNER JOIN pelanggan Plg ON N.KodePelanggan = Plg.KodePelanggan " +
                "INNER JOIN pegawai Peg ON N.KodePegawai = Peg.KodePegawai " +
                "ORDER BY N.NoNota DESC";
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();
                while (data.Read() == true)
                {
                    string nmrNota = data.GetValue(0).ToString();
                    DateTime tgglNota = DateTime.Parse(data.GetValue(1).ToString());
                    DateTime tglSelesai = DateTime.Parse(data.GetValue(2).ToString());
                    string status = data.GetValue(3).ToString();
                    string plgKode = data.GetValue(4).ToString();
                    string plgNama = data.GetValue(5).ToString();
                    string plgAlamat = data.GetValue(6).ToString();

                    pelanggan plg = new pelanggan();
                    plg.KodePelanggan = plgKode;
                    plg.NamaPelanggan = plgNama;
                    plg.Alamat = plgAlamat;

                    string pegKode = data.GetValue(7).ToString();
                    string pegNama = data.GetValue(8).ToString();
                    

                    pegawai pegawai = new pegawai();
                    pegawai.KodePegawai = pegKode;
                    pegawai.Nama = pegNama;

                    List<notaJualDetail> listDetilNota = new List<notaJualDetail>();

                    Koneksi k2 = new Koneksi();
                    k2.Connect();

                    string sql2 = "SELECT NJD.KodeBarang, B.Nama, NJD.Harga, NJD.Jumlah " +
                        "FROM notajual NJ INNER JOIN notajualdetil NJD ON NJ.NoNota = NJD.NoNota " +
                        "INNER JOIN barang B ON NJD.KodeBarang = B.KodeBarang " +
                        "WHERE NJ.NoNota='" + nmrNota + "'";
                    MySqlCommand c2 = new MySqlCommand(sql2, k2.KoneksiDB);

                    MySqlDataReader data2 = c2.ExecuteReader();
                    while (data2.Read() == true)
                    {
                        string brgKode = data2.GetValue(0).ToString();
                        string brgNama = data2.GetValue(1).ToString();
                        barang brg = new barang();
                        brg.KodeBarang = brgKode;
                        brg.NamaBarang = brgNama;
                        int hrgJual = int.Parse(data2.GetValue(2).ToString());
                        int jmlhJual = int.Parse(data2.GetValue(3).ToString());

                        notaJualDetail detilNota = new notaJualDetail(brg, hrgJual, jmlhJual);

                        listDetilNota.Add(detilNota);
                    }
                    c2.Dispose();
                    data2.Dispose();

                    notaJual nota = new notaJual(nmrNota, tgglNota, tglSelesai, plg, pegawai, status, listDetilNota);
                    listNotaJual.Add(nota);
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


        public string TampilNota()
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT N.NoNota, N.Tanggal, N.tanggalSelesai, N.Status, N.KodePelanggan, Plg.Nama AS NamaPelanggan, Plg.Alamat AS AlamatPelanggan, N.KodePegawai, Peg.Nama AS NamaPegawai " +
                "FROM notaJual N INNER JOIN pelanggan Plg ON N.KodePelanggan = Plg.KodePelanggan " +
                "INNER JOIN pegawai Peg ON N.KodePegawai = Peg.KodePegawai " +
                "WHERE Status!='Selesai' ";
            //TIMESTAMPDIFF(DAY, Tanggal, tanggalSelesai) = 3 &&
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();
                while (data.Read() == true)
                {
                    string nmrNota = data.GetValue(0).ToString();
                    DateTime tgglNota = DateTime.Parse(data.GetValue(1).ToString());
                    DateTime tglSelesai = DateTime.Parse(data.GetValue(2).ToString());
                    string status = data.GetValue(3).ToString();
                    string plgKode = data.GetValue(4).ToString();
                    string plgNama = data.GetValue(5).ToString();
                    string plgAlamat = data.GetValue(6).ToString();

                    pelanggan plg = new pelanggan();
                    plg.KodePelanggan = plgKode;
                    plg.NamaPelanggan = plgNama;
                    plg.Alamat = plgAlamat;

                    string pegKode = data.GetValue(7).ToString();
                    string pegNama = data.GetValue(8).ToString();


                    pegawai pegawai = new pegawai();
                    pegawai.KodePegawai = pegKode;
                    pegawai.Nama = pegNama;

                    List<notaJualDetail> listDetilNota = new List<notaJualDetail>();

                    Koneksi k2 = new Koneksi();
                    k2.Connect();

                    string sql2 = "SELECT NJD.KodeBarang, B.Nama, NJD.Harga, NJD.Jumlah " +
                        "FROM notajual NJ INNER JOIN notajualdetil NJD ON NJ.NoNota = NJD.NoNota " +
                        "INNER JOIN barang B ON NJD.KodeBarang = B.KodeBarang " +
                        "WHERE NJ.NoNota='" + nmrNota + "'";
                    MySqlCommand c2 = new MySqlCommand(sql2, k2.KoneksiDB);

                    MySqlDataReader data2 = c2.ExecuteReader();
                    while (data2.Read() == true)
                    {
                        string brgKode = data2.GetValue(0).ToString();
                        string brgNama = data2.GetValue(1).ToString();
                        barang brg = new barang();
                        brg.KodeBarang = brgKode;
                        brg.NamaBarang = brgNama;
                        int hrgJual = int.Parse(data2.GetValue(2).ToString());
                        int jmlhJual = int.Parse(data2.GetValue(3).ToString());

                        notaJualDetail detilNota = new notaJualDetail(brg, hrgJual, jmlhJual);

                        listDetilNota.Add(detilNota);
                    }
                    c2.Dispose();
                    data2.Dispose();

                    notaJual nota = new notaJual(nmrNota, tgglNota, tglSelesai, plg, pegawai, status, listDetilNota);
                    listNotaJual.Add(nota);
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
            Koneksi k1 = new Koneksi();
            k1.Connect();


            string sql1 = "SELECT N.NoNota, N.Tanggal, N.tanggalSelesai, N.KodePelanggan, Plg.Nama AS NamaPelanggan, Plg.Alamat AS Alamat, N.KodePegawai, N.Status, Pg.Nama AS Nama FROM notajual N INNER JOIN pelanggan Plg ON N.KodePelanggan = Plg.KodePelanggan INNER JOIN pegawai Pg ON N.KodePegawai = Pg.KodePegawai WHERE " + kriteria + " like '%" + nilaiKriteria + "%' ";

            MySqlCommand c1 = new MySqlCommand(sql1, k1.KoneksiDB);
            try
            {
                MySqlDataReader data1 = c1.ExecuteReader();

                while (data1.Read() == true)
                {
                    string noNota = data1.GetValue(0).ToString();
                    DateTime tgl = DateTime.Parse(data1.GetValue(1).ToString());
                    DateTime tglSelesai = DateTime.Parse(data1.GetValue(2).ToString());
                    string kodePlg = data1.GetValue(3).ToString();
                    string namaPlg = data1.GetValue(4).ToString();
                    string alamat = data1.GetValue(5).ToString();
                    pelanggan plg = new pelanggan();
                    plg.KodePelanggan = kodePlg;
                    plg.NamaPelanggan = namaPlg;
                    plg.Alamat = alamat;
                    string kodePg = data1.GetValue(6).ToString();
                    string namaPg = data1.GetValue(7).ToString();
                    string status = data1.GetValue(8).ToString();

                    pegawai pg = new pegawai();
                    pg.KodePegawai = kodePg;
                    pg.Nama = namaPg;

                    List<notaJualDetail> listDetilNota = new List<notaJualDetail>();

                    Koneksi k2 = new Koneksi();
                    k2.Connect();

                    string sql2 = "SELECT NJD.KodeBarang, B.Nama, NJD.Harga, NJD.Jumlah " +
                                  "FROM notajual N INNER JOIN notajualdetil NJD ON N.NoNota = NJD.NoNota " +
                                  "INNER JOIN barang B ON NJD.KodeBarang = B.KodeBarang " +
                                  "WHERE N.NoNota='" + noNota + "'";

                    MySqlCommand c2 = new MySqlCommand(sql2, k2.KoneksiDB);

                    MySqlDataReader data2 = c2.ExecuteReader();
                    while (data2.Read() == true)
                    {
                        string kodeBrg = data2.GetValue(0).ToString();
                        string namaBrg = data2.GetValue(1).ToString();

                        barang brg = new barang();
                        brg.KodeBarang = kodeBrg;
                        brg.NamaBarang = namaBrg;

                        int hargaJual = int.Parse(data2.GetValue(2).ToString());
                        int jmlJual = int.Parse(data2.GetValue(3).ToString());

                        notaJualDetail detilNota = new notaJualDetail(brg, hargaJual, jmlJual);
                        listDetilNota.Add(detilNota);
                    }

                    c2.Dispose();
                    data2.Dispose();

                    notaJual nota = new notaJual(noNota, tgl, tglSelesai, plg, pg, status, listDetilNota);
                    listNotaJual.Add(nota);
                }

                c1.Dispose();
                data1.Dispose();
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

            for (int i = 0; i < listNotaJual.Count; i++)
            {
                //info perusahaan
                file.WriteLine("        Nota Penjualan        ");
                file.WriteLine("    UD. KONVEKSI DAN SABLON INDRA");
                file.WriteLine("    Kota Mataram, Lombok, NTB");
                file.WriteLine("    Telp. (031) - 89900800");
                file.WriteLine("==========================================");

                //header nota
                file.WriteLine("No.Nota   : " + listNotaJual[i].NoNota);
                file.WriteLine("Tanggal   : " + listNotaJual[i].Tanggal);
                file.WriteLine("Tanggal Selesai   : " + listNotaJual[i].TanggalSelesai);

                file.WriteLine("");
                file.WriteLine("Pelanggan : " + listNotaJual[i].Pelanggan.NamaPelanggan);
                file.WriteLine("Alamat    : " + listNotaJual[i].Pelanggan.Alamat);
                file.WriteLine("");
                file.WriteLine("Kasir     : " + listNotaJual[i].Pegawai.Nama);
                file.WriteLine("==========================================");

                //barang yg terjual
                int grandTotal = 0;
                for (int j = 0; j < listNotaJual[i].JumlahBarangNota; j++)
                {
                    string nama = listNotaJual[i].ListNotaDetil[j].BarangNota.NamaBarang;

                    if (nama.Length > 30)
                    {
                        nama = nama.Substring(0, 30);
                    }

                    int jumlah = listNotaJual[i].ListNotaDetil[j].JumlahJual;
                    int harga = listNotaJual[i].ListNotaDetil[j].HargaJual;
                    int subTotal = jumlah * harga;

                    file.Write(nama);
                    file.Write(SpasiTambahan(nama.Length, 30));
                    file.Write(jumlah);
                    file.Write(SpasiTambahan(jumlah.ToString().Length, 3));
                    file.Write(harga.ToString("0,###"));
                    file.WriteLine("");
                    grandTotal = grandTotal + jumlah * harga;
                }

                file.WriteLine("==========================================");
                file.WriteLine("TOTAL : " + grandTotal.ToString("0,####"));
                file.WriteLine("==========================================");
                file.WriteLine("     Terima Kasih Sudah Membeli Produk Kami     ");
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
