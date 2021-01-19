using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class DocumentacionEL
    {
        public int cod_doc { get; set; }
        public int cod_flota { get; set; }
        public string cod_documentacion { get; set; }
        public string nom_documentacion { get; set; }
        public string fch_emision { get; set; }
        public string fch_vencimiento { get; set; }
        public string aud_usuario_creacion { get; set; }

        public string path_doc { get; set; }
    }
}
