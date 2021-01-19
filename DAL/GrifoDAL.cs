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
    public class GrifoDAL
    {
        public List<TransaccionEL> RegistarGrifo(GrifoEL oGrifo)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@Estacion_nom", SqlDbType.VarChar, 100);
            arParams[0].Value = oGrifo.Estacion_nom;

            arParams[1] = new SqlParameter("@fecha_inicio", SqlDbType.Date);
            arParams[1].Value = oGrifo.Fecha_Inicio;

            arParams[2] = new SqlParameter("@fecha_fin", SqlDbType.Date);
            arParams[2].Value = oGrifo.Fecha_Fin;

            arParams[3] = new SqlParameter("@usuario", SqlDbType.VarChar, 50);
            arParams[3].Value = oGrifo.aud_usuario_creacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Grifo_Registrar", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<GrifoEL> ListarGrifo()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Grifo_Listar");

            List<GrifoEL> lstData = new List<GrifoEL>();
            lstData = Util.ConvertDataTable<GrifoEL>(dt);

            return lstData;
        }
        public List<GrifoEL> CerrarGrifo(int cod)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_Estacion", SqlDbType.Int);
            arParams[0].Value = cod;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Grifo_Cerrar",arParams);

            List<GrifoEL> lstData = new List<GrifoEL>();
            lstData = Util.ConvertDataTable<GrifoEL>(dt);

            return lstData;
        }
    }

    public class GrifoDetDAL
    {
        
        public DataTable ReporteGrifoDet(int cod)
        {
            {
                DataTable dt;

                SqlParameter[] arParams = new SqlParameter[1];
                arParams[0] = new SqlParameter("@id_grifo", SqlDbType.Int);
                arParams[0].Value = cod;

                dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Grifo_Consumo_Listar_Exportar", arParams);

                return dt;
            }
        }

        public List<TransaccionEL> RegistarGrifoDet(GrifoDetEL oGrifoDet)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[16];

            arParams[0] = new SqlParameter("@id_Estacion", SqlDbType.Int);
            arParams[0].Value = oGrifoDet.id_Estacion;

            arParams[1] = new SqlParameter("@cod_cliente", SqlDbType.Int);
            arParams[1].Value = oGrifoDet.cod_cliente;

            arParams[2] = new SqlParameter("@fecha_registro", SqlDbType.DateTime);
            arParams[2].Value = oGrifoDet.fecha_registro;

            arParams[3] = new SqlParameter("@nr_despacho", SqlDbType.VarChar, 6);
            arParams[3].Value = oGrifoDet.nro_despacho;

            arParams[4] = new SqlParameter("@id_abastecedor", SqlDbType.Int);
            arParams[4].Value = oGrifoDet.id_abastecedor;

            arParams[5] = new SqlParameter("@nom_conductor", SqlDbType.VarChar, 300);
            arParams[5].Value = oGrifoDet.nom_conductor;

            arParams[6] = new SqlParameter("@cod_unidad", SqlDbType.VarChar, 6);
            arParams[6].Value = oGrifoDet.cod_unidad;

            arParams[7] = new SqlParameter("@unidad", SqlDbType.VarChar, 50);
            arParams[7].Value = oGrifoDet.unidad;

            arParams[8] = new SqlParameter("@nro_placa", SqlDbType.VarChar, 20);
            arParams[8].Value = oGrifoDet.nro_placa;

            arParams[9] = new SqlParameter("@km_unidad", SqlDbType.Decimal);
            arParams[9].Value = oGrifoDet.km_unidad;

            arParams[10] = new SqlParameter("@horometro", SqlDbType.Decimal);
            arParams[10].Value = oGrifoDet.horometro;

            arParams[11] = new SqlParameter("@cantidadl_gl", SqlDbType.Decimal);
            arParams[11].Value = oGrifoDet.cantidad_gl;

            arParams[12] = new SqlParameter("@precio_galon_igv", SqlDbType.Decimal);
            arParams[12].Value = oGrifoDet.precio_galon_igv;

            arParams[13] = new SqlParameter("@usuario", SqlDbType.VarChar, 100);
            arParams[13].Value = oGrifoDet.aud_usuario_creacion;

            arParams[14] = new SqlParameter("@NDS", SqlDbType.VarChar, 100);
            arParams[14].Value = oGrifoDet.NDS;

            arParams[15] = new SqlParameter("@nom_estacion", SqlDbType.VarChar, 100);
            arParams[15].Value = oGrifoDet.nom_estacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Grifo_Consumo_Registrar", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<GrifoDetEL> ListarGrifoDet(int cod)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_grifo", SqlDbType.Int);
            arParams[0].Value = cod;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Grifo_Consumo_Listar",arParams);

            List<GrifoDetEL> lstData = new List<GrifoDetEL>();
            lstData = Util.ConvertDataTable<GrifoDetEL>(dt);

            return lstData;
        }

        public List<GrifoDetEL> EliminarGrifoDet(int cod)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_consumo_estacion", SqlDbType.Int);
            arParams[0].Value = cod;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Eliminar_Consumo_Grifo", arParams);

            List<GrifoDetEL> lstData = new List<GrifoDetEL>();
            lstData = Util.ConvertDataTable<GrifoDetEL>(dt);

            return lstData;
        }

        public List<GrifoDetEL> ListarGrifoDet(int cod,int cli)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@id_grifo", SqlDbType.Int);
            arParams[0].Value = cod;

            arParams[1] = new SqlParameter("@cliente", SqlDbType.Int);
            arParams[1].Value = cli;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Grifo_Consumo_Listar", arParams);

            List<GrifoDetEL> lstData = new List<GrifoDetEL>();
            lstData = Util.ConvertDataTable<GrifoDetEL>(dt);

            return lstData;
        }
    }
}
