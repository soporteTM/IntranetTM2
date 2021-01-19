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
    public class NombradaDAL
    {
        public List<NombradaEL> ListarNombrada(NombradaEL oNombrada)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@fecha", SqlDbType.Date);
            arParams[0].Value = oNombrada.fecha;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Listado_Nombrada", arParams);

            List<NombradaEL> lstItem = new List<NombradaEL>();
            lstItem = Util.ConvertDataTable<NombradaEL>(dt);

            return lstItem;
        }

        public List<NombradaExportarEL> ListarNombradaExportar(NombradaEL oNombrada)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@fecha", SqlDbType.Date);
            arParams[0].Value = oNombrada.fecha;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Listado_Nombrada_Exportar", arParams);

            List<NombradaExportarEL> lstItem = new List<NombradaExportarEL>();
            lstItem = Util.ConvertDataTable<NombradaExportarEL>(dt);

            return lstItem;
        }

        public List<NombradaEL> SeleccionarUnidad(NombradaEL oNombrada)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_unidad", SqlDbType.Int);
            arParams[0].Value = oNombrada.id_unidad;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_SeleccionarUnidad", arParams);

            List<NombradaEL> lstItem = new List<NombradaEL>();
            lstItem = Util.ConvertDataTable<NombradaEL>(dt);

            return lstItem;
        }



        public List<TransaccionEL> RegistrarNombrada(NombradaEL oNombrada)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@fecha", SqlDbType.Date);
            arParams[0].Value = oNombrada.fecha;


            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Insertar_Nombrada", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<NombradaEL> ListarConductores()
        {
            DataTable dt;
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Listado_Conductores");
            List<NombradaEL> lstItem = new List<NombradaEL>();
            lstItem = Util.ConvertDataTable<NombradaEL>(dt);
            return lstItem;
        }

        public List<NombradaEL> ListarUnidades()
        {
            DataTable dt;
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Listado_Unidades");
            List<NombradaEL> lstItem = new List<NombradaEL>();
            lstItem = Util.ConvertDataTable<NombradaEL>(dt);
            return lstItem;
        }

        public List<NombradaEL> VerificarConductor(NombradaEL oNombrada)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@nombre", SqlDbType.VarChar,100);
            arParams[0].Value = oNombrada.NombreCompleto;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Verificar_Conductor", arParams);
            List<NombradaEL> lstItem = new List<NombradaEL>();
            lstItem = Util.ConvertDataTable<NombradaEL>(dt);
            return lstItem;
        }
        public List<NombradaEL> VerificarUnidad(NombradaEL oNombrada)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@cod_unidad", SqlDbType.Int);
            arParams[0].Value = oNombrada.cod_id;

            arParams[1] = new SqlParameter("@unidad", SqlDbType.VarChar,100);
            arParams[1].Value = oNombrada.cod_interno;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Verificar_Unidad",arParams);
            List<NombradaEL> lstItem = new List<NombradaEL>();
            lstItem = Util.ConvertDataTable<NombradaEL>(dt);
            return lstItem;
        }

        public List<TransaccionEL> ActualizarNombrada(NombradaEL oNombrada)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@id_unidad", SqlDbType.Int);
            arParams[0].Value = oNombrada.id_unidad;

            arParams[1] = new SqlParameter("@id", SqlDbType.Int);
            arParams[1].Value = oNombrada.id;

            arParams[2] = new SqlParameter("@tipo", SqlDbType.VarChar, 6);
            arParams[2].Value = oNombrada.tipo;

            arParams[3] = new SqlParameter("@observacion", SqlDbType.VarChar,50);
            arParams[3].Value = oNombrada.observacion;

            arParams[4] = new SqlParameter("@id_conductor", SqlDbType.Int);
            arParams[4].Value = oNombrada.id_conductor;


            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Actualizar_Nombrada", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> AgregarConductor(NombradaEL oNombrada)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@fecha", SqlDbType.DateTime);
            arParams[0].Value = oNombrada.fecha;

            arParams[1] = new SqlParameter("@id_conductor", SqlDbType.Int);
            arParams[1].Value = oNombrada.id_conductor;

            arParams[2] = new SqlParameter("@id_unidad", SqlDbType.Int);
            arParams[2].Value = oNombrada.id_unidad;

            arParams[3] = new SqlParameter("@tipo", SqlDbType.VarChar,6);
            arParams[3].Value = oNombrada.tipo;

            arParams[4] = new SqlParameter("@observacion", SqlDbType.VarChar, 50);
            arParams[4].Value = oNombrada.observacion;

            arParams[5] = new SqlParameter("@status_unidad", SqlDbType.Bit);
            arParams[5].Value = oNombrada.status_unidad;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Agregar_Nombrada", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> EliminarConductor(NombradaEL oNombrada)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oNombrada.id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Eliminar_Conductor", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }






    }
}
