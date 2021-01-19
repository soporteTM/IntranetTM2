using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EmpleadoIdiomaEL
    {
        public int id_key { get; set; }

        public int cod_id { get; set; }
        public string cod_idioma { get; set; }
        public string opcional_idioma { get; set; }

        public string cod_nivel { get; set; }
        public string opcional_nivel { get; set; }
        public string institucion { get; set; }
        public string n_habla { get; set; }
        public string n_lee { get; set; }
        public string n_escritura { get; set; }

        public string opcional_escritura { get; set; }
        public string opcional_lee { get; set; }
        public string opcional_habla { get; set; }
    }
}
