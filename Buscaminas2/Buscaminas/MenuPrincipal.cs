using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas
{
    internal class MenuPrincipal
    {
        private List<OpcionMenu> opciones;

        public MenuPrincipal()
        {
            opciones = new List<OpcionMenu>
        {
            new OpcionPrincipiante(),
            new OpcionIntermedio(),
            new OpcionExperto(),
            new OpcionPersonalizado(),
            new OpcionSalir()
        };
        }

        public void Mostrar()
        {
            while (true)
            {
                if (!MostrarMenuPrincipal())
                    break; 
            }
        }

        private bool MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Bienvenido al juego Buscaminas!");

            Console.WriteLine("Seleccione el nivel de dificultad:");
            for (int i = 0; i < opciones.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {opciones[i].Descripcion}");
            }

            int opcion;
            if (!int.TryParse(Console.ReadLine(), out opcion) || opcion < 1 || opcion > opciones.Count)
            {
                Console.WriteLine("Opción inválida. Inténtelo de nuevo.");
                return true; 
            }

            return opciones[opcion - 1].Ejecutar();
        }
    }
}
