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
    public class TMS_ClientesDAL
    {
        public List<TMS_ClientesEL> Listar_ClientesSAP(string cod_cliente, string cliente, int esTMS)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[3];
            arParams[0] = new SqlParameter("@cod_cliente", SqlDbType.VarChar, 6);
            arParams[0].Value = cod_cliente;

            arParams[1] = new SqlParameter("@cliente", SqlDbType.VarChar, 100);
            arParams[1].Value = cliente;
        
            arParams[2] = new SqlParameter("@esTMS", SqlDbType.Int);
            arParams[2].Value = esTMS;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TMS_Clientes_SAP", arParams);

            List<TMS_ClientesEL> lstItem = new List<TMS_ClientesEL>();
            lstItem = Util.ConvertDataTable<TMS_ClientesEL>(dt);

            return lstItem;
        }

        public List<TMS_ClientesEL> ListarClientes()
        {
            DataTable dt;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TM_Listar_Clientes_Maestro");

            List<TMS_ClientesEL> lstItem = new List<TMS_ClientesEL>();
            lstItem = Util.ConvertDataTable<TMS_ClientesEL>(dt);

            return lstItem;
        }

        public List<TMS_ClientesEL> ListarClientes(string cod_cliente)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@cod_cliente", SqlDbType.VarChar, 6);
            arParams[0].Value = cod_cliente;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TM_Listar_Clientes_Maestro", arParams);

            List<TMS_ClientesEL> lstItem = new List<TMS_ClientesEL>();
            lstItem = Util.ConvertDataTable<TMS_ClientesEL>(dt);

            return lstItem;
        }

        public List<TMS_SubClientesEL> ListarSubClientes(string cod_cliente)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[1];
            arParams[0] = new SqlParameter("@Cod_Cliente_Padre", SqlDbType.VarChar, 6);
            arParams[0].Value = cod_cliente;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TM_Listar_SubClientes", arParams);

            List<TMS_SubClientesEL> lstItem = new List<TMS_SubClientesEL>();
            lstItem = Util.ConvertDataTable<TMS_SubClientesEL>(dt);

            return lstItem;
        }

        public List<TMS_SubClientesEL> ListarSubClientes(string cod_cliente,string cod_subcliente)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@Cod_Cliente_Padre", SqlDbType.VarChar, 6);
            arParams[0].Value = cod_cliente;

            arParams[1] = new SqlParameter("@Cod_SubCliente", SqlDbType.VarChar, 6);
            arParams[1].Value = cod_subcliente;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TM_Listar_SubClientes", arParams);

            List<TMS_SubClientesEL> lstItem = new List<TMS_SubClientesEL>();
            lstItem = Util.ConvertDataTable<TMS_SubClientesEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> AgregarCliente(string cod_cliente, string razon_social, string ruc, string usuario)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@cod_empresa", SqlDbType.VarChar, 6);
            arParams[0].Value = cod_cliente;

            arParams[1] = new SqlParameter("@raz_soc", SqlDbType.VarChar);
            arParams[1].Value = razon_social;

            arParams[2] = new SqlParameter("@ruc", SqlDbType.VarChar, 11);
            arParams[2].Value = ruc;

            arParams[3] = new SqlParameter("@usuario", SqlDbType.VarChar, 50);
            arParams[3].Value = usuario;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TM_Crear_Cliente", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> AgregarSubCliente(string cod_cliente, string cod_cliente_padre, string razon_social, string ruc, string direccion, string usuario)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[6];
            arParams[0] = new SqlParameter("@cod_empresa_padre", SqlDbType.VarChar, 6);
            arParams[0].Value = cod_cliente_padre;

            arParams[1] = new SqlParameter("@cod_empresa", SqlDbType.VarChar, 6);
            arParams[1].Value = cod_cliente;

            arParams[2] = new SqlParameter("@raz_soc", SqlDbType.VarChar,400);
            arParams[2].Value = razon_social;

            arParams[3] = new SqlParameter("@direccion", SqlDbType.VarChar,500);
            arParams[3].Value = direccion;

            arParams[4] = new SqlParameter("@ruc", SqlDbType.VarChar, 11);
            arParams[4].Value = ruc;
        
            arParams[5] = new SqlParameter("@usuario", SqlDbType.VarChar, 50);
            arParams[5].Value = usuario;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TM_Crear_SubCliente", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> ActualizarCliente(string cod_cliente, string razon_social, string ruc, string usuario)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@cod_cliente", SqlDbType.VarChar, 6);
            arParams[0].Value = cod_cliente;

            arParams[1] = new SqlParameter("@razon_social", SqlDbType.VarChar);
            arParams[1].Value = razon_social;

            arParams[2] = new SqlParameter("@ruc", SqlDbType.VarChar, 11);
            arParams[2].Value = ruc;

            arParams[3] = new SqlParameter("@usuario", SqlDbType.VarChar, 50);
            arParams[3].Value = usuario;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TM_Actualizar_Cliente", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> ActualizarSubCliente(string cod_subcliente, string razon_social, string ruc, string usuario)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[4];
            arParams[0] = new SqlParameter("@cod_subcliente", SqlDbType.VarChar, 6);
            arParams[0].Value = cod_subcliente;

            arParams[1] = new SqlParameter("@razon_social", SqlDbType.VarChar);
            arParams[1].Value = razon_social;

            arParams[2] = new SqlParameter("@ruc", SqlDbType.VarChar, 11);
            arParams[2].Value = ruc;

            arParams[3] = new SqlParameter("@usuario", SqlDbType.VarChar, 50);
            arParams[3].Value = usuario;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TM_Actualizar_SubCliente", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }

        public List<TransaccionEL> EliminarCliente(string cod_cliente, string usuario)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@cod_cliente", SqlDbType.VarChar, 6);
            arParams[0].Value = cod_cliente;

            arParams[1] = new SqlParameter("@usuario", SqlDbType.VarChar, 50);
            arParams[1].Value = usuario;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TM_Eliminar_Cliente", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }

        public void ActualizarHerencia(string cod_cliente, bool herencia)
        {
            

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@cod_cliente", SqlDbType.VarChar, 6);
            arParams[0].Value = cod_cliente;

            arParams[1] = new SqlParameter("@herencia", SqlDbType.Bit);
            arParams[1].Value = herencia;

            SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TM_Actualizar_Herencia_Cliente", arParams);
            
        }

        public void ActualizarConsolidado(string cod_cliente, bool herencia)
        {
            

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@cod_cliente", SqlDbType.VarChar, 6);
            arParams[0].Value = cod_cliente;

            arParams[1] = new SqlParameter("@Consolidado", SqlDbType.Bit);
            arParams[1].Value = herencia;

            SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TM_Actualizar_Consolidar_Cliente", arParams);
            
        }

        public List<TransaccionEL> EliminarSubCliente(string cod_subcliente, string usuario)
        {
            DataTable dt;

            SqlParameter[] arParams = new SqlParameter[2];
            arParams[0] = new SqlParameter("@Cod_SubCliente", SqlDbType.VarChar, 6);
            arParams[0].Value = cod_subcliente;

            arParams[1] = new SqlParameter("@Usuario", SqlDbType.VarChar, 50);
            arParams[1].Value = usuario;

            dt = SqlServerHelper.ReadTable(SqlServerHelper.cnxTransportes, CommandType.StoredProcedure, "TM_Eliminar_SubCliente", arParams);

            List<TransaccionEL> lstItem = new List<TransaccionEL>();
            lstItem = Util.ConvertDataTable<TransaccionEL>(dt);

            return lstItem;
        }
    }
}
