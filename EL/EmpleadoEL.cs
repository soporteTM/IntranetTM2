using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EmpleadoEL
    {
        public int id_key { get; set; }
        public string cod_emp { get; set; }
        public string cod_tipo { get; set; }
        public string nro_documento { get; set; }
        public string nombre_emp { get; set; }
        public string apellido_pat { get; set; }
        public string apellido_mat { get; set; }
        public string cod_genero { get; set; }
        public string cod_civil { get; set; }
        public DateTime fch_nacimiento { get; set; }
        public string nacionalidad { get; set; }
        public string ubigeo { get; set; }
        public string domicilio { get; set; }
        public string nro_domicilio { get; set; }
        public string nro_int { get; set; }
        public string urbanizacion { get; set; }
        public string cod_afiliacionAFP { get; set; }
        public string num_afiliacionAFP { get; set; }
        public DateTime fch_afiliacionAFP { get; set; }
        public string email { get; set; }
        public string telf_trabajo { get; set; }
        public string telf_personal { get; set; }
        public string cod_dpto_laboral { get; set; }
        public string cod_puesto_laboral { get; set; }
        public string cod_jefatura { get; set; }
        public decimal ingreso_mensual_extra { get; set; }
        public string tipo_viviendo { get; set; }
        public string tipo_licencia { get; set; }
        public string nro_licencia { get; set; }
        public string tipo_discapa { get; set; }
        public string observaciones_medicas { get; set; }
        public string estado { get; set; }
        public string cod_cese { get; set; }
        public DateTime fecha_cese { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string referencia_google_maps { get; set; }
        public string carpeta_compartida { get; set; }
        public string tipo_contrato { get; set; }
        public string tipo_personal { get; set; }
        public DateTime fch_ingreso { get; set; }
        public string cod_seguro { get; set; }
        public string num_afiliacionSeguro { get; set; }
        public DateTime fch_afiliacionSeguro { get; set; }
        public string nro_cta_sueldo { get; set; }
        public string cci_cta_sueldo { get; set; }
        public string bco_cta_sueldo { get; set; }
        public string nro_cta_cts { get; set; }
        public string cci_cta_cts { get; set; }
        public string bco_cta_cts { get; set; }
        public string img_personal { get; set; }


        public string marca_vehiculo { get; set; }
        public string modelo_vehiculo { get; set; }
        public string placa_vehiculo { get; set; }
        public string posee_cta_bancaria { get; set; }
        public string banco_cta_bancaria { get; set; }
        public string posee_tarj_credito { get; set; }
        public string banco_tarj_credito { get; set; }
        public string otros_muebles { get; set; }



    }
}
