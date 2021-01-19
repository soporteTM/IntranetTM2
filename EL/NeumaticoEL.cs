using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class NeumaticoEL
    {
        public int id_nm { get; set; }
        public string nro_serie { get; set; }
        public string nro_placa { get; set; }
        public string nom_configuracion { get; set; }
        public string cod_marca { get; set; }
        public string nom_marca { get; set; }
        public string cod_modelo { get; set; }
        public string nom_modelo { get; set; }
        public decimal precio_costo { get; set; }
        public string medida { get; set; }
        public string tipo { get; set; }
        public int pos { get; set; }
        public decimal km_actual { get; set; }
        public int p_actual { get; set; }
        public int p_recomendado { get; set; }
        public int R1 { get; set; }
        public int R2 { get; set; }
        public int R3 { get; set; }
        public string estado_cd { get; set; }
        public string aud_usuario_creacion { get; set; }
        public DateTime aud_fecha_creacion { get; set; }
        public decimal km_recorrido { get; set; }
        public int reencauche { get; set; }
        public int cod_flota { get; set; }
        public string NrLlantas { get; set; }
        public string URL { get; set; }
        public string cod_interno { get; set; }
        public string DOT { get; set; }
        public string fecha_compra { get; set; }
        public string Proveedor { get; set; }
        public string diseño { get; set; }
        public string tipo_moneda { get; set; }

        public DateTime fecha { get; set; }
    }
}
