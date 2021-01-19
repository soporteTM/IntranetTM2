using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using SQLHelper;

namespace DAL
{
    public class TMS_EmpresaDAL
    {
        public List<TMS_EmpresaEL> ListarEmpresas(TMS_EmpresaEL locales)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@ENT_CODI", SqlDbType.VarChar,6);
            arParams[0].Value = locales.ENT_CODI;

            arParams[1] = new SqlParameter("@ENT_RSOC", SqlDbType.VarChar,90);
            arParams[1].Value = locales.ENT_RSOC;

            arParams[2] = new SqlParameter("@ENT_NOMC", SqlDbType.VarChar,80);
            arParams[2].Value = locales.ENT_NOMC;

            arParams[3] = new SqlParameter("@ENT_RUC", SqlDbType.VarChar,11);
            arParams[3].Value = locales.ENT_RUC;

            arParams[4] = new SqlParameter("@ENT_DIRE", SqlDbType.VarChar,100);
            arParams[4].Value = locales.ENT_DIRE;

            arParams[5] = new SqlParameter("@Ent_Empresa", SqlDbType.VarChar,6);
            arParams[5].Value = locales.ENT_Empresa;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_Dst_listaEntidades", arParams);

            List<TMS_EmpresaEL> lstItem = new List<TMS_EmpresaEL>();
            lstItem = Util.ConvertDataTable<TMS_EmpresaEL>(dt);

            return lstItem;
        }
    }
}
