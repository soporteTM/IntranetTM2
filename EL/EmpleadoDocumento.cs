using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class EmpleadoDocumentoEL
    {
        public int id_key { get; set; }
        public int IDPersonal { get; set; }
        public string TipoDocumento { get; set; }
        public string TipoCarpeta { get; set; }
        public string Nombre { get; set; }
        public string Archivo { get; set; }
        public bool TieneVigencia { get; set; }
        public DateTime FchInicioVigencia { get; set; }
        public DateTime FchFinVigencia { get; set; }
        public string Observacion { get; set; }
        public bool Estado { get; set; }
        public string UserRegistro { get; set; }
        public DateTime FchRegistro { get; set; }
        public string UserActualizo { get; set; }
        public DateTime FchActualizo { get; set; }

        public string opcional_TieneVigencia { get; set; }
        public string opcional_FchInicioVigencia  { get; set; }
        public string opcional_FchFinVigencia { get; set; } 
    }

    public class EmpleadoDocumento2EL
    {
        public string IDDocumento { get; set; }
        public string IDPersonal  { get; set; }
        public string codTipo { get; set; }
        public string tipodocumento { get; set; }
        public string documentacion { get; set; }
        public string TieneVigencia { get; set; }
        public string FchInicioVigencia { get; set; }
        public string FchFinVigencia { get; set; }
        public string Observacion { get; set; }
        public int Estado { get; set; }
    }

    public class EmpleadoDocumentoRegistrar
    {
        public int IDDocumento { get; set; }
        public int IDPersonal { get; set; }
        public string tipodocumento { get; set; }
        public string documentacion { get; set; }
        public bool TieneVigencia { get; set; }
        public string FchInicioVigencia { get; set; }
        public string FchFinVigencia { get; set; }
        public string Observacion { get; set; }
    }
    
}
