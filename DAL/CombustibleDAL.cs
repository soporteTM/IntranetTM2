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
    public class CombustibleDAL
    {
        public List<TransaccionEL> Registar_Combustible(CombustibleEL oCab)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@fecha_inicio", SqlDbType.VarChar,10);
            arParams[0].Value = oCab.fecha_inicio;

            arParams[1] = new SqlParameter("@fecha_corte", SqlDbType.VarChar,10);
            arParams[1].Value = oCab.fecha_corte;

            arParams[2] = new SqlParameter("@usuario_registro", SqlDbType.VarChar, 50);
            arParams[2].Value = oCab.usuario_registro;
        
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Insertar_Combustible", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<CombustibleEL> Listar_Cabecera()
        {
            DataTable dt;
            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Listar_Combustible_Cabecera");
            List<CombustibleEL> lstItem = new List<CombustibleEL>();
            lstItem = Util.ConvertDataTable<CombustibleEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> EliminarCabeceraDetalle(CombustibleEL oCombustible)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@id", SqlDbType.Int);
            arParams[0].Value = oCombustible.id;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Eliminar_Detalle_Combusible", arParams);

            List<TransaccionEL> lstData = new List<TransaccionEL>();
            lstData = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstData;
        }

        public List<CombustibleEL> ConsultarFecha(string fecha_inicio, string fecha_corte)
        {
            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[2];

            arParams[0] = new SqlParameter("@fecha_inicio", SqlDbType.VarChar, 10);
            arParams[0].Value = fecha_inicio;

            arParams[1] = new SqlParameter("@fecha_corte", SqlDbType.VarChar, 10);
            arParams[1].Value = fecha_corte;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Consultar_Fecha_Combustible", arParams);

            List<CombustibleEL> lstData = new List<CombustibleEL>();
            lstData = Util.ConvertDataTable<CombustibleEL>(dt);

            return lstData;
        }


    }

    public class CombustibleCompraDAL
    {
        public List<CombustibleCompraEL> RegistrarCompraCombustible(CombustibleCompraEL oCab)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@precio_compra_cisterna", SqlDbType.Decimal);
            arParams[0].Value = oCab.precio_compra_cisterna;

            arParams[1] = new SqlParameter("@precio_compra_grifo", SqlDbType.Decimal);
            arParams[1].Value = oCab.precio_compra_grifo;

            arParams[2] = new SqlParameter("@fecha_registro", SqlDbType.DateTime);
            arParams[2].Value = Convert.ToDateTime(oCab.fecha_registro);

            arParams[3] = new SqlParameter("@aud_usuario_creacion", SqlDbType.VarChar, 50);
            arParams[3].Value = oCab.usuario;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Insertar_Precio_Compra", arParams);

            List<CombustibleCompraEL> lstData = new List<CombustibleCompraEL>();
            lstData = Util.ConvertDataTable<CombustibleCompraEL>(dt);

            return lstData;
        }

        public List<CombustibleCompraEL> ListarCompraCombustible()
        {

            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Listar_Precio_Compra");

            List<CombustibleCompraEL> lstData = new List<CombustibleCompraEL>();
            lstData = Util.ConvertDataTable<CombustibleCompraEL>(dt);

            return lstData;
        }

        public List<CombustibleCompraEL> EliminarCompraCombustible(CombustibleCompraEL oCab)
        {

            DataTable dt;
            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@id_PC", SqlDbType.Decimal);
            arParams[0].Value = oCab.id_PC;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "CM_Eliminar_Precio_Compra", arParams);

            List<CombustibleCompraEL> lstData = new List<CombustibleCompraEL>();
            lstData = Util.ConvertDataTable<CombustibleCompraEL>(dt);

            return lstData;
        }
    }
}
