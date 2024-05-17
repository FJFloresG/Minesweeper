using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas
{
    internal class Buscaminas
    {
        private Tablero tablero;
        private DateTime tiempoInicio;

        public Buscaminas(int filas, int columnas, int minas)
        {
            tablero = new Tablero(filas, columnas, minas);
            tablero.Inicializar();
        }

        public void Jugar()
        {
            tiempoInicio = DateTime.Now;

            while (true)
            {
                tablero.Mostrar();
                Console.WriteLine("Tiempo transcurrido: " + (DateTime.Now - tiempoInicio));
                Console.WriteLine("Seleccione una acción:");
                Console.WriteLine("1. Descubrir casilla");
                Console.WriteLine("2. Colocar/Quitar bandera");
                Console.WriteLine("3. Reiniciar juego");
                Console.WriteLine("4. Volver al menú principal");

                int opcion;
                if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > 4)
                {
                    Console.WriteLine("Opción inválida. Inténtelo de nuevo.");
                    continue;
                }

                if (opcion == 3)
                {
                    tablero.Inicializar();
                    tiempoInicio = DateTime.Now;
                    Console.Clear();
                    continue;
                }

                if (opcion == 4)
                {
                    return; 
                }

                Console.WriteLine("Ingrese fila y columna (por ejemplo, 1 2): ");
                string[] entrada = Console.ReadLine().Split();
                int fila, columna;

                if (entrada.Length != 2 || !int.TryParse(entrada[0], out fila) || !int.TryParse(entrada[1], out columna))
                {
                    Console.WriteLine("Entrada inválida. Asegúrese de ingresar dos números separados por un espacio.");
                    continue;
                }

                fila--; 
                columna--; 

                if (fila < 0 || fila >= tablero.Filas || columna < 0 || columna >= tablero.Columnas)
                {
                    Console.WriteLine("Entrada fuera de rango. Inténtelo de nuevo.");
                    continue;
                }

                if (opcion == 1)
                {
                    tablero.DescubrirCasilla(fila, columna);
                    if (tablero.TodasLasCeldasDescubiertas())
                    {
                        tablero.Mostrar();
                        Console.WriteLine("¡Felicidades! ¡Ha ganado!");
                        break;
                    }
                }
                else if (opcion == 2)
                {
                    tablero.ColocarQuitarBandera(fila, columna);
                }

                Console.Clear(); 
            }
        }
    }
}
