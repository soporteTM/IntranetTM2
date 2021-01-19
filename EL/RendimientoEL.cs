using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class RendimientoEL
    {
        public int id_nm { get; set; }
        public string nro_serie { get; set; }
        public decimal precio_costo { get; set; }
        public string medida { get; set; }
        public string tipo { get; set; }
        public int pos { get; set; }
        public int p_actual { get; set; }
        public int R1 { get; set; }
        public int R2 { get; set; }
        public int R3 { get; set; }
        public int p_min { get; set; }
        public decimal km_inicial { get; set; }
        public decimal km_actual { get; set; }
        public decimal km_recorrido { get; set; }
        public int rod { get; set; }
        public decimal km_mm { get; set; }
        public int porcentaje { get; set; }
        public decimal km_3mm { get; set; }
        public decimal cost_actual { get; set; }
        public decimal cost_proy { get; set; }

    }
}
