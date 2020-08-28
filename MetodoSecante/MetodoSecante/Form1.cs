using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MetodoSecante
{
    public partial class Form1 : Form
    {

        public int i = 0;
        public double xI1 = 0;
        public double xI2 = 1;
        private List<iteraciones> listIte { get; set; }

        public Form1()
        {
            listIte = DoIter();
            InitializeComponent();
            this.CenterToScreen();
        }

        public double calcXI(double xI, double fxI, double xImxIm1, double fxIm1)
        {
            return xI - ((fxI * xImxIm1) / (fxI - fxIm1));
        }

        public double calcFxI(double xI)
        {
            return Math.Exp(-xI) - xI;
        }

        public double calcFxIm1(double xIm1)
        {
            return Math.Exp(-xIm1) - xIm1;
        }

        public double calcXImxIm1(double xI, double xIm1)
        {
            return xI-xIm1;
        }

        public double calcError(double xrN, double xrA)
        {
            return Math.Abs((xrN - xrA) / xrN) * 100;
        }

        private List<iteraciones> DoIter()
        {
            var list = new List<iteraciones>();
            list.Add(new iteraciones(1, xI1));
            double error, xI, fxI, fxIm1, xImxI1;
            fxI = calcFxI(xI2);
            fxIm1 = calcFxIm1(xI1);
            xImxI1 = calcXImxIm1(xI2, xI1);
            list.Add(new iteraciones(2, xI2, fxI, fxIm1, xImxI1));
            int it = 2;
            do
            {
                iteraciones anterior = list.Last();
                it++;
                xI = calcXI(anterior.xI, anterior.fxI, anterior.xImxIm1, anterior.fxIm1);
                fxI = calcFxI(xI);
                fxIm1 = calcFxIm1(anterior.xI);
                xImxI1 = calcXImxIm1(xI, anterior.xI);
                error = calcError(xI, anterior.xI);
                list.Add(new iteraciones(it, xI, fxI, fxIm1, xImxI1, error));
            }
            while (error >= 0.001);

            return list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ite = listIte;
            iteraciones iF = ite.Last();
            this.textBox1.Text = iF.xI.ToString();
            tabla.DataSource = ite;
        }

    }
}
