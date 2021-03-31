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
    public class DaftarNotaBeli
    {
        private List<notaBeli> listNotaBeli;
        private List<notaBeliUpdate> listNotaBeliUpdate;
        private string noNotaBaru;

        public List<notaBeli> ListNotaBeli
        {
            get { return listNotaBeli; }
        }

        public int JumlahNotaBeli
        {
            get { return listNotaBeli.Count; }
        }

        public string NoNotaBaru
        {
            get { return noNotaBaru; }
        }

        public List<notaBeliUpdate> ListNotaBeliUpdate { get => listNotaBeliUpdate; set => listNotaBeliUpdate = value; }

        public DaftarNotaBeli()
        {
            listNotaBeli = new List<notaBeli>();
            noNotaBaru = "20120101001";
            listNotaBeliUpdate = new List<notaBeliUpdate>();
        }

        public string GenerateNoNota()
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT SUBSTRING(NoNota,9,3) AS noUrutTransaksi " +
                         "FROM notabeli WHERE Date(Tanggal) = Date(CURRENT_DATE) " +
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

        public string TambahData(notaBeli nota)
        {
            Koneksi k1 = new Koneksi();
            k1.Connect();

            string sql1 = "INSERT INTO notabeli(NoNota, Tanggal, KodeSupplier, KodePegawai) VALUES ('" +
                           nota.NoNota + "','" + nota.Tanggal.ToString("yyyy-MM-dd hh:mm:ss") + "','" +
                           nota.Supplier.KodeSupplier + "','" + nota.Pegawai.KodePegawai + "')";

            MySqlCommand c1 = new MySqlCommand(sql1, k1.KoneksiDB);

            try
            {
                c1.ExecuteNonQuery();

                for (int i = 0; i < nota.JumlahBarangNota; i++)
                {
                    Koneksi k2 = new Koneksi();
                    k2.Connect();

                    string sql2 = "INSERT INTO notabelidetil(NoNota, KodeBarang, Harga, Jumlah) VALUES ('" +
                                   nota.NoNota + "','" + nota.ListBeliDetil[i].BahanNota.Id + "','" +
                                   nota.ListBeliDetil[i].HargaBeli + "','" + nota.ListBeliDetil[i].JumlahBeli + "')";

                    MySqlCommand c2 = new MySqlCommand(sql2, k2.KoneksiDB);
                    c2.ExecuteNonQuery();

                    string hasilUpdateBrg = UpdateStokBarang(nota.ListBeliDetil[i]);
                }
                return "sukses";
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string UpdateStokBarang(notaBeliDetail detilNota)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "";
            sql = "UPDATE bahan SET Stok = Stok + " + detilNota.JumlahBeli +
                " WHERE id = '" + detilNota.BahanNota.Id + "'";

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

            string sql = "SELECT NB.NoNota, NB.Tanggal, NB.KodeSupplier, Sp.Nama AS NamaSupplier, Sp.Alamat AS AlamatSupplier, NB.KodePegawai, Pg.Nama AS NamaPegawai " +
                "FROM notabeli NB INNER JOIN supplier Sp ON NB.KodeSupplier = Sp.KodeSupplier " +
                "INNER JOIN pegawai Pg ON NB.KodePegawai = Pg.KodePegawai " +
                "ORDER BY NB.NoNota DESC";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();
                while (data.Read() == true)
                {
                    string nmrNota = data.GetValue(0).ToString();
                    DateTime tgglNota = DateTime.Parse(data.GetValue(1).ToString());
                    string spKode = data.GetValue(2).ToString();
                    string spNama = data.GetValue(3).ToString();
                    string spAlamat = data.GetValue(4).ToString();

                    supplier supply = new supplier();
                    supply.KodeSupplier = spKode;
                    supply.NamaSupplier = spNama;
                    supply.AlamatSupplier = spAlamat;

                    string pegKode = data.GetValue(5).ToString();
                    string pegNama = data.GetValue(6).ToString();

                    pegawai pegawai = new pegawai();
                    pegawai.KodePegawai = pegKode;
                    pegawai.Nama = pegNama;

                    List<notaBeliDetail> listDetilNota = new List<notaBeliDetail>();

                    Koneksi k2 = new Koneksi();
                    k2.Connect();

                    string sql2 = "SELECT NBD.KodeBarang, B.namaBahan, NBD.Harga, NBD.Jumlah " +
                        "FROM notabeli NB INNER JOIN notabelidetil NBD ON NB.NoNota = NBD.NoNota " +
                        "INNER JOIN bahan B ON NBD.KodeBarang = B.id " +
                        "WHERE NB.NoNota='" + nmrNota + "'";

                    MySqlCommand c2 = new MySqlCommand(sql2, k2.KoneksiDB);

                    MySqlDataReader data2 = c2.ExecuteReader();
                    while (data2.Read() == true)
                    {
                        string brgKode = data2.GetValue(0).ToString();
                        string brgNama = data2.GetValue(1).ToString();
                        bahan bahan = new bahan();
                        bahan.Id = brgKode;
                        bahan.NamaBahan = brgNama;
                        int hrgBeli = int.Parse(data2.GetValue(2).ToString());
                        int jmlhBeli = int.Parse(data2.GetValue(3).ToString());

                        notaBeliDetail detilNota = new notaBeliDetail(bahan, hrgBeli, jmlhBeli);

                        listDetilNota.Add(detilNota);
                    }
                    c2.Dispose();
                    data2.Dispose();

                    notaBeli nota = new notaBeli(nmrNota, tgglNota, supply, pegawai, listDetilNota);
                    listNotaBeli.Add(nota);
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

        public string BacaSemuaDataUpdate()
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT NB.NoNota, " +
                                "NB.Tanggal," +
                                "Pg.Nama AS DibuatOleh," +
                                "Sp.Nama AS NamaSupplier," +
                                "Sp.Alamat AS AlamatSupplier," +
                                "jnbn.nama_bahan," +
                                "bhn.namaBahan," +
                                "ntbd.Harga," +
                                "ntbd.Jumlah," +
                                "ntbd.Harga * ntbd.Jumlah as total, " +
                                "bhn.id, " + 
                                "wrn.id, " + 
                                "wrn.nama_warna " +
                                "FROM notabeli NB " +
                                "INNER JOIN supplier Sp ON NB.KodeSupplier = Sp.KodeSupplier " +
                                "INNER JOIN pegawai Pg ON NB.KodePegawai = Pg.KodePegawai " +
                                "INNER JOIN notabelidetil ntbd ON ntbd.NoNota = nb.NoNota " +
                                "INNER JOIN bahan bhn on ntbd.KodeBarang = bhn.id  " +
                                "INNER JOIN jenis_bahan jnbn on bhn.jenis_bahan = jnbn.id " +
                                "INNER JOIN warna wrn on wrn.id = bhn.warna " +
                                "ORDER BY NB.NoNota DESC";
            
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();
                while (data.Read() == true)
                {
                    string nmrNota = data.GetValue(0).ToString();
                    DateTime tgglNota = DateTime.Parse(data.GetValue(1).ToString());
                    string pegNama = data.GetValue(2).ToString();
                    string spNama = data.GetValue(3).ToString();
                    string spAlamat = data.GetValue(4).ToString();
                    string jnsbhnNama = data.GetValue(5).ToString();
                    string bhnNama = data.GetValue(6).ToString();
                    int ntbdHarga = int.Parse(data.GetValue(7).ToString());
                    int ntbdJumlah = int.Parse(data.GetValue(8).ToString());
                    int ntbdTotal = int.Parse(data.GetValue(9).ToString());
                    string bhnid = data.GetValue(10).ToString();
                    int warnaid = int.Parse(data.GetValue(11).ToString());
                    string warnaNama = data.GetValue(12).ToString();

                    supplier supply = new supplier();
                    supply.KodeSupplier = null;
                    supply.NamaSupplier = spNama;
                    supply.AlamatSupplier = spAlamat;

                    pegawai pegawai = new pegawai();
                    pegawai.KodePegawai = null;
                    pegawai.Nama = pegNama;


                    jenisBahan jnsbhn = new jenisBahan();
                    jnsbhn.Id = null;
                    jnsbhn.Nama_bahan = jnsbhnNama;

                    warna wrn = new warna();
                    wrn.Id = warnaid;
                    wrn.Nama_warna = warnaNama;

                    bahan bahan = new bahan();
                    bahan.Id = bhnid;
                    bahan.Jenis_bahan = jnsbhn;
                    bahan.Stok = 0;
                    bahan.Warna = wrn;
                    bahan.HargaBeli = 0;
                    bahan.NamaBahan = bhnNama;

                  

                    notaBeliDetail ntbd = new notaBeliDetail();
                    ntbd.BahanNota = bahan;
                    ntbd.HargaBeli = ntbdHarga;
                    ntbd.JumlahBeli = ntbdJumlah;

                    notaBeliUpdate nota = new notaBeliUpdate(nmrNota, tgglNota, supply, pegawai, ntbd);
                    listNotaBeliUpdate.Add(nota);
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

        public string CariDataNota(string kriteria, string nilaiKriteria)
        {
            Koneksi k1 = new Koneksi();
            k1.Connect();


            string sql1 = "SELECT NB.NoNota, NB.Tanggal, NB.KodeSupplier, Sp.Nama AS NamaSupplier, Sp.Alamat AS AlamatSupplier, Pg.KodePegawai, Pg.Nama AS Nama FROM notabeli NB INNER JOIN Supplier Sp ON NB.KodeSupplier = Sp.KodeSupplier INNER JOIN pegawai Pg ON NB.KodePegawai = Pg.KodePegawai WHERE " +
                kriteria + " like '%" + nilaiKriteria + "%' ";

            MySqlCommand c1 = new MySqlCommand(sql1, k1.KoneksiDB);
            try
            {
                MySqlDataReader data1 = c1.ExecuteReader();

                while (data1.Read() == true)
                {
                    string noNota = data1.GetValue(0).ToString();
                    DateTime tgl = DateTime.Parse(data1.GetValue(1).ToString());

                    string kodeSp = data1.GetValue(2).ToString();
                    string namaSp = data1.GetValue(3).ToString();
                    string alamatSp = data1.GetValue(4).ToString();

                    supplier sp = new supplier();
                    sp.KodeSupplier = kodeSp;
                    sp.NamaSupplier = namaSp;
                    sp.AlamatSupplier = alamatSp;

                    string kodePg = data1.GetValue(5).ToString();
                    string namaPg = data1.GetValue(6).ToString();

                    pegawai pg = new pegawai();
                    pg.KodePegawai = kodePg;
                    pg.Nama = namaPg;

                    List<notaBeliDetail> listDetilNota = new List<notaBeliDetail>();

                    notaBeliDetail detilNota = new notaBeliDetail(null, 0, 0);
                    listDetilNota.Add(detilNota);

                    notaBeli nota = new notaBeli(noNota, tgl, sp, pg, listDetilNota);
                    listNotaBeli.Add(nota);
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

        public string CariData(string kriteria, string nilaiKriteria)
        {
            Koneksi k1 = new Koneksi();
            k1.Connect();


            string sql1 = "SELECT NB.NoNota, NB.Tanggal, NB.KodeSupplier, Sp.Nama AS NamaSupplier, Sp.Alamat AS AlamatSupplier, Pg.KodePegawai, Pg.Nama AS Nama FROM notabeli NB INNER JOIN Supplier Sp ON NB.KodeSupplier = Sp.KodeSupplier INNER JOIN pegawai Pg ON NB.KodePegawai = Pg.KodePegawai WHERE " +
                kriteria + " like '%" + nilaiKriteria + "%' ";

            MySqlCommand c1 = new MySqlCommand(sql1, k1.KoneksiDB);
            try
            {
                MySqlDataReader data1 = c1.ExecuteReader();

                while (data1.Read() == true)
                {
                    string noNota = data1.GetValue(0).ToString();
                    DateTime tgl = DateTime.Parse(data1.GetValue(1).ToString());

                    string kodeSp = data1.GetValue(2).ToString();
                    string namaSp = data1.GetValue(3).ToString();
                    string alamatSp = data1.GetValue(4).ToString();

                    supplier sp = new supplier();
                    sp.KodeSupplier = kodeSp;
                    sp.NamaSupplier = namaSp;
                    sp.AlamatSupplier = alamatSp;

                    string kodePg = data1.GetValue(5).ToString();
                    string namaPg = data1.GetValue(6).ToString();

                    pegawai pg = new pegawai();
                    pg.KodePegawai = kodePg;
                    pg.Nama = namaPg;

                    List<notaBeliDetail> listDetilNota = new List<notaBeliDetail>();

                    Koneksi k2 = new Koneksi();
                    k2.Connect();

                    string sql2 = "SELECT NBD.KodeBarang, B.namaBahan, NBD.Harga, NBD.Jumlah " +
                                  "FROM notabeli NB INNER JOIN notabelidetil NBD ON NB.NoNota = NBD.NoNota " +
                                  "INNER JOIN bahan B ON NBD.KodeBarang = B.id " +
                                  "WHERE NB.NoNota='" + noNota + "'";

                    MySqlCommand c2 = new MySqlCommand(sql2, k2.KoneksiDB);

                    MySqlDataReader data2 = c2.ExecuteReader();
                    while (data2.Read() == true)
                    {
                        string kodeBrg = data2.GetValue(0).ToString();
                        string namaBrg = data2.GetValue(1).ToString();

                        bahan bahan = new bahan();
                        bahan.Id = kodeBrg;
                        bahan.NamaBahan = namaBrg;

                        int hargaBeli = int.Parse(data2.GetValue(2).ToString());
                        int jmlBeli = int.Parse(data2.GetValue(3).ToString());

                        notaBeliDetail detilNota = new notaBeliDetail(bahan, hargaBeli, jmlBeli);
                        listDetilNota.Add(detilNota);
                    }

                    c2.Dispose();
                    data2.Dispose();

                    notaBeli nota = new notaBeli(noNota, tgl, sp, pg, listDetilNota);
                    listNotaBeli.Add(nota);
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

            for (int i = 0; i < listNotaBeli.Count; i++)
            {
                //info perusahaan
                file.WriteLine("        Nota Pembelian        ");
                file.WriteLine("    UD. KONVEKSI DAN SABLON INDRA");
                file.WriteLine("    Kota Mataram, Lombok, NTB");
                file.WriteLine("    Telp. (031) - 89900800");
                file.WriteLine("==========================================");

                //header nota
                file.WriteLine("No.Nota   : " + listNotaBeli[i].NoNota);
                file.WriteLine("Tanggal   : " + listNotaBeli[i].Tanggal);
                file.WriteLine("");
                file.WriteLine("Pelanggan : " + listNotaBeli[i].Supplier.NamaSupplier);
                file.WriteLine("Alamat    : " + listNotaBeli[i].Supplier.AlamatSupplier);
                file.WriteLine("");
                file.WriteLine("Kasir     : " + listNotaBeli[i].Pegawai.Nama);
                file.WriteLine("==========================================");

                //barang yg terjual
                int grandTotal = 0;
                for (int j = 0; j < listNotaBeli[i].JumlahBarangNota; j++)
                {
                    string nama = listNotaBeli[i].ListBeliDetil[j].BahanNota.NamaBahan;

                    if (nama.Length > 30)
                    {
                        nama = nama.Substring(0, 30);
                    }

                    int jumlah = listNotaBeli[i].ListBeliDetil[j].JumlahBeli;
                    int harga = listNotaBeli[i].ListBeliDetil[j].HargaBeli;
                    int subTotal = jumlah + harga;

                    file.Write(nama);
                    file.Write(SpasiTambahan(nama.Length, 30));
                    file.Write(jumlah);
                    file.Write(SpasiTambahan(jumlah.ToString().Length, 3));
                    file.Write(harga.ToString("0,###"));
                    file.WriteLine("");
                    grandTotal = grandTotal + jumlah * harga;
                }

                file.WriteLine("==========================================");
                ////file.WriteLine(TOTAL : " + grandTotal.ToString("0,####"));
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
