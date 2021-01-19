using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class SeguimientoEL
    {   
        public int id_nave { get; set; }
        public int id_seg { get; set; }
        public int id_cnt { get; set; }
        public int cod_unidad { get; set; }
        public int cod_conductor { get; set; }
        public DateTime fch_T1_llegada { get; set; }
        public DateTime fch_T2_ingreso { get; set; }
        public DateTime fch_T3_salida { get; set; }
        public DateTime fch_T4_llegada { get; set; }
        public DateTime fch_T5_ingreso { get; set; }
        public DateTime fch_T6_salida { get; set; }
        public string fch_T1_llegada2 { get; set; }
        public string fch_T2_ingreso2 { get; set; }
        public string fch_T3_salida2 { get; set; }
        public string fch_T4_llegada2 { get; set; }
        public string fch_T5_ingreso2 { get; set; }
        public string fch_T6_salida2 { get; set; }
        public int estado { get; set; }
        public string contenedor { get; set; }
        public string cod_interno { get; set; }
        public string nom_conductor { get; set; }
        public string nom_user { get; set; }

    }
}
