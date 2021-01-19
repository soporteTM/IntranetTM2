using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TerceroDocumentacionBL
    {
        public List<TransaccionEL> RegistrarDocumentacion(TerceroDocuementacionEL objDocumento)
        {
            TerceroDocumentacionDAL oDocumento = new TerceroDocumentacionDAL();
            return oDocumento.RegistrarDocumentacion(objDocumento);
        }

        public List<TransaccionEL> EliminarDocumentacion(TerceroDocuementacionEL objDocumento)
        {
            TerceroDocumentacionDAL oDocumento = new TerceroDocumentacionDAL();
            return oDocumento.EliminarDocumentacion(objDocumento);
        }

        public List<TerceroDocuementacionEL> ListarDocumentacion(TerceroDocuementacionEL objDocumento)
        {
            TerceroDocumentacionDAL oDocumento = new TerceroDocumentacionDAL();
            return oDocumento.ListarDocumentacion(objDocumento);
        }

    }
}
