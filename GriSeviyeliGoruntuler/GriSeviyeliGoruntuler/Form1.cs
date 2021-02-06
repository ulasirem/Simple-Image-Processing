using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GriSeviyeliGoruntuler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //Resim yükle butonun abastığımızda resim yüklennmesi için OpenFileDialog ekledik
        {

            OpenFileDialog dosya = new OpenFileDialog();
                dosya.Filter = "Resim Dosyası |*.jpg;*.nef;*.png| Video|*.avi| Tüm Dosyalar |*.*";
                dosya.Title = "www.yazilimkodlama.com";
                dosya.ShowDialog();
                string DosyaYolu = dosya.FileName;
                pictureBox1.ImageLocation = DosyaYolu;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap image = new Bitmap(pictureBox1.Image); //griyap butonuna bastığımızda pictureBox1 de bulunan resmi kullanırız
            Bitmap gri = griYap(image); //griYap fonksiyonunu kullanarak image in gri olmasını sağlarız
            pictureBox2.Image = gri;    //gri ye dönüşen resmimiz pictureBox2 de görünür.


        }

        private Bitmap griYap(Bitmap bmp)
        {
            //yatayda ve dikeyde resmi dolaşabilmek için iç içe for kullanırız
            for (int i=0; i<bmp.Height-1; i++)
            {
                for (int j=0; j<bmp.Width; j++ ) {

                    int deger = (bmp.GetPixel(j, i).R + bmp.GetPixel(j, i).G + bmp.GetPixel(j, i).B) / 3; //Renkli bir görüntüyü gri renge dönüştürebilmek için RGB değerlerini 3 böleriz

                    Color renk; //Color nesnesi oluşturduk
                    renk = Color.FromArgb(deger, deger, deger); //her bir RGB değerini yeni oluşturulan renkleri yerleştiririz

                    bmp.SetPixel(j, i, renk); //j ve i piksellerine renk parametresini set ettik
                  }
            }

            return bmp;
        }
    }
}
