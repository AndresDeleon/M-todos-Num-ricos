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
        public double[,] matrizI = new double[tam,tam];
        public double[,] matrizC = new double[tam, tam];
        public double[,] matrizA = new double[tam, tam];

        public Form1()
        {
            InitializeComponent();
            CenterToScreen();
        }

        public void matrizCofactor()
        {
            int f = 0, c = 0, fD, cD;
            for (int k = 0; k < (tam*tam); k++)
            {
                fD = 0;
                cD = 0;
                double[,] det = new double[(tam - 1), (tam - 1)];
                for (int i = 0; i < tam; i++)
                {
                    for (int j = 0; j < tam; j++)
                    {
                        if (i != f && j != c)
                        {
                            det[fD, cD] = matrizI[i, j];
                            cD++;

                            if (cD == (tam-1))
                            {
                                cD = 0;
                                if ((fD + 1) != (tam - 1))
                                {
                                    fD++;
                                }
                            }
                        }
                    }
                }
                if (((f + 1)+(c + 1)) % 2 == 0)
                {
                    matrizC[f, c] = determinante(det);

                }
                else
                {
                    matrizC[f, c] = (-1) * determinante(det);
                }

                c++;
                if (c == tam)
                {
                    c = 0;
                    f++;
                }
            }
            
        }

        public double determinante(double[,] det)
        {
            double determinante, diagonal1 = 1, diagonal2 = 1;
            int f=0, c=0;
            for (int i = 0; i < (tam-1); i++)
            {
                for (int j = 0; j < (tam-1); j++)
                {
                    if (i == f && j == c)
                    {
                        diagonal1 = diagonal1 * det[i, j];
                        f++;
                        c++;
                    }
                    
                }
            }
            f = 0;
            c = (tam - 1) - 1;
            for (int i = 0; i < (tam - 1); i++)
            {
                for (int j = 0; j < (tam - 1); j++)
                {
                    if (i == f && j == c)
                    {
                        diagonal2 = diagonal2 * det[i, j];
                        f++;
                        c--;
                    }
                }
            }

            determinante = diagonal1 - diagonal2;
            return determinante;
        }

        public void cargarMatrizAdjunta()
        {
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    matrizA[j, i] = matrizC[i, j];
                }
            }
        }

        public void cargarMatriz()
        {
            matrizInicial.Columns.Clear();
            matrizAdjunta.Columns.Clear();
            matrizI[0, 0] = 1;
            matrizI[0, 1] = 0;
            matrizI[0, 2] = -2;
            matrizI[1, 0] = 3;
            matrizI[1, 1] = 1;
            matrizI[1, 2] = 2;
            matrizI[2, 0] = 0;
            matrizI[2, 1] = -1;
            matrizI[2, 2] = -4;
            matrizCofactor();
            cargarMatrizAdjunta();
            int n = 1;
            while (n <= tam)
            {
                DataGridViewColumn columna = new DataGridViewColumn(new DataGridViewTextBoxCell());
                columna.Width = 42;
                this.matrizInicial.Columns.Add(columna);
                DataGridViewColumn columna2 = new DataGridViewColumn(new DataGridViewTextBoxCell());
                columna2.Width = 42;
                this.matrizAdjunta.Columns.Add(columna2);
                n++;
            }

            matrizInicial.Rows.Add(tam);
            matrizAdjunta.Rows.Add(tam);
            for (int i = 0; i < tam; i++)
            {
                for (int j = 0; j < tam; j++)
                {
                    matrizInicial[i, j].Value = matrizI[i, j];
                    matrizAdjunta[j, i].Value = matrizA[i, j];
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarMatriz();
        }
    }
}
