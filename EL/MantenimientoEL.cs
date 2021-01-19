using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class MantenimientoEL
    {
    }

    public class MantenimientoClienteEL
    {
        public int codigo_cliente { get; set; }
        public string cod_documento { get; set; }
        public string tipo_documento { get; set; }
        public string nro_documento { get; set; }
        public string razon_social { get; set; }
        public string nombre_comercial { get; set; }
        public string direccion { get; set; }
        public int estado { get; set; }
        public string usuario_creacion { get; set; }
        public string usuario_modificacion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }

    public class MantenimientoLocalEL
    {
        public int codigo_cliente { get; set; }
        public int codigo_local { get; set; }
        public string direccion { get; set; }
        public string codigo_ubigeo { get; set; }
        public string nombre_departamento { get; set; }
        public string nombre_provincia { get; set; }
        public string ubigeo { get; set; }
        public int estado { get; set; }
        public string usuario_creacion { get; set; }
        public string usuario_modificacion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }

    public class MantenimientoContactoEL
    {
        public int contacto_id { get; set; }
        public int codigo_cliente { get; set; }
        public string nombre { get; set; }
        public string apellido_pat { get; set; }
        public string apellido_mat { get; set; }
        public string cargo { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string anexo { get; set; }
        public string fecha_nacimiento { get; set; }
        public string observacion { get; set; }
        public int estado { get; set; }
        public string usuario_creacion { get; set; }
        public string usuario_modificacion { get; set; }
        public DateTime fecha_creacion { get; set; }
        public DateTime fecha_modificacion { get; set; }
    }
}
