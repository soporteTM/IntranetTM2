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
    public class CorreoDAL
    {
        public List<TransaccionEL> InsertarCorreo(CorreoEL oEmail)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@tipo", SqlDbType.VarChar, 10);
            arParams[0].Value = oEmail.tipo;

            arParams[1] = new SqlParameter("@destinatario", SqlDbType.VarChar, 100);
            arParams[1].Value = oEmail.destinatario;

            arParams[2] = new SqlParameter("@asunto", SqlDbType.VarChar, 100);
            arParams[2].Value = oEmail.asunto;

            arParams[3] = new SqlParameter("@template", SqlDbType.VarChar, 8000);
            arParams[3].Value = oEmail.template;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "NTF_InsertarCorreo", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }
    }
}
