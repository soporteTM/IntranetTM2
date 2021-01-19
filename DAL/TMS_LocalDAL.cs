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
    public class TMS_LocalDAL
    {
        public List<TMS_LocalesEL> ListarLocales(string cod_cli)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@CLIENTE", SqlDbType.VarChar, 6);
            arParams[0].Value = cod_cli;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_BuscarLocal", arParams);

            List<TMS_LocalesEL> lstItem = new List<TMS_LocalesEL>();
            lstItem = Util.ConvertDataTable<TMS_LocalesEL>(dt);

            return lstItem;
        }

        public List<TMS_LocalesEL> ListarLocales(string cod_cli, int cod_local)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@CLIENTE", SqlDbType.VarChar, 6);
            arParams[0].Value = cod_cli;

            arParams[1] = new SqlParameter("@CODIGO_LOCAL", SqlDbType.VarChar, 6);
            arParams[1].Value = cod_local;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TMS_BuscarLocal", arParams);

            List<TMS_LocalesEL> lstItem = new List<TMS_LocalesEL>();
            lstItem = Util.ConvertDataTable<TMS_LocalesEL>(dt);

            return lstItem;
        }

        public List<TMS_LocalesEL> GetLocal(string pCliente)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@CLIENTE", SqlDbType.VarChar, 6);
            arParams[0].Value = pCliente;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GetLocal", arParams);

            List<TMS_LocalesEL> lstItem = new List<TMS_LocalesEL>();
            lstItem = Util.ConvertDataTable<TMS_LocalesEL>(dt);

            return lstItem;
        }

        public string InsertarLocal(TMS_LocalesEL localesEL)
        {
            SqlParameter[] arParams = new SqlParameter[17];

            arParams[0] = new SqlParameter("@CLIENTE", SqlDbType.VarChar, 6);
            arParams[0].Value = localesEL.Ent_Codi;
            arParams[1] = new SqlParameter("@CODIGO", SqlDbType.Int);
            arParams[1].Value = localesEL.LOCAL_CODIGO;
            arParams[2] = new SqlParameter("@PROVINCIA", SqlDbType.Int);
            arParams[2].Value = Convert.ToInt32(localesEL.PROVINCIA);
            arParams[3] = new SqlParameter("@DISTRITO", SqlDbType.Int);
            arParams[3].Value = Convert.ToInt32(localesEL.DISTRITO_CODIGO);
            arParams[4] = new SqlParameter("@DIRECCION", SqlDbType.VarChar, 100);
            arParams[4].Value = localesEL.LOCAL_DIRECCION;
            arParams[5] = new SqlParameter("@LOCAL_GEOCERCA", SqlDbType.VarChar, 50);
            arParams[5].Value = localesEL.LOCAL_GEOCERCA;
            arParams[6] = new SqlParameter("@LOCAL_DESCRIPCION", SqlDbType.VarChar, 200);
            arParams[6].Value = localesEL.LOCAL_DESCRIPCION;
            arParams[7] = new SqlParameter("@ESTADO", SqlDbType.VarChar, 1);
            arParams[7].Value = localesEL.ESTADO;
            arParams[8] = new SqlParameter("@USUARIO", SqlDbType.VarChar, 50);
            arParams[8].Value = localesEL.LOCAL_USUARIO_CREACION;
            arParams[9] = new SqlParameter("@LOCAL_CODINT", SqlDbType.VarChar, 20);
            arParams[9].Value = localesEL.LOCAL_CODINT;
            arParams[10] = new SqlParameter("@LOCAL_HORARIODESDE", SqlDbType.VarChar, 20);
            arParams[10].Value = localesEL.LOCAL_HORARIODESDE;
            arParams[11] = new SqlParameter("@LOCAL_HORARIOHASTA", SqlDbType.VarChar, 20);
            arParams[11].Value = localesEL.LOCAL_HORARIOHASTA;
            arParams[12] = new SqlParameter("@LOCAL_MAILALMACEN", SqlDbType.VarChar, 50);
            arParams[12].Value = localesEL.LOCAL_MAILALMACEN;
            arParams[13] = new SqlParameter("@LOCAL_MAILSUBGER", SqlDbType.VarChar, 50);
            arParams[13].Value = localesEL.LOCAL_MAILSUBGER;
            arParams[14] = new SqlParameter("@LOCAL_OBSERVACION", SqlDbType.VarChar, 500);
            arParams[14].Value = localesEL.LOCAL_OBSERVACION;
            arParams[15] = new SqlParameter("@LOCAL_ATENCION", SqlDbType.VarChar, 50);
            arParams[15].Value = localesEL.LOCAL_ATENCION;
            arParams[16] = new SqlParameter("@LOCAL_ALIAS", SqlDbType.VarChar, 200);
            arParams[16].Value = localesEL.LOCAL_ALIAS;
            
            var dot = SqlServerHelper.ExecuteScalar(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_MantLocal", arParams);

            string mensaje = dot.ToString();
            
            return mensaje;
        }

        public List<TMS_LocalesEL> ListarProvincias()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GETPROVINCIA");

            List<TMS_LocalesEL> lstItem = new List<TMS_LocalesEL>();
            lstItem = Util.ConvertDataTable<TMS_LocalesEL>(dt);

            return lstItem;
        }

        public List<TMS_LocalesEL> ListarDistritos(int cod_provincia)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@PROVINCIA", SqlDbType.Int);
            arParams[0].Value = cod_provincia;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GETDISTRITO", arParams);

            List<TMS_LocalesEL> lstItem = new List<TMS_LocalesEL>();
            lstItem = Util.ConvertDataTable<TMS_LocalesEL>(dt);

            return lstItem;
        }
    }
}
