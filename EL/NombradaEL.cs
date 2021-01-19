using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class NombradaEL
    {
        public int cod_id { get; set; }
        public DateTime fecha { get; set; }
        public int id { get; set; }
        public int id_unidad { get; set; }
        public string cod_interno { get; set; }
        public string nro_placa { get; set; }
        public int id_conductor { get; set;}
        public string NombreCompleto { get; set; }
        public string nro_licencia { get; set; }
        public string observacion { get; set; }
        public string usuario { get; set; }
        public Boolean status_unidad { get; set; }
        public int cod_flota { get; set; }
        public string tipo { get; set; }
    }

    public class NombradaExportarEL
    {
        public int fila { get; set; }
        public string cod_interno { get; set; }
        public string nro_placa { get; set; }
        public string NombreCompleto { get; set; }
        public string nro_licencia { get; set; }
        public string observacion { get; set; }
        public string tipo { get; set; }
    }
}
