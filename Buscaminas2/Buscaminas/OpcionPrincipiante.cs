using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas
{
    internal class OpcionPrincipiante : OpcionMenu
    {
        public override string Descripcion => "Principiante (8x8 con 10 minas)";

        public override bool Ejecutar()
        {
            Juego juego = new Juego(8, 8, 10);
            juego.Iniciar();
            return true;
        }
    }
}
