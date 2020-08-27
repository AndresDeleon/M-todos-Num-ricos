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
        public double xI = 0;
        public double xGxI = 0;
        private List<iteraciones> listIte { get; set; }

        public Form1()
        {
            listIte = DoIter();
            InitializeComponent();
            this.CenterToScreen();
        }

        public double calcXGxI(double xI)
        {
            return Math.Exp(-xI);
        }

        public double calcError(double xIN, double xIA)
        {
            return Math.Abs((xIN - xIA) / xIN) * 100;
        }

        private List<iteraciones> DoIter()
        {
            var list = new List<iteraciones>();
            xGxI = calcXGxI(xI);
            list.Add(new iteraciones(1, xI, xGxI));
            double error, comp;
            int it = 1;
            do
            {
                iteraciones anterior = list.Last();
                it++;
                xI = anterior.xGxI;
                xGxI = calcXGxI(xI);
                error = calcError(anterior.xGxI, anterior.xI);
                comp = Math.Truncate(error * 1000);
                list.Add(new iteraciones(it, xI, xGxI, error));
            }
            while ((comp / 1000) != 0.001 || (comp / 1000) < 0.001);

            return list;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ite = listIte;
            iteraciones iF = ite.Last();
            this.textBox1.Text = iF.xGxI.ToString();
            tabla.DataSource = ite;
        }

    }
}
