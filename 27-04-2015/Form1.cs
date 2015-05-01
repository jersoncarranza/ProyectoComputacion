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
        Color fondos;//El color a elegir
        
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
            
            fondos = Color.Yellow ;

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

      

        private void button2_Click(object sender, EventArgs e)
        {
            Curva curva = new Curva(1, 0, 0, 2, Color.Red, Bm, Viewport);
            curva.encender();
        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            Curva curva = new Curva(3, 0, 0, 4, Color.Red, Bm, Viewport);
            curva.encender();
        }

        private void todo_Click(object sender, EventArgs e)
        {
            Curva curva = new Curva(0, 4, -3, 2, fondos, Bm, Viewport);
            curva.encender();

            Curva curva2 = new Curva(1, 11, 0, 2, fondos, Bm, Viewport);
            curva2.encender();

            Curva curva3 = new Curva(2, -3, 0, 2, fondos, Bm, Viewport);
            curva3.encender();
        }

        private void color_Click(object sender, EventArgs e)
        {
            ColorDialog objC = new ColorDialog();
            objC.ShowDialog();
            fondos = objC.Color;
        }

        private void Viewport_MouseUp(object sender, MouseEventArgs e)
        {
            switch (Habilitado)
            {   
                case 1://segmento
                    ModelosMatematicos mod = new ModelosMatematicos();
                    mod.Transformar(e.X, e.Y, out fx, out fy);
                    Segmento objseg = new Segmento(rx, ry, fx, fy, fondos, Bm, Viewport);
                    objseg.encender();
                break;

                case 2: //circunferencia    
                    ModelosMatematicos mol = new ModelosMatematicos();
                    mol.Transformar(e.X, e.Y, out fx, out fy);
                    double rad = Math.Sqrt(Math.Pow((rx - fx), 2) + Math.Pow((ry - fy), 2));
                    Circunferencia cir = new Circunferencia(rx, ry, rad, fondos, Bm, Viewport);
                    cir.Radio = rad;
                    cir.encender();
                break;

                case 3: //pixel
                     ModelosMatematicos objpix = new ModelosMatematicos();
                    objpix.Transformar(e.X, e.Y, out fx, out fy);
                    Vector obj = new Vector(fx, fy, fondos, Bm, Viewport);
                    obj.encender();
                break;

                case 4://lazo 
                    ModelosMatematicos objlazo = new ModelosMatematicos();
                    objlazo.Transformar(e.X, e.Y, out fx, out fy);
                    double rad_lazo = Math.Sqrt(Math.Pow((rx - fx), 2) + Math.Pow((ry - fy), 2));
                    Curva curva = new Curva(0, rx, ry, rad_lazo, fondos, Bm, Viewport);
                        curva.encender();
                break;
                case 5://Margarita
                
                    ModelosMatematicos objMargarita = new ModelosMatematicos();
                    objMargarita.Transformar(e.X, e.Y, out fx, out fy);
                    double rad_Mar = Math.Sqrt(Math.Pow((rx - fx), 2) + Math.Pow((ry - fy), 2));
                    Curva objCurMar = new Curva(2, rx, ry, rad_Mar, Color.Red, Bm, Viewport);
                    objCurMar.encender();
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
            fondos= Color.White;
        }

        private void btn_silver_Click(object sender, EventArgs e)
        {
            fondos = Color.Silver;
        }

        private void btn_Sienna_Click(object sender, EventArgs e)
        {
            fondos = Color.Sienna;
        }

        private void btn_LightSalmon_Click(object sender, EventArgs e)
        {
            fondos = Color.LightSalmon;
        }

        private void btn_DarkOrange_Click(object sender, EventArgs e)
        {
            fondos = Color.DarkOrange;
        }

        private void btn_azul_Click(object sender, EventArgs e)
        {
            fondos = Color.Blue;
        }

        private void btn_Khaki_Click(object sender, EventArgs e)
        {
            fondos = Color.Khaki;
        }

        private void btn_PaleGreen_Click(object sender, EventArgs e)
        {
            fondos = Color.PaleGreen;
        }

        private void btn_Turquoise_Click(object sender, EventArgs e)
        {
            fondos = Color.Turquoise;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fondos = Color.Black;
        }

        private void btn_DimGray_Click(object sender, EventArgs e)
        {
            fondos = Color.DimGray;
        }

        private void btn_Maroon_Click(object sender, EventArgs e)
        {
            fondos = Color.Maroon;
        }

        private void btn_red_Click(object sender, EventArgs e)
        {
            fondos = Color.Red;
        }

        private void btn_NavajoWhite_Click(object sender, EventArgs e)
        {
            fondos = Color.NavajoWhite;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            fondos = Color.Yellow;
        }

        private void btn_Green_Click(object sender, EventArgs e)
        {
            fondos = Color.Green;
        }

        private void btn_RoyalBlue_Click(object sender, EventArgs e)
        {
            fondos = Color.RoyalBlue;
        }

        private void btn_DarkViolet_Click(object sender, EventArgs e)
        {
            fondos = Color.DarkViolet;
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
    }
}
