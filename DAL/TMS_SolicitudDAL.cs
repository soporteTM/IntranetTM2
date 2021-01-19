using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using SQLHelper;

namespace DAL
{
    public class TMS_SolicitudDAL
    {
        public List<TMS_SolicitudEL> ListarMovimiento()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_TransMovimiento");

            List<TMS_SolicitudEL> lstItem = new List<TMS_SolicitudEL>();
            lstItem = Util.ConvertDataTable<TMS_SolicitudEL>(dt);

            return lstItem;
        }

        public List<TMS_SolicitudEL> ListarEstadosAL()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_TransEstado");

            List<TMS_SolicitudEL> lstItem = new List<TMS_SolicitudEL>();
            lstItem = Util.ConvertDataTable<TMS_SolicitudEL>(dt);

            return lstItem;
        }

        public List<TMS_SolicitudEL> ListarEmpresasAL()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_Empresas");

            List<TMS_SolicitudEL> lstItem = new List<TMS_SolicitudEL>();
            lstItem = Util.ConvertDataTable<TMS_SolicitudEL>(dt);

            return lstItem;
        }

        public List<TMS_SolicitudEL> ListarTipoSolicitud()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_TransTipoSol");

            List<TMS_SolicitudEL> lstItem = new List<TMS_SolicitudEL>();
            lstItem = Util.ConvertDataTable<TMS_SolicitudEL>(dt);

            return lstItem;
        }

        public List<TMS_SolicitudEL> ListarAnalista()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_CargarAuditoriaAnalistas");

            List<TMS_SolicitudEL> lstItem = new List<TMS_SolicitudEL>();
            lstItem = Util.ConvertDataTable<TMS_SolicitudEL>(dt);

            return lstItem;
        }
    }
}
