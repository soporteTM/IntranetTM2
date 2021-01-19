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
    public class SeguimientoDAL
    {

        public List<SeguimientoEL> ListarSeguimiento(SeguimientoEL oSeguimiento)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@id_nave", SqlDbType.Int);
            arParams[0].Value = oSeguimiento.id_nave;

            arParams[1] = new SqlParameter("@id_cnt", SqlDbType.Int);
            arParams[1].Value = oSeguimiento.id_cnt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Consultar_Seguimiento", arParams);

            List<SeguimientoEL> lstData = new List<SeguimientoEL>();
            lstData = Util.ConvertDataTable<SeguimientoEL>(dt);

            return lstData;


        }

        public List<SeguimientoEL> EliminarSeguimiento(SeguimientoEL oSeguimiento)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_seg", SqlDbType.Int);
            arParams[0].Value = oSeguimiento.id_seg;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Eliminar_Seguimineto", arParams);

            List<SeguimientoEL> lstData = new List<SeguimientoEL>();
            lstData = Util.ConvertDataTable<SeguimientoEL>(dt);

            return lstData;


        }

        public List<SeguimientoEL> RegistrarSeguimiento(SeguimientoEL oSeguimiento,string Usu)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[12];
            arParams[0] = new SqlParameter("@id_nave", SqlDbType.Int);
            arParams[0].Value = oSeguimiento.id_nave;

            arParams[1] = new SqlParameter("@id_cnt", SqlDbType.Int);
            arParams[1].Value = oSeguimiento.id_cnt;

            arParams[2] = new SqlParameter("@cod_unidad", SqlDbType.Int);
            arParams[2].Value = oSeguimiento.cod_unidad;

            arParams[3] = new SqlParameter("@unidad", SqlDbType.VarChar, 20);
            arParams[3].Value = oSeguimiento.cod_interno;

            arParams[4] = new SqlParameter("@cod_conductor", SqlDbType.Int);
            arParams[4].Value = oSeguimiento.cod_conductor;

            arParams[5] = new SqlParameter("@fch1", SqlDbType.DateTime);
            arParams[5].Value = Convert.ToDateTime(oSeguimiento.fch_T1_llegada);

            arParams[6] = new SqlParameter("@fch2", SqlDbType.DateTime);
            arParams[6].Value = Convert.ToDateTime(oSeguimiento.fch_T2_ingreso);

            arParams[7] = new SqlParameter("@fch3", SqlDbType.DateTime);
            arParams[7].Value = Convert.ToDateTime(oSeguimiento.fch_T3_salida);

            arParams[8] = new SqlParameter("@fch4", SqlDbType.DateTime);
            arParams[8].Value = Convert.ToDateTime(oSeguimiento.fch_T4_llegada);

            arParams[9] = new SqlParameter("@fch5", SqlDbType.DateTime);
            arParams[9].Value = Convert.ToDateTime(oSeguimiento.fch_T5_ingreso);

            arParams[10] = new SqlParameter("@fch6", SqlDbType.DateTime);
            arParams[10].Value = Convert.ToDateTime(oSeguimiento.fch_T6_salida);

            arParams[11] = new SqlParameter("@usu", SqlDbType.VarChar,100);
            arParams[11].Value = Usu;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_RegistrarSeguimiento", arParams);

            List<SeguimientoEL> lstData = new List<SeguimientoEL>();
            lstData = Util.ConvertDataTable<SeguimientoEL>(dt);

            return lstData;


        }

        public List<SeguimientoEL> ActualizarSeguimiento(SeguimientoEL oSeguimiento,string Usu)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[11];

            arParams[0] = new SqlParameter("@id_seg", SqlDbType.Int);
            arParams[0].Value = oSeguimiento.id_seg;

            arParams[1] = new SqlParameter("@cod_unidad", SqlDbType.Int);
            arParams[1].Value = oSeguimiento.cod_unidad;

            arParams[2] = new SqlParameter("@unidad", SqlDbType.VarChar, 20);
            arParams[2].Value = oSeguimiento.cod_interno;

            arParams[3] = new SqlParameter("@cod_conductor", SqlDbType.Int);
            arParams[3].Value = oSeguimiento.cod_conductor;

            arParams[4] = new SqlParameter("@fch1", SqlDbType.DateTime);
            arParams[4].Value = Convert.ToDateTime(oSeguimiento.fch_T1_llegada);

            arParams[5] = new SqlParameter("@fch2", SqlDbType.DateTime);
            arParams[5].Value = Convert.ToDateTime(oSeguimiento.fch_T2_ingreso);

            arParams[6] = new SqlParameter("@fch3", SqlDbType.DateTime);
            arParams[6].Value = Convert.ToDateTime(oSeguimiento.fch_T3_salida);

            arParams[7] = new SqlParameter("@fch4", SqlDbType.DateTime);
            arParams[7].Value = Convert.ToDateTime(oSeguimiento.fch_T4_llegada);

            arParams[8] = new SqlParameter("@fch5", SqlDbType.DateTime);
            arParams[8].Value = Convert.ToDateTime(oSeguimiento.fch_T5_ingreso);

            arParams[9] = new SqlParameter("@fch6", SqlDbType.DateTime);
            arParams[9].Value = Convert.ToDateTime(oSeguimiento.fch_T6_salida);

            arParams[10] = new SqlParameter("@usu", SqlDbType.VarChar, 100);
            arParams[10].Value = Usu;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OPS_Actualizar_Seguimiento", arParams);

            List<SeguimientoEL> lstData = new List<SeguimientoEL>();
            lstData = Util.ConvertDataTable<SeguimientoEL>(dt);

            return lstData;


        }

        

    }
}
