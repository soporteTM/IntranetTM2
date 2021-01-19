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
    public class CisternaDAL
    {
        
        public List<CisternaEL> ListarCisterna()
        {
            DataTable dt;
            
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_RPT_Cisterna");

            List<CisternaEL> lstItem = new List<CisternaEL>();
            lstItem = Util.ConvertDataTable<CisternaEL>(dt);

            return lstItem;
        }

        public List<CisternaEL> ListarCisterna(string cisterna, string fechaInicio, string fechaFin, string estado)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@cisterna", SqlDbType.VarChar,200);
            arParams[0].Value = cisterna;

            arParams[1] = new SqlParameter("@fechaInicio", SqlDbType.VarChar, 20);
            arParams[1].Value = fechaInicio;

            arParams[2] = new SqlParameter("@fechaFin", SqlDbType.VarChar,20);
            arParams[2].Value = fechaFin;

            arParams[3] = new SqlParameter("@estado", SqlDbType.VarChar,1);
            arParams[3].Value = estado;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_RPT_Cisterna_Filtro", arParams);

            List<CisternaEL> lstItem = new List<CisternaEL>();
            lstItem = Util.ConvertDataTable<CisternaEL>(dt);

            return lstItem;
        }

        public List<CisternaEL> ConsultarCisterna(CisternaEL oCisterna)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_cisterna", SqlDbType.Int);
            arParams[0].Value = oCisterna.cod_cisterna;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Listar_Cisterna",arParams);

            List<CisternaEL> lstItem = new List<CisternaEL>();
            lstItem = Util.ConvertDataTable<CisternaEL>(dt);

            return lstItem;
        }

        public List<ItemEL> TM_CisternaConsultar()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Cisterna_Consultar");

            List<ItemEL> lstItem = new List<ItemEL>();
            lstItem = Util.ConvertDataTable<ItemEL>(dt);

            return lstItem;
        }


        public List<TransaccionEL> RegistrarCisterna(CisternaEL oCisterna)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[10];
            arParams[0] = new SqlParameter("@cod_cisterna", SqlDbType.VarChar,6);
            arParams[0].Value = oCisterna.cod_cisterna;

            arParams[1] = new SqlParameter("@cantidad_gl", SqlDbType.Decimal);
            arParams[1].Value = oCisterna.cantidad_gl;

            arParams[2] = new SqlParameter("@cantidad_rm", SqlDbType.Decimal);
            arParams[2].Value = oCisterna.cantidad_rm_gl;

            arParams[3] = new SqlParameter("@precio_compra", SqlDbType.Decimal);
            arParams[3].Value = oCisterna.precio_compra;

            arParams[4] = new SqlParameter("@subtotal", SqlDbType.Decimal);
            arParams[4].Value = oCisterna.subtotal;

            arParams[5] = new SqlParameter("@total", SqlDbType.Decimal);
            arParams[5].Value = oCisterna.total;

            arParams[6] = new SqlParameter("@fecha_registro", SqlDbType.VarChar);
            arParams[6].Value = oCisterna.fecha_registro;

            arParams[7] = new SqlParameter("@fecha_vencimiento", SqlDbType.VarChar);
            arParams[7].Value = oCisterna.fecha_vencimiento;

            arParams[8] = new SqlParameter("@nro_factura", SqlDbType.VarChar);
            arParams[8].Value = oCisterna.nro_factura;

            arParams[9] = new SqlParameter("@nro_scop", SqlDbType.VarChar,50);
            arParams[9].Value = oCisterna.numero_scop;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Registrar_Cisterna", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> RegistrarCisternaRemanente(int id_cisterna_nueva,int id_cisterna)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@id_cisterna_nueva", SqlDbType.Int);
            arParams[0].Value = id_cisterna_nueva;

            arParams[1] = new SqlParameter("@id_cisterna", SqlDbType.Int);
            arParams[1].Value = id_cisterna;           
        
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Cisterna_Remanente", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }
    }
}
