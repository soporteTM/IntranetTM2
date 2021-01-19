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
    public class FlotaDAL
    {
        public List<TransaccionEL> RegistrarFlota(FlotaEL oFlotaEL)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[18];
            arParams[0] = new SqlParameter("@cod_interno", SqlDbType.VarChar,10);
            arParams[0].Value = oFlotaEL.cod_interno;

            arParams[1] = new SqlParameter("@nro_placa", SqlDbType.VarChar, 20);
            arParams[1].Value = oFlotaEL.nro_placa;

            arParams[2] = new SqlParameter("@cod_tipo_vehiculo", SqlDbType.VarChar, 6);
            arParams[2].Value = oFlotaEL.cod_tipo_vehiculo;

            arParams[3] = new SqlParameter("@cod_marca", SqlDbType.VarChar, 6);
            arParams[3].Value = oFlotaEL.cod_marca;

            arParams[4] = new SqlParameter("@cod_modelo", SqlDbType.VarChar, 6);
            arParams[4].Value = oFlotaEL.cod_modelo;

            arParams[5] = new SqlParameter("@color_unidad", SqlDbType.VarChar, 50);
            arParams[5].Value = oFlotaEL.color_unidad;

            arParams[6] = new SqlParameter("@cod_configuracion", SqlDbType.VarChar, 50);
            arParams[6].Value = oFlotaEL.cod_configuracion;

            arParams[7] = new SqlParameter("@anio_unidad", SqlDbType.VarChar, 50);
            arParams[7].Value = oFlotaEL.anio_unidad;

            arParams[8] = new SqlParameter("@cc_num", SqlDbType.Decimal);
            arParams[8].Value = oFlotaEL.cc_num;

            arParams[9] = new SqlParameter("@nro_cilindro", SqlDbType.Int);
            arParams[9].Value = oFlotaEL.nro_cilindro;

            arParams[10] = new SqlParameter("@hp_rpm", SqlDbType.VarChar,10);
            arParams[10].Value = oFlotaEL.hp_rpm;

            arParams[11] = new SqlParameter("@nro_motor", SqlDbType.VarChar, 50);
            arParams[11].Value = oFlotaEL.nro_motor;

            arParams[12] = new SqlParameter("@nro_chasis", SqlDbType.VarChar, 50);
            arParams[12].Value = oFlotaEL.nro_chasis;

            arParams[13] = new SqlParameter("@nro_rueda", SqlDbType.Int);
            arParams[13].Value = oFlotaEL.nro_rueda;

            arParams[14] = new SqlParameter("@nro_eje", SqlDbType.Int);
            arParams[14].Value = oFlotaEL.nro_eje;

            arParams[15] = new SqlParameter("@capacidad", SqlDbType.Int);
            arParams[15].Value = oFlotaEL.capacidad;

            arParams[16] = new SqlParameter("@cod_operacion", SqlDbType.VarChar,6);
            arParams[16].Value = oFlotaEL.cod_operacion;

            arParams[17] = new SqlParameter("@usuario", SqlDbType.VarChar, 50);
            arParams[17].Value = oFlotaEL.aud_usuario_creacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Registrar_Flota", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> ActualizarFlota(FlotaEL oFlotaEL)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[19];

            arParams[0] = new SqlParameter("@cod_flota", SqlDbType.Int);
            arParams[0].Value = oFlotaEL.cod_flota;

            arParams[1] = new SqlParameter("@cod_interno", SqlDbType.VarChar, 5);
            arParams[1].Value = oFlotaEL.cod_interno;

            arParams[2] = new SqlParameter("@nro_placa", SqlDbType.VarChar, 20);
            arParams[2].Value = oFlotaEL.nro_placa;

            arParams[3] = new SqlParameter("@cod_tipo_vehiculo", SqlDbType.VarChar, 6);
            arParams[3].Value = oFlotaEL.cod_tipo_vehiculo;

            arParams[4] = new SqlParameter("@cod_marca", SqlDbType.VarChar, 6);
            arParams[4].Value = oFlotaEL.cod_marca;

            arParams[5] = new SqlParameter("@cod_modelo", SqlDbType.VarChar, 6);
            arParams[5].Value = oFlotaEL.cod_modelo;

            arParams[6] = new SqlParameter("@color_unidad", SqlDbType.VarChar, 50);
            arParams[6].Value = oFlotaEL.color_unidad;

            arParams[7] = new SqlParameter("@cod_configuracion", SqlDbType.VarChar, 50);
            arParams[7].Value = oFlotaEL.cod_configuracion;

            arParams[8] = new SqlParameter("@anio_unidad", SqlDbType.VarChar, 50);
            arParams[8].Value = oFlotaEL.anio_unidad;

            arParams[9] = new SqlParameter("@cc_num", SqlDbType.Decimal);
            arParams[9].Value = oFlotaEL.cc_num;

            arParams[10] = new SqlParameter("@nro_cilindro", SqlDbType.Int);
            arParams[10].Value = oFlotaEL.nro_cilindro;

            arParams[11] = new SqlParameter("@hp_rpm", SqlDbType.VarChar, 10);
            arParams[11].Value = oFlotaEL.hp_rpm;

            arParams[12] = new SqlParameter("@nro_motor", SqlDbType.VarChar, 50);
            arParams[12].Value = oFlotaEL.nro_motor;

            arParams[13] = new SqlParameter("@nro_chasis", SqlDbType.VarChar, 50);
            arParams[13].Value = oFlotaEL.nro_chasis;

            arParams[14] = new SqlParameter("@nro_rueda", SqlDbType.Int);
            arParams[14].Value = oFlotaEL.nro_rueda;

            arParams[15] = new SqlParameter("@nro_eje", SqlDbType.Int);
            arParams[15].Value = oFlotaEL.nro_eje;

            arParams[16] = new SqlParameter("@capacidad", SqlDbType.Int);
            arParams[16].Value = oFlotaEL.capacidad;

            arParams[17] = new SqlParameter("@cod_operacion", SqlDbType.VarChar, 6);
            arParams[17].Value = oFlotaEL.cod_operacion;

            arParams[18] = new SqlParameter("@usuario", SqlDbType.VarChar, 50);
            arParams[18].Value = oFlotaEL.aud_usuario_creacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Actualizar_Flota", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }
        
        public List<FlotaEL> ConsultarFlota(int cod_flota,string nro_placa)
        {
            SqlParameter[] arParams = new SqlParameter[2];

            arParams[0] = new SqlParameter("@cod_flota", SqlDbType.Int);
            arParams[0].Value = cod_flota;

            arParams[1] = new SqlParameter("@nro_placa", SqlDbType.VarChar,10);
            arParams[1].Value = nro_placa;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Consultar_Flota", arParams);

            List<FlotaEL> lstItem = new List<FlotaEL>();
            lstItem = Util.ConvertDataTable<FlotaEL>(dt);

            return lstItem;
        }

        public List<FlotaEL> ConsultarFlota_v2()
        {

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Consultar_Flota_v2");

            List<FlotaEL> lstItem = new List<FlotaEL>();
            lstItem = Util.ConvertDataTable<FlotaEL>(dt);

            return lstItem;
        }

        public List<NeumaticoEL> ConsultarFlotaNeumatico(int cod_flota)
        {
            SqlParameter[] arParams = new SqlParameter[2];

            arParams[0] = new SqlParameter("@cod_flota", SqlDbType.Int);
            arParams[0].Value = cod_flota;

            arParams[1] = new SqlParameter("@nro_placa", SqlDbType.VarChar, 10);
            arParams[1].Value = "";

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Consultar_Flota_Neumaticos", arParams);

            List<NeumaticoEL> lstItem = new List<NeumaticoEL>();
            lstItem = Util.ConvertDataTable<NeumaticoEL>(dt);

            return lstItem;
        }

        public DataTable ConsultarFlota()
        {

            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Exportar_Flota");

            return dt;
        }
    }
}
