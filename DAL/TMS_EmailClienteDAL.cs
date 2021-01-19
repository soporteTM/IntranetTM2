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
    public class TMS_EmailClienteDAL
    {
        public List<TMS_EmailClienteEL> GetCorreoCliente(string Ent_Codi)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@EMP", SqlDbType.VarChar, 6);
            arParams[0].Value = Ent_Codi;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GetCorreoCliente_v2", arParams);

            List<TMS_EmailClienteEL> lstItem = new List<TMS_EmailClienteEL>();
            lstItem = Util.ConvertDataTable<TMS_EmailClienteEL>(dt);

            return lstItem;
        }

        public List<TMS_EmailClienteEL> GetCorreoCliente(string Ent_Codi, string Movimiento)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@EMP", SqlDbType.Char, 6);
            arParams[0].Value = Ent_Codi;

            arParams[1] = new SqlParameter("@MOV", SqlDbType.Char, 1);
            arParams[1].Value = Movimiento;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GetCorreoCliente_v2", arParams);

            List<TMS_EmailClienteEL> lstItem = new List<TMS_EmailClienteEL>();
            lstItem = Util.ConvertDataTable<TMS_EmailClienteEL>(dt);

            return lstItem;
        }

        public List<TMS_EmailClienteEL> InsertarCorreo(string Ent_Codi, string correo, string movimiento, string usuario)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@Ent_Codi", SqlDbType.VarChar, 6);
            arParams[0].Value = Ent_Codi;

            arParams[1] = new SqlParameter("@Email", SqlDbType.VarChar, 1000);
            arParams[1].Value = correo;

            arParams[2] = new SqlParameter("@Movimiento", SqlDbType.VarChar, 1);
            arParams[2].Value = movimiento;

            arParams[3] = new SqlParameter("@Usuario", SqlDbType.VarChar, 100);
            arParams[3].Value = usuario;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "UP_NotificacionCliente_RegistrarCorreo", arParams);

            List<TMS_EmailClienteEL> lstItem = new List<TMS_EmailClienteEL>();
            lstItem = Util.ConvertDataTable<TMS_EmailClienteEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> EliminarCorreoCliente(string Ent_Codi, string Movimiento, string correo)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@Ent_Codi", SqlDbType.VarChar, 6);
            arParams[0].Value = Ent_Codi;

            arParams[1] = new SqlParameter("@Movimiento", SqlDbType.VarChar, 1000);
            arParams[1].Value = Movimiento;

            arParams[2] = new SqlParameter("@Email", SqlDbType.VarChar, 1000);
            arParams[2].Value = correo;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "UP_NotificacionCliente_EliminarCorreo", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);
            
            return lstItem;
        }
    }
}
