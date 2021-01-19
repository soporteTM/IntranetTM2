using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLHelper;


namespace DAL
{
    public class CatalogoDAL
    {
        public List<ItemEL> ListarCatalogo(string id_catalogo)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_catalogo", SqlDbType.VarChar,2);
            arParams[0].Value = id_catalogo;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Catalogo_Consultar", arParams);

            List<ItemEL> lstItem = new List<ItemEL>();
            lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return lstItem;
        }

        public List<ItemEL> ListarCatalogoOperaciones(string id_catalogo)
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

        public List<ItemEL> ListarJefatura()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Listar_Jefatura");

            List<ItemEL> lstItem = new List<ItemEL>();
            lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return lstItem;
        }


    }
}
