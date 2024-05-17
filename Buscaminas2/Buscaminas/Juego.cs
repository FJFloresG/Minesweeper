using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas
{
    internal class Juego
    {
        private int filas;
        private int columnas;
        private int minas;
        private Buscaminas buscaminas;

        public Juego(int filas, int columnas, int minas)
        {
            this.filas = filas;
            this.columnas = columnas;
            this.minas = minas;
            this.buscaminas = new Buscaminas(filas, columnas, minas);
        }

        public void Iniciar()
        {
            buscaminas.Jugar();
        }
    }
}
