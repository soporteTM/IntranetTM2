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
    public class AbastecimientoDAL
    {
        public List<AbastecimientoEL> ConsultarAbastecimiento(int id_cisterna, int id_cliente, int id_abastecimiento)
        {
            SqlParameter[] arParams = new SqlParameter[3];

            arParams[0] = new SqlParameter("@id_cisterna", SqlDbType.Int);
            arParams[0].Value = id_cisterna;

            arParams[1] = new SqlParameter("@id_cliente", SqlDbType.Int);
            arParams[1].Value = id_cliente;

            arParams[2] = new SqlParameter("@id_abastecimiento", SqlDbType.Int);
            arParams[2].Value = id_abastecimiento;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_RPT_Detalle_Cisterna", arParams);

            List<AbastecimientoEL> lstItem = new List<AbastecimientoEL>();
            lstItem = Util.ConvertDataTable<AbastecimientoEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> GenerarLiquidacion(AbastecimientoEL oAbastecimientoEL)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@id_abastecimiento", SqlDbType.Int);
            arParams[0].Value = oAbastecimientoEL.id_abastecimiento;

            arParams[1] = new SqlParameter("@nro_factura", SqlDbType.VarChar, 20);
            arParams[1].Value = oAbastecimientoEL.id_liquidacion;

            arParams[2] = new SqlParameter("@fecha_facturacion", SqlDbType.VarChar,10);
            arParams[2].Value = oAbastecimientoEL.fecha_liquidacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Liquidacion_Combustible", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> ActualizarAbastecimiento(AbastecimientoEL oAbastecimientoEL)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_abastecimiento", SqlDbType.Int);
            arParams[0].Value = oAbastecimientoEL.id_abastecimiento;
           
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Actualizar_Abastecimiento", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> RegistrarConsumo(AbastecimientoEL oAbastecimientoEL)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[18];
            arParams[0] = new SqlParameter("@id_cisterna", SqlDbType.Int);
            arParams[0].Value = oAbastecimientoEL.id_cisterna;

            arParams[1] = new SqlParameter("@cod_cliente", SqlDbType.Int);
            arParams[1].Value = oAbastecimientoEL.cod_empresa;

            arParams[2] = new SqlParameter("@cod_unidad", SqlDbType.Int);
            arParams[2].Value = oAbastecimientoEL.cod_unidad;      

            arParams[3] = new SqlParameter("@unidad", SqlDbType.VarChar, 50);
            arParams[3].Value = oAbastecimientoEL.unidad;

            arParams[4] = new SqlParameter("@nro_placa", SqlDbType.VarChar, 10);
            arParams[4].Value = oAbastecimientoEL.nro_placa;

            arParams[5] = new SqlParameter("@cnt_inicial", SqlDbType.Decimal);
            arParams[5].Value = oAbastecimientoEL.cnt_inicial;

            arParams[6] = new SqlParameter("@cnt_final", SqlDbType.Decimal);
            arParams[6].Value = oAbastecimientoEL.cnt_final;

            arParams[7] = new SqlParameter("@km_unidad", SqlDbType.Decimal);
            arParams[7].Value = oAbastecimientoEL.km_unidad;

            arParams[8] = new SqlParameter("@horometro", SqlDbType.Decimal);
            arParams[8].Value = oAbastecimientoEL.horometro;

            arParams[9] = new SqlParameter("@nom_conductor", SqlDbType.VarChar,100);
            arParams[9].Value = oAbastecimientoEL.nom_conductor;

            arParams[10] = new SqlParameter("@cantidad_gl", SqlDbType.Decimal);
            arParams[10].Value = oAbastecimientoEL.cantidad_gl;

            arParams[11] = new SqlParameter("@nro_despacho", SqlDbType.VarChar,10);
            arParams[11].Value = oAbastecimientoEL.nro_despacho;

            arParams[12] = new SqlParameter("@nro_precinto1", SqlDbType.VarChar);
            arParams[12].Value = "";

            arParams[13] = new SqlParameter("@nro_precinto2", SqlDbType.VarChar);
            arParams[13].Value = "";

            arParams[14] = new SqlParameter("@fecha", SqlDbType.DateTime);
            arParams[14].Value = oAbastecimientoEL.fecha_liquidacion;

            arParams[15] = new SqlParameter("@abastecedor", SqlDbType.Int);
            arParams[15].Value = oAbastecimientoEL.abastecedor;

            arParams[16] = new SqlParameter("@ticket", SqlDbType.VarChar,20);
            arParams[16].Value = Convert.ToInt32(oAbastecimientoEL.nro_despacho);

            arParams[17] = new SqlParameter("@Usuario", SqlDbType.VarChar, 100);
            arParams[17].Value = oAbastecimientoEL.usuario;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Consumo_Cisterna_v2", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<AbastecimientoEL> AbastecimientoDisponible(AbasteciminetoDisponibleEL oAba)
        {

            SqlParameter[] arParams = new SqlParameter[4];

            arParams[0] = new SqlParameter("@id_TV", SqlDbType.Int);
            arParams[0].Value = oAba.id_TV;

            arParams[1] = new SqlParameter("@id_cliente", SqlDbType.Int);
            arParams[1].Value = oAba.id_cliente;

            arParams[2] = new SqlParameter("@fch_inicio", SqlDbType.Date);
            arParams[2].Value = oAba.fch_inicio;

            arParams[3] = new SqlParameter("@fch_fin", SqlDbType.Date);
            arParams[3].Value = oAba.fch_fin;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Listar_Abastecimiento_FacturacionDisponible",arParams);

            List<AbastecimientoEL> lstItem = new List<AbastecimientoEL>();
            lstItem = Util.ConvertDataTable<AbastecimientoEL>(dt);

            return lstItem;
        }

        public List<AbastecimientoEL> ActualizarLiquidacion(AbastecimientoEL oAba)
        {

            SqlParameter[] arParams = new SqlParameter[2];

            arParams[0] = new SqlParameter("@id_liquidacion", SqlDbType.Int);
            arParams[0].Value = oAba.id_liquidacion;

            arParams[1] = new SqlParameter("@id_abastecimiento", SqlDbType.Int);
            arParams[1].Value = oAba.id_abastecimiento;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Actualizar_Abastecimiento_Liquidacion", arParams);

            List<AbastecimientoEL> lstItem = new List<AbastecimientoEL>();
            lstItem = Util.ConvertDataTable<AbastecimientoEL>(dt);

            return lstItem;
        }

        public List<AbastecimientoEL> ListarAbastecedor()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Listar_Abastecedor");

            List<AbastecimientoEL> lstItem = new List<AbastecimientoEL>();
            lstItem = Util.ConvertDataTable<AbastecimientoEL>(dt);

            return lstItem;
        }

        //REPORTES COMBUSTIBLE

        public List<AbastecimientoEL> ListarReportePlaca(int Año,int mes, string placa,string cliente)
        {

            SqlParameter[] arParams = new SqlParameter[4];

            arParams[0] = new SqlParameter("@YEAR", SqlDbType.Int);
            arParams[0].Value = Año;

            arParams[1] = new SqlParameter("@MONTH", SqlDbType.Int);
            arParams[1].Value = mes;

            arParams[2] = new SqlParameter("@PLATE", SqlDbType.VarChar, 8);
            arParams[2].Value = placa;

            arParams[3] = new SqlParameter("@CLIENT", SqlDbType.VarChar, 200);
            arParams[3].Value = cliente;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Lista_Reporte_Placa", arParams);

            List<AbastecimientoEL> lstItem = new List<AbastecimientoEL>();
            lstItem = Util.ConvertDataTable<AbastecimientoEL>(dt);

            return lstItem;
        }

        public List<AbastecimientoEL> ListarReporteOperacion(int Año, int mes)
        {

            SqlParameter[] arParams = new SqlParameter[2];

            arParams[0] = new SqlParameter("@YEAR", SqlDbType.Int);
            arParams[0].Value = Año;

            arParams[1] = new SqlParameter("@MONTH", SqlDbType.Int);
            arParams[1].Value = mes;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Lista_Reporte_Operacion_Mensual", arParams);

            List<AbastecimientoEL> lstItem = new List<AbastecimientoEL>();
            lstItem = Util.ConvertDataTable<AbastecimientoEL>(dt);

            return lstItem;
        }

        public List<AbastecimientoEL> ListarReporteOperacionAnual(int Año)
        {

            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@YEAR", SqlDbType.Int);
            arParams[0].Value = Año;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Lista_Reporte_Operacion_Anual", arParams);

            List<AbastecimientoEL> lstItem = new List<AbastecimientoEL>();
            lstItem = Util.ConvertDataTable<AbastecimientoEL>(dt);

            return lstItem;
        }

        public List<AbastecimientoEL> ListarReporteVentas(int Año, int mes)
        {

            SqlParameter[] arParams = new SqlParameter[2];

            arParams[0] = new SqlParameter("@YEAR", SqlDbType.Int);
            arParams[0].Value = Año;

            arParams[1] = new SqlParameter("@MONTH", SqlDbType.Int);
            arParams[1].Value = mes;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Lista_Reporte_Venta", arParams);

            List<AbastecimientoEL> lstItem = new List<AbastecimientoEL>();
            lstItem = Util.ConvertDataTable<AbastecimientoEL>(dt);

            return lstItem;
        }


        public List<CombustibleCompraEL> VariacionDieselAnual(int Año)
        {

            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@YEAR", SqlDbType.Int);
            arParams[0].Value = Año;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Lista_Reporte_Variacion_Diesel_ANUAL", arParams);

            List<CombustibleCompraEL> lstItem = new List<CombustibleCompraEL>();
            lstItem = Util.ConvertDataTable<CombustibleCompraEL>(dt);

            return lstItem;
        }

        public List<CombustibleCompraEL> VariacionDieselMensual(int Año, int mes)
        {

            SqlParameter[] arParams = new SqlParameter[2];

            arParams[0] = new SqlParameter("@YEAR", SqlDbType.Int);
            arParams[0].Value = Año;

            arParams[1] = new SqlParameter("@MONTH", SqlDbType.Int);
            arParams[1].Value = mes;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Lista_Reporte_Variacion_Diesel_MENSUAL", arParams);

            List<CombustibleCompraEL> lstItem = new List<CombustibleCompraEL>();
            lstItem = Util.ConvertDataTable<CombustibleCompraEL>(dt);

            return lstItem;
        }
    
  


    }
}
