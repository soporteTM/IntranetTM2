using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class TarifaEL
    {
        public int id_cliente { get; set; }
        public string nom_empresa { get; set; }
        public decimal precio_tarifa_igv { get; set; }
        public decimal precio_tarifa_no_igv { get; set; }
    }
}
