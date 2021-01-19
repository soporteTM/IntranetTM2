using DAL;
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
    public class ItemDAL
    {
        public List<ItemEL> ListarItem(string id_catalogo)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_catalogo", SqlDbType.VarChar,2);
            arParams[0].Value = id_catalogo;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "TM_Catalogo_Consultar", arParams);

            List<ItemEL> lstItem = new List<ItemEL>();
            lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return lstItem;
        }

        public List<ItemEL> ListarItemOpe(string id_catalogo)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_catalogo", SqlDbType.VarChar, 2);
            arParams[0].Value = id_catalogo;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Catalogo_Consultar", arParams);

            List<ItemEL> lstItem = new List<ItemEL>();
            lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return lstItem;
        }

        public List<ItemEL> ListarItemOperaciones(string id_catalogo)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_catalogo", SqlDbType.VarChar, 2);
            arParams[0].Value = id_catalogo;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "TM_Catalogo_Consultar", arParams);

            List<ItemEL> lstItem = new List<ItemEL>();
            lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return lstItem;
        }

        public List<ItemEL> ListarItemCatalogoFlota(string id_catalogo)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_catalogo", SqlDbType.VarChar, 2);
            arParams[0].Value = id_catalogo;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Catalogo_Consultar", arParams);

            List<ItemEL> lstItem = new List<ItemEL>();
            lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return lstItem;
        }

        public List<ItemEL> ListarItemDocu(string id_catalogo)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_subCatalogo", SqlDbType.VarChar, 2);
            arParams[0].Value = id_catalogo;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Documentacion_Items", arParams);

            List<ItemEL> lstItem = new List<ItemEL>();
            lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return lstItem;
        }
        public List<ItemEL> ConsultarCatalogo(string id_catalogo)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@codigo", SqlDbType.VarChar, 6);
            arParams[0].Value = id_catalogo;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Idioma_ConsultarCodigo", arParams);

            List<ItemEL> lstItem = new List<ItemEL>();
            lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return lstItem;
        }

        public List<ItemEL> ConsultarCatalogoOperaciones(string id_catalogo)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@codigo", SqlDbType.VarChar, 6);
            arParams[0].Value = id_catalogo;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "TM_Consultar_Catalago", arParams);

            List<ItemEL> lstItem = new List<ItemEL>();
            lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> ObtenerID()
        {
            DataTable dt;
           
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Generar_OT");

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }
    }
}
