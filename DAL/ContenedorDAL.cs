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
    public class ContenedorDAL
    {
        public List<TransaccionEL> RegistrarContenedor(ContenedorEL oContenedor)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int, 5);
            arParams[0].Value = oContenedor.id;

            arParams[1] = new SqlParameter("@contenedor", SqlDbType.VarChar, 50);
            arParams[1].Value = oContenedor.contenedor;

            arParams[2] = new SqlParameter("@tipo", SqlDbType.VarChar, 5);
            arParams[2].Value = oContenedor.tipo;

            arParams[3] = new SqlParameter("@vacio", SqlDbType.VarChar, 5);
            arParams[3].Value = oContenedor.vacio;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Registrar_Contenedor", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<ContenedorEL> ListarContenedor(ContenedorEL oContenedor)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oContenedor.id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Listar_Contenedor", arParams);

            List<ContenedorEL> lstData = new List<ContenedorEL>();
            lstData = Util.ConvertDataTable<ContenedorEL>(dt);

            return lstData;
        }

        public List<ContenedorExportaEL> ListarContenedorExportar(ContenedorEL oContenedor)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oContenedor.id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Listar_Contenedor_Exportar", arParams);

            List<ContenedorExportaEL> lstData = new List<ContenedorExportaEL>();
            lstData = Util.ConvertDataTable<ContenedorExportaEL>(dt);

            return lstData;
        }

        public List<ContenedorExportaEL> ListarContenedorExportarxFecha(ContenedorExportaEL oContenedor)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@fchBegin", SqlDbType.VarChar, 20);
            arParams[0].Value = oContenedor.fch_T1_llegada;

            arParams[1] = new SqlParameter("@fchEnd", SqlDbType.VarChar, 20);
            arParams[1].Value = oContenedor.fch_T2_ingreso;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Listar_Contenedor_ExportarxFecha", arParams);

            List<ContenedorExportaEL> lstData = new List<ContenedorExportaEL>();
            lstData = Util.ConvertDataTable<ContenedorExportaEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> VerificarContenedor(ContenedorEL oContenedor)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oContenedor.id;

            arParams[1] = new SqlParameter("@contenedor", SqlDbType.VarChar, 50);
            arParams[1].Value = oContenedor.contenedor;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Verificar_Contenedores", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> ConsultaSeguimiento(ContenedorEL oContenedor)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oContenedor.id;
            
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Consulta_Contenedor_Seguimiento", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<ContenedorEL> EliminarContenedor(ContenedorEL oContenedor)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oContenedor.id_cnt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Eliminar_Contenedor", arParams);

            List<ContenedorEL> lstData = new List<ContenedorEL>();
            lstData = Util.ConvertDataTable<ContenedorEL>(dt);

            return lstData;

        }

        public List<TransaccionEL> ConsultarSeguimiento(ContenedorEL oContenedor)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oContenedor.id;

            arParams[1] = new SqlParameter("@id_cnt", SqlDbType.Int);
            arParams[1].Value = oContenedor.id_cnt;
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Consulta_Nave_Seguimiento", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<ContenedorEL> ContenedoresDescarga(NaveEL oNave)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@anio_manifiesto", SqlDbType.VarChar, 4);
            arParams[0].Value = oNave.anio_manifiesto;

            arParams[1] = new SqlParameter("@nro_manifiesto", SqlDbType.VarChar, 6);
            arParams[1].Value = oNave.nro_manifiesto;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "M_OP_SEGUIMIENTO_ImportarContenedores", arParams);

            List<ContenedorEL> lstData = new List<ContenedorEL>();
            lstData = Util.ConvertDataTable<ContenedorEL>(dt);

            return lstData;
        }

        public List<ContenedorEL> ActualizarContenedor(ContenedorEL oContenedor)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@id_cnt", SqlDbType.Int);
            arParams[0].Value = oContenedor.id_cnt;

            arParams[1] = new SqlParameter("@vacio", SqlDbType.VarChar,10);
            arParams[1].Value = oContenedor.vacio;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Actualizar_Contenedor", arParams);

            List<ContenedorEL> lstData = new List<ContenedorEL>();
            lstData = Util.ConvertDataTable<ContenedorEL>(dt);

            return lstData;
        }


    }
}
