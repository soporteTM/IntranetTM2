using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SolicitudBL
    {

        public List<SolicitudEL> ConsultarSolicitud(int id)
        {
            SolicitudDAL objSolicitud = new SolicitudDAL();
            return objSolicitud.ConsultarSolicitud(id);
        }

        public List<SolicitudEL> ListarSolicitud()
        {
            SolicitudDAL objSolicitud = new SolicitudDAL();
            return objSolicitud.ListarSolicitud();
        }

        public List<TransaccionEL> RegistrarSolicitud(SolicitudEL oSolicitud)
        {
            SolicitudDAL objSolicitud = new SolicitudDAL();
            return objSolicitud.RegistrarSolicitud(oSolicitud);
        }

        public List<SolicitudEL> RegistrarSolicitudTransporte(SolicitudEL oSolicitud)
        {
            SolicitudDAL objSolicitud = new SolicitudDAL();
            return objSolicitud.RegistrarSolicitudTransporte(oSolicitud);
        }
    }

    public class SolicitudDetalleContenedorBL
    {
        public List<SolicitudDetalleContenedorEL> ListarDetalleContenedor(int id)
        {
            SolicitudDetalleContenedorDAL objSolicitud = new SolicitudDetalleContenedorDAL();
            return objSolicitud.ListarDetalleContenedor(id);
        }

        public List<TransaccionEL> RegistrarDetalleContenedor(SolicitudDetalleContenedorEL oContenedor)
        {
            SolicitudDetalleContenedorDAL objSolicitud = new SolicitudDetalleContenedorDAL();
            return objSolicitud.RegistrarDetalleContenedor(oContenedor);
        }

        public List<TransaccionEL> ImportarContenedor(SolicitudDetalleContenedorEL oContenedor)
        {
            SolicitudDetalleContenedorDAL objSolicitud = new SolicitudDetalleContenedorDAL();
            return objSolicitud.ImportarContenedor(oContenedor);
        }
    }

    public class SolicitudDetalleBL
    {
        public List<SolicitudDetalleEL> ListarDetalle(int id)
        {
            SolicitudDetalleDAL objSolicitud = new SolicitudDetalleDAL();
            return objSolicitud.ListarDetalle(id);
        }
    }
}
