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
        public double[,] matriz = new double[tam,tam];
        public double[,] matrizTemp = new double[tam, tam];
        public double[,] matrizDet = new double[(tam + 2), tam];
        public double detM, detX, detY, detZ, x, y, z;
        public double[] constante = new double[] { 2, -3, 5 };


        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public double calcInc(double inc)
        {
            return inc / detM;
        }

        public double calMatrizInc(int n)
        {
            int c = 0;
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    if (j == n)
                    {
                        matrizTemp[i, j] = constante[c];
                        c++;
                    }
                    else
                    {
                        matrizTemp[i, j] = matriz[i, j];
                    }
                }
            }
            return determinante(calcDet(matrizTemp));
        }

        public double[,] calcDet(double[,] m)
        {
            double[,] md = new double[tam + 2, tam];
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    md[i, j] = m[i, j];
                }
            }
            int n = 0;
            for (int i = 3; i < (tam + 2); i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    md[i, j] = m[n, j];
                }
                n++;
            }
            return md;
        }

        public void proceso()
        {
            matrizDet = calcDet(matriz);
            detM = determinante(matrizDet);
            detX = calMatrizInc(0);
            detY = calMatrizInc(1);
            detZ = calMatrizInc(2);
            x = calcInc(detX);
            y = calcInc(detY);
            z = calcInc(detZ);
        }

        public double determinante(double[,] det)
        {
            double determinante, diagonal1, diagonal2, p1 = 0, p2 = 0;
            int f, c,s=0;
            for (int k = 0; k < 3; k++)
            {
                f = 0 + s;
                c = 0;
                diagonal1 = 1;
                for (int i = 0; i < (tam + 2); i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        if (i == f && j == c)
                        {
                            diagonal1 *= det[f, j];
                            f++;
                            c++;
                        }
                    }
                }
                p1 = p1 + diagonal1;
                s++;
            }
            
            s = 0;
            for (int k = 0; k < 3; k++)
            {
                f = 0 + s;
                c = (tam - 1);
                diagonal2 = 1;
                for (int i = 0; i < (tam + 2); i++)
                {
                    for (int j = 0; j < tam ; j++)
                    {
                        if (i == f && j == c)
                        {
                            diagonal2 *=  det[f, j];
                            f++;
                            c--;
                        }
                    }
                }
                p2 = p2 + diagonal2;
                s++;
            }
            

            determinante = p1 - p2;
            return determinante;
        }

        public void cargarMatriz()
        {
            matrizInicial.Columns.Clear();
            matriz[0, 0] = 2;
            matriz[0, 1] = -1;
            matriz[0, 2] = 5;
            matriz[1, 0] = 3;
            matriz[1, 1] = -2;
            matriz[1, 2] = 1;
            matriz[2, 0] = -2;
            matriz[2, 1] = 2;
            matriz[2, 2] = 3;
            proceso();
            int n = 1;
            while (n <= tam)
            {
                DataGridViewColumn columna = new DataGridViewColumn(new DataGridViewTextBoxCell());
                columna.Width = 42;
                this.matrizInicial.Columns.Add(columna);
                n++;
            }

            matrizInicial.Rows.Add(tam);
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    matrizInicial[i, j].Value = matriz[i, j];
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarMatriz();
            txtX.Text = Convert.ToString(x);
            txtY.Text = Convert.ToString(y);
            txtZ.Text = Convert.ToString(z);
        }
    }
}
