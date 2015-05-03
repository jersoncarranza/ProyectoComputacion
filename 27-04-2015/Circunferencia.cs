using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _27_04_2015
{
    class Circunferencia : Vector
    {
        // se aumenta el atributo radio
        private double radio;
        public Color scl; //color

        public static PictureBox Slienzo;
        public static Graphics SGrafico;
        public static Bitmap Sbit;

        public double tcos;
        public double tsen;

        public double Radio
        {
            get { return radio; }
            set { radio = value; }
        }


        // constructores
        public Circunferencia()
        {
        }

        public Circunferencia(double x0s, double y0s, double r, Color clr, Bitmap bi, PictureBox lienzos)
        {
            this.y0 = y0s;
            this.x0 = x0s;
            radio = r;
            this.scl = clr;
            Slienzo = lienzos;// es el que enviamos para que se dibuje
            Sbit = bi;
            SGrafico = Slienzo.CreateGraphics();
        }

        public override void encender()
        {
            double t = Math.PI*0, dt = 0.003;
            Vector seg = new Vector(0, 0, scl, Sbit, Slienzo);//aki quede los parametros
            do
            {

                seg.x0 = x0 + (radio) * Math.Cos(t);
                seg.y0 = y0 + (radio) * Math.Sin(t);
                seg.encender();
                t = t + dt;
            } while (t <= (2* Math.PI)/1);
        }



        public void encender6()
        {
            double t = Math.PI * -1 / 2, dt = 0.003;
            Vector seg = new Vector(0, 0, scl, Sbit, Slienzo);//aki quede los parametros
            do
            {

                seg.x0 = x0 + (radio) * Math.Cos(t);
                seg.y0 = y0 + (radio) * Math.Sin(t);
                seg.encender();
                t = t + dt;
            } while (t <= (5 * Math.PI) / 6);
        }

        public void encender3()
        {
            double t = Math.PI * -2 / 3, dt = 0.003;
            Vector seg = new Vector(0, 0, scl, Sbit, Slienzo);//aki quede los parametros
            do
            {

                seg.x0 = x0 + (radio) * Math.Cos(t);
                seg.y0 = y0 + (radio) * Math.Sin(t);
                seg.encender();
                t = t + dt;
            } while (t <= (1 * Math.PI) / 2);

            //Segmento obj_seg = new Segmento();


        }
 


        public void apagarDinamico(Color c)
        {
            double t = 0, dt = 0.003;
            Vector seg = new Vector(0, 0, scl, Sbit, Slienzo);//aki quede los parametros
            do
            {

                //seg.x0 = x0 + (radio) * Math.Cos(tcos * t);
                seg.y0 = y0 + (radio) * Math.Sin(tsen * t);
               // seg.apagar(c);
                t = t + dt;
            } while (t <= 2 * 3.141516);

        }

    }
}