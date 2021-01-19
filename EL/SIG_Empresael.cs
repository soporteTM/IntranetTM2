using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class SIG_EmpresaEL
    {
        public int Cod_Empresa { get; set; }
        public string RUC { get; set; }
        public string Razon_Social { get; set; }
        public string Representante_Legal { get; set; }
        public string Rubro { get; set; }
        public string Nombres_Contacto { get; set; }
        public string Apellidos_Contacto { get; set; }
        public string Cargo_Contacto { get; set; }
        public string Email_Contacto { get; set; }
        public string Telefono_Contacto { get; set; }
        public string Fecha_Solicitud { get; set; }
        public string Usuario_creacion { get; set; }
        public DateTime Fecha_creacion { get; set; }
        public string usuario_modificacion { get; set; }
        public DateTime Fecha_modificacion { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }


        public string Contacto { get; set; }


    }
}
