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
    public class TerceroConductorDAL
    {
        public List<TerceroConductorEL> ListarConductor(TerceroConductorEL oConductor)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oConductor.id_emp;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "SIG_Listado_Conductor",arParams);

            List<TerceroConductorEL> lstItem = new List<TerceroConductorEL>();
            lstItem = Util.ConvertDataTable<TerceroConductorEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> RegistrarConductor(TerceroConductorEL oConductor)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@id_emp", SqlDbType.Int);
            arParams[0].Value = oConductor.id_emp;

            arParams[1] = new SqlParameter("@nombre", SqlDbType.VarChar, 100);
            arParams[1].Value = oConductor.nombre;

            arParams[2] = new SqlParameter("@dni", SqlDbType.VarChar, 15);
            arParams[2].Value = oConductor.dni;

            arParams[3] = new SqlParameter("@licencia", SqlDbType.VarChar, 30);
            arParams[3].Value = oConductor.licencia;

            arParams[4] = new SqlParameter("@cat_licencia", SqlDbType.VarChar, 20);
            arParams[4].Value = oConductor.cat_licencia;


            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "SIG_Registrar_Conductor", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> ActualizarConductor(TerceroConductorEL oConductor)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@id_conductor", SqlDbType.Int);
            arParams[0].Value = oConductor.id_conductor;

            arParams[1] = new SqlParameter("@nombre", SqlDbType.VarChar, 100);
            arParams[1].Value = oConductor.nombre;

            arParams[2] = new SqlParameter("@dni", SqlDbType.VarChar, 15);
            arParams[2].Value = oConductor.dni;

            arParams[3] = new SqlParameter("@licencia", SqlDbType.VarChar, 30);
            arParams[3].Value = oConductor.licencia;

            arParams[4] = new SqlParameter("@cat_licencia", SqlDbType.VarChar, 20);
            arParams[4].Value = oConductor.cat_licencia;


            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "SIG_Actualizar_Conductor", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> EliminarConductor(TerceroConductorEL oConductor)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];            
            arParams[0] = new SqlParameter("@id_conductor", SqlDbType.Int);
            arParams[0].Value = oConductor.id_conductor;
            
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "SIG_Eliminar_Conductor", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }
    }
}
