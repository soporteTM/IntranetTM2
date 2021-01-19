using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EstadisticaEL
    {
        public string nave { get; set; }
        public int total { get; set; }
        public int TotalAvance { get; set; }
        public int TotalPropio { get; set; }
    }

    public class EtdPuertoEL
    {
        public string puerto { get; set; }
        public int TotalAvance { get; set; }
        public int TotalPropio { get; set; }
        public int TotalAlquiler { get; set; }
    }

    public class EtdGeneralEL
    {
        public string tipo_operacion { get; set; }
        public int TotalAvance { get; set; }
        public int TotalPropio { get; set; }
    }
}
