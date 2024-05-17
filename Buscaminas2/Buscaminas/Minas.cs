using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas
{
    internal class Minas
    {
        private bool[,] minasCuadricula;
        private int filas;
        private int columnas;
        private int totalMinas;
        private Celda[,] celdas;

        public Minas(int filas, int columnas, int totalMinas, Celda[,] celdas)
        {
            this.filas = filas;
            this.columnas = columnas;
            this.totalMinas = totalMinas;
            this.celdas = celdas;
            ColocarMinas();
        }

        private void ColocarMinas()
        {
            Random random = new Random();
            int minasColocadas = 0;
            while (minasColocadas < totalMinas)
            {
                int fila = random.Next(filas);
                int columna = random.Next(columnas);
                if (!celdas[fila, columna].EsMina)
                {
                    celdas[fila, columna].EsMina = true;
                    minasColocadas++;
                }
            }
        }

        public bool EstaMinada(int fila, int columna)
        {
            return celdas[fila, columna].EsMina;
        }

        public int ContarMinasCercanas(int fila, int columna)
        {
            int minasCercanas = 0;
            for (int i = Math.Max(0, fila - 1); i <= Math.Min(filas - 1, fila + 1); i++)
            {
                for (int j = Math.Max(0, columna - 1); j <= Math.Min(columnas - 1, columna + 1); j++)
                {
                    if (celdas[i, j].EsMina)
                    {
                        minasCercanas++;
                    }
                }
            }
            return minasCercanas;
        }
    }
}

