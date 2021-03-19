using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenTemperaturasG
{
    class REGISTRO
    {
        DateTime fecha;
        string codigo;

        public DateTime FechaT { get => fecha; set => fecha = value; }
        public string Codigo { get => codigo; set => codigo = value; }

    }
}
