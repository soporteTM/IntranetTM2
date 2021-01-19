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
    public class DocumentacionDAL
    {
        public List<TransaccionEL> RegistrarDocumentacion(DocumentacionEL oDocumentacion)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@cod_flota", SqlDbType.Int);
            arParams[0].Value = oDocumentacion.cod_flota;

            arParams[1] = new SqlParameter("@cod_documentacion", SqlDbType.VarChar, 6);
            arParams[1].Value = oDocumentacion.cod_documentacion;

            arParams[2] = new SqlParameter("@fch_emision", SqlDbType.VarChar, 20);
            arParams[2].Value = oDocumentacion.fch_emision;

            arParams[3] = new SqlParameter("@fch_vencimiento", SqlDbType.VarChar, 20);
            arParams[3].Value = oDocumentacion.fch_vencimiento;

            arParams[4] = new SqlParameter("@path_doc", SqlDbType.VarChar, 1000);
            arParams[4].Value = oDocumentacion.path_doc;

            arParams[5] = new SqlParameter("@usuario", SqlDbType.VarChar, 20);
            arParams[5].Value = oDocumentacion.aud_usuario_creacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Registrar_Documentacion", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> ActualizarDocumentacion(DocumentacionEL oDocumentacion)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[7];

            arParams[0] = new SqlParameter("@cod_doc", SqlDbType.Int);
            arParams[0].Value = oDocumentacion.cod_doc;

            arParams[1] = new SqlParameter("@cod_flota", SqlDbType.Int);
            arParams[1].Value = oDocumentacion.cod_flota;

            arParams[2] = new SqlParameter("@cod_documentacion", SqlDbType.VarChar, 6);
            arParams[2].Value = oDocumentacion.cod_documentacion;

            arParams[3] = new SqlParameter("@fch_emision", SqlDbType.VarChar, 20);
            arParams[3].Value = oDocumentacion.fch_emision;

            arParams[4] = new SqlParameter("@fch_vencimiento", SqlDbType.VarChar, 20);
            arParams[4].Value = oDocumentacion.fch_vencimiento;

            arParams[5] = new SqlParameter("@path_doc", SqlDbType.VarChar, 1000);
            arParams[5].Value = oDocumentacion.path_doc;

            arParams[6] = new SqlParameter("@usuario", SqlDbType.VarChar, 20);
            arParams[6].Value = oDocumentacion.aud_usuario_creacion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Actualizar_Documentacion", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<DocumentacionEL> ConsultarDocumentacion(int cod_flota)
        {
            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@cod_flota", SqlDbType.Int);
            arParams[0].Value = cod_flota;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Consultar_Documentacion", arParams);

            List<DocumentacionEL> lstItem = new List<DocumentacionEL>();
            lstItem = Util.ConvertDataTable<DocumentacionEL>(dt);

            return lstItem;
        }
    }
}
