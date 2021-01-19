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
    public class OrdTrabajoDetDAL
    {
        public List<OrdTrabajoDetEL> ListarConductores()
        {
            DataTable dt;
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OT_Listar_Conductor_OrdenTrabajo");
            List<OrdTrabajoDetEL> lstItem = new List<OrdTrabajoDetEL>();
            lstItem = Util.ConvertDataTable<OrdTrabajoDetEL>(dt);
            return lstItem;
        }

        public List<OrdTrabajoDetEL> ListarProveedores()
        {
            DataTable dt;
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OT_Listar_Proveedor_OrdenTrabajo");
            List<OrdTrabajoDetEL> lstItem = new List<OrdTrabajoDetEL>();
            lstItem = Util.ConvertDataTable<OrdTrabajoDetEL>(dt);
            return lstItem;

        }

        public List<OrdTrabajoDetEL> ListarTareas(string id_codigo)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@GrupoArticuloCodiMaterial", SqlDbType.VarChar, 50);
            arParams[0].Value = id_codigo;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OT_Listar_Tarea_OrdenTrabajo", arParams);
            List<OrdTrabajoDetEL> lstItem = new List<OrdTrabajoDetEL>();
            lstItem = Util.ConvertDataTable<OrdTrabajoDetEL>(dt);

            return lstItem;
        }

        public List<OrdTrabajoDetEL> ListarMateriales(string id_codigo)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@GrupoArticuloCodigo", SqlDbType.VarChar, 50);
            arParams[0].Value = id_codigo;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OT_Listar_Material_OrdenTrabajo", arParams);
            List<OrdTrabajoDetEL> lstItem = new List<OrdTrabajoDetEL>();
            lstItem = Util.ConvertDataTable<OrdTrabajoDetEL>(dt);

            return lstItem;

        }

        public List<OrdTrabajoDetEL> ListarMaterialesTareas(string id_codigo, string id_tarea)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[2];

            arParams[0] = new SqlParameter("@GrupoArticuloCodiMaterial", SqlDbType.VarChar, 50);
            arParams[0].Value = id_codigo;

            arParams[1] = new SqlParameter("@IdTarea", SqlDbType.VarChar, 500);
            arParams[1].Value = id_tarea;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OT_Listar_Materiales_Tareas", arParams);
            List<OrdTrabajoDetEL> lstItem = new List<OrdTrabajoDetEL>();
            lstItem = Util.ConvertDataTable<OrdTrabajoDetEL>(dt);

            return lstItem;
        }

        public List<OrdTrabajoDetEL> ListarMaterialesOrden(int id_Orden)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@IdOrden", SqlDbType.Int);
            arParams[0].Value = id_Orden;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OT_Listar_Materiales_Orden", arParams);
            List<OrdTrabajoDetEL> lstItem = new List<OrdTrabajoDetEL>();
            lstItem = Util.ConvertDataTable<OrdTrabajoDetEL>(dt);

            return lstItem;

        }


        public List<OrdTrabajoDetEL> ListarMaterialesTareas(string id_codigo)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@GrupoArticuloCodiMaterial", SqlDbType.VarChar, 50);
            arParams[0].Value = id_codigo;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OT_Listar_Materiales_Tareas", arParams);
            List<OrdTrabajoDetEL> lstItem = new List<OrdTrabajoDetEL>();
            lstItem = Util.ConvertDataTable<OrdTrabajoDetEL>(dt);

            return lstItem;
        }

        public void ActualizarCantidadMateriales(decimal cantidad, int codigo, int id_Detalle)
        {

            SqlParameter[] arParams = new SqlParameter[3];

            arParams[0] = new SqlParameter("@GrupoArticuloCodiMaterial", SqlDbType.Int);
            arParams[0].Value = codigo;

            arParams[1] = new SqlParameter("@Cantidad", SqlDbType.Decimal, 5);
            arParams[1].Value = cantidad;


            arParams[2] = new SqlParameter("@IdDetalle", SqlDbType.Int);
            arParams[2].Value = id_Detalle;


            SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OT_Actualizar_Cantidad_Materiales", arParams);
        }


        public List<TransaccionEL> Registrar_DetalleOrdenTrabajo(OrdTrabajoDetEL oDet, string Usuario)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[7];

            arParams[0] = new SqlParameter("@IdDetalle", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Output;
            arParams[0].Value = oDet.IdDetalle;

            arParams[1] = new SqlParameter("@IdOrden", SqlDbType.Int);
            arParams[1].Value = oDet.IdOrden;

            arParams[2] = new SqlParameter("@IdTipo", SqlDbType.VarChar, 50);
            arParams[2].Value = oDet.IdTipo;

            arParams[3] = new SqlParameter("@CodiSistema", SqlDbType.VarChar, 50);
            arParams[3].Value = oDet.CodiSistema;

            arParams[4] = new SqlParameter("@IdTarea", SqlDbType.Int);
            arParams[4].Value = oDet.IdTarea;

            arParams[5] = new SqlParameter("@IdMaterial", SqlDbType.Int);
            arParams[5].Value = oDet.IdMaterial;

            arParams[6] = new SqlParameter("@OrdenUCreacion", SqlDbType.VarChar, 50);
            arParams[6].Value = Usuario;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OT_Registrar_Orden_Trabajo_Detalle", arParams);
            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);
            TransaccionEL e = new TransaccionEL();
            e.id_mensaje = ((System.Data.SqlTypes.SqlInt32)arParams[0].SqlValue).Value;
            lstItem.Add(e);
            return lstItem;

        }

        public List<TransaccionEL> Registrar_DetalleOrdenTrabajoTarea(OrdTrabajoDetEL oDet, string Usuario)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[6];

            arParams[0] = new SqlParameter("@IdDetalle", SqlDbType.Int);
            arParams[0].Value = oDet.IdDetalle;

            arParams[1] = new SqlParameter("@IdOrden", SqlDbType.Int);
            arParams[1].Value = oDet.IdOrden;

            arParams[2] = new SqlParameter("@IdTarea", SqlDbType.Int);
            arParams[2].Value = oDet.IdTarea;

            arParams[3] = new SqlParameter("@IdMaterial", SqlDbType.Int);
            arParams[3].Value = oDet.IdMaterial;

            arParams[4] = new SqlParameter("@CantiMaterial", SqlDbType.Decimal);
            arParams[4].Value = oDet.CantiMaterial;

            arParams[5] = new SqlParameter("@OrdenTareaUCreacion", SqlDbType.VarChar, 50);
            arParams[5].Value = Usuario;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OT_Registrar_Orden_Trabajo_Detalle_Tareas", arParams);
            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);
            return lstItem;

        }

        public List<OrdTrabajoDetEL> Listar_DetalleOrdenesTrabajo_Sistemas_Tareas(int id_Orden)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@IdOrden", SqlDbType.Int);
            arParams[0].Value = id_Orden;
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OT_Listar_DetalleOrdenesTrabajo_Sistemas_Tareas", arParams);
            List<OrdTrabajoDetEL> lstItem = new List<OrdTrabajoDetEL>();
            lstItem = Util.ConvertDataTable<OrdTrabajoDetEL>(dt);
            return lstItem;

        }

    }
}
