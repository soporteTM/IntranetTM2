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
    public class EquipoProteccionDAL
    {
        public List<EquipoProteccionEL> ListarProteccion(int idPersonal,string tabla)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];

            arParams[0] = new SqlParameter("@id_emp", SqlDbType.Int);
            arParams[0].Value = idPersonal;

            arParams[1] = new SqlParameter("@id_tabla", SqlDbType.VarChar,2);
            arParams[1].Value = tabla;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "EPP_Listar", arParams);

            List<EquipoProteccionEL> lstData = new List<EquipoProteccionEL>();
            lstData = Util.ConvertDataTable<EquipoProteccionEL>(dt);

            return lstData;
        }

        public DataTable ExportarEPP(int idPersonal)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@id_emp", SqlDbType.Int);
            arParams[0].Value = idPersonal;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "EPP_EXPORTAR", arParams);
            

            return dt;
        }


        public List<TransaccionEL> RegistrarEPP(EquipoProteccionEL EquipoEL)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[8];

            arParams[0] = new SqlParameter("@id_emp", SqlDbType.Int);
            arParams[0].Value = EquipoEL.id_emp;

            arParams[1] = new SqlParameter("@cod_equipo", SqlDbType.VarChar,6);
            arParams[1].Value = EquipoEL.cod_equipo;

            arParams[2] = new SqlParameter("@cantidad", SqlDbType.Int);
            arParams[2].Value = EquipoEL.cantidad;

            arParams[3] = new SqlParameter("@fecha_entrega", SqlDbType.Date);
            arParams[3].Value = EquipoEL.fecha_entrega;

            arParams[4] = new SqlParameter("@observacion", SqlDbType.VarChar,200);
            arParams[4].Value = EquipoEL.observacion;

            arParams[5] = new SqlParameter("@tipo", SqlDbType.VarChar,1);
            arParams[5].Value = EquipoEL.Tipo;

            arParams[6] = new SqlParameter("@aud_usuario_creacion", SqlDbType.VarChar,100);
            arParams[6].Value = EquipoEL.aud_usuario_creacion;

            arParams[7] = new SqlParameter("@talla", SqlDbType.VarChar, 50);
            arParams[7].Value = EquipoEL.talla;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "EPP_Insertar", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<EquipoProteccionEL> ListarProteccionHistorico(int idPersonal,string cod_equipo)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];

            arParams[0] = new SqlParameter("@id_emp", SqlDbType.Int);
            arParams[0].Value = idPersonal;

            arParams[1] = new SqlParameter("@cod_equipo", SqlDbType.VarChar,6);
            arParams[1].Value = cod_equipo;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "EPP_Listar_Historico", arParams);

            List<EquipoProteccionEL> lstData = new List<EquipoProteccionEL>();
            lstData = Util.ConvertDataTable<EquipoProteccionEL>(dt);

            return lstData;
        }
    }
}
