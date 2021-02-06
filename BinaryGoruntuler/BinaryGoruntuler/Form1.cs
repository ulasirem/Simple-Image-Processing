using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BinaryGoruntuler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
            Bitmap image = new Bitmap(pictureBox1.Image); //PictureBox1 deki resim image nesnemizin içinde
            Bitmap binary = binaryYap(image); //bu imege yi binaryYap fonksiyonuna yollayarak binary dönmüş halini görürüz. 

            pictureBox2.Image = binary; //binary ye dönüşmüş resmi pictureBox2 içinde gösteririrz
        }

        private Bitmap binaryYap(Bitmap image)
        {
            Bitmap gri = griYap(image); //Binary yapmadan önce resmimizi gri seviyeye dönüştürmemiz gerekir

            int esik = 125; //eşik değerinin altındakiler 0(siyah) üstündeyse 1(beyaz) olur.Eşik değeri 0-255 arasında olmalıdır.Bu eşik değeri elle girmek yerine bir parametre ile yapılır.

            int temp = 0; //bir pikseldeki başlangıç değeri olacak

            Color renk;

            //iç içe for kullnarakk gri seviyeye çevirdiğimiz görüntüyü binary e çeviririz
            for (int i=0; i<image.Height-1; i++)
            {
                for (int j=0; j<image.Width-1; j++)
                {

                    temp = gri.GetPixel(j, i).R; //RGB değerleinden herhangi birini alabiliriz çünkü gri seviyeye çevirirken hepsine aynı değeri verdik

                    //temp değerinin bulunduğu pixel deki durumuna bakarız
                    if ( temp < esik )
                    {
                        renk = Color.FromArgb(0,0,0); //eğer 100 ün altındaysa gri seviyesi 0(siyah) a eşitleriz
                        gri.SetPixel(j, i, renk);
                    }
                    else 
                    { 
                        renk = Color.FromArgb(255, 255, 255); //temp değerimiz 100 ün üstünde ise tüm değerlerini 255 vererek 1(beyaz) yaparız
                        gri.SetPixel(j, i, renk);
                    }
                }
            }

            return gri;
        }

        private Bitmap griYap(Bitmap bmp) {
            //iç i.e for ile tüm resmi piksel piksel dolaşırız
            for (int i=0; i<bmp.Height-1; i++ )
            {
                for (int j=0; j<bmp.Width-1; j++ ) {
                    int deger = (bmp.GetPixel(j,i).R + bmp.GetPixel(j,i).G + bmp.GetPixel(j,i).B) / 3;

                    Color renk = Color.FromArgb(deger,deger,deger);

                    bmp.SetPixel(j, i, renk);
                }
            }

            return bmp;
        }
    }
}
