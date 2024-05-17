using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas
{
    internal class OpcionExperto : OpcionMenu
    {
        public override string Descripcion => "Experto (16x30 con 99 minas)";

        public override bool Ejecutar()
        {
            Juego juego = new Juego(16, 30, 99);
            juego.Iniciar();
            return true;
        }
    }
}
