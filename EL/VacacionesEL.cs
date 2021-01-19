using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class VacacionesEL
    {
        
    }

    public class VacacionesSolicitudEL
    {
        public int id_solicitud { get; set; }
        public int id_empleado { get; set; }
        public int id_solicitante { get; set; }
        public string nom_solicitante { get; set; }
        public string nom_empleado { get; set; }
        public string fch_inicio { get; set; }
        public string fch_registro { get; set; }
        public DateTime fch_inicio2 { get; set; }
        public string fch_fin { get; set; }
        public DateTime fch_fin2 { get; set; }
        public int total_dias { get; set; }
        public string observaciones { get; set; }
        public string estado { get; set; }
    }

    public class VacacionesAprobacionEL
    {
        public int id_aprobacion { get; set; }
        public int id_solicitud { get; set; }
        public int id_evaluador { get; set; }
        public string nombre { get; set; }
        public string fch_respuesta { get; set; }
        public string estado { get; set; }
    }

    public class VacacionesPendientesEL
    {
        public int fila { get; set; }
        public int id_aprobacion { get; set; }
        public int id_solicitud { get; set; }
        public int id_evaluador { get; set; }
        public int id_empleado { get; set; }
        public int id_solicitante { get; set; }
        public string nom_solicitante { get; set; }
        public string nom_empleado { get; set; }
        public string nombre { get; set; }
        public string fch_inicio { get; set; }
        public string fch_fin { get; set; }
        public int total_dias { get; set; }
        public string fch_ingreso { get; set; }
        public string dpto_laboral { get; set; }
        public string estado { get; set; }
    }

    public class VacacionesReporteEL
    {
        public int cod_id { get; set; }
        public string dni { get; set; }
        public string nombre { get; set; }
        public string fchIngreso { get; set; }
        public int diasTomados { get; set; }
        public int diasPendientes{ get; set; }
        public int diasTruncos { get; set; }
        public int diasVencidos { get; set; }
        public int total { get; set; }
    }

    public class VacacionesEmailEL
    {
        public string evaluador { get; set; }
        public string Empleado { get; set; }
        public string fch_registro { get; set; }
        public string observaciones { get; set; }
        public string nom_user { get; set; }
    }


}
