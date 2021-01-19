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
    public class TMS_NotificacionesDAL
    {

        public List<TMS_NotificacionesEL> ListarNotificacionesXCliente(string Ent_Codi, string movimiento)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@Ent_Codi", SqlDbType.VarChar, 6);
            arParams[0].Value = Ent_Codi;

            arParams[1] = new SqlParameter("@Movimiento", SqlDbType.VarChar, 1);
            arParams[1].Value = movimiento;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TM_Listar_NotificacionesXCliente", arParams);

            List<TMS_NotificacionesEL> lstItem = new List<TMS_NotificacionesEL>();
            lstItem = Util.ConvertDataTable<TMS_NotificacionesEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> CrearNotificacionesXCliente(string Ent_Codi, string usuario)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@Ent_Codi", SqlDbType.VarChar, 6);
            arParams[0].Value = Ent_Codi;

            arParams[1] = new SqlParameter("@Usuario", SqlDbType.VarChar, 100);
            arParams[1].Value = usuario;
            
            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TM_Crear_Notificaciones", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> ActualizarNotificaciones(TMS_NotificacionesEL Ntf)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[14];
            arParams[0] = new SqlParameter("@Ent_Codi", SqlDbType.VarChar, 6);
            arParams[0].Value = Ntf.Ent_Codi;

            arParams[1] = new SqlParameter("@Ntf_RLlegada", SqlDbType.Bit);
            arParams[1].Value = Ntf.Ntf_RLlegada;

            arParams[2] = new SqlParameter("@Ntf_RIngreso", SqlDbType.Bit);
            arParams[2].Value = Ntf.Ntf_RIngreso;

            arParams[3] = new SqlParameter("@Ntf_RSalida", SqlDbType.Bit);
            arParams[3].Value = Ntf.Ntf_RSalida; 

            arParams[4] = new SqlParameter("@Ntf_CLlegada", SqlDbType.Bit);
            arParams[4].Value = Ntf.Ntf_CLlegada;

            arParams[5] = new SqlParameter("@Ntf_CIngreso", SqlDbType.Bit);
            arParams[5].Value = Ntf.Ntf_CIngreso;

            arParams[6] = new SqlParameter("@Ntf_CInicio", SqlDbType.Bit);
            arParams[6].Value = Ntf.Ntf_CInicio;
             
            arParams[7] = new SqlParameter("@Ntf_CTermino", SqlDbType.Bit);
            arParams[7].Value = Ntf.Ntf_CTermino;

            arParams[8] = new SqlParameter("@Ntf_CSalida", SqlDbType.Bit);
            arParams[8].Value = Ntf.Ntf_CSalida; 
            
            arParams[9] = new SqlParameter("@Ntf_DLlegada", SqlDbType.Bit);
            arParams[9].Value = Ntf.Ntf_DLlegada;

            arParams[10] = new SqlParameter("@Ntf_DIngreso", SqlDbType.Bit);
            arParams[10].Value = Ntf.Ntf_DIngreso;

            arParams[11] = new SqlParameter("@Ntf_DSalida", SqlDbType.Bit);
            arParams[11].Value = Ntf.Ntf_DSalida;            

            arParams[12] = new SqlParameter("@Movimiento", SqlDbType.VarChar, 1);
            arParams[12].Value = Ntf.Movimiento;

            arParams[13] = new SqlParameter("@Usuario", SqlDbType.VarChar, 100);
            arParams[13].Value = Ntf.Usuario_Modificacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "UP_NotificacionCliente_Registrar", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }

        //public List<TMS_SeguimientoEL> GetEmpresaTransporte()
        //{
        //    DataTable dt;

        //    dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GetEmpresaTransporte");

        //    List<TMS_SeguimientoEL> lstItem = new List<TMS_SeguimientoEL>();
        //    lstItem = Util.ConvertDataTable<TMS_SeguimientoEL>(dt);

        //    return lstItem;
        //}

        //public DataTable GetEvento()
        //{
        //    DataTable dt;

        //    dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GetEvento");

        //    return dt;
        //}
    }
}
