using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ClienteBL
    {
        public List<ClienteEL> ListarCliente()
        {
            ClienteDAL oCliente = new ClienteDAL();
            return oCliente.ListarCliente();
        }
    }
}
