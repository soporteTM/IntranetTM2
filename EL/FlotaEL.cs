using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class FlotaEL
    {
        public int cod_flota { get; set; }
        public string cod_interno { get; set; }
        public string nro_placa { get; set; }
        public string cod_tipo_vehiculo { get; set; }
        public string nom_tipo_vehiculo { get; set; }
        public string cod_marca { get; set; }
        public string nom_marca { get; set; }
        public string cod_modelo { get; set; }
        public string nom_modelo { get; set; }
        public string color_unidad { get; set; }
        public string cod_configuracion { get; set; }
        public string nom_configuracion { get; set; }
        public int anio_unidad { get; set; }
        public decimal cc_num { get; set; }
        public int nro_cilindro { get; set; }
        public string hp_rpm { get; set; }
        public string nro_motor { get; set; }
        public string nro_chasis { get; set; }
        public int nro_rueda { get; set; }
        public int nro_eje { get; set; }
        public decimal capacidad { get; set; }
        public string cod_operacion { get; set; }
        public string nom_operacion { get; set; }
        public string aud_usuario_creacion { get; set; }
        public string aud_usuario_modificacion { get; set; }
        public DateTime aud_fecha_creacion { get; set; }
        public DateTime aud_fecha_modificacion { get; set; }
        public Boolean aud_estado { get; set; }

    }
}
