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
    public class NaveDAL
    {
        public List<NaveEL> ListarContenedorNave(string estado)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@Estado", SqlDbType.Int);
            arParams[0].Value = Convert.ToInt32(estado);

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Listar_NaveContenedor",arParams);            

            List<NaveEL> lstItem = new List<NaveEL>();
            lstItem = Util.ConvertDataTable<NaveEL>(dt);

            return lstItem;
        }

        public List<NaveExportarEL> ListarContenedorNaveExportar()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Listar_Nave_Exportar");

            List<NaveExportarEL> lstItem = new List<NaveExportarEL>();
            lstItem = Util.ConvertDataTable<NaveExportarEL>(dt);

            return lstItem;
        }



        public List<TransaccionEL> RegistrarNave(NaveEL oNave)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@puerto", SqlDbType.VarChar,5);
            arParams[0].Value = oNave.puerto;

            arParams[1] = new SqlParameter("@nave", SqlDbType.VarChar, 50);
            arParams[1].Value = oNave.nave;

            arParams[2] = new SqlParameter("@fecha", SqlDbType.DateTime);
            arParams[2].Value = oNave.fecha_registro;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Registrar_Nave", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }
        public List<TransaccionEL> RegistrarNaveDescarga(NaveEL oNave)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@anio_manifiesto", SqlDbType.VarChar, 50);
            arParams[0].Value = oNave.anio_manifiesto;

            arParams[1] = new SqlParameter("@nro_manifiesto", SqlDbType.VarChar, 50);
            arParams[1].Value = oNave.nro_manifiesto;

            arParams[2] = new SqlParameter("@puerto", SqlDbType.VarChar, 10);
            arParams[2].Value = oNave.puerto;

            arParams[3] = new SqlParameter("@nave", SqlDbType.VarChar, 50);
            arParams[3].Value = oNave.nave;

            arParams[4] = new SqlParameter("@fecha", SqlDbType.DateTime);
            arParams[4].Value = oNave.fecha_registro;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Registrar_Nave_Descarga", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<NaveEL> ActualizarNave(NaveEL oNave)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@nave", SqlDbType.VarChar, 50);
            arParams[0].Value = oNave.nave;

            arParams[1] = new SqlParameter("@fecha", SqlDbType.DateTime);
            arParams[1].Value = oNave.fecha_termino;

            arParams[2] = new SqlParameter("@id", SqlDbType.Int);
            arParams[2].Value = oNave.id;

            arParams[3] = new SqlParameter("@fechaInicio", SqlDbType.DateTime);
            arParams[3].Value = oNave.fecha_registro;


            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Actualizar_Nave", arParams);

            List<NaveEL> lstData = new List<NaveEL>();
            lstData = Util.ConvertDataTable<NaveEL>(dt);

            return lstData;
        }
        public List<NaveEL> EliminarNave(NaveEL oNave)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oNave.id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Eliminar_Nave", arParams);
            
            List<NaveEL> lstData = new List<NaveEL>();
            lstData = Util.ConvertDataTable<NaveEL>(dt);

            return lstData;
        }

        public List<NaveEL> ConsultarNave(NaveEL oNave)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oNave.id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Consultar_Nave", arParams);

            List<NaveEL> lstData = new List<NaveEL>();
            lstData = Util.ConvertDataTable<NaveEL>(dt);

            return lstData;
        }


    }
}
