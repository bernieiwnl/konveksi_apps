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

using PQScan.BarcodeCreator;
using System.Drawing.Imaging;

namespace KonveksiClass
{
    public class cetak
    {
        private Font jenisFont;
        private StreamReader fileCetak;
        private float marginKiriKertas, marginKananKertas, marginAtasKertas, marginBawahKertas;

        private Barcode barcodeGenerator;
        private Image gambarBarcode;

        public Font JenisFont
        {
            get { return jenisFont; }
            set { jenisFont = value; }
        }

        public StreamReader FileCetak
        {
            get { return fileCetak; }
            set { fileCetak = value; }
        }

        public float MarginKiri
        {
            get { return marginKiriKertas; }
            set { marginKiriKertas = value; }
        }

        public float MarginKanan
        {
            get { return marginKananKertas; }
            set { marginKananKertas = value; }
        }

        public float MarginAtas
        {
            get { return marginAtasKertas; }
            set { marginAtasKertas = value; }
        }

        public float MarginBawah
        {
            get { return marginBawahKertas; }
            set { marginBawahKertas = value; }
        }

        public Barcode BarcodeGenerator
        {
            get { return barcodeGenerator; }
            set { barcodeGenerator = value; }
        }


        public cetak(string namaFile)
        {
            fileCetak = new StreamReader(namaFile);
            jenisFont = new Font("Arial", 10);
            marginKiriKertas = (float)10.5;
            marginKananKertas = (float)10.5;
            marginAtasKertas = (float)10.5;
            marginBawahKertas = (float)10.5;
        }

        public cetak(string namaFile, string namaFont, int ukuranFont, float marginKiri, float marginKanan, float marginAtas, float marginBawah)
        {
            fileCetak = new StreamReader(namaFile);
            jenisFont = new Font(namaFont, ukuranFont);
            marginKiriKertas = marginKiri;
            marginKananKertas = marginKanan;
            marginAtasKertas = marginAtas;
            marginBawahKertas = marginBawah;
        }

        public cetak(string namaFileBarcode, string dataBarcode, int panjang, int lebar)
        {
            barcodeGenerator = new Barcode();
            barcodeGenerator.BarType = BarCodeType.Code39;
            barcodeGenerator.Data = dataBarcode;

            barcodeGenerator.Width = lebar;
            barcodeGenerator.Height = panjang;

            barcodeGenerator.PictureFormat = ImageFormat.Jpeg;

            barcodeGenerator.CreateBarcode(namaFileBarcode);
            gambarBarcode = Image.FromFile(namaFileBarcode);

            marginKiriKertas = (float)10.5;
            marginKananKertas = (float)10.5;
            marginAtasKertas = (float)10.5;
            marginBawahKertas = (float)10.5;
        }

        public Image GambarBarcode
        {
            get { return GambarBarcode; }
        }

        private void CetakTulisan(object sender, PrintPageEventArgs e)
        {
            int jmlBarisPerHalaman = (int)((e.MarginBounds.Height - marginBawahKertas) / jenisFont.GetHeight(e.Graphics));
            float y = marginAtasKertas;
            int jmlBaris = 0;

            string tulisanCetak = fileCetak.ReadLine();

            while (jmlBaris < jmlBarisPerHalaman && tulisanCetak != null)
            {
                y = marginAtasKertas + (jmlBaris * jenisFont.GetHeight(e.Graphics));
                e.Graphics.DrawString(tulisanCetak, jenisFont, Brushes.Black, marginKiriKertas, y);
                jmlBaris++;
                tulisanCetak = fileCetak.ReadLine();
            }
            if (tulisanCetak != null)
            {
                e.HasMorePages = true;
            }
            else
            {
                e.HasMorePages = false;
            }
        }

        public string CetakKePrinter(string tipe)
        {
            try
            {
                PrintDocument p = new PrintDocument();
                if (tipe == "tulisan")
                {
                    p.PrintPage += new PrintPageEventHandler(CetakTulisan);
                }
                else if (tipe == "barcode")
                {
                    p.PrintPage += new PrintPageEventHandler(CetakBarcode);
                }

                p.Print();
                fileCetak.Close();
                return "sukses";
            }
            catch (Exception e)
            {
                return "Proses cetak gagal. Pesan kesalahan = " + e.Message;
            }
        }

        private void CetakBarcode(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(gambarBarcode, marginKiriKertas, marginAtasKertas, (float)barcodeGenerator.Width, (float)barcodeGenerator.Height);
        }
    }
}
