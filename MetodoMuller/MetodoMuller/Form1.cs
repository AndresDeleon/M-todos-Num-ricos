using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodoMuller
{
    public partial class Form1 : Form
    {

        public int i = 0;
        public double x0 = 1;
        public double x1 = 2;
        private List<iteraciones> listIte { get; set; }

        public Form1()
        {
            listIte = DoIter();
            InitializeComponent();
            this.CenterToScreen();
        }

        public double calcX2(double x0, double x1)
        {
            return (x0 + x1)/2;
        }

        public double calcFx(double x)
        {
            return Math.Pow(x,4) - 3*Math.Pow(x,3) + Math.Pow(x,2) + x + 1;
        }

        public double calcH0(double x0, double x1)
        {
            return x1 - x0;
        }

        public double calcH1(double x1, double x2)
        {
            return x2 - x1;
        }

        public double calcD0(double fx1, double fx0, double h0)
        {
            return (fx1 - fx0)/h0;
        }

        public double calcD1(double fx2, double fx1, double h1)
        {
            return (fx2 - fx1) / h1;
        }

        public double calcA(double d0, double d1, double h1, double h0)
        {
            return (d1 - d0)/(h1 - h0);
        }

        public double calcB(double a, double d1, double h1)
        {
            return (a * h1) + d1;
        }

        public double calcX3(double x2, double a, double b, double c)
        {
            double x3 = 0;
            if (b > 0)
            {
                x3 = x2 + ((-2 * c) / (b + Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))));
            } 
            else
            {
                x3 = x2 + ((-2 * c) / (b - Math.Sqrt(Math.Pow(b, 2) - (4 * a * c))));
            }
            return x3;
        }

        public double calcError(double xrN, double xrA)
        {
            return Math.Abs((xrN - xrA) / xrN) * 100;
        }

        private List<iteraciones> DoIter()
        {
            var list = new List<iteraciones>();
            double error, x2 = 0, fx0, fx1, fx2, h0, h1, d0, d1, a, b, c, x3;
            int it = 1;
            do
            {
                if (it == 1) { x2 = calcX2(x0, x1);  };
                fx0 = calcFx(x0);
                fx1 = calcFx(x1);
                fx2 = calcFx(x2);
                h0 = calcH0(x0, x1);
                h1 = calcH1(x1, x2);
                d0 = calcD0(fx1, fx0, h0);
                d1 = calcD1(fx2, fx1, h1);
                a = calcA(d0, d1, h1, h0);
                b = calcB(a, d1, h1);
                c = fx2;
                x3 = calcX3(x2, a, b, c);
                if (it != 1)
                {
                    iteraciones anterior = list.Last();
                    error = calcError(x3, anterior.x3);
                    list.Add(new iteraciones(it, x0, x1, x2, fx0, fx1, fx2, h0, h1, d0, d1, a, b, c, x3, error));
                }
                else
                {
                    error = 100;
                    list.Add(new iteraciones(it, x0, x1, x2, fx0, fx1, fx2, h0, h1, d0, d1, a, b, c, x3));
                }
                x0 = x1;
                x1 = x2;
                x2 = x3;
                it++;
            }
            while (error > 0.001);

            return list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ite = listIte;
            iteraciones iF = ite.Last();
            this.textBox1.Text = iF.x3.ToString();
            tabla.DataSource = ite;
        }

    }
}
