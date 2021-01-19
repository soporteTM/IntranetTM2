using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EmpleadoExperienciaEL
    {
        public int id_key { get; set; }
        public int cod_id { get; set; }
        public string cod_cargo_laboral { get; set; }
        public string des_cargo_laboral { get; set; }
        public string nom_empresa { get; set; }
        public string ubicacion { get; set; }
        public string mes_inicio { get; set; }
        public string anio_inicio { get; set; }
        public string mes_fin { get; set; }
        public string anio_fin { get; set; }
        public string observaciones { get; set; }
    }
}
