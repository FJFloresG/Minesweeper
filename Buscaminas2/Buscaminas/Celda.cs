using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas
{
    internal class Celda
    {
        public bool EsMina { get; set; }
        public bool EstaDescubierta { get; set; }
        public bool TieneBandera { get; set; }
        public char Contenido { get; set; }

        public Celda()
        {
            EsMina = false;
            EstaDescubierta = false;
            TieneBandera = false;
            Contenido = '-';
        }
    }
}
