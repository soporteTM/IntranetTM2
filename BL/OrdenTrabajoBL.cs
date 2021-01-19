using DAL;
using EL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class OrdenTrabajoBL
    {
        public List<TransaccionEL> RegistrarOT(OrdenTrabajoEL oOrden)
        {
            OrdenTrabajoDAL oOT = new OrdenTrabajoDAL();
            return oOT.RegistrarOT(oOrden);
        }

        public List<TransaccionEL> ActualizarOT(OrdenTrabajoEL oOrden)
        {
            OrdenTrabajoDAL oOT = new OrdenTrabajoDAL();
            return oOT.ActualizarOT(oOrden);
        }

        public List<OrdenTrabajoEL> ListarOT(int id_orden)
        {
            OrdenTrabajoDAL oOT = new OrdenTrabajoDAL();
            return oOT.ListarOT(id_orden);
        }
    }
}
