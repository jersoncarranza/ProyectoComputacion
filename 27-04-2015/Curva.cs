using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _27_04_2015
{
    class Curva: Vector
    {
       double Radio; 
        private int tipo;
        PictureBox Slienzo;
        Color scl;
        Graphics SGrafico;
        Bitmap Sbit;

        public Curva(int tip, double xfs, double yfs, Double r, Color clr, Bitmap bi, PictureBox lienzos)
        {
            this.y0 = yfs;
            this.x0 = xfs;
            Radio = r;
            tipo = tip;
            this.scl = clr;
            Slienzo = lienzos;// es el que enviamos para que se dibuje
            Sbit = bi;
            SGrafico = Slienzo.CreateGraphics();
        }



        public override void encender()
        {
            switch (tipo)
            {
                case 0: double t = 0, dt = 0.001;
                        Vector lazo = new Vector(0, 0, scl, Sbit, Slienzo);//aki quede los parametros
                        do
                        {
                            lazo.x0 = x0 + (Radio * Math.Sin(2 * t)) * Radio;
                            lazo.y0 = y0 + (Radio * Math.Cos(3 * t)) * Radio;
                            lazo.encender();
                            t = t + dt;
                        } while (t <= (2 * Math.PI));
                        break;



                case 1: t = 0; dt = 0.003;
                        Vector Hipociclo = new Vector(0, 0, scl, Sbit, Slienzo);//aki quede los parametros creamos
                        do
                        {
                            Hipociclo.x0 = x0 + (Math.Sin(t) * Math.Sin(t) * Math.Sin(t)) * Radio;
                            Hipociclo.y0 = y0 + (Math.Cos(t) * Math.Cos(t) * Math.Cos(t)) * Radio;
                            Hipociclo.encender();
                            t = t + dt;
                        } while (t <= 2 * Math.PI);
                        break;
                case 2: t = 0; dt = 0.003;
                        Vector Margarita = new Vector(0, 0, scl, Sbit, Slienzo);//aki quede los parametros creamos
                        do
                        {
                            Margarita.x0 = x0 + ((0.7 * Math.Cos(4 * t) * Math.Cos(t))/2) * Radio;
                            Margarita.y0 = y0 + ((0.7 * Math.Cos(4 * t) * Math.Sin(t))/2) * Radio;
                            Margarita.encender();
                            t = t + dt;
                        } while (t <= 2 * Math.PI);
                        break;
                case 3: t = 0; dt = 0.003;
                        Vector Lemiscata = new Vector(0, 0, scl, Sbit, Slienzo);//aki quede los parametros creamos
                        do
                        {
                            Lemiscata.x0 = x0 + ((4 * Math.Cos(t) - Math.Cos(4 * t)) / 4) * Radio;
                            Lemiscata.y0 = y0 + ((4 * Math.Sin(t) - Math.Sin(4 * t)) / 4) * Radio;
                            Lemiscata.encender();
                            t = t + dt;
                        } while (t <= 2 * Math.PI);
                        break;
                default:
                    break;
            }

            


        }
    }
}
