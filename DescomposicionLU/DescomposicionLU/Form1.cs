using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrizAdjunta
{

    public partial class Form1 : Form
    {
        public static int tam = 3;
        public int col = 0, fil = 0;
        public double[] f = new double[tam];
        public double[] incognita = new double[tam];
        public double[] det1 = new double[] { 7.85, -19.3, 71.4 };
        public double[] det2 = new double[tam];
        public double[,] matrizU1 = new double[tam,tam];
        public double[,] matrizTemp = new double[tam, tam];
        public double[,] matrizU2 = new double[tam, tam];
        public double[,] matrizL1 = new double[tam, tam];
        public double[,] matrizA = new double[tam, tam];

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public void calcMatrizU()
        {
            matrizTemp = matrizA;
            int n=0;
            for (int k = 0; k < (tam - 1); k++)
            {
                double c1 = matrizTemp[col, fil], c2 = 0;
                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        if (i <= col)
                        {
                            matrizU1[i, j] = matrizTemp[i, j];
                        }
                        else
                        {
                            if (j == col)
                            {
                                c2 = matrizTemp[i, j];
                                f[n] = c2 / c1;
                                n++;
                            }
                            matrizU1[i, j] = matrizTemp[i, j] - ((c2 / c1) * matrizTemp[(fil), j]);
                        }
                    }
                }
                col++;
                fil++;
                matrizTemp = matrizU1;
            }

        }

        public void calcMatrizL()
        {
            int c, f = 0, d = 0, a = 0;
            for (int i = 0; i < tam; i++)
            {
                if (i != 0)
                {
                    f = i;
                }
                c = 0;
                for (int j = 0; j < tam; j++)
                {
                    if (i == d && j == d)
                    {
                        matrizL1[i, j] = 1;
                        d++;
                    }
                    else
                    {
                        if (c < f)
                        {
                            matrizL1[i, j] = this.f[a];
                            c++;
                            a++;
                        }
                        else
                        {
                            matrizL1[i, j] = 0;
                        }
                    }
                }
            }
        }

        public void calcDet()
        {
            int f = 0;
            for (int i = 0; i < tam; i++)
            {
                double resto = 0;
                for (int j = 0; j < tam; j++)
                {
                    if (matrizL1[i, j] != 0 && i == f)
                    {
                        if (i != 0)
                        {
                            resto += det2[j] * matrizL1[i, j];
                        }
                    }
                }
                det2[i] = det1[i] - resto;
                f++;
            }
        }

        public void calcInc()
        {
            calcDet();
            int c = 0, f = (tam - 1);
            for (int i = (tam - 1); i >= 0; i--)
            {
                double resto = 0;
                for (int j = (tam - 1); j >= 0; j--)
                {
                    if (matrizU1[i, j] != 0 && i == f)
                    {
                        if (i != (tam - 1))
                        {
                            resto += matrizU1[i, j] * incognita[j];
                        }
                    }
                }
                incognita[i] = (det2[i] - resto) / matrizU1[i, f];
                f--;
            }
        }


        public void cargarMatriz()
        {
            matrizInicial.Columns.Clear();
            matrizU.Columns.Clear();
            matrizA[0, 0] = 3;
            matrizA[0, 1] = -0.1;
            matrizA[0, 2] = -0.2;
            matrizA[1, 0] = 0.1;
            matrizA[1, 1] = 7;
            matrizA[1, 2] = -0.3;
            matrizA[2, 0] = 0.3;
            matrizA[2, 1] = -0.2;
            matrizA[2, 2] = 10;
            calcMatrizU();
            calcMatrizL();
            calcInc();
            int n = 1;
            while (n <= tam)
            {
                DataGridViewColumn columna = new DataGridViewColumn(new DataGridViewTextBoxCell());
                columna.Width = 42;
                this.matrizInicial.Columns.Add(columna);
                DataGridViewColumn columna2 = new DataGridViewColumn(new DataGridViewTextBoxCell());
                columna2.Width = 42;
                this.matrizU.Columns.Add(columna2);
                DataGridViewColumn columna3 = new DataGridViewColumn(new DataGridViewTextBoxCell());
                columna3.Width = 42;
                this.matrizL.Columns.Add(columna3);
                n++;
            }

            matrizInicial.Rows.Add(tam);
            matrizU.Rows.Add(tam);
            matrizL.Rows.Add(tam);
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    matrizInicial[i, j].Value = matrizA[i, j];
                    matrizU[j, i].Value = matrizU1[i, j];
                    matrizL[i, j].Value = matrizL1[j, i];
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarMatriz();
            txtX.Text = Convert.ToString(incognita[0]);
            txtY.Text = Convert.ToString(incognita[1]);
            txtZ.Text = Convert.ToString(incognita[2]);
        }
    }
}
