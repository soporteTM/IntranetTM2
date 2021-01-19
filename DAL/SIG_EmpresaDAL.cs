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
    public class SIG_EmpresaDAL
    {
        public List<SIG_EmpresaEL> ListarSolicitud()
        {
            DataTable dt;
            
            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "EXT_Empresa_Listado_Solicitud");

            List<SIG_EmpresaEL> lstItem = new List<SIG_EmpresaEL>();
            lstItem = Util.ConvertDataTable<SIG_EmpresaEL>(dt);

            return lstItem;
        }

        public List<SIG_EmpresaEL> RepuestaSolicitud(SIG_EmpresaEL oSeguimiento)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@Estado", SqlDbType.Int);
            arParams[0].Value = oSeguimiento.Estado;

            arParams[1] = new SqlParameter("@observacion", SqlDbType.VarChar,500);
            arParams[1].Value = oSeguimiento.Observaciones;

            arParams[2] = new SqlParameter("@Cod_Empresa", SqlDbType.Int);
            arParams[2].Value = oSeguimiento.Cod_Empresa;

            arParams[3] = new SqlParameter("@usuario", SqlDbType.VarChar,200);
            arParams[3].Value = oSeguimiento.usuario_modificacion;


            dt = SqlServerHelper.ReadTable(SqlServerHelper.operaciones, CommandType.StoredProcedure, "EXT_Empresa_Actualizar_Solicitud", arParams);

            List<SIG_EmpresaEL> lstData = new List<SIG_EmpresaEL>();
            lstData = Util.ConvertDataTable<SIG_EmpresaEL>(dt);

            return lstData;


        }
    }
}
