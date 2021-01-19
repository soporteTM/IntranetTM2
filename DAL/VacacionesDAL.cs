using EL;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class VacacionesDAL
    {
    }

    public class VacacionesSolicitudDAL
    {
        public List<VacacionesSolicitudEL> ListarVacaciones(VacacionesSolicitudEL oVacaciones)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oVacaciones.id_empleado;

            arParams[1] = new SqlParameter("@estado", SqlDbType.VarChar,6);
            arParams[1].Value = oVacaciones.estado;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "RRHH_VAC_ListarSolicitud", arParams);

            List<VacacionesSolicitudEL> lstItem = new List<VacacionesSolicitudEL>();
            lstItem = Util.ConvertDataTable<VacacionesSolicitudEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> RegistrarVacaciones(VacacionesSolicitudEL oVacaciones)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oVacaciones.id_empleado;

            arParams[1] = new SqlParameter("@idsolicitante", SqlDbType.Int);
            arParams[1].Value = oVacaciones.id_solicitante;

            arParams[2] = new SqlParameter("@fchIni", SqlDbType.Date);
            arParams[2].Value = oVacaciones.fch_inicio2;

            arParams[3] = new SqlParameter("@fchFin", SqlDbType.Date);
            arParams[3].Value = oVacaciones.fch_fin2;

            arParams[4] = new SqlParameter("@total_dias", SqlDbType.Int);
            arParams[4].Value = oVacaciones.total_dias;

            arParams[5] = new SqlParameter("@observaciones", SqlDbType.VarChar, 100);
            arParams[5].Value = oVacaciones.observaciones;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "RRHH_VAC_RegistrarSolicitud", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }

        public List<VacacionesSolicitudEL> ActualizarVacaciones(VacacionesSolicitudEL oVacaciones)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oVacaciones.id_solicitud;

            arParams[1] = new SqlParameter("@fchIni", SqlDbType.Date);
            arParams[1].Value = oVacaciones.fch_inicio2;

            arParams[2] = new SqlParameter("@fchFin", SqlDbType.Date);
            arParams[2].Value = oVacaciones.fch_fin2;

            arParams[3] = new SqlParameter("@total_dias", SqlDbType.Int);
            arParams[3].Value = oVacaciones.total_dias;

            arParams[4] = new SqlParameter("@observaciones", SqlDbType.VarChar, 100);
            arParams[4].Value = oVacaciones.observaciones;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "RRHH_VAC_ActualizarSolicitud", arParams);

            List<VacacionesSolicitudEL> lstItem = new List<VacacionesSolicitudEL>();
            lstItem = Util.ConvertDataTable<VacacionesSolicitudEL>(dt);

            return lstItem;
        }

        public List<VacacionesSolicitudEL> EliminarVacaciones(VacacionesSolicitudEL oVacaciones)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oVacaciones.id_solicitud;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "RRHH_VAC_EliminarSolicitud", arParams);

            List<VacacionesSolicitudEL> lstItem = new List<VacacionesSolicitudEL>();
            lstItem = Util.ConvertDataTable<VacacionesSolicitudEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> BuscarSolicitud(VacacionesSolicitudEL oVacaciones)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@fecha", SqlDbType.Date);
            arParams[0].Value = oVacaciones.fch_inicio2;

            arParams[1] = new SqlParameter("@id", SqlDbType.Int);
            arParams[1].Value = oVacaciones.id_empleado;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "RRHH_VAC_BuscarSolicitud", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }
    }

    public class VacacionesAprobacionDAL
    {

        public List<TransaccionEL> RespuestaAprobacion(VacacionesAprobacionEL oAprobacion)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@idApro", SqlDbType.Int);
            arParams[0].Value = oAprobacion.id_aprobacion;

            arParams[1] = new SqlParameter("@estado", SqlDbType.VarChar, 10);
            arParams[1].Value = oAprobacion.estado;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "RRHH_VAC_RespuestaAprobacion", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }

        public List<VacacionesAprobacionEL> ListarAprobacion(VacacionesSolicitudEL oVacaciones)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oVacaciones.id_empleado;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "RRHH_VAC_ListarAprobacion", arParams);

            List<VacacionesAprobacionEL> lstItem = new List<VacacionesAprobacionEL>();
            lstItem = Util.ConvertDataTable<VacacionesAprobacionEL>(dt);

            return lstItem;
        }

        public List<VacacionesPendientesEL> ListarPendientes(VacacionesSolicitudEL oVacaciones)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oVacaciones.id_empleado;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "RRHH_VAC_ListarPendientes", arParams);

            List<VacacionesPendientesEL> lstItem = new List<VacacionesPendientesEL>();
            lstItem = Util.ConvertDataTable<VacacionesPendientesEL>(dt);

            return lstItem;
        }



    }
    public class VacacionesReporteDAL
    {
        public List<VacacionesReporteEL> ListarReporte(VacacionesSolicitudEL oVacaciones)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@cod_id", SqlDbType.Int);
            arParams[0].Value = oVacaciones.id_empleado;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "RRHH_VAC_ListarReporte", arParams);

            List<VacacionesReporteEL> lstItem = new List<VacacionesReporteEL>();
            lstItem = Util.ConvertDataTable<VacacionesReporteEL>(dt);

            return lstItem;
        }

        public List<VacacionesReporteEL> ListarReporteExcel()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "RRHH_VAC_ListarReporteExcel");

            List<VacacionesReporteEL> lstItem = new List<VacacionesReporteEL>();
            lstItem = Util.ConvertDataTable<VacacionesReporteEL>(dt);

            return lstItem;
        }
    }

    public class VacacionesEmailDAL
    {
        public List<VacacionesEmailEL> ConsultarEmail(VacacionesPendientesEL oVacaciones)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oVacaciones.id_solicitud;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "RRHH_VAC_ConsultarEmail", arParams);

            List<VacacionesEmailEL> lstItem = new List<VacacionesEmailEL>();
            lstItem = Util.ConvertDataTable<VacacionesEmailEL>(dt);

            return lstItem;
        }

        public List<VacacionesEmailEL> ConsultarEmailAprobacion(int idApro)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_apro", SqlDbType.Int);
            arParams[0].Value = idApro;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "RRHH_VAC_ConsultarEmailAprobacion", arParams);

            List<VacacionesEmailEL> lstItem = new List<VacacionesEmailEL>();
            lstItem = Util.ConvertDataTable<VacacionesEmailEL>(dt);

            return lstItem;
        }

        public List<VacacionesEmailEL> EnviarEmail(string from,string body,string sub,string BC)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@FROM", SqlDbType.VarChar, 100000);
            arParams[0].Value = from;

            arParams[1] = new SqlParameter("@CC", SqlDbType.VarChar, 100000);
            arParams[1].Value = "";

            arParams[2] = new SqlParameter("@BC", SqlDbType.VarChar, 100000);
            arParams[2].Value = BC;

            arParams[3] = new SqlParameter("@BODY", SqlDbType.VarChar, 100000);
            arParams[3].Value = body;

            arParams[4] = new SqlParameter("@SUB", SqlDbType.VarChar, 100000);
            arParams[4].Value = sub;


            

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "SP_EnviarMail", arParams);

            List<VacacionesEmailEL> lstItem = new List<VacacionesEmailEL>();
            lstItem = Util.ConvertDataTable<VacacionesEmailEL>(dt);

            return lstItem;
        }


    }
}
