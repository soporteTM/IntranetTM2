using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class TerceroEL
    {
    }
    public class TerceroConductorEL
    {
        public int id_conductor { get; set; }
        public int id_emp { get; set; }
        public string nombre { get; set; }
        public string dni { get; set; }
        public string licencia { get; set; }
        public string cat_licencia { get; set; }
    }
    public class TerceroEmpresaEL
    {
        public int id { get; set; }
        public string Emp_Rsoc { get; set; }
        public string RUC { get; set; }
        public string Contacto { get; set; }
        public string telefono { get; set; }
    }
    public class TerceroUnidadEL
    {
        public int id_unidad { get; set; }
        public int id_emp { get; set; }
        public string placa { get; set; }
        public int estado { get; set; }
        public string clasificacion { get; set; }
        public string configuracion { get; set; }
        public string año_fabricacion { get; set; }
        public string soat { get; set; }
        public string inspeccion_tecnica { get; set; }
        public string habilitacion_vehicular { get; set; }
        public string poliza { get; set; }
    }

    public class TerceroDocuementacionEL
    {
        public int id_doc { get; set; }
        public string tipo_doc { get; set; }
        public string tipo { get; set; }
        public int id { get; set; }
        public string fecha_registro { get; set; }
        public string fecha_fin { get; set; }
        public string documentacion { get; set; }
    }
}
