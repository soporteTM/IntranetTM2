using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EcoMenuEL
    {
        public int MEN_CODIGO { get; set; }
        public string MEN_DESCRIPCION{ get; set; }
        public string MEN_URL { get; set; }
        public int MEN_CODIGO_PADRE { get; set; }
        public int MEN_ORDEN { get; set; }
        public string MEN_ICONO { get; set; }

    }

    public class EcoPerfilEL
    {
        public string per_codigo { get; set; }
        public string per_descripcion { get; set; }
    }

}
