using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class NaveEL
    {
        public int id { get; set; }
        public string anio_manifiesto { get; set; }
        public string nro_manifiesto { get; set; }
        public string puerto { get; set; }
        public DateTime fecha_registro { get; set; }
        public DateTime fecha_termino { get; set; }
        public string nave { get; set; }
        public string transporte { get; set; }
        public string finalizado { get; set; }
        public DateTime fecha_finalizado { get; set; }
        public string operacion { get; set; }
        public string user_registro { get; set; }
        public int pendiente { get; set; }
        public int avance { get; set; }
        public int fila { get; set; }
    }

    public class NaveExportarEL
    {
        public int fila { get; set; }
        public string nave { get; set; }
        public string puerto { get; set; }
        public DateTime fecha_registro { get; set; }
        public DateTime fecha_termino { get; set; }
        public string nro_manifiesto { get; set; }
        public string operacion { get; set; }
        public string estado { get; set; }

    }
}
