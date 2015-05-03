using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading; 

namespace _27_04_2015
{
    public partial class Form_ComGra : Form
    {
        Bitmap Bm;
        Color ColorBorde;//El color a elegir
        
        private int Habilitado = 0;
        // aka se almacean las coordenadas inciales y finales
        double rx;  //inicial
        double ry;   //inicial
        double fy;   //final
        double fx;   //final


        public Form_ComGra()
        {
            InitializeComponent();

            Bm = new Bitmap(600, 400);
            Viewport.Image = Bm;
            
            ColorBorde = Color.Black ;

            //eventos para ke el mouse pueda seleccionar una coordenada
            Viewport.MouseDown += new MouseEventHandler(Viewport_MouseDown);
            Viewport.MouseUp += new MouseEventHandler(Viewport_MouseUp);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Bm = new Bitmap(600, 400);
            Viewport.Image = Bm;
        
        }
        private void pixel_Click(object sender, EventArgs e)
        {
            Habilitado = 3; //pixel
        }
   

        private void color_Click(object sender, EventArgs e)
        {
            ColorDialog objC = new ColorDialog();
            objC.ShowDialog();
            ColorBorde = objC.Color;
        }

        private void Viewport_MouseUp(object sender, MouseEventArgs e)
        {
            switch (Habilitado)
            {   
                case 1://segmento
                    ModelosMatematicos mod = new ModelosMatematicos();
                    mod.Transformar(e.X, e.Y, out fx, out fy);
                    Segmento objseg = new Segmento(rx, ry, fx, fy, ColorBorde, Bm, Viewport);
                    objseg.encender();
                break;

                case 2: //circunferencia    
                    ModelosMatematicos mol = new ModelosMatematicos();
                    mol.Transformar(e.X, e.Y, out fx, out fy);
                    double rad = Math.Sqrt(Math.Pow((rx - fx), 2) + Math.Pow((ry - fy), 2));
                    Circunferencia cir = new Circunferencia(rx, ry, rad, ColorBorde, Bm, Viewport);
                    cir.Radio = rad;
                    cir.encender();
                break;

                case 3: //pixel
                     ModelosMatematicos objpix = new ModelosMatematicos();
                    objpix.Transformar(e.X, e.Y, out fx, out fy);
                    Vector obj = new Vector(fx, fy, ColorBorde, Bm, Viewport);
                    obj.encender();
                break;

                case 4://lazo 
                    ModelosMatematicos objlazo = new ModelosMatematicos();
                    objlazo.Transformar(e.X, e.Y, out fx, out fy);
                    double rad_lazo = Math.Sqrt(Math.Pow((rx - fx), 2) + Math.Pow((ry - fy), 2));
                    Curva curva = new Curva(0, rx, ry, rad_lazo, ColorBorde, Bm, Viewport);
                    curva.encender();
                break;
                case 5://Margarita
                
                    ModelosMatematicos objMargarita = new ModelosMatematicos();
                    objMargarita.Transformar(e.X, e.Y, out fx, out fy);
                    double rad_Mar = Math.Sqrt(Math.Pow((rx - fx), 2) + Math.Pow((ry - fy), 2));
                    Curva objCurMar = new Curva(2, rx, ry, rad_Mar, ColorBorde, Bm, Viewport);
                    objCurMar.encender();
                break;
                case 6://Estrella
                    ModelosMatematicos obj_Est = new ModelosMatematicos();
                    obj_Est.Transformar(e.X, e.Y, out fx, out fy);
                    double rad_Est = Math.Sqrt(Math.Pow((rx - fx), 2) + Math.Pow((ry - fy), 2));
                    Curva objCurEst = new Curva(1, rx, ry, rad_Est, ColorBorde, Bm, Viewport);
                    objCurEst.encender();
                break;

                case 7://Estrella
                ModelosMatematicos obj_Lem = new ModelosMatematicos();
                obj_Lem.Transformar(e.X, e.Y, out fx, out fy);
                double rad_Lem = Math.Sqrt(Math.Pow((rx - fx), 2) + Math.Pow((ry - fy), 2));
                Curva objCurLem = new Curva(3, rx, ry, rad_Lem, ColorBorde, Bm, Viewport);
                objCurLem.encender();
                break;

                case 8://Dos
                    ModelosMatematicos obj_seis = new ModelosMatematicos();
                    obj_seis.Transformar(e.X, e.Y, out fx, out fy);
                    double rad_seis = Math.Sqrt(Math.Pow((rx - fx), 2) + Math.Pow((ry - fy), 2));
                    Circunferencia objCurSeis = new Circunferencia(rx, ry, rad_seis, ColorBorde, Bm, Viewport);
                    objCurSeis.Radio = rad_seis;
                    objCurSeis.encender6();

                    Segmento objn = new Segmento(rx + rad_seis, ry, rx-rad_seis, ry - (2*rad_seis), ColorBorde, Bm, Viewport);
                    objn.encender();

                    Segmento objn1 = new Segmento(rx - rad_seis, ry - (2 * rad_seis), rx + rad_seis, ry - (2*rad_seis), ColorBorde, Bm, Viewport);
                    objn1.encender();
                    
                break;

                case 9://Tres3
                    ModelosMatematicos obj_tres = new ModelosMatematicos();
                    obj_tres.Transformar(e.X, e.Y, out fx, out fy);
                    double rad_tres = Math.Sqrt(Math.Pow((rx - fx), 2) + Math.Pow((ry - fy), 2));
                    Circunferencia objCurTres = new Circunferencia(rx, ry, rad_tres, ColorBorde, Bm, Viewport);
                    objCurTres.Radio = rad_tres;
                    objCurTres.encender3();

                    Segmento objn3 = new Segmento(rx , ry+rad_tres, rx+rad_tres, ry + (2 * rad_tres), ColorBorde, Bm, Viewport);
                    objn3.encender();

                    Segmento objn31 = new Segmento(rx + rad_tres, ry + (2 * rad_tres),  rx - (rad_tres/2), ry + (2 * rad_tres), ColorBorde, Bm, Viewport);
                    objn31.encender();

                
                break;
                case 10:
                    //Dibuja la linea
                    ModelosMatematicos objSegPen = new ModelosMatematicos();
                    objSegPen.Transformar(e.X, e.Y, out fx, out fy);

                    double rxa = rx;
                    double rya = ry;
                    double fxa = fx;
                    double fya = fy;

                    Segmento objseg2 = new Segmento(rxa, rya, fxa, fya, ColorBorde, Bm, Viewport);
                    objseg2.encender();


                   //Dibuja la pendiente
                    double midx = (rxa + fxa) / 2;
                    double midy = (rya + fya) / 2;
                    double pendiente = ((fya - rya) / (fxa - rxa));
                    
                    pendiente = (1 / pendiente) * -1;
                    rxa = 100;
                    rya =(pendiente *100);
                    fxa = midx;
                    fya = midy;
                 
                    Segmento objsegpend = new Segmento(rxa, rya, fxa, fya, ColorBorde, Bm, Viewport);
                    objsegpend.encender();
                     
                   
                    rxa = -100;
                    rya =(pendiente * -100);
                    fxa = midx;
                    fya = midy;

                    Segmento objpab = new Segmento(rxa, rya, fxa, fya, ColorBorde, Bm, Viewport);
                    objpab.encender();
                    //objsegpend.encender();

                   


                break;



                    default:
                    break;
            }


        }

