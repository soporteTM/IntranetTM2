using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class TarifaBL
    {
        public List<TarifaEL> ListarTarifa()
        {
            TarifaDAL oTarifa = new TarifaDAL();
            return oTarifa.ListarTarifa();
        }

        public List<TransaccionEL> RegistrarTarifa(TarifaEL oTarifa)
        {
            TarifaDAL objTarifa = new TarifaDAL();
            return objTarifa.RegistrarTarifa(oTarifa);
        }

    }
}
