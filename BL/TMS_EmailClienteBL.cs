using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TMS_EmailClienteBL
    {
        TMS_EmailClienteDAL oEmailCliente = new TMS_EmailClienteDAL();

        public List<TMS_EmailClienteEL> GetCorreoCliente(string Ent_Codi)
        {
            return oEmailCliente.GetCorreoCliente(Ent_Codi);
        }

        public List<TMS_EmailClienteEL> GetCorreoCliente(string Ent_Codi, string Movimiento)
        {
            return oEmailCliente.GetCorreoCliente(Ent_Codi,Movimiento);
        }

        public List<TMS_EmailClienteEL> InsertarCorreo(string Ent_Codi, string correo, string movimiento, string usuario)
        {
            return oEmailCliente.InsertarCorreo(Ent_Codi, correo, movimiento, usuario);
        }

        public List<TransaccionEL> EliminarCorreoCliente(string Ent_Codi, string Movimiento, string correo)
        {
            return oEmailCliente.EliminarCorreoCliente(Ent_Codi, Movimiento, correo);
        }
    }
}
