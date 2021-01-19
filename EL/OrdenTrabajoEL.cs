using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class OrdenTrabajoEL
    {
        public int id_orden { get; set; }
        public string nro_orden { get; set; }
        public string cod_proveedor { get; set; }
        public string nom_proveedor { get; set; }
        public DateTime fch_emision { get; set; }
        public DateTime hora_inicio { get; set; }
        public DateTime hora_fin { get; set; }
        public int cod_flota { get; set; }
        public string nro_placa { get; set; }
        public decimal km_flota { get; set; }
        public int cod_conductor { get; set; }
        public string cod_tipo_servicio { get; set; }
        public string nom_tipo_servicio { get; set; }
        public string cod_mantenimiento { get; set; }
        public string nom_mantenimiento { get; set; }
        public string cod_taller { get; set; }
        public string nom_taller { get; set; }
        public decimal horometro_flota { get; set; }
        public decimal total_servicio { get; set; }
        public string aud_usuario_creacion { get; set; }        
        public int estado { get; set; }
        public string estado_cd { get; set; }
    }
}
