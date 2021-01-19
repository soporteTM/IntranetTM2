using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class TMS_SolicitudEL
    {





        //carga del ddlAnalista en la busqueda del AL
        public string Nombre { get; set; }
        public string Usu_Codi { get; set; }
        //carga del ddlTipoSolicitud en la busqueda del AL
        public int TS_Cod { get; set; }
        public string TS_Des { get; set; }
        //carga del ddlEmpresaAL en la busqueda del AL
        public string Ent_Codi { get; set; }
        public string Ent_Rsoc { get; set; }
        //carga del ddlEstadoAL en la busqueda del AL
        public string ros_estado { get; set; }
        public string ESTADO { get; set; }
        //carga del ddlMovimiento en la busqueda del AL
        public string ro_tmov { get; set; }
        public string Movimiento { get; set; }
    }
}
