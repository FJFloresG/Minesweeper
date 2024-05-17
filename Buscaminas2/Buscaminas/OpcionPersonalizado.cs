using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas
{
    internal class OpcionPersonalizado : OpcionMenu
    {
        public override string Descripcion => "Personalizado";

        public override bool Ejecutar()
        {
            int filas = SolicitarDimension("filas");
            int columnas = SolicitarDimension("columnas");
            int minas = SolicitarMinas(filas, columnas);

            Juego juego = new Juego(filas, columnas, minas);
            juego.Iniciar();
            return true;
        }

        private int SolicitarDimension(string dimension)
        {
            int valor;
            while (true)
            {
                Console.Write($"Ingrese el número de {dimension} del tablero (mínimo 4): ");
                if (!int.TryParse(Console.ReadLine(), out valor) || valor < 4)
                {
                    Console.WriteLine($"El número de {dimension} debe ser al menos 4 y un número válido. Inténtelo de nuevo.");
                }
                else
                {
                    break;
                }
            }
            return valor;
        }

        private int SolicitarMinas(int filas, int columnas)
        {
            int minas;
            while (true)
            {
                Console.Write("Ingrese el número de minas (mínimo 3): ");
                if (!int.TryParse(Console.ReadLine(), out minas) || minas < 3 || minas >= filas * columnas)
                {
                    Console.WriteLine($"El número de minas debe ser al menos 3 y menos de {filas * columnas}. Inténtelo de nuevo.");
                }
                else
                {
                    break;
                }
            }
            return minas;
        }
    }
}
