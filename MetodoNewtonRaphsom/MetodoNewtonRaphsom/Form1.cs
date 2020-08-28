using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetodoRegulaFalsi
{
    public partial class Form1 : Form
    {

        public int i = 0;
        public double xIm1 = 3.5;
        public double fxIm1 = 0;
        public double fdxIm1 = 0;
        public double xI = 0;
        private List<iteraciones> listIte { get; set; }

        public Form1()
        {
            listIte = DoIter();
            InitializeComponent();
            this.CenterToScreen();
        }

        public double calcfxIm1(double xIm1)
        {
            return 0.95*Math.Pow(xIm1, 3) - 5.9*Math.Pow(xIm1, 2) + (10.9 * xIm1) - 6;
        }

        public double calcfdxIm1(double xIm1)
        {
            return 2.85*Math.Pow(xIm1, 2) - (11.8 * xIm1) + 10.9;
        }

        public double calcxI(double xIm1, double fxIm1, double fdxIm1)
        {
            return xIm1 - (fxIm1 / fdxIm1);
        }

        public double calcError(double xIN, double xIA)
        {
            return Math.Abs((xIN - xIA) / xIN) * 100;
        }

        private List<iteraciones> DoIter()
        {
            var list = new List<iteraciones>();
            fxIm1 = calcfxIm1(xIm1);
            fdxIm1 = calcfdxIm1(xIm1);
            xI = calcxI(xIm1, fxIm1, fdxIm1);
            list.Add(new iteraciones(1, xIm1, fxIm1, fdxIm1, xI));
            double error, comp;
            int it = 1;
            do
            {
                iteraciones anterior = list.Last();
                it++;
                xIm1 = anterior.xI;
                fxIm1 = calcfxIm1(xIm1); ;
                fdxIm1 = calcfdxIm1(xIm1);
                xI = calcxI(xIm1, fxIm1, fdxIm1);
                error = calcError(xI, anterior.xI);
                //comp = Math.Truncate(error * 1000);
                list.Add(new iteraciones(it, xIm1, fxIm1, fdxIm1, xI, error));
            }
            while (error > 0.001);

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
