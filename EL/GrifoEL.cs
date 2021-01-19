using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class GrifoEL
    {
        public int id_Estacion { get; set; }
        public string Estacion_nom { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public DateTime Fecha_Fin { get; set; }
        public string Fecha_Inicio2 { get; set; }
        public string Fecha_Fin2 { get; set; }
        public int estado { get; set; }
        public string aud_usuario_creacion { get; set; }
        public DateTime aud_fecha_creacion { get; set; }
        public string aud_usuario_modificacion { get; set; }
        public DateTime aud_fecha_modificacion { get; set; }
    }

    public class GrifoDetEL
    {
        public string nom_estacion { get; set; }
        public int id_consumo_estacion { get; set; }
        public int id_Estacion { get; set; }
        public int cod_cliente { get; set; }
        public DateTime fecha_registro { get; set; }
        public string fecha_registro2 { get; set; }
        public string nro_despacho { get; set; }
        public int id_abastecedor { get; set; }
        public string nom_conductor { get; set; }
        public string cod_unidad { get; set; }
        public string unidad { get; set; }
        public string nro_placa { get; set; }
        public decimal km_unidad { get; set; }
        public decimal horometro { get; set; }
        public decimal cantidad_gl { get; set; }
        public decimal precio_galon_igv { get; set; }
        public decimal total_venta { get; set; }
        public decimal precio_galon_no_igv { get; set; }
        public decimal total_venta_no_igv { get; set; }
        public int estado { get; set; }
        public string estado2 { get; set; }
        public string aud_usuario_creacion { get; set; }
        public DateTime aud_fecha_creacion { get; set; }
        public string aud_usuario_modificacion { get; set; }
        public DateTime aud_fecha_modificacion { get; set; }
        public string nom_empresa { get; set; }

        public string nom_abastecedor { get; set; }
        public string NDS { get; set; }
    }
}
