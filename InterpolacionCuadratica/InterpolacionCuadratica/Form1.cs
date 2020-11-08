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
        public double x0 = 0, x1 = 1, x2 = 4;
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

        public void calcResta()
        {
            r2[0] = Math.Pow(x1, 2) - Math.Pow(x2, 2);
            r2[1] = Math.Pow(x2, 2) - Math.Pow(x0, 2);
            r2[2] = Math.Pow(x0, 2) - Math.Pow(x1, 2);
            r1[0] = x1 - x2;
            r1[1] = x2 - x0;
            r1[2] = x0 - x1;
        }

        public double calcX3(double fx0, double fx1, double fx2)
        {
            return ((fx0 * r2[0]) + (fx1 * r2[1]) + (fx2 * r2[2])) / ((2 * fx0 * r1[0]) + (2 * fx1 * r1[1]) + (2 * fx2 * r1[2]));
        }

        private List<iteraciones> DoIter()
        {
            var list = new List<iteraciones>();
            int i = 1;
            double fx0, fx1, fx2, x3, fx3;
            for (int j = 0; j < 5; j++)
            {
                fx0 = calcFx(x0);
                fx1 = calcFx(x1);
                fx2 = calcFx(x2);
                calcResta();
                x3 = calcX3(fx0, fx1, fx2);
                fx3 = calcFx(x3);
                list.Add(new iteraciones(i, x0, x1, x2, fx0, fx1, fx2, x3, fx3));

                if (x1 < x3)
                {
                    x0 = x1;
                }
                else
                {
                    x2 = x1;
                }
                x1 = x3;
                i++;
            }
            return list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ite = listIte;
            iteraciones iF = ite.Last();
            this.textBox1.Text = iF.x3.ToString();
            this.textBox2.Text = iF.fx3.ToString();
            tabla.DataSource = ite;
        }

    }
}
