using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TerceroEmpresaBL
    {

        public List<TerceroEmpresaEL> ListarEmpresa()
        {
            TerceroEmpresaDAL oEmpresa = new TerceroEmpresaDAL();
            return oEmpresa.ListarEmpresa();
        }

        public List<TransaccionEL> RegistrarEmpresa(TerceroEmpresaEL objEmpresa)
        {
            TerceroEmpresaDAL oEmpresa = new TerceroEmpresaDAL();
            return oEmpresa.RegistrarEmpresa(objEmpresa);
        }

        public List<TransaccionEL> ActualizarEmpresa(TerceroEmpresaEL objEmpresa)
        {
            TerceroEmpresaDAL oEmpresa = new TerceroEmpresaDAL();
            return oEmpresa.ActualizarEmpresa(objEmpresa);
        }

        public List<TransaccionEL> EliminarEmpresa(TerceroEmpresaEL objEmpresa)
        {
            TerceroEmpresaDAL oEmpresa = new TerceroEmpresaDAL();
            return oEmpresa.EliminarEmpresa(objEmpresa);
        }

    }
}
