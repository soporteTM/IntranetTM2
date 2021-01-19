using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EstadisticaOPBL
    {
        public List<EstadisticasServiciosOP> ReporteServicios(EstadisticaOPEL estadisticasOPEL)
        {
            EstadisticaOPDAL oEstadistica = new EstadisticaOPDAL();
            return oEstadistica.ReporteServicios(estadisticasOPEL);
        }

        public List<EstadisticasTercerosOP> ReporteTercero(EstadisticaOPEL estadisticasOPEL)
        {
            EstadisticaOPDAL oEstadistica = new EstadisticaOPDAL();
            return oEstadistica.ReporteTerceros(estadisticasOPEL);
        }
    }
}
