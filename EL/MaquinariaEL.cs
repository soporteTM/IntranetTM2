using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class MaquinariaEL
    {
        public int id_maq { get; set; }
        public string tipo_maq { get; set;}
        public string nom_maq { get; set; }
        public string cod_maq { get; set; }
        public string cod_marca { get; set; }
        public string nom_marca { get; set; }
        public string fabricacion { get; set; }
        public string modelo { get; set; }
        public string nro_serie { get; set; }
        public string tipo_motor { get; set; }
        public string serie_motor { get; set; }
        public decimal capacidad { get; set; }
        public Boolean estado { get; set; }
    }
}
