using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class VacacionesBL
    {
    }

    public class VacacionesSolicitudBL
    {
        public List<VacacionesSolicitudEL> ListarVacaciones(VacacionesSolicitudEL objVacaciones)
        {
            VacacionesSolicitudDAL oVacaciones= new VacacionesSolicitudDAL();
            return oVacaciones.ListarVacaciones(objVacaciones);
        }

        public List<TransaccionEL> RegistrarVacaciones(VacacionesSolicitudEL objVacaciones)
        {
            VacacionesSolicitudDAL oVacaciones = new VacacionesSolicitudDAL();
            return oVacaciones.RegistrarVacaciones(objVacaciones);
        }
        
        public List<VacacionesSolicitudEL> ActualizarVacaciones(VacacionesSolicitudEL objVacaciones)
        {
            VacacionesSolicitudDAL oVacaciones = new VacacionesSolicitudDAL();
            return oVacaciones.ActualizarVacaciones(objVacaciones);
        }
        public List<VacacionesSolicitudEL> EliminarVacaciones(VacacionesSolicitudEL objVacaciones)
        {
            VacacionesSolicitudDAL oVacaciones = new VacacionesSolicitudDAL();
            return oVacaciones.EliminarVacaciones(objVacaciones);
        }
        public List<TransaccionEL> BuscarSolicitud(VacacionesSolicitudEL objVacaciones)
        {
            VacacionesSolicitudDAL oVacaciones = new VacacionesSolicitudDAL();
            return oVacaciones.BuscarSolicitud(objVacaciones);
        }

        
    }
    
    public class VacacionesAprobacionBL
    {
        public List<VacacionesAprobacionEL> ListarAprobacion(VacacionesSolicitudEL objVacaciones)
        {
            VacacionesAprobacionDAL oVacaciones = new VacacionesAprobacionDAL();
            return oVacaciones.ListarAprobacion(objVacaciones);
        }

        public List<VacacionesPendientesEL> ListarPendientes(VacacionesSolicitudEL objVacaciones)
        {
            VacacionesAprobacionDAL oVacaciones = new VacacionesAprobacionDAL();
            return oVacaciones.ListarPendientes(objVacaciones);
        }

        public List<TransaccionEL> RespuestaAprobacion(VacacionesAprobacionEL objVacaciones)
        {
            VacacionesAprobacionDAL oVacaciones = new VacacionesAprobacionDAL();
            return oVacaciones.RespuestaAprobacion(objVacaciones);
        }   
    }

    public class VacacionesReporteBL
    {
        public List<VacacionesReporteEL> ListarReporte(VacacionesSolicitudEL objVacaciones)
        {
            VacacionesReporteDAL oVacaciones = new VacacionesReporteDAL();
            return oVacaciones.ListarReporte(objVacaciones);
        }

        public List<VacacionesReporteEL> ListarReporteExcel()
        {
            VacacionesReporteDAL oVacaciones = new VacacionesReporteDAL();
            return oVacaciones.ListarReporteExcel();
        }
    }

    public class VacacionesEmailBL
    {
        public List<VacacionesEmailEL> ConsultarEmail(VacacionesPendientesEL objVacaciones)
        {
            VacacionesEmailDAL oVacaciones = new VacacionesEmailDAL();
            return oVacaciones.ConsultarEmail(objVacaciones);
        }

        public List<VacacionesEmailEL> ConsultarEmailAprobacion(int idApro)
        {
            VacacionesEmailDAL oVacaciones = new VacacionesEmailDAL();
            return oVacaciones.ConsultarEmailAprobacion(idApro);
        }

        public List<VacacionesEmailEL> EnviarEMail(string from, string body, string sub,string BC)
        {
            VacacionesEmailDAL oVacaciones = new VacacionesEmailDAL();
            return oVacaciones.EnviarEmail(from,body,sub,BC);
        }
    }

}
