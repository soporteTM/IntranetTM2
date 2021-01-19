using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class LiquidacionBL
    {
        public List<LiquidacionEL> ListarLiquidacion()
        {
            LiquidacionDAL oLiquidacion = new LiquidacionDAL();
            return oLiquidacion.ListarLiquidacion();
        }

        public List<TransaccionEL> RegistrarLiquidacion(LiquidacionEL objLiquidacion)
        {
            LiquidacionDAL oLiquidacion = new LiquidacionDAL();
            return oLiquidacion.RegistrarLiquidacion(objLiquidacion);
        }
        
        

        public List<TransaccionEL> EliminarLiquidacion(LiquidacionEL objLiquidacion)
        {
            LiquidacionDAL oLiquidacion = new LiquidacionDAL();
            return oLiquidacion.EliminarLiquidacion(objLiquidacion);
        }

        public List<AbastecimientoEL> LiquidacionDetalle(LiquidacionEL objLiquidacion)
        {
            LiquidacionDAL oLiquidacion = new LiquidacionDAL();
            return oLiquidacion.LiquidacionDetalle(objLiquidacion);
        }

        public List<AbastecimientoEL> EliminarDetalle(AbastecimientoEL objLiquidacion)
        {
            LiquidacionDAL oLiquidacion = new LiquidacionDAL();
            return oLiquidacion.EliminarnDetalle(objLiquidacion);
        }

    }

}

