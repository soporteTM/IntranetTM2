using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class ContenedorEL
    {
        //Contenedores de embarque
        public int id_seg { get; set; }
        public int id_cnt { get; set; }
        public int id { get; set; }
        public string contenedor { get; set; }
        public string tipo { get; set; }
        public string vacio { get; set; }
        public string nom_conductor { get; set; }
        public string cod_interno { get; set; }
        public string nro_placa { get; set; }
        public int estado { get; set; }
        
        //Contenedores de descarga
        public string CONTENEDOR { get; set; }
        public string TIPO_CTN { get; set; }
    }

    public class ContenedorExportaEL
    {
        public string nave { get; set; }
        public string operacion { get; set; }
        public string puerto { get; set; }
        public string contenedor { get; set; }
        public string tipo { get; set; }
        public string vacio { get; set; }
        public string nom_conductor { get; set; }
        public string cod_interno { get; set; }
        public string nro_placa { get; set; }
        public string transporte { get; set; }
        public string estado { get; set; }
        public string fch_T1_llegada { get; set; }
        public string fch_T2_ingreso { get; set; }
        public string fch_T3_salida { get; set; }
        public string fch_T4_llegada { get; set; }
        public string fch_T5_ingreso { get; set; }
        public string fch_T6_salida { get; set; }
    }
}
