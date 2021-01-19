using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class LiquidacionEL
    {
        public int id_liquidacion { get; set; }
        public string nom_empresa { get; set; }
        public int cod_empresa { get; set; }
        public string maquinaria { get; set; }
        public string cod_maquinaria { get; set; }
        public string cant { get; set; }
        public int cantidad_abastecimiento { get; set; }
        public int consumo_gl { get; set; }
        public Decimal consumo { get; set; }
        public string fch_registro { get; set; }
        public string fch_liquidacion_inicio { get; set; }
        public DateTime fch_liquidacion_inicio2 { get; set; }
        public string fch_liquidacion_fin { get; set; }
        public DateTime fch_liquidacion_fin2 { get; set; }
        public string usuario { get; set; }
        
    }

}
