using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class CisternaEL
    {
        public int fila { get; set; }
        public int id_cisterna { get;  set; }
        public string cod_cisterna { get; set; }
        public decimal cantidad_gl { get; set; }
        public decimal cantidad_rm_gl { get; set; }
        public decimal consumo_gl { get; set; }
        public decimal saldo_gl { get; set; }
        public decimal precio_compra { get; set; }
        public decimal subtotal { get; set; }
        public decimal total { get; set; }
        public string fecha_registro { get; set; }
        public string fecha_vencimiento { get; set; }
        public string nro_factura { get; set; }
        public string numero_scop { get; set; }
        public string estado { get; set; }
        
    }
}
