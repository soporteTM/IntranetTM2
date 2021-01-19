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
    public class LiquidacionDAL
    {
        public List<LiquidacionEL> ListarLiquidacion()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Listar_Liquidacion");

            List<LiquidacionEL> lstItem = new List<LiquidacionEL>();
            lstItem = Util.ConvertDataTable<LiquidacionEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> RegistrarLiquidacion(LiquidacionEL oLiquidacion)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@cod_empresa", SqlDbType.Int);
            arParams[0].Value = oLiquidacion.cod_empresa;
            
            arParams[1] = new SqlParameter("@cod_maquinaria", SqlDbType.VarChar,10);
            arParams[1].Value = oLiquidacion.maquinaria;

            arParams[2] = new SqlParameter("@fch_Ini", SqlDbType.Date);
            arParams[2].Value = oLiquidacion.fch_liquidacion_inicio2;

            arParams[3] = new SqlParameter("@fch_Fin", SqlDbType.Date);
            arParams[3].Value = oLiquidacion.fch_liquidacion_fin2;

            arParams[4] = new SqlParameter("@Usuario", SqlDbType.VarChar,50);
            arParams[4].Value = oLiquidacion.usuario;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Registrar_Liquidacion", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        

        public List<TransaccionEL> EliminarLiquidacion(LiquidacionEL oLiquidacion)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_liquidacion", SqlDbType.Int);
            arParams[0].Value = oLiquidacion.id_liquidacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Eliminar_Liquidacion", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<AbastecimientoEL> LiquidacionDetalle(LiquidacionEL oLiquidacion)
        {

            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@id_liquidacion", SqlDbType.Int);
            arParams[0].Value = oLiquidacion.id_liquidacion;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Listar_Liquidacion_Detalle", arParams);

            List<AbastecimientoEL> lstItem = new List<AbastecimientoEL>();
            lstItem = Util.ConvertDataTable<AbastecimientoEL>(dt);

            return lstItem;
        }

        public List<AbastecimientoEL> EliminarnDetalle(AbastecimientoEL oLiquidacion)
        {

            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@id_abastecimiento", SqlDbType.Int);
            arParams[0].Value = oLiquidacion.id_abastecimiento;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Eliminar_Liquidacion_Detalle", arParams);

            List<AbastecimientoEL> lstItem = new List<AbastecimientoEL>();
            lstItem = Util.ConvertDataTable<AbastecimientoEL>(dt);

            return lstItem;
        }
    }
}
