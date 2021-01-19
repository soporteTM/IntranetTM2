using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SeguimientoBL
    {
        public List<SeguimientoEL> ListarSeguimiento(SeguimientoEL oSeguimiento)
        {
            SeguimientoDAL objSeguimiento = new SeguimientoDAL();
            return objSeguimiento.ListarSeguimiento(oSeguimiento);
        }

        public List<SeguimientoEL> RegistrarSeguimiento(SeguimientoEL oSeguimiento,string usu)
        {
            SeguimientoDAL objSeguimiento = new SeguimientoDAL();
            return objSeguimiento.RegistrarSeguimiento(oSeguimiento,usu);
        }

        public List<SeguimientoEL> ActualizarSeguimiento(SeguimientoEL oSeguimiento,string usu)
        {
            SeguimientoDAL objSeguimiento = new SeguimientoDAL();
            return objSeguimiento.ActualizarSeguimiento(oSeguimiento,usu);
        }

        public List<SeguimientoEL> EliminarSeguimiento(SeguimientoEL oSeguimiento)
        {
            SeguimientoDAL objSeguimiento = new SeguimientoDAL();
            return objSeguimiento.EliminarSeguimiento(oSeguimiento);
        }

        
    }
}
