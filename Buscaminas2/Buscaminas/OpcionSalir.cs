using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas
{
    internal class OpcionSalir : OpcionMenu
    {
        public override string Descripcion => "Salir";

        public override bool Ejecutar()
        {
            return false; 
        }
    }
}
