using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodoRegulaFalsi
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
        public double x3 { get; set; }
        public double fx3 { get; set; }

        public iteraciones() { }

        public iteraciones(int i, double x0, double x1, double x2, double fx0, double fx1, double fx2, double x3, double fx3)
        {
            this.i = i;
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.fx0 = fx0;
            this.fx1 = fx1;
            this.fx2 = fx2;
            this.x3 = x3;
            this.fx3 = fx3;
        }

        /*public iteraciones(int i, double a, double b, double xr, double fa, double fb, double fxr, double faFxr, double error)
        {
            this.i = i;
            this.a = a;
            this.b = b;
            this.xr = xr;
            this.fb = fb;
            this.fa = fa;
            this.fxr = fxr;
            this.faFxr = faFxr;
            this.error = error;
        }*/

    }
}
