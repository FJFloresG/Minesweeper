using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas
{
    internal class VisualizadorTablero
    {
        private int filas;
        private int columnas;
        private Celda[,] celdas;

        public VisualizadorTablero(int filas, int columnas, Celda[,] celdas)
        {
            this.filas = filas;
            this.columnas = columnas;
            this.celdas = celdas;
        }

        public void Mostrar()
        {
            Console.WriteLine("  " + string.Join(" ", GetColumnHeaders()));
            for (int i = 0; i < filas; i++)
            {
                Console.Write((i + 1) + " ");
                for (int j = 0; j < columnas; j++)
                {
                    if (celdas[i, j].TieneBandera)
                    {
                        Console.Write("F ");
                    }
                    else
                    {
                        Console.Write(celdas[i, j].Contenido + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        private string[] GetColumnHeaders()
        {
            string[] headers = new string[columnas];
            for (int i = 0; i < columnas; i++)
            {
                headers[i] = (i + 1).ToString();
            }
            return headers;
        }

        public void MostrarMinas()
        {
            for (int i = 0; i < filas; i++)
            {
                for (int j = 0; j < columnas; j++)
                {
                    if (celdas[i, j].EsMina)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
