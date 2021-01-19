using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class SolicitudDstEL
    {
        public int cd_sol_id { get; set; }
        public int cd_sol { get; set; }
        public int or_viaje { get; set; }
        public DateTime fch_programada { get; set; }
        public int cd_cliente { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public string gr_transporte { get; set; }
        public string gr_sodimac { get; set; }
        public string cd_tipo_unidad { get; set; }
        public string picket_ticket { get; set; }
        public string contenedor { get; set; }
        public string observaciones { get; set; }
        public string cod_emp_creacion { get; set; }
        public string aud_usuario_creacion { get; set; }
        public string aud_usuario_modificacion { get; set; }
        public DateTime aud_fecha_creacion { get; set; }
        public DateTime aud_fecha_modificacion { get; set; }
    }
}
