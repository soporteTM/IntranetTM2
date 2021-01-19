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
    public class OrdTrabajoDAL
    {

        public List<TransaccionEL> Registrar_OrdTrabajo(OrdTrabajoEL oTarEL, string Usuario)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[19];

            arParams[0] = new SqlParameter("@IdOrden", SqlDbType.Int);
            arParams[0].Direction = ParameterDirection.Output;
            arParams[0].Value = oTarEL.IdOrden;

            arParams[1] = new SqlParameter("@Fecha", SqlDbType.VarChar, 50);
            arParams[1].Value = oTarEL.Fecha;

            arParams[2] = new SqlParameter("@HoraIngreso", SqlDbType.VarChar, 50);
            arParams[2].Value = oTarEL.HoraIngreso;

            arParams[3] = new SqlParameter("@HoraSalida", SqlDbType.VarChar, 50);
            arParams[3].Value = oTarEL.HoraSalida;

            arParams[4] = new SqlParameter("@Duracion", SqlDbType.Decimal, 5);
            arParams[4].Value = oTarEL.Duracion;

            arParams[5] = new SqlParameter("@PlacaTracto", SqlDbType.VarChar, 50);
            arParams[5].Value = oTarEL.PlacaTracto;

            arParams[6] = new SqlParameter("@PlacaSemirremolque", SqlDbType.VarChar, 50);
            arParams[6].Value = oTarEL.PlacaSemirremolque;

            arParams[7] = new SqlParameter("@DescKilometraje", SqlDbType.VarChar, 50);
            arParams[7].Value = oTarEL.DescKilometraje;

            arParams[8] = new SqlParameter("@Horometro", SqlDbType.VarChar, 50);
            arParams[8].Value = oTarEL.Horometro;

            arParams[9] = new SqlParameter("@Tecnico", SqlDbType.VarChar, 50);
            arParams[9].Value = oTarEL.Tecnico;

            arParams[10] = new SqlParameter("@id_conductor", SqlDbType.VarChar,10);
            arParams[10].Value = oTarEL.nro_documento;

            arParams[11] = new SqlParameter("@CodiSede", SqlDbType.VarChar, 50);
            arParams[11].Value = oTarEL.CodiSede;

            arParams[12] = new SqlParameter("@CodiServicio", SqlDbType.VarChar, 50);
            arParams[12].Value = oTarEL.CodiServicio;

            arParams[13] = new SqlParameter("@ServRealizado", SqlDbType.VarChar, 50);
            arParams[13].Value = oTarEL.ServRealizado;

            arParams[14] = new SqlParameter("@GrupoArticuloCodiMaterial", SqlDbType.VarChar, 50);
            arParams[14].Value = oTarEL.GrupoArticuloCodiMaterial;

            arParams[15] = new SqlParameter("@IdProveedor", SqlDbType.Int);
            arParams[15].Value = oTarEL.IdProveedor;

            arParams[16] = new SqlParameter("@IDTipoApertura", SqlDbType.Int);
            arParams[16].Value = oTarEL.TipoApertura;

            arParams[17] = new SqlParameter("@Descripcion", SqlDbType.VarChar, 500);
            arParams[17].Value = oTarEL.Descripcion;

            arParams[18] = new SqlParameter("@OrdenUCreacion", SqlDbType.VarChar, 50);
            arParams[18].Value = Usuario;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OT_Insertar_Orden_Trabajo", arParams);
            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);
            TransaccionEL e = new TransaccionEL();
            e.id_mensaje = ((System.Data.SqlTypes.SqlInt32)arParams[0].SqlValue).Value;
            lstItem.Add(e);
            return lstItem;

        }

        public List<OrdTrabajoEL> Listar_OrdenesTrabajo() 
        {
            DataTable dt;
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OT_Listar_Ordenes_Trabajo");
            List<OrdTrabajoEL> lstItem = new List<OrdTrabajoEL>();
            lstItem = Util.ConvertDataTable<OrdTrabajoEL>(dt);
            return lstItem;

        }

        public List<OrdTrabajoEL> Listar_DetalleOrdenesTrabajos(int id_Orden)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@IdOrden", SqlDbType.Int);
            arParams[0].Value = id_Orden;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OT_Listar_Orden_Trabajo_Detalle", arParams);
            List<OrdTrabajoEL> lstItem = new List<OrdTrabajoEL>();
            lstItem = Util.ConvertDataTable<OrdTrabajoEL>(dt);
            return lstItem;
        }

        public List<TransaccionEL> Editar_OrdenTrabajo(OrdTrabajoEL oTarEL, int id_Orden, string Usuario)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[17];

            arParams[0] = new SqlParameter("@IdOrden", SqlDbType.Int);
            arParams[0].Value = id_Orden;

            arParams[1] = new SqlParameter("@Fecha", SqlDbType.VarChar, 50);
            arParams[1].Value = oTarEL.Fecha;

            arParams[2] = new SqlParameter("@HoraIngreso", SqlDbType.VarChar, 50);
            arParams[2].Value = oTarEL.HoraIngreso;

            arParams[3] = new SqlParameter("@HoraSalida", SqlDbType.VarChar, 50);
            arParams[3].Value = oTarEL.HoraSalida;

            //arParams[4] = new SqlParameter("@Duracion", SqlDbType.Decimal, 5);
            //arParams[4].Value = oTarEL.Duracion;

            arParams[4] = new SqlParameter("@PlacaTracto", SqlDbType.VarChar, 50);
            arParams[4].Value = oTarEL.PlacaTracto;

            arParams[5] = new SqlParameter("@PlacaSemirremolque", SqlDbType.VarChar, 50);
            arParams[5].Value = oTarEL.PlacaSemirremolque;

            arParams[6] = new SqlParameter("@DescKilometraje", SqlDbType.VarChar, 50);
            arParams[6].Value = oTarEL.DescKilometraje;

            arParams[7] = new SqlParameter("@Horometro", SqlDbType.VarChar, 50);
            arParams[7].Value = oTarEL.Horometro;

            arParams[8] = new SqlParameter("@Tecnico", SqlDbType.VarChar, 50);
            arParams[8].Value = oTarEL.Tecnico;

            arParams[9] = new SqlParameter("@id_conductor", SqlDbType.VarChar,10);
            arParams[9].Value = oTarEL.nro_documento;

            arParams[10] = new SqlParameter("@CodiSede", SqlDbType.VarChar, 50);
            arParams[10].Value = oTarEL.CodiSede;

            arParams[11] = new SqlParameter("@CodiServicio", SqlDbType.VarChar, 50);
            arParams[11].Value = oTarEL.CodiServicio;

            arParams[12] = new SqlParameter("@ServRealizado", SqlDbType.VarChar, 50);
            arParams[12].Value = oTarEL.ServRealizado;

            arParams[13] = new SqlParameter("@GrupoArticuloCodiMaterial", SqlDbType.VarChar, 50);
            arParams[13].Value = oTarEL.GrupoArticuloCodiMaterial;

            arParams[14] = new SqlParameter("@IdProveedor", SqlDbType.Int);
            arParams[14].Value = oTarEL.IdProveedor;

            arParams[15] = new SqlParameter("@Descripcion", SqlDbType.VarChar, 500);
            arParams[15].Value = oTarEL.Descripcion;

            arParams[16] = new SqlParameter("@OrdenUCreacion", SqlDbType.VarChar, 50);
            arParams[16].Value = Usuario;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OT_Editar_Orden_Trabajo", arParams);
            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);
            return lstItem;

        }


        public List<OrdTrabajoEL> Eliminar_OrdenTrabajo(int id_Orden)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@IdOrden", SqlDbType.Int);
            arParams[0].Value = id_Orden;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "OT_Eliminar_Orden_Trabajo", arParams);

            List<OrdTrabajoEL> lstItem = new List<OrdTrabajoEL>();
            lstItem = Util.ConvertDataTable<OrdTrabajoEL>(dt);
            return lstItem;


        }

    }
}
