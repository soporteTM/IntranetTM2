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
    public class TerceroUnidadDAL
    {
        public List<TerceroUnidadEL> ListarUnidad(TerceroUnidadEL oUnidad)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oUnidad.id_emp;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "SIG_Listado_Unidad", arParams);

            List<TerceroUnidadEL> lstItem = new List<TerceroUnidadEL>();
            lstItem = Util.ConvertDataTable<TerceroUnidadEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> RegistrarUnidad(TerceroUnidadEL oUnidad)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@id_emp", SqlDbType.Int);
            arParams[0].Value = oUnidad.id_emp;

            arParams[1] = new SqlParameter("@placa", SqlDbType.VarChar, 50);
            arParams[1].Value = oUnidad.placa;

            arParams[2] = new SqlParameter("@clasificacion", SqlDbType.VarChar, 50);
            arParams[2].Value = oUnidad.clasificacion;

            arParams[3] = new SqlParameter("@configuracion", SqlDbType.VarChar, 50);
            arParams[3].Value = oUnidad.configuracion;

            arParams[4] = new SqlParameter("@año_fabricacion", SqlDbType.VarChar, 50);
            arParams[4].Value = oUnidad.año_fabricacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "SIG_Registrar_Unidad", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> ActualizarUnidad(TerceroUnidadEL oUnidad)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@id_unidad", SqlDbType.Int);
            arParams[0].Value = oUnidad.id_unidad;

            arParams[1] = new SqlParameter("@placa", SqlDbType.VarChar, 50);
            arParams[1].Value = oUnidad.placa;

            arParams[2] = new SqlParameter("@clasificacion", SqlDbType.VarChar, 50);
            arParams[2].Value = oUnidad.clasificacion;

            arParams[3] = new SqlParameter("@configuracion", SqlDbType.VarChar, 50);
            arParams[3].Value = oUnidad.configuracion;

            arParams[4] = new SqlParameter("@año_fabricacion", SqlDbType.VarChar, 50);
            arParams[4].Value = oUnidad.año_fabricacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "SIG_Actualizar_Unidad", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> EliminarUnidad(TerceroUnidadEL oUnidad)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_unidad", SqlDbType.Int);
            arParams[0].Value = oUnidad.id_unidad;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "SIG_Eliminar_Unidad", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }


    }
}
