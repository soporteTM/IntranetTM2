using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EL;
using SQLHelper;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DescansoMedicoDAL
    {
        public List<DescansoMedicoEL> ListaDescanso(int id , int id_emp, string estadoDM)
        {

            SqlParameter[] arParams = new SqlParameter[3];

            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = id;

            arParams[1] = new SqlParameter("@id_emp", SqlDbType.Int);
            arParams[1].Value = id_emp;

            arParams[2] = new SqlParameter("@estadoDM", SqlDbType.VarChar,1);
            arParams[2].Value = estadoDM;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Consultar_Descanso_v2", arParams);

            List<DescansoMedicoEL> lstItem = new List<DescansoMedicoEL>();
            lstItem = Util.ConvertDataTable<DescansoMedicoEL>(dt);

            return lstItem;
        }

        public List<DescansoMedicoEL> ConsultarFecha(int id_emp, string fecha_inicio, string fecha_fin)
        {

            SqlParameter[] arParams = new SqlParameter[3];

            arParams[0] = new SqlParameter("@id_emp", SqlDbType.Int);
            arParams[0].Value = id_emp;

            arParams[1] = new SqlParameter("@fecha_inicio", SqlDbType.VarChar,10);
            arParams[1].Value = fecha_inicio;

            arParams[2] = new SqlParameter("@fecha_fin", SqlDbType.VarChar,10);
            arParams[2].Value = fecha_fin;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Consultar_Descanso_Fecha", arParams);

            List<DescansoMedicoEL> lstItem = new List<DescansoMedicoEL>();
            lstItem = Util.ConvertDataTable<DescansoMedicoEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> RegistrarDescanso(DescansoMedicoEL DM)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[9];

            arParams[0] = new SqlParameter("@id_emp", SqlDbType.Int);
            arParams[0].Value = DM.id_emp;

            arParams[1] = new SqlParameter("@fecha_inicio", SqlDbType.VarChar, 10);
            arParams[1].Value = DM.diasInicio_des;

            arParams[2] = new SqlParameter("@fecha_fin", SqlDbType.VarChar, 10);
            arParams[2].Value = DM.diasFin_des;

            arParams[3] = new SqlParameter("@total_dias", SqlDbType.Int);
            arParams[3].Value = DM.diasTotal_des;

            arParams[4] = new SqlParameter("@cod_motivo", SqlDbType.VarChar, 6);
            arParams[4].Value = DM.cod_motivo;

            arParams[5] = new SqlParameter("@observacion", SqlDbType.VarChar, 1000);
            arParams[5].Value = DM.observacion_des;

            arParams[6] = new SqlParameter("@cod_clinica", SqlDbType.VarChar, 6);
            arParams[6].Value = DM.cod_clinica;

            arParams[7] = new SqlParameter("@documentacion", SqlDbType.VarChar, 1000);
            arParams[7].Value = DM.documentacion_des;

            arParams[8] = new SqlParameter("@estadoDM", SqlDbType.VarChar, 1);
            arParams[8].Value = DM.estadoDM;
            
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Registrar_Descanso", arParams);
            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }
		
        public List<TransaccionEL> EliminarDM(int id) {

            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = id;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Eliminar_Descanso", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }
        
        public DataTable ExportarDM(DescansoMedicoEL DM)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[3];

            arParams[0] = new SqlParameter("@fecha_inicio", SqlDbType.VarChar, 10);
            arParams[0].Value = DM.diasInicio_des;

            arParams[1] = new SqlParameter("@fecha_fin", SqlDbType.VarChar, 10);
            arParams[1].Value = DM.diasFin_des;

            arParams[2] = new SqlParameter("@cod_tipo", SqlDbType.VarChar, 1);
            arParams[2].Value = DM.estadoDM;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Personal_Consultar_Descanso_Todos", arParams);

            return dt;

        }

        public List<DescansoMedicoEL> BuscarClinica()
        {

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "Listado_Clinica");

            List<DescansoMedicoEL> lstItem = new List<DescansoMedicoEL>();
            lstItem = Util.ConvertDataTable<DescansoMedicoEL>(dt);

            return lstItem;
        }



        //METODO AÑADIDO POR RODRIGO ROJAS:

        public List<TransaccionEL> ConsultarDescanso(DescansoMedicoEL oDescanso)
            {
                DataTable dt;
                SqlParameter[] arParams = new SqlParameter[2];
                arParams[0] = new SqlParameter("@fecha", SqlDbType.Date);
                arParams[0].Value = oDescanso.fecha;

                arParams[1] = new SqlParameter("@id", SqlDbType.Int);
                arParams[1].Value = oDescanso.id_emp;

                dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str, CommandType.StoredProcedure, "BuscarDescanso", arParams);
                List<TransaccionEL> lstData = new List<TransaccionEL>();
                lstData = Util.ConvertDataTable<TransaccionEL>(dt);

                return lstData;
            }
        

    }
}
