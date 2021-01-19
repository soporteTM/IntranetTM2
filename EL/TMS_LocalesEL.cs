using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class TMS_LocalesEL
    {
        public string Ent_Codi { get; set; } 
        public int LOCAL_CODIGO { get; set; }
        public int DISTRITO_CODIGO { get; set; } 
        public string LOCAL_DIRECCION { get; set; }
        public string ESTADO { get; set; } 
        public string LOCAL_USUARIO_CREACION { get; set; } 
        public DateTime LOCAL_FECHA_CREACION { get; set; } 
        public string LOCAL_USUARIO_MODIFICACION { get; set; }
        public DateTime LOCAL_FECHA_MODIFICACION { get; set; }
        public string LOCAL_GEOCERCA { get; set; } 
        public string LOCAL_DESCRIPCION { get; set; } 
        public string LOCAL_CODINT { get; set; } 
        public string LOCAL_HORARIODESDE { get; set; }
        public string LOCAL_HORARIOHASTA { get; set; }
        public string LOCAL_HORARIOTURNO { get; set; }
        public string LOCAL_MAILALMACEN { get; set; } 
        public string LOCAL_MAILSUBGER { get; set; } 
        public string LOCAL_OBSERVACION { get; set; }
        public string LOCAL_ATENCION { get; set; }
        public string LOCAL_ALIAS { get; set; } 

        //LISTADO DE LOCALES PAG PPAL
        public string CLIENTE { get; set; }
        public string PROVINCIA { get; set; }
        public string DISTRITO { get; set; }
        public int LOCAL { get; set; }
        public string DIRECCION { get; set; }

        //tabla provincia para el ddl
        public int PROVINCIA_CODIGO { get; set; }
        public string PROVINCIA_DESCRIPCION { get; set; }

        //tabla distrito para el ddl
        //ya está arriba  public string DISTRITO_CODIGO { get; set; }
        public string DISTRITO_DESCRIP { get; set; }

    }
}
