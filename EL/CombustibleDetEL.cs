using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class CombustibleDetEL
    {
        public int id_detalle { get; set; }
        public int id_cabecera { get; set; }
        public string nro_placa { get; set; }
        public string nom_cliente { get; set; }
    	public string c_costo { get; set; }
        public string cod_eess { get; set; }
        public string nom_eess { get; set; }
        public string fch_documento { get; set; }
        public string num_documento { get; set; }
        public decimal cantidad { get; set; }
        public decimal precio_sin_igv { get; set; }
        public decimal precio_con_igv { get; set; }
        public decimal monto_sin_igv { get; set; }
        public decimal monto_con_igv { get; set; }
        public string Kilometraje { get; set; }

    }
}
