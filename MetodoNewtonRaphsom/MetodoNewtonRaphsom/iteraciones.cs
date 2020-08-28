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
        public double xIm1{ get; set; }
        public double fxIm1 { get; set; }
        public double fdxIm1 { get; set; }
        public double xI { get; set; }
        public double error { get; set; }

        public iteraciones() { }

        public iteraciones(int i, double xIm1, double fxIm1, double fdxIm1, double xI)
        {
            this.i = i;
            this.xIm1 = xIm1;
            this.fxIm1 = fxIm1;
            this.fdxIm1 = fdxIm1;
            this.xI = xI;
        }

        public iteraciones(int i, double xIm1, double fxIm1, double fdxIm1, double xI, double error)
        {
            this.i = i;
            this.xIm1 = xIm1;
            this.fxIm1 = fxIm1;
            this.fdxIm1 = fdxIm1;
            this.xI = xI;
            this.error = error;
        }

    }
}
