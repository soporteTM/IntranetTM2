using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DocumentacionBL
    {
        public List<DocumentacionEL> ConsultarDocumentacion(int cod_flota)
        {
            DocumentacionDAL oFlota = new DocumentacionDAL();
            return oFlota.ConsultarDocumentacion(cod_flota);
        }

        public List<TransaccionEL> RegistrarDocumentacion(DocumentacionEL oDocumentacion)
        {
            DocumentacionDAL oDoc = new DocumentacionDAL();
            return oDoc.RegistrarDocumentacion(oDocumentacion);
        }

        public List<TransaccionEL> ActualizarDocumentacion(DocumentacionEL oDocumentacion)
        {
            DocumentacionDAL oDoc = new DocumentacionDAL();
            return oDoc.ActualizarDocumentacion(oDocumentacion);
        }
    }
}
