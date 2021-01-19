using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class ReposicionEL
    {

        public int cod_reposicion { get; set; }

        public string n_celular { get; set; }

        public string empleado { get; set; }

        public string tipo_emp { get; set; }

        public string motivo { get; set; }

        public string placa { get; set; }

        public string opcional_area { get; set; }


        public string opcional_motivo { get; set; }

        public string unidad { get; set; }

        public string area { get; set; }

        public DateTime fch_solicitud { get; set; }

        public DateTime fch_entrega { get; set; }

        public string plan_equipo { get; set; }

        public string nom_equipo { get; set; }

        public string usuario_registro { get; set; }
        
        public string usuario_modificacion { get; set; }

        public DateTime fch_modificacion { get; set; }

        public int estado { get; set; }

        public string obs { get; set; }


    }
}
