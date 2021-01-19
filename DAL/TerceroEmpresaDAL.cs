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
    public class TerceroEmpresaDAL
    {
        public List<TerceroEmpresaEL> ListarEmpresa()
        {
            DataTable dt;
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "SIG_Listado_Empresa");

            List<TerceroEmpresaEL> lstItem = new List<TerceroEmpresaEL>();
            lstItem = Util.ConvertDataTable<TerceroEmpresaEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> RegistrarEmpresa(TerceroEmpresaEL oEmpresa)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@Emp_Rsoc", SqlDbType.VarChar,100);
            arParams[0].Value = oEmpresa.Emp_Rsoc;

            arParams[1] = new SqlParameter("@ruc", SqlDbType.VarChar,12);
            arParams[1].Value = oEmpresa.RUC;

            arParams[2] = new SqlParameter("@contacto", SqlDbType.VarChar,100);
            arParams[2].Value = oEmpresa.Contacto;
        
            arParams[3] = new SqlParameter("@telefono", SqlDbType.VarChar,100);
            arParams[3].Value = oEmpresa.telefono;


            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "SIG_Registrar_Empresa", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> ActualizarEmpresa(TerceroEmpresaEL oEmpresa)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[5];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oEmpresa.id;

            arParams[1] = new SqlParameter("@Emp_Rsoc", SqlDbType.VarChar, 100);
            arParams[1].Value = oEmpresa.Emp_Rsoc;

            arParams[2] = new SqlParameter("@ruc", SqlDbType.VarChar, 12);
            arParams[2].Value = oEmpresa.RUC;

            arParams[3] = new SqlParameter("@contacto", SqlDbType.VarChar, 100);
            arParams[3].Value = oEmpresa.Contacto;

            arParams[4] = new SqlParameter("@telefono", SqlDbType.VarChar, 100);
            arParams[4].Value = oEmpresa.telefono;


            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "SIG_Actualizar_Empresa", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<TransaccionEL> EliminarEmpresa(TerceroEmpresaEL oEmpresa)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oEmpresa.id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "SIG_Eliminar_Empresa", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

    }
}
