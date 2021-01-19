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
    public class TerceroDocumentacionDAL
    {
        public List<TransaccionEL> RegistrarDocumentacion(TerceroDocuementacionEL oDocuemento)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@tipo_doc", SqlDbType.VarChar, 50);
            arParams[0].Value = oDocuemento.tipo_doc;

            arParams[1] = new SqlParameter("@tipo", SqlDbType.VarChar, 50);
            arParams[1].Value = oDocuemento.tipo;

            arParams[2] = new SqlParameter("@id", SqlDbType.Int);
            arParams[2].Value = oDocuemento.id;

            arParams[3] = new SqlParameter("@fecha_registro", SqlDbType.VarChar, 50);
            arParams[3].Value = oDocuemento.fecha_registro;

            arParams[4] = new SqlParameter("@fecha_fin", SqlDbType.VarChar, 50);
            arParams[4].Value = oDocuemento.fecha_fin;

            arParams[5] = new SqlParameter("@documentacion", SqlDbType.VarChar, 50);
            arParams[5].Value = oDocuemento.documentacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "SIG_Registrar_Documentacion", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TerceroDocuementacionEL> ListarDocumentacion(TerceroDocuementacionEL oDocumento)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@tipo", SqlDbType.VarChar,10);
            arParams[0].Value = oDocumento.tipo;

            arParams[1] = new SqlParameter("@id", SqlDbType.Int);
            arParams[1].Value = oDocumento.id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "SIG_Listado_Documentacion", arParams);

            List<TerceroDocuementacionEL> lstItem = new List<TerceroDocuementacionEL>();
            lstItem = Util.ConvertDataTable<TerceroDocuementacionEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> EliminarDocumentacion(TerceroDocuementacionEL oDocuemento)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_doc", SqlDbType.Int);
            arParams[0].Value = oDocuemento.id_doc;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "SIG_Eliminar_Documentacion", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }
    }
}
