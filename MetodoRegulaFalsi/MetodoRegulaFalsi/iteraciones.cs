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
        public double a { get; set; }
        public double b { get; set; }
        public double fa { get; set; }
        public double fb { get; set; }
        public double xr { get; set; }
        public double fxr { get; set; }
        public double faFxr { get; set; }
        public double error { get; set; }

        public iteraciones() { }

        public iteraciones(int i, double a, double b, double xr, double fa, double fb, double fxr, double faFxr)
        {
            this.i = i;
            this.a = a;
            this.b = b;
            this.xr = xr;
            this.fa = fa;
            this.fb = fb;
            this.fxr = fxr;
            this.faFxr = faFxr;
        }

        public iteraciones(int i, double a, double b, double xr, double fa, double fb, double fxr, double faFxr, double error)
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
        }

    }
}
