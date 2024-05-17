using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buscaminas
{
    internal abstract class OpcionMenu
    {
        public abstract string Descripcion { get; }
        public abstract bool Ejecutar();
    }
}
