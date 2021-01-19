using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using DAL;

namespace BL
{
    public class TMS_SolicitudBL
    {
        public List<TMS_SolicitudEL> ListarMovimiento()
        {
            TMS_SolicitudDAL oSolicitud = new TMS_SolicitudDAL();
            return oSolicitud.ListarMovimiento();
        }
        public List<TMS_SolicitudEL> ListarEstadosAL()
        {
            TMS_SolicitudDAL oSolicitud = new TMS_SolicitudDAL();
            return oSolicitud.ListarEstadosAL();
        }
        public List<TMS_SolicitudEL> ListarEmpresasAL()
        {
            TMS_SolicitudDAL oSolicitud = new TMS_SolicitudDAL();
            return oSolicitud.ListarEmpresasAL();
        }
        public List<TMS_SolicitudEL> ListarTipoSolicitud()
        {
            TMS_SolicitudDAL oSolicitud = new TMS_SolicitudDAL();
            return oSolicitud.ListarTipoSolicitud();
        }
        public List<TMS_SolicitudEL> ListarAnalista()
        {
            TMS_SolicitudDAL oSolicitud = new TMS_SolicitudDAL();
            return oSolicitud.ListarAnalista();
        }
    }
}
