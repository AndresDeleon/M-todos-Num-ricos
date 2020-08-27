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
        public double xI { get; set; }
        public double xGxI { get; set; }
        public double error { get; set; }

        public iteraciones() { }

        public iteraciones(int i, double xI, double xGxI)
        {
            this.i = i;
            this.xI = xI;
            this.xGxI = xGxI;

        }

        public iteraciones(int i, double xI, double xGxI, double error)
        {
            this.i = i;
            this.xI = xI;
            this.xGxI = xGxI;
            this.error = error;
        }

    }
}
