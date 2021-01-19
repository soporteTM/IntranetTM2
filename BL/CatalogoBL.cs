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


namespace BL
{
    public class CatalogoBL
    {
        CatalogoDAL oItem = new CatalogoDAL();
        public List<ItemEL> ListarItem(string id_catalogo)
        {            
            return oItem.ListarCatalogo(id_catalogo);
        }

        public List<ItemEL> ListarItemOperaciones(string id_catalogo)
        {
            return oItem.ListarCatalogoOperaciones(id_catalogo);
        }

        public DataTable Consultar(string nombre)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@nombre", SqlDbType.VarChar, 100);
            arParams[0].Value = nombre;
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Institucion_Buscar", arParams);

            //List<ItemEL> lstItem = new List<ItemEL>();
            //lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return dt;
        }

        public List<ItemEL> ListarJefatura()
        {
            return oItem.ListarJefatura();
        }

    }
}
