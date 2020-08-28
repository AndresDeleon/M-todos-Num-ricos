using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodoSecante
{
    class iteraciones
    {

        public int i { get; set; }
        public double xI { get; set; }
        public double fxI { get; set; }
        public double fxIm1 { get; set; }
        public double xImxIm1 { get; set; }
        public double error { get; set; }

        public iteraciones() { }

        public iteraciones(int i, double xI)
        {
            this.i = i;
            this.xI = xI;
        }

        public iteraciones(int i, double xI, double fxI, double fxIm1, double xImxIm1)
        {
            this.i = i;
            this.xI = xI;
            this.fxI = fxI;
            this.fxIm1 = fxIm1;
            this.xImxIm1 = xImxIm1;
        }

        public iteraciones(int i, double xI, double fxI, double fxIm1, double xImxIm1, double error)
        {
            this.i = i;
            this.xI = xI;
            this.fxI = fxI;
            this.fxIm1 = fxIm1;
            this.xImxIm1 = xImxIm1;
            this.error = error;
        }

    }
}
