using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica_01
{
    class Import
    {
        public string ID;
        public string Description;
        public string Elemeneto;

        public Import(string Id, string Descripcion, string Element)
        {
            this.ID = Id;
            this.Description = Descripcion;
            this.Elemeneto = Element;

        }
    }
}
