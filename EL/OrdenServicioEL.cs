using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class OrdenServicioEL
    {
        public int id_servicio { get; set; }
        public int id_orden { get; set; }
        public string cod_servicio { get; set; }
        public string nom_servicio { get; set; }
        public decimal costo { get; set; }
        public string obs { get; set; }
    }
}
