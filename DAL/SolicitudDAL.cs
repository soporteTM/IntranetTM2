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
    public class SolicitudDAL
    {
        public List<SolicitudEL> ListarSolicitud()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "SOL_Listar_Solicitud");

            List<SolicitudEL> lstItem = new List<SolicitudEL>();
            lstItem = Util.ConvertDataTable<SolicitudEL>(dt);

            return lstItem;
        }

        public List<SolicitudEL> ConsultarSolicitud(int id)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "SOL_Consultar_Solicitud",arParams);

            List<SolicitudEL> lstItem = new List<SolicitudEL>();
            lstItem = Util.ConvertDataTable<SolicitudEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> RegistrarSolicitud(SolicitudEL oSolicitud)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[14];
            arParams[0] = new SqlParameter("@cd_cliente", SqlDbType.Int);
            arParams[0].Value = oSolicitud.cd_cliente2;

            arParams[1] = new SqlParameter("@cd_tipo_aduana", SqlDbType.VarChar, 6);
            arParams[1].Value = oSolicitud.cd_tipo_aduana;

            arParams[2] = new SqlParameter("@cd_tipo_mov", SqlDbType.VarChar, 6);
            arParams[2].Value = oSolicitud.cd_tipo_mov;

            arParams[3] = new SqlParameter("@cd_tipo_via", SqlDbType.VarChar, 6);
            arParams[3].Value = oSolicitud.cd_tipo_via;

            arParams[4] = new SqlParameter("@cd_tipo_incoterm", SqlDbType.VarChar, 6);
            arParams[4].Value = oSolicitud.cd_tipo_incoterm;

            arParams[5] = new SqlParameter("@cd_tipo_servicio", SqlDbType.VarChar, 6);
            arParams[5].Value = oSolicitud.cd_tipo_servicio;

            arParams[6] = new SqlParameter("@cd_tipo_cond_emb", SqlDbType.VarChar, 6);
            arParams[6].Value = oSolicitud.cd_tipo_cond_emb;

            arParams[7] = new SqlParameter("@cd_alm_entrada", SqlDbType.VarChar, 6);
            arParams[7].Value = oSolicitud.cd_alm_entrada;

            arParams[8] = new SqlParameter("@cd_alm_devolucion", SqlDbType.VarChar, 6);
            arParams[8].Value = oSolicitud.cd_alm_devolucion;

            arParams[9] = new SqlParameter("@aud_usuario_creacion", SqlDbType.VarChar, 50);
            arParams[9].Value = oSolicitud.aud_usuario_creacion;

            arParams[10] = new SqlParameter("@cd_tipo_solicitud", SqlDbType.VarChar, 6);
            arParams[10].Value = oSolicitud.cd_tipo_solicitud;

            arParams[11] = new SqlParameter("@cd_proveedor", SqlDbType.Int);
            arParams[11].Value = oSolicitud.cd_proveedor;

            arParams[12] = new SqlParameter("@observaciones", SqlDbType.VarChar, 255);
            arParams[12].Value = oSolicitud.observaciones;

            arParams[13] = new SqlParameter("@cd_emp_creacion", SqlDbType.VarChar, 6);
            arParams[13].Value = oSolicitud.cd_emp_creacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "SOL_Registrar_Solicitud", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<SolicitudEL> RegistrarSolicitudTransporte(SolicitudEL oSolicitud)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oSolicitud.cd_sol;

            arParams[1] = new SqlParameter("@cd_tipo_solicitud", SqlDbType.VarChar, 6);
            arParams[1].Value = oSolicitud.cd_tipo_solicitud;

            arParams[2] = new SqlParameter("@cd_proveedor", SqlDbType.Int);
            arParams[2].Value = oSolicitud.cd_proveedor;

            arParams[3] = new SqlParameter("@observaciones", SqlDbType.VarChar, 255);
            arParams[3].Value = oSolicitud.observaciones;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "SOL_Registrar_Solicitud_Transporte", arParams);

            List<SolicitudEL> lstData = new List<SolicitudEL>();
            lstData = Util.ConvertDataTable<SolicitudEL>(dt);

            return lstData;
        }
    }

    public class SolicitudDetalleContenedorDAL
    {
        public List<SolicitudDetalleContenedorEL> ListarDetalleContenedor(int id)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "SOL_Listar_Detalle_Contenedor",arParams);

            List<SolicitudDetalleContenedorEL> lstItem = new List<SolicitudDetalleContenedorEL>();
            lstItem = Util.ConvertDataTable<SolicitudDetalleContenedorEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> RegistrarDetalleContenedor(SolicitudDetalleContenedorEL oContenedor)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[12];
            arParams[0] = new SqlParameter("@cd_sol", SqlDbType.Int);
            arParams[0].Value = oContenedor.cd_sol;

            arParams[1] = new SqlParameter("@cd_item", SqlDbType.Int);
            arParams[1].Value = oContenedor.cd_item;

            arParams[2] = new SqlParameter("@cd_tipo_contenedor", SqlDbType.VarChar, 6);
            arParams[2].Value = oContenedor.cd_tipo_contenedor;

            arParams[3] = new SqlParameter("@pies", SqlDbType.Int);
            arParams[3].Value = oContenedor.pies;

            arParams[4] = new SqlParameter("@prefijo", SqlDbType.VarChar, 6);
            arParams[4].Value = oContenedor.prefijo;

            arParams[5] = new SqlParameter("@num_cnt", SqlDbType.VarChar, 10);
            arParams[5].Value = oContenedor.num_cnt;

            arParams[6] = new SqlParameter("@st1_descarga", SqlDbType.VarChar, 6);
            arParams[6].Value = oContenedor.st1_descarga;

            arParams[7] = new SqlParameter("@st2_descarga", SqlDbType.VarChar, 6);
            arParams[7].Value = oContenedor.st2_descarga;

            arParams[8] = new SqlParameter("@carga_suelta", SqlDbType.VarChar, 1);
            arParams[8].Value = oContenedor.carga_suelta;

            arParams[9] = new SqlParameter("@sol_det_fecha_cita", SqlDbType.DateTime);
            arParams[9].Value = oContenedor.sol_det_fecha_cita;

            arParams[10] = new SqlParameter("@sol_det_hora_cita", SqlDbType.DateTime);
            arParams[10].Value = oContenedor.sol_det_hora_cita;

            arParams[11] = new SqlParameter("@aud_usuario_creacion", SqlDbType.VarChar, 50);
            arParams[11].Value = oContenedor.aud_usuario_creacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "SOL_Registrar_Detalle_Contenedor", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> ImportarContenedor(SolicitudDetalleContenedorEL oContenedor)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[7];
            arParams[0] = new SqlParameter("@cd_sol", SqlDbType.Int);
            arParams[0].Value = oContenedor.cd_sol;

            arParams[1] = new SqlParameter("@cd_item", SqlDbType.Int);
            arParams[1].Value = oContenedor.cd_item;

            arParams[2] = new SqlParameter("@cd_tipo_contenedor", SqlDbType.VarChar, 6);
            arParams[2].Value = oContenedor.cd_tipo_contenedor;

            arParams[3] = new SqlParameter("@pies", SqlDbType.Int);
            arParams[3].Value = oContenedor.pies;

            arParams[4] = new SqlParameter("@prefijo", SqlDbType.VarChar, 6);
            arParams[4].Value = oContenedor.prefijo;

            arParams[5] = new SqlParameter("@num_cnt", SqlDbType.VarChar, 10);
            arParams[5].Value = oContenedor.num_cnt;

            arParams[6] = new SqlParameter("@usuario", SqlDbType.VarChar, 100);
            arParams[6].Value = oContenedor.aud_usuario_creacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "SOL_Importar_Contenedor", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }
    }

    public class SolicitudDetalleDAL
    {
        public List<SolicitudDetalleEL> ListarDetalle(int id)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@sol", SqlDbType.Int);
            arParams[0].Value = id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "SOL_Listar_Detalle", arParams);

            List<SolicitudDetalleEL> lstItem = new List<SolicitudDetalleEL>();
            lstItem = Util.ConvertDataTable<SolicitudDetalleEL>(dt);

            return lstItem;
        }
    }
}
