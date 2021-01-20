using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class OrdTrabajoEL
    {
        public int IdOrden { get; set; }
        public int IdTarea { get; set; }
        public  string Descripcion { get; set; }
        public int IdMaterial { get; set; }
        public string CodiMarca { get; set; }
        public int CantiMaterial { get; set; }
        public int BEstado { get; set; }
        public string cEstado { get; set; }
        public bool BActivo { get; set; }
        public string nro_documento { get; set; }
        public string nom_conductor { get; set; }
        public int IdProveedor { get; set; }
        public string nom_proveedor { get; set; }
        public string GrupoArticuloCodiMaterial { get; set; }

        public int TipoApertura { get; set; }
        public string Fecha { get; set; }
        public string HoraIngreso { get; set; }
        public string HoraSalida { get; set; }
        public decimal Duracion { get; set; }
        public string PlacaTracto { get; set; }
        public string PlacaSemirremolque { get; set; }
        public string CodiInterno { get; set; }
        public string DescKilometraje { get; set; }
        public string Horometro { get; set; }
        public string Tecnico { get; set; }
        public string Conductor { get; set; }
        public string CodiSede { get; set; }
        public string CodiServicio { get; set; }
        public string ServRealizado { get; set; }
    }
}
