using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SQLHelper;
using EL;

namespace DAL
{
   public class ReposicionDAL
    {
        public List<ReposicionEL> ListarReposicion_ADM()
        {
            DataTable dt;
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "TM_Reposicion_ADM");
            List<ReposicionEL> lstItem = new List<ReposicionEL>();
            lstItem = Util.ConvertDataTable<ReposicionEL>(dt);
            return lstItem;
        }

        public List<ReposicionEL> ListarReposicion(ReposicionEL oReposicion)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@usuario_registro", SqlDbType.VarChar, 20);
            arParams[0].Value = oReposicion.usuario_registro;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "TM_Reposicion", arParams);
            List<ReposicionEL> lstItem = new List<ReposicionEL>();
            lstItem = Util.ConvertDataTable<ReposicionEL>(dt);
            return lstItem;
        }

        public List<ReposicionEL> RegistrarReposicion(ReposicionEL oReposicion)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[13];
           

            arParams[0] = new SqlParameter("@n_celular", SqlDbType.VarChar, 10);
            arParams[0].Value = oReposicion.n_celular;

            arParams[1] = new SqlParameter("@empleado", SqlDbType.VarChar, 45);
            arParams[1].Value = oReposicion.empleado;


            arParams[2] = new SqlParameter("@tipo_emp", SqlDbType.VarChar, 45);
            arParams[2].Value = oReposicion.tipo_emp;

            arParams[3] = new SqlParameter("@motivo", SqlDbType.VarChar, 30);
            arParams[3].Value = oReposicion.motivo;


            arParams[4] = new SqlParameter("@placa", SqlDbType.VarChar, 30);
            arParams[4].Value = oReposicion.placa;

            arParams[5] = new SqlParameter("@unidad", SqlDbType.VarChar, 30);
            arParams[5].Value = oReposicion.unidad;

            arParams[6] = new SqlParameter("@area", SqlDbType.VarChar, 30);
            arParams[6].Value = oReposicion.area;

            arParams[7] = new SqlParameter("@plan_equipo", SqlDbType.VarChar, 10);
            arParams[7].Value = oReposicion.plan_equipo;

            arParams[8] = new SqlParameter("@nom_equipo", SqlDbType.VarChar, 20);
            arParams[8].Value = oReposicion.nom_equipo;


            arParams[9] = new SqlParameter("@usuario_registro", SqlDbType.VarChar);
            arParams[9].Value = oReposicion.usuario_registro;

            arParams[10] = new SqlParameter("@usuario_modificacion", SqlDbType.VarChar);
            arParams[10].Value = oReposicion.usuario_modificacion;

            arParams[11] = new SqlParameter("@estado", SqlDbType.Int);
            arParams[11].Value = oReposicion.estado;

            arParams[12] = new SqlParameter("@obs", SqlDbType.VarChar);
            arParams[12].Value = oReposicion.obs;


            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "TM_Registrar_Reposicion", arParams);

            List<ReposicionEL> lstData = new List<ReposicionEL>();
            lstData = Util.ConvertDataTable<ReposicionEL>(dt);

            return lstData;
        }

        public List<ReposicionEL> ActualizarReposicion(ReposicionEL Entidad)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];

            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = Entidad.cod_reposicion;

            arParams[1] = new SqlParameter("@users", SqlDbType.VarChar);
            arParams[1].Value = Entidad.usuario_modificacion;


            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "TM_actualizar_reposicion", arParams);

            List<ReposicionEL> lstData = new List<ReposicionEL>();
            lstData = Util.ConvertDataTable<ReposicionEL>(dt);

            return lstData;

        }

        public List<TransaccionEL> Eliminar_Reposicion(ReposicionEL oreposicionEL)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@cod_reposicion", SqlDbType.Int);
            arParams[0].Value = oreposicionEL.cod_reposicion;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "TM_Eliminar_Reposicion", arParams);
            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);
            return lstItem;
        }

        public List<ReposicionEL> Asignar_Equipo(ReposicionEL Entidad)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[3];

            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = Entidad.cod_reposicion;

            arParams[1] = new SqlParameter("@plan_equipo", SqlDbType.VarChar);
            arParams[1].Value = Entidad.plan_equipo;

            arParams[2] = new SqlParameter("@nom_equipo", SqlDbType.VarChar);
            arParams[2].Value = Entidad.nom_equipo;


            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "TM_Asignar_Equipo", arParams);

            List<ReposicionEL> lstData = new List<ReposicionEL>();
            lstData = Util.ConvertDataTable<ReposicionEL>(dt);

            return lstData;

        }




    }
}
