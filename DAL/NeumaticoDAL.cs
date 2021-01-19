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
    public class NeumaticoDAL
    {
        public List<NeumaticoEL> ConsultarNeumatico(string nro_placa)
        {
            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@nro_placa", SqlDbType.VarChar, 10);
            arParams[0].Value = nro_placa;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Consultar_Neumaticos",arParams);

            List<NeumaticoEL> lstItem = new List<NeumaticoEL>();
            lstItem = Util.ConvertDataTable<NeumaticoEL>(dt);

            return lstItem;
        }

        public List<NeumaticoEL> ListarNeumatico(int id)
        {
            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@id_nm", SqlDbType.Int);
            arParams[0].Value = id;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Listar_Neumaticos", arParams);

            List<NeumaticoEL> lstItem = new List<NeumaticoEL>();
            lstItem = Util.ConvertDataTable<NeumaticoEL>(dt);

            return lstItem;
        }

        public List<NeumaticoEL> ListarNeumaticosReporte(int estado, string fechaInicio, string fechaFin)
        {
            SqlParameter[] arParams = new SqlParameter[3];

            arParams[0] = new SqlParameter("@estado", SqlDbType.Int);
            arParams[0].Value = estado;

            arParams[1] = new SqlParameter("@estado", SqlDbType.DateTime);
            arParams[1].Value = estado;

            arParams[2] = new SqlParameter("@estado", SqlDbType.DateTime);
            arParams[2].Value = estado;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Reporte_Neumaticos", arParams);

            List<NeumaticoEL> lstItem = new List<NeumaticoEL>();
            lstItem = Util.ConvertDataTable<NeumaticoEL>(dt);

            return lstItem;
        }

        public List<NeumaticoEL> ListarNeumaticoHistorico(string Nserie)
        {
            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@nro_serie", SqlDbType.VarChar,50);
            arParams[0].Value = Nserie;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Listar_Neumaticos_Historico", arParams);

            List<NeumaticoEL> lstItem = new List<NeumaticoEL>();
            lstItem = Util.ConvertDataTable<NeumaticoEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> EditarNeumatico(NeumaticoEL obj,int cod)
        {
            SqlParameter[] arParams = new SqlParameter[15];

            arParams[0] = new SqlParameter("@nro_serie", SqlDbType.VarChar, 30);
            arParams[0].Value = obj.nro_serie;

            arParams[1] = new SqlParameter("@cod_marca", SqlDbType.VarChar, 50);
            arParams[1].Value = obj.cod_marca;

            arParams[2] = new SqlParameter("@cod_modelo", SqlDbType.VarChar, 6);
            arParams[2].Value = obj.cod_modelo;

            arParams[3] = new SqlParameter("@precio_costo", SqlDbType.Decimal);
            arParams[3].Value = obj.precio_costo;

            arParams[4] = new SqlParameter("@R1", SqlDbType.Int);
            arParams[4].Value = obj.R1;

            arParams[5] = new SqlParameter("@R2", SqlDbType.Int);
            arParams[5].Value = obj.R2;

            arParams[6] = new SqlParameter("@R3", SqlDbType.Int);
            arParams[6].Value = obj.R3;

            arParams[7] = new SqlParameter("@aud_usuario_creacion", SqlDbType.VarChar, 50);
            arParams[7].Value = obj.aud_usuario_creacion;

            arParams[8] = new SqlParameter("@DOT", SqlDbType.VarChar, 50);
            arParams[8].Value = obj.DOT;

            arParams[9] = new SqlParameter("@medida", SqlDbType.VarChar, 50);
            arParams[9].Value = obj.medida;

            arParams[10] = new SqlParameter("@fecha_compra", SqlDbType.DateTime);
            arParams[10].Value = obj.fecha_compra;

            arParams[11] = new SqlParameter("@proveedor", SqlDbType.VarChar, 50);
            arParams[11].Value = obj.Proveedor;

            arParams[12] = new SqlParameter("@cod_neumatico", SqlDbType.Int);
            arParams[12].Value = cod;

            arParams[13] = new SqlParameter("@diseño", SqlDbType.VarChar,100);
            arParams[13].Value = obj.diseño;

            arParams[14] = new SqlParameter("@reencauche", SqlDbType.Int);
            arParams[14].Value = obj.reencauche;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Editar_Neumatico", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }
        public List<TransaccionEL> RegistrarNeumatico(NeumaticoEL obj)
        {
            SqlParameter[] arParams = new SqlParameter[15];

            arParams[0] = new SqlParameter("@nro_serie", SqlDbType.VarChar, 30);
            arParams[0].Value = obj.nro_serie;

            arParams[1] = new SqlParameter("@cod_marca", SqlDbType.VarChar, 50);
            arParams[1].Value = obj.cod_marca;

            arParams[2] = new SqlParameter("@cod_modelo", SqlDbType.VarChar, 6);
            arParams[2].Value = obj.cod_modelo;

            arParams[3] = new SqlParameter("@precio_costo", SqlDbType.Decimal);
            arParams[3].Value = obj.precio_costo;

            arParams[4] = new SqlParameter("@R1", SqlDbType.Int);
            arParams[4].Value = obj.R1;

            arParams[5] = new SqlParameter("@R2", SqlDbType.Int);
            arParams[5].Value = obj.R2;

            arParams[6] = new SqlParameter("@R3", SqlDbType.Int);
            arParams[6].Value = obj.R3;

            arParams[7] = new SqlParameter("@aud_usuario_creacion", SqlDbType.VarChar, 50);
            arParams[7].Value = obj.aud_usuario_creacion;

            arParams[8] = new SqlParameter("@DOT", SqlDbType.VarChar, 50);
            arParams[8].Value = obj.DOT;

            arParams[9] = new SqlParameter("@medida", SqlDbType.VarChar, 50);
            arParams[9].Value = obj.medida;

            arParams[10] = new SqlParameter("@fecha_compra", SqlDbType.DateTime);
            arParams[10].Value = obj.fecha_compra;

            arParams[11] = new SqlParameter("@proveedor", SqlDbType.VarChar, 50);
            arParams[11].Value = obj.Proveedor;

            arParams[12] = new SqlParameter("@diseño", SqlDbType.VarChar, 100);
            arParams[12].Value = obj.diseño;


            arParams[13] = new SqlParameter("@Reencauche", SqlDbType.Int);
            arParams[13].Value = obj.reencauche;

            arParams[14] = new SqlParameter("@tipo_moneda", SqlDbType.VarChar,6);
            arParams[14].Value = obj.tipo_moneda;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Registrar_Neumatico", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> RegistrarNeumaticoFlota(NeumaticoEL obj,int estado)
        {
            SqlParameter[] arParams = new SqlParameter[10];

            arParams[0] = new SqlParameter("@id_nm", SqlDbType.VarChar, 30);
            arParams[0].Value = obj.id_nm;

            arParams[1] = new SqlParameter("@cod_flota", SqlDbType.VarChar, 6);
            arParams[1].Value = obj.cod_flota;

            arParams[2] = new SqlParameter("@pos", SqlDbType.VarChar, 6);
            arParams[2].Value = obj.pos;

            arParams[3] = new SqlParameter("@Km", SqlDbType.Decimal);
            arParams[3].Value = obj.km_actual;

            arParams[4] = new SqlParameter("@r1", SqlDbType.Int);
            arParams[4].Value = obj.R1;

            arParams[5] = new SqlParameter("@r2", SqlDbType.Int);
            arParams[5].Value = obj.R2;

            arParams[6] = new SqlParameter("@r3", SqlDbType.Int);
            arParams[6].Value = obj.R3;

            arParams[7] = new SqlParameter("@aud_usuario_creacion", SqlDbType.VarChar, 50);
            arParams[7].Value = obj.aud_usuario_creacion;

            arParams[8] = new SqlParameter("@estado", SqlDbType.Int);
            arParams[8].Value = estado;

            arParams[9] = new SqlParameter("@fecha", SqlDbType.DateTime);
            arParams[9].Value = obj.fecha;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Registrar_Neumatico_Flota", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }

        public List<NeumaticoEL> RegistrarReencauche(NeumaticoEL obj)
        {
            SqlParameter[] arParams = new SqlParameter[9];

            arParams[0] = new SqlParameter("@nro_serie", SqlDbType.VarChar, 30);
            arParams[0].Value = obj.nro_serie;

            arParams[1] = new SqlParameter("@cod_marca", SqlDbType.VarChar, 50);
            arParams[1].Value = obj.cod_marca;

            arParams[2] = new SqlParameter("@cod_modelo", SqlDbType.VarChar, 6);
            arParams[2].Value = obj.cod_modelo;

            arParams[3] = new SqlParameter("@precio_costo", SqlDbType.Decimal);
            arParams[3].Value = obj.precio_costo;

            arParams[4] = new SqlParameter("@R1", SqlDbType.Int);
            arParams[4].Value = obj.R1;

            arParams[5] = new SqlParameter("@R2", SqlDbType.Int);
            arParams[5].Value = obj.R2;

            arParams[6] = new SqlParameter("@R3", SqlDbType.Int);
            arParams[6].Value = obj.R3;

            //arParams[7] = new SqlParameter("@estado_cd", SqlDbType.VarChar, 100);
            //arParams[7].Value = obj.estado_cd;

            arParams[7] = new SqlParameter("@aud_usuario_creacion", SqlDbType.VarChar, 50);
            arParams[7].Value = obj.aud_usuario_creacion;

            arParams[8] = new SqlParameter("@diseño", SqlDbType.VarChar, 100);
            arParams[8].Value = obj.diseño;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Registrar_Reencauche", arParams);

            List<NeumaticoEL> lstItem = new List<NeumaticoEL>();
            lstItem = Util.ConvertDataTable<NeumaticoEL>(dt);

            return lstItem;
        }

        public List<RendimientoEL> RendimientoNeumatico(string nro_placa)
        {
            SqlParameter[] arParams = new SqlParameter[1];

            arParams[0] = new SqlParameter("@nro_placa", SqlDbType.VarChar, 10);
            arParams[0].Value = nro_placa;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Rendimiento_Neumaticos", arParams);

            List<RendimientoEL> lstItem = new List<RendimientoEL>();
            lstItem = Util.ConvertDataTable<RendimientoEL>(dt);

            return lstItem;
        }

        public List<NeumaticoEL> EliminarNeumatico(int id_nm,string usuario)
        {
            SqlParameter[] arParams = new SqlParameter[2];

            arParams[0] = new SqlParameter("@id_nm", SqlDbType.Int);
            arParams[0].Value = id_nm;

            arParams[1] = new SqlParameter("@aud_usuario_modificacion", SqlDbType.VarChar,60);
            arParams[1].Value = id_nm;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Eliminar_Neumatico", arParams);

            List<NeumaticoEL> lstItem = new List<NeumaticoEL>();
            lstItem = Util.ConvertDataTable<NeumaticoEL>(dt);

            return lstItem;
        }

        public List<NeumaticoEL> EliminarNeumatico(int id_nm, string usuario, string cod_motivo, string R1, string R2, string R3, double kilometraje, string obs)
        {
            SqlParameter[] arParams = new SqlParameter[7];

            arParams[0] = new SqlParameter("@id_nm", SqlDbType.Int);
            arParams[0].Value = id_nm;

            arParams[1] = new SqlParameter("@aud_usuario_modificacion", SqlDbType.VarChar, 60);
            arParams[1].Value = usuario;

            arParams[2] = new SqlParameter("@cod_motivo", SqlDbType.VarChar, 6);
            arParams[2].Value = cod_motivo;

            arParams[3] = new SqlParameter("@R1", SqlDbType.Int);
            arParams[3].Value = R1;

            arParams[4] = new SqlParameter("@R2", SqlDbType.Int);
            arParams[4].Value = R2;

            arParams[5] = new SqlParameter("@R3", SqlDbType.Int);
            arParams[5].Value = R3;

            arParams[6] = new SqlParameter("@Kilometraje", SqlDbType.Decimal);
            arParams[6].Value = kilometraje;

            arParams[7] = new SqlParameter("@Observacion", SqlDbType.VarChar, 200);
            arParams[7].Value = obs;

            DataTable dt = SqlServerHelper.ReadTable(SqlServerHelper.default_connection_str2, CommandType.StoredProcedure, "TM_Eliminar_Neumatico_v3", arParams);

            List<NeumaticoEL> lstItem = new List<NeumaticoEL>();
            lstItem = Util.ConvertDataTable<NeumaticoEL>(dt);

            return lstItem;
        }
    }
}
