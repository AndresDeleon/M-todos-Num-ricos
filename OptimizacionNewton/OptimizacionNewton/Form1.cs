using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptimizacionNewton
{
    public partial class Form1 : Form
    {

        public int i = 0;
        public double x = 2.5, px = 1.4275, py = 1.7757;

        public double[] r1 = new double[3];
        public double[] r2 = new double[3];
        private List<iteraciones> listIte { get; set; }

        public Form1()
        {
            listIte = DoIter();
            InitializeComponent();
            this.CenterToScreen();
        }

        public double calcFx(double x)
        {
            return 2 * Math.Sin(x) - (Math.Pow(x, 2) / 10);
        }

        public double calcFdx(double x)
        {
            return 2 * Math.Cos(x) - (x / 5);
        }

        public double calcFddx(double x)
        {
            return (-2 * Math.Sin(x) - 0.2);
        }

        public double calcXi(double x, double fdx, double fddx)
        {
            return x - (fdx / fddx);
        }

        private List<iteraciones> DoIter()
        {
            var list = new List<iteraciones>();
            int i = 1;
            double fx, fdx, fddx;
            for (int j = 0; j < 5; j++)
            {
                fx = calcFx(x);
                fdx = calcFdx(x);
                fddx = calcFddx(x);
                list.Add(new iteraciones(i, x, fx, fdx, fddx));
                x = calcXi(x, fdx, fddx);
                i++;
            }
            return list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ite = listIte;
            iteraciones iF = ite.Last();
            this.textBox1.Text = iF.x.ToString();
            this.textBox2.Text = iF.fx.ToString();
            tabla.DataSource = ite;
        }

    }
}
