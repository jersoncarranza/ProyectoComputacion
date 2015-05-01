using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _27_04_2015
{
    class Vector: ModelosMatematicos
    {
        //variables
        public double x0;
        public double y0;
        public Color cl;
       
        //variables para graficos
        public static PictureBox lienzo;
        public static Graphics Grafico;
        public static Bitmap bit;

        //ejecutar el construtor con los valores
        public Vector(double x0s, double y0s, Color clr, Bitmap bi, PictureBox lienzos)
        {
            this.y0 = y0s;
            this.x0 = x0s;
            this.cl = clr;
            lienzo = lienzos;
            bit = bi;
            Grafico = lienzo.CreateGraphics();

        }
        public Vector()
        { }




        //metodo para prender el pixel
        public virtual void encender()
        {
            int sx, sy;
            double p1 = Convert.ToDouble(this.x0);//poniendo el valor de xo que ingresa
            double p2 = Convert.ToDouble(this.y0);//poniendo el valor de yo que ingresa
            pantalla(x0, y0, out sx, out sy); // parametros de x0 y y0 salida valores sx, sy
            if (sx >= 0 && sx < 600 && sy >= 0 && sy < 400)// es como un try para que no me de errore al momento de graficar
            {
                bit.SetPixel(sx, sy, cl);//valores que van ha graficar
                lienzo.Image = bit;//llamar a la imagen
            }//Grafico.DrawImage(bit, 0, 0, lienzo.Width, lienzo.Height);
        }
        public virtual void apagar()
        {
            cl = Color.White;
            encender();

        }


    }
}
