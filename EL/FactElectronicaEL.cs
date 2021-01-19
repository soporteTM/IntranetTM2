using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL
{
    public class FactElectronicaEL
    {
        public int IDProceso { get; set; }
        public int DocEntry { get; set; }
        public string Directory { get; set; }
        public string DocumentType { get; set; }
        public string NumPref { get; set; }
        public string NumFolio { get; set; }
        public string Modo { get; set; }
        public string Indentificador { get; set; }
        public string Contenido { get; set; }
        public string ContenidoEncode64 { get; set; }
        public string Estado { get; set; }
        public DateTime FchRegistro { get; set; }
        public DateTime Envio_Fecha { get; set; }
        public string Envio_TransactionID { get; set; }
        public string Envio_Status { get; set; }
        public string Proceso_Fecha { get; set; }
        public string Proceso_Name { get; set; }
        public string Proceso_Status { get; set; }
        public string Proceso_StatusLegal { get; set; }
        public string Download_Archivo { get; set; }
        public string Download_Status { get; set; }

        public string U_CTS_ESFE { get; set; }
        public DateTime DocDate { get; set; }
     
       
    }
}
