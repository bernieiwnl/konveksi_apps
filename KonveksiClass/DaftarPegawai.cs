using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
namespace KonveksiClass
{
    public class DaftarPegawai
    {
        private List<pegawai> listPegawai;
        private string kodeTerbaru;

        public List<pegawai> ListPegawai
        {
            get { return listPegawai; }
        }

        public int JumlahPegawai
        {
            get { return listPegawai.Count; }
        }

        public string KodeTerbaru
        {
            get { return kodeTerbaru; }
        }

        public DaftarPegawai()
        {
            listPegawai = new List<pegawai>();
            kodeTerbaru = "1";
        }

        public string BacaSemuaData()
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SELECT pg.KodePegawai, pg.Nama, pg.TglLahir, pg.Alamat, pg.Gaji, pg.Username, pg.Password, jb.IdJabatan, jb.Nama FROM pegawai pg, jabatan jb WHERE pg.IdJabatan = jb.IdJabatan ORDER BY KodePegawai ASC ";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string kode = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    string tgl = data.GetValue(2).ToString();
                    string alamat = data.GetValue(3).ToString();
                    string gaji = data.GetValue(4).ToString();
                    string user = data.GetValue(5).ToString();
                    string pass = data.GetValue(6).ToString();

                    string idJabat = data.GetValue(7).ToString();
                    string namaJabat = data.GetValue(8).ToString();

                    jabatan jabat = new jabatan(idJabat, namaJabat);
                    pegawai pgw = new pegawai(kode, nama, DateTime.Parse(tgl), alamat, gaji, user, pass, jabat);
                    listPegawai.Add(pgw);
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

            string sql = "SELECT pg.KodePegawai, pg.Nama, pg.TglLahir, pg.Alamat, pg.Gaji, pg.Username, pg.Password, jb.IdJabatan, jb.Nama AS Jabatan FROM pegawai pg INNER JOIN jabatan jb ON pg.IdJabatan = jb.IdJabatan WHERE " +
                kriteria + " LIKE '%" + nilaiKriteria + "%'";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                MySqlDataReader data = c.ExecuteReader();

                while (data.Read() == true)
                {
                    string kode = data.GetValue(0).ToString();
                    string nama = data.GetValue(1).ToString();
                    string tgl = data.GetValue(2).ToString();
                    string alamat = data.GetValue(3).ToString();
                    string gaji = data.GetValue(4).ToString();
                    string user = data.GetValue(5).ToString();
                    string pass = data.GetValue(6).ToString();

                    string idJabat = data.GetValue(7).ToString();
                    string namaJabat = data.GetValue(8).ToString();

                    jabatan jabat = new jabatan(idJabat, namaJabat);
                    pegawai pgw = new pegawai(kode, nama, DateTime.Parse(tgl), alamat, gaji, user, pass, jabat);
                    listPegawai.Add(pgw);
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

            string sql = "SELECT kodePegawai FROM pegawai ORDER BY KodePegawai DESC LIMIT 1";
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

        public string TambahData(pegawai pgw)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "INSERT INTO pegawai(KodePegawai, Nama, TglLahir, Alamat, Gaji, Username, Password, IdJabatan) VALUES ('" +
                pgw.KodePegawai + "','" + pgw.Nama + "','" + pgw.TanggalLahir+ "','" + pgw.Alamat +
                "','" + pgw.Gaji + "','" + pgw.Username + "','" + pgw.Password + "','" + pgw.IdJabatanPegawai + "')";

            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                c.ExecuteNonQuery();

                string hasilBuatUser = BuatUserBaru(pgw, "localhost");
                if (hasilBuatUser == "sukses")
                {
                    string hasilBeriHak = BeriHakAkses(pgw, "localhost");
                    if (hasilBeriHak == "sukses")
                    {
                        return "sukses";
                    }
                    else
                    {
                        return "Gagal memberikan hak akses pada user. Pesan Kesalahan = " + hasilBeriHak;
                    }
                }
                else
                {
                    return "Gagal membuat user baru. Pesan kesalahan = " + hasilBuatUser;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string UbahData(pegawai pgw)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "UPDATE pegawai SET Nama = '" + pgw.Nama + "', TglLahir = '" + pgw.TanggalLahir + "', Alamat = '" +
                    pgw.Alamat + "', Gaji = '" + pgw.Gaji + "', Username = '" + pgw.Username + "', Password = '" +
                    pgw.Password + "', IdJabatan = '" + pgw.IdJabatanPegawai + "' WHERE pegawai.KodePegawai = '" + pgw.KodePegawai + "'";

            //buat Mysqlcommand
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);
            try
            {
                c.ExecuteNonQuery();
                string ubahpassword = UbahPasswordUser(pgw, "localhost");
                if (ubahpassword == "sukses")
                {
                    return "sukses";
                }
                else
                {
                    return "Gagal mengubah password. Pesan kesalahan = " + ubahpassword;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string HapusData(pegawai pgw)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            //tuliskan perintah SQL yang akan dijalankan

            //"DELETE FROM `pegawai` WHERE `pegawai`.`KodePegawai` = 11"?
            string sql = "DELETE FROM pegawai WHERE pegawai.KodePegawai = '" + pgw.KodePegawai + "'";

            //buat Mysqlcommand
            MySqlCommand c = new MySqlCommand(sql, k.KoneksiDB);

            try
            {
                c.ExecuteNonQuery();
                string hapususer = HapusUser(pgw, "localhost");
                if (hapususer == "sukses")
                {
                    return "sukses";
                }
                else
                {
                    return "Gagal menghapus data. Pesan kesalahan = " + hapususer;
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string BuatUserBaru(pegawai pw, string namaServer)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "CREATE USER '" + pw.Username + "'@'" + namaServer + "' IDENTIFIED BY '" + pw.Password + "'";
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

        public string BeriHakAkses(pegawai pw, string namaServer)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "GRANT ALL PRIVILEGES ON *.* TO '" + pw.Username + "'@'" + namaServer + "' WITH GRANT OPTION;";
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

        public string UbahPasswordUser(pegawai pw, string namaServer)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "SET PASSWORD FOR '" + pw.Username + "'@'" + namaServer + "'=PASSWORD('" + pw.Password + "')";
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

        public string HapusUser(pegawai pw, string namaServer)
        {
            Koneksi k = new Koneksi();
            k.Connect();

            string sql = "DROP USER '" + pw.Username + "'@'" + namaServer + "'";
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