        private void Viewport_MouseDown(object sender, MouseEventArgs e)
        {
            ModelosMatematicos mol = new ModelosMatematicos();
            mol.Transformar(e.X, e.Y, out rx, out ry);
        }

        private void Viewport_Click(object sender, EventArgs e)
        {

        }

        private void btn_Circunferencia_Click(object sender, EventArgs e)
        {
            Habilitado = 2;
        }

        private void btn_ColorBlanco_Click(object sender, EventArgs e)
        {
            ColorBorde= Color.White;
        }

        private void btn_silver_Click(object sender, EventArgs e)
        {
            ColorBorde = Color.Silver;
        }

        private void btn_Sienna_Click(object sender, EventArgs e)
        {
            ColorBorde = Color.Sienna;
        }

        private void btn_LightSalmon_Click(object sender, EventArgs e)
        {
            ColorBorde = Color.LightSalmon;
        }

        private void btn_DarkOrange_Click(object sender, EventArgs e)
        {
            ColorBorde = Color.DarkOrange;
        }

        private void btn_azul_Click(object sender, EventArgs e)
        {
            ColorBorde = Color.Blue;
        }

        private void btn_Khaki_Click(object sender, EventArgs e)
        {
            ColorBorde = Color.Khaki;
        }

        private void btn_PaleGreen_Click(object sender, EventArgs e)
        {
            ColorBorde = Color.PaleGreen;
        }

        private void btn_Turquoise_Click(object sender, EventArgs e)
        {
            ColorBorde = Color.Turquoise;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ColorBorde = Color.Black;
        }

        private void btn_DimGray_Click(object sender, EventArgs e)
        {
            ColorBorde = Color.DimGray;
        }

        private void btn_Maroon_Click(object sender, EventArgs e)
        {
            ColorBorde = Color.Maroon;
        }

        private void btn_red_Click(object sender, EventArgs e)
        {
            ColorBorde = Color.Red;
        }

        private void btn_NavajoWhite_Click(object sender, EventArgs e)
        {
            ColorBorde = Color.NavajoWhite;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ColorBorde = Color.Yellow;
        }

        private void btn_Green_Click(object sender, EventArgs e)
        {
            ColorBorde = Color.Green;
        }

        private void btn_RoyalBlue_Click(object sender, EventArgs e)
        {
            ColorBorde = Color.RoyalBlue;
        }

        private void btn_DarkViolet_Click(object sender, EventArgs e)
        {
            ColorBorde = Color.DarkViolet;
        }

        private void btn_linea_Click(object sender, EventArgs e)
        {
            Habilitado = 1;
        }

        private void btn_lazo_Click(object sender, EventArgs e)
        {
            Habilitado = 4;
      
        }

        private void btn_margarita_Click(object sender, EventArgs e)
        {
            Habilitado = 5;
        }

        private void btn_estrellla_Click(object sender, EventArgs e)
        {
            Habilitado = 6;
        }

        private void btn_lemisaca_Click(object sender, EventArgs e)
        {
            Habilitado = 7;
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            Habilitado = 8;
        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            Habilitado = 9;
        }

        private void btn_segLinea_Click(object sender, EventArgs e)
        {
            Habilitado = 10;
        }

        private void creditos_Click(object sender, EventArgs e)
        {
            frm_ayuda frm = new frm_ayuda();
            frm.Show();
        }

      
    }
}
