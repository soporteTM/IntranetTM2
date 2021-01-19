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
    public class SolicitudDstDAL
    {
        public List<TransaccionEL> RegistrarSolicitud(SolicitudDstEL oSolicitud)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[12];
            arParams[0] = new SqlParameter("@or_viaje", SqlDbType.Int);
            arParams[0].Value = oSolicitud.or_viaje;

            arParams[1] = new SqlParameter("@fch_programada", SqlDbType.DateTime);
            arParams[1].Value = oSolicitud.fch_programada;

            arParams[2] = new SqlParameter("@cd_cliente", SqlDbType.Int);
            arParams[2].Value = oSolicitud.cd_cliente;

            arParams[3] = new SqlParameter("@origen", SqlDbType.VarChar);
            arParams[3].Value = oSolicitud.origen;

            arParams[4] = new SqlParameter("@destino", SqlDbType.VarChar);
            arParams[4].Value = oSolicitud.destino;

            arParams[5] = new SqlParameter("@gr_transporte", SqlDbType.VarChar);
            arParams[5].Value = oSolicitud.gr_transporte;

            arParams[6] = new SqlParameter("@gr_sodimac", SqlDbType.VarChar);
            arParams[6].Value = oSolicitud.gr_sodimac;

            arParams[7] = new SqlParameter("@cd_tipo_unidad", SqlDbType.VarChar, 6);
            arParams[7].Value = oSolicitud.cd_tipo_unidad;

            arParams[8] = new SqlParameter("@pick_ticket", SqlDbType.VarChar);
            arParams[8].Value = oSolicitud.picket_ticket;

            arParams[9] = new SqlParameter("@contenedor", SqlDbType.VarChar);
            arParams[9].Value = oSolicitud.contenedor;

            arParams[10] = new SqlParameter("@observaciones", SqlDbType.VarChar);
            arParams[10].Value = oSolicitud.observaciones;

            arParams[11] = new SqlParameter("@aud_usuario_creacion", SqlDbType.VarChar, 50);
            arParams[11].Value = oSolicitud.aud_usuario_creacion;


            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "[DST_Registrar_Solicitud]", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }





    }
}
