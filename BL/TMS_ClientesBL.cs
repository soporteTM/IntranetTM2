using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TMS_ClientesBL
    {
        public List<TMS_ClientesEL> Listar_ClientesSAP(string cod_cliente, string cliente, int esTMS)
        {
            TMS_ClientesDAL oClientes = new TMS_ClientesDAL();
            return oClientes.Listar_ClientesSAP(cod_cliente, cliente ,esTMS);
        }

        public List<TMS_ClientesEL> ListarClientes()
        {
            TMS_ClientesDAL oClientes = new TMS_ClientesDAL();
            return oClientes.ListarClientes();
        }

        public List<TMS_ClientesEL> ListarClientes(string cod_cliente)
        {
            TMS_ClientesDAL oClientes = new TMS_ClientesDAL();
            return oClientes.ListarClientes(cod_cliente);
        }

        public List<TMS_SubClientesEL> ListarSubClientes(string cod_cliente)
        {
            TMS_ClientesDAL oClientes = new TMS_ClientesDAL();
            return oClientes.ListarSubClientes(cod_cliente);
        }

        public List<TMS_SubClientesEL> ListarSubClientes(string cod_cliente, string cod_subcliente)
        {
            TMS_ClientesDAL oClientes = new TMS_ClientesDAL();
            return oClientes.ListarSubClientes(cod_cliente,cod_subcliente);
        }

        public List<TransaccionEL> AgregarCliente(string cod_cliente, string razon_social, string ruc, string usuario)
        {
            TMS_ClientesDAL oClientes = new TMS_ClientesDAL();
            return oClientes.AgregarCliente(cod_cliente, razon_social, ruc, usuario);
        }

        public List<TransaccionEL> AgregarSubCliente(string cod_cliente, string cod_cliente_padre, string razon_social, string ruc, string direccion, string usuario)
        {
            TMS_ClientesDAL oClientes = new TMS_ClientesDAL();
            return oClientes.AgregarSubCliente(cod_cliente, cod_cliente_padre, razon_social, ruc, direccion, usuario);
        }

        public List<TransaccionEL> ActualizarCliente(string cod_cliente, string razon_social, string ruc, string usuario)
        {
            TMS_ClientesDAL oClientes = new TMS_ClientesDAL();
            return oClientes.ActualizarCliente(cod_cliente, razon_social, ruc, usuario);
        }

        public List<TransaccionEL> ActualizarSubCliente(string cod_subcliente, string razon_social, string ruc, string usuario)
        {
            TMS_ClientesDAL oClientes = new TMS_ClientesDAL();
            return oClientes.ActualizarSubCliente(cod_subcliente, razon_social, ruc, usuario);
        }

        public List<TransaccionEL> EliminarCliente(string cod_cliente, string usuario)
        {
            TMS_ClientesDAL oClientes = new TMS_ClientesDAL();
            return oClientes.EliminarCliente(cod_cliente, usuario);
        }

        public List<TransaccionEL> EliminarSubCliente(string cod_Subcliente, string usuario)
        {
            TMS_ClientesDAL oClientes = new TMS_ClientesDAL();
            return oClientes.EliminarSubCliente(cod_Subcliente, usuario);
        }

        public void ActualizarHerencia(string cod_cliente, bool usuario)
        {
            TMS_ClientesDAL oClientes = new TMS_ClientesDAL();
            oClientes.ActualizarHerencia(cod_cliente, usuario);
        }

        public void ActualizarConsolidado(string cod_cliente, bool usuario)
        {
            TMS_ClientesDAL oClientes = new TMS_ClientesDAL();
            oClientes.ActualizarConsolidado(cod_cliente, usuario);
        }
    }
}
