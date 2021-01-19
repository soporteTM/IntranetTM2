using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SolicitudDstBL
    {
        public List<TransaccionEL> RegistrarSolicitud(SolicitudDstEL oSolicitud)
        {
            SolicitudDstDAL objSolicitud = new SolicitudDstDAL();
            return objSolicitud.RegistrarSolicitud(oSolicitud);
        }


    }
}
