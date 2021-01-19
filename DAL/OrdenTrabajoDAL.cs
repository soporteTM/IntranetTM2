using DAL;
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
    public class OrdenTrabajoDAL
    {
        public List<TransaccionEL> RegistrarOT(OrdenTrabajoEL oOrden)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[14];
            arParams[0] = new SqlParameter("@nro_orden", SqlDbType.Int);
            arParams[0].Value = oOrden.nro_orden;

            arParams[1] = new SqlParameter("@cod_proveedor", SqlDbType.VarChar, 50);
            arParams[1].Value = oOrden.cod_proveedor;

            arParams[2] = new SqlParameter("@nom_proveedor", SqlDbType.VarChar, 100);
            arParams[2].Value = oOrden.nom_proveedor;

            arParams[3] = new SqlParameter("@fch_emision", SqlDbType.DateTime);
            arParams[3].Value = oOrden.fch_emision;

            arParams[4] = new SqlParameter("@hora_inicio", SqlDbType.DateTime);
            arParams[4].Value = oOrden.hora_inicio;

            arParams[5] = new SqlParameter("@hora_fin", SqlDbType.DateTime);
            arParams[5].Value = oOrden.hora_fin;

            arParams[6] = new SqlParameter("@cod_flota", SqlDbType.Int);
            arParams[6].Value = oOrden.cod_flota;

            arParams[7] = new SqlParameter("@km_flota", SqlDbType.Decimal);
            arParams[7].Value = oOrden.km_flota;

            arParams[8] = new SqlParameter("@cod_conductor", SqlDbType.Int);
            arParams[8].Value = oOrden.cod_conductor;

            arParams[9] = new SqlParameter("@cod_tipo_servicio", SqlDbType.VarChar,6);
            arParams[9].Value = oOrden.cod_tipo_servicio;

            arParams[10] = new SqlParameter("@cod_mantenimiento", SqlDbType.VarChar, 6);
            arParams[10].Value = oOrden.cod_mantenimiento;

            arParams[11] = new SqlParameter("@cod_taller", SqlDbType.VarChar, 6);
            arParams[11].Value = oOrden.cod_taller;

            arParams[12] = new SqlParameter("@horometro", SqlDbType.Decimal);
            arParams[12].Value = oOrden.horometro_flota;

            arParams[13] = new SqlParameter("@usuario", SqlDbType.VarChar,50);
            arParams[13].Value = oOrden.aud_usuario_creacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Registrar_Orden", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> ActualizarOT(OrdenTrabajoEL oOrden)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[14];
            arParams[0] = new SqlParameter("@id_orden", SqlDbType.Int);
            arParams[0].Value = oOrden.id_orden;

            arParams[1] = new SqlParameter("@cod_proveedor", SqlDbType.VarChar, 50);
            arParams[1].Value = oOrden.cod_proveedor;

            arParams[2] = new SqlParameter("@nom_proveedor", SqlDbType.VarChar, 100);
            arParams[2].Value = oOrden.nom_proveedor;

            arParams[3] = new SqlParameter("@fch_emision", SqlDbType.DateTime);
            arParams[3].Value = oOrden.fch_emision;

            arParams[4] = new SqlParameter("@hora_inicio", SqlDbType.DateTime);
            arParams[4].Value = oOrden.hora_inicio;

            arParams[5] = new SqlParameter("@hora_fin", SqlDbType.DateTime);
            arParams[5].Value = oOrden.hora_fin;

            arParams[6] = new SqlParameter("@cod_flota", SqlDbType.Int);
            arParams[6].Value = oOrden.cod_flota;

            arParams[7] = new SqlParameter("@km_flota", SqlDbType.Decimal);
            arParams[7].Value = oOrden.km_flota;

            arParams[8] = new SqlParameter("@cod_conductor", SqlDbType.Int);
            arParams[8].Value = oOrden.cod_conductor;

            arParams[9] = new SqlParameter("@cod_tipo_servicio", SqlDbType.VarChar, 6);
            arParams[9].Value = oOrden.cod_tipo_servicio;

            arParams[10] = new SqlParameter("@cod_mantenimiento", SqlDbType.VarChar, 6);
            arParams[10].Value = oOrden.cod_mantenimiento;

            arParams[11] = new SqlParameter("@cod_taller", SqlDbType.VarChar, 6);
            arParams[11].Value = oOrden.cod_taller;

            arParams[12] = new SqlParameter("@horometro", SqlDbType.Decimal);
            arParams[12].Value = oOrden.horometro_flota;

            arParams[13] = new SqlParameter("@usuario", SqlDbType.VarChar, 50);
            arParams[13].Value = oOrden.aud_usuario_creacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Actualizar_Orden", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }
        public List<OrdenTrabajoEL> ListarOT(int id_orden)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_orden", SqlDbType.Int);
            arParams[0].Value = id_orden;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Mantenimiento_Consultar",arParams);

            List<OrdenTrabajoEL> lstItem = new List<OrdenTrabajoEL>();
            lstItem = Util.ConvertDataTable<OrdenTrabajoEL>(dt);

            return lstItem;
        }

    }
}
