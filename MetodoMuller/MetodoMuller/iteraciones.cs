using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodoMuller
{
    class iteraciones
    {

        public int i { get; set; }
        public double x0 { get; set; }
        public double x1 { get; set; }
        public double x2 { get; set; }
        public double fx0 { get; set; }
        public double fx1 { get; set; }
        public double fx2 { get; set; }
        public double h0 { get; set; }
        public double h1 { get; set; }
        public double d0 { get; set; }
        public double d1 { get; set; }
        public double a { get; set; }
        public double b { get; set; }
        public double c { get; set; }
        public double x3 { get; set; }
        public double error { get; set; }

        public iteraciones() { }

        public iteraciones(int i, double x0, double x1, double x2, double fx0, double fx1, double fx2, double h0, double h1, double d0, double d1, double a, double b, double c, double x3)
        {
            this.i = i;
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.fx0 = fx0;
            this.fx1 = fx1;
            this.fx2 = fx2;
            this.h0 = h0;
            this.h1 = h1;
            this.d0 = d0;
            this.d1 = d1;
            this.a = a;
            this.b = b;
            this.c = c;
            this.x3 = x3;
        }

        public iteraciones(int i, double x0, double x1, double x2, double fx0, double fx1, double fx2, double h0, double h1, double d0, double d1, double a, double b, double c, double x3, double error)
        {
            this.i = i;
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.fx0 = fx0;
            this.fx1 = fx1;
            this.fx2 = fx2;
            this.h0 = h0;
            this.h1 = h1;
            this.d0 = d0;
            this.d1 = d1;
            this.a = a;
            this.b = b;
            this.c = c;
            this.x3 = x3;
            this.error = error;
        }

    }
}
