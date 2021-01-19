using EL;
using SQLHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MaquinariaDAL
    {
        public List<MaquinariaEL> ConsultarMaquinaria()
        {
            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CTR_ConsultarMaquinaria");

            List<MaquinariaEL> lstItem = new List<MaquinariaEL>();
            lstItem = Util.ConvertDataTable<MaquinariaEL>(dt);

            return lstItem;
        }
    }
}
