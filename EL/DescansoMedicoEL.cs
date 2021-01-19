using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class DescansoMedicoEL
    {

        public int fila { get; set; }
        public int id { get; set; }
        public int id_emp { get; set; }
        public string diasInicio_des { get; set; }
        public string diasFin_des { get; set; }
        public int diasTotal_des { get; set; }
        public string cod_motivo { get; set; }
        public string desc_motivo { get; set; }
        public string observacion_des { get; set; }
        public string cod_clinica { get; set; }
        public string desc_clinica { get; set; }
        public string documentacion_des { get; set; }
        public string estadoDM { get; set; }
        public DateTime fecha { get; set; }  //AGREGADO POR RODRIGO ROJAS

    }
}
