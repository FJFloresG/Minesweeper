using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas
{
    internal class Tablero
    {
        public int Filas { get; private set; }
        public int Columnas { get; private set; }
        private int minas;
        private Celda[,] celdas;
        private Minas gestorMinas;
        private VisualizadorTablero visualizador;

        public Tablero(int filas, int columnas, int minas)
        {
            Filas = filas;
            Columnas = columnas;
            this.minas = minas;
            Inicializar();
        }

        public void Inicializar()
        {
            celdas = new Celda[Filas, Columnas];
            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < Columnas; j++)
                {
                    celdas[i, j] = new Celda();
                }
            }

            gestorMinas = new Minas(Filas, Columnas, minas, celdas);
            visualizador = new VisualizadorTablero(Filas, Columnas, celdas);
        }

        public void Mostrar()
        {
            visualizador.Mostrar();
        }

        public void DescubrirCasilla(int fila, int columna)
        {
            if (celdas[fila, columna].TieneBandera)
            {
                Console.WriteLine("Retirando bandera antes de descubrir la casilla.");
                celdas[fila, columna].TieneBandera = false; // Retirar la bandera
            }

            if (celdas[fila, columna].EsMina)
            {
                Console.WriteLine("¡Game Over! ¡Ha tocado una mina!");
                visualizador.MostrarMinas();
                Environment.Exit(0);
            }
            else
            {
                int minasCercanas = gestorMinas.ContarMinasCercanas(fila, columna);
                celdas[fila, columna].Contenido = minasCercanas.ToString()[0]; 
                celdas[fila, columna].EstaDescubierta = true;

                /*if (minasCercanas == 0)
                {
                    DescubrirCeldasAdyacentes(fila, columna);
                }*/
            }
        }

        /*private void DescubrirCeldasAdyacentes(int fila, int columna)
        {
            for (int i = Math.Max(0, fila - 1); i <= Math.Min(Filas - 1, fila + 1); i++)
            {
                for (int j = Math.Max(0, columna - 1); j <= Math.Min(Columnas - 1, columna + 1); j++)
                {
                    if (!celdas[i, j].EstaDescubierta && celdas[i, j].Contenido == '-')
                    {
                        DescubrirCasilla(i, j);
                    }
                }
            }
        }*/

        public void ColocarQuitarBandera(int fila, int columna)
        {
            if (celdas[fila, columna].Contenido != '-')
            {
                Console.WriteLine("No se puede colocar una bandera en una casilla ya descubierta.");
                return;
            }

            celdas[fila, columna].TieneBandera = !celdas[fila, columna].TieneBandera; // Alternar bandera
        }

        public bool TodasLasCeldasDescubiertas()
        {
            for (int i = 0; i < Filas; i++)
            {
                for (int j = 0; j < Columnas; j++)
                {
                    if (!celdas[i, j].EsMina && !celdas[i, j].EstaDescubierta)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
