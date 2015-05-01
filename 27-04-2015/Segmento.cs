using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _27_04_2015
{
    class Segmento:Vector
    {


        //el atributo x0 y y0 son los puntos inciales del segmento, y son heredados de la clase vector

        // xf y yf son los puntos finales del segmento
        private double xf;
        private double yf;

        public static PictureBox Slienzo;
        public static Graphics SGrafico;
        public static Bitmap Sbit;
        public Color scl;


        public double Xf
        {
            get { return xf; }
            set { xf = value; }
        }

        public double Yf
        {
            get { return yf; }
            set { yf = value; }
        }

        //construcctores
        public Segmento(double xfs, double yfs, double xf, double yf, Color clr, Bitmap bi, PictureBox lienzos)//enviar de parametros del bitmap y del picture como salida
        {
            this.y0 = yfs;
            this.x0 = xfs;
            this.yf = yf;
            this.xf = xf;
            this.scl = clr;
            Slienzo = lienzos;// es el que enviamos para que se dibuje
            Sbit = bi;
            SGrafico = lienzos.CreateGraphics();

        }
        public Segmento(Color clr, Bitmap bi, PictureBox lienzos)
        {
            this.scl = clr;
            Slienzo = lienzos;// es el que enviamos para que se dibuje
            Sbit = bi;
            SGrafico = Slienzo.CreateGraphics();

        }




        public Segmento()
        {
        }


        public override void encender()
        {
            double t = 0, dt = 0.003;
            Vector seg = new Vector(0, 0, scl, Sbit, Slienzo);//aki quede los parametros
            do
            {
                seg.x0 = x0 * (1 - t) + xf * (t);
                seg.y0 = y0 * (1 - t) + yf * (t);
                seg.encender();
                t = t + dt;
            } while (t <= 1);

        }
    }
}
