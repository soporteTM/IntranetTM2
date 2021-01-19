using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class SolicitudEL
    {
        public int cd_sol_id { get; set; }
        public int cd_sol { get; set; }
        public string cd_cliente { get; set; }
        public int cd_cliente2 { get; set; }
        public string nom_cliente { get; set; }
        public string cd_tipo_aduana { get; set; }
        public string cd_tipo_mov { get; set; }
        public string cd_tipo_via { get; set; }
        public string cd_tipo_incoterm { get; set; }
        public string cd_tipo_servicio { get; set; }
        public string cd_tipo_cond_emb { get; set; }
        public DateTime fch_emision { get; set; }
        public string fch_emision2 { get; set; }
        public int st_sol { get; set; }
        public string cd_alm_entrada { get; set; }
        public string direccion_entrada { get; set; }
        public string cd_alm_devolucion { get; set; }
        public string direccion_devolucion { get; set; }
        public string cd_tipo_solicitud { get; set; }
        public int cd_proveedor { get; set; }
        public string observaciones { get; set; }
        public string cd_emp_creacion { get; set; }
        public string aud_usuario_creacion { get; set; }
        public string aud_usuario_modificacion { get; set; }
        public DateTime aud_fecha_creacion { get; set; }
        public DateTime aud_fecha_modificacion { get; set; }
        public int cantidad {get;set;}
    }

    public class SolicitudDetalleContenedorEL
    {
        public int cod_det_cont_id { get; set; }
        public int cd_sol { get; set; }
        public int cd_item { get; set; }
        public int cantidad { get; set; }
        public string cd_tipo_contenedor { get; set; }
        public string tipoContenedor { get; set; }
        public string contenedor { get; set; }
        public int pies { get; set; }
        public string prefijo { get; set; }
        public string num_cnt { get; set; }
        public string st1_descarga { get; set; }
        public string st2_descarga { get; set; }
        public string carga_suelta { get; set; }
        public DateTime sol_det_fecha_cita{ get; set; }
        public string hora_cita{ get; set; }
        public string fecha_cita{ get; set; }
        public string sol_det_fecha { get; set; }
        public DateTime sol_det_hora_cita{ get; set; }
        public string aud_usuario_creacion { get; set; }
        public string aud_usuario_modificacion { get; set; }
        public DateTime aud_fecha_creacion { get; set; }
        public DateTime aud_fecha_modificacion { get; set; }
    }

    public class SolicitudDetalleEL
    {
        public int cd_sol_det_id { get; set; }
        public int cd_sol { get; set; }
        public int cd_item { get; set; }
        public int cantidad { get; set; }
        public string cd_tipo_bulto { get; set; }
        public string cd_tipo_contenedor { get; set; }
        public int pies { get; set; }
        public string observaciones { get; set; }
        public string aud_usuario_creacion { get; set; }
        public string aud_usuario_modificacion { get; set; }
        public DateTime aud_fecha_creacion { get; set; }
        public DateTime aud_fecha_modificacion { get; set; }
    }

}
