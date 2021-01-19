using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EmpleadoFormacionEL
    {
        public int id_key { get; set; } 
        public int cod_id { get; set; }
        public string cod_grado_instruccion { get; set; }
        public string opcional_instruccion { get; set; }
        public string cod_institucion { get; set; }
        public string opcional_institucion { get; set; }
        public string titulo { get; set; }
        public string anio_inicio { get; set; }
        public string anio_fin { get; set; }
        public string observaciones { get; set; }
    }
}
