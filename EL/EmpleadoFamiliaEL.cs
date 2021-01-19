using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EmpleadoFamiliaEL
    {
        public int id_key { get; set; }
        public int cod_id { get; set; }
        public string cod_parentesco { get; set; }
        public string fam_nombre { get; set; }
        public string fam_apellido_pat { get; set; }
        public string fam_apellido_mat { get; set; }
        public DateTime fch_nacimiento { get; set; }
		
		public int edad { get; set; }
		
        public string lugar_nacimiento { get; set; }
        public string cod_ocupacion { get; set; }
        public string lugar_trabajo { get; set; }
        public string telf_of { get; set; }
        public string telf_casa { get; set; }
        public string llamar_emergencia { get; set; }


        public string opcional_llamar_emergencia { get; set; }
        public string opcional_parentesco { get; set; }
        public string opcional_ocupacion { get; set; } 
    }
}
