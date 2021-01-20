using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class OrdTrabajoDetEL
    {
       public int IdDetalle { get; set; }
       public int IdOrden { get; set; }
       public int IdTarea { get; set; }
       public string nro_documento { get; set; }
       public string nom_conductor { get; set; }
       public int IdProveedor { get; set; }
       public string nom_proveedor { get; set; }
       public string nom_tarea { get; set; }
       public int IdMaterial { get; set; }
       public string nom_material { get; set; }
       public string GrupoArticuloCodiMaterial { get; set; }
       public string CodiMarca { get; set; }
       public string CodiSistema { get; set; }
       public decimal cantidad { get; set; }
       public string Descripcion { get; set; }
       public string Fecha { get; set; }
       public string HoraIngreso { get; set; }
       public string HoraSalida { get; set; }
       public decimal Duracion { get; set; }
       public string  PlacaTracto { get; set; }
       public string PlacaSemirremolque { get; set; }
       public string CodiInterno { get; set; }
       public string DescKilometraje { get; set; }
       public string Horometro { get; set; }
       public string Tecnico { get; set; }
       public string Conductor { get; set; }
       public decimal CantiMaterial { get; set; }
       public string CodiSede { get; set; }
       public string CodiServicio { get; set; }
       public string ServRealizado { get; set; }
       public int IdTipo { get; set; }

       public string nom_sistema { get; set; }
    }
}
