using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TerceroUnidadBL
    {
        public List<TerceroUnidadEL> ListarUnidad(TerceroUnidadEL objUnidad)
        {
            TerceroUnidadDAL oConductor = new TerceroUnidadDAL();
            return oConductor.ListarUnidad(objUnidad);
        }

        public List<TransaccionEL> RegistrarUnidad(TerceroUnidadEL objUnidad)
        {
            TerceroUnidadDAL oUnidad = new TerceroUnidadDAL();
            return oUnidad.RegistrarUnidad(objUnidad);
        }

        public List<TransaccionEL> ActualizarUnidad(TerceroUnidadEL objUnidad)
        {
            TerceroUnidadDAL oUnidad = new TerceroUnidadDAL();
            return oUnidad.ActualizarUnidad(objUnidad);
        }

        public List<TransaccionEL> EliminarUnidad(TerceroUnidadEL objUnidad)
        {
            TerceroUnidadDAL oUnidad = new TerceroUnidadDAL();
            return oUnidad.EliminarUnidad(objUnidad);
        }
    }
}
