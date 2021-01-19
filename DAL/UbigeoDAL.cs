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
    public class UbigeoDAL
    {
        public List<UbigeoEL> ListarUbigeo(string cod_departamento, string cod_provincia, string cod_distrito)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@cod_departamento", SqlDbType.Char,2);
            arParams[0].Value = cod_departamento;
            arParams[1] = new SqlParameter("@cod_provincia", SqlDbType.Char, 2);
            arParams[1].Value = cod_provincia;
            arParams[2] = new SqlParameter("@cod_distrito", SqlDbType.Char, 2);
            arParams[2].Value = cod_distrito;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Ubigeo_Consultar", arParams);

            List<UbigeoEL> lstItem = new List<UbigeoEL>();
            lstItem = Util.ConvertDataTable<UbigeoEL>(dt);

            return lstItem;
        }
 
    }
}
