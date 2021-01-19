using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrdenServicioBL
    {
        public List<TransaccionEL> RegistrarServicio(OrdenServicioEL oServicio)
        {
            OrdenServicioDAL oOT = new OrdenServicioDAL();
            return oOT.RegistrarServicio(oServicio);
        }

        public List<OrdenServicioEL> ListarServicio(int id_orden)
        {
            OrdenServicioDAL oOT = new OrdenServicioDAL();
            return oOT.ListarServicioOT(id_orden);
        }
    }
}
