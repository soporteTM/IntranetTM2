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
    public class EcoMenuDAL
    {
        public List<EcoMenuEL> ListarMenu(EcoMenuEL menuEL)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@v_per_codigo", SqlDbType.VarChar, 5);
            arParams[0].Value = menuEL.MEN_DESCRIPCION;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxSeguridad, CommandType.StoredProcedure, "ECO_SP_CREAR_MENU", arParams);

            List<EcoMenuEL> lstItem = new List<EcoMenuEL>();
            lstItem = Util.ConvertDataTable<EcoMenuEL>(dt);

            return lstItem;
        }
    }

    public class EcoPerfilDAL
    {
        public List<EcoPerfilEL> ListarPerfil()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "Listado_Perfil");

            List<EcoPerfilEL> lstItem = new List<EcoPerfilEL>();
            lstItem = Util.ConvertDataTable<EcoPerfilEL>(dt);

            return lstItem;
        }
    }
}
