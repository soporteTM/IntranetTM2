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
    public class TMS_PreFacturacionDAL
    {
        //public List<TMS_LocalesEL> ListarLocales(string cod_cli)
        //{
        //    DataTable dt;

        //    SqlParameter[] arParams = new SqlParameter[1];
        //    arParams[0] = new SqlParameter("@CLIENTE", SqlDbType.VarChar, 6);
        //    arParams[0].Value = cod_cli;

        //    dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_BuscarLocal", arParams);

        //    List<TMS_LocalesEL> lstItem = new List<TMS_LocalesEL>();
        //    lstItem = Util.ConvertDataTable<TMS_LocalesEL>(dt);

        //    return lstItem;
        //}

        public DataTable ConsultarZona(int pRo, int pSolicitud) {

            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@RO", SqlDbType.VarChar, 6);
            arParams[0].Value = pRo;

            arParams[0] = new SqlParameter("@SOLICITUD", SqlDbType.VarChar, 6);
            arParams[0].Value = pSolicitud;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_ConsultarZona", arParams);

            return dt;
        }

        public DataTable GetCabecera(int pRo, int pSolicitud)
        {
            
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@RO", SqlDbType.Int);
            arParams[0].Value = pRo;

            arParams[1] = new SqlParameter("@SOLICITUD", SqlDbType.Int);
            arParams[1].Value = pSolicitud;

            return SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GetCabeceraFac", arParams);
            
        }

        public DataTable ActualizarFacturacion(string pRo, string pClienteCreacion, string pCliente, string pUsuario, string pCentroCosto, string pSolicitud,
                                            string pRucCliente, string pTipoMovimiento)
        {
            DataTable dt;
            
            SqlParameter[] arParams = new SqlParameter[8];
            arParams[0] = new SqlParameter("@RO", SqlDbType.Int);
            arParams[0].Value = pRo;

            arParams[1] = new SqlParameter("@CLIENTE", SqlDbType.Int);
            arParams[1].Value = pCliente;

            arParams[2] = new SqlParameter("@CLIENTE_DEL_CLIENTE", SqlDbType.Int);
            arParams[2].Value = pClienteCreacion;

            arParams[3] = new SqlParameter("@USUARIO", SqlDbType.Int);
            arParams[3].Value = pUsuario;

            arParams[4] = new SqlParameter("@CONTROCOSTO", SqlDbType.Int);
            arParams[4].Value = pCentroCosto;

            arParams[5] = new SqlParameter("@SOLICITUD", SqlDbType.Int);
            arParams[5].Value = pSolicitud;

            arParams[6] = new SqlParameter("@RUC", SqlDbType.Int);
            arParams[6].Value = pRucCliente;

            arParams[7] = new SqlParameter("@TIPO_MOVIMIENTO", SqlDbType.Int);
            arParams[7].Value = pTipoMovimiento;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_ActualizarFacturacion", arParams);

            return dt;
        }

        public DataTable ActualizarDetalleFacturacion(int pRo, int pSolicitud, string pUsuario, int pDocumento)
        {
            DataTable dt;
            
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@RO", SqlDbType.Int);
            arParams[0].Value = pRo;

            arParams[1] = new SqlParameter("@SOLICITUD", SqlDbType.Int);
            arParams[1].Value = pSolicitud;

            arParams[2] = new SqlParameter("@USUARIO", SqlDbType.Int);
            arParams[2].Value = pUsuario;

            arParams[3] = new SqlParameter("@DOCUMENTO", SqlDbType.Int);
            arParams[3].Value = pDocumento;
            
            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_InsertarDetalleFacturacion", arParams);

            return dt;
        }

        public DataTable GetCabeceraFacturacion(int pDocumento)
        {
            DataTable dt;
            
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@DOCUMENTO", SqlDbType.Int);
            arParams[0].Value = pDocumento;
            
            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_GetCabeceraFacturacion", arParams);

            return dt;
        }

        public DataTable ListarDetalleFacturacion(int pFacId)
        {
            DataTable dt;
            
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@Fac_Id", SqlDbType.Int);
            arParams[0].Value = pFacId;
            
            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_DetalleFacturacionVentas", arParams);

            return dt;
        }

        public DataTable ActualizarCodigoZona(int pAl, int pSol, string pUsuario, string pContenedor)
        {
            DataTable dt;
            
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@RO", SqlDbType.Int);
            arParams[0].Value = pAl;
            arParams[1] = new SqlParameter("@SOLICITUD", SqlDbType.Int);
            arParams[1].Value = pSol;
            arParams[2] = new SqlParameter("@USUARIO", SqlDbType.VarChar, 50);
            arParams[2].Value = pUsuario;
            arParams[3] = new SqlParameter("@CONTENEDOR", SqlDbType.VarChar, 50);
            arParams[3].Value = pContenedor;
            
            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_Actualizar_CodigoZona_V3", arParams);

            return dt;
        }

        public DataTable ActualizarDetalleFacturacionUN(int pRo, int pSolicitud, string pUsuario, int pDocumento)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@RO", SqlDbType.Int);
            arParams[0].Value = pRo;
            arParams[1] = new SqlParameter("@SOLICITUD", SqlDbType.Int);
            arParams[1].Value = pSolicitud;
            arParams[2] = new SqlParameter("@USUARIO", SqlDbType.VarChar, 50);
            arParams[2].Value = pUsuario;
            arParams[3] = new SqlParameter("@DOCUMENTO", SqlDbType.VarChar, 50);
            arParams[3].Value = pDocumento;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_InsertarDetalleFacturacionUN", arParams);

            return dt;
        }

        public DataTable ActualizarZona(int pDetFacId, int pZona, int pTipoContenedor)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@FAC_ID", SqlDbType.Int);
            arParams[0].Value = pDetFacId;

            arParams[1] = new SqlParameter("@ZONA", SqlDbType.Int);
            arParams[1].Value = pZona;

            arParams[2] = new SqlParameter("@TIPO_CONTENEDOR", SqlDbType.Int);
            arParams[2].Value = pTipoContenedor;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "SP_ActualizarZona", arParams);

            return dt;
        }


    }
}
