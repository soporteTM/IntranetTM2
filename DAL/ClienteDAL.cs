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
    public class ClienteDAL
    {
        public List<ClienteEL> ListarCliente()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Listar_Cliente");

            List<ClienteEL> lstItem = new List<ClienteEL>();
            lstItem = Util.ConvertDataTable<ClienteEL>(dt);

            return lstItem;
        }
    }
}
