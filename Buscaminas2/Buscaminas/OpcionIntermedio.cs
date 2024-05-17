using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas
{
    internal class OpcionIntermedio : OpcionMenu
    {
        public override string Descripcion => "Intermedio (16x16 con 40 minas)";

        public override bool Ejecutar()
        {
            Juego juego = new Juego(16, 16, 40);
            juego.Iniciar();
            return true; 
        }
    }
}
