using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptimizacionNewton
{
    class iteraciones
    {

        public int i { get; set; }
        public double x { get; set; }
        public double fx { get; set; }
        public double fdx { get; set; }
        public double fddx { get; set; }

        public iteraciones() { }

        public iteraciones(int i, double x, double fx, double fdx, double fddx)
        {
            this.i = i;
            this.x = x;
            this.fx = fx;
            this.fdx = fdx;
            this.fddx = fddx;
        }

    }
}
