using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class CombustibleEL
    {
        public int id { get; set; }
        public string nom_estacion { get; set; }
        public string fecha_inicio { get; set; }
        public string fecha_corte { get; set; }
        public string fecha_registro { get; set; }
        public string usuario_registro { get; set; }
    }

    public class CombustibleCompraEL
    {
        public int id_PC { get; set; }
        public decimal precio_compra_cisterna { get; set; }
        public decimal precio_compra_grifo { get; set; }
        public string fecha_registro { get; set; }
        public int estado { get; set; }
        public string usuario { get; set; }
    }
}
