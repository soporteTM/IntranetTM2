using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TerceroConductorBL
    {
        public List<TerceroConductorEL> ListarConductor(TerceroConductorEL objConductor)
        {
            TerceroConductorDAL oConductor = new TerceroConductorDAL();
            return oConductor.ListarConductor(objConductor);
        }

        public List<TransaccionEL> RegistrarConductor(TerceroConductorEL objConductor)
        {
            TerceroConductorDAL oConductor = new TerceroConductorDAL();
            return oConductor.RegistrarConductor(objConductor);
        }

        public List<TransaccionEL> ActualizarConductor(TerceroConductorEL objConductor)
        {
            TerceroConductorDAL oConductor = new TerceroConductorDAL();
            return oConductor.ActualizarConductor(objConductor);
        }

        public List<TransaccionEL> EliminarConductor(TerceroConductorEL objConductor)
        {
            TerceroConductorDAL oConductor = new TerceroConductorDAL();
            return oConductor.EliminarConductor(objConductor);
        }
    }
}
