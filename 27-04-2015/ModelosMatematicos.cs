using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_04_2015
{
    class ModelosMatematicos
    {
        //Estos valores siempre deben ser Reales pueden cojer un valor diferente valores reales
        double X1 = -15;
        double Y1 = -10;
        double X2 = 15;
        double Y2 = 10;
        //Estos valores siempre deben ser Enteros por se r de la pantalla
        int SX1 = 0;
        int SY1 = 0;
        int SX2 = 600;
        int SY2 = 400;
      

        public void pantalla(double X, double Y, out int SX, out int SY)
        {
            int xs, ys;
            SX = 0;
            SY = 0;
            
            //Nos permite controlar es la formula de los vectores

            xs = (int)Math.Truncate(((SX1 - SX2) / (X1 - X2)) * (X - X1)) + SX1;
            ys = (int)Math.Truncate(((SY1 - SY2) / (Y2 - Y1)) * (Y - Y1)) + SY2;
            if (xs < 600 && ys < 400)
            {
                SX = xs; SY = ys;
            }
        }

        //metodo que transforma las coordenadas de la pantalla del pc a la pantalla real
        public void Transformar(int SX, int SY, out double X, out double Y)
        {
            X = (((SX - SX1) * (X1 - X2)) / (SX1 - SX2)) + X1;
            Y = (((SY - SY2) * (Y2 - Y1)) / (SY1 - SY2)) + Y1;
        }

    }
}
